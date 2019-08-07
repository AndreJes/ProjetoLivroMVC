using Modelo.Cadastros;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Cadastros
{
    public class FabricanteDAL
    {
        private EFContext _context = new EFContext();

        public IQueryable<Fabricante> ObterFabricantesOrdenadosPorNome()
        {
            return _context.Fabricantes.OrderBy(f => f.Nome);
        }
    }
}
