using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validator_B_Tree
{
    public class Node
    {
        private Int32 n; //count of keys
        private Int32[] keys;
        private Node[] links;
        private bool isLeaf; //Leaf?
        private const Int32 t = 2; //

        public Int32 N
        {
            get { return n; }
            set { this.n = value; }
        }

        public Int32[] Keys
        {
            get { return keys; }
            set { this.keys = value; }
        }

        public Node[] Links
        {
            get { return links; }
            set { this.links = value; }
        }

        public bool IsLeaf
        {
            get { return isLeaf; }
            set { this.isLeaf = value; }
        }

        public Node()
        {
            this.n = 0;
            this.isLeaf = true;
            this.keys = new Int32[2 * t - 1];
            this.links = new Node[2 * t];
        }

        public Node(Int32 n, Int32[] keys, Node[] links, bool isLeaf)
        {
            this.n = n;
            //this.keys = new int[2 * t - 1];
            //this.links = new Node[2 * t];
            this.keys = keys;
            this.links = links;
            this.isLeaf = isLeaf;
        }

        public Int32 CountOfLinks()
        {
            return n + 1;
        }

        public bool Sorted()
        {
            for (Int32 i = 0; i < this.n - 1; i++)
            {
                if (this.Keys[i] > this.Keys[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            string result = "";
            for (Int32 i = 0; i < n; i++)
            {
                result += Convert.ToString(this.keys[i]) + " ";
            }
            for (Int32 i = n; i < 2 * t - 1; i++)
            {
                result += "null ";
            }
            result += "; ";
            if (this.isLeaf)
            {
                result += "Is Leaf";
            }
            else
            {
                result += "Is not Leaf";
            }
            return result;
        }
        
    }

    public class Position
    {
        private Node node;
        private Int32 i;   // number value in node

        public Position(Node node, Int32 i)
        {
            this.node = node;
            this.i = i;
        }

        public override string ToString()
        {
            string result = this.node.ToString() + "; Index of Element: " + Convert.ToString(this.i);
            return result;
        }

    }

    public class Range
    {
        private Int32 begin;
        private Int32 end;

        public Int32 Begin
        {
            get { return begin; }
            set { this.begin = value; }
        }

        public Int32 End
        {
            get { return end; }
            set { this.end = value; }
        }

        public Range(Int32 begin, Int32 end)
        {
            this.begin = begin;
            this.end = end;
        }

    }
}
