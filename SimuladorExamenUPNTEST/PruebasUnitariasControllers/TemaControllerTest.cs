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
    class TemaControllerTest
    {
        [Test]
        public void GetIndexTemaIsOk()
        {
            var temaServiceMock = new Mock<ITemaService>();
            var categoriaServiceMock = new Mock<ICategoriaService>();
            var controller = new TemaController(temaServiceMock.Object, categoriaServiceMock.Object);
            var result = controller.Index("criterio");
            Assert.IsInstanceOf<ViewResult>(result);

        }
        [Test]
        public void GetCrearTemaIsOk()
        {
            var temaServiceMock = new Mock<ITemaService>();
            var categoriaServiceMock = new Mock<ICategoriaService>();
            var controller = new TemaController(temaServiceMock.Object, categoriaServiceMock.Object);
            var result = controller.Crear();
            Assert.IsInstanceOf<ViewResult>(result);

        }
        [Test]
        public void PostCrearTemaIsOk()
        {
            var temaServiceMock = new Mock<ITemaService>();
            var categoriaServiceMock = new Mock<ICategoriaService>();
            var controller = new TemaController(temaServiceMock.Object, categoriaServiceMock.Object);
            var result = controller.Crear(new Tema(), new List<int>());
            Assert.IsInstanceOf<RedirectToRouteResult>(result);

        }
        [Test]
        public void GetEditarTemaIsOk()
        {
            var temaServiceMock = new Mock<ITemaService>();
            var categoriaServiceMock = new Mock<ICategoriaService>();
            var controller = new TemaController(temaServiceMock.Object, categoriaServiceMock.Object);
            var result = controller.Editar(1);
            Assert.IsInstanceOf<ViewResult>(result);

        }
        [Test]
        public void PostEditarTemaIsOk()
        {
            var tema = new Tema();
            var temaServiceMock = new Mock<ITemaService>();
            var categoriaServiceMock = new Mock<ICategoriaService>();

            var controller = new TemaController(temaServiceMock.Object, categoriaServiceMock.Object);
            var result = controller.Editar(new Tema());
            Assert.IsInstanceOf<RedirectToRouteResult>(result);

        }
        [Test]
        public void EliminarTemaIsOk()
        {
            var tema = new Tema();
            var temaServiceMock = new Mock<ITemaService>();
            var categoriaServiceMock = new Mock<ICategoriaService>();
            var controller = new TemaController(temaServiceMock.Object, categoriaServiceMock.Object);
            var result = controller.Eliminar(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);

        }
    }
}