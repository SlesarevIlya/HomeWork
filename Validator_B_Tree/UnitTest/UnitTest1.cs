using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validator_B_Tree;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestMethod1()
        {
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
                        new Node(3, new Int32[] { 90, 92, 93}, new Node[4], true),
                        null }, false), 
                    null }, false);

            Tree T = new Tree();
            bool result = T.Validator_Correct(x);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
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
                        new Node(3, new Int32[] { 90, 92, 93}, new Node[] {
                            new Node(1, new Int32[] { 97, 100, 105 }, new Node[4], true), 
                            new Node(1, new Int32[] { 125, 130, 0 }, new Node[4], true), 
                            new Node(1, new Int32[] { 150, 0, 0 }, new Node[4], true), 
                            null }, false),
                        null }, false), 
                    null }, false);

            Tree T = new Tree();
            bool result = T.Validator_Correct(x);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
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
                        new Node(3, new Int32[] { 90, 92, 93}, new Node[] {
                            new Node(1, new Int32[] { 100, 50, 105 }, new Node[4], true), 
                            new Node(1, new Int32[] { 1, 130, 0 }, new Node[4], true), 
                            new Node(1, new Int32[] { 150, 0, 50 }, new Node[4], true), 
                            null }, false),
                        null }, false), 
                    null }, false);

            Tree T = new Tree();
            bool result = T.Validator_Correct(x);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
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
                        new Node(3, new Int32[] { 93, 92, 90}, new Node[4], true),
                        null }, false), 
                    null }, false);

            Tree T = new Tree();
            bool result = T.Validator_Correct(x);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Node x =
                new Node(2, new Int32[] { 31, 71, 0 }, new Node[] 
                    {new Node(1, new Int32[] { 12, 0, 0 }, new Node[] {
                        new Node(0, new Int32[] { 0, 0, 0 }, new Node[4], true),
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
                        new Node(3, new Int32[] { 90, 92, 93}, new Node[4], true),
                        null }, false), 
                    null }, false);

            Tree T = new Tree();
            bool result = T.Validator_Correct(x);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Node x =
                new Node(2, new Int32[] { 31, 71, 0 }, new Node[] 
                    {new Node(1, new Int32[] { 12, 0, 0 }, new Node[] {
                        new Node(1, new Int32[] { 0, 0, 0 }, new Node[4], true),
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
                        new Node(4, new Int32[] { 90, 92, 93, 94}, new Node[4], true),
                        null }, false), 
                    null }, false);

            Tree T = new Tree();
            bool result = T.Validator_Correct(x);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Node x =
                new Node(2, new Int32[] { 31, 71, 0 }, new Node[] 
                    {new Node(1, new Int32[] { 12, 0, 0 }, new Node[] {
                        new Node(1, new Int32[] { 15, 0, 0 }, new Node[4], true),
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
                        new Node(3, new Int32[] { 90, 92, 93}, new Node[4], true),
                        null }, false), 
                    null }, false);

            Tree T = new Tree();
            bool result = T.Validator_Correct(x);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestMethod8()
        {
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
                        new Node(3, new Int32[] { 90, 92, 93}, new Node[4], true),
                        null }, false), 
                    null }, false);

            Tree T = new Tree();
            bool result = T.Validator_Correct(x);
            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void TestMethod9()
        {
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
                        new Node(3, new Int32[] { 90, 92, 93}, new Node[4], true),
                        null }, false), 
                    null }, false);

            Tree T = new Tree();
            T.Root = x;
            bool result = T.Validator_Correct(T.Root);
            Assert.AreEqual(true, result);
            Tree T2 = new Tree();
            T2.Create_Tree(ref T2);
            T2 = T.CopyTree(T);
            result = T2.Validator_Correct(T2.Root);
            Assert.AreEqual(true, result);
        }
        /*
        [TestMethod]
        public void TestMethod1()
        {
            Node x =
                new Node(3, new Int32[] { 31, 58, 76, 0, 0 }, new Node[] {
                    new Node(4, new Int32[] { 7, 12, 25, 26, 0 }, new Node[6], true),
                    new Node(3, new Int32[] { 38, 40, 43, 0, 0 }, new Node[6], true),
                    new Node(5, new Int32[] { 63, 66, 69, 71, 75 }, new Node[6], true),
                    new Node(5, new Int32[] { 82, 88, 89, 90, 92 }, new Node[6], true),
                    }, false);

            Tree T = new Tree();
            T.Create_Tree(ref T);
            T.Root = x;
            T = T.Decompressed(T);
            string result = T.ToString();
            string exp = "58 null null null null ; Is not Leaf \n 25 38 null null null ; Is not Leaf \n ";
            exp += "7 12 null null null ; Is Leaf \n 26 31 null null null ; Is Leaf \n ";
            exp += "40 43 null null null ; Is Leaf \n 69 76 89 null null ; Is not Leaf \n ";
            exp += "63 66 null null null ; Is Leaf \n 71 75 null null null ; Is Leaf \n ";
            exp += "82 88 null null null ; Is Leaf \n 90 92 null null null ; Is Leaf \n ";
            Assert.AreEqual(exp, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Node x =
                new Node(3, new Int32[] { 31, 58, 76, 0, 0 }, new Node[] {
                    new Node(4, new Int32[] { 7, 12, 25, 26, 0 }, new Node[6], true),
                    new Node(3, new Int32[] { 38, 40, 43, 0, 0 }, new Node[6], true),
                    new Node(5, new Int32[] { 63, 66, 69, 71, 75 }, new Node[6], true),
                    new Node(4, new Int32[] { 82, 88, 89, 90, 0 }, new Node[6], true),
                    }, false);

            Tree T = new Tree();
            T.Create_Tree(ref T);
            T.Root = x;
            T = T.Decompressed(T);
            string result = T.ToString();
            string exp = "58 null null null null ; Is not Leaf \n 25 38 null null null ; Is not Leaf \n ";
            exp += "7 12 null null null ; Is Leaf \n 26 31 null null null ; Is Leaf \n ";
            exp += "40 43 null null null ; Is Leaf \n 69 76 null null null ; Is not Leaf \n ";
            exp += "63 66 null null null ; Is Leaf \n 71 75 null null null ; Is Leaf \n ";
            exp += "82 88 89 90 null ; Is Leaf \n ";
            Assert.AreEqual(exp, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Node x =
                new Node(3, new Int32[] { 31, 58, 76, 95, 0 }, new Node[] {
                    new Node(4, new Int32[] { 7, 12, 25, 26, 0 }, new Node[6], true),
                    new Node(3, new Int32[] { 38, 40, 43, 0, 0 }, new Node[6], true),
                    new Node(5, new Int32[] { 63, 66, 69, 71, 75 }, new Node[6], true),
                    new Node(5, new Int32[] { 82, 88, 89, 90, 92 }, new Node[6], true),
                    new Node(3, new Int32[] { 100, 120, 130, 0, 0 }, new Node[6], true),
                    }, false);

            Tree T = new Tree();
            T.Create_Tree(ref T);
            T.Root = x;
            T = T.Decompressed(T);
            string result = T.ToString();
            string exp = "58 null null null null ; Is not Leaf \n 25 38 null null null ; Is not Leaf \n ";
            exp += "7 12 null null null ; Is Leaf \n 26 31 null null null ; Is Leaf \n ";
            exp += "40 43 null null null ; Is Leaf \n 69 76 89 100 null ; Is not Leaf \n ";
            exp += "63 66 null null null ; Is Leaf \n 71 75 null null null ; Is Leaf \n ";
            exp += "82 88 null null null ; Is Leaf \n 90 92 null null null ; Is Leaf \n ";
            exp += "120 130 null null null ; Is Leaf \n ";
            Assert.AreEqual(exp, result);
        }
*/
        [TestMethod]
        public void TestMethod11()
        {
            Node x =
                new Node(2, new Int32[] { 31, 71, 0 }, new Node[] 
                    {new Node(1, new Int32[] { 12, 0, 0 }, new Node[] {
                        new Node(1, new Int32[] { 7, 0, 0 }, new Node[4], true),
                        new Node(2, new Int32[] { 25, 32, 0 }, new Node[4], true),
                        null, null }, false),

                    new Node(2, new Int32[] { 43, 63, 0 }, new Node[] {
                        new Node(2, new Int32[] { 38, 40, 0 }, new Node[4], true),
                        new Node(1, new Int32[] { 58, 0, 0 }, new Node[4], true), 
                        new Node(2, new Int32[] { 66, 69, 0 }, new Node[4], true), 
                        null }, false),

                    new Node(2, new Int32[] { 82, 89, 0}, new Node[] {
                        new Node(2, new Int32[] { 75, 76, 0 }, new Node[4], true),
                        new Node(1, new Int32[] { 88, 0, 0 }, new Node[4], true), 
                        new Node(3, new Int32[] { 90, 92, 93}, new Node[4], true),
                        null }, false), 
                    null }, false);

            Tree T = new Tree();
            bool result = T.Validator_Correct(x);
            Assert.AreEqual(false, result);
        }

    }
}
