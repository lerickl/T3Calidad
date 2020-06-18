using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimuladorExamenUPN.Servicios
{
    public interface IPreguntasService {
        List<Pregunta> GetPreguntas(int tema, int nroPreguntas);
        void addPreguntas(Pregunta pregunta);
        Pregunta GetPreguntaByID(int id);
        void EditarPregunta(Pregunta pregunta);
        void EliminarPregunta(int id);
        void Validar(Pregunta pregunta, ModelStateDictionary ModelState);
        void GuardarPreguntas(Examen examen, List<Pregunta> preguntas);
    }
    public class PreguntasService : IPreguntasService
    {
        SimuladorContext db;
        private readonly ExamenService examenService;
        public PreguntasService(SimuladorContext db) {
            this.db = db;
            examenService = new ExamenService(db);
        }

        public void addPreguntas(Pregunta pregunta)
        {
            db.Preguntas.Add(pregunta);
            db.SaveChanges();
        }

        public void EditarPregunta(Pregunta pregunta)
        {
            var preg = GetPreguntaByID(pregunta.Id);
            preg.Descripcion = pregunta.Descripcion;
            preg.TemaId = pregunta.TemaId;
            preg.Tema = pregunta.Tema;
            preg.Alternativas = pregunta.Alternativas;
            db.SaveChanges();

        }

        public void EliminarPregunta(int id)
        {
            var pregunta = db.Preguntas.Find(id);
            db.Preguntas.Remove(pregunta);
            db.SaveChanges();
        }

        public Pregunta GetPreguntaByID(int id)
        {
            var pregunta = db.Preguntas.Find(id);
            return pregunta;
        }

        public List<Pregunta> GetPreguntas(int tema, int nroPreguntas)
        {
            var basePreguntas = db.Preguntas.Where(o => o.TemaId == tema).OrderBy(x => Guid.NewGuid())
                .Take(nroPreguntas).ToList();
            return basePreguntas;
        }

        public void GuardarPreguntas(Examen examen, List<Pregunta> preguntas)
        {
            foreach (var item in preguntas)
            {
                var examenPreguta = new ExamenPregunta();
                examenPreguta.ExamenId = examen.Id;
                examenPreguta.PreguntaId = item.Id;

                examenService.addExamenPregunta(examenPreguta);

            }
        }

        public void Validar(Pregunta pregunta, ModelStateDictionary ModelState) {
            if (pregunta.Alternativas.Count < 4)
                ModelState.AddModelError("Alternativas", "Las alternativas deben ser al menos 4");

            if (pregunta.Alternativas.Where(o => o.EsCorrecto).Count() == 0)
                ModelState.AddModelError("Alternativas", "Las alternativas deben tener al mensos una respusta correcta");

        }
    }
}