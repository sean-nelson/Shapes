using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            //Start the audio system so sound can be played
            SwinGame.OpenAudio();
            
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
           // SwinGame.ShowSwinGameSplashScreen();

			Drawing myDrawing = new Drawing ();

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);

				//Change location of shape
				if (SwinGame.MouseClicked(MouseButton.LeftButton))
				{
					Shape myShape = new Shape ();
					myDrawing.AddShape (myShape);
					myShape.X = SwinGame.MouseX ();
					myShape.Y = SwinGame.MouseY ();
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