using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proje4B_BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph theGraph = new Graph();
            theGraph.addVertex('A'); // 0 (start for dfs)
            theGraph.addVertex('B'); // 1
            theGraph.addVertex('C'); // 2
            theGraph.addVertex('D'); // 3
            theGraph.addVertex('E'); // 4
            theGraph.addEdge(0, 1); // AB
            theGraph.addEdge(1, 2); // BC
            theGraph.addEdge(0, 3); // AD
            theGraph.addEdge(3, 4); // DE
            Console.Write("Visits: ");
            theGraph.bfs(); // breadth-first search
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}
