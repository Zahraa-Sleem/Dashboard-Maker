using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardMaker.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class ColorPaletteController: ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public ColorPaletteController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<object>>> GetPalettes()
		{
			if (_context.ColorColorPalettes == null)
			{
				return NotFound();
			}

			// Select the required data: each ColorPaletteId with its colors
			var palettesWithColors = await _context.ColorColorPalettes
				.Select(palette => new
				{
					ColorPaletteId = palette.ColorPaletteId,
					Colors = palette.Palette.Colors
				})
				.ToListAsync();

			return palettesWithColors;
		}

	}
}
