using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Threading.Tasks;

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

		[HttpGet]
		public async Task<ActionResult<List<string>>> GetTables(int dataSourceId)
		{
			var DataSource = _context.DataSources.Find(dataSourceId);
			var tables = new List<string>();

			QueryFactory db;

			if (DataSource.DataSourceType == "SQL Database")
			{
				// Set up SQL Server connection
				db = new QueryFactory(new SqlConnection(DataSource.ConnectionString), new SqlServerCompiler());
			}
			else if (DataSource.DataSourceType == "MySQL Database")
			{
				// Set up MySQL connection
				db = new QueryFactory(new MySqlConnection(DataSource.ConnectionString), new MySqlCompiler());
			}
			else
			{
				// Handle other types or throw an exception
				throw new NotImplementedException("Database type not supported");
			}

			// Build and execute the query based on the database type
			//var query = DataSource.DataSourceType == "SQL Database"
			//? db.Query("INFORMATION_SCHEMA.TABLES").Select("TABLE_NAME").Where("TABLE_TYPE", "BASE TABLE")
			//: db.Query().SelectRaw("TABLE_NAME").FromRaw("INFORMATION_SCHEMA.TABLES");

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
	}
}
