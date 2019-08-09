using Modelo.Tabelas;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {
        private EFContext _context = new EFContext();

        public IQueryable<Categoria> ObterCategoriasOrdenadasPorNome()
        {
            return _context.Categorias.OrderBy(c => c.Nome);
        }

        public Categoria ObterCategoriaPorId(long id)
        {
            return _context.Categorias.Where(c => c.CategoriaID == id).Include("Produtos.Fabricante").First();
        }

        public void GravarCategoria(Categoria categoria)
        {
            if (categoria.CategoriaID == null)
            {
                _context.Categorias.Add(categoria);
            }
            else
            {
                _context.Entry(categoria).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public Categoria EliminarCategoriaPorId(long id)
        {
            Categoria categoria = ObterCategoriaPorId(id);
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return categoria;
        }
    }
}
