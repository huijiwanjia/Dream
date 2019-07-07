
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dream.Model.Api;
using Dream.Util;

namespace Dream.DataAccess
{
    public class DBConnection
    {
        public static SqlConnection Dream
        {
            get
            {
                var connnectionString = ConfigUtil.GetConfig<DataApiAppSettings>("AppSettings").DreamConnectionString;
                var connection = new SqlConnection(connnectionString);
                return connection;
            }
        }
        public static SqlConnection CreateConnection()
        {
            return Dream;
        }
    }
}
