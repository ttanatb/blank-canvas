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
        GameContent content;

        // creates variables for textures of background, main menu, and pause screen
        Texture2D backgroundTexture;

        Texture2D menuTexture;
        Texture2D pointerTexture;
        int pointerNum;

        Texture2D pauseTexture;
        Texture2D gameOverTexture;
        Texture2D levelChangeTexture;

        // variables for fonts
        SpriteFont levelChangeText;

        // enum variables
        GameState state;
        Level lvl;

        // game state property
        public GameState gameState
        {
            get { return state; }
            set { state = value; }
        }

        // level property
        public Level getLevel
        {
            get { return lvl; }
            set { lvl = value; }
        }

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
            content = new GameContent(Content);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //loads in all the texture that the stage manager requries

            // gameplay textures
            backgroundTexture = content.Load("backgroundTexture");

            // main menu screen texture
            menuTexture = content.Load("mainMenuTexture");
            pointerTexture = content.Load("pointerTexture");

            // pause screen texture
            pauseTexture = content.Load("pauseTexture");

            // game over screen texture
            gameOverTexture = content.Load("gameOverTexture");

            //level change screen texture
            levelChangeTexture =content.Load("levelChange");
            levelChangeText = Content.Load<SpriteFont>("Arial_14");

            stageManager = new StageManager(new Camera(GraphicsDevice.Viewport, GraphicsDevice), input);
            stageManager.LoadContent(content);
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

                // if gameplay state
                case GameState.Gameplay:

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

                    //  updates the gameplay based on any input to change the state
                    UpdateGamePlay();
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
                        state = GameState.Gameplay;
                        break;
                    case 1:
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
            if (input.KeyPressed(Keys.D))

                state = GameState.LevelChange;
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
                //unloads all content then loads in what is necessary for the menu states
                Content.Unload();
                LoadContent();
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
                switch (getLevel)
                {
                    case Level.Desert:
                        Content.Unload();
                        LoadContent();
                        break;
                    case Level.Ice_Caves:
                        Content.Unload();
                        LoadContent();
                        break;
                    case Level.Forest:
                        Content.Unload();
                        LoadContent();
                        break;
                    case Level.Mountain:
                        Content.Unload();
                        LoadContent();
                        break;
                    case Level.Castle:
                        Content.Unload();
                        LoadContent();
                        break;
                }

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
                    spriteBatch.Begin();
                    spriteBatch.Draw(menuTexture, Vector2.Zero, Color.White);
                    spriteBatch.Draw(pointerTexture, new Vector2(563, 258 + 48 * pointerNum), Color.White);
                    break;

                // draws gameplay and focuses the camera
                case GameState.Gameplay:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, stageManager.Camera.Transform);
                    //spriteBatch.Draw(backgroundTexture, new Vector2(-500, 0), Color.White);
                    stageManager.Draw(spriteBatch);
                    break;

                // draws pause screen
                case GameState.Pause:
                    spriteBatch.Begin();
                    spriteBatch.Draw(pauseTexture, Vector2.Zero, Color.White);
                    spriteBatch.Draw(pointerTexture, new Vector2(627, 330 + 85 * pointerNum), Color.White);
                    break;

                // draws end screen, which then exits
                case GameState.EndOfGame:
                    spriteBatch.Begin();
                    spriteBatch.Draw(gameOverTexture, Vector2.Zero, Color.White);
                    spriteBatch.Draw(pointerTexture, new Vector2(627, 325), Color.White);
                    break;

                // when player reaches end of level
                case GameState.LevelChange:
                    spriteBatch.Begin();
                    spriteBatch.Draw(levelChangeTexture, Vector2.Zero, Color.White);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
