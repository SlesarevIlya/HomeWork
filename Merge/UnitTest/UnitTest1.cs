using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Merge;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var Collection = new List<SortedSet<char>>();
            Collection.Add(new SortedSet<char>() { 'B', 'A' });
            Collection.Add(new SortedSet<char>() { 'B', 'C' });
            Collection.Add(new SortedSet<char>() { 'C', 'D' });
            Collection.Add(new SortedSet<char>() { 'G', 'K' });
            var result = new List<string>();
            result = Program.Merge(Collection);
            var Expected = new List<string>();
            Expected.Add("ABCD");
            Expected.Add("GK");
            CollectionAssert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var Collection = new List<SortedSet<char>>();
            Collection.Add(new SortedSet<char>() { 'A', 'U' });
            Collection.Add(new SortedSet<char>() { 'C', 'D' });
            Collection.Add(new SortedSet<char>() { 'D', 'E' });
            Collection.Add(new SortedSet<char>() { 'G', 'M' });
            Collection.Add(new SortedSet<char>() { 'M', 'U' });
            var result = new List<string>();
            result = Program.Merge(Collection);
            var Expected = new List<string>();
            Expected.Add("AGMU");
            Expected.Add("CDE");
            CollectionAssert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var Collection = new List<SortedSet<char>>();
            Collection.Add(new SortedSet<char>() { 'A', });
            Collection.Add(new SortedSet<char>() { 'C', 'U' });
            var result = new List<string>();
            result = Program.Merge(Collection);
            var Expected = new List<string>();
            Expected.Add("A");
            Expected.Add("CU");
            CollectionAssert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var Collection = new List<SortedSet<char>>();
            Collection.Add(new SortedSet<char>() { 'B', 'C' });
            Collection.Add(new SortedSet<char>() { 'A', 'F' });
            Collection.Add(new SortedSet<char>() { 'D', 'E' });
            Collection.Add(new SortedSet<char>() { 'B', 'G' });
            Collection.Add(new SortedSet<char>() { 'E', 'F' });
            var result = new List<string>();
            result = Program.Merge(Collection);
            var Expected = new List<string>();
            Expected.Add("BCG");
            Expected.Add("ADEF");
            CollectionAssert.AreEqual(Expected, result);
        }
    }
}
