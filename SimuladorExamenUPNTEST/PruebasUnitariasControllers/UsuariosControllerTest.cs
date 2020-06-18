using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SimuladorExamenUPN.Controllers;
using SimuladorExamenUPN.Models;
using SimuladorExamenUPN.Servicios;
using SimuladorExamenUPN.session;

namespace SimuladorExamenUPN.SimuladorExamenUPNTEST.PruebasUnitariasControllers
{
    [TestFixture]
    public class UsuariosControllerTest
    {
        [Test]
        public void GetLoginIsOK()
        {

            var controllerUsuario = new UsuarioController(null, null, null);
            var view = controllerUsuario.Login();
            Assert.IsInstanceOf<ViewResult>(view);

        }
        [Test]
        public void LoginIsError()
        {
            var user = new Usuario();

            var auth = new Mock<IAuthService>();
            var SessionMock = new Mock<ISessionService>();
            auth.Setup(o => o.Login("admin", "admin"));
            var controller = new UsuarioController(auth.Object, null, null);

            var redirect = controller.Login("admin", "admin");
            Assert.IsInstanceOf<ViewResult>(redirect);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(redirect);



        }
        [Test]
        public void PostLoginIsOK()
        {
            var admin = new Usuario { Id = 1, Username = "admin", Password = "admin", Nombres = "namedmin" };


            var authMock = new Mock<IAuthService>();
            var SessionMock = new Mock<ISessionService>();
            var authManagerMock = new Mock<IAuthManager>();
            authMock.Setup(x => x.Login("admin", "admin")).Returns(admin);
            var controllerUsuario = new UsuarioController(authMock.Object, SessionMock.Object, authManagerMock.Object);

            var result = controllerUsuario.Login("admin", "admin");
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            Assert.IsNotInstanceOf<ViewResult>(result);
        }
        [Test]
        public void LogOutisOk()
        {
            var SessionMock = new Mock<ISessionService>();
            var authMock = new Mock<IAuthService>();
            var authManagerMock = new Mock<IAuthManager>();
            var controllerUsuario = new UsuarioController(authMock.Object, SessionMock.Object, authManagerMock.Object);

            var result = controllerUsuario.Logout();

            Assert.IsInstanceOf<RedirectToRouteResult>(result);

        }




    }

}