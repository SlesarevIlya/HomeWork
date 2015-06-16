using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class ArcComponent : AdjacencyMatrix
    {
        List<String> components = new List<String>();
        String line;
        AdjacencyMatrix graph = new AdjacencyMatrix();
        Dictionary<Vertex, bool> painted = new Dictionary<Vertex, bool>();
        private static Int32 maximumCountOfComponents;
        
        public Int32 MaximumCountOfComponents
        {
            get { return maximumCountOfComponents; }
        }

        public ArcComponent(AdjacencyMatrix g)
        {
            graph = g;
            this.components = this.FindComponents();
        }
        
        public List<String> FindComponents()
        {
            List<String> result = new List<String>();
            painted.Clear();
            foreach (var a in graph.Matrix.Keys)
                painted.Add(a, false);

            foreach (var a in graph.Matrix.Keys)
                if (!painted[a])
                {
                    line = "";
                    result.Add(Dfs(a));
                }
            if (result.Count > maximumCountOfComponents)
                maximumCountOfComponents = result.Count;
            return result;
        }

        public String Dfs(Vertex vertex)
        {
            line += vertex.ToString() + " ";
            painted[vertex] = true;
            foreach (var a in graph.Matrix[vertex])
                if (!painted[a])
                {
                    Dfs(a);
                }
            return line;
        }

        public override void AddVertex(Vertex v)
        {
            graph.AddVertex(v);
            components = FindComponents();
        }

        public override void AddEdge(Edge e)
        {
            graph.AddEdge(e);
            components = FindComponents();
        }

        public override void RemoveVertex(Vertex v)
        {
            graph.RemoveVertex(v);
            components = FindComponents();
        }

        public override void RemoveEdge(Edge e)
        {
            graph.RemoveEdge(e);
            components = FindComponents();
        }

        public void PrintComponents()
        {
            for (int i = 0; i < components.Count(); i++)
            {
                foreach (var v in components[i])
                {
                    Console.Write(v);
                }
                Console.WriteLine();
            }
        }

    }
}
