using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BO_ListeEmployes
    {
        #region "Propriétés d'instance"
        public List<BO_Employe> Employes { get; set; }
        #endregion "Propriétés d'instance"

        #region "Constructeurs"
        public BO_ListeEmployes()
        {
            Employes = new List<BO_Employe>();
        }
       
        #endregion "Constructeurs"
    }
}
