using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkastraAlgorithm
{
    class Solution
    {
        public List<string> path;
        public int weight;

        public Solution(List<string> path, int weight)
        {
            this.path = path;
            this.weight = weight;
        }

        public void Show()
        {
            Console.WriteLine("\n");
            Console.Write(" - Shortest Path: (");
            for (int i = 0; i < path.Count; i++)
                if (i == path.Count - 1)
                    Console.Write(path[i] + ")");
                else
                    Console.Write(path[i] + ",");
            Console.Write(", weight: " + weight);
            Console.WriteLine("\n");
        }
    }
}
