using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class Connection
    {
        public static SqlConnection SqlConnection = new SqlConnection(Properties.Resources.ChaineConnection);

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(Properties.Resources.ChaineConnection);
        }
        
    }
}
