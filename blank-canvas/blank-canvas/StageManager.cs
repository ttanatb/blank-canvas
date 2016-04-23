using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace blank_canvas
{
    /// <summary>
    /// The StageManager manages the gameplay loop
    /// </summary>
    class StageManager
    {
        #region variables
        StageReader stageReader;    //reads in the text file and creates the stage
        InputManager input;         //manages input
        Camera camera;              //manages camera movement

        SpriteFont testFont;        //just a test font
        Texture2D testTexture;      //just a test texture

        Player player;              
        Enemy[] enemies;            
        Tile[] tiles;               //tiles to draw (we really don't need tiles, just rectangles)
        Rectangle[] tileCollision;  //tiles to check collision with
        Gates[] gates;

        PuzzleOrb[] puzzleOrbs;        //this is for testing
        //Enemy testEnemy;
        //the puzzle orb should be linked to a gate

        int level;                  //the level of the stage (may be unnecessary)

        const float GRAVITY = 24f;    //gravity of the whole thing (kind of unnecessary)
        #endregion

        //constructor
        public StageManager(Camera camera, InputManager inputManager)
        {
            input = new InputManager();         //normal instantialization for input manager
            stageReader = new StageReader();    //may need some tinkering?
            this.camera = camera;               //get camera from game1
            level = 0;                          //sets level at 0

            //read file from the stage reader and get player, enemy, tile data
            stageReader.ReadFile();
            player = stageReader.Player;
            enemies = stageReader.Enemies;
            tiles = stageReader.Tile;
            tileCollision = stageReader.CollisionBoxes;
            puzzleOrbs = stageReader.PuzzleOrbs;
            gates = stageReader.PuzzleGates;       
        }

        //properties
        public Camera Camera
        {
            get { return camera;  }
        }

        #region Load Content
        /// <summary>
        /// Loads in the textures
        /// </summary>
        /// <param name="content">The ContentManager</param>
        /// <param name="playerTexture">The texture for the player</param>
        /// <param name="enemyTexture">The texture for the enemy</param>
        /// <param name="tileTexture">The texture for the tiles</param>
        public void LoadContent(ContentManager content, string playerTexture,
            string enemyTexture, string tileTexture, string projectileTexture,
            string orbBaseTexture, string orbTexture, string gateTexture)
        {
            try
            {
                player.Texture = content.Load<Texture2D>("playerSpriteSheet");
                player.Projectile.Texture = content.Load<Texture2D>(projectileTexture);
            }
            catch (Exception e)
            {
                Console.WriteLine("You didn't make a character you are dumb af.");
                throw e;
            }

            foreach (Enemy enemy in enemies)
                enemy.Texture = content.Load<Texture2D>(enemyTexture);

            foreach (Tile tile in tiles)
                tile.Texture = content.Load<Texture2D>(tileTexture);
            
            foreach (PuzzleOrb puzzleorb in puzzleOrbs)
            {
                puzzleorb.Texture = content.Load<Texture2D>(orbBaseTexture);
                puzzleorb.OrbTexture = content.Load<Texture2D>(orbTexture);
            }

            foreach(Gates gate in gates)
            {
                gate.Texture = content.Load<Texture2D>(gateTexture);
            }

            testFont = content.Load<SpriteFont>("Arial_14");
            testTexture = content.Load<Texture2D>("testChar");
        }
        #endregion

        /// <summary>
        /// Updates position, takes input to update acceleration, checks collision and fix positions,
        /// and then updates velocity of characters
        /// </summary>
        /// <param name="deltaTime">The amount of miliseconds passed since previous update</param>
        public void Update(float deltaTime)
        {
            //updates the camera and input
            deltaTime = deltaTime / 1000.0f;
            camera.Update(player);
            input.Update();

            player.UpdateInput(input);

            if (input.KeyPressed(Keys.X) && (player.AnimState == AnimState.Jump || player.AnimState == AnimState.Walk || player.AnimState == AnimState.Idle))
                PlayerDrainColor();

            player.Velocity += new Vector2(0, GRAVITY);

            player.UpdatePos(deltaTime);
            player.UpdateAnim(deltaTime);

            if (player.Projectile.Active)
            {
                player.Projectile.Update(deltaTime);
                player.Projectile.CheckCollision(puzzleOrbs, enemies);
            }

            foreach (Enemy enemy in enemies)
            {
                if (!enemy.Active)
                    continue;

                enemy.Update(deltaTime);

                if (player.CollisionBox.Intersects(enemy.Rectangle))
                    player.TakeDamage(enemy);
            }

            foreach (Rectangle r in tileCollision)
            {

                if (r.Intersects(player.CollisionBox))
                    FixPos(player, r);

                if (player.Projectile.Active && r.Intersects(player.Projectile.CollisionBox))
                    player.Projectile.Active = false;

                foreach (Enemy enemy in enemies)
                {
                    if (enemy.Active && r.Intersects(enemy.Rectangle))
                        enemy.ChangeDirection();
                }
                foreach(Gates gate in gates)
                {
                    if (gate.DoorState == PuzzleState.Active && gate.Rectangle.Intersects(player.CollisionBox))
                        FixPos(player, gate.Rectangle);
                }
            }
        }

        private void PlayerDrainColor()
        {
            player.AnimState = AnimState.Drain;
            Rectangle searchRect = player.SearchRectangle;
            int index = SearchClosestEnemy(searchRect);
            if (index == -1)
            {
                index = SearchClosestPuzzleOrb(searchRect);
                if (index != -1 && puzzleOrbs[index].PuzzleState != PuzzleState.Completed)
                    player.DrainColor(puzzleOrbs[index]);
            }
            else player.DrainColor(enemies[index]);
        }

        private int SearchClosestEnemy(Rectangle searchRect)
        {
            int index = -1;
            float dist = 99999;
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].Active && searchRect.Intersects(enemies[i].Rectangle) && ((int)player.Direction * (enemies[i].X - player.X) < dist))
                {
                    index = i;
                    dist = (int)player.Direction * (enemies[i].X - player.X);
                }
            }
            return index;
        }

        private int SearchClosestPuzzleOrb(Rectangle searchRect)
        {
            int index = -1;
            float dist = 99999;
            for (int i = 0; i < puzzleOrbs.Length; i++)
            {
                if (searchRect.Intersects(puzzleOrbs[i].CollisionBox) && ((int)player.Direction * puzzleOrbs[i].X - player.X < dist))
                {
                    index = i;
                    dist = (int)player.Direction * (puzzleOrbs[i].X - player.X);
                }
            }
            return index;
        }

        private void NextLevel()
        {
            level++;
            //NEEDS WORK: dump everything
            //NEEDS WORK: load the new variables
        }

        /// <summary>
        /// Fixes the position of the player based on the rectangle it intersected with
        /// </summary>
        private void FixPos(Player player, Rectangle rect)
        {


            if (player.PrevPos.X + Player.RIGHT_MARGIN >= rect.X + rect.Width)
            {
                Console.WriteLine(player.PrevPos.X + Player.RIGHT_MARGIN + " " + (rect.X + rect.Width));
                if (player.Direction == Direction.Right)
                {
                    player.X = rect.X + rect.Width - Player.LEFT_MARGIN;
                }
                else player.X = rect.X + rect.Width - Player.RIGHT_MARGIN;
                return;
            }
            if (player.PrevPos.X + player.Width - Player.RIGHT_MARGIN - 1 <= rect.X)
            {
                if (player.Direction == Direction.Right)
                    player.X = rect.X - player.Width + Player.RIGHT_MARGIN;
                else player.X = rect.X - player.Width + Player.LEFT_MARGIN;
                //player.Velocity = new Vector2(0, player.Velocity.Y);
                return;
            }
            if (player.PrevPos.Y <= rect.Y - rect.Height / 2)
            {
                player.Y = rect.Y - player.Height + 1;
                player.Velocity = new Vector2(player.Velocity.X, 0);
                player.CanJump = true;
                return;
            }
            if (player.PrevPos.Y + Player.TOP_MARGIN > rect.Y + rect.Height / 2)
            {

                player.Y = rect.Y + rect.Height;
                player.Velocity = new Vector2(player.Velocity.X, 0);
                return;
            }

            /*
            float wy = (player.Width + rect.Width) * (player.Center.Y - rect.Center.Y);
            float hx = (player.Height + rect.Height) * (player.Center.X - rect.Center.X);

            Console.WriteLine(wy + " " + hx);
            if (wy+1 >= hx)
            {
                if (wy > -hx)
                {

                    player.Y = rect.Y + rect.Height;
                    player.Velocity = new Vector2(player.Velocity.X, 0);
                    return;
                }
                else
                {
                    if (player.Direction == Direction.Right)
                        player.X = rect.X - player.Width + Player.RIGHT_MARGIN;
                    else player.X = rect.X - player.Width + Player.LEFT_MARGIN;
                    player.Velocity = new Vector2(0, player.Velocity.Y);
                    return;
                }
            }
            else
            {
                if (wy >= -hx)
                {
                    if (player.Direction == Direction.Right)
                        player.X = rect.X + rect.Width - Player.LEFT_MARGIN;
                    else player.X = rect.X + rect.Width - Player.RIGHT_MARGIN;
                    player.Velocity = new Vector2(0, player.Velocity.Y);
                    return;
                }
                else
                {

                    player.Y = rect.Y - player.Height + 1;
                    player.Velocity = new Vector2(player.Velocity.X, 0);
                    player.CanJump = true;
                    return;
                }
            }
            */
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(testTexture, player.SearchRectangle, Color.Red);


            // Drawing from Background to front
            #region Tiles
            // First Tiles
            foreach (Tile tile in tiles)
                tile.Draw(spriteBatch);
            #endregion

            #region Orbs

            //puzzleOrbs[0].Draw(spriteBatch);

            foreach (PuzzleOrb puzzleorb in puzzleOrbs)
                puzzleorb.Draw(spriteBatch);

            #endregion

            #region Gates
            foreach (Gates gate in gates)
                gate.Draw(spriteBatch);
            #endregion

            foreach (Enemy enemy in enemies)
                enemy.Draw(spriteBatch);


            player.Draw(spriteBatch);

            spriteBatch.DrawString(testFont, player.ToString(), new Vector2(player.X, player.Y - 50), Color.Black);
            foreach (Tile tile in tiles)
                tile.Draw(spriteBatch);

            //spriteBatch.Draw(testTexture, player.SearchRectangle, Color.Red);
           
        }

    }
}
