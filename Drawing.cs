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
			set
			{
				_background = value;
			}
		}

		public List<Shape> SelectedShapes
		{
			get
			{
				List<Shape> result = new List<Shape> ();

				foreach ( Shape s in _shapes)
				{
					if (s.Selected)
					{
						result.Add(s);
					}
				}

				return result;
			}
		}
			
		//Methods
		public void AddShape (Shape shape)
		{
			_shapes.Add (shape);
		}

		public void Draw()
		{
			SwinGame.ClearScreen(_background);

			foreach (Shape s in _shapes)
			{
				s.Draw ();
			}

		}

		public void SelectShapesAt (Point2D pt)
		{
			foreach (Shape s in _shapes)
			{
				s.Selected = s.IsAt (pt);
			}
		}

		public void RemoveShape (Shape shape)
		{
			_shapes.Remove (shape);
		}
	}
}

