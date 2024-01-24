using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DashboardMaker.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class ColorPaletteController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public ColorPaletteController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("GetColorsFromColorPalette")]
		public async Task<ActionResult<IEnumerable<string>>> GetColorsFromColorPalette(int paletteId)
		{
			var colors = _context.ColorColorPalettes
				.Where(c => c.ColorPaletteId == paletteId)
				.Select(c => c.hexadecimal)
				.ToList();

			return colors;
		}
	}
}
