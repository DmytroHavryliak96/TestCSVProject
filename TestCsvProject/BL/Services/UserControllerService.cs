using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestCsvProject.DAO.Interfaces;
using TestCsvProject.DAO.Repositories;
using TestCsvProject.BL.Interfaces;
using TestCsvProject.Models;
using TestCsvProject.ViewModels;
using System.Web.Mvc;

namespace TestCsvProject.BL.Services
{
    [Authorize]
    public class UserControllerService : IUserController
    {
        private IUnitOfWork database;
        IParseCsvFile<CsvUserDataViewModel> parser;

        public UserControllerService(IUnitOfWork db, IParseCsvFile<CsvUserDataViewModel> parser)
        {
            database = db;
            this.parser = parser;

        }
        
        public void SaveData(HttpPostedFileBase file, string userId)
        {
            var rep = (ApplicationUserRepository)database.Users;
            var records = parser.Parse(file).ToList();

            for (int i = 0; i < records.Count(); i++)
            {
                var csvData = new CsvUserDataModel
                {
                    Name = records[i].Name,
                    DateOfBirth = records[i].DateOfBirth,
                    Married = records[i].Married,
                    Phone = records[i].Phone,
                    Salary = records[i].Salary,
                    User = rep.Get(userId)
                };

                database.UserDataModels.Create(csvData);
            }

            database.Save();

        }
    }
}