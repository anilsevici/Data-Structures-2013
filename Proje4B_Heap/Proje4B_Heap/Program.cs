using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proje4B_Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            int value, value2;
            Heap theHeap = new Heap(31); // make a Heap; max size 31
            Boolean success;
            theHeap.insert(70); // insert 10 items
            theHeap.insert(40);
            theHeap.insert(50);
            theHeap.insert(20);
            theHeap.insert(60);
            theHeap.insert(100);
            theHeap.insert(80);
            theHeap.insert(30);
            theHeap.insert(10);
            theHeap.insert(90);
            while (true) // until [Ctrl]-[C]
            {
                Console.Write("Enter first letter of ");

                Console.Write("show, insert, remove, change: ");
                int choice = getChar();
                switch (choice)
                {
                    case 's': // show
                        theHeap.displayHeap();
                        break;
                    case 'i': // insert
                        Console.Write("Enter value to insert: ");
                        value = getInt();
                        success = theHeap.insert(value);
                        if (!success)
                            Console.WriteLine("Can’t insert; heap full");
                        break;
                    case 'r': // remove
                        if (!theHeap.isEmpty())
                            theHeap.remove();
                        else
                            Console.WriteLine("Can’t remove; heap empty");
                        break;
                    case 'c': // change
                        Console.Write("Enter current index of item: ");
                        value = getInt();
                        Console.Write("Enter new key: ");
                        value2 = getInt();
                        success = theHeap.change(value, value2);
                        if (!success)
                            Console.WriteLine("Invalid index");
                        break;
                    default:
                        Console.WriteLine("Invalid entry\n");
                        break;
                } // end switch
            } // end while
        } // end main()
        //-------------------------------------------------------------
        public static char getChar()
        {
            String s = Console.ReadLine();
            return s[0];
        }
        //-------------------------------------------------------------
        public static int getInt()
        {
            String s = Console.ReadLine();
            return Int32.Parse(s);
        }
    }
    //-------------------------------------------------------------
} // end class HeapApp
////////////////////////////////////////////////////////////////


