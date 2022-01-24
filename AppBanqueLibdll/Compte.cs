using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanqueLibdll
{
    public class Compte
    {
        static Devise plafond = new MAD(2000);
        static int count = 0;
        private int numcompte = ++count;
        
        Devise solde;
        List<Transaction> historique;


        public Compte(Devise sol)
        {
            this.solde = sol;
            this.historique = new List<Transaction>();
        }
        public virtual bool debiter(Devise M)
        {
            if (solde >= M && M <= plafond)
            {
                solde = solde - M;
                Transaction p = new OperationR(M, this);
                this.historique.Add(p);
                return true;
            }
            return false;
        }

        public virtual void crediter(Devise M)
        {
            solde = solde + M;
           Transaction p = new OperationV(M, this);
            this.historique.Add(p);
        }
        public bool verser(Devise M, Compte C)
        {
            if (M.GetType() == C.solde.GetType())
            {
                if (debiter(M))
                {
                    C.crediter(M);
                    return true;
                }
                return false;
            }
            return false;
        }


        public override string ToString()
        {
            return "numero du compte : " + numcompte + ", Solde :" + solde;
        }

        public void consulter()
        {
            Console.WriteLine("\t num compte =" + numcompte);
            Console.Write("\t Solde =" );solde.afficher();
            Console.WriteLine("************************************");
            afficherhistorique();
        }

        void afficherhistorique()
        {
            foreach (Transaction operation in historique)
            {
                operation.detailsTransac();

            }
        }

        public Devise Interet(double a)
        {

            Devise res = new Devise(a);

            return (this.solde) * (res);
        }

        public bool checkSup(Devise s)
        {
            return ((this.solde) >= s);
        }

        public void debiter_direct(Devise M)
        {
            (this.solde) = (this.solde) - (M * 0.05);
        }
    }
}
