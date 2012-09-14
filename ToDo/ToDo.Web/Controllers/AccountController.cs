using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Services;

namespace ToDo.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationService _authenticationService;
        private IUserService _userService;

        public AccountController(IAuthenticationService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Dashboard");
        }

        public ActionResult Signup()
        {
            return View("Signup", new UserModel());
        }

        [HttpPost]
        public ActionResult Signup(UserModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _userService.Signup(model);
                    return RedirectToAction("Login");
                }
                catch(ValidationException e)
                {
                    ModelState.AddModelError(e.Key, e.Description);
                }
            }
            return View("Signup", model);
        }

        public ActionResult Login()
        {
            return View("Login", new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _authenticationService.Login(_userService.Login(model), false);
                    return RedirectToAction("Index", "Dashboard");
                }
                catch (ValidationException e)
                {
                    ModelState.AddModelError(e.Key, e.Description);
                }
            }
            return View("Login", model);
        }
    }
}
