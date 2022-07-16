using System;
using System.Collections.Generic;
using System.Linq;

namespace JoyTeam.Game
{
    public class Graph
    {
        public Vertex[] vertices;

        public Graph(int count)
        {
            vertices = new Vertex[count];
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = new Vertex(i);
            }
        }
        
        public void Connect(int v1,int v2) => vertices[v1].Connect(vertices[v2]);
        
        public Vertex this[int index]
        {
            get => vertices[index];
            set => vertices[index] = value;
        }

        public Edge this[int index , int index1] => vertices[index].Edges[index1];
    }
}
