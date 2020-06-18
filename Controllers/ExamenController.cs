using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SimuladorExamenUPN.session;
using SimuladorExamenUPN.Servicios;

namespace SimuladorExamenUPN.Controllers
{
    [Authorize]
    public class ExamenController : Controller
    {
        IAuthManager AuthManager;
        IExamenService examenService;
        ITemaService TemaService;
        IPreguntasService preguntasService;

        public ExamenController(IAuthManager AuthManager, IExamenService examenService, ITemaService TemaService, IPreguntasService preguntasService)
        {
            this.AuthManager = AuthManager;
            this.examenService = examenService;
            this.TemaService = TemaService;
            this.preguntasService = preguntasService;
           
        }

        [HttpGet]
        public ActionResult Index()
        {
            Usuario logged = AuthManager.GetUserLogueado();
            int id = logged.Id;
            var examenes = examenService.GetExamensByUserId(id);
            //Usuario logged = GetLoggedUser();
            //var examenes = db.Examenes
            //    .Where(o => o.UsuarioId == logged.Id)
            //    .Include(o => o.Tema)
            //    .Include(o => o.Preguntas)
            //    .ToList();
            return View(examenes);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            //ViewBag.Temas = db.Temas.ToList();
            //return View(new Examen());
            ViewBag.Temas = TemaService.GetTemas();
            return View(new Examen());
        }

        [HttpPost]
        public ActionResult Crear(Examen examen, int nroPreguntas)
        {
            if (ModelState.IsValid)
            {
                examen.EstaActivo = true;
                GuardarExamen(examen);
                List<Pregunta> preguntas = GenerarPreguntas(examen.TemaId, nroPreguntas);

                preguntasService.GuardarPreguntas(examen, preguntas);
                return RedirectToAction("Index");
            }

            ViewBag.Temas = TemaService.GetTemas();
            return View(examen);
        }

        //private void GuardarPreguntas(Examen examen, List<Pregunta> preguntas)
        //{
        //    foreach (var item in preguntas)
        //    {
        //        var examenPreguta = new ExamenPregunta();
        //        examenPreguta.ExamenId = examen.Id;
        //        examenPreguta.PreguntaId = item.Id;

        //        examenService.addExamenPregunta(examenPreguta);
               
        //    }
        //}

        private void GuardarExamen(Examen examen)
        {
            var user= AuthManager.GetUserLogueado();
            examen.UsuarioId = user.Id;
            examen.FechaCreacion = DateTime.Now;
            examenService.GuardarExamen(examen);
            //db.Examenes.Add(examen);
            //db.SaveChanges();
        }

        //private Usuario GetLoggedUser()
        //{
        //  return (Usuario)Session["Usuario"];
        //}



        private List<Pregunta> GenerarPreguntas(int tema, int nroPreguntas)
        {
            var basePreguntas = preguntasService.GetPreguntas(tema, nroPreguntas);
            return basePreguntas;
           
        }
    }
}
