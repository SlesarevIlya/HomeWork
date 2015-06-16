using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    abstract class Graph
    {
        public abstract void AddVertex(Vertex vertex);
        public abstract void AddVertex(Vertex vertex1, Vertex vertex2);
        public abstract void AddVertex(params Vertex[] vertexes);
        public abstract void AddEdge(Edge edge);
        public abstract void AddEdge(Edge edge1, Edge edge2);
        public abstract void AddEdge(params Edge[] edges);
        public abstract void RemoveVertex(Vertex vertex);
        public abstract void RemoveEdge(Edge edge);
    }
}
