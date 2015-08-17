using System;
using System.Collections.Generic;
using Color = System.Drawing.Color;
using SwinGameSDK;

namespace MyGame
{
	public class Drawing
	{
		private readonly List<Shape> _shapes;
		private Color _background;

		//Constructor
		public Drawing (Color background)
		{
			_shapes = new List<Shape> ();
			_background = background;
		}

		//Default constructor
		public Drawing () : this (Color.White)
		{

		}

		//Properties
		public int ShapeCount
		{
			get
			{
				return _shapes.Count;
			}
		}

		public Color BackgroundColor
		{
			get
			{
				return _background;
			}
		}
			
		//Methods
		public void AddShape (Shape shape)
		{
			_shapes.Add (shape);
		}
	}
}

