using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestCsvProject.ViewModels;
using TestCsvProject.Models;

namespace TestCsvProject.BL.Interfaces
{
    public interface IUserController
    {
        void SaveData(HttpPostedFileBase file, string userId);

        IEnumerable<CsvUserDataViewModel> GetAllDataForUser(string userId);

        CsvUserDataViewModel GetCsvUserDataItem(int id);

        void UpdateRecord(CsvUserDataViewModel record, string userId);

        void DeleteRecord(int id);
    }
}
