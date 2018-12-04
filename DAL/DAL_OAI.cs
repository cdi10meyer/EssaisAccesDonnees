using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [DataContract]
    public class DAL_OAI
    {
        [DataMember]
        public DataTable SchemaTable { get; set; }
        #region "Connection"
        public static string SqlMessage = "Connection ok";

        public static SqlCommand CreateConnection()
        {
            SqlCommand objSelectCommand = new SqlCommand();
            try
            {
                SqlConnection cmd = new SqlConnection();
                cmd.ConnectionString = Properties.Resources.ChaineConnection;
                objSelectCommand.Connection = cmd;
                SqlMessage = "Connection ok";
                return objSelectCommand;
            }
            catch (SqlException e)
            {
                SqlMessage = e.Message;
                return objSelectCommand;
            }
        }
        #endregion "Connection"

        #region "Departement"
        public DataTable GetAllDept()
        {
            SqlCommand objSelectCommand = DAL_OAI.CreateConnection();

            objSelectCommand.CommandText = "SELECT * FROM dbo.T_OAI_Dept";
            SchemaTable = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelectCommand);
            objDataAdapter.Fill(SchemaTable);
            return SchemaTable;
        }

        #endregion "Departement"

        #region "Employes"
        public DataTable GetAllEmp()
        {
            SqlCommand objSelectCommand = DAL_OAI.CreateConnection();

            objSelectCommand.CommandText = "SELECT * FROM dbo.T_OAI_Emp";
            SchemaTable = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelectCommand);
            objDataAdapter.Fill(SchemaTable);
            return SchemaTable;
        }

        public DataTable GetEmpByDeptno(int deptno)
        {
            SqlCommand objSelectCommand = DAL_OAI.CreateConnection();

            objSelectCommand.CommandText = "dbo.P_OAI_GetEmpsByDeptno";
            objSelectCommand.CommandType = CommandType.StoredProcedure;
            objSelectCommand.Parameters.AddWithValue("@DEPTNO", deptno);
            SchemaTable = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelectCommand);
            objDataAdapter.Fill(SchemaTable);
            return SchemaTable;
        }
        public int UpdateEmp(int empno, string ename)
        {
            SqlCommand objUpdateCommand = CreateConnection();
            objUpdateCommand.Connection.Open();
            objUpdateCommand.CommandText = "P_OAI_UpdateEmp";
            objUpdateCommand.CommandType = CommandType.StoredProcedure;
            objUpdateCommand.Parameters.AddWithValue("@EMPNO", empno);
            objUpdateCommand.Parameters.AddWithValue("@ENAME", ename);
            int requete = objUpdateCommand.ExecuteNonQuery();
            objUpdateCommand.Connection.Close();
            return requete;
        }
        public int GetNbEmp(int deptno)
        {
            SqlCommand objSelectCommand = CreateConnection();

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

        #endregion "Employes"
    }
}
