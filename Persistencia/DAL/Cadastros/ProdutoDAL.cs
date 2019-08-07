using Modelo.Cadastros;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Persistencia.DAL.Cadastros
{
    public class ProdutoDAL
    {
        private EFContext _context = new EFContext();

        public IQueryable<Produto> ObterProdutosOrdenadosPorNome()
        {
            return _context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(p => p.Nome);
        }

        public Produto ObterProdutoPorId(long id)
        {
            return _context.Produtos.Where(p => p.ProdutoID == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();
        }

        public void GravarProduto(Produto produto)
        {
            if (produto.ProdutoID == null)
            {
                _context.Produtos.Add(produto);
            }
            else
            {
                _context.Entry(produto).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public Produto EliminarProdutoPorId(long id)
        {
            Produto produto = ObterProdutoPorId(id);
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return produto;
        }
    }
}
