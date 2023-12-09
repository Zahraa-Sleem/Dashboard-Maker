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
        public Boolean CheckIfColorExists(string hexadecimal)
        {
            //fetch the color from the database and return if its there
            var colorInDb = _context.Colors.Find(hexadecimal);
            return colorInDb != null;
        }
    }
}
