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
    /// <para>The parent class of all objects in the game</para>
    /// </summary>
    public class GameObject
    {

        //doesn't yet handle multiple textures

        #region variables
        protected Texture2D texture;
        protected Vector2 position;
        protected Color color;
        protected int width;
        protected int height;
        #endregion

        #region constructor
        /// <param name="rectangle">Target Rectangle</param>
        public GameObject(Rectangle rectangle)
        {
            width = rectangle.Width;
            height = rectangle.Height;
            position = new Vector2(rectangle.X, rectangle.Y);
            color = Color.White;
        }

        public GameObject()
        {

        }

        #endregion

        #region properties
        /// <summary>
        /// The X position of upper left corner
        /// </summary>
        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }
        
        /// <summary>
        /// The Y position of the upper left corner
        /// </summary>
        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        /// <summary>
        /// The rectangle
        /// </summary>
        public Rectangle Rectangle
        {
            get { return new Rectangle((int)X,(int)Y,width,height); }
        }

        /// <summary>
        /// The current texture
        /// </summary>
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public Point Min
        {
            get { return position.ToPoint(); }
        }

        public Point Max
        {
            get { return new Point((int)position.X + width, (int)position.Y + height); }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }
        #endregion

        #region methods
        /// <summary>
        /// Basic draw method, doesn't draw if texture is not instantiated. 
        /// Default color is white.
        /// </summary>
        /// <param name="spriteBatch">The current spriteBatch</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
            {
                if (color != null)
                    spriteBatch.Draw(texture, Rectangle, color);
                else spriteBatch.Draw(texture, Rectangle, Color.White);
            }
        }
        #endregion
    }
}
