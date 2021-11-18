using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCsvProject.BL.Interfaces;
using TestCsvProject.BL.Services;
using TestCsvProject.ViewModels;

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

        [HttpGet]
        public ActionResult ManageData()
        {
            var result = _contrl.GetAllDataForUser(User.Identity.GetUserId());
            return View(result);
        }

        [HttpGet]
        public ViewResult EditData(int id)
        {
            var item = _contrl.GetCsvUserDataItem(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult EditData(CsvUserDataViewModel record)
        {
            if (ModelState.IsValid)
            {
                _contrl.UpdateRecord(record, User.Identity.GetUserId());
                return RedirectToAction("ManageData");
            }
            else
            {
                // there is something wrong with the data values
                return View(record);
            }
        }
    }
}