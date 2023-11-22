using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Mvc;

namespace DashboardMaker.Controllers
{
    [Route("/ColorPalette")]
    public class ColorPaletteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColorPaletteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Edit")]
        public IActionResult EditColorPalette()
        {
            return View(new ColorPalette());
        }
    }
}
