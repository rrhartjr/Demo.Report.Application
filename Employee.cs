using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Report.Application
{
    public enum Position
    {
        Salesperson,
        Manager
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }

        public Employee(string firstName, string lastName, Position position)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
        }
    }
}
