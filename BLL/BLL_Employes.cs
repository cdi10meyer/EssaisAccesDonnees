using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using BO;

namespace BLL
{
    public class BLL_Employes
    {
        #region "Propriétés d'instance"
        public List<BO_Employe> Employes { get; set; }
        #endregion "Propriétés d'instance"

        #region "Constructeurs"
        public BLL_Employes()
        {
            Employes = new List<BO_Employe>();
            this.GetAllEmp();
        }
        public BLL_Employes(int deptno)
        {
            Employes = new List<BO_Employe>();
            this.GetEmpByDeptno(deptno);

        }
        #endregion "Constructeurs"

        #region "Méthodes propres à la classe"
        public static int NbEmployeByDept(int dept)
        {
            return DAL_Employe.GetNbEmp(dept);
        }

        public void GetAllEmp()
        {
            DAL_Employe employes = new DAL_Employe();
            DataTable schemaTable = employes.GetAllEmp();

            this.RemplirTable(schemaTable);
        }

        public void GetEmpByDeptno(int deptno)
        {

            DAL_Employe employes = new DAL_Employe();
            DataTable schemaTable = employes.GetEmpByDeptno(deptno);

            this.RemplirTable(schemaTable);
        }
        public void RemplirTable(DataTable schemaTable)
        {
            foreach (DataRow row in schemaTable.Rows)
            {
                string nom = row["ENAME"].ToString();
                decimal salaire = Convert.ToDecimal(row["SAL"]);
                int dept = Convert.ToInt32(row["DEPTNO"]);
                string job = row["JOB"].ToString();
                this.Employes.Add(new BO_Employe(nom, dept, job, salaire));

            }
        }
        #endregion "Méthodes propres à la classe"
    }
}
