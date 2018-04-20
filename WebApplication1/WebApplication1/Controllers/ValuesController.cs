using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi1.Models;

namespace webapi1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        private statinfi_summitEntities db = new statinfi_summitEntities();
        public List<graphs> Get()
        {
            graphl j = new graphl();

            j.lm = (from B in db.Invoices

                    select new graphs()
                    {
                        label = B.InvoiceDate,
                        value = B.InvoiceAmt

                    }).ToList();


            return j.lm;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

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
