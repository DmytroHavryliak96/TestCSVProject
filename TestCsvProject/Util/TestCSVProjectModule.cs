using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using TestCsvProject.DAO.Interfaces;
using TestCsvProject.DAO.Repositories;
using TestCsvProject.BL.Interfaces;
using TestCsvProject.BL.Services;
using TestCsvProject.Models;
using TestCsvProject.ViewModels;

namespace TestCsvProject.Util
{
    public class TestCSVProjectModule : NinjectModule
    {
        private string connectionString;

        public TestCSVProjectModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
            Bind<IParseCsvFile<CSVModel>>().To<CsvParser<CSVModel>>();
            Bind<IUserController>().To<UserControllerService>();
        }
    }
}