using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Servicios
{
    public interface ITemaService {
        IEnumerable<Tema> GetTemas();
        Tema GetTemaAndPreguntasByID(int id);
        Tema GetTemaByID(int id);
        void EliminarTema(int id);
        void addTema(Tema tema);
        void addTemaCategoria(TemaCategoria temaCategoria);
        IEnumerable<Tema> GetTemasWithCriterio(string criterio);
        void EditarTema(Tema tema);
    }
    public class TemaService : ITemaService
    {
        SimuladorContext db;
        public TemaService(SimuladorContext db) {
            this.db = db;
        }

        public void addTema(Tema tema)
        {
            db.Temas.Add(tema);
            db.SaveChanges();
            
        }

        public void addTemaCategoria(TemaCategoria temaCategoria)
        {
            db.TemaCategorias.Add(temaCategoria);
            db.SaveChanges();
        }

        public void EliminarTema(int id)
        {
            var tema = db.Temas.Find(id);
            db.Temas.Remove(tema);
            db.SaveChanges();
        }

        public Tema GetTemaAndPreguntasByID(int id)
        {
            var temas = db.Temas
                .Include(o => o.Preguntas.Select(x => x.Alternativas))
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return temas;
        }

        public Tema GetTemaByID(int id)
        {
            var tema= db.Temas.Find(id);
            return tema;
        }

        public IEnumerable<Tema> GetTemas()
        {
            var temas = db.Temas.ToList();
            return temas;
        }

        public IEnumerable<Tema> GetTemasWithCriterio(string criterio)
        {
            var temas = db.Temas.Include(a => a.Categorias.Select(o => o.Categoria)).AsQueryable();

            if (!string.IsNullOrEmpty(criterio))
                temas = temas.Where(o => o.Nombre.Contains(criterio));
            return temas;
        }
        public void EditarTema(Tema tema)
        {
            var preg = GetTemaByID(tema.Id);
            preg.Nombre = tema.Nombre;
            preg.Descripcion = tema.Descripcion;
            preg.Preguntas = tema.Preguntas;
            preg.Categorias = tema.Categorias;
            db.SaveChanges();

        }
    }
}