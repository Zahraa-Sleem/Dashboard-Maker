using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        [HttpPost("CreateColorPalette")]
        public async Task<IActionResult> CreateColorPalette(ColorPalette colorPalette)
        {
            if (ModelState.IsValid)
            {
                _context.ColorPalettes.Add(colorPalette);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(colorPalette);
        }

        [HttpGet("Create")]
        public IActionResult CreateColorPalette()
        {
            return View(new ColorPalette());
        }

        

        [HttpGet("Edit/{id?}")]
        public async Task<IActionResult> EditColorPalette(int? id)
        {
            if (id == null)
            {
                return View(new ColorPalette());
            }

            var colorPalette = await _context.ColorPalettes
                .Include(cp => cp.Colors)
                .FirstOrDefaultAsync(cp => cp.Id == id);

            if (colorPalette == null)
            {
                return NotFound();
            }

            return View(colorPalette);
        }

        [HttpPost("EditColorPalette")]
        public async Task<IActionResult> EditColorPalette(ColorPalette colorPalette)
        {
            if (ModelState.IsValid)
            {
                if (colorPalette.Id == 0)
                {
                    _context.ColorPalettes.Add(colorPalette);
                }
                else
                {
                    _context.ColorPalettes.Update(colorPalette);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); // Replace with the appropriate action and controller
            }

            return View(colorPalette);
        }
    }
}
