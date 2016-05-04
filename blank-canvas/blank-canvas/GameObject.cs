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
        #region field and variables

        //the value that the alpha value will be divided by
        protected const float FADE_INCREMENT = .70f;

        //value used to instantiate the overlaying color
        protected int alpha; 

        protected Texture2D texture; 
        protected Vector2 position;
        protected int width;
        protected int height;

        #endregion

        #region constructor
        public GameObject(Rectangle rectangle)
        {
            width = rectangle.Width;
            height = rectangle.Height;
            position = new Vector2(rectangle.X, rectangle.Y);
            alpha = 255;
        }

        /// <summary>
        /// Constructor for projectile
        /// </summary>
        public GameObject(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        #endregion

        #region properties

        /// <summary>
        /// The center of the sprite
        /// </summary>
        public Vector2 Center
        {
            get { return new Vector2(X + width / 2, Y + height / 2); }
        }

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

        /// <summary>
        /// The point that represents the top-left corner of the object's AABB
        /// </summary>
        public Point Min
        {
            get { return position.ToPoint(); }
        }

        /// <summary>
        /// The point that represents the bottom-right corner of the object's AABB
        /// </summary>
        public Point Max
        {
            get { return new Point((int)position.X + width, (int)position.Y + height); }
        }

        /// <summary>
        /// The width of the object
        /// </summary>
        public int Width
        {
            get { return width; }
        }

        /// <summary>
        /// The height of the object
        /// </summary>
        public int Height
        {
            get { return height; }
        }
        #endregion

         #region methods

        /// <summary>
        /// The method that fades a sprite
        /// </summary>
        protected virtual void Fade()
        {
            if (alpha > 0)
                alpha = (int)(alpha * FADE_INCREMENT);
            else alpha = 0;
        }

        /// <summary>
        /// Basic draw method, doesn't draw if texture is not instantiated. 
        /// Default color is white.
        /// </summary>
        /// <param name="spriteBatch">The current spriteBatch</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rectangle, new Color(alpha,alpha,alpha,alpha));
        }

        #endregion
    }
}
