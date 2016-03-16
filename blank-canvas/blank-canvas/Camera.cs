using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace blank_canvas
{
    class Camera
    {
        //draws camera
        public Matrix transform;
        //where we are looking
        Viewport view;
        //center of camera
        Vector2 centre;

        public Camera(Viewport newView)
        {
            view = newView;
        }

        public void Update(GameTime gameTime, Game1 ship)
        {
            centre = new Vector2(ship.spritePosition.X + (ship.spriteRectangle.Width / 2) - 400, ship.spritePosition.Y + (ship.spriteRectangle.Height / 2) - 400);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));

        }
    }
}
