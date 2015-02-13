using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proje_3A
{
    class HeapNode
    {
        private double uygunluk;
        private Eleman eleman;

        public double Uygunluk
        {
            get { return uygunluk; }
            set { uygunluk = value; }
        }


        public Eleman Eleman
        {
            get { return eleman; }
            set { eleman = value; }
        }


        public HeapNode(double key, Eleman e)
        {
            uygunluk = key;
            eleman = e;
        }


        // -------------------------------------------------------------
    } // end class HeapNode
    ////////////////////////////////////////////////////////////////
    class Heap
    {
        private string is_tanımı;
        private string aranan_ozellikler;
        private Sirket sirket;

        public string IsTanımı
        {
            get { return is_tanımı; }
            set { is_tanımı = value; }
        }

        public string ArananOzellik
        {
            get { return aranan_ozellikler; }
            set { aranan_ozellikler = value; }
        }

        public Sirket Sirket
        {
            get { return sirket; }
            set { sirket = value; }
        }

        public void ElemanİlanCıkar(Eleman e)
        {
            HeapNode[] oldHeapArray = (HeapNode[])heapArray.Clone();
            heapArray = new HeapNode[maxSize];

            currentSize = 0;
            foreach (HeapNode item in oldHeapArray)
            {
                if (item != null && item.Eleman != e)
                    this.insert(item.Uygunluk, item.Eleman);

            }
        }

        private HeapNode[] heapArray;
        private int maxSize; // size of array
        private int currentSize; // number of HeapNodes in array

        public int MaxSize
        {
            get { return maxSize; }
        }

        public int CurrentSize
        {
            get { return currentSize; }
        }
        // -------------------------------------------------------------
        public Heap(int mx, Sirket s, string is_tanim, string ozellik) // constructor
        {
            is_tanımı = is_tanim;
            aranan_ozellikler = ozellik;
            sirket = s;
            maxSize = mx;
            currentSize = 0;
            heapArray = new HeapNode[maxSize]; // create array
        }
        // -------------------------------------------------------------
        public Boolean isEmpty()
        { return currentSize == 0; }
        // -------------------------------------------------------------
        public Boolean insert(double key, Eleman e)
        {
            if (currentSize == maxSize)
                return false;
            HeapNode newNode = new HeapNode(key, e);
            heapArray[currentSize] = newNode;
            trickleUp(currentSize++);
            return true;
        } // end insert()
        // -------------------------------------------------------------
        public void trickleUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapNode bottom = heapArray[index];
            while (index > 0 &&
           heapArray[parent].Uygunluk < bottom.Uygunluk)
            {
                heapArray[index] = heapArray[parent]; // move it down
                index = parent;
                parent = (parent - 1) / 2;
            } // end while
            heapArray[index] = bottom;
        } // end trickleUp()
        // -------------------------------------------------------------
        public HeapNode remove() // delete item with max key
        { // (assumes non-empty list)
            HeapNode root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            trickleDown(0);
            return root;
        } // end remove()
        // -------------------------------------------------------------
        public void trickleDown(int index)
        {
            int largerChild;
            HeapNode top = heapArray[index]; // save root
            while (index < currentSize / 2) // while HeapNode has at
            { // least one child,
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                // find larger child
                if (rightChild < currentSize && // (rightChild exists?)
                 heapArray[leftChild].Uygunluk <
                heapArray[rightChild].Uygunluk)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                // top >= largerChild?
                if (top.Uygunluk >= heapArray[largerChild].Uygunluk)
                    break;
                // shift child up
                heapArray[index] = heapArray[largerChild];
                index = largerChild; // go down
            } // end while
            heapArray[index] = top; // root to index
        } // end trickleDown()
        // -------------------------------------------------------------
        public Boolean change(int index, HeapNode newValue)
        {
            if (index < 0 || index >= currentSize)
                return false;
            double oldValue = heapArray[index].Uygunluk; // remember old
            heapArray[index].Uygunluk = newValue.Uygunluk;
            heapArray[index].Eleman = newValue.Eleman;// change to new
            if (oldValue < newValue.Uygunluk) // if raised,
                trickleUp(index); // trickle it up
            else // if lowered,
                trickleDown(index); // trickle it down
            return true;
        } // end change()
        // -------------------------------------------------------------
        public void displayHeap()
        {

            Console.WriteLine(String.Format("{0,-30}{1,-8}", "Kişi Adı", "Uygunluk")); ;
            for (int m = 0; m < currentSize; m++)
                if (heapArray[m] != null)
                    Console.WriteLine(String.Format("{0,-30}{1,-8}", heapArray[m].Eleman.KisiAdi, heapArray[m].Uygunluk));

        } // end displayHeap()

        public void displayHeap2()
        {
            Console.WriteLine(String.Format("{0,-11}{1,-20}{2,-12}{3,-21}{4,-17}", "Şirket Adı", "Pozisyon", "Aranan Ozellik", "Başvuran Kişi Sayısı", "Max Kişi Sayısı"));
            Console.WriteLine(String.Format("{0,-11}{1,-20}{2,-15}{3,-21}{4,-17}", Sirket.SirketAdi, IsTanımı, ArananOzellik, CurrentSize, MaxSize));
            Console.WriteLine();
        }
        // -------------------------------------------------------------
    } // end class Heap
    ////////////////////////////////////////////////////////////////
}
