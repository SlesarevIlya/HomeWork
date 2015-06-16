using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validator_B_Tree
{
    public class Tree
    {
        
        private Node root;
        private const Int32 t = 2; //max Links to children
        private bool flag;

        public Node Root
        {
            get { return root; }
            set { this.root = value; }
        }

        public Position Search(Node x, Int32 k, out bool flag)
        {
            flag = false;
            Int32 i = 0;
            while ((i < x.N) && (k > x.Keys[i]))
            {
                i++;
            }
            if ((i < x.N) && (k == x.Keys[i]))
            {
                flag = true;
                return new Position(x, i);
            }
            else if (x.IsLeaf)
            {
                return new Position(new Node(), 0);
            }
            else
            {
                return Search(x.Links[i], k, out flag);
            }
        }

        public void Create_Tree (ref Tree T)
        {
            Node x = new Node();
            x.IsLeaf = true;
            x.N = 0;
            T.root = x;
        }

        public void Split_Child(Node x, Int32 i)
        {
            Node right = new Node();
            Node left = x.Links[i];
            right.IsLeaf = left.IsLeaf;
            right.N = t - 1;
            for (Int32 j = 0; j < t - 1; j++)
            {
                right.Keys[j] = left.Keys[j + t];
            }
            if (!left.IsLeaf)
            {
                for (Int32 j = 0; j < t; j++)
                {
                    right.Links[j] = left.Links[j + t];
                }
            }
            left.N = t - 1;
            for (Int32 j = x.N; j >= i + 1; j--)
            {
                x.Links[j + 1] = x.Links[j];
            }
            x.Links[i + 1] = right;
            for (Int32 j = x.N - 1; j >= i; j--)
            {
                x.Keys[j + 1] = x.Keys[j];
            }
            x.Keys[i] = left.Keys[t - 1];
            x.N++;
        }

        public void Insert(ref Tree T, Int32 k)
        {
            Search(T.Root, k, out flag);
            if (!flag)
            {
                Node r = T.root;
                if (r.N == 2 * t - 1)
                {
                    Node s = new Node();
                    T.root = s;
                    s.IsLeaf = false;
                    s.N = 0;
                    s.Links[0] = r;
                    Split_Child(s, 0);
                    Insert_NonFull(s, k);
                }
                else
                {
                    Insert_NonFull(r, k);
                }
            }
            
        }

        public void Insert(ref Tree T, params Int32[] k)
        {
            for (Int32 i = 0; i < k.Count(); i++)
            {
                Insert(ref T, k[i]);
            }
        }

        public void Insert_NonFull(Node x, Int32 k)
        {
            Int32 i = x.N;
            if (x.IsLeaf)
            {
                while ((i >= 1) && (k < x.Keys[i - 1]))
                {
                    x.Keys[i] = x.Keys[i - 1];
                    i--;
                }
                x.Keys[i] = k;
                x.N++;
            }
            else
            {
                while ((i >= 1) && (k < x.Keys[i - 1]))
                {
                    i--;
                }
                if (x.Links[i].N == 2 * t - 1)
                {
                    Split_Child(x, i);
                    if (k > x.Keys[i])
                    {
                        i++;
                    }
                }
                Insert_NonFull(x.Links[i], k);
            }
                
        }

        public void Validator(Node x, ref bool flag, ref Int32 h, List<Int32> listOfHeight, Range range)
        {
            if (x != null)
            {//if root
                if (x.Keys == root.Keys)
                {
                    if ((x.N < 1) || (x.N > 2 * t - 1) || (x.CountOfLinks() < 2) || (x.CountOfLinks() > 2 * t) || (!x.Sorted()))
                    {
                        flag = false;
                    }
                    else
                    {
                        Int32 lvl = h;
                        h++;
                        Int32 c = x.N + 1;
                        for (Int32 i = 0; i < c; i++)
                        {
                            if (i == 0)
                            {
                                Validator(x.Links[i], ref flag, ref h, listOfHeight, new Range(range.Begin, x.Keys[i]));
                            }
                            else if (i == c - 1)
                            {
                                Validator(x.Links[i], ref flag, ref h, listOfHeight, new Range(x.Keys[c - 2], range.End));
                            }
                            else
                            {
                                Validator(x.Links[i], ref flag, ref h, listOfHeight, new Range(x.Keys[i - 1], x.Keys[i]));
                            }
                        }
                        h = lvl;
                    }
                }
                else
                {//if !root
                    if (x.IsLeaf) //if Leaf
                    {
                        if ((x.N < t - 1) || (x.N > 2 * t - 1) ||  (x.CountOfLinks() > 2 * t) || (!x.Sorted()))
                        {
                            flag = false;
                        }
                        for (Int32 i = 0; i < x.N; i++)
                        {
                            if ((x.Keys[i] < range.Begin) || (x.Keys[i] > range.End))
                            {
                                flag = false;
                            }
                        }
                        listOfHeight.Add(h);
                    }//if !Leaf
                    else 
                    {
                        if ((x.N < t - 1) || (x.N > 2 * t - 1) || (x.CountOfLinks() < t) || (x.CountOfLinks() > 2 * t) || 
                            (!x.Sorted()) || ((x.CountOfLinks() - x.N) != 1))
                        {
                            flag = false;
                        }
                        else
                        {
                            for (Int32 j = 0; j < x.N; j++)
                            {
                                if ((x.Keys[j] < x.Links[j].Keys[0]) || (x.Keys[j] > x.Links[j + 1].Keys[0]) || 
                                    (x.Keys[j] < range.Begin) || (x.Keys[j] > range.End))
                                {
                                    flag = false;
                                }
                            }
                        }
                        Int32 lvl = h;
                        h++;
                        Int32 c = x.N + 1;
                        for (Int32 j = 0; j < c; j++)
                        {
                            if (j == 0)
                            {
                                Validator(x.Links[j], ref flag, ref h, listOfHeight, new Range(range.Begin, x.Keys[j]));
                            }
                            else if (j == c - 1)
                            {
                                Validator(x.Links[j], ref flag, ref h, listOfHeight, new Range(x.Keys[c - 2], range.End));
                            }
                            else
                            {
                                Validator(x.Links[j], ref flag, ref h, listOfHeight, new Range(x.Keys[j - 1], x.Keys[j]));
                            }
                        }
                        h = lvl;
                    }
                }
                //end !root
            }
        }

        public bool Validator_Correct(Node x)
        {
            bool flag = true;
            Int32 h = 0;
            List<Int32> listOfHeight = new List<Int32>();
            root = x;

            Range range = new Range(Int32.MinValue, Int32.MaxValue);
            Validator(x, ref flag, ref h, listOfHeight, range);
            Int32 max = listOfHeight[0];
            foreach (var a in listOfHeight)
            {
                if (a != max)
                {
                    flag = false;
                }
            }
            return flag;
        }
        
        public Tree Decompressed(Tree T)
        {
            SortedSet<Int32> collection = new SortedSet<Int32>();
            Collection_Numbers(T.root, ref collection);

            Tree result = new Tree();
            result.Create_Tree(ref result);
            foreach (var a in collection)
            {
                Insert(ref result, a);
            }

            Split_Last(result.root);
            return result;
        }

        public void Split_Last(Node x)
        {
            Int32 i = x.N;
            if (x.Links[i] != null)
            {
                if (x.Links[i].N == 2 * t - 1)
                {
                    Split_Child(x, i);
                }
                else
                {
                    Split_Last(x.Links[i]);
                }
            }
        }

        public void Collection_Numbers(Node x, ref SortedSet<Int32> collection)
        {
            if (x != null)
            {
                for (Int32 i = 0; i < x.N; i++)
                {
                    collection.Add(x.Keys[i]);

                }
                for (Int32 j = 0; j < x.Links.Count(); j++)
                {
                    Collection_Numbers(x.Links[j], ref collection);
                }
            }
        }

        public void Count_Of_Lvl(List<Int32> x, ref Int32 maxCount, ref Int32 h) 
        {
            if (x.Count() > maxCount)
            {
                maxCount += (Int32)Math.Pow(2 * t, h + 1) * (2 * t - 1);
                h++;
                Count_Of_Lvl(x, ref maxCount, ref h);
            }
        }

        public void Convert_To_String(Node x, ref string result)
        {
            if (x != null)
            {
                result += x.ToString() + " \n ";
                for (Int32 i = 0; i < x.N + 1; i++)
                {
                    Convert_To_String(x.Links[i], ref result);
                }
            }
        }

        public Tree CopyTree(Tree T)
        {
            Tree T2 = new Tree();
            Create_Tree(ref T2);
            Clone(T.root, T2.root);
            T2.ToString();

            return T2;
        }

        private void Clone(Node x, Node y)
        {
            for (Int32 i = 0; i < 2 * t - 1; i++)
            {
                y.Keys[i] = x.Keys[i];
            }
            y.N = x.N;
            y.IsLeaf = x.IsLeaf;
            for (Int32 i = 0; i < 2 * t; i++)
            {
                if (x.Links[i] != null)
                {
                    y.Links[i] = new Node();
                }
                else
                {
                    continue;
                }
                Clone(x.Links[i], y.Links[i]);
            }
            
        }


        public override string ToString()
        {
            string result = "";
            Convert_To_String(this.root, ref result);

            return result;
        }
    }
}
