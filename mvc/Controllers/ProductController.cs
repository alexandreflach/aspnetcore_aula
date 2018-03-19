using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    //[Route("api/product")]
    public class ProductController : Controller
    {
        [HttpGet("{id:int}")]
        public int Get(int id)
        {
            //return Content()
            //return File
            return id;
        }

        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if(!ModelState.IsValid)
                ViewBag.Validacao = "produto inválido";
            return View();
        }
    }
}