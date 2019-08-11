using Microsoft.AspNet.Identity.EntityFramework;
using ProjetoLivroASPMVC.Areas.Seguranca.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoLivroASPMVC.DAL
{
    public class IdentityDbContextAplicacao : IdentityDbContext<Usuario>
    {
        public IdentityDbContextAplicacao() : base("MySQL_UserDB") { }

        static IdentityDbContextAplicacao()
        {
            Database.SetInitializer<IdentityDbContextAplicacao>(new IdentityDbInit());
        }

        public static IdentityDbContextAplicacao Create()
        {
            return new IdentityDbContextAplicacao();
        }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityDbContextAplicacao> { }
}