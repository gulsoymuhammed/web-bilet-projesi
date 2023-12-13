using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using webBiletProje.Models;



namespace webBiletProje.Controllers
{
    public class HomeController : Controller
    {

        private readonly DbContext _context;

        public HomeController()
        {
            _context = new DataContext(); // Replace YourDbContext with the actual name of your DbContext class
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string userName, string password)
        {
            var user = await _context.Set<User>().SingleOrDefaultAsync(u => u.UserName == userName && u.Password == password);

            if (user != null)
            {
                // Login successful, redirect to Index view
                return RedirectToAction("Index");
            }
            else
            {
                // Login failed, you might want to show an error message or redirect back to the login page
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }

        public async Task<ActionResult> GetUserByUsername(string userName)
        {
            var user = await _context.Set<User>().SingleOrDefaultAsync(u => u.UserName == userName);

            if (user != null)
            {
                // Pass the user object to the view
                return View(user);
            }
            else
            {
                // Handle user not found case
                return View("UserNotFound");
            }
        }
    }
}