using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADS
{
    public interface IScreen
    {

        void UnloadContent();
        void Initialize();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void Unload();
    }
}
