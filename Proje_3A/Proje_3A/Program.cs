using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Proje_3A
{
    class Program
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            Hashtable sirketler = new Hashtable();
            Tree elemanlar = new Tree();
            Eleman BirEleman;

            SirketOku(sirketler);
            ElemanOku(elemanlar);


            int secim, m;
            do
            {
                secim = anaMenu();
                switch (secim)
                {
                    case 1:

                        do
                        {
                            m = Menu1();

                            switch (m)
                            {
                                case 1:
                                    kisiEkle(elemanlar);
                                    Console.WriteLine("Eklenme islemi basari ile gerceklestirilmistir.");
                                    break;
                                case 2:
                                    kisiGuncelle(elemanlar);
                                    break;
                                case 3:
                                    kisiSil(elemanlar);
                                    break;
                                case 4:
                                    IsBasvurma(sirketler, elemanlar);
                                    break;
                            }

                        } while (m != 5);

                        break;
                    case 2:

                        do
                        {
                            m = Menu2();

                            switch (m)
                            {
                                case 1:
                                    YeniSirketEkle(sirketler);
                                    break;
                                case 2:
                                    SirketGuncelleme(sirketler);
                                    break;
                                case 3:
                                    YeniIsIlanıVerme(sirketler);
                                    break;
                                case 4:
                                    IsBasvurularıListele(sirketler);
                                    break;
                                case 5:
                                    UygunElemanIseAl(sirketler);
                                    break;
                                case 6:
                                    IsIlanıGeriCekme(sirketler);
                                    break;
                            }

                        } while (m != 7);

                        break;
                    case 3:

                        do
                        {
                            m = menu3();

                            switch (m)
                            {
                                case 1:
                                    Console.WriteLine("Bilgilerini listelenmek istediginiz kisinin adini giriniz: ");
                                    BirEleman = elemanlar.dugumBul(Console.ReadLine());
                                    if (BirEleman != null)
                                    {
                                        BirEleman.yazdir();
                                    }
                                    else Console.WriteLine("Sistemde gidiginiz ada sahip kisi bulunmadi.");
                                    break;
                                case 2:
                                    elemanlar.ort90ustu(elemanlar.kokCagir());
                                    break;
                                case 3:
                                    elemanlar.ingilizceBilen(elemanlar.kokCagir());
                                    break;
                                case 4:
                                    Console.WriteLine("In order listelenmesi:");
                                    elemanlar.inOrder(elemanlar.kokCagir(), -1);
                                    Console.WriteLine("Post order listelenmesi:");
                                    elemanlar.postOrder(elemanlar.kokCagir(), -1);
                                    Console.WriteLine("Pre order listelenmesi:");
                                    elemanlar.preOrder(elemanlar.kokCagir(), -1);
                                    Console.Write("agacin dugum sayisi: " + elemanlar.dugumSay(elemanlar.kokCagir()));
                                    Console.WriteLine("agacin derinligi: " + elemanlar.derinlikBul(elemanlar.kokCagir()));
                                    break;
                            }

                        } while (m != 5);

                        break;
                }
            } while (secim != 4);
            Console.ReadLine();
        }

        public static void kisiEkle(Tree elemanlar)
        {
            Eleman birKisi = new Eleman();

            Console.WriteLine("Eklenecek kisinin...");
            Console.Write("adi: ");
            birKisi.KisiAdi = Console.ReadLine();
            Console.Write("adresi: ");
            birKisi.ElemanAdres = Console.ReadLine();
            Console.Write("telefon numarasi: ");
            birKisi.Telefon = Console.ReadLine();
            Console.Write("E-postasi: ");
            birKisi.Mail = Console.ReadLine();
            Console.Write("uyrugu: ");
            birKisi.Uyruk = Console.ReadLine();
            Console.Write("dogum yeri: ");
            birKisi.DogumYeri = Console.ReadLine();
            Console.Write("dogum tarihi: ");
            birKisi.DogumTarih = Console.ReadLine();
            Console.Write("medeni durumu: ");
            birKisi.MedeniDurum = Console.ReadLine();
            Console.Write("yabanci dili: ");
            birKisi.YabancıDil = Console.ReadLine();
            Console.Write("ilgili alanlari: ");
            birKisi.IlgıAlan = Console.ReadLine();
            Console.Write("referans olan kisileri: ");
            birKisi.ReferansOlanKisiler = Console.ReadLine();

            Console.Write("daha once çalıştığı işyerlerinin ");
            do
            {
                IsDeneyimi i = new IsDeneyimi();
                Console.Write("adi: ");
                i.SirketAd = Console.ReadLine();
                Console.Write("adresi: ");
                i.Adres = Console.ReadLine();
                Console.Write("pozisyonu: ");
                i.Pozisyon = Console.ReadLine();
                birKisi.Isdeneyimleri.Add(i);
                Console.Write("baska calistigi yer var mi? (evet:1 | hayir:0)");
            } while (SayiAl(1, 0) == 1);

            Console.Write("mezun olduğu okulların ");
            do
            {
                EgitimDurumu e = new EgitimDurumu();
                Console.Write("adi: ");
                e.OkulAdi = Console.ReadLine();
                Console.Write("bolumu: ");
                e.Bolum = Console.ReadLine();
                Console.Write("baslangic yili: ");
                e.BaslangicTarih = Console.ReadLine();
                Console.Write("bitis yili: ");
                e.BitisTarih = Console.ReadLine();
                Console.Write("not ortalamasi: ");
                e.NotOrtalama = Convert.ToInt32(Console.ReadLine());
                birKisi.egitimler.Add(e);
                Console.Write("baska mezun oldugu okul var mi? (evet:1 | hayir:0)");
            } while (SayiAl(1, 0) == 1);

            elemanlar.dugumEkle(birKisi);
        }

        public static void kisiGuncelle(Tree elemanlar)
        {
            Console.WriteLine("Bilgilerini guncellemek istediginiz kisinin adini giriniz: ");
            Eleman birKisi = elemanlar.dugumBul(Console.ReadLine());
            if (birKisi != null)
            {
                Console.WriteLine("Guncellenecek kisinin...");
                Console.Write("telefonu: ");
                birKisi.Telefon = Console.ReadLine();
                Console.Write("E-postasi: ");
                birKisi.Mail = Console.ReadLine();
                Console.Write("medeni durumu: ");
                birKisi.MedeniDurum = Console.ReadLine();

                Console.WriteLine("Guncelleme islemi basari ile gerceklestirilmistir.");
            }
            else Console.WriteLine("Sistemde gidiginiz ada sahip kisi bulunmadi.");
        }

        public static void kisiSil(Tree elemanlar)
        {
            Console.WriteLine("Sistemden silinecek kisinin adini giriniz:");
            Eleman birEleman = elemanlar.dugumBul(Console.ReadLine());

            if (birEleman != null)
            {
                foreach (Heap kisi in birEleman.basvurduguIsIlanlari)
                    kisi.ElemanİlanCıkar(birEleman);//Kisi basvurdugu tüm is ilanlaridan(ilgili heaplerden) cıkartılıyor

                elemanlar.dugumSil(birEleman.KisiAdi);

                Console.WriteLine("Sistemden {0} adlı kisi basariyla silindi", birEleman.KisiAdi);
            }
            else Console.WriteLine("Kisi sistemde kayitli degildir.");
        }

        public static void IsBasvurma(Hashtable sirketler, Tree elemanlar)
        {
            IDictionaryEnumerator enumerator = sirketler.GetEnumerator();
            int indeks = 0;
            List<Heap> SuankiIsIlanlari = new List<Heap>();

            while (enumerator.MoveNext())
            {
                if (((Sirket)enumerator.Value).is_ilanlari != null)
                {
                    foreach (Heap item in ((Sirket)enumerator.Value).is_ilanlari)
                    {
                        SuankiIsIlanlari.Add(item);//Sirketlerin tüm is ilanları heap tipinden generic liste ekleniyor

                        Console.WriteLine("\nindeks:{0}", indeks++);
                        Console.WriteLine();

                        item.displayHeap2();
                    }
                }
            }
            Console.WriteLine();
            Console.Write("Başvurmak istediğiniz ilanın indeksini giriniz: ");
            int basvurulanIndeks = SayiAl(--indeks, 0);

            Console.Write("İşe başvuracak kişinin ismini giriniz: ");
            Eleman bireleman = elemanlar.dugumBul(Console.ReadLine());

            if (bireleman != null)
            {
                if (!bireleman.basvurduguIsIlanlari.Contains(SuankiIsIlanlari[basvurulanIndeks]))//Daha önce bu ise basvuru yapılmıs mı kontrol ediliyor
                {
                    double uygunluk;
                    Console.Write("Uygunluk değerini kendiniz girmek için 0 rastgele üretilmesi için 1 i tuşlayınız: ");
                    int secim = SayiAl(1, 0);
                    if (secim == 0)
                    {
                        Console.Write("0.0-10.0 aralığında bir sayı tuşlayınız: ");
                        uygunluk = sayiAlDouble(10.0, 0.0);
                    }
                    else
                        uygunluk = r.NextDouble() * 10;


                    SuankiIsIlanlari[basvurulanIndeks].insert(uygunluk, bireleman);//Sirketin ilgili is ilanına(Heape) ekleme yapılıyor.
                    bireleman.basvurduguIsIlanlari.Add(SuankiIsIlanlari[basvurulanIndeks]);//Kisinin basvuru yaptıgı is ilanları listesine ekleme yapılıyor
                    Console.WriteLine(bireleman.KisiAdi + " ilana başvurdu.");
                }
                else Console.WriteLine("Kişi daha önce bu ilana başvurmuş.");
            }
            else Console.WriteLine("Kişi sistemde bulunamadı.");

        }

        public static int anaMenu()
        {
            Console.WriteLine("1 İş Başvurusu Yapan Kişilerin Kullanacağı Bölüm.");
            Console.WriteLine("2 Eleman Arayan Şirketlerin Kullanacağı Bölüm.");
            Console.WriteLine("3 Ağaç İşlemleri.");
            Console.WriteLine("4 Çıkış.");
            Console.WriteLine("Seçiminizi giriniz.");
            return SayiAl(4, 1);
        }
        public static int Menu1()
        {
            Console.WriteLine("1 Sisteme kayıt.");
            Console.WriteLine("2 Sistemdeki bilgilerini günleme.");
            Console.WriteLine("3 Sistemden çıkma.");
            Console.WriteLine("4 Sistemdeki bir işe başvurma.");
            Console.WriteLine("5 Ana menüye dön.");
            Console.WriteLine("Seçiminizi giriniz.");
            return SayiAl(5, 1);
        }
        public static int Menu2()
        {
            Console.WriteLine("1 Sisteme kayıt.");
            Console.WriteLine("2 Sistemdeki bilgilerini günleme.");
            Console.WriteLine("3 Yeni bir iş ilanı verme.");
            Console.WriteLine("4 İşe başvuran tüm adayların bilgilerini listeleme.");
            Console.WriteLine("5 En uygun adayı işe alma.");
            Console.WriteLine("6 İş ilanını sistemden kimseyi işe almadan geri çekme.");
            Console.WriteLine("7 Ana menüye dön.");
            Console.WriteLine("Seçiminizi giriniz.");
            return SayiAl(7, 1);
        }
        public static int menu3()
        {
            Console.WriteLine("1 Adından kişi arama, tüm bilgilerini listeleme.");
            Console.WriteLine("2 Not ortalamalarından en az birisi,90’ın üzerinde olan kişilerin adlarının listelenmesi.");
            Console.WriteLine("3 İngilizce bilen kişilerin adlarının listelenmesi.");
            Console.WriteLine("4 İkili arama ağacındaki tüm kişilerin listelenme.");
            Console.WriteLine("5 Ana menüye dön.");
            Console.WriteLine("Seçiminizi giriniz.");
            return SayiAl(5, 1);
        }

        public static void YeniSirketEkle(Hashtable sirketler)
        {
            Sirket srkt = new Sirket();
            Console.WriteLine("Eklenecek işyerinin...");
            Console.Write("Adı: ");
            srkt.SirketAdi = Console.ReadLine();
            Console.Write("Tam Adresini: ");
            srkt.SirketAdres = Console.ReadLine();
            Console.Write("Telefonu: ");
            srkt.SirketTelefon = Console.ReadLine();
            Console.Write("Faks: ");
            srkt.SirketFaks = Console.ReadLine();
            Console.Write("E-Posta: ");
            srkt.SirketMail = Console.ReadLine();
            sirketler.Add(srkt.SirketAdi, srkt);
            Console.WriteLine(srkt.SirketAdi + " isimli şirket sisteme eklendi.");
        }

        public static void SirketGuncelleme(Hashtable sirketler)
        {
            Console.WriteLine("Bilgilerini guncellemek istediginiz sirketin adini giriniz: ");
            Sirket srkt = (Sirket)sirketler[Console.ReadLine()];

            if (srkt != null)
            {
                Console.WriteLine("Guncellenecek sirketin...");
                Console.Write("telefonu: ");
                srkt.SirketTelefon = Console.ReadLine();
                Console.Write("E-postasi: ");
                srkt.SirketMail = Console.ReadLine();
                Console.Write("Faksı: ");
                srkt.SirketFaks = Console.ReadLine();
                Console.Write("Tam Adresi: ");
                srkt.SirketAdres = Console.ReadLine();

                Console.WriteLine("Guncelleme islemi basari ile gerceklestirilmistir.");
            }
            else Console.WriteLine("Sistemde gidiginiz ada sahip sirket bulunmadi.");
        }

        public static void YeniIsIlanıVerme(Hashtable sirketler)
        {
            Console.Write("İş ilanı verecek şirketin adini giriniz: ");
            Sirket srkt = (Sirket)sirketler[Console.ReadLine()];

            if (srkt != null)
            {
                Console.Write("İş ilanı açılan is tanimini giriniz: ");
                string t = Console.ReadLine();
                Console.Write("İs ilanı icin aranan özellikleri giriniz:");
                string o = Console.ReadLine();
                Heap isIlani = new Heap(50, srkt, t, o);
                srkt.is_ilanlari.Add(isIlani);//Sirketin is ilanları listesine ekleme yapılıyor.

                Console.WriteLine("Yeni is ilani basariyla sisteme eklendi!");

            }
            else Console.WriteLine("Şirket sistemde kayıtlı değil.");
        }

        public static void IsBasvurularıListele(Hashtable sirketler)
        {
            Console.Write("İş Basvuruları listelenicek şirketin adini giriniz: ");
            Sirket srkt = (Sirket)sirketler[Console.ReadLine()];

            if (srkt != null)
            {
                if (srkt.is_ilanlari.Count != 0)
                {
                    foreach (Heap basvuru in srkt.is_ilanlari)
                    {
                        basvuru.displayHeap2();//İs ilanı bilgileri
                        basvuru.displayHeap();//Heap dügümlerinde bulunan kisilerin bilgileri
                    }
                }
                else
                    Console.WriteLine("Sirketin is ilanı bulunmamaktadir."); 
            }
            else Console.WriteLine("Şirket sistemde kayıtlı değil!");

        }

        public static void IsIlanıGeriCekme(Hashtable sirketler)
        {
            Console.Write("Is ilani geri cekilicek şirketin adini giriniz: ");
            Sirket srkt = (Sirket)sirketler[Console.ReadLine()];

            if (srkt != null)
            {
                int indeks = 0;

                if (srkt.is_ilanlari.Count != 0)
                {

                    foreach (Heap item in srkt.is_ilanlari)
                    {
                        Console.WriteLine("\nindeks:{0}", indeks++);
                        Console.WriteLine();

                        item.displayHeap2();
                    }


                    Console.Write("Geri cekmek istediginiz ilanın tablodaki indeksini giriniz: ");
                    int basvurulanIndeks = SayiAl(--indeks, 0);

                    while (!srkt.is_ilanlari[basvurulanIndeks].isEmpty())
                    {
                        HeapNode node = srkt.is_ilanlari[basvurulanIndeks].remove();
                        node.Eleman.basvurduguIsIlanlari.Remove(srkt.is_ilanlari[basvurulanIndeks]);//İS ilanı sistemdeki bütün kisilerin basvurdugu is ilanları listesinden cıkartılıyor
                    }

                    srkt.is_ilanlari.RemoveAt(basvurulanIndeks);//İS ilanı Sirketin is ilanları listesinden cıkartılıyor
                    Console.WriteLine("İlan kaldırıldı.");
                }
                else Console.WriteLine("Şirketin sistemde kayıtlı iş ilanı yok.");
            }
            else Console.WriteLine("Şirket sistemde kayıtlı değil.");

        }

        public static void UygunElemanIseAl(Hashtable sirketler)
        {
            Console.Write("Şirketin adını giriniz: ");
            Sirket srk = (Sirket)sirketler[Console.ReadLine()];

            if (srk != null)
            {
                if (srk.is_ilanlari.Count != 0)
                {
                    int indeks = 0;

                    foreach (Heap item in srk.is_ilanlari)
                    {
                        Console.WriteLine("\nindeks:{0}", indeks++);
                        Console.WriteLine();

                        item.displayHeap2();
                    }

                    Console.Write("İşe eleman almak istediğiniz ilanın tablodaki indeksini giriniz: ");
                    int basvurulanIndeks = SayiAl(--indeks, 0);

                    HeapNode node = srk.is_ilanlari[basvurulanIndeks].remove();//Heap dügümündeki kök cıkartılıyor
                    node.Eleman.basvurduguIsIlanlari.Remove(srk.is_ilanlari[basvurulanIndeks]);
                    while (!srk.is_ilanlari[basvurulanIndeks].isEmpty())
                    {
                        HeapNode node2 = srk.is_ilanlari[basvurulanIndeks].remove();
                        node2.Eleman.basvurduguIsIlanlari.Remove(srk.is_ilanlari[basvurulanIndeks]);//İS ilanı sistemdeki bütün kisilerin basvurdugu is ilanları listesinden cıkartılıyor
                    }

                    Console.WriteLine("İşe alınan eleman: " + node.Eleman.KisiAdi);
                    Console.WriteLine("Uygunluk puani: " + node.Uygunluk);

                    srk.is_ilanlari.RemoveAt(basvurulanIndeks);

                    foreach (Heap basvuru_is in node.Eleman.basvurduguIsIlanlari)
                        basvuru_is.ElemanİlanCıkar(node.Eleman);//Kisi yaptıgı diger is basvuruları heaplerinden cıkartılıyor


                }
                else Console.WriteLine("Şirketin sistemde kayıtlı iş ilanı mevcut değil!");

            }
            else Console.WriteLine("Şirket sistemde kayıtlı değil!");
        }


        public static void ElemanOku(Tree elemanlar)//Eleman.txt okunup agaca aktaralıyor
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Environment.CurrentDirectory + @"\eleman.txt");
            string satir;
            string[] stringSeparators = new string[] { "KİŞİ:", "Eleman Adresi", "Telefon", "E-Posta", "\t" };
            string[] stringSeparators2 = new string[] { "OKUL:", "Okul", "Bölüm", "\t" };
            string[] stringSeparators3 = new string[] { "DENEYİM:", "Şirket", "Adres", "Pozisyon", "\t" };
            string[] result;
            Eleman e = null;

            while ((satir = file.ReadLine()) != null)
            {
                if (satir.StartsWith("KİŞİ"))
                {
                    if (e != null)
                        elemanlar.dugumEkle(e);

                    result = satir.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    e = new Eleman();
                    e.KisiAdi = result[0];
                    e.ElemanAdres = result[1];
                    e.Telefon = result[2];
                    e.Uyruk = result[3];
                    e.Mail = result[4];
                    e.DogumYeri = result[5];
                    e.DogumTarih = result[6];
                    e.MedeniDurum = result[7];
                    e.YabancıDil = result[8];
                    e.IlgıAlan = result[9];
                    e.ReferansOlanKisiler = result[10];
                }
                else if (satir.StartsWith("OKUL"))
                {
                    result = satir.Split(stringSeparators2, StringSplitOptions.RemoveEmptyEntries);
                    EgitimDurumu egt = new EgitimDurumu();
                    egt.OkulAdi = result[0];
                    egt.Bolum = result[1];
                    egt.BaslangicTarih = result[2];
                    egt.BitisTarih = result[3];
                    egt.NotOrtalama = Int32.Parse(result[4]);
                    e.egitimler.Add(egt);
                }
                else
                {
                    result = satir.Split(stringSeparators3, StringSplitOptions.RemoveEmptyEntries);
                    IsDeneyimi deneyim = new IsDeneyimi();
                    deneyim.SirketAd = result[0];
                    deneyim.Adres = result[1];
                    deneyim.Pozisyon = result[2];
                    e.Isdeneyimleri.Add(deneyim);
                }


            }
            elemanlar.dugumEkle(e);//Son kisi agaca ekleniyor.

            file.Close();
        }

        public static void SirketOku(Hashtable sirketler)//Sirket.txt okunup hashtablea ekleniyor
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Environment.CurrentDirectory + @"\sirket.txt");
            string satir;
            string[] stringSeparators = new string[] { "İşyeri Adı", "Tam Adresi", "Telefon", "Faks", "E-Posta", "\t", " " };
            string[] result;
            Sirket s;

            while ((satir = file.ReadLine()) != null)
            {
                result = satir.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                s = new Sirket();
                s.SirketAdi = result[0];
                s.SirketAdres = result[1];
                s.SirketTelefon = result[2];
                s.SirketFaks = result[3];
                s.SirketMail = result[4];

                sirketler.Add(s.SirketAdi, s);
            }

            file.Close();
        }

        public static int SayiAl(int ust, int alt)
        {
            int s = 0;
            while (!int.TryParse(Console.ReadLine(), out s) || s > ust || s < alt)
            {
                Console.WriteLine("Yanlış giriş yaptınız, tekrar deneyiniz: ");
            }
            return s;
        }

        public static double sayiAlDouble(double ust, double alt)
        {
            double s = 0;
            while (!double.TryParse(Console.ReadLine(), out s) || s > ust || s < alt)
            {
                Console.WriteLine("Yanlış giriş yaptınız, tekrar deneyiniz: ");
            }
            return s;
        }

    }

}
