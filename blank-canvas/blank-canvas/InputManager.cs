using Microsoft.Xna.Framework.Input;

namespace blank_canvas
{
    /// <summary>
    /// The class that deals with all the input
    /// </summary>
    class InputManager
    {
        #region variables 

        //variables
        KeyboardState kb;
        KeyboardState prevKb;
        MouseState prevMouse;
        MouseState mouse;

        #endregion

        #region properties

        /// <summary>
        /// The keyboard state in the previous frame
        /// </summary>
        public KeyboardState PrevKBState
        {
            get { return prevKb; }
            set { prevKb = value; }
        }

        /// <summary>
        /// The current keyboard state
        /// </summary>
        public KeyboardState KBState
        {
            get { return kb; }
            set { kb = value; }
        }

        /// <summary>
        /// The previous mouse state
        /// </summary>
        public MouseState PrevMouseState
        {
            get { return prevMouse; }
            set { prevMouse = value; }
        }

        /// <summary>
        /// The current mouse state
        /// </summary>
        public MouseState MouseState
        {
            get { return mouse; }
            set { mouse = value; }
        }

        #endregion

        #region methods

        /// <summary>
        /// Updates the current and previous keyboard states
        /// </summary>
        public void Update()
        {
            prevKb = kb;
            kb = Keyboard.GetState();
            prevMouse = mouse;
            mouse = Mouse.GetState();
        }

        /// <summary>
        /// Checks to see if a key was pressed (doesn't count if the key is being held down)
        /// </summary>
        /// <param name="key">The key that is currently being pressed</param>
        public bool KeyPressed(Keys key)
        {
            if (kb.IsKeyDown(key) && prevKb.IsKeyUp(key))
                return true;
            else return false;
        }

        /// <summary>
        /// Checks to see if a set of keys was pressed (doesn't count if held)
        /// </summary>
        /// <param name="keys">An array of keys to test</param>
        public bool KeysPressed(params Keys[] keys)
        {
            foreach(Keys k in keys)
            {
                if (kb.IsKeyDown(k) && prevKb.IsKeyUp(k))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if a key is currently being held down
        /// </summary>
        /// <param name="key">The key that is currently down</param>
        public bool KeyDown(Keys key)
        {
            if (kb.IsKeyDown(key))
                return true;
            else return false;
        }

        /// <summary>
        /// Checks to see if a set of keys is being held down
        /// </summary>
        /// <param name="keys">The array of keys</param>
        public bool KeysDown(params Keys[] keys)
        {
            foreach(Keys k in keys)
            {
                if (kb.IsKeyDown(k))
                    return true; 
            }
            return false;
        }

        /// <summary>
        /// Checks to see if a key is not being held or pressed
        /// </summary>
        /// <param name="key">The key to test with</param>
        public bool KeyUp(Keys key)
        {
            if (kb.IsKeyUp(key))
                return true;
            else return false;
        }

        /// <summary>
        /// Checks to see if a set of keys are not being held or pressed
        /// </summary>
        /// <param name="key">The key to test with</param>
        public bool KeysUp(params Keys[] keys)
        {
            foreach(Keys k in keys)
            {
                if (kb.IsKeyUp(k))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if a key was released
        /// </summary>
        /// <param name="key">The key to test with</param>
        public bool KeyRelease(Keys key)
        {
            if (prevKb.IsKeyDown(key) && kb.IsKeyUp(key))
                return true;
            else return false;
        }

        /// <summary>
        /// Checks to see if a set of keys was released
        /// </summary>
        /// <param name="key">The key to test with</param>
        public bool KeysRelease(params Keys[] keys)
        {
            foreach(Keys k in keys)
            {
                if ((prevKb.IsKeyDown(k) && kb.IsKeyUp(k)))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Checks to see if the left click is pressed (not held)
        /// </summary>
        public bool LeftClick()
        {
            if (mouse.LeftButton == ButtonState.Pressed && prevMouse.LeftButton == ButtonState.Released)
                return true;
            else return false;
        }

        /// <summary>
        /// Checks to see if the right click is pressed (not held)
        /// </summary>
        public bool RightClick()
        {
            if (mouse.RightButton == ButtonState.Pressed && prevMouse.RightButton == ButtonState.Released)
                return true;
            else return false;
        }

        #endregion
    }
}
