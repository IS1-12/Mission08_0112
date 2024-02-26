using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Putting_Things_First_1_12.Models;
using SQLitePCL;
using System.Diagnostics;

namespace Putting_Things_First_1_12.Controllers
{
    public class HomeController : Controller
    {
        private EnterTaskContext _context; // make context usable

        public HomeController(EnterTaskContext temp) // make context usable
        {
            _context = temp;
        }

        public IActionResult Quadrant()
        {
            var tasks = _context.Tasks
                .Include(x => x.Category)
                .ToList();
            return View(tasks);
        }

        public IActionResult NewTask()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
