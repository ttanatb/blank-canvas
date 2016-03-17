﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
<<<<<<< HEAD

        //initialize classes and variables
        KeyboardState prevKBState;
        Character c;
        Player p;
=======

        //initialize classes and variables
        KeyboardState prevKBState;
        Character c;
        Player p;

        //Textures
        Texture2D pTextureSS; // Player Standing Still
        Texture2D eTextureSS; // Enemy Standing Still


>>>>>>> d909b04d77a90b37b7dc3a4f2fa66a63c36a65e9

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // TODO: Add your initialization logic here
<<<<<<< HEAD
            p = new Player(new Rectangle(20,20,100,100));
=======
            p = new Player(new Rectangle(20, 20, 100, 100));
>>>>>>> d909b04d77a90b37b7dc3a4f2fa66a63c36a65e9
            base.Initialize();
            prevKBState = Keyboard.GetState();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            p.Texture = this.Content.Load<Texture2D>("testChar");
            // TODO: use this.Content to load your game content here
            pTextureSS = Content.Load<Texture2D>("playerStandingStill");
            eTextureSS = Content.Load<Texture2D>("enemyNoColor");
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //handling input
            float timer = gameTime.ElapsedGameTime.Milliseconds;

            KeyboardState kbState = Keyboard.GetState();
            //if the user hits the escape button
<<<<<<< HEAD
            if (kbState.IsKeyDown(Keys.Escape))
                Exit();
            c.Move();
            prevKBState = kbState;
=======
>>>>>>> d909b04d77a90b37b7dc3a4f2fa66a63c36a65e9

            p.UpdatePos(timer);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            p.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
