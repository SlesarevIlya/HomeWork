using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class AdjacencyMatrix : Graph
    {
        internal Dictionary<Vertex, List<Vertex>> Matrix;
        public AdjacencyMatrix()
        {
            this.Matrix = new Dictionary<Vertex, List<Vertex>>();
        }
        
        public AdjacencyMatrix(Dictionary<Vertex, List<Vertex>> dictionary)
        {
            this.Matrix = new Dictionary<Vertex, List<Vertex>>();
            foreach (var a in dictionary)
            {
                this.Matrix.Add(a.Key, new List<Vertex>());
                foreach (var b in a.Value)
                {
                    this.Matrix[a.Key].Add(b);
                }
            }
        }

        public static AdjacencyMatrix operator + (AdjacencyMatrix g1, Vertex vertex)
        {
            AdjacencyMatrix g = new AdjacencyMatrix(g1.Matrix);
            if (vertex != null)
                g.Matrix.Add(vertex, new List<Vertex>());
            return g;
        }

        public static AdjacencyMatrix operator + (Vertex vertex, AdjacencyMatrix g)
        {
            return (g + vertex);
        }

        public static AdjacencyMatrix operator +(AdjacencyMatrix g1, AdjacencyMatrix g2)
        {
            AdjacencyMatrix g = new AdjacencyMatrix(g1.Matrix);
            foreach (var a in g2.Matrix)
                foreach (var b in a.Value)
                {
                    Edge e = new Edge(a.Key.Name, b.Name);
                    g += e;
                }
            return g;
        }

        public static AdjacencyMatrix operator +(AdjacencyMatrix g1, Edge edge)
        {
            AdjacencyMatrix g = new AdjacencyMatrix(g1.Matrix);
            bool FlagStart = false;
            bool FlagFinish = false;
            Vertex begin = new Vertex(edge.Start);
            Vertex end = new Vertex(edge.Finish);
            foreach (var a in g.Matrix)
            {
                if (a.Key.Name == edge.Start)
                {
                    bool flag = false;
                    for (Int32 i = 0; i < a.Value.Count(); i++)
                        if (a.Value[i].Name == edge.Finish)
                        {
                            flag = true;
                            break;
                        }
                    if (!flag)
                        a.Value.Add(end);
                    FlagStart = true;
                }
                else if (a.Key.Name == edge.Finish)
                {
                    bool flag = false;
                    for (Int32 i = 0; i < a.Value.Count(); i++)
                        if (a.Value[i].Name == edge.Start)
                        {
                            flag = true;
                            break;
                        }
                            
                    if (!flag)
                        a.Value.Add(begin);
                    FlagFinish = true;
                }     
            }
            if (!FlagStart)
            {
                g.Matrix.Add(begin, new List<Vertex>());
                g.Matrix[begin].Add(end);
            }
            if (!FlagFinish)
            {
                g.Matrix.Add(end, new List<Vertex>());
                g.Matrix[end].Add(begin);
            }
            return g;
        }

        public static AdjacencyMatrix operator +(Edge edge, AdjacencyMatrix g)
        {
            return (g + edge);
        }

        public static AdjacencyMatrix operator -(AdjacencyMatrix g1, Vertex vertex)
        {
            AdjacencyMatrix g = new AdjacencyMatrix(g1.Matrix);
            foreach (var a in g.Matrix)
            {
                foreach (var b in a.Value)
                    if (b.Name == vertex.Name)
                    {
                        a.Value.Remove(b);
                        break;
                    }
            }
            foreach (var a in g.Matrix.Keys)
                if (a.Name == vertex.Name)
                {
                    g.Matrix.Remove(a);
                    break;
                }
            return g;
        }

        public static AdjacencyMatrix operator -(AdjacencyMatrix g1, Edge edge)
        {
            AdjacencyMatrix g = new AdjacencyMatrix(g1.Matrix);
            foreach (var a in g.Matrix)
            {
                for (Int32 i = 0; i < a.Value.Count; i++)
                    if ((a.Value[i].Name == edge.Start) || (a.Value[i].Name == edge.Finish))
                        a.Value.RemoveAt(i);
            }
            foreach(var a in g.Matrix)
            {
                if (a.Key.Name == edge.Start) 
                {
                    g.Matrix.Remove(a.Key);
                    break;
                } 
            }
            foreach (var a in g.Matrix)
            {
                if (a.Key.Name == edge.Finish)
                {
                    g.Matrix.Remove(a.Key);
                    break;
                }
            }
            return g;
        }

        public static AdjacencyMatrix operator -(AdjacencyMatrix g1, AdjacencyMatrix g2)
        {
            AdjacencyMatrix g = new AdjacencyMatrix(g1.Matrix);
            foreach (var a in g2.Matrix.Keys)
                g -= a;
            return g;
        }
        
        private static IncidenceMatrix ConvertToIncidence(AdjacencyMatrix g)
        {
            var graph = new Dictionary<Vertex, List<Edge>>();
            foreach (var a in g.Matrix)
            {
                List<Edge> List_edges = new List<Edge>();
                foreach (var b in a.Value)
                    List_edges.Add(new Edge(a.Key.Name, b.Name));
                graph.Add(a.Key, List_edges);
            }
            IncidenceMatrix result = new IncidenceMatrix(graph);
            return result;
        }

        public static implicit operator IncidenceMatrix(AdjacencyMatrix g)
        {
            return ConvertToIncidence(g);
        }

        public override void AddVertex(Vertex v)
        {
            AdjacencyMatrix g = this;
            g += v;
            this.Matrix = g.Matrix;
        }

        public override void AddVertex(Vertex v1, Vertex v2)
        {
            AdjacencyMatrix g = this;
            g += v1;
            g += v2;
            this.Matrix = g.Matrix;
        }

        public override void AddVertex(params Vertex[] v)
        {
            AdjacencyMatrix g = this;
            for (Int32 i = 0; i < v.Count(); i++)
                g += v[i];
            this.Matrix = g.Matrix;
        }

        public override void AddEdge(Edge e)
        {
            AdjacencyMatrix g = this;
            g += e;
            this.Matrix = g.Matrix;
        }

        public override void AddEdge(Edge e1, Edge e2)
        {
            AdjacencyMatrix g = this;
            g += e1;
            g += e2;
            this.Matrix = g.Matrix;
        }

        public override void AddEdge(params Edge[] e)
        {
            AdjacencyMatrix g = this;
            for (Int32 i = 0; i < e.Count(); i++)
                g += e[i];
            this.Matrix = g.Matrix;
        }

        public override void RemoveVertex(Vertex v)
        {
            AdjacencyMatrix g = this;
            g -= v;
            this.Matrix = g.Matrix;
        }

        public override void RemoveEdge(Edge e)
        {
            AdjacencyMatrix g = this;
            g -= e;
            this.Matrix = g.Matrix;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            AdjacencyMatrix v = obj as AdjacencyMatrix;
            foreach (var a in this.Matrix)
            {
                Vertex search = new Vertex('-');
                foreach (var b in v.Matrix.Keys)
                    if (b.Name == a.Key.Name)
                    {
                        search = b;
                        break;
                    }

                if (search.Name == '-')
                    return false;
                else
                {
                    foreach (var b in v.Matrix[search])
                        if (!a.Value.Contains(b))
                            return false;
                }
            }

            foreach (var a in v.Matrix)
            {
                Vertex search = new Vertex('-');
                foreach (var b in this.Matrix.Keys)
                    if (b.Name == a.Key.Name)
                    {
                        search = b;
                        break;
                    }

                if (search.Name == '-')
                    return false;
                else
                {
                    foreach (var b in this.Matrix[search])
                        if (!a.Value.Contains(b))
                            return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            Int32 Hash = 0;
            foreach (var a in this.Matrix)
                Hash += a.Value.Count + (Int32)a.Key.Name;
            return Hash / this.Matrix.Count;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var a in this.Matrix)
            {
                result += " : " + a.Key.ToString();
                foreach (var b in a.Value)
                    result += " " + b.ToString();
            }
                
            return result;
        }
    }
}
