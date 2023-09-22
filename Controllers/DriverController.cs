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
            IEnumerable<DriverInfoModel> driverInfo = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44348/api/DriverAPI");
                //HTTP GET
                var responseTask = client.GetAsync("DriverAPI");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<DriverInfoModel>>();
                    readTask.Wait();

                    driverInfo = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    driverInfo = Enumerable.Empty<DriverInfoModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(driverInfo);
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

        //POST: Driver/Create
        //[HttpPost]
        //public ActionResult Create(DriverInfoModel model)
        //{
        //    //using (var client = new HttpClient())
        //    //{
        //    //    client.BaseAddress = new Uri("https://localhost:44348/api/DriverAPI");

        //    //    //HTTP POST
        //    //    var postTask = client.PostAsJsonAsync<DriverInfoModel>("DriverAPI", model);
        //    //    postTask.Wait();

        //    //    var result = postTask.Result;
        //    //    if (result.IsSuccessStatusCode)
        //    //    {
        //    //        return RedirectToAction("Index");
        //    //    }
        //    //}

        //    //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

        //    model.GenList = db.GenderTable
        //                     .Select(x => new DropdownModel { ID = x.GenderId, TEXT = x.Category }).ToList();
        //    model.ActList = db.ActivityTable
        //                      .Select(x => new DropdownModel { ID = x.IsActive, TEXT = x.Available }).ToList();
        //    model.HobList = db.HobbyTable
        //                         .Select(x => new HobbyModel { HobbyId = x.HobbyId, Hobby = x.Hobby, IsActive = x.IsActive == null ? false : x.IsActive.Value }).ToList();

        //    return View(model);
        //}
    }
}