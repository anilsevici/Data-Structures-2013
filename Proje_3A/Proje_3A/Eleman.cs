using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proje_3A
{
    class Eleman
    {
        public List<IsDeneyimi> Isdeneyimleri;
        public List<EgitimDurumu> egitimler;
        public List<Heap> basvurduguIsIlanlari;
        public Eleman sag;
        public Eleman sol;

        public Eleman()
        {
            Isdeneyimleri = new List<IsDeneyimi>();
            egitimler = new List<EgitimDurumu>();
            basvurduguIsIlanlari = new List<Heap>();
        }
        private string kisiAdi;

        public string KisiAdi
        {
            get { return kisiAdi; }
            set { kisiAdi = value; }
        }

        private string elemanAdresi;

        public string ElemanAdres
        {
            get { return elemanAdresi; }
            set { elemanAdresi = value; }
        }
        private string telefon;

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }
        private string uyruk;

        public string Uyruk
        {
            get { return uyruk; }
            set { uyruk = value; }
        }
        private string ePosta;

        public string Mail
        {
            get { return ePosta; }
            set { ePosta = value; }
        }

        private string dogumYeri;

        public string DogumYeri
        {
            get { return dogumYeri; }
            set { dogumYeri = value; }
        }
        private string dogumTarihi;

        public string DogumTarih
        {
            get { return dogumTarihi; }
            set { dogumTarihi = value; }
        }

        private string medeniDurum;

        public string MedeniDurum
        {
            get { return medeniDurum; }
            set { medeniDurum = value; }
        }
        private string yabanciDil;

        public string YabancıDil
        {
            get { return yabanciDil; }
            set { yabanciDil = value; }
        }
        private string ilgiAlanlari;

        public string IlgıAlan
        {
            get { return ilgiAlanlari; }
            set { ilgiAlanlari = value; }
        }
        private string referansOlanKisiler;

        public string ReferansOlanKisiler
        {
            get { return referansOlanKisiler; }
            set { referansOlanKisiler = value; }
        }


        public void yazdir()
        {
            Console.WriteLine("Adı : " + kisiAdi);
            Console.WriteLine("Adresi: " + elemanAdresi);
            Console.WriteLine("Telefonu: " + telefon);
            Console.WriteLine("E-Postasi: " + ePosta);
            Console.WriteLine("Uyruğu: " + uyruk);
            Console.WriteLine("Doğum Yeri: " + dogumYeri);
            Console.WriteLine("Doğum Tarihi: " + dogumTarihi);
            Console.WriteLine("Medeni Durum: " + medeniDurum);
            Console.WriteLine("Yabancı Dil: " + yabanciDil);
            Console.WriteLine("İlgi Alanları: " + ilgiAlanlari);
            Console.WriteLine("Referans olan kişileri: " + referansOlanKisiler);

            Console.WriteLine("Mezun olduğu okullar: ");
            Console.WriteLine(String.Format("{0,-20}{1,-11}{2,-12}{3,-11}{4,-8}", "Adı", "Bölümü", "Bşlngç Yılı", "Bitiş Yılı", "Not Ort"));
            foreach (EgitimDurumu item in egitimler)
                Console.WriteLine(String.Format("{0,-20}{1,-11}{2,-12}{3,-11}{4,-8}", item.OkulAdi, item.Bolum, item.BaslangicTarih, item.BitisTarih, item.NotOrtalama));


            Console.WriteLine("Çalıştığı işyerleri: ");
            if (Isdeneyimleri.Count != 0)
            {
                Console.WriteLine(String.Format("{0,-20}{1,-11}{2,-20}", "Adı", "Adresi", "Pozisyon"));
                foreach (IsDeneyimi item in Isdeneyimleri)
                    Console.WriteLine(String.Format("{0,-20}{1,-11}{2,-20}", item.SirketAd, item.Adres, item.Pozisyon));

            }
            else Console.Write("Daha önce calistigi isyeri yoktur.\n");

            Console.WriteLine("Başvurduğu iş ilanları: ");
            if (basvurduguIsIlanlari.Count != 0)
            {
                foreach (Heap item in basvurduguIsIlanlari)
                    item.displayHeap2();

            }
            else Console.Write("Basvurdugu is ilani bulunmamaktadir.\n");
        }
    }

}


