using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Mvc;

namespace DashboardMaker.Controllers
{
    [Route("/Color")]
    public class ColorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ColorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Color GetColorId(string hexadecimal)
        {
            //fetch the color from the database
            var colorInDb = _context.Colors.Find(hexadecimal);
            if(colorInDb == null)
            {
                // Color doesn't exist, so add it to the database
                var newColor = new Color(hexadecimal);
                _context.Colors.Add(newColor);
                _context.SaveChanges();
            }

            // Return the color object
            return _context.Colors.Find(hexadecimal);
        }
    }
}
