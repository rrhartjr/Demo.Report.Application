using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Report.ReportItems;

namespace Demo.Report.Application
{
    public class Dealership : IRenderable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CityStateZip { get; set; }

        public IList<Vehicle> Vehicles { get; set; }
        public IList<Employee> Employees { get; set; }

        public Dealership(string name, string address, string citystatezip)
        {
            Name = name;
            Address = address;
            CityStateZip = citystatezip;

            Vehicles = new List<Vehicle>();
            Employees = new List<Employee>();
        }

        public IList<IReportItem> GetDocumentOutline()
        {
            var outline = new List<IReportItem>();
            outline.Add(new TitleHeader(Name));
            outline.Add(new DataTuple("Address", Address, ""));
            outline.Add(new DataTuple("City, State, Zip", CityStateZip, ""));
            
            outline.Add(new SectionHeader("Vehicle Inventory"));
            var vehicles = new DataSection();
            vehicles.ColumnHeaders = new[] { "Year", "Make", "Model" };
            vehicles.ColumnWidths = new[] { 20, 40, 50 };
            vehicles.Rows = Vehicles.Select(v => new [] { v.Year.ToString(), v.Make, v.Model });
            outline.Add(vehicles);
            outline.Add(new PageBreak());

            outline.Add(new SectionHeader("Employees"));
            var employees = new DataSection();
            employees.ColumnHeaders = new[] { "First Name", "Last Name", "Position" };
            employees.ColumnWidths = new[] { 30, 30, 30 };
            employees.Rows = Employees.Select(e => new[] { e.FirstName, e.LastName, e.Position.ToString() });
            outline.Add(employees);

            return outline;
        }
    }
}
