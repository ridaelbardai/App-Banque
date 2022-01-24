using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanqueLibdll
{
    public class OperationR : Transaction
    {
        static string libel = "\t\t\t-- Retrait --";
        public OperationR(Devise Value, Compte compte) : base(Value, compte) { }
        public override void detailsTransac()
        {
            Console.WriteLine(libel);
            base.detailsTransac();
        }
    }
}
