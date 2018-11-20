using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BO_Departement
    {
        #region "Propriétés d'instance"
        public int Deptno { get; set; }

        public string Dname { get; set; }

        public string Loc { get; set; }
        #endregion "Propriétés d'instance"

        #region "Constructeurs"
        public BO_Departement(int deptno, string dname, string loc)
        {
            this.Deptno = deptno;
            this.Dname = dname.ToUpper();
            this.Loc = loc.ToUpper();
        }

        public BO_Departement()
        {

        }
        #endregion "Constructeurs"

        #region "Méthodes substituées"
        public override string ToString()
        {
            return $"{this.Deptno} => Département: {this.Dname} Localisation: {this.Loc}";
        }
        #endregion "Méthodes substituées"
        
    }
}
