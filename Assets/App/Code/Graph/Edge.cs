using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }


        public Edge(Vertex from,Vertex to)
        {
            From = from;
            To = to;
        }

        public bool IncedentVertex(Vertex vertex)
        {
            return vertex == From || vertex == To;
        }

        public Vertex OtherVertex(Vertex vertex)
        {
            if(vertex == From) return To;
            else if(vertex == To) return From;
            else return null;
        }
    }
}
