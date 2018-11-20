using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BO_Employe:IComparable<BO_Employe>
    {
        #region "Propriétés d'instance"
        public string Nom { get; set; }
        public int Deptno { get; set; }
        public string Job { get; set; }
        public decimal Salaire { get; set; }
        #endregion "Propriétés d'instance"

        #region "Constructeurs"
        public BO_Employe(string nom, int deptno, string job, decimal salaire)
        {
            this.Nom = nom.ToUpper();
            this.Deptno = deptno;
            this.Job = job.ToUpper();
            this.Salaire = salaire;
        }
        public BO_Employe(string nom, int deptno) : this(nom, deptno, "SALESMAN", 1250)
        {

        }
        public BO_Employe()
        {

        }
        #endregion "Constructeurs"

        #region "Méthodes substituées"
        public override string ToString()
        {
            return $"Nom: {this.Nom} Poste: {this.Job} Salaire: {this.Salaire} N° Departement: {this.Deptno} ";
        }
        #endregion "Méthodes substituées"

        #region "Méthodes d'interface"
        public int CompareTo(BO_Employe other)
        {
            int resultat = this.Salaire.CompareTo(other.Salaire) * -1;

            return resultat != 0 ? resultat : this.Nom.CompareTo(other.Nom);
        }
        #endregion "Méthodes d'interface"

    }
}
