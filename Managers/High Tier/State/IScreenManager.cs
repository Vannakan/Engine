using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public interface IScreenManager
    {
       

        void Initialize();
        void UnloEnginecreens();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void Add(string screenName);
        void ReplaceScreen(string screenName);
        void CheckScreens();
        void CheckScreenManagerInput();
        void RemoveTopScreen();
        void UpdateTopScreen(GameTime gameTime);
   
        ContentManager content { get; set; }

    }
}
