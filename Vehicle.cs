using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Report.Application
{
    public class Vehicle
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public Vehicle(int year, string make, string model)
        {
            Year = year;
            Make = make;
            Model = model;
        }
    }
}
