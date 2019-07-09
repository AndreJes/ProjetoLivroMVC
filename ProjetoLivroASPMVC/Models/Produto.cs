using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivroASPMVC.Models
{
    public class Produto
    {
        public long? ProdutoID { get; set; }
        public string Nome { get; set; }

        public long? CategoriaID { get; set; }
        public long? FabricanteID { get; set; }

        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }

    }
}