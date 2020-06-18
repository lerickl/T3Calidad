using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SimuladorExamenUPN.session
{
    public interface IAuthManager
    {
        void Login(Usuario Usuario);
        Usuario GetUserLogueado();
        void Logout();
    }
    public class AuthManager : IAuthManager
    {
        public void Login(Usuario Usuario)
        {
            FormsAuthentication.SetAuthCookie(Usuario.Nombres, false);
            HttpContext.Current.Session["Usuario"] = Usuario;
        }
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
        public Usuario GetUserLogueado()
        {
            return (Usuario)HttpContext.Current.Session["Usuario"];
        }
    }
}