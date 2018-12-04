using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// 
    /// </summary>
    public class BO_ListeEmployes:Consommable
    {
        #region "Propriétés d'instance"
        /// <summary>
        /// 
        /// </summary>
        public List<BO_Employe> Employes { get; set; }
        #endregion "Propriétés d'instance"

        #region "Constructeurs"
        /// <summary>
        /// 
        /// </summary>
        public BO_ListeEmployes()
        {
            Employes = new List<BO_Employe>();
        }
       
        #endregion "Constructeurs"
    }
}
