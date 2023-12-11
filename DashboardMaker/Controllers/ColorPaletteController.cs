using DashboardMaker.Data;
using DashboardMaker.Models;
using DashboardMaker.Models.ViewModels;
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
            return View("ColorPaletteForm",new ColorPaletteViewModel());
        }

        [HttpGet("Edit/{id}")]
        public IActionResult UpdateColorPalette(int id)
        {
            var colorPalette = _context.ColorPalettes.Find(id);

            if (colorPalette == null) { return NotFound(); }

			var colors = _context.ColorColorPalettes.Where(e => e.ColorPaletteId == id).Select(e => e.hexadecimal).ToList();
			string colorsAsString = JsonConvert.SerializeObject(colors);
			return View("ColorPaletteForm", new ColorPaletteViewModel(id,colorPalette.Name,colorsAsString));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(ColorPaletteViewModel colorPalette)
        {

            // check if each in the selected colors is created
            //if not created;create it
            var colorsArray = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(colorPalette.SelectedColors);
            foreach (var color in colorsArray)
            {
                var colorInDb = _context.Colors.Find(color);
                if (colorInDb == null)
                {
                    // Color doesn't exist, so add it to the database
                    var newColor = new Color(color);
                    _context.Colors.Add(newColor);
                }
            }
            await _context.SaveChangesAsync();
            // now we are sure that every color created is in the db 

            if(colorPalette.Id == 0)
            {
                // create color palette
                var newColorPalette = new ColorPalette(colorPalette.Name);
                _context.ColorPalettes.Add(newColorPalette);
                await _context.SaveChangesAsync();

                // fill the rows of the many to many table (ColorColorPalette)
                // After SaveChangesAsync, the ID property of newColorPalette will be updated
                int newColorPaletteId = newColorPalette.Id;
                // for each color create a row of (color,paletteid)
                foreach (var color in colorsArray)
                {
                    _context.ColorColorPalettes.Add(new ColorColorPalette(color,newColorPaletteId));
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                //fetch the color palette from the database
                var colorPaletteInDb = _context.ColorPalettes.Find(colorPalette.Id);

                //if found edit the data
                if (colorPaletteInDb != null)
                {
                    // change name since it is the only attribute
                    colorPaletteInDb.Name = colorPalette.Name;
                    
                    // deal with the colors
                    //remove colors that are removed or add others that are re-added
                    var oldcolors=_context.ColorColorPalettes.Where(e => e.ColorPaletteId == colorPalette.Id).Select(e => e.hexadecimal).ToArray();

                    // for elements that are removed during update;we have to delete them
                    // get these elements
                    var removed = oldcolors.Except(colorsArray).ToList();

                    var entitiesToRemove = _context.ColorColorPalettes.Where(e => e.ColorPaletteId == colorPalette.Id && removed.Contains(e.Color.HexadecimalValue));
                    _context.ColorColorPalettes.RemoveRange(entitiesToRemove);

                    // get the elements added
                    var added=colorsArray.Except(oldcolors);
                    Console.WriteLine("added");
                    foreach(var add in added)
                    {
                        Console.WriteLine(add);
                    }
                    Console.WriteLine("initial");
                    foreach (var add in colorsArray)
                    {
                        Console.WriteLine(add);
                    }
                    foreach (var color in added)
                    {
                        _context.ColorColorPalettes.Add(new ColorColorPalette(color, colorPalette.Id));      
                    }
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }
            // we will not reach here
            return View("ColorPaletteForm", colorPalette);
        }
    }
}
