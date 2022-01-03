using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TNT.Collections;

namespace Tests
{
	[TestClass]
	public class GraphTests
	{
		[TestMethod]
		public void ConstructorTests()
		{
			Graph<object, object> g = new Graph<object, object>();
			Assert.IsFalse(g.AllowCircularLinks);

			g = new Graph<object, object>(true);
			Assert.IsTrue(g.AllowCircularLinks);
		}

		[TestMethod]
		public void CreateEdgeTestValidParameters()
		{
			object eo1 = new object();
			object eo2 = new object();
			object no1 = new object();
			object no2 = new object();

			Graph<object, object> g = new Graph<object, object>();

			Assert.ThrowsException<ArgumentNullException>(() => g.CreateEdge(null, no1, no2));
		}

		[TestMethod]
		public void CreateEdgeTestValidParameters1()
		{
			object eo1 = new object();
			object eo2 = new object();
			object no1 = new object();
			object no2 = new object();

			Graph<object, object> g = new Graph<object, object>();
			Assert.ThrowsException<ArgumentNullException>(() => g.CreateEdge(eo1, null, no2));
		}

		[TestMethod]
		public void CreateEdgeTestValidParameters2()
		{
			object eo1 = new object();
			object eo2 = new object();
			object no1 = new object();
			object no2 = new object();

			Graph<object, object> g = new Graph<object, object>();

			Assert.ThrowsException<ArgumentNullException>(() => g.CreateEdge(eo1, no1, null));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void CreateEdgeTestValidParameters3()
		{
			object eo1 = new object();
			object eo2 = new object();
			object no1 = new object();
			object no2 = new object();

			Graph<object, object> g = new Graph<object, object>();

			try
			{
				g.CreateEdge(eo1, no1, no1);
			}
			catch (ArgumentException ae)
			{
				Assert.AreEqual("Arguments nodeObj1 and nodeObj2 can not be the same object", ae.Message);
				throw;
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void CreateEdgeTestExistingEdgeNode()
		{
			object eo1 = new object();
			object eo2 = new object();
			object no1 = new object();
			object no2 = new object();

			Graph<object, object> g = new Graph<object, object>(true);

			GraphEdge<object, object> edge = g.CreateEdge(eo1, no1, no2);

			Assert.AreEqual(eo1, edge.Object);

			try
			{
				g.CreateEdge(eo1, no1, no2);
			}
			catch (ArgumentException ae)
			{
				Assert.AreEqual("edgeObj is already bound to an edge", ae.Message);
				throw;
			}
		}
		

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void CreateEdgeTestCircularLink()
		{
			object eo1 = new object();
			object eo2 = new object();
			object eo3 = new object();
			object no1 = new object();
			object no2 = new object();
			object no3 = new object();

			Graph<object, object> g = new Graph<object, object>();

			g.CreateEdge(eo1, no1, no2);
			g.CreateEdge(eo2, no2, no3);

			try
			{
				g.CreateEdge(eo3, no3, no1);
			}
			catch (ArgumentException ae)
			{
				Assert.AreEqual("Circular link not allowed", ae.Message);
				throw;
			}
		}


		[TestMethod]
		public void FindGraphNodeTest()
		{
			Graph<object, object> g = new Graph<object, object>();
			GraphNode<object, object> gn = g.FindGraphNode(new object());
			Assert.IsNull(gn);

			gn = g.FindGraphNode(null);
			Assert.IsNull(gn);
		}

		[TestMethod]
		public void FindEdgeNodeTest()
		{
			Graph<object, object> g = new Graph<object, object>();
			GraphEdge<object, object> ge = g.FindGraphEdge(new object());
			Assert.IsNull(ge);

			ge = g.FindGraphEdge(null);
			Assert.IsNull(ge);
		}

		[TestMethod]
		public void FindConnectedNodeTest()
		{
			object eo1 = new object();
			object eo2 = new object();
			object eo3 = new object();
			object eo4 = new object();
			object no1 = new object();
			object no2 = new object();
			object no3 = new object();
			object no4 = new object();

			Graph<object, object> g = new Graph<object, object>();

			GraphEdge<object, object> e1 = g.CreateEdge(eo1, no1, no2);
			GraphEdge<object, object> e2 = g.CreateEdge(eo2, no2, no3);
			GraphEdge<object, object> e3 = g.CreateEdge(eo3, no2, no4);

			Assert.ThrowsException<ArgumentNullException>(() => g.FindConnectedNode(null, null, true));
		}
	}
}
