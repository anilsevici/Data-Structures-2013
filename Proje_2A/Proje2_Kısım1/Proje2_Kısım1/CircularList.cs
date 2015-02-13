using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proje2_Kısım1
{
    class CircularList
    {
        private Otomobil ilk;
        private Otomobil last;

        public CircularList()
        {
            ilk = null;
        }

        public Boolean isEmpty()
        {
            return ilk == null;
        }

        public void insertEnd(String re)//Dairesel listenin sonuna ekleme yapan method
        {
            Otomobil yeni = new Otomobil(re);

            if (isEmpty())
            {
                ilk = yeni;
            }
            else
            {
                Otomobil tp = ilk;
                while (tp.Sonraki != ilk)
                {
                    tp = tp.Sonraki;
                }
                tp.Sonraki=yeni;
            }
            yeni.Sonraki=ilk;

            this.last = yeni;
        }

        public void insertBegin(String re)//Dairesel listenin basına ekleme yapan method
        {
            Otomobil yeni2 = new Otomobil(re);

            if (isEmpty())
            {
                yeni2.Sonraki=yeni2;
            }
            else
            {
                Otomobil tp = ilk;
                while (tp.Sonraki != ilk)
                {
                    tp = tp.Sonraki;
                }
                tp.Sonraki=yeni2;
                yeni2.Sonraki=ilk;
            }
            ilk = yeni2;
        }

        public Otomobil cikart()//Balon problemi icin alınan n degerine gore araba atlandıktan sonra o araba cıkartılır
        {
            Otomobil cikar=null;
            if (!isEmpty())
            {
                if (last.Sonraki == ilk)
                    ilk = ilk.Sonraki;

                cikar = last.Sonraki;

                if (last.Sonraki == last)
                    ilk = null;

                last.Sonraki = last.Sonraki.Sonraki;
            }

            return cikar;
        }

        public void Atla(int n) //Kullanıcıdan alınan n değerine göre balon problemi icin araba atlanir
        {
            int count = 1;
            while (ilk.Sonraki != ilk && count != n)
            {
                count++;
                last = last.Sonraki;
                
            }
        }

        public void yazdir()
        {
            Otomobil etkin = ilk;

            if (!isEmpty())
            {
                do
                {
                    etkin.yazdir();
                    etkin = etkin.Sonraki;
                } while (etkin != ilk);
            }
        }
    }
}
