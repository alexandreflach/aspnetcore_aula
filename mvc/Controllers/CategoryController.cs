using System.Linq;
using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            ViewBag.Categories = _context.Categories.ToList();

            var categorySelected = _context.Categories.FirstOrDefault(x => x.Id == id);

            return View(categorySelected);
        }

        [HttpPost]
        public IActionResult Register(Category category)
        {
            if (category.Id == 0)
                _context.Categories.Add(category);
            else
            {
                var categorySave = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
                categorySave.Name = category.Name;
                _context.Categories.Update(categorySave);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id){
            var categoryDelete = _context.Categories.FirstOrDefault(x => x.Id == id);
            _context.Categories.Remove(categoryDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}