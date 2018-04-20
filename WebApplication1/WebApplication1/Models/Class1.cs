using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi1.Models
{
    public class Class1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string LoginID { get; set; }
        public int UserRouteNumber { get; set; }
        public bool Active { get; set; }
    }

    public class Emp
    {
        public int PayrollID { get; set; }
        public Nullable<int> EmpID { get; set; }
        public Nullable<System.DateTime> PayBegin { get; set; }
        public Nullable<System.DateTime> PayEnd { get; set; }
        public Nullable<decimal> Deductions { get; set; }
        public Nullable<decimal> NetPay { get; set; }
        public Nullable<int> AcctNumber { get; set; }
        public Nullable<int> RouteNumber { get; set; }
        public string BankName { get; set; }
        public string lable { get; set; }
        public int value { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        public virtual Employee Employee { get; set; }

    }
    public class empl
    {
        public List<Emp> a { get; set; }

    }

    public class UserInfo
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }

        public int PayrollID { get; set; }
        public string BankName { get; set; }

        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string EmpPhone { get; set; }
    }

    public class graphs
    {
        public DateTime label { get; set; }
        public decimal value { get; set; }
    }
    public class graphl
    {
        public List<graphs> lm { get; set; }
    }

    public class login
    {
        public List<UserRole> l { get; set; }
    }
}