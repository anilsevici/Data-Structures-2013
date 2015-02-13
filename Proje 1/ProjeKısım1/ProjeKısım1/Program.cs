using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ProjeKısım1
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            int yil1, yil2, secim;
            int[] ndizi = { 50, 100, 500, 1000 };//N degerlerini tutan dizi


            do
            {
                Console.WriteLine("1.Herhangi iki yıl arasında dogum günü üret");
                Console.WriteLine("2.1995-1997 yılları arasında dogum günü üret");
                Console.WriteLine("3.1996 yılında dogum günü üret");

                Console.Write("Lütfen seciminizi giriniz:");
                secim = SayiAl(1, 3);

                switch (secim)
                {
                    case 1:
                        Console.Write("1.yılı giriniz:");
                        yil1 = SayiAl();
                        Console.Write("2.yılı giriniz:");
                        yil2 = SayiAl();

                        if (yil1 > yil2)//Girilen ilk yıl ikinci yıldan büyükse iki yıl yer degistiriyor.
                        {
                            int temp = yil1;
                            yil1 = yil2;
                            yil2 = temp;

                        }

                        DateTime h1 = new DateTime(yil1, 1, 1);
                        DateTime h2 = new DateTime(yil2, 12, 31);
                        Console.Write("Her deneyi gerceklestirmek icin 1 sadece istatistik icin 2 ye basınız:");
                        secim = SayiAl(1, 2);
                        Console.WriteLine();

                        if (secim == 1)
                            TestBirthDays(ndizi, h1, h2);
                        else
                            yazdır(ndizi, h1, h2);
                        break;
                    case 2:
                        DateTime s = new DateTime(1995, 1, 1);
                        DateTime f = new DateTime(1997, 12, 31);
                        Console.Write("Her deney icin 1 sadece istatistik icin 2 ye basınız:");
                        secim = SayiAl(1, 2);
                        Console.WriteLine();

                        if (secim == 1)
                            TestBirthDays(ndizi, s, f);
                        else
                            yazdır(ndizi, s, f);

                        break;
                    case 3:
                        DateTime tek1 = new DateTime(1996, 1, 1);
                        DateTime tek2 = new DateTime(1996, 12, 31);
                        Console.Write("Her deney icin 1 sadece istatistik icin 2 ye basınız:");
                        secim = SayiAl(1, 2);
                        Console.WriteLine();

                        if (secim == 1)
                            TestBirthDays(ndizi, tek1, tek2);
                        else
                            yazdır(ndizi, tek1, tek2);
                        break;
                }

                Console.Write("Tekrar denemek istiyorsanız 1 e cıkmak icin 2 ye basınız:");
                secim = SayiAl(1, 2);

            } while (secim == 1);

        }

        public static int SayiAl()//Try catch ile hata yakalayarak yapılmış sayıal methodu string girisine izin vermez
        {
            bool hata;
            int sayi = 0;
            do
            {
                hata = true;
                try
                {
                    sayi = Int32.Parse(Console.ReadLine());
                    hata = false;
                }
                catch (FormatException)
                {
                    Console.Write("Yanlıs giris yaptınız tekrar deneyiniz:");
                }
            } while (hata);
            return sayi;
        }

        public static int SayiAl(int min, int max)//Try catch ile hata yakalayarak yapılmış sayıal methodu istenilen aralıkta sayı aldırır string girisine izin vermez
        {
            bool hata;
            int sayi = 0;
            do
            {
                hata = true;

                try
                {
                    sayi = Int32.Parse(Console.ReadLine());

                    if (sayi <= max && sayi >= min)
                        hata = false;
                }
                catch (FormatException)
                {
                    Console.Write("Yanlis giris yaptınız tekar deneyiniz:");
                }
            } while (hata);
            return sayi;
        }

        public static DateTime GetRandomDate(DateTime dtStart, DateTime dtEnd)//İki tarih arasındaki gün sayısını bulur sonra baslangıc tarihinin üstüne gün sayısıyla 0 ile 1.0 arasında rastgele üretilmis double sayıyı carparak ekler.
        {
            int GunSayisi = (dtEnd - dtStart).Days;

            return dtStart.AddDays(rand.NextDouble() * GunSayisi);//Üretilmis tarihi geri dondurur.
        }

        public static DateTime[] GenerateRandomDate(int n, DateTime s, DateTime f)//N adet tarih uretir.Uretilen tarihleri dizide tutar ve diziyi döndurur.
        {
            DateTime[] dtarih = new DateTime[n];

            for (int i = 0; i < n; i++)
            {
                DateTime g = GetRandomDate(s, f);
                dtarih[i] = g;
            }
            return dtarih;
        }

        public static void TestBirthDays(int[] dizi, DateTime s, DateTime f)//Her deneyi yil veya yıllar varsa cakısma tablolarını ve en sonunda istatistik yazdırır
        {
            int[][] dgun = new int[12][];//Jagged Array yaratılıyor
            int[,] istatistik = new int[10, 4];//İstatistik tablosu icin matris yaratılıyor.
            int toplam = 0;//Matrisin sütun toplamı icin gerekli olan degisken

            for (int n = 0; n < 4; n++)//N sayisi kadar döner
            {

                for (int deney = 0; deney < 10; deney++)//Deney sayisi kadar döner
                {
                    DateTime[] a = GenerateRandomDate(dizi[n], s, f);
                    for (int i = s.Year; i <= f.Year; i++)//Baslangıc tarihinin yılından bitis tarihinin yılına kadar döner
                    {

                        for (int l = 0; l < 12; l++)//Jagged Array icin ay sayısı kadar yaratılıyor
                            dgun[l] = new int[DateTime.DaysInMonth(i, l + 1)];

                        for (int j = 0; j < a.Length; j++)//Her yıl icin ayrı ayrı cakısma tablosu icin ilgili yılın tarihine ekleme yapılıyor
                        {
                            if (a[j].Year == i)
                                dgun[a[j].Month - 1][a[j].Day - 1]++;
                        }


                        Console.WriteLine("Yil:{0}  Deney No:{1} Kisi Sayisi:{2}", i, deney + 1, dizi[n]);
                        Console.Write("{0,-10}", " ");
                        for (int z = 0; z < 31; z++)
                        {
                            if (z < 9)
                                Console.Write("{0}", z + 1 + " ");
                            else
                                Console.Write("{0}", z + 1);
                        }
                        Console.WriteLine();
                        for (int k = 0; k < dgun.Length; k++)//Cakısma tablosu yazdırılıyor
                        {
                            Console.Write(String.Format("{0,-10}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(k + 1) + " "));

                            for (int t = 0; t < dgun[k].Length; t++)
                            {
                                Console.Write("{0}{1}", (dgun[k][t] == 0) ? 0 : dgun[k][t] - 1, t == (dgun[k].Length - 1) ? "" : " ");

                            }

                            Console.WriteLine();
                        }
                        Console.WriteLine();

                        foreach (int[] t in dgun)//İstatistik icin olan matrise cakısma sayıları ekleniyor
                            foreach (int o in t)
                            {
                                if (o > 1)
                                    istatistik[deney, n] += o - 1;
                            }
                    }

                    Console.WriteLine("Bir sonraki deneye gecmek icin herhangi bir tusa basiniz...");
                    Console.ReadKey();
                }
            }


            Console.Write("{0,-14}", " ");
            for (int i = 0; i < dizi.Length; i++)
                Console.Write("n={0,-10}", dizi[i]);

            Console.WriteLine();

            for (int i = 0; i < istatistik.GetLength(0); i++)//İstatistik matrisi yazdırılıyor
            {
                Console.Write("Deney {0,-10}", i + 1);

                for (int j = 0; j < istatistik.GetLength(1); j++)
                {
                    Console.Write("{0,-10}{1}", istatistik[i, j], j == (istatistik.GetLength(0) - 1) ? "" : " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Ortalama {0,-8}", " ");

            for (int i = 0; i < istatistik.GetLength(1); i++)//Ortalama hesaplanıyor
            {
                toplam = 0;
                for (int j = 0; j < istatistik.GetLength(0); j++)
                {
                    toplam += istatistik[j, i];
                }
                Console.Write("{0,-10}", (double)toplam / 10);
            }
            Console.WriteLine();

        }

        public static void yazdır(int[] dizi, DateTime s, DateTime f)//Sadece istatistik yazdırır
        {
            int[][] dgun = new int[12][];
            int[,] istatistik = new int[10, 4];
            int toplam;

            for (int n = 0; n < 4; n++)
            {

                for (int deney = 0; deney < 10; deney++)
                {
                    DateTime[] a = GenerateRandomDate(dizi[n], s, f);

                    for (int i = s.Year; i <= f.Year; i++)
                    {

                        for (int l = 0; l < 12; l++)
                            dgun[l] = new int[DateTime.DaysInMonth(i, l + 1)];

                        for (int j = 0; j < a.Length; j++)
                        {
                            if (a[j].Year == i)
                                dgun[a[j].Month - 1][a[j].Day - 1] += 1;
                        }

                        foreach (int[] t in dgun)
                            foreach (int o in t)
                            {
                                if (o > 1)
                                    istatistik[deney, n] += o - 1;
                            }
                    }

                }
            }
            Console.Write("{0,-14}", " ");
            for (int i = 0; i < dizi.Length; i++)
                Console.Write("n={0,-10}", dizi[i]);

            Console.WriteLine();

            for (int i = 0; i < istatistik.GetLength(0); i++)
            {
                Console.Write("Deney {0,-10}", i + 1);

                for (int j = 0; j < istatistik.GetLength(1); j++)
                {
                    Console.Write("{0,-10}{1}", istatistik[i, j], j == (istatistik.GetLength(0) - 1) ? "" : " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Ortalama {0,-8}", " ");

            for (int i = 0; i < istatistik.GetLength(1); i++)
            {
                toplam = 0;
                for (int j = 0; j < istatistik.GetLength(0); j++)
                {
                    toplam += istatistik[j, i];
                }
                Console.Write("{0,-10}", (double)toplam / 10);
            }
            Console.WriteLine();
        }
    }
}
