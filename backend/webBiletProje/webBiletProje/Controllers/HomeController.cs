using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using webBiletProje.Models;



namespace webBiletProje.Controllers
{
    public class HomeController : Controller
    {

        private readonly DbContext _context;
        private DataContext db = new DataContext();

        public HomeController()
        {
            _context = new DataContext(); // Replace YourDbContext with the actual name of your DbContext class
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
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
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string Name, string Surname, string MailAddress, string UserName, string PhoneNumber, string sex, string Password, string City, string Address)
        {

            var newUser = new User
            {
                Name = Name,
                Surname = Surname,
                MailAddress = MailAddress,
                PhoneNumber = PhoneNumber,
                Sex = sex,
                UserName = UserName,
                Password = Password,
                City = City,
                Address = Address
            };

            db.Users.Add(newUser);
            db.SaveChanges();

            return RedirectToAction("Index");
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