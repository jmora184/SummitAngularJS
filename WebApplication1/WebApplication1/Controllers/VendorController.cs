using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.Http.Description;
using System.Data.Entity;
using System.Web.Http.Cors;
using webapi1;
using AngularJS.webapi1;

namespace AngularJS.webapi1.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class VendorController : ApiController
    {

        private statinfi_summitEntities db = new statinfi_summitEntities();

        public IEnumerable<Vendor> Get()
        {
            var vendor = db.Vendors.ToList();
            return vendor;
        }

        [HttpPost]
        [ResponseType(typeof(Vendor))]
        public IHttpActionResult AddVendor(Vendor vendor)
        {

            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                db.SaveChanges();
            }
            else
            {
                return BadRequest(ModelState);
            }

            return Ok<string>("User successfully created");
        }

        [ResponseType(typeof(Vendor))]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid vendor id");

                 var vendor = db.Vendors
                .Where(v => v.VendorID == id)
                .FirstOrDefault();

            db.Entry(vendor).State = EntityState.Deleted;
            db.SaveChanges();

            return Ok();
        }
        [ResponseType(typeof(Vendor))]
        public IHttpActionResult UpdateUser(Vendor vendor)
        {
            int id = vendor.VendorID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != vendor.VendorID)
            {
                return BadRequest();
            }
            db.Entry(vendor).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();




        }
    }


}
    

