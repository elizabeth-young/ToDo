using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Security;
using ToDo.Common.Helpers;

namespace ToDo.Services
{
    public interface IAuthenticationService
    {
        void Login(AuthenticationModel model, bool isPersistent);
        void Logoff();
        AuthenticationModel GetAuthData();
        bool IsAuthenticated();
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPrincipal _principal;

        public AuthenticationService(IPrincipal userPrincipal)
        {
            _principal = userPrincipal;
        }

        public void Login(AuthenticationModel model, bool isPersistent)
        {
            var authTicket = new FormsAuthenticationTicket(
                                                            1,
                                                            model.Name,
                                                            DateTime.Now,
                                                            DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                                                            isPersistent,
                                                            SerializationHelper.Serialize(model)
                                                           );
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket)));
        }

        public void Logoff()
        {
            FormsAuthentication.SignOut();
        }

        public AuthenticationModel GetAuthData()
        {
            if (_principal == null)
            {
                return null;
            }
            var authTicket = _principal.Identity as FormsIdentity;
            if (authTicket == null)
            {
                return null;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(authTicket.Ticket.UserData);
            return SerializationHelper.Deserialize<AuthenticationModel>(bytes);
        }

        public bool IsAuthenticated()
        {
            return _principal.Identity.IsAuthenticated;
        }
    }
}
