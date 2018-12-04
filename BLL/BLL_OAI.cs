using BO;
//using DAL;
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
        public static BO_ListeDepartements GetAllDept()
        {
            
            BO_ListeDepartements departements = new BO_ListeDepartements();
            RestRequest request = new RestRequest("Departements", Method.GET);
            return (BO_ListeDepartements)ExecuteRequest(request, departements);
            //IRestResponse<BO_ListeDepartements> response= Client.Execute<BO_ListeDepartements>(request);
            //if(response.ResponseStatus == ResponseStatus.Completed)
            //{
            //    departements = response.Data;
            //}
            //return departements;
            
        }
        public static BO_Departement GetDeptByDeptno(int deptno)
        {
            BO_Departement departement = GetAllDept().Departements.Find(x => x.Deptno == deptno);
            return departement;
        }

        #endregion "Departement"

        #region "Employes"
        public static int NbEmployeByDept(int deptno)
        {
            BO_Nombre retour = new BO_Nombre();
            RestRequest request = new RestRequest("Employes/nbr/{deptno}", Method.GET);
            request.AddParameter("deptno", deptno.ToString(), ParameterType.UrlSegment);
            return ((BO_Nombre)ExecuteRequest(request, retour)).Nombre;
            //IRestResponse<int> response = Client.Execute<int>(request);
            //if (response.ResponseStatus == ResponseStatus.Completed)
            //{
            //    retour.Nombre = response.Data;
            //}
            //return retour.Nombre;
        }

        public static BO_ListeEmployes GetAllEmp()
        {
            BO_ListeEmployes employes = new BO_ListeEmployes();
            RestRequest request = new RestRequest("Employes", Method.GET);
            return (BO_ListeEmployes)ExecuteRequest(request, employes);
            //IRestResponse<BO_ListeEmployes> response= Client.Execute<BO_ListeEmployes>(request);
            //if(response.ResponseStatus == ResponseStatus.Completed)
            //{
            //    employes = response.Data;
            //}
            //return employes;
        }

        public static BO_ListeEmployes GetEmpByDeptno(int deptno)
        {
            BO_ListeEmployes employes = new BO_ListeEmployes();
            RestRequest request = new RestRequest("Employes/{deptno}", Method.GET);
            request.AddParameter("deptno", deptno, ParameterType.UrlSegment);
            return (BO_ListeEmployes)ExecuteRequest(request, employes);
            //IRestResponse<BO_ListeEmployes> response = Client.Execute<BO_ListeEmployes>(request);
            //if (response.ResponseStatus == ResponseStatus.Completed)
            //{
            //    employes = response.Data;
            //}
            //return employes;
        }
        public static BO_Nombre UpdateEmp(BO_Employe newEmploye)
        {
            BO_Nombre retour = new BO_Nombre();
            //BO_Employe newEmploye = new BO_Employe();
            //newEmploye.Empno = empno;
            //newEmploye.Nom = ename;
            RestRequest request = new RestRequest("UpdateEmp", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(newEmploye);
            return (BO_Nombre)ExecuteRequest(request, retour);
            //IRestResponse<int> response = Client.Execute<int>(request);
            //if (response.ResponseStatus == ResponseStatus.Completed)
            //{
            //    retour.Nombre = response.Data;
            //}

            //return retour.Nombre;
        }

        #endregion "Employe"
        public static Consommable ExecuteRequest(RestRequest request, Consommable consommable)
        {
            if (consommable is BO_ListeDepartements)
            {
                IRestResponse<BO_ListeDepartements> response = Client.Execute<BO_ListeDepartements>(request);
                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    consommable = response.Data;
                }
            }
            else if (consommable is BO_ListeEmployes)
            {
                IRestResponse<BO_ListeEmployes> response = Client.Execute<BO_ListeEmployes>(request);
                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    consommable = response.Data;
                }
            }
            else if (consommable is BO_Nombre)
            {
                IRestResponse<BO_Nombre> response = Client.Execute<BO_Nombre>(request);
                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    consommable = response.Data;
                }
            }
            return consommable;
        }
    }
}
