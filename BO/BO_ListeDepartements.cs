using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BO_ListeDepartements: Consommable
    {
        #region "Propriétés d'instance"
        public List<BO_Departement> Departements { get; set; }
        #endregion "Propriétés d'instance"

        #region "Constructeurs"
        public BO_ListeDepartements()
        {
            Departements = new List<BO_Departement>();
        }
        #endregion "Constructeurs"
    }
}
