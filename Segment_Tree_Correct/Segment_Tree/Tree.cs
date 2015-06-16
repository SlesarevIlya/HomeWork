using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segment_Tree
{
    public class Tree
    {
        public Int32 N;
        public Int32[] Segment_Tree;
        public Int32[] ColorMarker;

        public Tree (Int32 N)
        {
            this.N = N;
            Segment_Tree = new Int32[N * 4];
            ColorMarker = new Int32[N * 4];
        }

        public void Build(Int32[] a, Int32 v, Int32 tl, Int32 tr)
        {
            if (tl == tr)
                Segment_Tree[v] = a[tl];
            else
            {
                Int32 tm = (tl + tr) / 2;
                Build(a, v * 2, tl, tm);
                Build(a, v * 2 + 1, tm + 1, tr);
                Segment_Tree[v] = Segment_Tree[v * 2] + Segment_Tree[v * 2 + 1];
            }
        }
        public void Update(Int32 v, Int32 tl, Int32 tr, Int32 l, Int32 r, Int32 X)
        {
            if (l > r)
                return;
            if (l == tl && tr == r)
            {
                if (ColorMarker[v] == -1)
                    ColorMarker[v] += 1;
                ColorMarker[v] = X;
            } 
            else
            {
                push(v);
                int tm = (tl + tr) / 2;
                Update(v * 2, tl, tm, l, Math.Min(r, tm), X);
                Update(v * 2 + 1, tm + 1, tr, Math.Max(l, tm + 1), r, X);
            }
        }
        public Int32 Get_range(Int32 v, Int32 tl, Int32 tr, Int32 l, Int32 r)
        {
            if (l > r)
                return 0;
            if (l == tl && r == tr && ColorMarker[v] != -1)
            {
                if (ColorMarker[v] > 0)
                    return ColorMarker[v] * (r - l + 1);
                else return Segment_Tree[v];
            }
            Int32 tm = (tl + tr) / 2;
            return Get_range(v * 2, tl, tm, l, Math.Min(r, tm))
                + Get_range(v * 2 + 1, tm + 1, tr, Math.Max(l, tm + 1), r);
        }
        public void push(Int32 v)
        {
            if (ColorMarker[v] != -1)
            {
                ColorMarker[v * 2] = ColorMarker[v * 2 + 1] = ColorMarker[v];
                ColorMarker[v] = -1;
            }
        }

        public void Change_pos(Int32 pos, Int32 value)
        {
            Update(1, 0, N - 1, pos, pos, value);
        }
        public void Change_range(Int32 l, Int32 r, Int32 value)
        {
            Update(1, 0, N - 1, l, r, value);
        }
        public Int32 Get_sum_in_range(Int32 l, Int32 r)
        {
            return Get_range(1, 0, N - 1, l, r);
        }
        public Int32 Get_position(Int32 pos)
        {
            return Get_sum_in_range(pos, pos);
        }
    }
}
