using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Repository.Helper
{
    public class CommonFunctions
    {
        #region web.config region
        public static string GetServerVersion()
        {
            string server_version = WebConfigurationManager.AppSettings["SqlServerVersion"];
            return server_version;
        }


        #endregion
    }
}
