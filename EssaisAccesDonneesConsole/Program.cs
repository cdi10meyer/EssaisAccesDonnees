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
            BLL_ListeEmployes listeEmployes = new BLL_ListeEmployes();
            Console.WriteLine(listeEmployes);
            BLL_ListeDepartements listeDept = new BLL_ListeDepartements();
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
            
            BLL_ListeEmployes listeEmplyeByDeptno = new BLL_ListeEmployes(dept);
            
            Console.WriteLine(listeEmplyeByDeptno);
            Console.WriteLine(BLL_ListeEmployes.NbEmployeParDept(dept));
           

            Console.ReadKey();
        }
    }
}
