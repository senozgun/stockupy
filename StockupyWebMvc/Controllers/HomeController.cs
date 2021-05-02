using DataAccessLibrary.Models;
using DataAccessLibrary;
using UserData = DataAccessLibrary.UserData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockupyWebMvc.Models;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StockupyWebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserData _userData;
        private readonly ISession _session;

        const string SessionUser = "_User";
        const string SessionId = "_Id";

        public HomeController(ILogger<HomeController> logger, IUserData userData, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _userData = userData;
            _session= httpContextAccessor.HttpContext.Session;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoUserLogin(UserModel model)
        {
            var result = _userData.GetUserForLogin(model);

            if (result.Result != null)
            {
                _session.SetString(SessionUser, result.Result.Name + " " + result.Result.Surname);
                _session.SetInt32(SessionId, result.Result.Id);

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            ViewBag.vb_Error = "User not found !";
            return View("Login");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Home");
        }
    }
}
