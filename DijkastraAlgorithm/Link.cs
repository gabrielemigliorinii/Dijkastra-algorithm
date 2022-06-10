using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkastraAlgorithm
{
    class Link
    {
        int w;
        Node n1, n2;

        public int Weight { get => w; }
        public Node[] Nodes { get => new Node[] { n1, n2 }; }

        public Link(int w, Node n1, Node n2)
        {
            this.w = w;
            this.n1 = n1;
            this.n2 = n2;
        }

        public static int GetWeight(Node n1, Node n2)
        {
            if (Node.Adjacents(n1, n2))
                return DATA.Graph[DATA.IndexOf(n1.ID), DATA.IndexOf(n2.ID)];
            return -1;
        }
    }
}
