using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCsvProject.Models;

namespace TestCsvProject.DAO.Interfaces
{
    public interface IIUnitOfWork
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<CsvUserDataModel> UserDataModels { get; }
        void Save();
    }
}
