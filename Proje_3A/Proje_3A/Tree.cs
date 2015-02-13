using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proje_3A
{

    class Tree
    {

        private Eleman kok;
        public int elemanSay;

        public Tree()
        {
            kok = null;
            elemanSay = 0;
        }

        public Eleman kokCagir() { return kok; }

        public int derinlikBul(Eleman etkin)
        {
            if (etkin == null)
                return -1;
            int lefth = derinlikBul(etkin.sol);
            int righth = derinlikBul(etkin.sag);
            if (lefth > righth)
                return lefth + 1;
            else
                return righth + 1;
        }

        public int dugumSay(Eleman etkin)
        {
            if (etkin != null)
            {
                elemanSay++;
                dugumSay(etkin.sol);
                dugumSay(etkin.sag);
            }
            if (etkin == kok)
                return elemanSay;
            else return 0;

        }

        public void ort90ustu(Eleman etkin)
        {
            if (etkin != null)
            {
                ort90ustu(etkin.sol);
                foreach (EgitimDurumu e in etkin.egitimler)
                    if (e.NotOrtalama > 90)
                    {
                        Console.WriteLine(etkin.KisiAdi);
                        break;
                    }
                ort90ustu(etkin.sag);
            }
        }

        public void ingilizceBilen(Eleman etkin)
        {
            if (etkin != null)
            {
                ingilizceBilen(etkin.sol);
                if (etkin.YabancıDil == "İngilizce")
                    Console.WriteLine(etkin.KisiAdi);
                ingilizceBilen(etkin.sag);
            }
        }

        public void inOrder(Eleman etkin, int d)
        {
            if (etkin != null)
            {
                d = d + 1;
                inOrder(etkin.sol, d);
                Console.WriteLine(" " + etkin.KisiAdi + " " + d + ". düzeyde");
                inOrder(etkin.sag, d);
            }
        }

        public void preOrder(Eleman etkin, int d)
        {
            if (etkin != null)
            {
                d = d + 1;
                Console.WriteLine(" " + etkin.KisiAdi + " " + d + ". düzeyde");
                preOrder(etkin.sol, d);
                preOrder(etkin.sag, d);
            }
        }

        public void postOrder(Eleman etkin, int d)
        {
            if (etkin != null)
            {
                d = d + 1;
                postOrder(etkin.sol, d);
                postOrder(etkin.sag, d);
                Console.WriteLine(" " + etkin.KisiAdi + " " + d + ". düzeyde");
            }
        }

        public void dugumSil(string ad)
        {
            Eleman simdiki = kok, ebeveyn = kok;
            bool solMu = true;
            while (simdiki.KisiAdi != ad)
            {
                ebeveyn = simdiki;
                if (string.Compare(ad, simdiki.KisiAdi) < 0)
                {
                    solMu = true;
                    simdiki = ebeveyn.sol;
                }
                else
                {
                    solMu = false;
                    simdiki = ebeveyn.sag;
                }
                if (simdiki == null)
                { Console.WriteLine("Boyle bir dugum yok!"); return; }
            }
            if (simdiki.sag == null && simdiki.sol == null)
            {
                if (simdiki == kok) kok = null;
                else if (solMu) ebeveyn.sol = null;
                else ebeveyn.sag = null;
            }
            else if (simdiki.sag == null)
            {
                if (simdiki == kok) kok = simdiki.sol;
                else if (solMu) ebeveyn.sol = simdiki.sol;
                else ebeveyn.sag = simdiki.sol;
            }
            else if (simdiki.sol == null)
            {
                if (simdiki == kok) kok = simdiki.sag;
                else if (solMu) ebeveyn.sol = simdiki.sag;
                else ebeveyn.sag = simdiki.sag;
            }
            else
            {
                Eleman successor = getSuccessor(simdiki);
                if (simdiki == kok)
                    kok = successor;
                else if (solMu)
                    ebeveyn.sol = successor;
                else
                    ebeveyn.sag = successor;
                successor.sol = simdiki.sol;
            }
            Console.WriteLine("Dugum silindi.");
        }

        private Eleman getSuccessor(Eleman silinen)
        {
            Eleman successorParent = silinen;
            Eleman successor = silinen;
            Eleman simdiki = silinen.sag;
            while (simdiki != null)
            {
                successorParent = successor;
                successor = simdiki;
                simdiki = simdiki.sol;
            }
            if (successor != silinen.sag)
            {
                successorParent.sol = successor.sag;
                successor.sag = silinen.sag;
            }
            return successor;
        }

        public Eleman dugumBul(string ad)
        {
            Eleman gecici = kok;
            while (gecici.KisiAdi != ad)
            {
                if (string.Compare(ad, gecici.KisiAdi) < 0)
                    gecici = gecici.sol;
                else
                    gecici = gecici.sag;
                if (gecici == null) return null;
            }
            return gecici;
        }

        public void dugumEkle(Eleman eklenen)
        {
            if (kok == null) kok = eklenen;
            else
            {
                Eleman gecici = kok;
                while (true)
                {
                    if (string.Compare(eklenen.KisiAdi, gecici.KisiAdi) < 0)
                    {
                        if (gecici.sol == null)
                        {
                            gecici.sol = eklenen;
                            return;
                        }
                        gecici = gecici.sol;
                    }
                    else
                    {
                        if (gecici.sag == null)
                        {
                            gecici.sag = eklenen;
                            return;
                        }
                        gecici = gecici.sag;
                    }
                }
            }
        }

    }
}
