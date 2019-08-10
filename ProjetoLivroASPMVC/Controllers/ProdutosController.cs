using System.Data.Entity;
using System.Web.Mvc;
using System.Linq;
using Modelo.Cadastros;
using System.Net;
using Serviços.Cadastros;
using Serviços.Tabelas;

namespace Persistencia.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutoServico _produtoServico = new ProdutoServico();
        private CategoriaServico _categoriaServico = new CategoriaServico();
        private FabricanteServico _fabricanteServico = new FabricanteServico();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(_produtoServico.ObterProdutosOrdenadosPorNome());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoProdutoPorId(id);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(_produtoServico.ObterProdutoPorId((long)id));
            return ObterVisaoProdutoPorId(id);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            return GravarProduto(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            return GravarProduto(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Produto produto = _produtoServico.EliminarProdutoPorId(id);
                TempData["Message"] = "Produto: " + produto.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ObterVisaoProdutoPorId(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = _produtoServico.ObterProdutoPorId((long) id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        private void PopularViewBag(Produto produto = null)
        {
            if(produto == null)
            {
                ViewBag.CategoriaId = new SelectList(_categoriaServico.ObterCategoriasOrdenadasPorNome(), "CategoriaId", "Nome");
                ViewBag.FabricanteId = new SelectList(_fabricanteServico.ObterFabricantesOrdenadosPorNome(), "FabricanteId", "Nome");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(_categoriaServico.ObterCategoriasOrdenadasPorNome(), "CategoriaId", "Nome", produto.CategoriaID);
                ViewBag.FabricanteId = new SelectList(_fabricanteServico.ObterFabricantesOrdenadosPorNome(), "FabricanteId", "Nome", produto.FabricanteID);
            }
        }

        private ActionResult GravarProduto(Produto produto)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _produtoServico.GravarProduto(produto);
                }
                PopularViewBag(produto);
                return View(produto);
            }
            catch
            {
                PopularViewBag(produto);
                return View(produto);
            }
        }
    }
}
