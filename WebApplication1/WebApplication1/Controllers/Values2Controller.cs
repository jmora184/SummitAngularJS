using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Values2Controller : ApiController
    {
        private statinfi_summitEntities db = new statinfi_summitEntities();
        public List<graphs2> Get()
        {
            graphl2 j = new graphl2();


            j.lm = (from B in db.Invoices

                    select new graphs2()
                    {
                        label = B.InvoiceDate,
                        value = B.InvoiceAmt - 20510

                    }).ToList();


            return j.lm;
        }
    }
}
