using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Xml.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
 
    public class userController : ApiController
    {
        private statinfi_summitEntities db = new statinfi_summitEntities();

        public List<Emp> Get()
        {
            empl n = new empl();
            n.a = (from B in db.Payrolls
                   join c in db.Employees on B.EmpID equals c.EmpID
                   select new Emp()
                   {

                       PayrollID = B.PayrollID,
                       EmpID = B.EmpID,
                       PayBegin = B.PayBegin,
                       PayEnd = B.PayEnd,
                       Deductions = B.Deductions,
                       NetPay = B.NetPay,
                       AcctNumber = B.AcctNumber,
                       RouteNumber = B.RouteNumber,
                       BankName = B.BankName,
                       lable = B.BankName,
                       value = B.BankName.Length,
                       name=c.EmpName,
                       EmpAddress=c.EmpAddress
                       

                   }).ToList();

            return n.a;
        }


        public string Post([FromBody]UserInfo value)
        {
            var j = db.UserRoles.Create();
            var s = db.Payrolls.Create();
            var m = db.Employees.Create();

            j.UserID = value.UserID;
            j.Role = value.Role;
            j.Email = value.Email;

            db.UserRoles.Add(j);

            m.EmpID = value.UserID;
            m.EmpName = value.EmpName;
            m.EmpAddress = value.EmpAddress; 
            m.EmpPhone = value.EmpPhone;

            db.Employees.Add(m);

            s.PayrollID = value.PayrollID;
            s.BankName = value.BankName;
            s.EmpID = value.UserID;

            db.Payrolls.Add(s);



          
            db.SaveChanges();

            return "sucess";

        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, [FromBody]payroll payroll)
        {


            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != payroll.PayrollID)
                {
                    return BadRequest();
                }

                var ss = db.Payrolls.FirstOrDefault(p => p.PayrollID == id);
                var sj = db.Employees.FirstOrDefault(p => p.EmpID== ss.EmpID);

                ss.BankName = payroll.BankName;
                ss.AcctNumber = payroll.AcctNumber;
                sj.EmpAddress = payroll.EmpAddress;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayrollExists(id))
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

        }
        [ResponseType(typeof(Payroll))]
        public IHttpActionResult Delete(int id)
        {
            Payroll payroll = db.Payrolls.Find(id);
            if (payroll == null)
            {
                return NotFound();
            }

            db.Payrolls.Remove(payroll);
            db.SaveChanges();

            return Ok(payroll);
        }

        private bool PayrollExists(int id)
        {
            return db.Payrolls.Count(e => e.PayrollID== id) > 0;
        }

    }
}
