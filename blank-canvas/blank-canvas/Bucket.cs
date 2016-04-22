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
    /// The data structure that represents 
    /// </summary>
    class Bucket
    {
        int red;
        int blue;
        int yellow;
        PaletteColor currentColor;
        Projectile projectile;

        public Bucket()
        {
            projectile = new Projectile(this);
            red = 1;
            blue = 1;
            yellow = 1;
            currentColor = PaletteColor.Red;
        }

        public int Red
        {
            get { return red; }
        }

        public int Blue
        {
            get { return blue; }
        }

        public int Yellow
        {
            get { return yellow; }
        }

        public PaletteColor CurrentColor
        {
            get { return currentColor; }
        }

        public Projectile Projectile
        {
            get { return projectile; }
        }

        public void AddColor(Enemy enemy)
        {
            PaletteColor color = enemy.DrainColor();
            DistributeColor(color);
        }

        public void AddColor(PuzzleOrb puzzleOrb)
        {
            PaletteColor color = puzzleOrb.DrainColor();
            DistributeColor(color);
        }

        /// <summary>
        /// switches through red blue yellow
        /// </summary>
        public void SwitchRBY()
        {
            if (blue == 0 && red == 0 && yellow == 0)
                return;

            switch (currentColor)
            {
                case PaletteColor.Red:
                    if (blue > 0)
                        currentColor = PaletteColor.Blue;
                    else goto case PaletteColor.Blue;
                    break;

                case PaletteColor.Blue:
                    if (yellow > 0)
                        currentColor = PaletteColor.Yellow;
                    else goto case PaletteColor.Yellow;
                    break;

                case PaletteColor.Yellow:
                    if (red > 0)
                        currentColor = PaletteColor.Red;
                    else goto case PaletteColor.Red;
                    break;
            }
        }

        /// <summary>
        /// switches through yellow blue red
        /// </summary>
        public void SwitchYBR()
        {
            if (blue == 0 && red == 0 && yellow == 0)
                return;

            switch (currentColor)
            {
                case PaletteColor.Yellow:
                    if (blue > 0)
                        currentColor = PaletteColor.Blue;
                    else goto case PaletteColor.Blue;
                    break;
                case PaletteColor.Blue:
                    if (red > 0)
                        currentColor = PaletteColor.Red;
                    else goto case PaletteColor.Red;
                    break;
                case PaletteColor.Red:
                    if (yellow > 0)
                        currentColor = PaletteColor.Yellow;
                    else goto case PaletteColor.Yellow;
                    break;
            }
        }

        private void DistributeColor(PaletteColor color)
        {
            int r = (int)color % 2;
            int b = (int)color % 3;
            int y = (int)color % 5;

            if (r == 0)
                red++;
            if (b == 0)
                blue++;
            if (y == 0)
                yellow++;
        }

        public void Shoot(Player player)
        {
            if (!(blue == 0 && red == 0 && yellow == 0))
            {
                Vector2 startingPos;
                if (player.Direction == Direction.Right)
                    startingPos = new Vector2(player.Max.X, player.Y + player.Height / 3 + Projectile.HEIGHT);
                else startingPos = new Vector2(player.X - Projectile.WIDTH, player.Y + player.Height / 3 + Projectile.HEIGHT);

                //deal with the color thing with the bucket

                projectile.Shoot(startingPos, player.Direction, currentColor);
            }

        }

        public PaletteColor UsePaint()
        {
            switch(currentColor)
            {
                case PaletteColor.Red:
                    if (red > 0)
                    {
                        red--;
                        if (red == 0)
                            SwitchRBY();
                        return PaletteColor.Red;
                    }
                    break;
                case PaletteColor.Blue:
                    if (blue > 0)
                    {
                        blue--;
                        if (blue == 0)
                            SwitchRBY();
                        return PaletteColor.Blue;
                    }
                    break;
                case PaletteColor.Yellow:
                    if (yellow > 0)
                    {
                        yellow--;
                        if (yellow == 0)
                            SwitchRBY();
                        return PaletteColor.Yellow;
                    }
                    break;
            }
            return PaletteColor.White;
        }

        public override string ToString()
        {
            string msg = "";
            msg += "Red: " + red + " Blue: " + blue + " Yellow: " + yellow;
            msg += "\nCurrent color: " + currentColor;
            return msg;
        }
    }
}
