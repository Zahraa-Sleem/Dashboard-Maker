using DashboardMaker.Data;
using DashboardMaker.Models;
using DashboardMaker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data.Common;
using System.Net.Http;
using System.Security.Claims;

namespace DashboardMaker.Controllers
{
	[Route("Visualization")]
	public class VisualizationController : Controller
	{
		private readonly ApplicationDbContext _context;

		public VisualizationController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("Create/{id}")]
		public async Task<IActionResult> CreateVisualization(int id)
		{
			string owner = null;
			if (User.FindFirstValue(ClaimTypes.NameIdentifier) != null)
			{
				owner = _context.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier)).Id;
			}

			VisualizationViewModel model = new VisualizationViewModel()
			{
				Visualization = new Visualization()
				{
					DashboardId = id
				},
				DataSources = _context.DataSources.Where(d => d.OwnerId == owner).ToList(),
				ColorPalettes = await GetPalettes()
			};

			return View("VisualizationForm", model);
		}


		[HttpGet("Edit/{id}")]
		public IActionResult UpdateVisualization(int id)
		{
			var visualization = _context.Visualizations.Find(id);

			if (visualization == null) { return NotFound(); }

			return View("VisualizationForm", visualization);
		}

		[HttpPost("Save")]
		public async Task<IActionResult> Save(VisualizationViewModel model)
		{
			// Checking the model validity before action
			if (ModelState.TryGetValue("Visualization", out var stateEntry) && stateEntry.Errors.Any())
			{
				// There are validation errors in the Visualization property
				return View("VisualizationForm", model);
			}

			// Checking if the visualization is new or old
			if (model.Visualization.Id == 0)
			{
				// Visualization is new
				var dataSourceType = _context.DataSources.Find(model.Visualization.DataSourceId).DataSourceType;
				if (dataSourceType == "MySQL Database" || dataSourceType == "SQL Database")
				{
					// Check that TablesJoin is not null or empty
					if (model.Visualization.TablesJoin != null)
					{
						// Assuming _context is your database context and Visualization is a DbSet
						_context.Visualizations.Add(model.Visualization);
						// Attempt to save changes to the database
						await _context.SaveChangesAsync();
						return RedirectToAction("Index", "Home");
					}
					else
					{
						// TablesJoin is null or empty
						ModelState.AddModelError("", "Tables join configuration must be provided for database sources.");
						return View("VisualizationForm", model);
					}
				}
				// Handle other DataSourceTypes
				else if (model.Visualization.DataSource.DataSourceType == "Excel File")
				{
					// Handle Excel file data source
					// ...
				}
				else
				{
					return BadRequest("Not a valid data source type.");
				}
			}
			else
			{
				// Visualization is old (existing), handle updating the visualization
				// ...
			}

			return RedirectToAction(nameof(Index));
		}


		// Helpers
		[HttpGet("GetPalettes")]
		private async Task<IEnumerable<ColorPaletteViewModel>> GetPalettes()
		{
			var palettes = await _context.ColorPalettes
			.Select(palette => new ColorPaletteViewModel
			{
				Id = palette.Id,
				Name = palette.Name,
				SelectedColors = String.Join(",", _context.ColorColorPalettes
					.Where(ccp => ccp.ColorPaletteId == palette.Id)
					.Select(ccp => ccp.Color.HexadecimalValue))
			})
			.ToListAsync();

			return palettes;
		}
	}
}
