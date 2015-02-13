using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjeKısım2
{
    class Ogrenci
    {
        private string Ogrİsim;//Ogrencinin ismi
        private int OgrNot;//Ogrencinin Notu

        public string Ogrismi
        {
            get { return Ogrİsim; }
            set { Ogrİsim = value; }
        }

        public int Ogrnot
        {
            get { return OgrNot; }
            set { OgrNot = value; }
        }

        public void yazdır()
        {
            Console.WriteLine(Ogrİsim + " " + OgrNot);
        }


    }

}
