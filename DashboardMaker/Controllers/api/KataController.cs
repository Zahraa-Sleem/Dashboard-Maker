using Dapper;
using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using Newtonsoft.Json;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data;

namespace DashboardMaker.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class KataController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public KataController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("GetTables")]
		public async Task<ActionResult<List<string>>> GetTables(int dataSourceId)
		{
			var DataSource = _context.DataSources.Find(dataSourceId);
			if (DataSource == null)
			{
				return NotFound("Data source not found.");
			}
			var tables = new List<string>();
			QueryFactory db;

			if (DataSource.DataSourceType == "SQL Database")
			{
				db = new QueryFactory(new SqlConnection(DataSource.ConnectionString), new SqlServerCompiler());
			}
			else if (DataSource.DataSourceType == "MySQL Database")
			{
				db = new QueryFactory(new MySqlConnection(DataSource.ConnectionString), new MySqlCompiler());
			}
			else
			{
				throw new NotImplementedException("Database type not supported");
			}

			// Extract the database name from the connection string
			var databaseNameKeyValue = DataSource.ConnectionString
				.Split(';')
				.Select(part => part.Split('='))
				.FirstOrDefault(part => part[0].Equals("Database", StringComparison.OrdinalIgnoreCase));

			if (databaseNameKeyValue == null || databaseNameKeyValue.Length < 2)
			{
				return BadRequest("The database name could not be found in the connection string.");
			}

			string databaseName = databaseNameKeyValue[1];

			// Build and execute the query based on the database type
			var query = DataSource.DataSourceType == "SQL Database"
				? db.Query("INFORMATION_SCHEMA.TABLES")
				.Select("TABLE_NAME")
				.Where("TABLE_SCHEMA", "=", "dbo")
				.Where("TABLE_TYPE", "BASE TABLE")
			: db.Query("INFORMATION_SCHEMA.TABLES")
				.Select("TABLE_NAME")
				.Where("TABLE_SCHEMA", "=", databaseName)
				.Where("TABLE_TYPE", "BASE TABLE");


			var results = await db.GetAsync<dynamic>(query);

			foreach (var result in results)
			{
				// Extract table name depending on the database type
				string tableName;
				if (DataSource.DataSourceType == "SQL Database")
				{
					tableName = result.TABLE_NAME;
				}
				else // MySQL Database
				{
					var resultDictionary = (IDictionary<string, object>)result;
					tableName = resultDictionary.Values.First().ToString();
				}
				tables.Add(tableName);
			}
			return tables;
		}

		[HttpGet("GetColumns")]
		public async Task<ActionResult<List<string>>> GetColumns(int dataSourceId, string tableName)
		{
			// Find the dataSource from the database
			var dataSource = await _context.DataSources.FindAsync(dataSourceId);
			if (dataSource == null)
			{
				return NotFound("DataSource not found.");
			}

			if (string.IsNullOrWhiteSpace(tableName))
			{
				return BadRequest("Table name is required.");
			}

			try
			{
				var columns = new List<string>();
				using (IDbConnection connection = CreateConnection(dataSource))
				{
					connection.Open();
					IDbCommand command; // Changed 'var' to 'IDbCommand'

					if (dataSource.DataSourceType == "SQL Database")
					{
						command = CreateCommand(connection, tableName, "dbo");
					}
					else // Assuming the else block handles MySQL Database
					{
						var databaseNameKeyValue = dataSource.ConnectionString
							.Split(';')
							.Select(part => part.Split('='))
							.FirstOrDefault(part => part[0].Equals("Database", StringComparison.OrdinalIgnoreCase));

						if (databaseNameKeyValue == null || databaseNameKeyValue.Length < 2)
						{
							return BadRequest("The database name could not be found in the connection string.");
						}

						string databaseName = databaseNameKeyValue[1];
						command = CreateCommand(connection, tableName, databaseName);
					}

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							columns.Add(reader.GetString(0));
						}
					}
				}
				return Ok(columns);
			}
			catch (Exception ex)
			{
				// It's a good practice to log the exception here
				return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
			}
		}


		[HttpGet("GetDataForAGraph/{visualizationId}")]
		public async Task<ActionResult<List<string>>> GetDataForAGraph(int visualizationId)
		{
			// Find the visualization from the database
			var visualization = await _context.Visualizations.FindAsync(visualizationId);
			if (visualization == null)
			{
				return NotFound("Visualization not found.");
			}

			DataSource dataSource = await _context.DataSources.FindAsync(visualization.DataSourceId);
			if (dataSource == null)
			{
				return NotFound("Data source not found.");
			}

			if (dataSource.DataSourceType == "MySQL Database" || dataSource.DataSourceType == "SQL Database")
			{
				var tableColumns = System.Text.Json.JsonSerializer.Deserialize<TableColumns>(visualization.TablesColumns);
				using (var connection = CreateConnection(dataSource))
				{
					connection.Open();
					string columns = string.Join(", ", tableColumns.columns);
					string query = $"SELECT {columns} FROM {tableColumns.table}";

					using (var command = connection.CreateCommand())
					{
						command.CommandText = query;
						try
						{
							using (var reader = command.ExecuteReader())
							{
								var results = new List<RowData>();
								while (reader.Read())
								{
									var rowData = new RowData();
									for (int i = 0; i < reader.FieldCount; i++)
									{
										var columnData = new ColumnData
										{
											ColumnName = reader.GetName(i),
											Value = reader.IsDBNull(i) ? "null" : reader.GetValue(i).ToString()
										};
										rowData.Columns.Add(columnData);
									}
									results.Add(rowData);
								}
								Console.WriteLine(results);
								return Ok(results);
							}
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.ToString());
						}
					}
				}
				return Ok();
			}
			else
			{
				return BadRequest("Unsupported data source type.");
			}
		}
		[HttpGet("getColumnsTypes")]
		public async Task<ActionResult<List<ColumnType>>> GetColumnsTypes(string selectedColumns,int DataSourceId,string TableName)
		{
			var columns = JsonConvert.DeserializeObject<List<string>>(selectedColumns);
			if (columns == null || !columns.Any())
			{
				return BadRequest("No columns specified.");
			}

			var dataSource = await _context.DataSources.FindAsync(DataSourceId);
			if (dataSource == null)
			{
				return NotFound("DataSource not found.");
			}

			try
			{
				var columnTypes = new List<ColumnType>();
				using (IDbConnection connection = CreateConnection(dataSource))
				{
					connection.Open();
					foreach (var column in columns)
					{
						var dbSchema = dataSource.DataSourceType == "SQL Database" ? "dbo" : ExtractDatabaseName(dataSource.ConnectionString);
						var query = @"SELECT DATA_TYPE 
                              FROM INFORMATION_SCHEMA.COLUMNS 
                              WHERE TABLE_NAME = @tableName 
                              AND COLUMN_NAME = @columnName 
                              AND TABLE_SCHEMA = @schemaName";

						using (var command = connection.CreateCommand())
						{
							command.CommandText = query;

							var tableNameParameter = command.CreateParameter();
							tableNameParameter.ParameterName = "@tableName";
							tableNameParameter.Value = TableName;
							command.Parameters.Add(tableNameParameter);

							var columnNameParameter = command.CreateParameter();
							columnNameParameter.ParameterName = "@columnName";
							columnNameParameter.Value = column;
							command.Parameters.Add(columnNameParameter);

							var schemaNameParameter = command.CreateParameter();
							schemaNameParameter.ParameterName = "@schemaName";
							schemaNameParameter.Value = dbSchema;
							command.Parameters.Add(schemaNameParameter);

							var dataType =  command.ExecuteScalar() as string;
							columnTypes.Add(new ColumnType
							{
								ColumnName = column,
								DataType = dataType
							});
						}
					}
				}

				return Ok(columnTypes);
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
			}
		}

		// helper functions
		private IDbConnection CreateConnection(DataSource dataSource)
		{
			return dataSource.DataSourceType switch
			{
				"SQL Database" => new SqlConnection(dataSource.ConnectionString),
				"MySQL Database" => new MySqlConnection(dataSource.ConnectionString),
				_ => throw new ArgumentException("Unsupported database type.")
			};
		}

		private string ExtractDatabaseName(string connectionString)
		{
			var databaseNameKeyValue = connectionString
				.Split(';')
				.Select(part => part.Split('='))
				.FirstOrDefault(part => part[0].Equals("Database", StringComparison.OrdinalIgnoreCase));

			return databaseNameKeyValue?.Length == 2 ? databaseNameKeyValue[1] : null;
		}

		private IDbCommand CreateCommand(IDbConnection connection, string tableName, string schemaName)
		{
			IDbCommand command = connection.CreateCommand();
			command.CommandText = @"SELECT COLUMN_NAME 
                            FROM INFORMATION_SCHEMA.COLUMNS 
                            WHERE TABLE_NAME = @tableName 
                            AND TABLE_SCHEMA = @schemaName";

			var tableNameParameter = command.CreateParameter();
			tableNameParameter.ParameterName = "@tableName";
			tableNameParameter.Value = tableName;
			command.Parameters.Add(tableNameParameter);

			var schemaNameParameter = command.CreateParameter();
			schemaNameParameter.ParameterName = "@schemaName";
			schemaNameParameter.Value = schemaName;
			command.Parameters.Add(schemaNameParameter);

			return command;
		}




		// Helper class to deserialize the JSON
		public class TableColumns
		{
			public string table { get; set; }
			public List<string> columns { get; set; }
		}

		// Helper classes to use for generic data and different data types
		public class RowData
		{
			public List<ColumnData> Columns { get; set; } = new List<ColumnData>();
		}

		public class ColumnData
		{
			public string ColumnName { get; set; }
			public string Value { get; set; }
		}

		public class ColumnsRequest
		{
			public List<string> Columns { get; set; }
			public int DataSourceId { get; set; }
			public string TableName { get; set; }
		}

		public class ColumnType
		{
			public string ColumnName { get; set; }
			public string DataType { get; set; }
		}
	}
}
