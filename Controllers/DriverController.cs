using DriverInformation.ViewModel;
using NetWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace NetWebAPI.Controllers
{
    public class DriverController : Controller
    {
        private DriverManagementEntities db = new DriverManagementEntities();

        // GET: Driver
        public ActionResult Index()
        {
            return View();
        }
        //GET: Driver/Create
        public ActionResult Create()
        {
            DriverInfoModel model = new DriverInfoModel();

            model.GenList = db.GenderTable
                               .Select(x => new DropdownModel { ID = x.GenderId, TEXT = x.Category }).ToList();
            model.ActList = db.ActivityTable
                              .Select(x => new DropdownModel { ID = x.IsActive, TEXT = x.Available }).ToList();
            model.HobList = db.HobbyTable
                                 .Select(x => new HobbyModel { HobbyId = x.HobbyId, Hobby = x.Hobby, IsActive = x.IsActive == null ? false : x.IsActive.Value }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(DriverInfoModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44348/api/DriverAPI");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<DriverInfoModel>("DriverAPI", model);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index","Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            model.GenList = db.GenderTable
                             .Select(x => new DropdownModel { ID = x.GenderId, TEXT = x.Category }).ToList();
            model.ActList = db.ActivityTable
                              .Select(x => new DropdownModel { ID = x.IsActive, TEXT = x.Available }).ToList();
            model.HobList = db.HobbyTable
                                 .Select(x => new HobbyModel { HobbyId = x.HobbyId, Hobby = x.Hobby, IsActive = x.IsActive == null ? false : x.IsActive.Value }).ToList();

            return View(model);
        }
    }
}