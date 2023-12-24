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
			string owner = null;
			if (User.FindFirstValue(ClaimTypes.NameIdentifier) != null)
			{
				owner = _context.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier)).Id;
			}

			return await _context.DataSources.Where(d => d.OwnerId == owner).ToListAsync();
		}
	}
}
