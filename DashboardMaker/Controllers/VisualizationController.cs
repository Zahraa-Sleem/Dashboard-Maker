using DashboardMaker.Data;
using DashboardMaker.Models;
using DashboardMaker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DashboardMaker.Controllers
{
	[Route("/Visualization")]
	public class VisualizationController : Controller
	{
		private readonly ApplicationDbContext _context;

		public VisualizationController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("Create")]
		public IActionResult CreateVisualization(int id)
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
				DataSources = _context.DataSources.Where(d => d.OwnerId == owner).ToList()
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

	}
}
