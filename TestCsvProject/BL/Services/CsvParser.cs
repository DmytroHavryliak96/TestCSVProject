﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestCsvProject.BL.Interfaces;
using TestCsvProject.Models;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace TestCsvProject.BL.Services
{
    public class CsvParser<T> : IParseCsvFile<T>
    {   
        public IEnumerable<T> Parse(HttpPostedFileBase file)
        {
            IEnumerable<T> records;
            using (var reader = new StreamReader(file.InputStream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<T>().ToList();
            }

            return records;
        }
    }
}