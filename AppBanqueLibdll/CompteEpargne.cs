using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace AppBanqueLibdll
{
    public class CompteEpargne : Compte
    {
        private double tauxInteret;

        public CompteEpargne(Devise s, double t) : base(s)
        {
            Debug.Assert(t > 0 && t <= 100);
            this.tauxInteret = t;
        }

        public void calculInteret()
        {
            double a = this.tauxInteret / 100;
            this.crediter((Interet(a)));
        }
    }
}