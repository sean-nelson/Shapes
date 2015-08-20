using NUnit.Framework;
using System;
using System.Collections.Generic;
using Color = System.Drawing.Color;
using SwinGameSDK;

namespace MyGame
{
	[TestFixture ()]
	public class DrawingTests
	{
		[Test ()]
		public void TestDefaultInitialisation ()
		{
			Drawing d = new Drawing();

			Assert.IsTrue (d.BackgroundColor == Color.White);
		}

		[Test()]
		public void TestInitialiseWithColor ()
		{
			Drawing d = new Drawing (Color.Red);

			Assert.IsTrue (d.BackgroundColor == Color.Red);
		}

		[Test()]
		public void TestAddShape () 
		{
			Drawing myDrawing = new Drawing ();
			int count = myDrawing.ShapeCount;

			Assert.AreEqual (0, count, "Drawing should start with no shapes");

			myDrawing.AddShape (new Shape ());
			myDrawing.AddShape (new Shape ());
			count = myDrawing.ShapeCount;

			Assert.AreEqual (2, count, "Adding two shapes should increase the count to 2");
		}

		[Test()]
		public void TestSelectShape()
		{
			Drawing myDrawing = new Drawing();

			Shape[] testShapes = 
			{
				new Shape(Color.Red, 25, 25, 50, 50),
				new Shape(Color.Green, 25, 10, 50, 50),
				new Shape(Color.Blue, 10, 25, 50, 50) 
			};
			
			foreach(Shape s in testShapes) myDrawing.AddShape( s );

			List<Shape> selected;
			Point2D point;

			point = SwinGame.PointAt( 70, 70 );
			myDrawing.SelectShapesAt( point );
			selected = myDrawing.SelectedShapes;
			CollectionAssert.Contains( selected, testShapes[0] );
			Assert.AreEqual( 1, selected.Count );

			point = SwinGame.PointAt( 70, 50 );
			myDrawing.SelectShapesAt( point );
			selected = myDrawing.SelectedShapes;
			CollectionAssert.Contains( selected, testShapes[0] );
			CollectionAssert.Contains( selected, testShapes[1] );
			Assert.AreEqual( 2, selected.Count ); 
		}

		[Test()]
		public void TestRemoveShape()
		{
			Drawing myDrawing = new Drawing ();

			Shape myShape1 = new Shape (Color.Red, 100, 100, 10, 50);
			Shape myShape2 = new Shape (Color.Green, 100, 100, 50, 50);
			Shape myShape3 = new Shape (Color.Blue, 100, 100, 50, 10);

			myDrawing.AddShape (myShape1);
			myDrawing.AddShape (myShape2);
			myDrawing.AddShape (myShape3);

			Point2D pt = SwinGame.PointAt (100, 100);

			Assert.AreEqual (3, myDrawing.ShapeCount);

			myDrawing.RemoveShape (myShape2);

			Assert.AreEqual (2, myDrawing.ShapeCount);

			myDrawing.SelectShapesAt(pt);

			(myDrawing.SelectedShapes, myDrawing));

		}
	}
}