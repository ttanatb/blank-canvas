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

        //for gui stats
        public void DrawStats(Texture2D testTexture)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            //spriteBatch.Draw(testTexture, new Rectangle(50, 40, 300, 70), Color.Lavender);
            spriteBatch.Draw(testTexture, new Rectangle(50, 40, 300, 70), new Rectangle(0,0,300,70),Color.Lavender, 0f, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.End();
        }
    }
}
