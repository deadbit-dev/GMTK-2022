using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Graph
    {
        public Vertex[] vertices;

        public Graph(int Count)
        {
            vertices = new Vertex[Count];
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = new Vertex(i);
            }
        }


        public void Connect(int v1,int v2)
        {
            vertices[v1].Connect(vertices[v2]);
        }
        public Vertex this[int index]
        {
            get
            {
                return vertices[index];
            }
        }

        public Edge this[int index , int index1]
        {
            get
            {
                return vertices[index].Edges[index1];
            }
        }
        public override string ToString()
        {
            return vertices.ToString(); 
        }
    }
}
