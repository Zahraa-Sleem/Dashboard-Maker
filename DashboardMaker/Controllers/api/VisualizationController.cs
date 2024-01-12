using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardMaker.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class VisualizationController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public VisualizationController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("GetByDashboard/{dashboardId}")]
		public async Task<ActionResult<IEnumerable<Visualization>>> GetVisualizations(int dashboardId)
		{
			if(dashboardId <= 0)
			{
				return BadRequest("Invalid dashboard");
			}
			var dashboard = await _context.Dashboards.FindAsync(dashboardId);
			if (dashboard == null)
			{
				return NotFound();
			}
			var visualizations = await _context.Visualizations
				.Where(v => v.DashboardId == dashboardId) 
				.ToListAsync();

			return Ok(visualizations);
		}

	}
}
