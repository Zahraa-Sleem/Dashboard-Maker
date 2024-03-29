﻿using Microsoft.AspNetCore.Mvc;
using DashboardMaker.Models;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using SqlKata.Compilers;
using SqlKata.Execution;
using Microsoft.AspNetCore.Http;
using DashboardMaker.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace DashboardMaker.Controllers
{
    [Route("DataSource")]
	[Authorize]
	public class DataSourceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataSourceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("All")]
        public IActionResult Index()
        {
            var dataSources = _context.DataSources.ToList();
            return View(dataSources);
        }


        [HttpGet("Add")]
        public async Task<IActionResult> AddDataSource()
        {
            DataSource model = new DataSource()
            {
                OwnerId = _context.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier)).Id
            };
            return View("DataSourceForm", model);
        }

        [HttpGet("Update")]
        public async Task<IActionResult> UpdateDataSource(int id)
        {
            var datasource = _context.DataSources.Find(id);

            if (datasource == null) { return NotFound(); }

            return View("DataSourceForm", datasource);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(DataSource dataSource)
        {
			//Checking the model validity before action
			if (!ModelState.IsValid)
            {
                return View("DataSourceForm", dataSource);
            }
            //checking if the data source is new or old
            if (dataSource.Id == 0)
            {
                //data source is new
                if (dataSource.DataSourceType == "MySQL Database")
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
                    catch
                    {
                        ModelState.AddModelError("", "Error connecting to the database.Make sure the inputs you've added are right.");
                        return View("DataSourceForm", dataSource);
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
                    catch
                    {
                        ModelState.AddModelError("", "Error connecting to the database.Make sure the inputs you've added are right.");
                        return View("DataSourceForm", dataSource);
                    }
                }
                else if (dataSource.DataSourceType == "Excel File")
                {
                    _context.DataSources.Add(dataSource);
                    _context.SaveChanges();
                    return View("DataSourceForm", dataSource);
                }
            }
            else
            {
                //fetch the datasource from the database
                var dataSourceInDb = _context.DataSources.Find(dataSource.Id);

                //if found edit the data
                if (dataSourceInDb != null)
                {
                    _context.DataSources.Update(dataSource);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

