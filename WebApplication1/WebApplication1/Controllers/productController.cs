using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi1;

namespace webapi1.Controllers
{
    public class productController : ApiController
    {
        private statinfi_summitEntities db = new statinfi_summitEntities();
        // GET: user
        //[HttpGet]

        public List<Product> Get()
        {
            List<Product> product = null;
            try
            {
                product = db.Products.ToList();
            }
            catch
            {
                product = null;
            }
            return product;
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



