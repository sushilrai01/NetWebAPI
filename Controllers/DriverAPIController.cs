using DriverInformation.ViewModel;
using NetWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NetWebAPI.Controllers
{
    public class DriverAPIController : ApiController
    {
        private DriverManagementEntities db = new DriverManagementEntities();

        public IHttpActionResult GetAllDriver()
        {
            IList<DriverInfoModel> driverInfo = null;
            driverInfo = db.DriverTable.Select(x => new DriverInfoModel()
            {
                DriverId = x.DriverId,
                DriverName = x.Name,
                ContactNo = x.ContactNo,    
                GenderId = x.GenderId == null? 0: x.GenderId.Value,
                ActiveId = x.IsActive == null ? 0 : x.IsActive.Value,
                Football = x.Football ==null ? false: x.Football.Value, 
            }).ToList();

            if(driverInfo.Count() == 0)
            {
                return NotFound();  
            }

            return Ok(driverInfo);
        }

        public IHttpActionResult PostNewDriver(DriverInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");  
            }

            DriverTable drivertbl = new DriverTable();

            drivertbl.DriverId = model.DriverId;
            drivertbl.Name = model.DriverName;
            drivertbl.ContactNo = model.ContactNo;      
            drivertbl.Football = model.Football;
            drivertbl.GenderId = model.GenderId;
            drivertbl.IsActive = model.ActiveId;
            drivertbl.Basketball = model.Basketball;    
            drivertbl.Cricket = model.Cricket;

            db.DriverTable.Add(drivertbl);
            db.SaveChanges();

            return Ok();
        }

    } //<--MAIN DRIVER-CONTROLLER CLASS.
}
