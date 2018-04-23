using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        private statinfi_summitEntities db = new statinfi_summitEntities();
        public List<graphs> Get()
        {
            graphl j = new graphl();
           
           
            j.lm = (from B in db.Invoices
                    join c in db.Vendors on B.VendorID equals c.VendorID
                    select new graphs()
                    {
                        label = c.VendorName,
                        value = B.InvoiceAmt

                    }).ToList();


            return j.lm;
        }

        // GET api/values/5
        //public List<graphs2> Get2()
        //{
        //    graphl2 j = new graphl2();


        //    j.lm = (from B in db.Invoices
     
        //            select new graphs2()
        //            {
        //                label = B.InvoiceDate,
        //                value = B.InvoiceAmt

        //            }).ToList();


        //    return j.lm;
        //}

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
