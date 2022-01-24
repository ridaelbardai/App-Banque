using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AppBanqueLibdll
{
    public class Devise
    {
        double valeur;

        public Devise(double valeur)
        {
            this.valeur = valeur;
        }
        public Devise(Devise devise)
        {
            this.valeur = devise.valeur;
        }
      
    
        public static Devise operator +(Devise devise, Devise d)
        {
            return new Devise(devise.valeur + d.valeur);

        }
        public static Devise operator -(Devise devise, Devise d)
        {
            return new Devise(devise.valeur - d.valeur);

        }

        public static Devise operator /(Devise devise, Devise d)
        {
           
            try
            {
                return new Devise(devise.valeur / d.valeur);

            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
            }
            return null;
            
        }
        public static bool operator <=(Devise d1, Devise devise)
        {
            //Debug.Assert(d1.GetType() == devise.GetType());
            return d1.valeur <= devise.valeur;
        }
        public static bool operator >=(Devise d1, Devise devise)
        {
            //Debug.Assert(d1.GetType() == devise.GetType());
            return d1.valeur >= devise.valeur;
        }
        public static Devise operator *(Devise devise, double d)
        {
            return new Devise(devise.valeur * d);
        }
        public static Devise operator *(Devise devise, Devise d)
        {
            return new Devise(devise.valeur * d.valeur);
        }

        public void afficher()
        {
            Console.Write(this.valeur+"\n");
        }




    }
}
