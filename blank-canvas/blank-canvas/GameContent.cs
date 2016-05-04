using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace blank_canvas
{
    /// <summary>
    /// Class that manages all the textures that 
    /// need to be passed in.
    /// </summary>
    class GameContent : Microsoft.Xna.Framework.Game
    {
        Dictionary<string, Texture2D> dict = new Dictionary<string, Texture2D>();

        Texture2D testTexture;
        SpriteFont testFont;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        public GameContent(ContentManager content)
        {
            dict.Add("playerSpriteSheet", content.Load<Texture2D>("playerSpriteSheet"));
            dict.Add("enemySpriteSheet", content.Load<Texture2D>("enemySpriteSheet"));
            dict.Add("Tiles-Spritesheet", content.Load<Texture2D>("Tiles-Spritesheet"));
            dict.Add("projectile", content.Load<Texture2D>("projectile"));
            dict.Add("orbBase", content.Load<Texture2D>("orbBase"));
            dict.Add("orb", content.Load<Texture2D>("orb"));
            dict.Add("orbGlow", content.Load<Texture2D>("orbGlow"));
            dict.Add("Door", content.Load<Texture2D>("Door"));
            dict.Add("finalOrbTexture", content.Load<Texture2D>("Final Orb Spritesheet"));
            dict.Add("backgroundTexture", content.Load<Texture2D>("testBackground"));
            dict.Add("mainMenuTexture", content.Load<Texture2D>("mainmenu"));
            dict.Add("pointerTexture", content.Load<Texture2D>("pointer"));
            dict.Add("pauseTexture", content.Load<Texture2D>("pausemenu"));
            dict.Add("gameOverTexture", content.Load<Texture2D>("gameover"));
            dict.Add("levelChange", content.Load<Texture2D>("testlevelchange"));
            dict.Add("instructionTexture", content.Load<Texture2D>("instruction"));


            testTexture = content.Load<Texture2D>("testChar");
            testFont = content.Load<SpriteFont>("Arial_14");
        }

        /// <summary>
        /// Searches for each texture within the dictionary
        /// </summary>
        /// <param name="str"> takes in string to search for texture </param>
        public Texture2D Load(string str)
        {
            if (dict.ContainsKey(str))
            {
                return dict[str];
            }
            else
                return null;
        }

        public Texture2D TestTexture { get { return testTexture; } }

        public SpriteFont TestFont {  get { return testFont; } }
    }
}
