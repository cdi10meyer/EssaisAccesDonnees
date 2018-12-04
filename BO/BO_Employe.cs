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
    public class BO_Employe: Consommable, IComparable<BO_Employe>
    {
        #region "Propriétés d'instance"

        /// <summary>
        /// 
        /// </summary>
        /// 
        public int Empno { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        public string Nom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BO_Departement Departement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Salaire { get; set; }

        #endregion "Propriétés d'instance"

        #region "Constructeurs"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empno"></param>
        /// <param name="nom"></param>
        /// <param name="deptno"></param>
        /// <param name="job"></param>
        /// <param name="salaire"></param>
        public BO_Employe(int empno,string nom, int deptno, string job, decimal salaire)
        {
            this.Empno = empno;
            this.Nom = nom.ToUpper();
            this.Departement = new BO_Departement();
            this.Departement.Deptno = deptno;
            this.Job = job.ToUpper();
            this.Salaire = salaire;
        }
        /// <summary>
        /// 
        /// </summary>
        public BO_Employe()
        {

        }
        #endregion "Constructeurs"

        #region "Méthodes substituées"
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Nom: {this.Nom} Poste: {this.Job} Salaire: {this.Salaire} N° Departement: {this.Departement.Deptno} ";
        }
        #endregion "Méthodes substituées"

        #region "Méthodes d'interface"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(BO_Employe other)
        {
            int resultat = this.Salaire.CompareTo(other.Salaire) * -1;

            return resultat != 0 ? resultat : this.Nom.CompareTo(other.Nom);
        }
        #endregion "Méthodes d'interface"

    }
}
