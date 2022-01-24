using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBanqueLibdll;


namespace ConsoleAppBqnaue
{
    class Program
    {
        static void Main(string[] args)
        {
            Client clt1 = new Client("Rida", "EL BARDAI", "AE105550", "login","mdp");
            Compte cmpt1 = new ComptePayant(new Dollar(3000));
            Compte cmpt2 = new ComptePayant(new Dollar(1000));

            clt1.ajouterCompte(cmpt1);
            clt1.ajouterCompte(cmpt2);

            cmpt1.verser(new Dollar(500), cmpt2);

            cmpt1.consulter();
            cmpt2.consulter();

            

            
            Console.ReadKey();
        }
    }
}
