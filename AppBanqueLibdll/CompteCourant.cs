using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AppBanqueLibdll
{
    public class CompteCourant : Compte
    {
        Devise decouvert;
        public CompteCourant(Devise s, Devise d): base(s)
        {
            Debug.Assert(s >= d);
            this.decouvert = d;
        }

        public override bool debiter(Devise M)
        {
            if (this.checkSup(M+this.decouvert))
            {
                return base.debiter(M);
            }
            return false;
        }
    }
}
