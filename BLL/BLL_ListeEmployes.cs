using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace BLL
{
    public class BLL_ListeEmployes
    {
        public List<BLL_Employe> Employes { get; set; }
        public BLL_ListeEmployes(List<BLL_Employe> employes)
        {
            this.Employes = employes;
        }
        public BLL_ListeEmployes()
        {
            Employes = new List<BLL_Employe>();

            DataTable schemaTable = DAL_Employe.GetAllEmp();

            foreach (DataRow row in schemaTable.Rows)
            {
                BLL_Employe employe = new BLL_Employe();
                employe.Nom = row[1].ToString();
                employe.Salaire = Convert.ToDecimal(row[5]);
                employe.Deptno = Convert.ToInt32(row[7]);
                employe.Job = row[2].ToString();
                this.Employes.Add(employe);

            }
        }
        public BLL_ListeEmployes(int deptno)
        {
            Employes = new List<BLL_Employe>();
            
            DataTable schemaTable = DAL_Employe.GetEmpByDeptno(deptno);
            
            foreach (DataRow row in schemaTable.Rows)
            {
                BLL_Employe employe = new BLL_Employe();
                employe.Nom = row[1].ToString();
                employe.Salaire = Convert.ToDecimal(row[2]);
                employe.Deptno = Convert.ToInt32(row[3]);
                employe.Job = row[4].ToString();
                this.Employes.Add(employe);
                
            }
            
        }
        public static int NbEmployeParDept(int dept)
        {
            return DAL_Employe.GetNbEmp(dept);
        }

        public override string ToString()
        {
            Employes.Sort();
            string resultat = "";
            if (Employes.Count != 0)
            {
                foreach (BLL_Employe employe in Employes)
                {
                    resultat += employe.ToString() + Environment.NewLine;
                }
            }
            else
            {
                resultat = "Rien à afficher";
            }
            return resultat;
        }
        
    }
}
