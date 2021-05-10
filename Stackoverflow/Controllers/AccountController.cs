using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflow.ServiceLayer.Interfaces;
using StackOverflow.ViewModels;

namespace Stackoverflow.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersService _usersService;

        public AccountController(IUsersService service)
        {
            _usersService = service;
        }
        public ActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                int userid = _usersService.InsertUser(registerViewModel);

                Session["CurrentUserId"] = userid;
                Session["CurrentUserName"] = registerViewModel.Name;
                Session["CurrentUserEmail"] = registerViewModel.Email;
                Session["CurrentUserPassword"] = registerViewModel.Password;
                Session["CurrentUserIsAdmin"] = false;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("key", "invalid-date");
                return View();
            }
        }

        public ActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                UserViewModel model = _usersService.GetUserByEmailAndPassword(viewModel.Email, viewModel.Password);
                if (model != null)
                {
                    Session["CurrentUserId"] = model.UserId;
                    Session["CurrentUserName"] = model.Name;
                    Session["CurrentUserEmail"] = viewModel.Email;
                    Session["CurrentUserPassword"] = viewModel.Password;
                    Session["CurrentUserIsAdmin"] = model.IsAdmin;

                    if (model.IsAdmin)
                    {
                        return RedirectToRoute(new { area = "Admin", controller = "AdminHome", action = "Index" });
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("key", "invalid email and password");
                    return View(viewModel);
                }
            }
            else
            {
                ModelState.AddModelError("key", "invalid data");
                return View(viewModel);
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}