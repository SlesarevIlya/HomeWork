using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Vertex
    {
        private char name;

        public char Name
        {
            get { return name; }
            set { name = value; }
        }

        public Vertex(char name)
        {
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            if ( obj == null) 
                return false;
            if (this.GetType() != obj.GetType()) 
                return false;
            Vertex v = obj as Vertex;
            if (this.Name != v.Name) 
                return false;
            return true;
        }

        public override int GetHashCode()
        {

            return ((Int32)this.Name + 50) / 4;
        }
        
        public override string ToString()
        {
            return Convert.ToString(this.Name);
        }
         
    }
}
