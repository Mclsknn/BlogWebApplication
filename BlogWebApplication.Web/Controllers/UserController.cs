using BlogWebApplicationEntities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApplication.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login(User user)
        {
            string id = user.UserID.ToString();
            HttpContext.Session.SetString("UserID", id);
            return View();
        }

        public IActionResult Register() 
        {
            return View();
        }
        public IActionResult MyProfile() 
        {
            return View();
        }
    }
}
