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
        public DataTable SchemaTable { get; set; }
        public DAL_Employe()
        {
            SchemaTable=this.GetAllEmp();
        }

        public DAL_Employe(int deptno)
        {
            SchemaTable = this.GetEmpByDeptno(deptno);
        }
        public DataTable GetAllEmp()
        {
            SqlCommand objSelectCommand = DAL_Connection.CreateConnection();
            
            objSelectCommand.CommandText = "SELECT * FROM dbo.T_OAI_Emp";
            DataTable schemaTable = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelectCommand);
            objDataAdapter.Fill(schemaTable);
            return schemaTable;
        }

        public  DataTable GetEmpByDeptno(int deptno)
        {
            SqlCommand objSelectCommand = DAL_Connection.CreateConnection();

            objSelectCommand.CommandText = "dbo.P_OAI_GetEmpsByDeptno";
            objSelectCommand.CommandType = CommandType.StoredProcedure;
            objSelectCommand.Parameters.AddWithValue("@DEPTNO", deptno);
            DataTable schemaTable = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelectCommand);
            objDataAdapter.Fill(schemaTable);
            return schemaTable;
        }
        public int UpdateEmp(int empno, string ename)
        {
            SqlCommand objUpdateCommand = DAL_Connection.CreateConnection();
            objUpdateCommand.CommandText = "dbo.P_OAI_UpdateEmp";
            objUpdateCommand.CommandType = CommandType.StoredProcedure;
            objUpdateCommand.Parameters.AddWithValue("@EMPNO", empno);
            objUpdateCommand.Parameters.AddWithValue("@ENAME", ename);
            objUpdateCommand.Connection.Open();
            int nbrLigne = objUpdateCommand.ExecuteNonQuery();
            objUpdateCommand.Connection.Close();
            return nbrLigne;
        }
        public static int GetNbEmp(int deptno)
        {
            SqlCommand objSelectCommand = DAL_Connection.CreateConnection();

            objSelectCommand.CommandText = "dbo.P_OAI_GetNbEmp";
            objSelectCommand.CommandType = CommandType.StoredProcedure;
            objSelectCommand.Parameters.AddWithValue("@DEPTNO", deptno);
            SqlParameter ligne = new SqlParameter("@NB", SqlDbType.Int);
            ligne.Direction = ParameterDirection.Output;
            objSelectCommand.Parameters.Add(ligne);
            objSelectCommand.Connection.Open();
            SqlDataReader reader = objSelectCommand.ExecuteReader();
            int output = Convert.ToInt32(ligne.Value);
            objSelectCommand.Connection.Close();
            return output;
        }
    }
}

