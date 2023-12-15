using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace DashboardMaker.Controllers
{
	[Authorize]
	[Route("/Dashboard")]
	public class DashboardController : Controller
	{
		private readonly ApplicationDbContext _context;

		public DashboardController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("Create")]
		public IActionResult CreateDashboard()
		{
			return View("DashboardForm", new Dashboard());
		}

		[HttpGet("Edit/{id}")]
		public IActionResult UpdateDashboard(int id)
		{
			var dashboard = _context.Dashboards.Find(id);

			if (dashboard == null) { return NotFound(); }

			return View("DashboardForm", dashboard);
		}

		[HttpPost("Save")]
		public IActionResult Save(Dashboard dashboard)
		{
			if (User.FindFirstValue(ClaimTypes.NameIdentifier) != null)
			{
				dashboard.Owner = _context.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));
			}
			else
			{
				Console.WriteLine(User.FindFirstValue(ClaimTypes.NameIdentifier));
				// Redirect to the login page to handle the unauthenticated user.
				return RedirectToAction("Index", "Home");
			}

			//// Checking the model validity before action
			//if (!ModelState.IsValid)
			//{
			//	// If not valid, redirect to the form with posted data
			//	return View("DashboardForm", dashboard);
			//}

			// Checking if the dashboard is new or old
			if (dashboard.Id == 0)
			{
				// If new, add the dashboard
				_context.Dashboards.Add(dashboard);
			}
			else
			{
				// Fetch the dashboard from the database
				var dashboardInDb = _context.Dashboards.Find(dashboard.Id);

				// If found, update the data
				if (dashboardInDb != null)
				{
					dashboardInDb.Title = dashboard.Title;
				}
				else // Report error
				{
					return NotFound();
				}
			}

			// Save changes to the database
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
