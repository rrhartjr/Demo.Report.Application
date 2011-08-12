using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Report.Renderers;

namespace Demo.Report.Application
{
    class Program
    {
        private static readonly string FILE_NAME = "Demo";

        static void Main(string[] args)
        {
            var Dealership = new Dealership(
                "Deals on Wheels",
                "1505 Burned Rubber Boulevard",
                "Pleasantville, KS 66055"
            );

            Dealership.Vehicles = new List<Vehicle>(
                new[] {
                    new Vehicle(2010, "Ford", "Focus"),
                    new Vehicle(2005, "Chevrolet", "Avalanche"),
                    new Vehicle(2000, "Hyundai", "Elantra"),
                    new Vehicle(1995, "Toyota", "Tercel"),
                    new Vehicle(1990, "Honda", "Civic")
                }
            );

            Dealership.Employees = new List<Employee>(
                new[] {
                    new Employee("Nelson", "Kees", Position.Manager),
                    new Employee("Lonnie", "Branner", Position.Manager),
                    new Employee("Pam", "Dion", Position.Manager),
                    new Employee("Natasha", "Jones", Position.Manager),
                    new Employee("Jeffery", "Thacker", Position.Salesperson),
                    new Employee("Aaron", "Hearn", Position.Salesperson),
                    new Employee("Melissa", "Barnes", Position.Salesperson),
                    new Employee("Emily", "Valero", Position.Salesperson),
                }
            );

            string basename = FILE_NAME + DateTime.Now.ToString("yyyyMMddHHmm");
            string csvFilename = basename + ".csv";
            string pdfFilename = basename + ".pdf";

            Console.WriteLine("Writing CSV Report to " + csvFilename);
            Dealership.RenderAndSave<CsvDocumentRenderer>(csvFilename);

            Console.WriteLine("Writing PDF Report to " + pdfFilename);
            Dealership.RenderAndSave<TextSharpPdfDocumentRenderer>(pdfFilename);

            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();
        }
    }
}
