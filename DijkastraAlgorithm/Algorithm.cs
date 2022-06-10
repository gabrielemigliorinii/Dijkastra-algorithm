using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkastraAlgorithm
{
    static class Algorithm
    {
        public static Solution Dijkstra(Node[] __nodes, string _pp, string _end)
        {
            _pp = _pp.ToUpper();
            _end = _end.ToUpper();
            List<Node> __visited = new List<Node>();
            int[,] __dynamicMatrix = new int[DATA.Nodes.Length, 2];
            for (int i = 0; i < DATA.Nodes.Length; i++)
                __dynamicMatrix[i, 0] = __dynamicMatrix[i, 1] = -1;

            Node __pp = DATA.GetNode(_pp);
            Node __end = DATA.GetNode(_end);

            __Dijkstra(__nodes, __pp, __end, __visited, __dynamicMatrix);

            void __Dijkstra(Node[] nodes, Node pp, Node end, List<Node> visited, int[,] dynamicMatrix)
            {
                foreach (Node node in pp.ConnectedNodes())
                {
                    if (visited.Contains(node)) continue;
                    int costo = Link.GetWeight(pp, node);
                    if (dynamicMatrix[Node.GetInt(pp.ID), 0] != -1)
                        costo += dynamicMatrix[Node.GetInt(pp.ID), 0];
                    int index = Node.GetInt(node.ID);
                    if (costo < dynamicMatrix[index, 0] || dynamicMatrix[index, 0] == -1)
                    {
                        dynamicMatrix[index, 0] = costo;
                        dynamicMatrix[index, 1] = Node.GetInt(pp.ID);
                    }
                }
                visited.Add(pp);
                if (visited.Count == nodes.Length) return;
                int min = 0, pos = 0;
                bool done = false;
                for (int i = 0; i < nodes.Length; i++)
                {
                    if (!done) min = dynamicMatrix[i, 0] + 1;
                    if (dynamicMatrix[i, 0] < min && dynamicMatrix[i, 0] != -1 && !visited.Contains(DATA.Nodes[i]))
                    {
                        min = dynamicMatrix[i, 0];
                        pos = i;
                        done = true;
                    }
                }

                __Dijkstra(nodes, DATA.Nodes[pos], end, visited, dynamicMatrix);
            }

            List<string> path = new List<string>();
            string tNode = _end;
            int weight = 0;
            bool w = false;
            while (tNode != _pp)
            {
                path.Add(tNode);
                if (!w) { weight = __dynamicMatrix[Node.GetInt(tNode), 0]; w = !w; }
                tNode = Node.GetChar(__dynamicMatrix[Node.GetInt(tNode), 1]);
            }
            path.Add(_pp);
            path.Reverse();

            return new Solution(path, weight);
        }

        public static void Show(int[,] graph, int I)
        {

            Console.Write("\n\n\n ________________________\n\n");
            Console.Write("      COSTO  PREDEC  \n\n");
            for (int i = 0; i < I; i++)
            {
                Console.Write("   " + Node.GetChar(i));
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(" | ");
                    if (graph[i, j] == -1)
                        Console.Write("    ");
                    else if (j == 1)
                        Console.Write(" " + Node.GetChar(graph[i, j]) + "  ");
                    else
                        Console.Write(" " + graph[i, j] + "  ");
                }
                Console.WriteLine(" | ");

            }
            Console.Write("\n ________________________\n\n\n");

        }

        public static void Quicksort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivot = array[low];
                int i = low - 1;
                int j = high + 1;

                do
                {
                    do i++; while (array[i] < pivot);
                    do j--; while (array[j] > pivot);

                    if (i < j)
                        Algorithm.Swap<int>(ref array[i], ref array[j]);

                } while (i < j);

                Quicksort(array, low, j);
                Quicksort(array, j + 1, high);
            }
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T t = a; a = b; b = t;
        }
    }
}
