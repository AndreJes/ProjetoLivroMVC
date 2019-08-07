using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;

namespace Serviços.Tabelas
{
    public class CategoriaServico
    {
        private CategoriaDAL categoriaDAL = new CategoriaDAL();

        public IQueryable<Categoria> ObterCategoriasOrdenadasPorNome()
        {
            return categoriaDAL.ObterCategoriasOrdenadasPorNome();
        }
    }
}
