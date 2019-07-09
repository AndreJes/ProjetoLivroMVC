using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivroASPMVC.Models
{
    public class Fabricante
    {
        public long FabricanteID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}