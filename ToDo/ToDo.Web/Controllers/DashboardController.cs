using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Services;

namespace ToDo.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private IAuthenticationService _authenticationService;
        private AuthenticationModel authData;

        public DashboardController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            authData = _authenticationService.GetAuthData();
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
