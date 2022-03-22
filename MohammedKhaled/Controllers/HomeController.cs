using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MohammedKhaled.Data;
using MohammedKhaled.Models;


using System.Diagnostics;

namespace MyWeb.Controllers
{
    public class HomeController : Controller
    {

        public readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login(Employee emp)
        {


            var employee = await _context.Employee.FindAsync(emp.Id);

            
            if (employee == null)
            {
           
                return NotFound();

            }

            else if ((employee.Id == emp.Id) && (employee.Password == emp.Password))
            {
                

                return View("Index", employee);

                int z = 3242;
            }

            return View();

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}