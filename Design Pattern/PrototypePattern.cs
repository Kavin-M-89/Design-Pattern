using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern
{
    public class PrototypePattern : IDesignPatten
    {
        public void Main()
        {
            TemporaryEmployee emp1 = new TemporaryEmployee();
            emp1.Name = "K";
            emp1.CompanyName = "CN";
            emp1.CompanyAddress = "CA";

            Employee emp2 = emp1.Clone();
            emp2.Name = "M";

            Console.WriteLine(emp1.Name + " " + emp1.CompanyName + " " + emp1.CompanyAddress);
            Console.WriteLine(emp2.Name + " " + emp2.CompanyName + " " + emp2.CompanyAddress);
        }
    }

    public class TemporaryEmployee : Employee
    {
        public override Employee Clone()
        {
            return (TemporaryEmployee)this.MemberwiseClone();
        }
    }

    public abstract class Employee
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }

        public abstract Employee Clone();

    }
}
