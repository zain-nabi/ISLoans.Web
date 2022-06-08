using ISLoans.Web.API_Helper;
using ISLoans.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISLoans.Web.API_Router;

namespace ISLoans.Web.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            var model = new Users();
            model.IDNumberError = null;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(Users model)
        {
            var checkEmail = await UserService.CheckIfIDExist(model.idNumber);
            if(checkEmail.idNumber == "True")
            {
                model.IDNumberUniqueKey = "Please enter a unique ID number";
                return View(model);
            }
            if(model.idNumber.Length != 13)
            {
                model.IDNumberError = "Invalid ID number";
                return View(model);
            }
            var result = await UserService.Register(model);
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public IActionResult Login()
        {
            var UserViewModel = new UserViewModel();
            UserViewModel.IDNumberError = null;
            return View(UserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            var UserViewModel = new UserViewModel();
            var result = await UserService.Login(model.UserModel.idNumber);
            if(result == null)
            {
                UserViewModel.IDNumberError = "ID Number does not exist";
                return View(UserViewModel);
            }
            return RedirectToAction("UserDocuments", "LoanDocument", new { idNumber = result.idNumber });
        }
    }
}
