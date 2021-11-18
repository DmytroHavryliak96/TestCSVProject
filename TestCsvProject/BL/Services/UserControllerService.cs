﻿using System;
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

        public void DeleteRecord(int id)
        {
            database.UserDataModels.Delete(id);
            database.Save();
        }

        public IEnumerable<CsvUserDataViewModel> GetAllDataForUser(string userId)
        {

            var result = new List<CsvUserDataViewModel>();

            var records = database.UserDataModels.Find(record => record.User.Id.Equals(userId)).ToList();

            for(int i = 0; i < records.Count(); i++)
            {
                result.Add(new CsvUserDataViewModel
                {
                    Name = records[i].Name,
                    DateOfBirth = records[i].DateOfBirth,
                    Married = records[i].Married,
                    Phone = records[i].Phone,
                    Salary = records[i].Salary,
                    Id = records[i].Id
                });
            }
            return result;
        }

        public CsvUserDataViewModel GetCsvUserDataItem(int id)
        {
            var record = database.UserDataModels.Get(id);
            var result = new CsvUserDataViewModel
            {
                Name = record.Name,
                DateOfBirth = record.DateOfBirth,
                Married = record.Married,
                Phone = record.Phone,
                Salary = record.Salary,
                Id = record.Id
            };
            return result;
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

        public void UpdateRecord(CsvUserDataViewModel record, string userId)
        {
            var rep = (ApplicationUserRepository)database.Users;

            var result = new CsvUserDataModel
            {
                Id = record.Id,
                Name = record.Name,
                DateOfBirth = record.DateOfBirth,
                Married = record.Married,
                Phone = record.Phone,
                Salary = record.Salary,
                User = rep.Get(userId)
            };

            database.UserDataModels.Update(result);
            database.Save();
        }
    }
}