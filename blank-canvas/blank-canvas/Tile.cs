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
        public Tile(Vector2 position) : base(new Rectangle((int)position.X, (int)position.Y,WIDTH, HEIGHT))
        {
            
        }

        #endregion

        #region methods



        #endregion
    }
}
