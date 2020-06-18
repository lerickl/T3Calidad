using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using SimuladorExamenUPN.Servicios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimuladorExamenUPN.Controllers
{
    public class PreguntaController : Controller
    {
 
        private ITemaService TemaService;
        private IPreguntasService preguntasService;
        public PreguntaController(ITemaService TemaService, IPreguntasService preguntasService)
        {

            this.TemaService = TemaService;
            this.preguntasService = preguntasService;
        }

        [HttpGet]
        public ActionResult Index(int temaId)
        {
            var tema = TemaService.GetTemaAndPreguntasByID(temaId);

            return View(tema);
        }

        [HttpGet]
        public ActionResult Crear(int temaId)
        {
            ViewBag.Tema = TemaService.GetTemaByID(temaId);
            return View(new Pregunta());
        }

        [HttpPost]
        public ActionResult Crear(Pregunta pregunta)
        {
            //Validar(pregunta);
            preguntasService.Validar(pregunta,ModelState);
            if (ModelState.IsValid)
            {
                //ViewBag.Tema = context.Temas.Find(pregunta.TemaId);
                ViewBag.Tema = TemaService.GetTemaByID(pregunta.Id);
                return View(pregunta);
            }
            preguntasService.addPreguntas(pregunta);
            //context.Preguntas.Add(pregunta);
            //context.SaveChanges();

            return RedirectToAction("Index", new { temaId = pregunta.TemaId });
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            //var pregunta = context.Preguntas.Find(id);
            //ViewBag.Tema = context.Temas.Find(pregunta.TemaId);
            var pregunta = preguntasService.GetPreguntaByID(id);
            ViewBag.Tema = TemaService.GetTemaByID(pregunta.TemaId);
            return View(pregunta);
        }

        [HttpPost]
        public ActionResult Editar(Pregunta pregunta)
        {
            if (!ModelState.IsValid)
            {
                //ViewBag.Tema = context.Temas.Find(pregunta.TemaId);
                ViewBag.Tema = TemaService.GetTemaByID(pregunta.TemaId);
                return View(pregunta);
            }
            //context.Entry(pregunta).State = EntityState.Modified;
            //context.SaveChanges();
            preguntasService.EditarPregunta(pregunta);

            return RedirectToAction("Index", new { temaId = pregunta.TemaId });
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            //var pregunta = context.Preguntas.Find(id);
            //context.Preguntas.Remove(pregunta);
            //context.SaveChanges();
            preguntasService.EliminarPregunta(id);

            return RedirectToAction("Index","");
        }



        private void Validar(Pregunta pregunta)
        {
            if (pregunta.Alternativas.Count < 4)
                ModelState.AddModelError("Alternativas", "Las alternativas deben ser al menos 4");

            if (pregunta.Alternativas.Where(o => o.EsCorrecto).Count() == 0)
                ModelState.AddModelError("Alternativas", "Las alternativas deben tener al mensos una respusta correcta");
        }

    }
}