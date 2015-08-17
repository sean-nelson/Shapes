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
            SwinGame.ShowSwinGameSplashScreen();
         	
			Shape myShape = new Shape();

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);

				//Draw shape object
				myShape.Draw ();

				//Change location of shape
				if (SwinGame.MouseClicked(MouseButton.LeftButton))
				{
					myShape.X = SwinGame.MouseX ();
					myShape.Y = SwinGame.MouseY ();
				}

				//Check if mouse is within shape bounds and spacebar pressed
				//If true change color of shape to random RGB color
				if (myShape.IsAt (SwinGame.MousePosition()) && SwinGame.KeyTyped(KeyCode.vk_SPACE))
				{
					myShape.Color = SwinGame.RandomRGBColor (255);
				}

                SwinGame.DrawFramerate(0,0);
                
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