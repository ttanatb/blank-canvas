using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace blank_canvas
{
    /// <summary>
    /// The class that controls the camera movement based on the position of the player
    /// </summary>
    class Camera
    {
        //draws camera
        Matrix transform;
        //where we are looking
        Viewport view;
        //center of camera
        Vector2 centre;

        //for gui stats
        SpriteBatch spriteBatch;
        int redNum;
        int blueNum;
        int yellNum;

        //constructor
        public Camera(Viewport newView, GraphicsDevice g)
        {
            view = newView;
            transform = new Matrix();
            centre = Vector2.Zero;
            spriteBatch = new SpriteBatch(g);
        }

        //properties
        public Matrix Transform
        {
            get { return transform; }
        }

        /// <summary>
        /// Updates the view of the camera
        /// </summary>
        /// <param name="player">The player to center the camera at</param>
        public void Update(Player player)
        {
            centre = new Vector2(player.Center.X - view.Width / 2, player.Center.Y - view.Height / 2);
            //centre = new Vector2(player.X + (player.Width / 2) - 400, player.Y + (player.Height / 2) - 400);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));
        }

        //for gui stats box
        public void SortArr(int[] colorStats)
        {
            redNum = colorStats[0];
            blueNum = colorStats[1];
            yellNum = colorStats[2];
        }

        /// <summary>
        /// Draws out the GUI
        /// </summary>
        public void DrawStats(Texture2D testTexture, Texture2D heartHealth, Texture2D guiBox, SpriteFont testFont, String currColor, int health)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            //the box
            spriteBatch.Draw(guiBox, new Rectangle(20, 20, 143, 112), new Rectangle(0, 0, 143, 112),Color.Gray, 0f, Vector2.Zero, SpriteEffects.None, 1);


            //health
            int count = 0;
            for (int i = 0; i < health; i++)
            {
                spriteBatch.Draw(heartHealth, new Rectangle(26 + count, 15, 23, 38), new Rectangle(0, 0, 23, 38), Color.Pink, 0f, Vector2.Zero, SpriteEffects.None, 1);
                count += 27;
            }

            //color numbers
            //red
            spriteBatch.Draw(testTexture, new Rectangle(33, 60, 30, 30), new Rectangle(0, 0, 30, 30), Color.Salmon, 0f, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.DrawString(testFont, redNum + "", new Vector2(39, 68), Color.White);
            //blue
            spriteBatch.Draw(testTexture, new Rectangle(75, 60, 30, 30), new Rectangle(0, 0, 30, 30), Color.RoyalBlue, 0f, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.DrawString(testFont, blueNum + "", new Vector2(84, 68), Color.White);
            //yellow
            spriteBatch.Draw(testTexture, new Rectangle(120, 60, 30, 30), new Rectangle(0, 0, 30, 30), Color.Gold, 0f, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.DrawString(testFont, yellNum + "", new Vector2(128, 68), Color.White);


            //current color
            if (currColor == "Red")
            {
                spriteBatch.Draw(testTexture, new Rectangle(31, 100, 120, 23), new Rectangle(0, 0, 120, 23), Color.Salmon, 0f, Vector2.Zero, SpriteEffects.None, 1);
            }
            if (currColor == "Blue")
            {
                spriteBatch.Draw(testTexture, new Rectangle(31, 100, 120, 23), new Rectangle(0, 0, 120, 23), Color.RoyalBlue, 0f, Vector2.Zero, SpriteEffects.None, 1);
            }
            if (currColor == "Yellow")
            {
                spriteBatch.Draw(testTexture, new Rectangle(31, 100, 120, 23), new Rectangle(0, 0, 120, 23), Color.Gold, 0f, Vector2.Zero, SpriteEffects.None, 1);
            }
            spriteBatch.DrawString(testFont, "Current Color", new Vector2(52, 105), Color.White);


            spriteBatch.End();
        }

        /// <summary>
        /// Draws the background
        /// </summary>
        /// <param name="texture">The texture of the background</param>
        public void DrawBG(Texture2D texture)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, Vector2.Zero, Color.White);
            spriteBatch.End();
        }
    }
}
