using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Putting_Things_First_1_12.Models;
using SQLitePCL;
using System.Diagnostics;

namespace Putting_Things_First_1_12.Controllers
{
    public class HomeController : Controller
    {
        //private EnterTaskContext _context; // make context usable

        //public HomeController(EnterTaskContext temp) // make context usable
        //{
        //    _context = temp;
        //}

        private ITasksRepository _repo;

        public HomeController(ITasksRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Quadrant()
        {
            var tasks = _repo.Tasks
                .ToList();

            return View(tasks);

        }

        public IActionResult NewTask()
        {
            ViewBag.Categories = _repo.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult NewTask(TaskEntry t)
        {
            _repo.Add(t);

            return RedirectToAction("Quadrant");
        }

        public IActionResult Update(int id)
        {
            TaskEntry update = _repo.Update(id);

            ViewBag.Categories = _repo.Categories.ToList();

            return View("NewTask", update);
        }

        [HttpPost]
        public IActionResult Update(TaskEntry t)
        {
            _repo.Update(t);

            return RedirectToAction("Quadrant");
        }

        public IActionResult Delete(int id)
        {
            TaskEntry delete = _repo.Delete(id);

            return View(delete);
        }

        [HttpPost]
        public IActionResult Delete(TaskEntry t)
        {
            _repo.Delete(t);
            return RedirectToAction("Quadrant");
        }

        //[HttpPost]
        //public IActionResult Delete(TaskEntry task)
        //{
        //    _context.Tasks.Remove(task);
        //    _context.SaveChanges();

        //    return RedirectToAction("Quadrant");
        //}

    }
}
