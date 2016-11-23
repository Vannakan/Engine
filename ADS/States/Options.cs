using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ADS.Managers.EntityRelated;
using ADS.Entities;

namespace ADS
{
    class Options : BaseScreen
    {

        #region Constructor & Initialization
        public Options()
        {
        }

        public override void Initialize()
        {
            EntityManager.Instance.createEntity<pEntity>(new Vector2(100, 100), "player");

            base.Initialize();
        }
        #endregion

        #region ClearContent

        public override void UnloadContent()
        {
            
            //SpriteManager.Instance.ClearSpriteList();
        }
        #endregion

        #region Update & Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
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
