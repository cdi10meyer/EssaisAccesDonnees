using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Employe
    {
        public static DataTable GetAllEmp()
        {
            SqlCommand objSelectCommand = new SqlCommand();

            SqlConnection cmd = new SqlConnection(Properties.Resources.ChaineConnection);
            cmd.Open();
            objSelectCommand.Connection = cmd;
            objSelectCommand.Connection = cmd;
            objSelectCommand.CommandText = "SELECT * FROM dbo.T_OAI_Emp";
            DataTable schemaTable = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelectCommand);
            objDataAdapter.Fill(schemaTable);
            cmd.Close();
            return schemaTable;
        }

        public static DataTable GetEmpByDeptno(int deptno)
        {
            SqlCommand objSelectCommand = new SqlCommand();

            SqlConnection cmd = new SqlConnection(Properties.Resources.ChaineConnection);
            cmd.Open();
            objSelectCommand.Connection = cmd;
            objSelectCommand.CommandText = "dbo.P_OAI_GetEmpsByDeptno";
            objSelectCommand.CommandType = CommandType.StoredProcedure;
            objSelectCommand.Parameters.AddWithValue("@DEPTNO", deptno);
            DataTable schemaTable = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelectCommand);
            objDataAdapter.Fill(schemaTable);
            cmd.Close();
            return schemaTable;
        }
        public static int GetNbEmp(int deptno)
        {
            SqlCommand objSelectCommand = new SqlCommand();
            SqlConnection cmd = new SqlConnection(Properties.Resources.ChaineConnection);
            cmd.Open();
            objSelectCommand.Connection = cmd;
            objSelectCommand.CommandText = "dbo.P_OAI_GetNbEmp";
            objSelectCommand.CommandType = CommandType.StoredProcedure;
            objSelectCommand.Parameters.AddWithValue("@DEPTNO", deptno);
            SqlParameter ligne = new SqlParameter("@NB", SqlDbType.Int);
            ligne.Direction = ParameterDirection.Output;
            objSelectCommand.Parameters.Add(ligne);
            SqlDataReader reader = objSelectCommand.ExecuteReader();
            int output = Convert.ToInt32(ligne.Value);
            cmd.Close();
            return output;
        }
    }
}
