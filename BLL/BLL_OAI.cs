using BO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BLL_OAI
    {

        #region "Connection"
        private static string URL_SERVICE = "http://user07.2isa.org/Dept.svc";
        private static RestClient Client = new RestClient(URL_SERVICE);
        #endregion "Connection"

        #region "Departement"
        /// <summary>
        /// Récuperation de  tous les départements de la base de données
        /// </summary>
        /// <returns>Liste de tous les départements</returns>
        public static List<BO_Departement> GetAllDept()
        {
            List<BO_Departement> departements = new List<BO_Departement>();
            RestRequest request = new RestRequest("Departements", Method.GET);
            IRestResponse<List<BO_Departement>> response = Client.Execute<List<BO_Departement>>(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                departements = response.Data;
            }
            return departements;
            
        }
        /// <summary>
        /// Récupération du département de la liste des départements selon son numéro
        /// </summary>
        /// <param name="deptno"></param>
        /// <returns>un departement</returns>
        public static BO_Departement GetDeptByDeptno(int deptno)
        {
            return GetAllDept().Find(x => x.Deptno == deptno);
        }

        #endregion "Departement"

        #region "Employes"

        /// <summary>
        /// Récupération de tous les employés de la base de données
        /// </summary>
        /// <returns>Liste de tous les employés</returns>
        public static List<BO_Employe> GetAllEmp()
        {
            List<BO_Employe> employes = new List<BO_Employe>();
            RestRequest request = new RestRequest("Employes", Method.GET);
            IRestResponse<List<BO_Employe>> response = Client.Execute<List<BO_Employe>>(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                employes = response.Data;
            }
            return employes;
        }

        public static List<BO_Employe> GetEmpByDeptno(int deptno)
        {
            List<BO_Employe> employes = new List<BO_Employe>();
            RestRequest request = new RestRequest("Employes/{deptno}", Method.GET);
            request.AddParameter("deptno", deptno, ParameterType.UrlSegment);
            IRestResponse<List<BO_Employe>> response = Client.Execute<List<BO_Employe>>(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                employes = response.Data;
            }
            return employes;
        }

        /// <summary>
        /// Récuperation du nombre d'employés selon le numéro de département
        /// </summary>
        /// <param name="deptno"></param>
        /// <returns>Liste d'employés</returns>
        public static int NbEmployeByDept(int deptno)
        {
            int retour = 0;
            RestRequest request = new RestRequest("Employes/nbr/{deptno}", Method.GET);
            request.AddParameter("deptno", deptno.ToString(), ParameterType.UrlSegment);
            IRestResponse<int> response = Client.Execute<int>(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                retour = response.Data;
            }
            return retour;
        }
        
        public static int UpdateEmp(BO_Employe newEmploye)
        {
            int retour = 0;
            RestRequest request = new RestRequest("UpdateEmp", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(newEmploye);
            IRestResponse<int> response = Client.Execute<int>(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                retour = response.Data;
            }
            return retour;
        }

        #endregion "Employe"
        //public static Consommable ExecuteRequest(RestRequest request, List<Consommable> consommable)
        //{
        //    if (consommable is List<BO_Departement>)
        //    {
        //        IRestResponse<List<BO_Departement>> response = Client.Execute<List<BO_Departement>>(request);
        //        if (response.ResponseStatus == ResponseStatus.Completed)
        //        {
        //            consommable = response.Data;
        //        }
        //    }
        //    else if (consommable is List<BO_Employe>)
        //    {
        //        IRestResponse<List<BO_Employe>> response = Client.Execute<List<BO_Employe>>(request);
        //        if (response.ResponseStatus == ResponseStatus.Completed)
        //        {
        //            consommable = response.Data;
        //        }
        //    }
        //    else if (consommable is BO_Nombre)
        //    {
        //        BO_Nombre nombre = (BO_Nombre)consommable;
        //        IRestResponse<int> response = Client.Execute<int>(request);
        //        if (response.ResponseStatus == ResponseStatus.Completed)
        //        {
        //            nombre.Nombre = response.Data;
        //            consommable = nombre;
        //        }
        //    }
        //    return consommable;
        //}
    }
}
