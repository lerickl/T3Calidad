using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SimuladorExamenUPN.Controllers;
using SimuladorExamenUPN.Servicios;

namespace SimuladorExamenUPN.SimuladorExamenUPNTEST.PruebasUnitariasControllers
{
    [TestFixture]
    class HomeControllerTest
    {
        [Test]
        public void IndexHomeIsOk()
        {
            var examenServiceMock = new Mock<IExamenService>();
            var Controller = new HomeController(examenServiceMock.Object);
            var result = Controller.Index();
            Assert.IsInstanceOf<ViewResult>(result);

        }
        [Test]
        public void ConfirmarHomeIsOk()
        {
            var examenServiceMock = new Mock<IExamenService>();
            var Controller = new HomeController(examenServiceMock.Object);
            var result = Controller.Confirmar(1);
            Assert.IsInstanceOf<ViewResult>(result);

        }
        [Test]
        public void DarExamenHomeIsOk()
        {
            var examenServiceMock = new Mock<IExamenService>();
            var Controller = new HomeController(examenServiceMock.Object);
            var result = Controller.DarExamen(1);
            Assert.IsInstanceOf<ViewResult>(result);

        }
    }
}