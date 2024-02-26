using Microsoft.AspNetCore.Mvc;
using Putting_Things_First_1_12.Models;
using System.Diagnostics;

namespace Putting_Things_First_1_12.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext _context; // make context usable

        public HomeController(TaskContext temp) // make context usable
        {
            _context = temp;
        }

        public IActionResult Quadrant()
        {
            return View();
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
