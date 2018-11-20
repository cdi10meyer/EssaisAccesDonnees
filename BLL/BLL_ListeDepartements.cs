using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ListeDepartements
    {
        public List<BLL_Departement> Departements { get; set; }
        public BLL_ListeDepartements(List<BLL_Departement> departements)
        {
            this.Departements = departements;
        }
        public BLL_ListeDepartements()
        {
            Departements = new List<BLL_Departement>();

            DataTable schemaTable = DAL_Departement.GetAllDept();

            foreach (DataRow row in schemaTable.Rows)
            {
                BLL_Departement dept = new BLL_Departement();
                dept.Deptno = Convert.ToInt32(row[0]);
                dept.Dname = row[1].ToString();
                dept.Loc = row[2].ToString();

                this.Departements.Add(dept);

            }
        }
        public override string ToString()
        {
            string resultat = "";
            if (Departements.Count != 0)
            {
                foreach (BLL_Departement departement in Departements)
                {
                    resultat += departement.ToString() + Environment.NewLine;
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
