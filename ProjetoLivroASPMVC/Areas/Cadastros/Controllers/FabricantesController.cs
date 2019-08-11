using Modelo.Cadastros;
using Modelo.Tabelas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Serviços.Cadastros;

namespace ProjetoLivroASPMVC.Areas.Cadastros.Controllers
{
    public class FabricantesController : Controller
    {
        private FabricanteServico _fabricanteServico = new FabricanteServico();
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(_fabricanteServico.ObterFabricantesOrdenadosPorNome());
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Fabricante fabricante = _fabricanteServico.EliminarFabricantePorId(id);
                TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " , foi removido com sucesso.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ObterVisaoFabricantePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fabricante fabricante = _fabricanteServico.ObterFabricanePorId((long)id);

            if (fabricante == null)
            {
                return HttpNotFound();
            }

            return View(fabricante);
        }

        private ActionResult GravarFabricante(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fabricanteServico.GravarFabricante(fabricante);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(fabricante);
            }
        }
    }
}