using Modelo.Tabelas;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
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
    }
}
