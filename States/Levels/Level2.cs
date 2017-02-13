using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Engine.Managers.Behaviour;
using Engine.Managers.Collision;
using Engine.Managers.Render;
using Engine.Managers.EntityRelated;
using Engine.Entities;

namespace Engine
{
    class Level2 : BaseScreen
    {
        #region Variables
        private TileMap Map;
        #endregion

        #region Constructor, Initialization & Unload
        public Level2()
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

            SoundTrack = "SoundTrack1";

            Map.Generate(new int[,]{
                {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
                {4,0,0,0,4,12,0,0,0,4,14,0,0,4,0,0,0,4,0,0,0,0,0,0,0,0,20,4},
                {4,0,0,0,4,0,0,0,0,4,0,0,0,4,0,0,0,4,0,0,0,0,0,0,0,0,0,4},
                {4,0,0,0,0,0,0,0,0,4,0,0,0,4,0,0,0,4,0,0,0,0,0,0,0,0,0,4},
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
            EntityManager.Instance.createEntityDrawable<pEntity>(new Vector2(200,100));
            EntityManager.Instance.createEntityCamDrawable<pEntity>(new Vector2(200, 100));
            EntityManager.Instance.createEntity<pEntity>(new Vector2(250, 100));


            DetectionManger.Instance.setTileMap(Map);
            base.Initialize();

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
        int hi = 0;
        /// <summary>
        /// Update activities within the level
        /// Our level currently is very standard therefore no updates are needed
        /// </summary>
        /// <param name="gameTime"></param>

        bool test1 = false;
        bool test2 = false;
        bool test3 = false;
        bool test4 = false;
        bool test5 = false;
        bool test6 = false;
        public override void Update(GameTime gameTime)
        {
            hi++;
            if(hi > 50 && !test1)
            {
                RenderManager.Instance.getD.Clear();
                test1 = true;
            }
            if (hi > 100 && !test2)
            {
                RenderManager.Instance.getD1.Clear();
                test2 = true;
            }
            if (hi > 150 && !test3)
            {
                EntityManager.Instance.clearList();
                test3 = true;
            }
            if (hi > 200 && !test4)
            {
                EntityManager.Instance.createEntityDrawable<pEntity>(new Vector2(200, 100));
                test4 = true;
            }
            if (hi > 250 && !test5)
            {
                EntityManager.Instance.createEntityCamDrawable<pEntity>(new Vector2(200, 100));
                test5 = true;
            }
            if (hi > 300 && !test6)
            {
                EntityManager.Instance.createEntity<pEntity>(new Vector2(250, 100));
                test6 = true;
            }
        }
        #endregion
    }
}

