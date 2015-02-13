using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proje_3A
{
    class Sirket
    {
        public List<Heap> is_ilanlari;
        private string sirket_adi;
        private string sirket_adres;
        private string sirket_telefon;
        private string sirket_faks;
        private string sirket_mail;

        public Sirket()
        {
            is_ilanlari = new List<Heap>();
        }

        public string SirketAdi
        {
            get { return sirket_adi; }
            set { sirket_adi = value; }
        }

        public string SirketAdres
        {
            get { return sirket_adres; }
            set { sirket_adres = value; }
        }

        public string SirketTelefon
        {
            get { return sirket_telefon; }
            set { sirket_telefon = value; }
        }


        public string SirketFaks
        {
            get { return sirket_faks; }
            set { sirket_faks = value; }
        }

        public string SirketMail
        {
            get { return sirket_mail; }
            set { sirket_mail = value; }
        }


    }
}
