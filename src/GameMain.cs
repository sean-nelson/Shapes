using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
    public class GameMain
    {
		private enum ShapeKind
		{
			Rectangle,
			Circle,
			Line
		}

        public static void Main()
        {
			ShapeKind kindToAdd = ShapeKind.Circle;

            //Start the audio system so sound can be played
            SwinGame.OpenAudio();
            
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
           // SwinGame.ShowSwinGameSplashScreen();

			Drawing myDrawing = new Drawing ();

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
				if (SwinGame.KeyTyped (KeyCode.vk_r))
				{
					kindToAdd = ShapeKind.Rectangle;
				}

				if (SwinGame.KeyTyped (KeyCode.vk_c))
				{
					kindToAdd = ShapeKind.Circle;
				}

				if (SwinGame.KeyTyped (KeyCode.vk_l))
				{
					kindToAdd = ShapeKind.Line;
				}

                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);

				//Change location of shape
				if (SwinGame.MouseClicked(MouseButton.LeftButton))
				{
					Shape newShape;

					if (kindToAdd == ShapeKind.Circle)
					{
						Circle newCircle = new Circle ();
						newShape = newCircle;
					}
					else if (kindToAdd == ShapeKind.Rectangle)
					{
						Rectangle newRect = new Rectangle ();
						newShape = newRect;
					}
					else
					{
						Line newLine = new Line ();
						newShape = newLine;
					}


					newShape.X = SwinGame.MouseX ();
					newShape.Y = SwinGame.MouseY ();

					myDrawing.AddShape (newShape);
				}

				if (SwinGame.MouseClicked (MouseButton.RightButton))
				{
					myDrawing.SelectShapesAt (SwinGame.MousePosition ());
				}

				//Check if mouse is within shape bounds and spacebar pressed
				//If true change color of shape to random RGB color
				if (SwinGame.KeyTyped(KeyCode.vk_SPACE))
				{
					myDrawing.BackgroundColor = SwinGame.RandomRGBColor (255);
				}

				if ((SwinGame.KeyTyped (KeyCode.vk_DELETE)) || (SwinGame.KeyTyped (KeyCode.vk_BACKSPACE)))
				{
					foreach (Shape s in myDrawing.SelectedShapes)
					{
						myDrawing.RemoveShape (s);
					}
				}
					
                SwinGame.DrawFramerate(0,0);

				myDrawing.Draw ();

                //Draw onto the screen
                SwinGame.RefreshScreen();
            }
            
            //End the audio
            SwinGame.CloseAudio();
            
            //Close any resources we were using
            SwinGame.ReleaseAllResources();
        }
    }
}