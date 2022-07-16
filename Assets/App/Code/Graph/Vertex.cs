using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Vertex
    {
        public int Number;
        public List<Edge> Edges = new List<Edge>();

        public Vertex(int number)
        {
            Number = number;
        }
        public void Connect(Vertex otherVertex)
        {
            var newEdge = new Edge(this,otherVertex);
            Edges.Add(newEdge);
        }
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
