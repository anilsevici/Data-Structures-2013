using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjeKısım2
{
    class Program
    {
        static Random r = new Random();//Random sınıfından nesne
        static void Main(string[] args)
        {
            List<Ulke> ulkelist = new List<Ulke>();
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            Console.Write("Ulkelerin Kontenjanını kullanıcıdan almak icin 1 rastgele almak icin 2 ye basınız:");
            int secenek = SayıAl(1, 2);

            KontenjanAl(secenek, ulkelist);
            OgrenciKontenjanAl(ogrenciler);
            yerlestir(ogrenciler, ulkelist);

            Console.ReadLine();
        }

        public static int SayıAl(int min, int max)//İstenilen aralikta sayı alıp o sayıyı döndürür.Tryparse methodu ile string girişine izin vermez.
        {
            int sayı = 0;
            while (!int.TryParse(Console.ReadLine(), out sayı) || sayı < min || sayı > max)
            {
                Console.Write("Yanlış giriş yaptınız, tekrar deneyiniz: ");
            }
            return sayı;
        }

        public static void KontenjanAl(int se, List<Ulke> ulist)
        {
            List<string> ulkeisim = new List<string>() { "ENG", "GER", "FRE", "ITA", "ESP", "USA", "JAP", "CHN", "RUS" };
            Ulke u;//Ulke classından nesne üretiliyor

            for (int i = 0; i < 9; i++)
            {
                u = new Ulke();
                if (se == 1)
                {
                    Console.Write("{0} nin kontenjanini giriniz:", ulkeisim[i]);
                    u.KontenjanSayı = SayıAl(0, 10);//Kullanıcıdan kontenjan sayısı alınıyor
                }
                else
                    u.KontenjanSayı = r.Next(0, 11);//Rastgele kontenjan sayısı alınıyor

                u.Ulkeİsmi = ulkeisim[i];//Ülke ismi alınıyor

                if (u.KontenjanSayı != 0)//Kontenjan sıfır ise ülke listine ekleme yapılmıyor
                {
                    if (ulist.Count == 0)//Ülke listesi bossa ekleme yapılıyor
                        ulist.Add(u);
                    else
                    {
                        int yer = 0;
                        while (yer < ulist.Count && u.KontenjanSayı <= ulist[yer].KontenjanSayı)
                            yer++;

                        ulist.Insert(yer, u);//Kontenjanlar büyükten kücüge sıralı olacak bir bicimde araya sona ya da basa ekleme yapılıyor
                    }

                }
            }

        }



        public static void OgrenciKontenjanAl(List<Ogrenci> oList)
        {
            List<string> list = new List<string>() { "ANIL", "ALİ", "HUSEYİN", "TAYFUN", "SERHAT", "YASİN", "YİGİT", "MERİC", "GOKCE", "ERKUT", "MELİH", "SİNEM", "EFE", "EMRE", "AHMET", "UMUT", "ARDA", "BURAK", "ÖMER", "GÖRKEM" };
            List<string> list2 = new List<string>() { "SEVİCİ", "YESİLKANAT", "TOZ", "ÖZTÜRK", "CELİK", "ÖNSÖZ", "AYDIN", "NALBANT", "YARDIMCI", "GÜREN", "YETİS", "SAVAS", "ELMAS", "GUL", "SIMSEK", "DINLER", "KAYA", "KALİC", "MERT", "BENLİ" };

            Console.Write("Basvuran ogrenci sayisini giriniz:");
            int n = SayıAl(1, 150);


            Ogrenci birOgrenci;//Ogrenci classından nesne üretiliyor

            for (int i = 0; i < n; i++)
            {
                birOgrenci = new Ogrenci();
                birOgrenci.Ogrismi = list[r.Next(0, list.Count)] + " " + list2[r.Next(0, list2.Count)];//Ogrencinin adı rastgele listten soyadı rastgele list2 den alınarak iki string birlestiriliyor
                birOgrenci.Ogrnot = r.Next(40, 101);//Ogrencinin notu alınıyor

                if (birOgrenci.Ogrnot >= 60)//Notu 60 ın altında olanlar ogrenci listesine eklenmiyor
                {
                    if (oList.Count == 0)//Ogrenci listesi bossa ekleniyor
                        oList.Add(birOgrenci);
                    else
                    {
                        int yer = 0;
                        while (yer < oList.Count && birOgrenci.Ogrnot <= oList[yer].Ogrnot)
                            yer++;

                        oList.Insert(yer, birOgrenci);//Ogrencinin notlarına göre büyükten kücüge doğru sıralı yerlestirmek icin araya basa ya da sonra yerlestiriliyor.
                    }
                }
            }

        }


        public static void yerlestir(List<Ogrenci> ogrList, List<Ulke> ukList)
        {
            double min;
            int indeks = 0, toplam = 0;

            for (int i = 0; i < ukList.Count; i++)
                toplam += ukList[i].KontenjanSayı;//Bütün ülkelerin toplam kontenjan sayısı


            for (int i = 0; i < (ogrList.Count > toplam ? toplam : ogrList.Count); i++)//Ogrenci listesindeki ogrenci sayısı toplam kontenjandan fazla ise kontenjan sayısı kadar değilse azsa ogrenci sayısı kadar döner
            {
                min = 1.0;
                for (int j = 0; j < ukList.Count; j++)//Ülke sayısı kadar döner
                {
                    double minYuzde = (double)ukList[j].OgrenciListesi.Count / ukList[j].KontenjanSayı;//Her ülkenin doluluk yüzdesini hesaplar
                    if (minYuzde < min)
                    {
                        min = minYuzde;
                        indeks = j;
                    }
                }
                ukList[indeks].OgrenciListesi.Add(ogrList[i]);//Minimum yüzde nerede ise oraya öğrenci ekler
            }

            Console.WriteLine();
            for (int i = 0; i < ukList.Count; i++)//Her ülkedeki bilgiler yazdırılıyor.
            {
                Console.WriteLine("{0} ulkesini kazananlar:", ukList[i].Ulkeİsmi);
                Console.WriteLine("Ulkenin Kontenjani {0}", ukList[i].KontenjanSayı);
                for (int j = 0; j < ukList[i].OgrenciListesi.Count; j++)
                    ukList[i].OgrenciListesi[j].yazdır();

                Console.WriteLine("Ogrenci Sayısı {0} ve yuzdesi % {1}", ukList[i].OgrenciListesi.Count, (double)ukList[i].OgrenciListesi.Count * 100 / ukList[i].KontenjanSayı);
                Console.WriteLine();
            }

            if (ogrList.Count == 0)
                Console.WriteLine("Yerlestirilcek ogrenci yoktur!");

            if (ogrList.Count > toplam)
            {
                Console.WriteLine("Yerlesemeyen Ogrenciler");
                for (int i = toplam; i < ogrList.Count; i++)//Yerlesemeyen ogrencilerin bilgileri
                    ogrList[i].yazdır();

                Console.WriteLine("Yerlesemeyen Ogrenci Sayısı {0}", ogrList.Count - toplam);
            }
        }


    }
}
