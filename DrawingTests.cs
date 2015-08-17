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
	}
}

