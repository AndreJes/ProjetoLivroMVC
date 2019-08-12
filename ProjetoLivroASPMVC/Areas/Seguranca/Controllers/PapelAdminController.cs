using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProjetoLivroASPMVC.Areas.Seguranca.Models;
using ProjetoLivroASPMVC.Infraestrutura;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLivroASPMVC.Areas.Seguranca.Controllers
{
    public class PapelAdminController : Controller
    {
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach(string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private GerenciadorUsuario UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }

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
        public ActionResult Create([Required]string nome)
        {
            if(ModelState.IsValid)
            {
                IdentityResult result = roleManager.Create(new Papel(nome));
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(nome);
        }
    }
}