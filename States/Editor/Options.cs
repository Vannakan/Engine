using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Engine.Managers.EntityRelated;
using Engine.Entities;
using Engine.States;

namespace Engine
{
    class Options : BaseScreen
    {
        MapEditor mapEdit;
        #region Constructor & Initialization
        public Options()
        {
            mapEdit = new MapEditor();
            mapEdit.Initialize();
        }

        public override void Initialize()
        {
            SoundTrack = "SoundTrack2";
            base.Initialize();
        }
        #endregion

        #region ClearContent

        public override void Unload()
        {
            mapEdit.Unload();
            base.Unload();
            //SpriteManager.Instance.ClearSpriteList();
        }
        #endregion

        #region Update & Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            mapEdit.Draw(spriteBatch);
            spriteBatch.DrawString(ResourceLoader.Instance.GetFont("mFont"), "There are currently no options", new Vector2(300,300), Color.Red);
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            
                base.Update(gameTime);
            
        }
        #endregion
    }
}
