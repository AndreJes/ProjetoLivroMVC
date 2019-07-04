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

        public ActionResult Edit(long id)
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
    }
}