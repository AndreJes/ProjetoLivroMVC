﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivroASPMVC.Areas.Seguranca.Models
{
    public class Papel : IdentityRole
    {
        public Papel() : base() { }

        public Papel(string nome) : base(nome) { }
    }
}