using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkastraAlgorithm
{
    class Node
    {
        string id;
        Link[] links;

        public string ID { get => id; }
        public Link[] Links { get => links; }

        public Node(string id)
        {
            this.id = id;
        }

        public void LoadLinks()
        {
            List<Link> buffer = new List<Link>();

            int index = DATA.IndexOf(ID);

            for (int i = 0; i < DATA.Nodes.Length; i++)
            {
                if (DATA.Graph[index, i] > 0)
                {
                    int weight = DATA.Graph[index, i];
                    buffer.Add(new Link(weight, DATA.Nodes[index], DATA.Nodes[i]));
                }
            }

            links = buffer.ToArray();
        }

        public Node[] ConnectedNodes()
        {
            List<Node> __nodes = new List<Node>();

            foreach (Node node in DATA.Nodes)
                if (Adjacents(node, this))
                    __nodes.Add(node);

            return __nodes.ToArray();
        }

        public bool Adjacents(Node n)
        {
            return
                n.ID == ID
                &&
                DATA.Graph[DATA.IndexOf(n.ID), DATA.IndexOf(ID)] > 0;
        }

        public static bool Adjacents(Node n1, Node n2)
        {
            return n1.ID != n2.ID && DATA.Graph[DATA.IndexOf(n1.ID), DATA.IndexOf(n2.ID)] > 0;
        }

        public static string GetChar(int num)
        {
            return Convert.ToChar(num + 65).ToString();
        }

        public static int GetInt(string letteral)
        {
            return char.Parse(letteral.ToUpper()) - 65;
        }
    }
}
