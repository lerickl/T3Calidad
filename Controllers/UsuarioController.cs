using SimuladorExamenUPN.Models;

using SimuladorExamenUPN.Servicios;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SimuladorExamenUPN.session;

namespace SimuladorExamenUPN.Controllers
{
    public class UsuarioController : Controller     
    {
        //private ISessionManager session;
        private ISessionService session;
        private IAuthService auth;
        private readonly IAuthManager autenticacion;
        public UsuarioController(IAuthService auth, ISessionService session, IAuthManager autenticacion) {
            
            this.auth = auth;
            this.session = session;
            this.autenticacion = autenticacion;
        }
        [HttpGet]
        public ActionResult Login()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                //FormsAuthentication.SetAuthCookie(username, false);
                //Session["Usuario"] = new Usuario { Id = 1, Username = "admin"};
                
                
                //Usuario usuario = servicio.GetUsuarioByCorreoAndClave(Correo, Clave);
                var user = auth.Login(username, password);
                if (user != null)
                {
                 
                    autenticacion.Login(user);
                    session.GuardarSession(user);
                    return RedirectToAction("Index", "Home");
                }
                
                else
                {
                    ViewBag.Validation = "Usuario y/o contraseña incorrecta";
                    
                    return View();
                }
            }
            else
                {
                    ViewBag.Validation = "Usuario y/o contraseña incorrecta";
                    return View();
                }
        }


        public ActionResult Logout() {
            //FormsAuthentication.SignOut();
            //Session.Clear();
            autenticacion.Logout();
            session.LimpiarSesion();
            return RedirectToAction("Login");
        }
    }
}