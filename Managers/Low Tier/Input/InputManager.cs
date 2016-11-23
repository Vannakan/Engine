using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class InputManager : IInputManager
    {
        #region Variables
        //Variable to hold the current key state
        private KeyboardState currentKeyState;
        //Variable to hold the previous key state for comparison
        private KeyboardState previousKeyState;
        #endregion
        #region Singleton
        //Variable to hold the current InputManager Instance
        private static IInputManager instance;
      
        /// <summary>
        /// 
        /// </summary>
        public static IInputManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputManager();

                }
                return instance;
            }
        }
        #endregion
        #region Update
        /// <summary>
        /// This Update method simply gets the current keystate, as well as updating the previous key state to what the
        /// key state was at the last update
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            previousKeyState = currentKeyState;

            currentKeyState = Keyboard.GetState();

            MouseState m = Mouse.GetState();
         //   Console.WriteLine(onClick(m));
        }

        #endregion
        //Currently a work in progress
        # region TestForKeys - Commented
        //public bool KeysPressed(Keys[] keys)
        //{
        //    foreach(Keys key in keys)
        //    {
        //        if (currentKeyState.IsKeyDown(key) && previousKeyState.IsKeyUp(key))
        //            return true;
        //    }
        //    return false;
        //}

        //public bool KeysReleased (Keys[] keys)
        //{
        //    foreach (Keys key in keys)
        //    {
        //        if (currentKeyState.IsKeyUp(key) && previousKeyState.IsKeyDown(key))
        //            return true;
        //    }
        //    return false;
        //}

        //public bool KeysDown(Keys[] keys)
        //{
        //    foreach (Keys key in keys)
        //    {
        //        if (currentKeyState.IsKeyDown(key))
        //            return true;
        //    }
        //    return false;

        //}

        #endregion
        #region CheckKeys

     

        /// <summary>
        /// Check if the left key is down and return true if this is the case
        /// </summary>
        /// <returns></returns>
        /// 

        public bool CheckHeldDown(Keys k)
        {
            bool heldDown = false;

            if (currentKeyState.IsKeyDown(k) )
            {
                heldDown = true;
            }

            return heldDown;

        }

        public bool CheckKeyPressed(Keys k)
        {
            bool checkLeft = false;

            if (currentKeyState.IsKeyDown(k) && previousKeyState.IsKeyUp(k))
            {
                checkLeft = true;
            }

            return checkLeft;
        }


    //    public bool onClick(MouseState m)
       // {
         //   if(m.LeftButton == ButtonState.Pressed)
        //    {
        //        return true;
         //   }
        //    return false;
      //  }
  


        #endregion
    }
}
