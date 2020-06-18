using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Servicios
{
    public interface IExamenService {
        IEnumerable<Examen> GetExamens();
        Examen Confirmar(int ExamenId);
        Examen DarExamen(int ExamenId);
        IEnumerable<Examen> GetExamensByUserId(int id);
        void GuardarExamen(Examen examen);
        void addExamenPregunta(ExamenPregunta examenPregunta);
    }
    public class ExamenService : IExamenService
    {
        SimuladorContext db;
        public ExamenService(SimuladorContext db) {
            this.db = db;
        }

        public void addExamenPregunta(ExamenPregunta examenPregunta)
        {
            db.ExamenPreguntas.Add(examenPregunta);

            db.SaveChanges();
        }

        public Examen Confirmar(int ExamenId)
        {

            var examen = db.Examenes
                .Where(o => o.Id == ExamenId)
                .Include(o => o.Tema)
                .Include(u => u.Usuario)
                .FirstOrDefault();
            return examen;
        }

        public Examen DarExamen(int ExamenId)
        {
            var examen = db.Examenes.Where(o => o.Id == ExamenId)
               .Include(o => o.Preguntas.Select(s => s.Pregunta.Alternativas))
               .FirstOrDefault();
            return examen;
        }

        public IEnumerable<Examen> GetExamens()
        {
            var examenes = db.Examenes
              .Include(o => o.Tema.Categorias.Select(s => s.Categoria))
              .Include(o => o.Usuario)
              .Where(o => o.EstaActivo == true)
              .ToList();
            return examenes;
        }

        public IEnumerable<Examen> GetExamensByUserId(int id)
        {
            var examenes = db.Examenes
                .Where(o => o.UsuarioId == id)
                .Include(o => o.Tema)
                .Include(o => o.Preguntas)
                .ToList();
            return examenes;
        }

        public void GuardarExamen(Examen examen)
        {

            db.Examenes.Add(examen);
            db.SaveChanges();
        }
    }
}