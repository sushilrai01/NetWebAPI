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
    public class DriverController : ApiController
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


    } //<--MAIN DRIVER-CONTROLLER CLASS.
}
