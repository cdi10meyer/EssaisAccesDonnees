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
            SqlCommand objSelectCommand = new SqlCommand();

            SqlConnection cmd = new SqlConnection(Properties.Resources.ChaineConnection);
            cmd.Open();
            objSelectCommand.Connection = cmd;
            objSelectCommand.CommandText = "SELECT * FROM dbo.T_OAI_Dept";
            DataTable schemaTable = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelectCommand);
            objDataAdapter.Fill(schemaTable);
            cmd.Close();
            return schemaTable;
        }

    }
}
