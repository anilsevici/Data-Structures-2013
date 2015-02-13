using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proje4B_MST
{
    class Edge
    {
        public int srcVert; // index of a vertex starting edge
        public int destVert; // index of a vertex ending edge
        public int distance; // distance from src to dest
        // -------------------------------------------------------------
        public Edge(int sv, int dv, int d) // constructor
        {
            srcVert = sv;
            destVert = dv;
            distance = d;
        }
        // -------------------------------------------------------------
    } // end class Edge
    ////////////////////////////////////////////////////////////////
    class PriorityQ
    {
        // array in sorted order, from max at 0 to min at size-1
        private int SIZE = 20;
        private Edge[] queArray;
        private int size;
        // -------------------------------------------------------------
        public PriorityQ() // constructor
        {
            queArray = new Edge[SIZE];
            size = 0;
        }
        // -------------------------------------------------------------
        public void insert(Edge item) // insert item in sorted order
        {
            int j;
            for (j = 0; j < size; j++) // find place to insert
                if (item.distance >= queArray[j].distance)
                    break;
            for (int k = size - 1; k >= j; k--) // move items up
                queArray[k + 1] = queArray[k];
            queArray[j] = item; // insert item
            size++;
        }
        // -------------------------------------------------------------
        public Edge removeMin() // remove minimum item
        { return queArray[--size]; }
        // -------------------------------------------------------------
        public void removeN(int n) // remove item at n
        {
            for (int j = n; j < size - 1; j++) // move items down
                queArray[j] = queArray[j + 1];
            size--;
        }
        // -------------------------------------------------------------
        public Edge peekMin() // peek at minimum item
        { return queArray[size - 1]; }
        // -------------------------------------------------------------
        public int sizee() // return number of items
        { return size; }
        // -------------------------------------------------------------
        public Boolean isEmpty() // true if queue is empty
        { return (size == 0); }
        // -------------------------------------------------------------
        public Edge peekN(int n) // peek at item n
        { return queArray[n]; }
        // -------------------------------------------------------------
        public int find(int findDex) // find item with specified
        { // destVert value
            for (int j = 0; j < size; j++)
                if (queArray[j].destVert == findDex)
                    return j;
            return -1;
        }
        // -------------------------------------------------------------
    } // end class PriorityQ
    ////////////////////////////////////////////////////////////////
}
