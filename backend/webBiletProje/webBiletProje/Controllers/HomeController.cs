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