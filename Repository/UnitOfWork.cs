using Model;
using Repository.Repository;
using Repository.Repository.T4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork
    {
        #region Fields

        private FileMeEntities context = new FileMeEntities();

        #endregion

        #region Constructor

        private BasicRepository _basicRepository;
        private WorkRepository _workRepository;
 

        public BasicRepository basicRepository
        {

            get
            {
                if (this._basicRepository == null)
                {
                    this._basicRepository = new BasicRepository(context);
                }

                return _basicRepository;
            }
        }
        public WorkRepository work_Repository
        {

            get
            {
                if (this._workRepository == null)
                {
                    this._workRepository = new WorkRepository(context);
                }

                return _workRepository;
            }
        }


        #endregion

        #region Methods

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
