using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Segment_Tree
{
    public class Program
    {
        private static Int32[] BaseArray = new Int32[0];
        public static Int32 N = 8;
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                Array.Resize(ref BaseArray, N);
                string[] a = new string[N];
                char[] charSeparators = new char[] { ' ' };
                a = reader.ReadLine().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                for (Int32 j = 0; j < a.Count(); j++)
                    BaseArray[j] = Convert.ToInt32(a[j]);
            }
            Tree tr = new Tree(N);
            tr.Build(BaseArray, 1, 0, N - 1);
            Console.WriteLine("Segment tree ");
            Console.WriteLine();
            Int32 flag = 1;
            for (int i = 1; i < tr.Segment_Tree.Count() / 2; i *= 2)
            {
                for (int j = 1; j < N - flag; j++) 
                    Console.Write(" ");
                for (int j = 0; j < i; j++)
                {
                    Console.Write("{0} ", tr.Segment_Tree[flag]);
                    flag++;
                }
                Console.WriteLine(); 
                Console.WriteLine();
            }
            Int32 l = 3;
            Int32 r = 3;
            tr.Change_range(l, r, 5);
            Console.Write("Tree of markers ");
            for (Int32 i = 1; i < tr.ColorMarker.Count() / 2; i++)
                Console.Write("{0} ", tr.ColorMarker[i]);
            Console.WriteLine();
            //Console.WriteLine("sum 0 : 7 = {0}", Tree.Get_range(1, 0, N - 1, 0, 7));
            Console.WriteLine(tr.Get_position(0));
        }
        
    }
}
