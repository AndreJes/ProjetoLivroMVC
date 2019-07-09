using ProjetoLivroASPMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoLivroASPMVC.Contexts
{
    public class EFContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public EFContext() : base("Asp_Net_MVC_CS") { }
    }
}