using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proje_3A
{
    class EgitimDurumu
    {
        private string okulAdi;

        public string OkulAdi
        {
            get { return okulAdi; }
            set { okulAdi = value; }
        }
        private string bolumu;

        public string Bolum
        {
            get { return bolumu; }
            set { bolumu = value; }
        }
        private string baslangicTarihi;

        public string BaslangicTarih
        {
            get { return baslangicTarihi; }
            set { baslangicTarihi = value; }
        }
        private string bitisTarihi;

        public string BitisTarih
        {
            get { return bitisTarihi; }
            set { bitisTarihi = value; }
        }
        private int notOrtalamasi;

        public int NotOrtalama
        {
            get { return notOrtalamasi; }
            set { notOrtalamasi = value; }
        }

    }
}
