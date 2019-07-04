using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivroASPMVC.Models
{
    public class Categoria
    {
        public long CategoriaID { get; set; }
        public string Nome { get; set; }

        public Categoria(long categoriaID, string nome)
        {
            CategoriaID = categoriaID;
            Nome = nome;
        }
    }
}