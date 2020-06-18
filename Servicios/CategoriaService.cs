using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Servicios
{
    public interface ICategoriaService {
        IEnumerable<Categoria> Getcategorias();
    }
    public class CategoriaService : ICategoriaService
    {
        readonly SimuladorContext db;
        public CategoriaService(SimuladorContext db) {
            this.db = db;
        }
        public IEnumerable<Categoria> Getcategorias()
        {
            var cat=db.Categorias.ToList();
            return cat;
        }
    }
}