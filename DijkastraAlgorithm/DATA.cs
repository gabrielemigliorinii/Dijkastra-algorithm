using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkastraAlgorithm
{
    static class DATA
    {
        static int[,] graph = null;
        static Node[] nodes = null;

        public static int[,] Graph { get => graph; }
        public static Node[] Nodes { get => nodes; }

        public static void Set(int[,] __graph)
        {
            graph = __graph;
            int N = graph.GetLength(0);
            nodes = new Node[N];

            for (int i = 65; i < 65 + N; i++)
                nodes[i - 65] = new Node(Convert.ToChar(i).ToString());

            for (int i = 0; i < nodes.Length; i++)
                nodes[i].LoadLinks();
        }

        public static int IndexOf(string value)
        {
            return char.Parse(value.ToUpper()) - 65;
        }

        public static Node GetNode(string value)
        {
            return Array.Find(nodes, n => n.ID == value.ToUpper());
        }
    }
}
