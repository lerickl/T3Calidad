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
    public class TemaController : Controller
    {

        private ITemaService temaService;
        private ICategoriaService categoriaService;
        public TemaController(ITemaService temaService, ICategoriaService categoriaService)
        {
            this.temaService = temaService;
            this.categoriaService = categoriaService;
 
        }
        [HttpGet]
        public ViewResult Index(string criterio)
        {

            //var temas = context.Temas.Include(a=>a.Categorias.Select(o=>o.Categoria)).AsQueryable();

            //if (!string.IsNullOrEmpty(criterio))
            //    temas = temas.Where(o => o.Nombre.Contains(criterio));
            var temas = temaService.GetTemasWithCriterio(criterio);
            ViewBag.Criterio = criterio;
            return View(temas.ToList());
        }

        [HttpGet]
        public ViewResult Crear()
        {
            ViewBag.Categorias = categoriaService.Getcategorias();
            ViewBag.Message = "Pantalla de crear";
            return View(new Tema());
        }

        [HttpPost]
        public ActionResult Crear(Tema tema,List<int> Ids)
        {

            ViewBag.Categorias = categoriaService.Getcategorias();

            if (ModelState.IsValid == true)
            {

                temaService.addTema(tema);
               

                foreach (var categoriaid in Ids)
                {
                   var temaCategoria = new TemaCategoria() { CategoriaId = categoriaid, TemaId = tema.Id };
                    //context.TemaCategorias.Add(temaCategoria);
                    //context.SaveChanges();
                    temaService.addTemaCategoria(temaCategoria);
                }
                return RedirectToAction("Index");
            }

            else
            {
                return View(tema);
            }
        }

        [HttpGet]
        public ViewResult Editar(int id)
        {

            //Tema tema = context.Temas.Where(x => x.Id == id).First();

            var tema = temaService.GetTemaByID(id);     
            return View(tema);
        }

        [HttpPost]
        public ActionResult Editar(Tema tema)
        {      
            if (ModelState.IsValid == true)
            {
                //context.Entry(tema).State = EntityState.Modified;
                //context.SaveChanges();
                temaService.EditarTema(tema);
                return RedirectToAction("Index");
            }

            return View(tema);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {

            //Tema tema = context.Temas.Where(x => x.Id == id).First();
            //context.Temas.Remove(tema);
            //context.SaveChanges();
            temaService.EliminarTema(id);

            return RedirectToAction("Index","Tema");
        }
    }
}