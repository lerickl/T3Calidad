using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.session
{
    public interface ISessionService
    {

        void GuardarSession(Usuario usuario);
        void LimpiarSesion();

    }
    class SessionService : ISessionService
    {
        private readonly HttpContext ctx;

        public SessionService()
        {
            ctx = HttpContext.Current;
            SimuladorContext cnt = new SimuladorContext();

        }

        public void GuardarSession(Usuario usuario)
        {
            ctx.Session["id"] = usuario.Id.ToString();
            ctx.Session["Nombres"] = usuario.Nombres.ToString();
            ctx.Session["Username"] = usuario.Username.ToString();
            ctx.Session["Password"] = usuario.Password.ToString();
        }
        public bool SucessSession(int? Id)
        {
            if (IsLogged())
            {
                int UsuarioId = Convert.ToInt32(ctx.Session["id"]);
                if (UsuarioId != Id)
                    return false;
            }
            return true;
        }
        public bool IsLogged()
        {
            //if (ctx.Session["id"] != null && ctx.Session["Cargo"] != null)
            if (ctx.Session["id"] != null)
                return true;
            return false;
        }
        public void LimpiarSesion()
        {
            ctx.Session.Clear();
        }
    }
}