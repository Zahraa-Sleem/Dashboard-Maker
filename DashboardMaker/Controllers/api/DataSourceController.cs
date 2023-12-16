using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardMaker.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class DataSourceController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public DataSourceController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<DataSource>>> GetDataSources()
		{
			if (_context.DataSources == null)
			{

				return NotFound();
			}
			return await _context.DataSources.ToListAsync();
		}
	}
}
