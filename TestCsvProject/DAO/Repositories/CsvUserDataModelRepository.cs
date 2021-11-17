using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestCsvProject.Models;
using TestCsvProject.DAO.Interfaces;
using System.Data.Entity;

namespace TestCsvProject.DAO.Repositories
{
    public class CsvUserDataModelRepository : IRepository<CsvUserDataModel>
    {
        private ApplicationDbContext db;
        private IRepository<ApplicationUser> applicationUserRepository;

        public CsvUserDataModelRepository(ApplicationDbContext context, IRepository<ApplicationUser> rep)
        {
            this.db = context;
            applicationUserRepository = rep;
        }

        public void Create(CsvUserDataModel item)
        {
            db.CsvUserDataModels.Add(item);
        }

        public void Delete(int id)
        {
            var model = db.CsvUserDataModels.Find(id);

            if (model != null)
            {
                db.CsvUserDataModels.Remove(model);
            }
        }

        public IEnumerable<CsvUserDataModel> Find(Func<CsvUserDataModel, bool> predicate)
        {
            return this.GetAll().Where(predicate);
        }

        public CsvUserDataModel Get(int id)
        {
            CsvUserDataModel model = db.CsvUserDataModels.Find(id);
            model.User = db.Users.Find(model.User.Id);
            return model;

        }

        public IEnumerable<CsvUserDataModel> GetAll()
        {
            var models = db.CsvUserDataModels;
            var listModels = models.ToList();
            for(int i = 0; i < listModels.Count(); i++)
            {
                listModels[i].User = db.Users.Find(listModels[i].User.Id);
            }
            return listModels;
        }

        public void Update(CsvUserDataModel item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}