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
                .Where(b => b.Completed==false)
                .Include(x => x.Category)
                .ToList();
            return View(tasks);
        }

        public IActionResult NewTask()
        {
            ViewBag.Categories = _context.Categories.ToList(); // pass categories table so they can be listed in the dropdown
            return View();
        }

        public IActionResult Update(int id)
        {
            var taskToEdit = _context.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _context.Categories.ToList();

            return View("NewTask", taskToEdit);
        }

        [HttpPost]
        public IActionResult Update(TaskEntry t)
        {
            _context.Update(t);
            _context.SaveChanges();

            return RedirectToAction("Quadrant");
        }

        [HttpPost]
        public IActionResult NewTask(TaskEntry t)
        {
            _context.Update(t);
            _context.SaveChanges();

            return RedirectToAction("Quadrant");
        }

        public IActionResult Delete(int id)
        {
            var taskToDelete = _context.Tasks
                .Where(x => x.TaskId == id)
                .FirstOrDefault();

            return View(taskToDelete);
        }

        [HttpPost]
        public IActionResult Delete(TaskEntry task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return RedirectToAction("Quadrant");
        }

    }
}
