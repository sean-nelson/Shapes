using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
	public class Circle : Shape
	{
		private int _radius;

		public Circle () : this (50) {}

		public Circle (int radius)
		{
			_radius = radius;
		}

		public int Radius 
		{
			get
			{
				return _radius;
			}
			set
			{
				_radius = value;
			}
		}

		public override void Draw ()
		{
			if (Selected)
			{
				DrawOutline ();
			}
			SwinGame.FillCircle (Color, X, Y, _radius);
		}

		public override void DrawOutline ()
		{
			SwinGame.DrawCircle (Color.Black, X, Y, _radius + 2);
		}

		public override bool IsAt (Point2D pt)
		{
			if (SwinGame.PointInCircle (pt, X, Y, _radius))
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

