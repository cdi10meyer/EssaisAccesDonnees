using DAL;
using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Departements
    {
        #region "Propriétés d'instance"
        public List<BO_Departement> Departements { get; set; }
        #endregion "Propriétés d'instance"

        #region "Constructeurs"
        public BLL_Departements()
        {
            this.GetAllDept();
        }
        #endregion "Constructeurs"

        #region "Méthodes propres à la classe"
        public void GetAllDept()
        {
            Departements = new List<BO_Departement>();

            DataTable schemaTable = DAL_Departement.GetAllDept();

            foreach (DataRow row in schemaTable.Rows)
            {
                BO_Departement dept = new BO_Departement();
                dept.Deptno = Convert.ToInt32(row["DEPTNO"]);
                dept.Dname = row["DNAME"].ToString();
                dept.Loc = row["LOC"].ToString();

                this.Departements.Add(dept);

            }
        }
        #endregion "Méthodes propres à la classe"

    }

}
