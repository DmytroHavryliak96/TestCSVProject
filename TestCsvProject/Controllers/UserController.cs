using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCsvProject.BL.Interfaces;
using TestCsvProject.BL.Services;

namespace TestCsvProject.Controllers
{
    public class UserController : Controller
    {
        private IUserController _contrl;

        public UserController(IUserController controller)
        {
            _contrl = controller;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadFile()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult LoadFile(HttpPostedFileBase file)
        {
            if (file != null)
            {
                _contrl.SaveData(file, User.Identity.GetUserId());
            }

            return RedirectToAction("Index");
        }
    }
}