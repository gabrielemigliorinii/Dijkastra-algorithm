using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkastraAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[,]
            {
                {0,1,-1,-1,-1,3},
                {1,0,3,-1,5,1},
                {-1,3,0,2,-1,-1},
                {-1,-1,2,0,1,6},
                {-1,5,-1,1,0,2},
                {3,1,-1,6,2,0}
            };

            DATA.Set(graph);
            Solution st = Algorithm.Dijkstra(DATA.Nodes, "A", "D");

            st.Show();
            Console.ReadKey();
    
            /*
            int[] array = { 4, 533, 226, 24, 32, 2, 3, 5, 4 };

            Algorithm.Quicksort(array, 0, array.Length-1);

            foreach (var x in array)
                Console.WriteLine(x);
            */
            
        }
    }
}
