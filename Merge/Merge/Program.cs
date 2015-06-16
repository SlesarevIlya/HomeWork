using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Merge
{
    public class Program
    {
        static void Main(string[] args)
        {
            string line;
            var Collection = new List<SortedSet<char>>();
            using (StreamReader reader = new StreamReader("input.txt"))
                for (Int32 i = 0; (line = reader.ReadLine()) != null; i++)
                {
                    var a = new SortedSet<char>();
                    for (Int32 j = 0; j < line.Length; j++)
                        a.Add(line[j]);
                    Collection.Add(a);
                }

            var result = new List<string>();
            result = Merge(Collection);
            for (Int32 i = 0; i < result.Count(); i++)
                Console.WriteLine(result[i]);
            
        }

        public static List<string> Merge(List<SortedSet<char>> Collection)
        {
            Int32 CountChars = 0;
            while (CountChars != Collection.Count)
            {
                CountChars = Collection.Count;
                for (Int32 i = 0; i < Collection.Count; i++)
                {
                    for (Int32 j = i + 1; j < Collection.Count; j++)
                    {
                        var a = new SortedSet<char>();
                        foreach (char x in Collection[i])
                            a.Add(x);
                        foreach (char x in Collection[j])
                            a.Add(x);
                        if (a.Count != (Collection[i].Count + Collection[j].Count))
                        {
                            Collection[i] = a;
                            Collection.RemoveAt(j);
                        }   
                    }
                }
            }

            var result = new List<string>();
            for (Int32 i = 0; i < Collection.Count; i++)
            {
                string s = "";
                foreach (char x in Collection[i])
                    s += x.ToString();
                result.Add(s);
            }

            return result;
        }
    }
}
