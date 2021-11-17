using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCsvProject.Models
{
    public class CsvUserDataModel
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Married { get; set; }
        public string Phone { get; set; }

        public decimal Salary { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}