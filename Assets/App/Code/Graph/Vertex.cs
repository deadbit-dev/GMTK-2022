using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JoyTeam.Game
{

    public class Vertex
    {
        public int Index;
        public List<Edge> Edges = new List<Edge>();

        public Vertex(int i)
        {
            this.Index = i;
        }

        public void Connect(Vertex otherVertex)
        {
            var newEdge = new Edge(this,otherVertex);
            Edges.Add(newEdge);
        }
    }
}
