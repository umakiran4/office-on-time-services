using System;
using System.Collections.Generic;
using System.Diagnostics;
using CabAgeDataModel.GenericRepository;
using System.Data.Entity.Validation;
using System.Linq;

namespace CabAgeDataModel.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private CabAgeEntities context = null;
        private GenericRepository<CategoryMaster> categoryMasterRepository;
        private GenericRepository<EmployeeMaster> employeeMasterRepository;
        private GenericRepository<EmployeeLocation> employeeLocationRepository;
        private GenericRepository<EmployeeSurveyResult> employeeSurveyRepository;

        private bool disposed = false;

        public UnitOfWork()
        {
            context = new CabAgeEntities();
        }

        public GenericRepository<CategoryMaster> CategoryMasterRepository
        {
            get {
                return categoryMasterRepository ??
                       (categoryMasterRepository = new GenericRepository<CategoryMaster>(context));
            }
        }

        public GenericRepository<EmployeeMaster> EmployeeMasterRepository
        {
            get
            {
                return employeeMasterRepository ??
                       (employeeMasterRepository = new GenericRepository<EmployeeMaster>(context));
            }
        }


        public GenericRepository<EmployeeLocation> EmployeeLocationRepository
        {
            get
            {
                return employeeLocationRepository ??
                       (employeeLocationRepository = new GenericRepository<EmployeeLocation>(context));
            }
        }


        public GenericRepository<EmployeeSurveyResult> EmployeeSurveyRepository
        {
            get
            {
                return employeeSurveyRepository ??
                       (employeeSurveyRepository = new GenericRepository<EmployeeSurveyResult>(context));
            }
        }



        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    outputLines.AddRange(eve.ValidationErrors.Select(ve => string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage)));
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
    }
}
