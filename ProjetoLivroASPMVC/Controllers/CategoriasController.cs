using Modelo.Cadastros;
using Modelo.Tabelas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Serviços.Tabelas;

namespace Persistencia.Controllers
{
    public class CategoriasController : Controller
    {
        private CategoriaServico _categoriaServico = new CategoriaServico();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(_categoriaServico.ObterCategoriasOrdenadasPorNome());
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria categoria = _categoriaServico.EliminarCategoriaPorId(id);
            TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " removida com sucesso";
            return RedirectToAction("Index");
        }

        private ActionResult ObterVisaoCategoriaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = _categoriaServico.ObterCategoriaPorId((long)id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoriaServico.GravarCategoria(categoria);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(categoria);
            }
        }
    }
}