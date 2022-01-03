using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TNT.Collections;

namespace Tests
{
   [TestClass]
   public class GraphEdgeTests
   {
      [TestMethod]
      public void OperatorEqualTest()
      {
         object eo1 = new object();
         object eo2 = new object();

         object no1 = new object();
         object no2 = new object();
         object no3 = new object();

         GraphNode<object, object> gn1 = new GraphNode<object, object>(no1);
         GraphNode<object, object> gn2 = new GraphNode<object, object>(no2);
         GraphNode<object, object> gn3 = new GraphNode<object, object>(no3);


         GraphEdge<object, object> ge1 = new GraphEdge<object, object>(eo1, gn1, gn2);
         GraphEdge<object, object> ge2 = new GraphEdge<object, object>(eo1, gn1, gn2);
         GraphEdge<object, object> ge3 = new GraphEdge<object, object>(eo2, gn2, gn3);

         Assert.IsFalse(ge1 == null);
         Assert.IsTrue(ge1 == ge1);
         Assert.IsTrue(ge1 == ge2);
         Assert.IsFalse(ge1 == ge3);

         Assert.IsTrue(ge1 == eo1);
         Assert.IsFalse(ge1 == eo2);

         Assert.IsTrue(eo1 == ge1);
         Assert.IsFalse(eo2 == ge2);

         Assert.IsTrue(ge1 != null);
         Assert.IsFalse(ge1 != ge1);
         Assert.IsFalse(ge1 != ge2);
         Assert.IsTrue(ge1 != ge3);

         Assert.IsFalse(ge1 != eo1);
         Assert.IsTrue(ge1 != eo2);

         Assert.IsFalse(eo1 != ge1);
         Assert.IsTrue(eo2 != ge2);
      }

      [TestMethod]
      public void EqualsTest()
      {
         object eo1 = new object();
         object eo2 = new object();

         object no1 = new object();
         object no2 = new object();
         object no3 = new object();

         GraphNode<object, object> gn1 = new GraphNode<object, object>(no1);
         GraphNode<object, object> gn2 = new GraphNode<object, object>(no2);
         GraphNode<object, object> gn3 = new GraphNode<object, object>(no3);


         GraphEdge<object, object> ge1 = new GraphEdge<object, object>(eo1, gn1, gn2);
         GraphEdge<object, object> ge2 = new GraphEdge<object, object>(eo1, gn1, gn2);
         GraphEdge<object, object> ge3 = new GraphEdge<object, object>(eo2, gn2, gn3);

         Assert.IsTrue(ge1.Equals(ge1));
         Assert.IsTrue(ge1.Equals(ge2));
         Assert.IsFalse(ge1.Equals(eo1));
         Assert.IsFalse(ge1.Equals(null));
         Assert.IsFalse(ge1.Equals(ge3));
      }

      [TestMethod]
      public void GetHashCodeTest()
      {
         object eo1 = new object();
         object no1 = new object();
         object no2 = new object();

         GraphNode<object, object> gn1 = new GraphNode<object, object>(no1);
         GraphNode<object, object> gn2 = new GraphNode<object, object>(no2);

         GraphEdge<object, object> ge1 = new GraphEdge<object, object>(eo1, gn1, gn2);

         Assert.AreEqual(eo1.GetHashCode(), ge1.GetHashCode());
      }

      [TestMethod]
      public void ConstructorTests()
      {
         object eo1 = new object();
         object no1 = new object();
         object no2 = new object();

         GraphNode<object, object> gn1 = new GraphNode<object, object>(no1);
         GraphNode<object, object> gn2 = new GraphNode<object, object>(no2);


         Assert.ThrowsException<ArgumentNullException>(() => new GraphEdge<object, object>(null, gn1, gn2));
      }

      [TestMethod]
      public void ConstructorTests1()
      {
         object eo1 = new object();
         object no1 = new object();
         object no2 = new object();

         GraphNode<object, object> gn1 = new GraphNode<object, object>(no1);
         GraphNode<object, object> gn2 = new GraphNode<object, object>(no2);

         Assert.ThrowsException<ArgumentNullException>(() => new GraphEdge<object, object>(eo1, null, gn2));

      }

      [TestMethod]
      public void ConstructorTests2()
      {
         object eo1 = new object();
         object no1 = new object();
         object no2 = new object();

         GraphNode<object, object> gn1 = new GraphNode<object, object>(no1);
         GraphNode<object, object> gn2 = new GraphNode<object, object>(no2);

         Assert.ThrowsException<ArgumentNullException>(() => new GraphEdge<object, object>(eo1, gn1, null));

      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void ConstructorTests3()
      {
         object eo1 = new object();
         object no1 = new object();
         object no2 = new object();

         GraphNode<object, object> gn1 = new GraphNode<object, object>(no1);
         GraphNode<object, object> gn2 = new GraphNode<object, object>(no2);

         try
         {
            new GraphEdge<object, object>(eo1, gn1, gn1);
         }
         catch (ArgumentException ae)
         {
            Assert.AreEqual("Arguments node1 and node2 can not be the same node", ae.Message);
            throw;
         }
      }

      [TestMethod]
      public void GetOppositeNodeTest()
      {
         object eo1 = new object();
         object no1 = new object();
         object no2 = new object();
         object no3 = new object();

         GraphNode<object, object> gn1 = new GraphNode<object, object>(no1);
         GraphNode<object, object> gn2 = new GraphNode<object, object>(no2);
         GraphNode<object, object> gn3 = new GraphNode<object, object>(no3);

         GraphEdge<object, object> ge1 = new GraphEdge<object, object>(eo1, gn1, gn2);

         Assert.ThrowsException<ArgumentNullException>(() => ge1.GetOppositeNode(null));

      }
   }
}
