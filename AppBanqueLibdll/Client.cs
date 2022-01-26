using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanqueLibdll
{
    public class Client
    {
        public string nom;
        public string prenom;
        public string photo;

        public string  cin, login, passwd;
        private List<Compte> comptes;
        public Client(string nom, string prenom, string cin, string login, string passwd,string photo)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            this.login = login;
            this.passwd = passwd;
            this.photo = photo;
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
