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
		private int _width, _height;
		private bool _selected;

		//Constructor
		public Shape ()
		{
			_color = Color.Green;
			_x = 0;
			_y = 0;
			_width = 100;
			_height = 100;
			_selected = false;
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
		public void Draw ()
		{
			SwinGame.FillRectangle (_color, _x, _y, _width, _height);
		}

		//Check if a point on screen is within shape bounds
		public bool IsAt (Point2D pt)
		{
			if (SwinGame.PointInRect(pt, _x, _y, _width, _height))
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

