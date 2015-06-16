using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    static class ParseGraph
    {
        public static void ParseGraphAdjacency(this String s, out AdjacencyMatrix graph)
        {
            char[] charSeparators = new char[] { ' ' };
            string[] elements = s.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            var Collection = new Dictionary<Vertex, List<Vertex>>();
            Int32 i = 0;
            Vertex index = new Vertex('a');
            while (i < elements.Length)
            {
                if (elements[i] == ":")
                {
                    var a = new Vertex(elements[i + 1][0]);
                    Collection.Add(a, new List<Vertex>());
                    index = a;
                    i += 2;
                    continue;
                }
                else
                    Collection[index].Add(new Vertex(elements[i][0]));
                i++;
            }

            AdjacencyMatrix graph1 = new AdjacencyMatrix(Collection);
            graph = graph1;
        }

        public static void ParseGraphIncidence(this String s, out IncidenceMatrix graph)
        {
            char[] charSeparators = new char[] { ' ' };
            string[] elements = s.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            var Collection = new Dictionary<Vertex, List<Edge>>();
            Int32 i = 0;
            Vertex index = new Vertex('a');
            while (i < elements.Length)
            {
                if (elements[i] == ":")
                {
                    var a = new Vertex(elements[i + 1][0]);
                    Collection.Add(a, new List<Edge>());
                    index = a;
                    i += 2;
                    continue;
                }
                else
                {
                    Edge e = new Edge(elements[i][0], elements[i][1]);
                    Collection[index].Add(e);
                }
                i++;
            }

            IncidenceMatrix graph1 = new IncidenceMatrix(Collection);
            graph = graph1;
        }
    }
}
