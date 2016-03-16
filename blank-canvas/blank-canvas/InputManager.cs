﻿using Microsoft.Xna.Framework.Input;

namespace blank_canvas
{
    /// <summary>
    /// The class that deals with all the input
    /// </summary>
    class InputManager
    {
        KeyboardState kb;
        KeyboardState prevKb;
        MouseState prevMouse;
        MouseState mouse;

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
                if (!(kb.IsKeyDown(k) && prevKb.IsKeyUp(k)))
                    return false;
            }
            return true;
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
                if (!kb.IsKeyDown(k))
                    return false; 
            }
            return true;
        }

        /// <summary>
        /// Checks to see if only one key 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool OnlyKeyDown(Keys key)
        {
            Keys[] keys = kb.GetPressedKeys();
            if (keys.Length == 1 && keys[0] == key)
                return true;
            else return false;
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
    }
}
