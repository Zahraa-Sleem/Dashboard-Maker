using Dapper;
using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MySqlConnector;
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

			// Build and execute the query based on the database type
			var query = DataSource.DataSourceType == "SQL Database"
			? db.Query("INFORMATION_SCHEMA.TABLES").Select("TABLE_NAME").Where("TABLE_TYPE", "BASE TABLE")
			: db.Query("INFORMATION_SCHEMA.TABLES")
				.Select("TABLE_NAME")
				.Where("TABLE_SCHEMA", "!=", "mysql")
				.Where("TABLE_SCHEMA", "!=", "information_schema")
				.Where("TABLE_SCHEMA", "!=", "performance_schema")
				.Where("TABLE_SCHEMA", "!=", "sys")
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
					var command = CreateCommand(connection, tableName);

					using (var reader =  command.ExecuteReader())
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
				return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
			}
		}

		private IDbConnection CreateConnection(DataSource dataSource)
		{
			return dataSource.DataSourceType switch
			{
				"SQL Database" => new SqlConnection(dataSource.ConnectionString),
				"MySQL Database" => new MySqlConnection(dataSource.ConnectionString),
				_ => throw new ArgumentException("Unsupported database type.")
			};
		}

		private IDbCommand CreateCommand(IDbConnection connection, string tableName)
		{
			IDbCommand command = connection.CreateCommand();
			command.CommandText = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @tableName";
			var parameter = command.CreateParameter();
			parameter.ParameterName = "@tableName";
			parameter.Value = tableName;
			command.Parameters.Add(parameter);

			return command;
		}

	}
}
