using System;
using System.Collections.Generic;
using System.Data.Entity;
using ProjetoLivroASPMVC.Contexts;
using System.Web.Mvc;
using System.Linq;
using ProjetoLivroASPMVC.Models;
using System.Net;

namespace ProjetoLivroASPMVC.Controllers
{
    public class ProdutosController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(n => n.Nome);
            return View(produtos);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = context.Produtos.Where(p => p.ProdutoID == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(context.Categorias.OrderBy(n => n.Nome), "CategoriaID", "Nome");
            ViewBag.FabricanteID = new SelectList(context.Fabricantes.OrderBy(n => n.Nome), "FabricanteID", "Nome");
            return View();
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = context.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoriaID = new SelectList(context.Categorias.OrderBy(p => p.Nome), "CategoriaID", "Nome", produto.CategoriaID);
            ViewBag.FabricanteID = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteID", "Nome", produto.FabricanteID);

            return View(produto);
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(produto);
            }
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(produto).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch
            {
                return View(produto);
            }
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
