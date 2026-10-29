using Microsoft.AspNetCore.Mvc;
using todolist.Data;
using todolist.Models;

namespace todolist.Controllers
{
    public class todoController : Controller
    {
        private readonly Applicationdbcontext _context;
        public todoController (Applicationdbcontext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var task = _context.todoitems.ToList();
            return View(task);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(todoitem items)
        {
            if(ModelState.IsValid)
            {
                _context.todoitems.Add(items);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(items);
        }

        public IActionResult Edit(int id)
        {
            var task = _context.todoitems.Find(id);
            if (task == null) return NotFound();
            return View(task);
            
        }
        [HttpPost]
        public IActionResult Edit(todoitem item)
        {
            if(ModelState.IsValid)
            {
                _context.todoitems.Update(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public IActionResult Delete(int id)
        {
            var task = _context.todoitems.Find(id);
            if (task == null) return NotFound();
            return View(task);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _context.todoitems.Find(id);
            if (task != null)
            {
                _context.todoitems.Remove(task);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var task = _context.todoitems.Find(id);
            if (task == null)
                return NotFound();
            return View(task);
        }


    }
}
