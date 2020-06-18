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

namespace SimuladorExamenUPN.SimuladorExamenUPNTEST.PruebasUnitariasControllers
{
    [TestFixture]
    class PreguntaControllerTest
    {
        [Test]
        public void GetIndexIsOK()
        {
            var TemaServiceMock = new Mock<ITemaService>();
            var preguntasService = new Mock<IPreguntasService>();
            var controller = new PreguntaController(TemaServiceMock.Object, preguntasService.Object);
            var result = controller.Index(1);
            Assert.IsInstanceOf<ViewResult>(result);

        }
        [Test]
        public void GetCrearIsOK()
        {
            var TemaServiceMock = new Mock<ITemaService>();
            var preguntasService = new Mock<IPreguntasService>();
            var controller = new PreguntaController(TemaServiceMock.Object, preguntasService.Object);
            var result = controller.Crear(1);
            Assert.IsInstanceOf<ViewResult>(result);

        }
        [Test]
        public void PostCrearIsOK()
        {
            Pregunta pregunta = new Pregunta();
            var TemaServiceMock = new Mock<ITemaService>();
            var preguntasService = new Mock<IPreguntasService>();
            var controller = new PreguntaController(TemaServiceMock.Object, preguntasService.Object);
            var result = controller.Crear(pregunta);
            Assert.IsInstanceOf<ViewResult>(result);

        }
        [Test]
        public void PostCrearErrorIsOK()
        {
            Pregunta pregunta = new Pregunta();
            var TemaServiceMock = new Mock<ITemaService>();
            var preguntasService = new Mock<IPreguntasService>();
            var controller = new PreguntaController(TemaServiceMock.Object, preguntasService.Object);
            controller.ModelState.AddModelError("Erro","en el modelstate");
            var result = controller.Crear(pregunta);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);

        }
        [Test]
        public void GetEditarIsOk()
        {
            Pregunta pregunta = new Pregunta();
            var TemaServiceMock = new Mock<ITemaService>();
            var preguntasService = new Mock<IPreguntasService>();
            preguntasService.Setup(x => x.GetPreguntaByID(1)).Returns(new Pregunta());
            var controller = new PreguntaController(TemaServiceMock.Object, preguntasService.Object);
            var result = controller.Editar(1);
            Assert.IsInstanceOf<ViewResult>(result);

        }
        [Test]
        public void PostEditarIsOK()
        {
            Pregunta pregunta = new Pregunta() { Id = 1, Descripcion = "desc", TemaId = 1, Tema = new Tema(), Alternativas = new List<Alternativa>() };
            var TemaServiceMock = new Mock<ITemaService>();
            var preguntasService = new Mock<IPreguntasService>();
            preguntasService.Setup(x => x.GetPreguntaByID(1)).Returns(pregunta);

            var controller = new PreguntaController(TemaServiceMock.Object, preguntasService.Object);
            var result = controller.Editar(pregunta);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);

        }
        [Test]
        public void PostEditarErrorIsOK()
        {
            Pregunta pregunta = new Pregunta() { Id = 1, Descripcion = "desc", TemaId = 1, Tema = new Tema(), Alternativas = new List<Alternativa>() };
            var TemaServiceMock = new Mock<ITemaService>();
            var preguntasService = new Mock<IPreguntasService>();
            preguntasService.Setup(x => x.GetPreguntaByID(1)).Returns(pregunta);

            var controller = new PreguntaController(TemaServiceMock.Object, preguntasService.Object);
            controller.ModelState.AddModelError("error","model");
            var result = controller.Editar(pregunta);
            Assert.IsInstanceOf<ViewResult>(result);
            
        }
        [Test]
        public void EliminarIsOK()
        {
            Pregunta pregunta = new Pregunta() { Id = 1, Descripcion = "desc", TemaId = 1, Tema = new Tema(), Alternativas = new List<Alternativa>() };
            var TemaServiceMock = new Mock<ITemaService>();
            var preguntasService = new Mock<IPreguntasService>();
            var controller = new PreguntaController(TemaServiceMock.Object, preguntasService.Object);
            var result = controller.Eliminar(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);

        }


    }
}