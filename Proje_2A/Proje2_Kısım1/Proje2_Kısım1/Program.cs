using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Timers;

namespace Proje2_Kısım1
{
    class Program
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            int secim;

            ArrayList otopark = new ArrayList(); 

            Console.Write("Balon problemi icin n degeri giriniz:");
            int n = SayıAl();


            do
            {
                secim = menu();

                switch (secim)
                {
                    case 1:
                        {
                            ekle(otopark);
                            katlar_yazdır(otopark);
                            otomobil_cikart(n, otopark);
                            break;
                        }
                    case 2:
                        {
                            islem_zaman(n);
                            break;
                        }
                }
            } while (secim != 3);

        }

        public static int menu()
        {
            int secim;

            Console.WriteLine("1.Josephus problem");
            Console.WriteLine("2.Bilgisayarın 3 snde cozdugu ortalama otopark problemi");
            Console.WriteLine("3.Cikis");
            Console.Write("Lutfen seciminizi giriniz:");
            secim = SayıAl(1, 3);


            return secim;
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

        public static int SayıAl() //Try catch ile hata yakalayarak yapılmış sayısal methodu string girişine izin vermez.
        {
            bool hatali;
            int sayı = 0;
            do
            {
                hatali = true;
                try
                { 
                    sayı = Int32.Parse(Console.ReadLine());
                    hatali = false;
                }
                catch (FormatException)
                {
                    Console.Write("Yanlış giriş yaptınız, tekrar deneyiniz: ");
                }
            } while (hatali);
            return sayı;
        }

        public static void kuyruk_ekleme(String s, Queue<Otomobil> kat)
        {
            Otomobil o = new Otomobil(s);
            kat.Enqueue(o);
        }

        public static void yıgıt_ekleme(String s, Stack<Otomobil> kat)
        {
            Otomobil o = new Otomobil(s);
            kat.Push(o);
        }

        public static void circular_ekleme(String s, CircularList kat)
        {
            Otomobil o = new Otomobil(s);
            kat.insertEnd(s);
        }

        public static void kuyruk_yazdır(Queue<Otomobil> kuyruk)
        {
            foreach (Otomobil o in kuyruk)
                o.yazdir();
        }

        public static void yıgıt_yazdır(Stack<Otomobil> yıgıt)
        {
            foreach (Otomobil o in yıgıt)
                o.yazdir();
        }

        public static void circular_yazdır(CircularList list)
        {
            list.yazdir();
        }

        public static void ekle(ArrayList katlar)//Tum veri yapılarına 9 adet araba random olarak yerlestirildikten sonra  sirasi ile arrayliste kuyruk,yıgıt,dairesel liste veri yapıları eklenir.
        {
            String[] renk = { "Kirmizi", "Yesil", "Mavi", "Sari", "Mor", "Turuncu", "Pembe", "Gri", "Siyah" };


            Queue<Otomobil> kat_1 = new Queue<Otomobil>();
            Stack<Otomobil> kat_2 = new Stack<Otomobil>();
            CircularList kat_3 = new CircularList();
            katlar.Clear();

            for (int i = 0; i < 9; i++)
            {
                kuyruk_ekleme(renk[r.Next(0,renk.Length)], kat_1);
                yıgıt_ekleme(renk[r.Next(0, renk.Length)], kat_2);
                circular_ekleme(renk[r.Next(0, renk.Length)], kat_3);
            }

            katlar.Add(kat_1);
            katlar.Add(kat_2);
            katlar.Add(kat_3);

        }

        public static void katlar_yazdır(ArrayList katlar_yaz)//Arraylistin icinde bulunan kuyruk,yıgıt,dairesel liste yazdırılır.
        {
            Console.WriteLine("KAT1");
            if (((Queue<Otomobil>)katlar_yaz[0]).Count == 0)
                Console.WriteLine("Katta araba yok");
            kuyruk_yazdır(katlar_yaz[0] as Queue<Otomobil>);
            Console.WriteLine();

            Console.WriteLine("KAT2");
            if (((Stack<Otomobil>)katlar_yaz[1]).Count == 0)
                Console.WriteLine("Katta araba yok");
            yıgıt_yazdır(katlar_yaz[1] as Stack<Otomobil>);
            Console.WriteLine();

            Console.WriteLine("KAT3");
            if (((CircularList)katlar_yaz[2]).isEmpty())
                Console.WriteLine("Katta araba yok");
            circular_yazdır(katlar_yaz[2] as CircularList);
            Console.WriteLine();
        }

        public static void otomobil_cikart(int n, ArrayList katlar_cikart)//Arabalar sadece 1.kattan yani kuyruktan cıkmaktadırlar.Sonra sırası ile yıgıttan bir araba kuyruga dairesel listeden bir arabada yıgıta eklenmektedir.
        {
            Boolean flag = false;
            Otomobil o,son_kalan;
            Queue<Otomobil> kuyruk;
            Stack<Otomobil> yıgıt;
            CircularList list;

            kuyruk = katlar_cikart[0] as Queue<Otomobil>;
            yıgıt = katlar_cikart[1] as Stack<Otomobil>;
            list = katlar_cikart[2] as CircularList;
            son_kalan = yıgıt.Last<Otomobil>();

            Console.WriteLine("Son kalan araba(Yıgıtın en son elemanı):{0}", son_kalan.Renk);

            while (!flag)
            {

                if (kuyruk.Count != 0)
                {
                    o = kuyruk.Dequeue();
                    Console.WriteLine("Otoparktan Cıkan Araba: {0}", o.Renk);
                    katlar_yazdır(katlar_cikart);
                }
                else
                {
                    flag = true;
                }

                if (yıgıt.Count != 0)
                {
                    o = yıgıt.Pop();
                    kuyruk.Enqueue(o);
                }

                if (!list.isEmpty())
                {
                    list.Atla(n);
                    o = list.cikart();
                    yıgıt.Push(o);
                }

                if (kuyruk.Count!=0)
                {
                    Console.WriteLine("\nSonraki tur için bir tuşa basınız.");
                    Console.ReadLine();
                }
            }
            
        }


        public static void otomobil_cikart_test(int n, ArrayList katlar_cikart)//3snde balon problemi icin cikar methodunun girdi ve cıktılardan arındırılmıs yeniden duzenlenmis hali
        {
            Boolean flag = false;
            Otomobil o;
            Queue<Otomobil> kuyruk;
            Stack<Otomobil> yıgıt;
            CircularList list;

            kuyruk = katlar_cikart[0] as Queue<Otomobil>;
            yıgıt = katlar_cikart[1] as Stack<Otomobil>;
            list = katlar_cikart[2] as CircularList;

            while (!flag)
            {

                if (kuyruk.Count != 0)
                    o = kuyruk.Dequeue();
                else
                    flag = true;


                if (yıgıt.Count != 0)
                {
                    o = yıgıt.Pop();
                    kuyruk.Enqueue(o);
                }

                if (!list.isEmpty())
                {
                    list.Atla(n);
                    o = list.cikart();
                    yıgıt.Push(o);
                }
            }
        }

        public static void islem_zaman(int n)//3 snde ne kadar balon problemi cozumu yapabildigini hesaplayan method
        {
            ArrayList test_otopark = new ArrayList();
            int sayac = 0;
            int start, end;

            start = DateTime.Now.Second;
            end = (start+3)%60;

            do
            {
                ekle(test_otopark);
                otomobil_cikart_test(n, test_otopark);


                start = DateTime.Now.Second;
                sayac++;
            } while (start!=end);

            Console.WriteLine("3 snde yapılan balon problemi cozumu {0}",sayac);
        }
    }
}
