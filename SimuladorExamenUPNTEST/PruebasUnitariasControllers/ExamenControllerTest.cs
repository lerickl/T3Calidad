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
    public class ExamenControllerTest
    {
        [Test]
        public void GetIndexIsOK()
        {

            var AuthManagerMock = new Mock<IAuthManager>();
            AuthManagerMock.Setup(x => x.GetUserLogueado()).Returns(new Usuario());
            var examenServiceMock = new Mock<IExamenService>();
            //examenServiceMock.Setup(x => x.GetExamensByUserId(1)).Returns(new List<Examen>());
            var TemaServiceMock = new Mock<ITemaService>();
            var PreguntaServiceMock = new Mock<IPreguntasService>();

            var controllerExamen = new ExamenController(AuthManagerMock.Object, examenServiceMock.Object, TemaServiceMock.Object, PreguntaServiceMock.Object);
            var result = controllerExamen.Index();

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void GetCrearIsOK()
        {

            var AuthManagerMock = new Mock<IAuthManager>();
            var examenServiceMock = new Mock<IExamenService>();
            var TemaServiceMock = new Mock<ITemaService>();
            var PreguntaServiceMock = new Mock<IPreguntasService>();

            var controllerExamen = new ExamenController(AuthManagerMock.Object, examenServiceMock.Object, TemaServiceMock.Object, PreguntaServiceMock.Object);
            var result = controllerExamen.Crear();

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void PostCrearIsOK()
        {

            Examen examen = new Examen();
            var temp = new Usuario() {Id=1, };
            var AuthManagerMock = new Mock<IAuthManager>();
            var examenServiceMock = new Mock<IExamenService>();
            var TemaServiceMock = new Mock<ITemaService>();
            var PreguntaServiceMock = new Mock<IPreguntasService>();
            AuthManagerMock.Setup(e => e.GetUserLogueado()).Returns(temp);
            PreguntaServiceMock.Setup(x => x.GetPreguntas(1, 1)).Returns(new List<Pregunta>());
            var controllerExamen = new ExamenController(AuthManagerMock.Object, examenServiceMock.Object, TemaServiceMock.Object, PreguntaServiceMock.Object);
            var result = controllerExamen.Crear(examen, 1);

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }
        [Test]
        public void PostCrearErrorIsOK()
        {

            Examen examen = new Examen();
            var temp = new Usuario() { Id = 1, };
            var AuthManagerMock = new Mock<IAuthManager>();
            var examenServiceMock = new Mock<IExamenService>();
            var TemaServiceMock = new Mock<ITemaService>();
            var PreguntaServiceMock = new Mock<IPreguntasService>();
            AuthManagerMock.Setup(e => e.GetUserLogueado()).Returns(temp);
            PreguntaServiceMock.Setup(x => x.GetPreguntas(1, 1)).Returns(new List<Pregunta>());
            var controllerExamen = new ExamenController(AuthManagerMock.Object, examenServiceMock.Object, TemaServiceMock.Object, PreguntaServiceMock.Object);
            controllerExamen.ModelState.AddModelError("Error", "en el model");
            var result = controllerExamen.Crear(examen, 1);

            Assert.IsInstanceOf<ViewResult>(result);
        }

    }
}