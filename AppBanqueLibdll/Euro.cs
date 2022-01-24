using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanqueLibdll
{
    public class Euro : Devise
    {
        
        public Euro(double valeur) : base(valeur) { }
       

        public override string ToString()
        {
            return base.ToString() + "€";
        }
       
    }
}
