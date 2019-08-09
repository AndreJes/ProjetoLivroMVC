using Modelo.Cadastros;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Fabricante ObterFabricantePorId(long id)
        {
            return _context.Fabricantes.Where(f => f.FabricanteID == id).Include("Produtos.Categoria").First();
        }

        public void GravarFabricante(Fabricante fabricante)
        {
            if(fabricante.FabricanteID == null)
            {
                _context.Fabricantes.Add(fabricante);
            }
            else
            {
                _context.Entry(fabricante).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public Fabricante EliminarFabricantePorId(long id)
        {
            Fabricante fabricante = ObterFabricantePorId(id);
            _context.Fabricantes.Remove(fabricante);
            _context.SaveChanges();
            return fabricante;
        }
    }
}
