using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Departement
    {
        public int Deptno { get; set; }

        public string Dname { get;set; }

        public string Loc { get; set; }

        public BLL_Departement(int deptno, string dname, string loc)
        {
            this.Deptno = deptno;
            this.Dname = dname.ToUpper();
            this.Loc = loc.ToUpper();
        }
        public BLL_Departement()
        {

        }

        public override string ToString()
        {
            return $"{this.Deptno} => Département: {this.Dname} Localisation: {this.Loc}";
        }
    }
}
