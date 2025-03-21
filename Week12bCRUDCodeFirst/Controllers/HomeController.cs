using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Week12bCRUDCodeFirst.AppDbContext;
using Week12bCRUDCodeFirst.Models;

namespace Week12bCRUDCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        private readonly DataContext _db;

        public HomeController(DataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            _db.Employees.Add(obj);     // adding to SQL query    //constructor part   
                                        // Employees is the table name defined in DataContext.cs
            _db.SaveChanges();      // Saving
            return View();
        }

        [HttpGet]
        public IActionResult GetEmployeeData()
        {
            var Emp = _db.Employees.ToList();
            return View(Emp);
        }

        //[HttpPost]
        public IActionResult Delete(int id)
        {
            var Emp = _db.Employees.FirstOrDefault(x => x.id == id);     // matching with database id
            _db.Employees.Remove(Emp);
            _db.SaveChanges();
            return RedirectToAction("GetEmployeeData");
        }


        [HttpGet]
        public IActionResult Update(int id)     //Getting edit-able page with id
        {
            var Emp = _db.Employees.FirstOrDefault(x => x.id == id);     // matching id with database id

            return View(Emp);
        }

        [HttpPost]
        public IActionResult Update(Employee obj)       // Saving edited page with information
        {
            _db.Employees.Update(obj);
            _db.SaveChanges();
            //return View();
            return RedirectToAction("GetEmployeeData");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
