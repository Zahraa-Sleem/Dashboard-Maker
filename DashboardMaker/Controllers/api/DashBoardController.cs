using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DashboardMaker.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class DashboardController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public DashboardController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("GetUserDashboards")]
		public async Task<ActionResult<IEnumerable<Dashboard>>> GetDashboardsForUser()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (string.IsNullOrEmpty(userId))
			{
				return Unauthorized();
			}

			var user = await _context.Users.FindAsync(userId);
			if (user == null)
			{
				return NotFound("User not found.");
			}

			var dashboards = await _context.Dashboards
										   .Where(d => d.Owner.Id == user.Id)
										   .ToListAsync();

			if (!dashboards.Any())
			{
				return NotFound("No dashboards found for the user.");
			}

			return dashboards;
		}

	}
}
