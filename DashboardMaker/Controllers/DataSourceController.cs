using Microsoft.AspNetCore.Mvc;
using DashboardMaker.Models;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using SqlKata.Compilers;
using SqlKata.Execution;
using Microsoft.AspNetCore.Http;
using DashboardMaker.Data;

namespace DashboardMaker.Controllers
{
    public class DataSourceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataSourceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> AddDataSource()
        {
            return View(new DataSource());
        }

        [HttpPost]
        public async Task<IActionResult> AddDataSource(DataSource dataSource)
        {
            if (ModelState.IsValid)
            {
                if(dataSource.DataSourceType == "MySQL Database")
                {
                    try
                    {
                        // Checking if connection string is valid.
                        using var connection = new MySqlConnection(dataSource.ConnectionString);
                        await connection.OpenAsync();

                        // If the connection is successful, proceed to add the DataSource to the database
                        _context.DataSources.Add(dataSource);
                        _context.SaveChanges();

                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, $"Error connecting to the database.Make sure the inputs you've added are right.");
                        return View(dataSource);
                    }
                }
               else if (dataSource.DataSourceType == "SQL Database")
                {
                    try
                    {

                        // Checking if connection string is valid.
                        using var connection = new SqlConnection(dataSource.ConnectionString);
                        await connection.OpenAsync();

                        // If the connection is successful, proceed to add the DataSource to the database
                        _context.DataSources.Add(dataSource);
                        _context.SaveChanges();

                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, $"Error connecting to the database.Make sure the inputs you've added are right.");
                        return View(dataSource);
                    }
                }
                else if (dataSource.DataSourceType == "Excel File")
                {
                    Console.WriteLine("*****************************************************" +
                        "In excel"+
                       "**************************************");
                    _context.DataSources.Add(dataSource);
                    _context.SaveChanges();
                }
            }
            return View("Index","Home");
        }
    }
}
