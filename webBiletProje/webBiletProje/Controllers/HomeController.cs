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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User userModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Assuming you have a DbContext class named DataContext
                    using (var dbContext = new DataContext())
                    {
                        // Map User model to your entity model (assuming your entity model is named UserEntity)
                        var userEntity = new User
                        {
                            Name = userModel.Name,
                            Surname = userModel.Surname,
                            MailAddress = userModel.MailAddress,
                            PhoneNumber = userModel.PhoneNumber,
                            Sex = userModel.Sex
                        };

                        // Add the entity to the database
                        dbContext.Users.Add(userEntity);

                        // Save changes to the database
                        dbContext.SaveChanges();
                    }

                    // Redirect to a success or result view
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log the error, handle it, or display an error message to the user
                    ViewBag.ErrorMessage = $"An error occurred during registration: {ex.Message}";
                    return View();
                }
            }

            // If the model state is not valid, return the registration view with validation errors
            return View(userModel);
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