using Microsoft.AspNet.Identity.Owin;
using ProjetoLivroASPMVC.Areas.Seguranca.Models;
using ProjetoLivroASPMVC.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLivroASPMVC.Areas.Seguranca.Controllers
{
    public class PapelAdminController : Controller
    {
        private GerenciadorPapel roleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorPapel>();
            }
        }
        // GET: Seguranca/PapelAdmin
        public ActionResult Index()
        {
            return View(roleManager.Roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Papel papel)
        {
            return View();
        }
    }
}