using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanqueLibdll
{
    public class Client
    {
        private string nom, prenom, cin, login, passwd;
        private List<Compte> comptes;
        public Client(string nom, string prenom, string cin, string login, string passwd)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            this.login = login;
            this.passwd = passwd;
            comptes = new List<Compte>();
        }

        public void ajouterCompte(Compte se)
        {
            if (comptes.Contains(se)) return;
                comptes.Add(se);
        }

        public override string ToString()
        {
            return "CIN : " + cin + "\nNom :" + nom + "\nPrenom :" + prenom;
        }
    }
}
