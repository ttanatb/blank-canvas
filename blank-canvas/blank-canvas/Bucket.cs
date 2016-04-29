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
    /// The data structure that represents the paint values of the player
    /// </summary>
    class Bucket
    {
        #region variables

        //the amount of primary color paint
        int red;
        int blue;
        int yellow;

        //the current color that's being used
        PaletteColor currentColor;

        //an instance of a projectile
        Projectile projectile;

        #endregion

        #region constructor

        public Bucket()
        {
            //instantializes the projectile
            projectile = new Projectile(this);

            //right now it sets everything at 1 for testing
            red = 0;
            blue = 0;
            yellow = 0;

            //an initial color
            currentColor = PaletteColor.Red;
        }

        #endregion

        #region properties
        /// <summary>
        /// To be used for the GUI
        /// </summary>
        public int Red
        {
            get { return red; }
        }

        /// <summary>
        /// To be used for the GUI
        /// </summary>
        public int Blue
        {
            get { return blue; }
        }

        /// <summary>
        /// To be used for the GUI
        /// </summary>
        public int Yellow
        {
            get { return yellow; }
        }

        /// <summary>
        /// To be used for the GUI
        /// </summary>
        public PaletteColor CurrentColor
        {
            get { return currentColor; }
        }

        /// <summary>
        /// An instance of the projectile class
        /// </summary>
        public Projectile Projectile
        {
            get { return projectile; }
        }

        #endregion

        #region methods

        /// <summary>
        /// Adds a color by draining an enemy's color
        /// </summary>
        /// <param name="enemy">The enemy to drain the color of</param>
        public void AddColor(Enemy enemy)
        {
            PaletteColor color = enemy.DrainColor();
            DistributeColor(color);
        }

        /// <summary>
        /// Adds a color by draining a puzzle orb's color
        /// </summary>
        /// <param name="enemy">The puzzle orb to drain the color of</param>
        public void AddColor(PuzzleOrb puzzleOrb)
        {
            PaletteColor color = puzzleOrb.DrainColor();
            DistributeColor(color);
        }

        /// <summary>
        /// Distributes the given color by its primary colors
        /// </summary>
        /// <param name="color">Color to distribute</param>
        private void DistributeColor(PaletteColor color)
        {
            //if a color is divisible by 2 it contains red
            int r = (int)color % 2;

            //if a color is divisible by 3 it contains blue
            int b = (int)color % 3;

            //if a color is divisible by 5 it contains yellow
            int y = (int)color % 5;

            //increments the current paint amount based on the divisibility
            if (r == 0)
                red++;
            if (b == 0)
                blue++;
            if (y == 0)
                yellow++;
        }

        /// <summary>
        /// Switches in the order of red, blue, yellow, then back to red
        /// </summary>
        public void SwitchRBY()
        {
            //checks to make sure there are any paint left
            if (blue == 0 && red == 0 && yellow == 0)
                return;

            switch (currentColor)
            {
                case PaletteColor.Red:
                    //switches to blue if it exists
                    if (blue > 0)
                    {
                        currentColor = PaletteColor.Blue;
                        break;
                    }

                    //otherwise move to case of blue
                    else goto case PaletteColor.Blue;

                case PaletteColor.Blue:
                    //switches to yellow
                    if (yellow > 0)
                    {
                        currentColor = PaletteColor.Yellow;
                        break;
                    }

                    //otherwise move to the case of yellow
                    else goto case PaletteColor.Yellow;

                case PaletteColor.Yellow:
                    //switches to red
                    if (red > 0)
                    {
                        currentColor = PaletteColor.Red;
                        break;
                    }

                    //otherwise move to the case of red
                    else goto case PaletteColor.Red;
            }
        }

        /// <summary>
        /// Switches through the order of yellow, blue, red, then back to yellow
        /// </summary>
        public void SwitchYBR()
        {
            if (blue == 0 && red == 0 && yellow == 0)
                return;

            switch (currentColor)
            {
                case PaletteColor.Yellow:
                    //switches to blue if it exists
                    if (blue > 0)
                    {
                        currentColor = PaletteColor.Blue;
                        break;
                    }

                    //otherwise move to case of blue
                    else goto case PaletteColor.Blue;

                case PaletteColor.Blue:
                    //switches to yellow
                    if (red > 0)
                    {
                        currentColor = PaletteColor.Red;
                        break;
                    }

                    //otherwise move to the case of yellow
                    else goto case PaletteColor.Red;

                case PaletteColor.Red:
                    //switches to red
                    if (yellow > 0)
                    {
                        currentColor = PaletteColor.Yellow;
                        break;
                    }

                    //otherwise move to the case of red
                    else goto case PaletteColor.Yellow;
            }
        }

        /// <summary>
        /// Shoots out a projectile
        /// </summary>
        /// <param name="player">The player position to start the projectile</param>
        public void Shoot(Player player)
        {
            //makes sure that there actually is paint
            switch (currentColor)
            {
                case PaletteColor.Blue:
                    if (blue == 0)
                        return;
                    else break;
                case PaletteColor.Red:
                    if (red == 0)
                        return;
                    else break;
                case PaletteColor.Yellow:
                    if (yellow == 0)
                        return;
                    else break;
            }

            //starting position
            Vector2 startingPos;

            //starting position depends on the current position
            if (player.Direction == Direction.Right)
                startingPos = new Vector2(player.Max.X - Player.RIGHT_MARGIN, player.Y + player.Height / 3 + Projectile.HEIGHT);
            else startingPos = new Vector2(player.X - Projectile.WIDTH + Player.RIGHT_MARGIN, player.Y + player.Height / 3 + Projectile.HEIGHT);

            projectile.Shoot(startingPos, player.Direction, currentColor);
        }

        /// <summary>
        /// Uses up a color based on the current color
        /// </summary>
        /// <returns></returns>
        public void UsePaint()
        {
            //uses up paint only if it exists
            //if paint is used up, it cycles to the next one
            switch(currentColor)
            {
                case PaletteColor.Red:
                    if (red > 0)
                    {
                        red--;
                        if (red == 0)
                            SwitchRBY();
                        return;
                    }
                    break;
                case PaletteColor.Blue:
                    if (blue > 0)
                    {
                        blue--;
                        if (blue == 0)
                            SwitchRBY();
                        return;
                    }
                    break;
                case PaletteColor.Yellow:
                    if (yellow > 0)
                    {
                        yellow--;
                        if (yellow == 0)
                            SwitchRBY();
                        return;
                    }
                    break;
            }
        }

        /// <summary>
        /// Shows the current paint values and current color
        /// </summary>
        public override string ToString()
        {
            string msg = "";
            msg += "Red: " + red + " Blue: " + blue + " Yellow: " + yellow;
            msg += "\nCurrent color: " + currentColor;
            return msg;
        }

        #endregion
    }
}
