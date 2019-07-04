using ProjetoLivroASPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLivroASPMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria(1, "NoteBooks"),
            new Categoria(2, "Monitores"),
            new Categoria(3, "Impressoras"),
            new Categoria(4, "Mouses"),
            new Categoria(5, "Desktops")
        };

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Edit
        public ActionResult Edit(long id)
        {
            return View(categorias.Where(c => c.CategoriaID == id).First());
        }

        // GET: Details
        public ActionResult Details(long id)
        {
            return View(categorias.Where(c => c.CategoriaID == id).First());
        }

        // GET: Delete
        public ActionResult Delete(long id)
        {
            return View(categorias.Where(c => c.CategoriaID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categoria.CategoriaID = categorias.Select(lc => lc.CategoriaID).Max() + 1;
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias[categorias.IndexOf(
                categorias.Where(c => c.CategoriaID == categoria.CategoriaID).First()
                )] = categoria;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaID == categoria.CategoriaID).First());
            return RedirectToAction("Index");
        }
    }
}