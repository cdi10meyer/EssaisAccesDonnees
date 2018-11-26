using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BLL_OAI
    {
        #region "Connection"
        public static string SqlMessage = DAL_OAI.SqlMessage;
        #endregion "Connection"

        #region "Departement"
        public static BO_ListeDepartements GetAllDept()
        {
            BO_ListeDepartements departements = new BO_ListeDepartements(); 

            DataTable schemaTable = DAL_OAI.GetAllDept();

            foreach (DataRow row in schemaTable.Rows)
            {
                BO_Departement dept = new BO_Departement();
                dept.Deptno = Convert.ToInt32(row["DEPTNO"]);
                dept.Dname = row["DNAME"].ToString();
                dept.Loc = row["LOC"].ToString();

                departements.Departements.Add(dept);

            }
            return departements;
        }
        public static BO_Departement GetDeptByDeptno(int deptno)
        {
            BO_Departement departement = GetAllDept().Departements.Find(x => x.Deptno == deptno);
            return departement;
        }

        #endregion "Departement"

        #region "Employes"
        public static int NbEmployeByDept(int dept)
        {
            return DAL_OAI.GetNbEmp(dept);
        }

        public static BO_ListeEmployes GetAllEmp()
        {
            DataTable schemaTable = DAL_OAI.GetAllEmp();

           return  CreateListeEmployes(schemaTable);
        }

        public static BO_ListeEmployes GetEmpByDeptno(int deptno)
        {
            DataTable schemaTable = DAL_OAI.GetEmpByDeptno(deptno);

            return CreateListeEmployes(schemaTable);
        }
        public static BO_ListeEmployes CreateListeEmployes(DataTable schemaTable)
        {
            BO_ListeEmployes listeEmployes = new BO_ListeEmployes();
            foreach (DataRow row in schemaTable.Rows)
            {
                BO_Employe employe = new BO_Employe();
                employe.Empno = Convert.ToInt32(row["EMPNO"]);
                employe.Nom = row["ENAME"].ToString();
                employe.Salaire = Convert.ToDecimal(row["SAL"]);
                employe.Departement = GetDeptByDeptno(Convert.ToInt32(row["DEPTNO"])); 
                employe.Job = row["JOB"].ToString();
                listeEmployes.Employes.Add(employe);
                

            }
            return listeEmployes;
        }

        public static int UpdateEmp(int empno, string ename)
        {
            return DAL_OAI.UpdateEmp(empno, ename);
        }

        public static int GetNbEmp(int deptno)
        {
            return DAL_OAI.GetNbEmp(deptno);
        }
        #endregion "Employe"
    }
}
