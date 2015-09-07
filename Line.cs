using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
	public class Line : Shape
	{
		private float _endX, _endY;

		public Line () : this (Color.Blue, SwinGame.MouseX() + 40, SwinGame.MouseY() + 40) {}

		public Line (Color color, float endX, float endY)
		{
			Color = color;
			_endX = endX;
			_endY = endY;
		}

		public float EndX 
		{
			get
			{
				return _endX;
			}
			set
			{
				_endX = value;
			}
		}

		public float EndY 
		{
			get
			{
				return _endY;
			}
			set
			{
				_endY = value;
			}
		}

		public override void Draw ()
		{
			if (Selected)
			{
				DrawOutline ();
			}
			SwinGame.DrawLine (Color, X, Y, _endX, _endY);
		}

		public override void DrawOutline ()
		{
			SwinGame.DrawCircle (Color.Black, X, Y, 5);
			SwinGame.DrawCircle (Color.Black, _endX, _endY, 5);
			//SwinGame.DrawRectangle (Color.Black, X - 1, Y - 1, _endX - X, 3); 
		}

		public override bool IsAt (Point2D pt)
		{
			return SwinGame.PointOnLine (pt, X, Y, _endX, _endY);
		}
	}
}

