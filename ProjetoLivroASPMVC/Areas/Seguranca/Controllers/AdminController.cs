using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProjetoLivroASPMVC.Areas.Seguranca.Models;
using ProjetoLivroASPMVC.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace ProjetoLivroASPMVC.Areas.Seguranca.Controllers
{
    public class AdminController : Controller
    {
        public GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }
        // GET: Seguranca/Admin
        [Authorize]
        public ActionResult Index()
        {
            return View(GerenciadorUsuario.Users);
        }

        // GET: Seguranca/Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario user = GerenciadorUsuario.FindById(id);

            if (user == null)
            {
                return new HttpNotFoundResult();
            }

            UsuarioViewModel pageModel = new UsuarioViewModel();

            pageModel.Id = user.Id;
            pageModel.Nome = user.UserName;
            pageModel.Email = user.Email;

            return View(pageModel);

        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario user = GerenciadorUsuario.FindById(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        public ActionResult Details(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario user = GerenciadorUsuario.FindById(id);

            if(user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel model)
        {
            if(ModelState.IsValid)
            {
                Usuario user = new Usuario { UserName = model.Nome, Email = model.Email };
                IdentityResult result = GerenciadorUsuario.Create(user, model.Senha);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel pageModel)
        {
            if(ModelState.IsValid)
            {
                //Recupera o usuário a ser editado da base de dados
                Usuario usuario = GerenciadorUsuario.FindById(pageModel.Id);

                //Edita o usuário com as informações da View Model
                usuario.UserName = pageModel.Nome;
                usuario.Email = pageModel.Email;
                usuario.PasswordHash = GerenciadorUsuario.PasswordHasher.HashPassword(pageModel.Senha);

                //Atualiza os dados utilizando o metodo update para obter um IdentityResult
                IdentityResult result = GerenciadorUsuario.Update(usuario);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(pageModel);
        }

        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            Usuario user = GerenciadorUsuario.FindById(usuario.Id);
            if(user != null)
            {
                IdentityResult result = GerenciadorUsuario.Delete(usuario);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return HttpNotFound();
            }
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach(string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}