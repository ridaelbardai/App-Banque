using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanqueLibdll
{
    public abstract class Transaction
    {
        static long incr = 0;
        readonly long num = ++incr;
        DateTime date;
        Devise montant;
        Compte compte;
        public Transaction(Devise Value, Compte compte)
        {
            montant = Value;
            this.compte = compte;
            date = DateTime.Now;
        }

        public virtual void detailsTransac()
        {

            Console.WriteLine("\n\t\tDate : "+ date );
            Console.WriteLine("\t\tTransaction num: "+ num);
            Console.Write("\t\tMontant de l'op :" );montant.afficher();
            Console.WriteLine("\n\t\t---------------------\n");
        }

        protected string Montant()
        {
            return montant.ToString();
        }
    }


}
