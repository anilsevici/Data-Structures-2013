using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proje2_Kısım1
{
    class Otomobil
    {
        private String renk;
        private Otomobil next;

       

        public Otomobil(String oto_renk)
        {
            renk = oto_renk;
            next = null;
        }

        public String Renk
        {
            get { return renk; }
            set { renk = value; }
        }

        public Otomobil Sonraki
        {
            get { return next; }
            set { next = value; }
        }

        public void yazdir()
        {
            Console.WriteLine(" "+renk);
        }
    }
}
