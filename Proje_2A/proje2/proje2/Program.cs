using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace proje2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.Write("N degerini giriniz: ");
            int n = Convert.ToInt32(Console.ReadLine());
            oncelikKuyrugu kuyruk = new oncelikKuyrugu(n);
            kuyrukOlustur(kuyruk);
            oncelikKuyrugu k = new oncelikKuyrugu(kuyruk);
            yazdir(k);
            Console.WriteLine();
            k = new oncelikKuyrugu(kuyruk);
            oncelikKuyrugu gecici = karsilastir(k);
            Console.WriteLine();
            otopark(gecici);
            Console.ReadLine();
        }
        static public void kuyrukOlustur(oncelikKuyrugu kuyruk)
        {
            araba birAraba;
            for (int i = 0; i < kuyruk.boyut; i++)
            {
                birAraba = new araba(i + 1);
                kuyruk.ekle(birAraba);
            }
        }
        static public oncelikKuyrugu karsilastir(oncelikKuyrugu kuyruk)
        {
            int[] beklenenSure = new int[2];
            araba araba1, araba2;
            oncelikKuyrugu k = new oncelikKuyrugu(kuyruk);
            oncelikKuyrugu oKuyruk = new oncelikKuyrugu(kuyruk.elemanSayisiOku());
            while (!k.bosMu())
            {
                araba1 = k.cikar();
                oKuyruk.siraliEkle(araba1);
            }
            oncelikKuyrugu gecici = new oncelikKuyrugu(oKuyruk);
            Console.WriteLine("Oncelik Kuyrugu:\t|Kuyruk:");
            Console.WriteLine("No" + "\t" + "Sure" + "\t" + "Toplam" + "\t" + "|No" + "\t" + "Sure" + "\t" + "Toplam");
            while (!oKuyruk.bosMu())
            {
                araba1 = oKuyruk.cikar();
                araba2 = kuyruk.cikar();
                beklenenSure[0] += araba1.islemSuresi;
                beklenenSure[1] += araba2.islemSuresi;
                oKuyruk.toplam += beklenenSure[0];
                kuyruk.toplam += beklenenSure[1];
                Console.WriteLine(araba1.no + "\t" + araba1.islemSuresi + "\t" + beklenenSure[0] + "\t|" + araba2.no + "\t" + araba2.islemSuresi +
                    "\t" + beklenenSure[1] + "\t" + "fark: " + (beklenenSure[1] - beklenenSure[0]));
            }
            double a = (double)kuyruk.toplam / kuyruk.boyut, b = (double)oKuyruk.toplam / kuyruk.boyut;
            Console.WriteLine("Ort: " + String.Format("{0:0.##}", b) + "\t\t|Ort: " + String.Format("{0:0.##}", a));
            Console.WriteLine("Oncelik kuyrugun toplam bekleme suresi: " + oKuyruk.toplam);
            Console.WriteLine("Normal kuyrugun toplam bekleme suresi: " + kuyruk.toplam);
            Console.WriteLine("Ortalama kazanilan zaman ve yuzdesi: " + (a - b) + " " + String.Format("{0:0.##}", (double)((1 - (b / a)) * 100)) + "%");
            gecici.toplam = oKuyruk.toplam;
            return gecici;
        }
        static public void yazdir(oncelikKuyrugu kuyruk)
        {
            int beklenenSure = 0, toplam = 0;
            araba birAraba;
            Console.WriteLine("Kuyruk: ");
            Console.WriteLine("No" + "\t" + "Sure" + "\t" + "BeklenenSureToplam");
            while (!kuyruk.bosMu())
            {
                birAraba = kuyruk.cikar();
                beklenenSure += birAraba.islemSuresi;
                toplam += beklenenSure;
                Console.WriteLine(birAraba.no + "\t" + birAraba.islemSuresi + "\t" + beklenenSure);
            }
            Console.Write("Ort: ");
            Console.WriteLine(String.Format("{0:0.##}", (double)toplam / kuyruk.boyut));
        }
        static public void otopark(oncelikKuyrugu kuyruk)
        {
            oncelikKuyrugu[] otopark = new oncelikKuyrugu[3];
            for (int i = 0; i < 3; i++)
                otopark[i] = new oncelikKuyrugu();
            int[] beklenenSure = new int[3];
            araba birAraba;
            int elemanSay;
            int kuyrukSure = kuyruk.toplam;
            int min, index = 0;
            while (!kuyruk.bosMu())
            {
                birAraba = kuyruk.cikar();
                min = beklenenSure[index];
                for (int i = 0; i < 3; i++)
                {
                    if (beklenenSure[i] < min)
                    {
                        min = beklenenSure[i];
                        index = i;
                    }
                }
                otopark[index].ekle(birAraba);
                beklenenSure[index] += birAraba.islemSuresi;
            }
            beklenenSure = new int[3];
            int otoparkSure = 0;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Oncelik Kuyrugu: ");
                Console.WriteLine("No" + "\t" + "Sure" + "\t" + "BeklenenSureToplam");
                elemanSay = otopark[i].elemanSayisiOku();
                while (!otopark[i].bosMu())
                {
                    birAraba = otopark[i].cikar();
                    beklenenSure[i] += birAraba.islemSuresi;
                    otopark[i].toplam += beklenenSure[i];
                    Console.WriteLine(birAraba.no + "\t" + birAraba.islemSuresi + "\t" + beklenenSure[i]);
                }
                Console.Write("Ort: ");
                Console.WriteLine(String.Format("{0:0.##}", (double)otopark[i].toplam / elemanSay));
                otoparkSure += otopark[i].toplam;
            }
            Console.WriteLine("Otoparkin toplam bekleme suresi: " + otoparkSure);
            Console.WriteLine("Oncelik kuyrugun toplam bekleme suresi: " + kuyrukSure);
            Console.WriteLine("Kazanc: " + (kuyrukSure - otoparkSure));
        }
    }
}
