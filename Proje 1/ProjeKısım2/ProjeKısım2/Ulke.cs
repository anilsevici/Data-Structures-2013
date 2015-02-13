using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjeKısım2
{
    class Ulke
    {

        private int UlkeKontenjan;// ülkenin kontenjan sayısı
        private string isim;//Ülkenin ismi
        private List<Ogrenci> ogrenciList = new List<Ogrenci>();//Ülkeye gidicek olan ögrenciler icin Ogrenci classı tipinden ögrenci listesi

        public int KontenjanSayı
        {
            get { return UlkeKontenjan; }
            set { UlkeKontenjan = value; }
        }

        public string Ulkeİsmi
        {
            get { return isim; }
            set { isim = value; }
        }

        public List<Ogrenci> OgrenciListesi
        {
            get { return ogrenciList; }
            set { ogrenciList = value; }
        }



    }
}
