using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webapi1.Controllers
{

    public class LogInController : ApiController
    {
        private statinfi_summitEntities db = new statinfi_summitEntities();

        public List<UserRole> Get()
        {
            var s = db.UserRoles.ToList();

            return s;
        }
    }
}
