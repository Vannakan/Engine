using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ADS.Managers.Behaviour;
using ADS.Managers.Collision;
using ADS.Managers.Render;
using ADS.Managers.EntityRelated;
using ADS.Entities;

namespace ADS
{
    class Level1 : BaseScreen
    {
        #region Variables
        private TileMap Map;
        #endregion
        #region Constructor, Initialization & Unload
        public Level1()
        {
            Map = new TileMap();
        }

        /// <summary>
        /// Run Initialization logic
        /// - Generate the TileMap
        /// - Add a player to the game
        /// /// </summary>
        public override void Initialize()
        {
            Map.Generate(new int[,]{
                {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
                {4,10,0,0,4,12,0,0,0,4,14,0,0,4,0,0,0,4,0,0,0,0,0,0,0,0,0,4},
                {4,0,0,0,4,0,0,0,0,4,0,0,0,4,0,0,0,4,0,0,0,0,0,0,0,0,0,4},
                {4,0,0,0,4,0,0,0,0,4,0,0,0,4,0,0,0,4,0,0,0,0,0,0,0,0,0,4},
                {4,0,4,4,4,0,4,4,4,4,0,4,4,4,0,4,4,4,0,0,0,0,0,0,0,0,15,4},
                {4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,4},
                {4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4},
                {4,0,4,4,4,0,4,4,4,4,0,4,4,4,0,4,4,4,0,0,0,0,0,0,0,0,0,4},
                {4,0,0,0,4,0,0,0,0,4,0,0,0,4,0,0,0,4,0,0,0,0,0,0,0,0,0,4},
                {4,0,0,0,4,0,0,0,0,4,0,0,0,4,0,0,0,4,0,0,0,0,0,0,0,0,0,4},
                {4,13,0,0,4,0,0,0,0,4,0,0,0,4,0,0,0,4,0,0,0,0,0,0,0,0,0,4},
                {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            }, 64);

            Map.GenerateLayer(new int[,]{
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,6,6,6,0,6,6,6,6,0,6,6,6,4,6,6,6,4,6,6,6,6,6,6,6,6,20,0},
                {0,6,6,6,0,6,6,6,6,0,6,6,6,4,6,6,6,4,6,6,6,6,6,6,6,6,6,0},
                {0,6,6,6,0,6,6,6,6,0,6,6,6,4,6,6,6,4,6,6,6,6,6,6,6,6,6,0},
                {0,6,6,0,0,6,0,0,0,0,6,6,0,4,6,4,4,4,6,6,6,6,6,6,6,6,6,0},
                {0,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,0},
                {0,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,0},
                {0,6,0,0,0,6,0,0,0,0,6,0,0,0,6,0,0,0,6,6,6,6,6,6,6,6,6,0},
                {0,6,6,6,0,6,6,6,6,0,6,6,6,0,6,6,6,0,6,6,6,6,6,6,6,6,6,0},
                {0,6,6,6,0,6,6,6,6,0,6,6,6,0,6,6,6,0,6,6,6,6,6,6,6,6,6,0},
                {5,6,6,6,0,6,6,6,6,0,6,6,6,6,6,6,6,0,6,6,6,6,6,6,6,6,6,1},
                {1,6,6,6,6,8,1,8,1,8,1,1,1,1,1,1,1,1,1,1,1,8,1,8,1,1,1,1},
            }, 64);

 
            DetectionManger.Instance.setTileMap(Map);

        }

      
        public override void UnloadContent()
        {
                   

        }
        #endregion
        #region Update & Draw
        /// <summary>
        /// Draw the map
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {

            Map.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Update activities within the level
        /// Our level currently is very standard therefore no updates are needed
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {


        }
        #endregion
    }
}
