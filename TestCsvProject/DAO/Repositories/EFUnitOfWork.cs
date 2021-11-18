using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestCsvProject.DAO.Interfaces;
using TestCsvProject.Models;

namespace TestCsvProject.DAO.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;

        private ApplicationUserRepository applicationUserRepository;
        private CsvUserDataModelRepository csvUserDataModelRepository;

        public EFUnitOfWork()
        {
            db = new ApplicationDbContext();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                if (applicationUserRepository == null)
                    applicationUserRepository = new ApplicationUserRepository(db);

                return applicationUserRepository;
            }
        }

        public IRepository<CsvUserDataModel> UserDataModels
        {
            get
            {
                if (csvUserDataModelRepository == null)
                    csvUserDataModelRepository = new CsvUserDataModelRepository(db, applicationUserRepository);

                return csvUserDataModelRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
    }
}