using Microsoft.AspNetCore.Mvc;
using DashboardMaker.Models;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using SqlKata.Compilers;
using SqlKata.Execution;
using Microsoft.AspNetCore.Http;

namespace DashboardMaker.Controllers
{
    public class DataSourceController : Controller
    {
        //[HttpGet]
        //public async Task<IActionResult> AddDataSource()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddDataSource(DataSource dataSource)
        //{
        //    var connString = $"Server={dataSource.Host};User ID={dataSource.UserName};Password={dataSource.Password};Database={dataSource.DatabaseName}";

        //    using var connection = new MySqlConnection(connString);

        //    var compiler = new MySqlCompiler(); // Assuming you're using MySQL
        //    var db = new QueryFactory(connection, compiler);

        //    // Construct the query to select data from the specified table
        //    var query = db.Query(dataSource.TableName).Get();
        //    Console.WriteLine(query.First());
        //    return View();
        //}

    }
}
