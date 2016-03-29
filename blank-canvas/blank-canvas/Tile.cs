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
        Point gridPos;
        #endregion

        #region Properties
        public Point GridPosition
        {
            get { return gridPos; }
        }
        #endregion

        #region constructors
        /// <param name="position">X and Y coordinates of top-left corner</param>
        public Tile(Vector2 position) : base(new Rectangle((int)position.X, (int)position.Y,WIDTH, HEIGHT))
        {
            gridPos = new Point((int)position.X / 64, (int)position.Y / 64);
        }
        
        #endregion

        #region methods
        public bool CheckCollision(Player player)
        {

            if ((Max.Y >= player.Min.Y) && (Min.Y < player.Max.Y) && (Max.X > player.Min.X) && (Min.X < player.Max.X))
                return true;
            
            else return false;
        }

        //used for testing
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            Draw(spriteBatch);
            spriteBatch.DrawString(font, "(" + gridPos.X + ", " + gridPos.Y + ")", position, Color.White);

        }

        public Vector2 DistanceToChar(Character character)
        {
            return new Vector2(character.X - X, character.Y - Y);
        }


        #endregion
    }
}
