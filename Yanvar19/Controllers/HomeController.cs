using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yanvar19.Contexts;

namespace Yanvar19.Controllers
{
    public class HomeController : Controller
    {
        Yanvar19DbContext _context;

        public HomeController(Yanvar19DbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Instructors.ToListAsync());
        }

        
    }
}