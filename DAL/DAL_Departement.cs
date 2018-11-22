using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class DAL_Departement
    {
        public static DataTable GetAllDept()
        {
            SqlCommand objSelectCommand = DAL_Connection.CreateConnection();

            objSelectCommand.CommandText = "SELECT * FROM dbo.T_OAI_Dept";
            DataTable schemaTable = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelectCommand);
            objDataAdapter.Fill(schemaTable);
            return schemaTable;
        }

    }
}
