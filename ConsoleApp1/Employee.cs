using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Employee : Person
    {
        public string jobTitle { get; set; }

        public Employee(string firstName, string lastName, string jobTitle) : base(firstName, lastName)
        {
            this.jobTitle = jobTitle;
        }
    }
}
