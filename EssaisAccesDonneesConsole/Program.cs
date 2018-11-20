using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssaisAccesDonneesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BLL_Employes listeEmployes = new BLL_Employes();
            Console.WriteLine(listeEmployes);
            BLL_Departements listeDept = new BLL_Departements();
            Console.WriteLine();
            Console.WriteLine(listeDept);
            int dept =-1;
            Console.WriteLine("Veuillez saisir un N° de Département de la liste ci-dessus");
            string UserInput = Console.ReadLine();
            if (int.TryParse(UserInput, out dept))

                dept = int.Parse(UserInput);

            else

            {

                Console.WriteLine("Le département que vous avez saisi est incorrect ...");

            }
            
            BLL_Employes listeEmplyeByDeptno = new BLL_Employes(dept);
            
            Console.WriteLine(listeEmplyeByDeptno);
            //Console.WriteLine(BLL_Employes.NbEmployeParDept(dept));
           

            Console.ReadKey();
        }
    }
}
