using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi1;

namespace WebApplication1.Controllers
{
    public class productController : ApiController
    {
        private statinfi_summitEntities db = new statinfi_summitEntities();
        // GET: user
        //[HttpGet]

        public List<Product> Get()
        {

            var s = db.Products.ToList();

            return s;
        }

        public string Post([FromBody]Product product)
        {
            var j = db.Products.Create();
            

            j.ProductID = product.ProductID;
            j.VendorID = 21;
            j.Price = product.Price;
            j.Description = product.Description;

            db.Products.Add(j);
            db.SaveChanges();
            return "sucess";
        }
    }
}



