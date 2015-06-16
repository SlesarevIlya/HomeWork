using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validator_B_Tree
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tree T = new Tree();
            T.Create_Tree(ref T);
            T.Insert(ref T, new Int32[]{ 82, 26, 31, 89, 7, 12, 25, 43, 40, 76, 90, 71, 69, 58, 63, 66, 75, 88, 38, 92});
            Console.WriteLine(T.Validator_Correct(T.Root).ToString());
            //T.Insert(ref T, new Int32[] { 82, 26, 31, 7, 12, 25, 43, 40, 76, 71, 69, 58, 63, 66, 75, 88, 38 });
            /*
            bool flag;
            Position p = T.Search(T.Root, 40, out flag);
            if (p.ToString() != "null null null ; Is Leaf; Index of Element: 0")
            {
                Console.WriteLine("{0}", p.ToString());
            }
            else
            {
                Console.WriteLine("Key not found");
            }*/
            Node x =
                new Node(2, new Int32[] { 31, 71, 0 }, new Node[] 
                    {new Node(1, new Int32[] { 12, 0, 0 }, new Node[] {
                        new Node(1, new Int32[] { 7, 0, 0 }, new Node[4], true),
                        new Node(2, new Int32[] { 25, 26, 0 }, new Node[4], true),
                        null, null }, false),

                    new Node(2, new Int32[] { 43, 63, 0 }, new Node[] {
                        new Node(2, new Int32[] { 38, 40, 0 }, new Node[4], true),
                        new Node(1, new Int32[] { 58, 0, 0 }, new Node[4], true), 
                        new Node(2, new Int32[] { 66, 69, 0 }, new Node[4], true), 
                        null }, false),

                    new Node(2, new Int32[] { 82, 89, 0}, new Node[] {
                        new Node(2, new Int32[] { 75, 76, 0 }, new Node[4], true),
                        new Node(1, new Int32[] { 88, 0, 0 }, new Node[4], true), 
                        new Node(3, new Int32[] { 90, 92, 0}, new Node[4], true),
                        null }, false), 
                    null }, false);
            
            /*
            Tree T2 = T.Decompressed(T);*/
            Console.WriteLine(T.Validator_Correct(T.Root).ToString());
            //string wer = T2.ToString();
            //Console.WriteLine(T2.ToString());
            //return;
            Tree T2 = T.CopyTree(T);
            Console.WriteLine(T2.Validator_Correct(T2.Root).ToString());
            return;
        }

    }
}
