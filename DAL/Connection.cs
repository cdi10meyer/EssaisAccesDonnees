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

        public static SqlCommand CreateConnection()
        {
            SqlCommand objSelectCommand = new SqlCommand();
            SqlConnection cmd = new SqlConnection(Properties.Resources.ChaineConnection);
            objSelectCommand.Connection = cmd;
            return objSelectCommand;
        }
        
    }
}
