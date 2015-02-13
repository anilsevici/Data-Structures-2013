using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace proje2
{
    class oncelikKuyrugu
    {

        public int boyut;
        public List<araba> liste;
        public int toplam;
        public oncelikKuyrugu(int b)
        {
            boyut = b;
            liste = new List<araba>();
        }
        public oncelikKuyrugu()
        {
            liste = new List<araba>();
        }
        public oncelikKuyrugu(oncelikKuyrugu k)
        {
            boyut = k.boyut;
            liste = new List<araba>();
            liste.AddRange(k.listOku());
        }
        public List<araba> listOku()
        {
            return liste;
        }
        public int elemanSayisiOku()
        {
            return liste.Count;
        }
        public void ekle(araba a)
        {
            liste.Add(a);
        }
        public void siraliEkle(araba a)
        {
            int s;
            if (liste.Count == 0) liste.Insert(0, a);
            else
            {
                s = 0;
                while (s < liste.Count && a.islemSuresi >= liste[s].islemSuresi) s++;
                liste.Insert(s, a);
            }
        }
        public araba cikar()
        {
            araba gecici = liste[0];
            liste.RemoveAt(0);
            return gecici;
        }
        public bool bosMu()
        {
            return (liste.Count == 0);
        }
    }
}
