using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.SimuladorExamenUPNTEST.PruebasSelenium
{
    [TestFixture]
    class Selenium
    {
        string Ruta = "http://localhost:58972/";
        ChromeOptions opciones = new ChromeOptions();
        [Test]
        public void HomeIndexTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            var page = navegador.FindElementByName("homeIndex");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void ButtonTomarExamenTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("BotonTomarExamen").Click();
            var page = navegador.FindElementById("Confirmar");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void ButtonIniciarExamenTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("BotonTomarExamen").Click();
            navegador.FindElementById("buttoniniciarExamen").Click();
            var page = navegador.FindElementById("darExamen");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void ButtonCancelarExamenTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("BotonTomarExamen").Click();
            navegador.FindElementById("buttonCancelarExamen").Click();
            var page = navegador.FindElementByName("homeIndex");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void ButtonTemasTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            var page = navegador.FindElementById("temas");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void ButtonCrearTemaTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("creartemaLink").Click();
            var page = navegador.FindElementById("crearTema");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void CrearTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("creartemaLink").Click();
            navegador.FindElementById("Nombre").SendKeys("Prueba");
            navegador.FindElementById("Historia").Click();
            navegador.FindElementById("Descripcion").SendKeys("Historia");
            navegador.FindElementById("btnguardartema").Click();
            var page = navegador.FindElementById("temas");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void BottonEditarPrimerElementoTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();

            navegador.FindElementById("edit+1").Click();

            var page = navegador.FindElementById("editarTema");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void EditarPrimerElementoTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            //
            navegador.FindElementById("edit+1").Click();

            navegador.FindElementByName("Nombre").SendKeys("editado");
            navegador.FindElementByName("Descripcion").SendKeys("editado");
            navegador.FindElementById("buttonGuardar").Click();

            var page = navegador.FindElementById("temas");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void CancelarEditarPrimerElementoTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            //
            navegador.FindElementById("edit+1").Click();

             
            navegador.FindElementById("buttonCancelar").Click();

            var page = navegador.FindElementById("temas");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void ButtonEliminarPrimerTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            //
            navegador.FindElementById("delet+1").Click();
             
            var page = navegador.FindElementById("temas");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void ButtonPreguntasPrimerTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            //
            navegador.FindElementById("preguntas+1").Click();

            var page = navegador.FindElementById("preguntas");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void ButtonRegresarTemasDesdePreguntasTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            //
            navegador.FindElementById("preguntas+1").Click();
            navegador.FindElementById("buttonIrATemas").Click();
            var page = navegador.FindElementById("temas");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void ButtonCrearPreguntasTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            //
            navegador.FindElementById("preguntas+1").Click();
            navegador.FindElementById("crearPreg").Click();
            var page = navegador.FindElementById("crearPreguntasView");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void CrearPreguntasTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            //
            navegador.FindElementById("preguntas+1").Click();
            navegador.FindElementById("crearPreg").Click();

            
            navegador.FindElementByName("Descripcion").SendKeys("Pregunta");
            navegador.FindElementById("btnAddAlternativa").Click();
            navegador.FindElementById("0descripcion").SendKeys("Pregunta");
            navegador.FindElementById("0check").Click();
       
            navegador.FindElementById("guardar").Click();
            var page = navegador.FindElementById("preguntas");
            Assert.IsNotNull(page);
            navegador.Close();

 
        }
        [Test]
        public void ButtonEditPreguntasTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            //
            navegador.FindElementById("preguntas+1").Click();

            navegador.FindElementById("Editar+1").Click();
     
            var page = navegador.FindElementById("EditarPregunta");
            Assert.IsNotNull(page);
            navegador.Close();


        }
        [Test]
        public void  EditPreguntasTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            //
            navegador.FindElementById("preguntas+1").Click();

            navegador.FindElementById("Editar+1").Click();

            navegador.FindElementByName("Descripcion").SendKeys("PreguntaEditada");

            navegador.FindElementById("bttnguardar").Click();

            var page = navegador.FindElementById("preguntas");
            Assert.IsNotNull(page);
            navegador.Close();


        }
        [Test]
        public void ButtonCancelPreguntasTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            //
            navegador.FindElementById("preguntas+1").Click();

            navegador.FindElementById("Editar+1").Click(); 
            navegador.FindElementById("bttnCancelar").Click();

            var page = navegador.FindElementById("preguntas");
            Assert.IsNotNull(page);
            navegador.Close();


        }
        [Test]
        public void ButtonEliminarPreguntasTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            //
            navegador.FindElementById("preguntas+1").Click();

        
            navegador.FindElementById("eliminar+1").Click();

            var page = navegador.FindElementByName("homeIndex");
            Assert.IsNotNull(page);
            navegador.Close();


        }
        [Test]
        public void BuscarTemaIsOkTest()
        {

            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username");
            navegador.FindElementByName("Password");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();
            //
            navegador.FindElementByName("criterio").SendKeys("a");
            navegador.FindElementById("BttnBuscar").Click();
             var page = navegador.FindElementById("temas");
            Assert.IsNotNull(page);
            navegador.Close();


        }
    }
}