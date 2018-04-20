using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webapi1.Controllers
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
    }
}
