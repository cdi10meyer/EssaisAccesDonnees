using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Employe: IComparable<BLL_Employe>
    {
        public string Nom { get; set; }
        public int Deptno { get; set; }
        public string Job { get; set; }
        public decimal Salaire { get; set; }

        public BLL_Employe(string nom, int deptno, string job, decimal salaire)
        {
            this.Nom = nom.ToUpper();
            this.Deptno = deptno;
            this.Job = job.ToUpper();
            this.Salaire = salaire;
        }
        public BLL_Employe(string nom, int deptno):this(nom,deptno,"SALESMAN",1250)
        {

        }
        public BLL_Employe()
        {

        }
        public override string ToString()
        {
            return $"Nom: {this.Nom} Poste: {this.Job} Salaire: {this.Salaire} N° Departement: {this.Deptno} ";
        }

        public int CompareTo(BLL_Employe other)
        {
            int resultat = this.Salaire.CompareTo(other.Salaire)*-1;

            return resultat != 0 ? resultat : this.Nom.CompareTo(other.Nom);
        }
    }
}
