using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

/*
    Class: Game1
    Purpose: creates Monogame
*/

namespace blank_canvas
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        StageManager stageManager;
        InputManager input;
        GameContent contentManager;

        // creates variables for textures of background, main menu, and pause screen
        Texture2D backgroundTexture;

        Texture2D menuTexture;
        Texture2D pointerTexture;
        int pointerNum;

        Texture2D pauseTexture;
        Texture2D gameOverTexture;
        Texture2D levelChangeTexture;
        Texture2D instructionTexture;

        // variables for fonts
        SpriteFont levelChangeText;

        // enum variables
        GameState state;
        Camera camera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            //updates the dimensions of the game screen
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            input = new InputManager();

            //instantializes the initial GameState
            state = GameState.MainMenu;
            pointerNum = 0;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            contentManager = new GameContent(Content);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //loads in all the texture that the stage manager requries

            // gameplay textures
            backgroundTexture = contentManager.Load("testBackground");

            // textures for the screens
            menuTexture = contentManager.Load("mainMenu");
            pauseTexture = contentManager.Load("pause");
            gameOverTexture = contentManager.Load("gameOver");
            instructionTexture = contentManager.Load("instruction");
            pointerTexture = contentManager.Load("pointer");


            //level change screen texture
            levelChangeTexture = contentManager.Load("levelChange");
            levelChangeText = Content.Load<SpriteFont>("Arial_14");

            camera = new Camera(GraphicsDevice.Viewport, GraphicsDevice);
            stageManager = new StageManager(camera, input);


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary> 
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //updates input
            input.Update();

            //updates the current state
            switch (state)
            {
                // if mainmenu state
                case GameState.MainMenu:
                    UpdateMainMenu();
                    break;
                case GameState.Instruction:
                    UpdateInstruction();
                    break;
                // if gameplay state
                case GameState.Gameplay:

                    UpdateGamePlay();

                    // updates the level based on the amount of time that has passed
                    float deltaTime = gameTime.ElapsedGameTime.Milliseconds;
                    try
                    {
                        stageManager.Update(deltaTime);
                    }
                    catch (GameOverException)
                    {
                        pointerNum = 0;
                        state = GameState.EndOfGame;
                    }
                    catch (NextLevelException)
                    {
                        if (stageManager.Level == 4)
                        {
                            state = GameState.MainMenu;
                            pointerNum = 0;
                            stageManager.Level = 0;
                        }
                        else
                        {
                            stageManager.NextLevel();
                            stageManager.LoadContent(contentManager);
                        }
                    }

                    //  updates the gameplay based on any input to change the state
                    break;

                // if pause state
                case GameState.Pause:
                    UpdatePause();
                    break;

                // if game over or exit
                case GameState.EndOfGame:
                    UpdateEndOfGame();
                    break;

                // when player changes levels
                case GameState.LevelChange:
                    UpdateLevelChange();
                    break;
            }

            base.Update(gameTime);
        }

        private void UpdateInstruction()
        {
            if (input.KeysPressed(Keys.Space, Keys.Enter, Keys.Escape))
            {
                state = GameState.MainMenu;
            }
        }

        ///<summary>
        ///Changes from main menu to gameplay
        ///</summary>
        private void UpdateMainMenu()
        {
            //currently in Main Menu state
            if (input.KeyPressed(Keys.Down) && pointerNum < 2)
                pointerNum++;
            else if (input.KeyPressed(Keys.Up) && pointerNum > 0)
                pointerNum--;

            if(input.KeysPressed(Keys.Enter, Keys.Space))
            {
                switch(pointerNum)
                {
                    case 0:
                        stageManager.LoadContent(contentManager);
                        state = GameState.Gameplay;
                        break;
                    case 1:
                        state = GameState.Instruction;
                        break;
                    case 2:
                        Exit();
                        break;
                }
            }
        }

        /// <summary>
        /// Changes from gameplay to pause screen
        /// </summary>
        private void UpdateGamePlay()
        {
            if (input.KeysPressed(Keys.Back, Keys.Escape))
            {
                state = GameState.Pause;
                pointerNum = 0;
            }
        }

        /// <summary>
        /// Changes from pause to gameplay or exit
        /// </summary>
        private void UpdatePause()
        {
            if (input.KeyPressed(Keys.Down) && pointerNum < 1)
                pointerNum++;
            else if (input.KeyPressed(Keys.Up) && pointerNum > 0)
                pointerNum--;

            if (input.KeysPressed(Keys.Enter, Keys.Space))
            {
                switch (pointerNum)
                {
                    case 0:
                        state = GameState.Gameplay;
                        break;
                    case 1:
                        state = GameState.MainMenu;
                        pointerNum = 0;
                        break;
                }
            }
            else if (input.KeyPressed(Keys.Escape))
                state = GameState.Gameplay;
        }

        /// <summary>
        /// Exits the game
        /// </summary>
        private void UpdateEndOfGame()
        {
            if (input.KeyPressed(Keys.Enter))
            {
                state = GameState.MainMenu;
            }
        }

        /// <summary>
        /// When end of level reached, end of level screen pops up and level changes
        /// </summary>
        private void UpdateLevelChange()
        {
            // updates level count 
            stageManager.NextLevel();

            // switches level textures and design
            if (input.KeyPressed(Keys.Space))
            {
                //switch (getLevel)
                //{
                //    case Level.Desert:
                //        break;
                //    case Level.Ice_Caves:
                //        break;
                //    case Level.Forest:
                //        break;
                //    case Level.Mountain:
                //        break;
                //    case Level.Castle:
                //        break;
                //}

                state = GameState.Gameplay;
            }
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkCyan);

            // switches the state based on current GameState
            switch (state)
            {

                // draws the main menu
                case GameState.MainMenu:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, null);

                    spriteBatch.Draw(menuTexture, Vector2.Zero, Color.White);
                    spriteBatch.Draw(pointerTexture, new Vector2(563, 258 + 48 * pointerNum), Color.White);
                    spriteBatch.End();

                    break;

                case GameState.Instruction:
                    spriteBatch.Begin();
                    spriteBatch.Draw(instructionTexture, Vector2.Zero, Color.White);
                    spriteBatch.End();

                    break;

                // draws gameplay and focuses the camera
                case GameState.Gameplay:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, stageManager.Camera.Transform);
                    stageManager.Draw(spriteBatch);
                    break;

                // draws pause screen
                case GameState.Pause:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, null);
                    spriteBatch.Draw(pauseTexture, Vector2.Zero, Color.White);
                    spriteBatch.Draw(pointerTexture, new Vector2(627, 330 + 85 * pointerNum), Color.White);
                    spriteBatch.End();

                    break;

                // draws end screen, which then exits
                case GameState.EndOfGame:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, null);
                    spriteBatch.Draw(gameOverTexture, Vector2.Zero, Color.White);
                    spriteBatch.Draw(pointerTexture, new Vector2(627, 325), Color.White);
                    spriteBatch.End();

                    break;

                // when player reaches end of level
                case GameState.LevelChange:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, null);
                    spriteBatch.Draw(levelChangeTexture, Vector2.Zero, Color.White);
                    spriteBatch.End();

                    break;
            }
            base.Draw(gameTime);
        }
    }
}
