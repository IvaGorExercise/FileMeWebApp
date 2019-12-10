using Model;
using Repository.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class WorkRepository
    {
        #region Fields
        internal FileMeEntities _context;
        #endregion

        #region Constructor
        public WorkRepository(FileMeEntities context)
        {
            this._context = context;
        }
        #endregion

        private UnitOfWork _uow = new UnitOfWork();

        public string InsertLogGetPoruka(string originalMessage, string userName)
        {
            FileMeEntities context = new FileMeEntities();

            String returnMessage = String.Empty;
            String errorLogMessage = String.Empty;
            ErrorLog el = new ErrorLog();

            returnMessage = ErrorLogHandle.GetCustomErrorMesage(originalMessage);

            el.UserName = userName;
            el.Date = DateTime.Now;
            el.ErrorText = originalMessage;

            context.ErrorLog.Add(el);
            context.SaveChanges();


            return returnMessage;
        }


    }
}