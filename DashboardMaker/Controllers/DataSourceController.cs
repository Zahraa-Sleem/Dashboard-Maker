using Microsoft.AspNetCore.Mvc;
using DashboardMaker.Models;
using Microsoft.Data.SqlClient;
using MySqlConnector;

namespace DashboardMaker.Controllers
{
    public class DataSourceController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> AddDataSource()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDataSource(DataSource dataSource)
        {
            var connString = $"Server={dataSource.Host};User ID={dataSource.UserName};Password={dataSource.Password};Database={dataSource.DatabaseName}";
            await using var connection = new MySqlConnection(connString);
            await connection.OpenAsync();
            using var command = new MySqlCommand($"SELECT * FROM {dataSource.TableName}", connection);

            await using var reader = await command.ExecuteReaderAsync();

            // Check if there are any rows in the result set and read the first column from the first row
            if (await reader.ReadAsync())
            {
                var value = reader[0].ToString(); // You may want to change this based on your needs
                return Content(value);
            }

            // If no rows are found
            return Content("No data found.");
        }
    }
}
