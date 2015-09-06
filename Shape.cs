using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
	public class Shape
	{
		private Color _color;
		private float _x, _y;
		private bool _selected;

		//Constructor
		public Shape () : this (Color.White) {}

		public Shape (Color color)
		{
			_color = color;
		}

		//Properties/Accessors
		public Color Color 
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		public float X 
		{
			get
			{
				return _x;
			}
			set
			{
				_x = value;
			}

		}

		public float Y
		{
			get
			{
				return _y;
			}
			set
			{
				_y = value;
			}
		}

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
			}
		}

		//Methods

		//Draws the shape
		public virtual void Draw () {}

		public virtual void DrawOutline() {}

		//Check if a point on screen is within shape bounds
		public virtual bool IsAt (Point2D pt)
		{
//			if (SwinGame.PointInRect(pt, _x, _y, _width, _height))
//			{
//				return true;
//			}
//			else
//			{
//				return false;
//			}
			return false;
		}
	}
}

