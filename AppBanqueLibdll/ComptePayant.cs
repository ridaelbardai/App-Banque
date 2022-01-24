using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanqueLibdll
{
    public class ComptePayant : Compte
    {
        public ComptePayant(Devise D) : base(D) { }
        public override bool debiter(Devise D)
        {
            if (!base.debiter(D)) return false;
            base.debiter_direct(D);
            return true;
        }
        public override void crediter(Devise M)
        {
            base.crediter(M);
            this.debiter_direct(M);
        }
    }
}
