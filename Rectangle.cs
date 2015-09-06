using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
	public class Rectangle : Shape
	{
		private int _width, _height;

		public Rectangle () : this (Color.Green, 0, 0, 100, 100) {}

		public Rectangle (Color color, float x, float y, int width, int height) : base (color)
		{
			Color = color;
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		public int Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
			}
		}

		public int Height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
			}
		}

		public override void Draw ()
		{
			if (Selected)
			{
				DrawOutline ();
			}
			SwinGame.FillRectangle (Color, X, Y, _width, _height);
		}

		public override void DrawOutline ()
		{
			SwinGame.DrawRectangle (Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
		}

		public override bool IsAt (Point2D pt)
		{
			if (SwinGame.PointInRect (pt, X, Y, _width, _height))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

