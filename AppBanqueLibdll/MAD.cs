using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanqueLibdll
{
    public class MAD : Devise
    {
   
        public MAD(double valeur) : base(valeur) { }
     
        public override string ToString()
        {
            return base.ToString() + "DH";
        }
    
    }
}
