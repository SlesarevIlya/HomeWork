using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {

            AdjacencyMatrix Graph1 = new AdjacencyMatrix();
            AdjacencyMatrix Graph2 = new AdjacencyMatrix();
            AdjacencyMatrix Graph3 = new AdjacencyMatrix();
            Vertex ver = new Vertex('K');
            Graph1.AddVertex(new Vertex('A'), new Vertex('B'), new Vertex('C'), new Vertex('D'), new Vertex('E'), ver, new Vertex('M'), new Vertex('O'));
            Graph1.AddEdge(new Edge('A', 'B'), new Edge('A', 'C'), new Edge('B', 'C'), new Edge('B', 'E'), new Edge('C', 'D'), new Edge('M', 'O'));
            Graph2.AddVertex(new Vertex('A'), new Vertex('B'), new Vertex('C'), new Vertex('D'), new Vertex('E'));
            Graph2.AddEdge(new Edge('A', 'B'), new Edge('A', 'C'), new Edge('B', 'C'), new Edge('B', 'E'), new Edge('C', 'D'));
            //тест вычитание двух графов ( + вычесть вершину)
            //Graph2.AddVertex(new Vertex('B'), new Vertex('C'), new Vertex('E'));
            //Graph2.AddEdge(new Edge('B', 'C'), new Edge('B', 'E'));
            //Graph3 = Graph1 - Graph2;
            
            //тест вычесть ребро
            //Edge e1 = new Edge('B', 'E');
            //Graph3 = Graph1 - e1;
            
            //тест сложить 2 графа
            //Graph2.AddVertex(new Vertex('E'), new Vertex('M'));
            //Graph2.AddEdge(new Edge('E', 'M'));
            //Graph3 = Graph1 + Graph2;

            //тест + ребро
            //Edge e1 = new Edge('E', 'D');
            //Edge e2 = new Edge('E', 'M');
            //Graph3 = Graph1 + e2;

            IncidenceMatrix GraphI1 = new IncidenceMatrix(new Dictionary<Vertex, List<Edge>>());
            IncidenceMatrix GraphI2 = new IncidenceMatrix(new Dictionary<Vertex, List<Edge>>());
            IncidenceMatrix GraphI3 = new IncidenceMatrix(new Dictionary<Vertex, List<Edge>>());
            GraphI1.AddVertex(new Vertex('A'), new Vertex('B'), new Vertex('C'), new Vertex('D'), new Vertex('E'), new Vertex('L'));
            GraphI1.AddEdge(new Edge('A', 'B'), new Edge('A', 'C'), new Edge('B', 'C'), new Edge('B', 'E'), new Edge('C', 'D'));
            GraphI2.AddVertex(new Vertex('A'), new Vertex('B'), new Vertex('C'), new Vertex('D'), new Vertex('E'));
            GraphI2.AddEdge(new Edge('A', 'B'), new Edge('A', 'C'), new Edge('B', 'C'), new Edge('B', 'E'), new Edge('C', 'D'));
            //тест приведения
            //GraphI1 = Graph1;
            //Graph2 = (AdjacencyMatrix) GraphI1;

            //тест вычитание двух графов ( + вычесть вершину)
            //GraphI2.AddVertex(new Vertex('B'), new Vertex('C'), new Vertex('E'));
            //GraphI2.AddEdge(new Edge('B', 'C'), new Edge('B', 'E'));
            //GraphI3 = GraphI1 - GraphI2;

            //тест вычесть ребро
            //Edge e1 = new Edge('B', 'E');
            //GraphI3 = GraphI1 - e1;

            //тест сложить 2 графа
            //GraphI2.AddVertex(new Vertex('E'), new Vertex('D'));
            //GraphI2.AddEdge(new Edge('E', 'D'));
            //GraphI3 = GraphI1 + GraphI2;

            //тест + ребро
            //Edge e1 = new Edge('E', 'D');
            //Edge e2 = new Edge('E', 'M');
            //GraphI3 = GraphI1 + e2;
            
            //тест парс в смежности
            /*
            string line = ": A B C : B A K : K B : C A";
            AdjacencyMatrix Graph4;
            line.ParseGraphAdjacency(out Graph4);
            */

            //тест парс в инциденции
            
            string line = ": A AB AC : B AB BK : K BK : C AC";
            IncidenceMatrix GraphI4;
            line.ParseGraphIncidence(out GraphI4);

            bool abc = GraphI1.Equals(GraphI2);

            GraphI4.ToString();
            ArcComponent c = new ArcComponent(Graph1);
            c.PrintComponents();
            Console.WriteLine(c.MaximumCountOfComponents);
            c.RemoveVertex(ver);
            c.PrintComponents();
            Console.WriteLine(c.MaximumCountOfComponents);
            c.AddVertex(new Vertex('H'));
            c.AddVertex(new Vertex('L'));
            c.PrintComponents();
            Console.WriteLine(c.MaximumCountOfComponents);
        }
    }
}
