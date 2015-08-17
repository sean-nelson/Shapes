using NUnit.Framework;
using System;
using Color = System.Drawing.Color;
using SwinGameSDK;

namespace MyGame
{
	[TestFixture ()]
	public class ShapeTests
	{
		[Test ()]
		public void TestShapeAt ()
		{
			Shape s = new Shape ();

			s.X = 25;
			s.Y = 25;
			s.Width = 50;
			s.Height = 50;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (50, 50)));
			Assert.IsTrue (s.IsAt (SwinGame.PointAt (25, 25)));
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (10, 50)));
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (50, 10)));
		}

		[Test()]
		public void TestShapeAtWhenMoved ()
		{
			Shape s = new Shape ();

			s.X = 25;
			s.Y = 25;
			s.Width = 50;
			s.Height = 50;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (50, 50)));

			s.X = 100;
			s.Y = 100;

			Assert.IsFalse (s.IsAt (SwinGame.PointAt (50, 50)));
		}

		[Test()]
		public void TestShapeAtWhenResized ()
		{
			Shape s = new Shape ();

			s.X = 25;
			s.Y = 25;
			s.Width = 50;
			s.Height = 50;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (75, 75)));

			s.Width = 25;
			s.Height = 25;

			Assert.IsFalse (s.IsAt (SwinGame.PointAt (75, 75)));
		}

		[Test()]
		public void TestShapeValue ()
		{
			Shape s = new Shape ();
			Assert.IsFalse (s.Selected);

			s.Selected = true;
			Assert.IsTrue (s.Selected);

		}
	}
}

