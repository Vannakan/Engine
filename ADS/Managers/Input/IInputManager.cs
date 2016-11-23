using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADS
{
    public interface IInputManager
    {
        void Update(GameTime gameTime);
        bool CheckKeyPressed(Keys k);
        bool CheckHeldDown(Keys k);
    }
}
