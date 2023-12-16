using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardMaker.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class VisualizationTypeController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public VisualizationTypeController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<VisualizationType>>> GetTypes()
		{
			if (_context.VisualizationTypes == null)
			{

				return NotFound();
			}
			return await _context.VisualizationTypes.ToListAsync();
		}
	}
}
