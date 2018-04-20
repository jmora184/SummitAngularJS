using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

using System.Web.Http.Cors;
using webapi1;

namespace webapi1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VendorsController : ApiController
    {

        private statinfi_summitEntities db = new statinfi_summitEntities();

        // GET: api/Vendors
        public IQueryable<Vendor> GetVendors()
        {
            return db.Vendors;
        }
        
        // GET: api/Vendors/5
        [ResponseType(typeof(Vendor))]
        public IHttpActionResult GetVendor(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor);
        }

        // PUT: api/Vendors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendor.VendorID)
            {
                return BadRequest();
            }

            db.Entry(vendor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vendors
        [ResponseType(typeof(Vendor))]
        public IHttpActionResult PostVendor(Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vendors.Add(vendor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VendorExists(vendor.VendorID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vendor.VendorID }, vendor);
        }

        // DELETE: api/Vendors/5
        [ResponseType(typeof(Vendor))]
        public IHttpActionResult DeleteVendor(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return NotFound();
            }

            db.Vendors.Remove(vendor);
            db.SaveChanges();

            return Ok(vendor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendorExists(int id)
        {
            return db.Vendors.Count(e => e.VendorID == id) > 0;
        } 
    }
}