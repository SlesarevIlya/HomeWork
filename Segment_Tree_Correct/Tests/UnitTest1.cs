using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Segment_Tree;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Check_build()
        {
            Int32 N = 8;
            //Int32[] Segment_Tree = new Int32[4 * N];
            Int32[] BaseArray = new Int32[] { 7, 8, 9, 10, 11, 12, 13, 14 };
            Tree tr = new Tree(N);
            tr.Build(BaseArray, 1, 0, N - 1);
            Int32[] result = new Int32[] { 0, 84, 34, 50, 15, 19, 23, 27, 7, 8, 9, 10, 11, 12, 13, 14,
                                               0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            CollectionAssert.AreEqual(result, tr.Segment_Tree);
        }

        [TestMethod]
        public void Get_position()
        {
            Int32 N = 8;
            Tree tr = new Tree(N);
            Int32[] Segment_Tree = new Int32[4 * N];
            Int32[] BaseArray = new Int32[] { 7, 8, 9, 10, 11, 12, 13, 14 };
            tr.Build(BaseArray, 1, 0, N - 1);
            tr.Change_range(0, 0, 6);
            Assert.AreEqual(6, tr.Get_position(0));
        }

        [TestMethod]
        public void Change_pos()
        {
            Int32 N = 8;
            Tree tr = new Tree(N);
            Int32[] Segment_Tree = new Int32[4 * N];
            Int32[] BaseArray = new Int32[] { 7, 8, 9, 10, 11, 12, 13, 14 };
            tr.Build(BaseArray, 1, 0, N - 1);
            tr.Change_pos(3, 5);
            Int32[] result = new Int32[] { 0, -1, -1, 0, 0, -1, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 
                                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            CollectionAssert.AreEqual(result, tr.ColorMarker);
            Array.Clear(Segment_Tree, 0, 4 * N - 1);
        }
        
        [TestMethod]
        public void Change_range()
        {
            Int32 N = 8;
            Tree tr = new Tree(N);
            Int32[] Segment_Tree = new Int32[4 * N];
            Int32[] BaseArray = new Int32[] { 7, 8, 9, 10, 11, 12, 13, 14 };
            tr.Build(BaseArray, 1, 0, N - 1);
            tr.Change_range(6, 7, 5);
            Int32[] result = new Int32[] {0, -1, 0, -1, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            CollectionAssert.AreEqual(result, tr.ColorMarker);
            Array.Clear(tr.Segment_Tree, 0, 4 * N - 1);
        }

        [TestMethod]
        public void Get_sum_in_range()
        {
            Int32 N = 8;
            Tree tr = new Tree(N);
            Int32[] Segment_Tree = new Int32[4 * N];
            Int32[] BaseArray = new Int32[] { 7, 8, 9, 10, 11, 12, 13, 14 };
            tr.Build(BaseArray, 1, 0, N - 1);
            tr.Change_range(0, 3, 6);
            tr.Change_range(1, 2, 5);
            Int32[] result = new Int32[] { 0, 72, 22, 50, 11, 11, 23, 27, 6, 5, 5, 6, 11, 12, 13, 14,
                                              0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            Assert.AreEqual(33, tr.Get_sum_in_range(0, 4));
        }

    }
}
