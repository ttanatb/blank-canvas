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
            centre = new Vector2(player.X + (player.Width / 2) - 400, player.Y + (player.Height / 2) - 400);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));
        }

        //for gui stats box
        public void SortArr(int[] colorStats)
        {
            redNum = colorStats[0];
            blueNum = colorStats[1];
            yellNum = colorStats[2];
        }

        //for gui stats
        public void DrawStats(Texture2D testTexture, SpriteFont testFont, String currColor, int health)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            //the box
            spriteBatch.Draw(testTexture, new Rectangle(35, 30, 125, 110), new Rectangle(0, 0, 125, 110),Color.Gray, 0f, Vector2.Zero, SpriteEffects.None, 1);

            //red
            spriteBatch.Draw(testTexture, new Rectangle(45, 40, 25, 25), new Rectangle(0, 0, 25, 25), Color.Red, 0f, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.DrawString(testFont, redNum + "", new Vector2(50, 45), Color.White);
            //blue
            spriteBatch.Draw(testTexture, new Rectangle(85, 40, 25, 25), new Rectangle(0, 0, 25, 25), Color.Blue, 0f, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.DrawString(testFont, blueNum + "", new Vector2(90, 45), Color.White);
            //yellow
            spriteBatch.Draw(testTexture, new Rectangle(125, 40, 25, 25), new Rectangle(0, 0, 25, 25), Color.Yellow, 0f, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.DrawString(testFont, yellNum + "", new Vector2(130, 45), Color.White);

            //current color
            if(currColor == "Red")
            {
                spriteBatch.Draw(testTexture, new Rectangle(45, 72, 105, 25), new Rectangle(0, 0, 105, 20), Color.Red, 0f, Vector2.Zero, SpriteEffects.None, 1);
            }
            if (currColor == "Blue")
            {
                spriteBatch.Draw(testTexture, new Rectangle(45, 72, 105, 25), new Rectangle(0, 0, 105, 20), Color.Blue, 0f, Vector2.Zero, SpriteEffects.None, 1);
            }
            if (currColor == "Yellow")
            {
                spriteBatch.Draw(testTexture, new Rectangle(45, 72, 105, 25), new Rectangle(0, 0, 105, 20), Color.Yellow, 0f, Vector2.Zero, SpriteEffects.None, 1);
            }
            spriteBatch.DrawString(testFont, "Current Color", new Vector2(60, 78), Color.White);

            //health
            int count = 0;
            switch (health)
            {
                case 5:
                    for (int i = 0; i < health; i++)
                    {
                        spriteBatch.Draw(testTexture, new Rectangle(45 + count, 105, 15, 28), new Rectangle(0, 0, 15, 25), Color.Blue, 0f, Vector2.Zero, SpriteEffects.None, 1);
                        count += 22;
                    }
                    break;
                case 4:
                    for (int i = 0; i < health; i++)
                    {
                        spriteBatch.Draw(testTexture, new Rectangle(45 + count, 105, 15, 28), new Rectangle(0, 0, 15, 25), Color.Green, 0f, Vector2.Zero, SpriteEffects.None, 1);
                        count += 22;
                    }
                    break;
                case 3:
                    for (int i = 0; i < health; i++)
                    {
                        spriteBatch.Draw(testTexture, new Rectangle(45 + count, 105, 15, 28), new Rectangle(0, 0, 15, 25), Color.Yellow, 0f, Vector2.Zero, SpriteEffects.None, 1);
                        count += 22;
                    }
                    break;
                case 2:
                    for (int i = 0; i < health; i++)
                    {
                        spriteBatch.Draw(testTexture, new Rectangle(45 + count, 105, 15, 28), new Rectangle(0, 0, 15, 25), Color.Orange, 0f, Vector2.Zero, SpriteEffects.None, 1);
                        count += 22;
                    }
                    break;
                case 1:
                    for (int i = 0; i < health; i++)
                    {
                        spriteBatch.Draw(testTexture, new Rectangle(45 + count, 105, 15, 28), new Rectangle(0, 0, 15, 25), Color.Red, 0f, Vector2.Zero, SpriteEffects.None, 1);
                        count += 22;
                    }
                    break;
                default:
                    for (int i = 0; i < health; i++)
                    {
                        spriteBatch.Draw(testTexture, new Rectangle(45 + count, 105, 15, 28), new Rectangle(0, 0, 15, 25), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1);
                        count += 22;
                    }
                    break;
            }


            spriteBatch.End();
        }
    }
}
