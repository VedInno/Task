using Microsoft.AspNetCore.Mvc;
using Login.Models;

namespace LoginApp.Controllers
{
    public class HomeController : Controller
    {
        
        private const string ValidUsername = "############";
        private const string ValidPassword = "############";
        private static List<string> ToDoList = new List<string>();

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoggedIn"); 
            return RedirectToAction("Login");  
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == ValidUsername && model.Password == ValidPassword)
                {
                    ViewBag.Message = "Login Successful!";
                    return RedirectToAction("ToDo");
                }
                else
                {
                    ViewBag.Message = "Invalid Username or Password";
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult ToDo()
        {
                return View(ToDoList); 
        
        }

        [HttpPost]
        public IActionResult AddTask(string task)
        {
            if (!string.IsNullOrEmpty(task))
            {
                ToDoList.Add(task);
            }
            return RedirectToAction("ToDo");
        }

        [HttpPost]
        public IActionResult RemoveTask(string task)
        {

            ToDoList.Remove(task);
            return RedirectToAction("ToDo");
        }
 
        
    }
}

