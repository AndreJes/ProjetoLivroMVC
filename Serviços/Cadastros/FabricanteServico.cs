﻿using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviços.Cadastros
{
    public class FabricanteServico
    {
        private FabricanteDAL fabricanteDAL = new FabricanteDAL();

        public IQueryable<Fabricante> ObterFabricantesOrdenadosPorNome()
        {
            return fabricanteDAL.ObterFabricantesOrdenadosPorNome();
        }
    }
}
