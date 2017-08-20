﻿using System.Web.Mvc;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider authProvider;

        public AccountController(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }
        
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                if(authProvider.authenticate(model.Username, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect Username or Password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}