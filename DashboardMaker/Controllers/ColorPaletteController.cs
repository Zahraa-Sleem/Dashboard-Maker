using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        [HttpGet("Create")]
        public IActionResult CreateColorPalette()
        {
            return View("ColorPaletteForm",new ColorPalette());
        }

        [HttpGet("Edit/{id}")]
        public IActionResult UpdateColorPalette(int id)
        {
            var colorPalette = _context.ColorPalettes.Find(id);

            if (colorPalette == null) { return NotFound(); }

            return View("ColorPaletteForm", colorPalette);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(ColorPalette colorPalette)
        {
            //colorPalette.Colors = JsonConvert.DeserializeObject<ICollection<Color>>(colorPalette.Colors);

            //Checking the model validity before action
            if (!ModelState.IsValid)
            {
                return View("ColorPaletteForm", colorPalette);
            }

            if(colorPalette.Id == 0)
            {
                _context.ColorPalettes.Add(colorPalette);
                await _context.SaveChangesAsync();
            }
            else
            {
                //fetch the color palette from the database
                var colorPaletteInDb = _context.ColorPalettes.Find(colorPalette.Id);

                //if found edit the data
                if (colorPaletteInDb != null)
                {
                    _context.ColorPalettes.Update(colorPalette);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }
            return View("ColorPaletteForm", colorPalette);
        }
    }
}
