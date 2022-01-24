using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanqueLibdll
{
    public class OperationV : Transaction
    {
        static string libel = "\t\t\t-- Versement --";
        public OperationV(Devise Value, Compte compte) : base(Value, compte)
        {
        }
        public override void detailsTransac()
        {
            Console.WriteLine(libel);
            base.detailsTransac();

        }
    }
}
