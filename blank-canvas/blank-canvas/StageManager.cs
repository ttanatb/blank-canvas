using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace blank_canvas
{
    /// <summary>
    /// The StageManager manages the gameplay loop
    /// </summary>
    class StageManager:Game
    {
        #region variables
        StageReader stageReader;    //reads in the text file and creates the stage
        InputManager input;         //manages input
        Camera camera;              //manages camera movement

        SpriteFont testFont;        //just a test font
        Texture2D testTexture;      //just a test texture
        Texture2D heartHealth;      //for player health bar
        Texture2D guiBox;           //for stats box

        Player player;
        Enemy[] enemies;
        Tile[] tiles;               //tiles to draw (we really don't need tiles, just rectangles)
        SpecialTile[] sTiles;
        Rectangle[] tileCollision;  //tiles to check collision with
        Gates[] gates;

        PuzzleOrb[] puzzleOrbs;        //this is for testing
        FinalOrb finalOrb;

        int level;                  //the level of the stage (may be unnecessary)

        const float GRAVITY = 24f;    //gravity of the whole thing (kind of unnecessary)
        #endregion

        //constructor
        public StageManager(Camera camera, InputManager inputManager)
        {
            level = 0;
            input = new InputManager();         //normal instantialization for input manager
            stageReader = new StageReader(level);    //may need some tinkering?
            this.camera = camera;               //get camera from game1
        }

        //properties
        public Camera Camera
        {
            get { return camera; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }


        #region Load Content
        /// <summary>
        /// Loads in the textures
        /// </summary>
        /// <param name="contentManager">The ContentManager</param>
        /// <param name="playerTexture">The texture for the player</param>
        /// <param name="enemyTexture">The texture for the enemy</param>
        /// <param name="tileTexture">The texture for the tiles</param>
        public void LoadContent(GameContent contentManager)
        {
            //read file from the stage reader and get player, enemy, tile data
            stageReader.ReadFile(level);
            player = stageReader.Player;
            enemies = stageReader.Enemies;
            tiles = stageReader.Tile;
            sTiles = stageReader.STile;
            tileCollision = stageReader.CollisionBoxes;
            puzzleOrbs = stageReader.PuzzleOrbs;
            gates = stageReader.PuzzleGates;
            finalOrb = stageReader.FinalOrb;

            try
            {
                player.Texture = contentManager.Load("player");
                player.Projectile.Texture = contentManager.Load("projectile");
                finalOrb.Texture = contentManager.Load("finalOrb");
            }
            catch (Exception e)
            {
                Console.WriteLine("You didn't make a character you are dumb af.");
                throw e;
            }

            foreach (Enemy enemy in enemies)
                enemy.Texture = contentManager.Load("enemy");

            foreach (Tile tile in tiles)
                tile.Texture = contentManager.Load("tile");

            foreach (SpecialTile sTile in sTiles)
                sTile.Texture = contentManager.Load("tile");

            foreach (PuzzleOrb puzzleorb in puzzleOrbs)
            {
                puzzleorb.Texture = contentManager.Load("orbBase");
                puzzleorb.OrbTexture = contentManager.Load("orb");
                puzzleorb.OrbGlowTexture = contentManager.Load("orbGlow");
            }

            foreach (Gates gate in gates)
            {
                gate.Texture = contentManager.Load("door");
            }

            testFont = contentManager.TestFont;
            testTexture = contentManager.TestTexture;
            heartHealth = contentManager.HeartHealth;
            guiBox = contentManager.GuiBox;
        }
        #endregion

        /// <summary>
        /// Updates position, takes input to update acceleration, checks collision and fix positions,
        /// and then updates velocity of characters
        /// </summary>
        /// <param name="deltaTime">The amount of miliseconds passed since previous update</param>
        public void Update(float deltaTime)
        {
            if (player.IsDead)
                throw new GameOverException();

            if (finalOrb.Progress > 4)
                throw new NextLevelException();

            //updates the camera and input
            deltaTime = deltaTime / 1000.0f;
            camera.Update(player);

            //updates the input
            input.Update();
            player.UpdateInput(input);

            //this input is done in the main method because it requires different interaction among the objects
            if (input.KeyPressed(Keys.X) && (player.AnimState == AnimState.Jump || player.AnimState == AnimState.Walk || player.AnimState == AnimState.Idle))
                PlayerDrainColor();

            //updates position, velocity and animation
            player.UpdatePos(deltaTime);
            player.Velocity += new Vector2(0, GRAVITY);
            player.UpdateAnim(deltaTime);

            //updates projectile if it is active
            if (player.Projectile.Active)
            {
                //checks collision for all puzzle orbs and enemies
                player.Projectile.Update(deltaTime);
                player.Projectile.CheckCollision(puzzleOrbs, enemies, sTiles, finalOrb);
            }

            //updates the gates
            foreach (Gates gate in gates)
            {
                gate.Update();
            }

            //updates the enemies in the array
            foreach (Enemy enemy in enemies)
            {
                //skips if enemy isn't active
                if (!enemy.Active)
                    continue;

                //updates the position
                enemy.Update(deltaTime);

                //checks for collision with player
                if (player.CollisionBox.Intersects(enemy.CollisionRect))
                    player.TakeDamage(enemy);

            }

            //loops through each collision tiles in the game
            foreach (Rectangle r in tileCollision)
            {
                //checks if it intersects with player, then fixes position
                if (r.Intersects(player.CollisionBox))
                    FixPos(player, r);

                //checks if it intersects with an active projectile
                if (player.Projectile.Active && r.Intersects(player.Projectile.CollisionBox))
                    player.Projectile.Active = false;

                //checks if it intersects with an enemy
                foreach (Enemy enemy in enemies)
                {
                    if (enemy.Active && r.Intersects(enemy.CollisionRect))
                        enemy.ChangeDirection();
                }
            }

            // Loops through the special tiles in the game
            foreach (SpecialTile sTile in sTiles)
            {

                // Blank Canvas Tile (only intersects with objects if completed)
                if(sTile.ActiveState == PuzzleState.Completed) // if the special tile has been filled with paint
                {
                    // Check Collision with player
                    if (sTile.Rectangle.Intersects(player.CollisionBox))
                    {
                        FixPos(player, sTile.Rectangle);
                    }

                    // checks if projecticle intersects with the special Tile (completed)
                    if (player.Projectile.Active && sTile.Rectangle.Intersects(player.Projectile.CollisionBox))
                    {
                        player.Projectile.Active = false;
                    }

                    // Checks if projectile intersects with the special tile (completed)
                    if (player.Projectile.Active && sTile.Rectangle.Intersects(player.Projectile.CollisionBox))
                    {
                        player.Projectile.Active = false;
                    }
                }

                // Handles a hazard Tile (made to have the player take damage if they intersect with this block)
                if(sTile.TileType == TileType.Hazard)
                {
                    if (player.CollisionBox.Intersects(sTile.Rectangle))
                    {
                        player.TakeDamage(sTile);
                    }
                }

                // Handles the Enemy Colliding with the special Tiles (made to keep enemies moving back and forth ontop of a platform)
                foreach (Enemy enemy in enemies)
                {
                    if (sTile.TileType == TileType.EnemyBlockTile || sTile.TileType == TileType.Hazard || (sTile.TileType==TileType.Blank) && sTile.ActiveState == PuzzleState.Completed)
                    {
                        if (enemy.Active && sTile.Rectangle.Intersects(enemy.CollisionRect))
                        {
                            enemy.ChangeDirection();
                        }
                    }
                }
            }

            //loops through the gates and checks for collision with the player
            foreach (Gates gate in gates)
            {
                if (gate.DoorState == PuzzleState.Active && gate.Rectangle.Intersects(player.CollisionBox))
                    FixPos(player, gate.Rectangle);

                // Checks if the enemy intersects with the door
                foreach (Enemy enemy in enemies)
                {
                    if (enemy.Active && gate.Rectangle.Intersects(enemy.CollisionRect) && gate.DoorState == PuzzleState.Active)
                    {
                        enemy.ChangeDirection();
                    }
                }

                // checks if projecticle intersects with the doow
                if (player.Projectile.Active && gate.Rectangle.Intersects(player.Projectile.CollisionBox))
                    player.Projectile.Active = false;

            }
        }

        /// <summary>
        /// This is the method that helps tie in the DrainColor method of the player
        /// </summary>
        private void PlayerDrainColor()
        {
            //changes the animation state
            player.AnimState = AnimState.Drain;

            //updates the search rectangle
            Rectangle searchRect = player.SearchRectangle;

            //searches for the closest enemy that intersects the search rectangle
            int index = SearchClosestEnemy(searchRect);

            //if an enemy isn't found, search for the closesst puzzle orb
            if (index == -1)
            {
                index = SearchClosestPuzzleOrb(searchRect);

                //if a puzzle orb is found, drain the color
                if (index != -1)
                    player.DrainColor(puzzleOrbs[index]);
            }

            //drain the color
            else player.DrainColor(enemies[index]);
        }

        /// <summary>
        /// This is the method that search for the closest enemy within a search rectangle
        /// </summary>
        /// <param name="searchRect">A rectangle to search through</param>
        /// <returns>The index of the enemy to pass to the player's method</returns>
        private int SearchClosestEnemy(Rectangle searchRect)
        {
            //initial index is -1 if nothing is found
            int index = -1;

            //set arbitrarily large distance
            float dist = 99999;

            //loops through all the enemies
            for (int i = 0; i < enemies.Length; i++)
            {
                //checks if is active and intersects search rectangle and has a distance smaller than the current distance
                if (enemies[i].Active
                    && ((int)player.Direction * (enemies[i].X - player.X) < dist)
                    && searchRect.Intersects(enemies[i].Rectangle))
                {
                    //sets the index to that 
                    index = i;

                    //sets the new distance
                    dist = (int)player.Direction * (enemies[i].X - player.X);
                }
            }

            return index;
        }

        private int SearchClosestPuzzleOrb(Rectangle searchRect)
        {
            //initial index is -1 if nothing is found
            int index = -1;

            //set arbitrarily large distance
            float dist = 99999;

            //loops through all the enemies
            for (int i = 0; i < puzzleOrbs.Length; i++)
            {
                //checks if is active and intersects search rectangle and has a distance smaller than the current distance
                if (puzzleOrbs[i].PuzzleState != PuzzleState.Completed
                    && ((int)player.Direction * puzzleOrbs[i].X - player.X < dist)
                    && searchRect.Intersects(puzzleOrbs[i].CollisionBox))
                {
                    //sets the index to that 
                    index = i;

                    //sets the new distance
                    dist = (int)player.Direction * (puzzleOrbs[i].X - player.X);
                }
            }

            return index;
        }

        /// <summary>
        /// Allows for level to change 
        /// </summary>
        public void NextLevel()
        {
            level++;
            stageReader.LevelEnum = (Level)level;
        }

        /// <summary>
        /// Fixes the position of the player based on the rectangle it intersected with.
        /// This doesn't produce a 100% collision resolution and is subject to change.
        /// </summary>
        private void FixPos(Player player, Rectangle rect)
        {
            //checks if player collided from the right
            if (player.PrevPos.X + Player.RIGHT_MARGIN >= rect.X + rect.Width)
            {
                //sets the player's position based on the direction
                if (player.Direction == Direction.Right)
                    player.X = rect.X + rect.Width - Player.LEFT_MARGIN;
                else player.X = rect.X + rect.Width - Player.RIGHT_MARGIN;
                return;
            }

            //checks if the player collided from the left
            if (player.PrevPos.X + player.Width - Player.RIGHT_MARGIN - 1 <= rect.X)
            {
                //sets the player's position based on the direction
                if (player.Direction == Direction.Right)
                    player.X = rect.X - player.Width + Player.RIGHT_MARGIN;
                else player.X = rect.X - player.Width + Player.LEFT_MARGIN;
                return;
            }

            //checks if the player collided from the top
            if (player.PrevPos.Y <= rect.Y - rect.Height / 2)
            {
                //sets the velocity and position and canJump value
                player.Y = rect.Y - player.Height + 1;
                player.Velocity = new Vector2(player.Velocity.X, 0);
                player.CanJump = true;
                return;
            }

            //checks if the player collided from the bottom
            if (player.PrevPos.Y + Player.TOP_MARGIN > rect.Y + rect.Height / 2)
            {

                player.Y = rect.Y + rect.Height;
                player.Velocity = new Vector2(player.Velocity.X, 0);
                return;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Drawing from Background to front
            foreach (PuzzleOrb puzzleorb in puzzleOrbs)
                puzzleorb.Draw(spriteBatch);

            foreach (Gates gate in gates)
                gate.Draw(spriteBatch);

            foreach (Enemy enemy in enemies)
                enemy.Draw(spriteBatch);

            player.Draw(spriteBatch);

            finalOrb.Draw(spriteBatch);

            foreach (SpecialTile sTile in sTiles)
            {
                sTile.Draw(spriteBatch);
            }

            foreach (Tile tile in tiles)
                tile.Draw(spriteBatch);

            spriteBatch.End();

            //for gui stats
            camera.SortArr(player.ColorStats());
            camera.DrawStats(testTexture, heartHealth, guiBox, testFont, player.CurrColor(), player.CurrHealth());
        }

    }
}
