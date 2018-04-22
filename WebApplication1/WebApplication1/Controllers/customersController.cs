using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication1.Controllers
{
    public class customersController : ApiController
    {
        private statinfi_summitEntities db = new statinfi_summitEntities();
        // GET: user
        //[HttpGet]
        //hi mom    

        public List<Customer> Get()
        {
            List<Customer> customers = null;
            try
            {
                customers = db.Customers.ToList();
            }
            catch
            {
                customers = null;
            }       
            return customers;
        }

        public string Post([FromBody]Customer customer)
        {
            var c = db.Customers.Create();

            c.CustID = customer.CustID;
            c.CustName = customer.CustName;
            c.CustAddress = customer.CustAddress;
            c.CustPhone = customer.CustPhone;

            db.Customers.Add(c);
            db.SaveChanges();
            return "sucess";
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id,[FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustID)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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
        private bool CustomerExists(int id)
        {
            return db.Vendors.Count(e => e.VendorID == id) > 0;
        }
    }
}
