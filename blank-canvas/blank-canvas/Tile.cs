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
    /// A basic tile that makes up the walls and floors
    /// 
    /// Needs work: Complete collision
    /// </summary>
    class Tile : GameObject
    {
        #region constants
        const int WIDTH = 64;   
        const int HEIGHT = 64;
        #endregion

        #region constructors
        /// <param name="position">X and Y coordinates of top-left corner</param>
        public Tile(Vector2 position)
        {
            rectangle = new Rectangle((int)position.X,(int)position.Y, WIDTH, HEIGHT);
            this.position = position;
            color = Color.White;
        }

        /// <param name="position">X and Y coordinates of top-left corner</param>
        /// <param name="color">Color of the object</param>
        public Tile(Vector2 position, Color color)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT);
            this.position = position;
            this.color = color;
        }

        /// <param name="position">X and Y coordinates of top-left corner</param>
        /// <param name="texture">Texture of the object</param>
        public Tile(Vector2 position, Texture2D texture)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT);
            this.position = position;
            this.texture = texture;
            color = Color.White;
        }

        /// <param name="position">X and Y coordinates of top-left corner</param>
        /// <param name="texture">Texture of the object</param>
        /// <param name="color">Color of the object</param>
        public Tile(Vector2 position, Texture2D texture, Color color)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT);
            this.position = position;
            this.texture = texture;
            this.color = color;
        }

        // do we need all of these 
        public Tile(Rectangle rectangle, Color color) : base (rectangle, color)
        {
            
        }

        public Tile(Texture2D texture, Rectangle rectangle) : base (texture, rectangle)
        {

        }

        public Tile(Texture2D texture, Rectangle rectangle, Color color) : base (texture, rectangle, color)
        {

        }

        #endregion

        #region methods

        /// <summary>
        /// Checks collision with each of the character's collision boxes
        /// </summary>
        /// <param name="character">Character to check collision with</param>
        /// <returns>Returns true if there is collision</returns>
        public bool CheckCollision(Character character)
        {
            foreach(Rectangle r in character.CollisionBoxes)
            {
                if (r.Intersects(this.Rectangle))
                    return true;
            }
            return false;
        }

        #endregion
    }
}
