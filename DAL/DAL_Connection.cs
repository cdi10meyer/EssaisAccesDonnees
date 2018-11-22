using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class DAL_Connection
    {
        public static SqlConnection SqlConnection = new SqlConnection(Properties.Resources.ChaineConnection);
        public static string SqlMessage;

        public static SqlCommand CreateConnection()
        {
            SqlCommand objSelectCommand = new SqlCommand();
            try
            {
                
                SqlConnection cmd = new SqlConnection(Properties.Resources.ChaineConnection);
                objSelectCommand.Connection = cmd;
                SqlMessage = "Connection ok";
                return objSelectCommand;
            }
            catch(SqlException e)
            {
                SqlMessage = e.Message;
                return objSelectCommand;
            }
        }
        
    }
}
