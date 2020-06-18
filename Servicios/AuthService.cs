using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SimuladorExamenUPN.Servicios
{
    public interface IAuthService {
        Usuario Login(string username, string password);

    }
    public class AuthService : IAuthService
    {
        SimuladorContext app;
        public AuthService(SimuladorContext app) {
            this.app = app;
        }
        public Usuario Login(string username, string password)
        {
            Usuario user = app.Usuarios.FirstOrDefault(x=>x.Username==username && x.Password==password);
            if (user != null)
            {

                return user;
                
            };
            throw new NotImplementedException();

        }
       
    }
}