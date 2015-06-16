using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Edge
    {
        private char start;
        private char finish;

        public char Start
        {
            get { return start; }
        }

        public char Finish
        {
            get { return finish; }
        }

        public Edge(char start, char finish)
        {
            this.start = start;
            this.finish = finish;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            Edge v = obj as Edge;
            if ((this.Start != v.Start) || (this.Finish != v.Finish))
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return ((Int32)this.Start + (Int32)this.Finish) / 3;
        }

        public override string ToString()
        {
            string result = Convert.ToString(this.Start) + Convert.ToString(this.Finish);
            return result;
        }
    }
}
