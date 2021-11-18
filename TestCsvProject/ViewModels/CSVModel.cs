using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCsvProject.ViewModels
{
    public class CSVModel
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Married { get; set; }
        public string Phone { get; set; }

        public decimal Salary { get; set; }
    }
}