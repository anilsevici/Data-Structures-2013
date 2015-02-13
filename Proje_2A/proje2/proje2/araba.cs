using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proje2
{
    class araba
    {
        static Random rast = new Random();
        public int islemSuresi,no;
        public araba(int n)
        {
            islemSuresi = rast.Next(15,251);
            no = n;
        }
    }
}
