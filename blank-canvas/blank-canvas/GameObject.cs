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
        protected Rectangle rectangle;
        protected Color color;
        #endregion

        #region constructor
        /// <param name="rectangle">Target Rectangle</param>
        public GameObject(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            position = new Vector2(rectangle.X, rectangle.Y);
            color = Color.White;
        }

        /// <param name="rectangle">Target Rectangle</param>
        /// <param name="color">Color of the object</param>
        public GameObject(Rectangle rectangle, Color color)
        {
            this.rectangle = rectangle;
            position = new Vector2(rectangle.X, rectangle.Y);
            this.color = color;
        }

        /// <param name="texture">Texture of the object</param>
        /// <param name="position">Position of the object</param>
        public GameObject(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            rectangle = new Rectangle((int)position.X,
                (int)position.Y, texture.Width, texture.Height);
            color = Color.White;
        }

        /// <param name="texture">Texture of the object</param>
        /// <param name="position">Position of the object</param>
        /// <param name="color">Color of object</param>
        public GameObject(Texture2D texture, Vector2 position, Color color)
        {
            this.texture = texture;
            this.position = position;
            rectangle = new Rectangle((int)position.X,
                (int)position.Y, texture.Width, texture.Height);
            this.color = color;
        }

        /// <param name="texture">Texture of the object</param>
        /// <param name="rectangle">Target rectangle</param>
        public GameObject(Texture2D texture, Rectangle rectangle)
        {
            this.texture = texture;
            position = new Vector2((float)rectangle.X, (float)rectangle.Y);
            this.rectangle = rectangle;
            color = Color.White;
        }

        /// <param name="texture">Texture of the object</param>
        /// <param name="rectangle">Target rectangle</param>
        /// <param name="color">Color of object</param>
        public GameObject(Texture2D texture, Rectangle rectangle, Color color)
        {
            this.texture = texture;
            position = new Vector2((float)rectangle.X, (float)rectangle.Y);
            this.rectangle = rectangle;
            this.color = color;
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
            get { return rectangle; }
            set { rectangle = value; }
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
        /// The color of the object
        /// </summary>
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        #endregion

        #region methods
        /// <summary>
        /// Basic draw method, doesn't draw if texture is not instantiated. 
        /// Default color is white.
        /// </summary>
        /// <param name="spriteBatch">The current spriteBatch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
            {
                if (color != null)
                    spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, rectangle.Width, rectangle.Height), color);
                else spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, rectangle.Width, rectangle.Height), Color.White);
            }
        }
        #endregion
    }
}
