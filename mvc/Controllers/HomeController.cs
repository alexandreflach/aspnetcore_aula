using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using mvc.Models;
using mvc.Repository;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private IPeopleRepository _peopleRepository;
        private IConfiguration _configuration;

        public HomeController(IPeopleRepository peopleRepository, IConfiguration configuration)
        {
            _peopleRepository = peopleRepository;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewData["Name"] = _peopleRepository.GetNameById(2);
            ViewData["Environment"] = _configuration.GetValue<string>("Environment");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult People()
        {
            var people = new mvc.Models.People { Name = "Catiana", Age = 30 };
            return View(people);
        }
    }
}
