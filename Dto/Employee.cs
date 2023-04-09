using System;
using System.Collections.Generic;
using System.Text;

namespace Linq.Models
{
   public  class  Employees
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Lname { get; set; }
        public override string ToString()
        {
            return $"empName is {Name } + His Id Is {ID} + His Address is {Address}";
        }
        //public Employee() { }
        //public int Id { get; set; }

        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        //public DateTime HireDate { get; set; }

        //public string Gender { get; set; }

        //public string Department { get; set; }

        //public bool HasHealthInsurance { get; set; }

        //public bool HasPensionPlan { get; set; }

        //public decimal Salary { get; set; }

        //public override string ToString()
        //{
        //    return
        //            string.Format($"" +
        //            $"{Id}\t" +
        //            $" {String.Concat(LastName, ", ", FirstName).PadRight(15, ' ')}\t" +
        //            $"{HireDate.Date.ToShortDateString()}\t" +
        //            $"{Gender.PadRight(10, ' ')}\t" +
        //            $"{Department.PadRight(10, ' ')}\t" +
        //            $"{HasHealthInsurance}\t" +
        //            $"{HasPensionPlan}\t" +
        //            $"${Salary.ToString("0.00")}");
        //}
    }
}
