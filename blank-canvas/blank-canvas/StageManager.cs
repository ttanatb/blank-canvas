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
    /// The StageManager starts with the stageReader. The stageReader will determine the tiles needed and the enemies to instantiate
    /// </summary>
    class StageManager
    {
        #region variables
        StageReader stageReader;
        InputManager input;

        Player player;
        Enemy[] enemies;
        Tile[,] tiles;

        int level;

        const float GRAVITY = 1200f;
        #endregion

        public StageManager()
        {
            input = new InputManager();
            stageReader = new StageReader();
            level = 0;
            
            //do stage reader things

            //calls construct stage method(?)
        }

        public void Update(double deltaTime)
        {
            deltaTime = deltaTime / 1000.0;

            //update position of characters
            //updates acc based on input
            //updates enemy movement

            //search for nearest tile of each character (left,right,top,bottom)
            foreach (Tile t in SearchClosestTiles(player))
            {
                CheckCollision(player, t);
            }
                
            //checks if they are colliding with it

            //updates velocity if collision didn't occur
        }

        private void NextLevel()
        {
            level++;
            //dump everything
            //load the new variables
        }

        /// <summary>
        /// Checks collision with each of the character's collision boxes
        /// </summary>
        /// <param name="character">Character to check collision with</param>
        /// <returns>Returns true if there is collision</returns>
        public bool CheckCollision(Character character, Tile tile)
        {
            foreach (Rectangle r in character.CollisionBoxes)
            {
                if (r.Intersects(tile.Rectangle))
                    return true;
            }
            return false;
        }

        private Tile[] SearchClosestTiles(Character character)
        {
            Tile[] tiles = new Tile[4];

            return tiles;
        }

        private void FixPos(Character character, Tile tile)
        {
            //prioritizes intserction from the sides
            if (character.PrevPos.X + 4 >= tile.Max.X) //checks if 
            {
                character.X = tile.Max.X;
                character.Velocity = new Vector2(0, character.Velocity.Y);
                character.Acceleration = new Vector2(0, character.Acceleration.Y);
            }
            else if (character.PrevPos.X + character.Width - 4 <= tile.X)
            {
                character.X = tile.X - character.Width;
                character.Velocity = new Vector2(0, character.Velocity.Y);
                character.Acceleration = new Vector2(0, character.Acceleration.Y);
            }
            else if (character.PrevPos.Y + character.Height - 1 <= tile.Y) //intersects from top
            {
                character.Y = tile.Min.Y - character.Height;
                character.Velocity = new Vector2(character.Velocity.X, 0);
                character.Acceleration = new Vector2(character.Velocity.X, 0);
            }
            else if (character.PrevPos.Y + character.Height + 1 >= tile.Max.Y)
            {
                character.Y = tile.Max.Y;
                character.Velocity = new Vector2(character.Velocity.X, 0);
                character.Acceleration = new Vector2(character.Velocity.X, 0);
            }
        }
        
        private void FixPos(Player player, Tile tile)
        {
            if (player.PrevPos.X + 4 >= tile.Max.X) //prioritizes intersection from the sides
            {
                player.X = tile.Max.X;
                player.Velocity = new Vector2(0, player.Velocity.Y);
                player.Acceleration = new Vector2(0, player.Acceleration.Y);
                return;
            }
            else if (player.PrevPos.X + player.Width - 4 <= tile.X)
            {
                player.X = tile.X - player.Width;
                player.Velocity = new Vector2(0, player.Velocity.Y);
                player.Acceleration = new Vector2(0, player.Acceleration.Y);
                return;
            }
            else if (player.PrevPos.Y + player.Height - 1 <= tile.Y) //intersects from top
            {
                player.Y = tile.Min.Y - player.Height;
                player.Velocity = new Vector2(player.Velocity.X, 0);
                player.Acceleration = new Vector2(player.Velocity.X, 0);
                if (player is Player)
                    player.CanJump = true;
            }
            else if (player.PrevPos.Y + player.Height + 1 >= tile.Max.Y)
            {
                player.Y = tile.Max.Y;
                player.Velocity = new Vector2(player.Velocity.X, 0);
                player.Acceleration = new Vector2(player.Velocity.X, 0);
            }
        }

        public void Draw()
        {

        }
    }
}
