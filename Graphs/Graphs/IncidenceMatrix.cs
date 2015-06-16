using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class IncidenceMatrix : Graph
    {
        private Dictionary<Vertex, List<Edge>> Matrix;

        public IncidenceMatrix(Dictionary<Vertex, List<Edge>> dictionary)
        {
            this.Matrix = new Dictionary<Vertex, List<Edge>>();
            foreach (var a in dictionary)
            {
                this.Matrix.Add(a.Key, new List<Edge>());
                foreach (var b in a.Value)
                {
                    this.Matrix[a.Key].Add(b);
                }
            }
        }

        public static IncidenceMatrix operator + (IncidenceMatrix g1, Vertex vertex)
        {
            IncidenceMatrix g = new IncidenceMatrix(g1.Matrix);
            if (vertex != null)
                g.Matrix.Add(vertex, new List<Edge>());
            return g;
        }

        public static IncidenceMatrix operator + (Vertex vertex, IncidenceMatrix g)
        {
            return (g + vertex);
        }

        public static IncidenceMatrix operator + (IncidenceMatrix g1, IncidenceMatrix g2)
        {
            IncidenceMatrix g = new IncidenceMatrix(g1.Matrix);
            foreach (var a in g2.Matrix)
                foreach (var b in a.Value)
                    g += b;
            return g;
        }

        public static IncidenceMatrix operator +(IncidenceMatrix g1, Edge edge)
        {
            IncidenceMatrix g = new IncidenceMatrix(g1.Matrix);
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
                        if ((a.Value[i].Start == edge.Start) && (a.Value[i].Finish == edge.Finish))
                        {
                            flag = true;
                            break;
                        }
                    if (!flag)
                        a.Value.Add(edge);
                    FlagStart = true;
                }
                else if (a.Key.Name == edge.Finish)
                {
                    bool flag = false;
                    for (Int32 i = 0; i < a.Value.Count(); i++)
                        if ((a.Value[i].Start == edge.Start) && (a.Value[i].Finish == edge.Finish))
                        {
                            flag = true;
                            break;
                        }

                    if (!flag)
                        a.Value.Add(edge);
                    FlagFinish = true;
                }
            }
            if (!FlagStart)
            {
                g.Matrix.Add(begin, new List<Edge>());
                g.Matrix[begin].Add(edge);
            }
            if (!FlagFinish)
            {
                g.Matrix.Add(end, new List<Edge>());
                g.Matrix[end].Add(edge);
            }
            return g;
        }

        public static IncidenceMatrix operator +(Edge edge, IncidenceMatrix g)
        {
            return g + edge;
        }

        public static IncidenceMatrix operator -(IncidenceMatrix g1, Vertex vertex)
        {
            IncidenceMatrix g = new IncidenceMatrix(g1.Matrix);
            foreach (var a in g.Matrix.Keys)
                if (a.Name == vertex.Name)
                {
                    g.Matrix.Remove(a);
                    break;
                }   
            foreach (var a in g.Matrix)
                for (Int32 i = 0; i < a.Value.Count; i++)
                    if ((a.Value[i].Start == vertex.Name) || (a.Value[i].Finish == vertex.Name))
                        a.Value.RemoveAt(i);
            return g;
        }

        public static IncidenceMatrix operator -(IncidenceMatrix g1, Edge edge)
        {
            IncidenceMatrix g = new IncidenceMatrix(g1.Matrix);
            foreach (var a in g.Matrix)
                if ((a.Key.Name == edge.Start) || (a.Key.Name == edge.Finish))
                    foreach (var b in a.Value)
                        if ((b.Start == edge.Start) && (b.Finish == edge.Finish))
                        {
                            a.Value.Remove(b);
                            break;
                        }     
            return g;
        }

        public static IncidenceMatrix operator -(IncidenceMatrix g1, IncidenceMatrix g2)
        {
            IncidenceMatrix g = new IncidenceMatrix(g1.Matrix);
            foreach (var a in g2.Matrix.Keys)
                g -= a;
            return g;
        }
        
        private static AdjacencyMatrix ConvertToAdjacency(IncidenceMatrix g)
        {
            var graph = new Dictionary<Vertex, List<Vertex>>();
            foreach (var a in g.Matrix)
            {
                List<Vertex> List_vertexes = new List<Vertex>();
                foreach (var b in a.Value)
                {
                    if (b.Start != a.Key.Name)
                        List_vertexes.Add(new Vertex(b.Start));
                    else
                        List_vertexes.Add(new Vertex(b.Finish));
                }
                graph.Add(a.Key, List_vertexes);
            }
            AdjacencyMatrix result = new AdjacencyMatrix(graph);
            return result;
        }

        public static explicit operator AdjacencyMatrix(IncidenceMatrix g)
        {
            return ConvertToAdjacency(g);
        }
        
        public override void AddVertex(Vertex v)
        {
            IncidenceMatrix g = this;
            g += v;
            this.Matrix = g.Matrix;
        }

        public override void AddVertex(Vertex v1, Vertex v2)
        {
            IncidenceMatrix g = this;
            g += v1;
            g += v2;
            this.Matrix = g.Matrix;
        }

        public override void AddVertex(params Vertex[] v)
        {
            IncidenceMatrix g = this;
            for (Int32 i = 0; i < v.Count(); i++)
                g += v[i];
            this.Matrix = g.Matrix;
        }
        
        public override void AddEdge(Edge e)
        {
            IncidenceMatrix g = this;
            g += e;
            this.Matrix = g.Matrix;
        }

        public override void AddEdge(Edge e1, Edge e2)
        {
            IncidenceMatrix g = this;
            g += e1;
            g += e2;
            this.Matrix = g.Matrix;
        }

        public override void AddEdge(params Edge[] e)
        {
            IncidenceMatrix g = this;
            for (Int32 i = 0; i < e.Count(); i++)
                g += e[i];
            this.Matrix = g.Matrix;
        }

        public override void RemoveVertex(Vertex v)
        {
            IncidenceMatrix g = this;
            g -= v;
            this.Matrix = g.Matrix;
        }

        public override void RemoveEdge(Edge e)
        {
            IncidenceMatrix g = this;
            g -= e;
            this.Matrix = g.Matrix;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            IncidenceMatrix v = obj as IncidenceMatrix;
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
