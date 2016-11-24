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
using Engine.Managers.ASTAR;
using Engine.Serialization;
using System.Xml.Serialization;
using System.IO;
using ADS.Tilemaps;
using Engine.Managers.CamManage;
using Engine.Events.KeyboardEvent;

namespace Engine
{
    class Level1 : BaseScreen
    {
        #region Variables
        private TileMap Map;
        private PathFinder pathfinder;
        private CA ca;
        #endregion
        #region Constructor, Initialization & Unload
        public Level1()
        {
            Map = new TileMap();
            ca = new CA();
        }

        /// <summary>
        /// Run Initialization logic
        /// - Generate the TileMap
        /// - Add a player to the game
        /// /// </summary>
        public override void Initialize()
        {

            KeyHandler.Instance.KeyDown += OnKeyDown;
        
        ca.Start();
            CameraManager.Instance.getCam().Zoom = 0.05f;
            this.SoundTrack = "SoundTrack1";
            saveDataTest dd = new saveDataTest();
            XmlSerializer x = new XmlSerializer(dd.GetType());

                        using (FileStream fileStream = new FileStream(@"C:\Coding Stuff\Level1.xml", FileMode.Open))
                        {
                            dd = (saveDataTest)x.Deserialize(fileStream);
                           
                        }
                        int[,] return1 = new int[dd.Colums, dd.Rows];

                        for (int i = 0; i < dd.Colums; i++ )
                        {
                            for(int j = 0; j<dd.Rows; j++)
                            {
                                return1[i,j] = dd.IntJagged[i][j];
                            }
                        }


                            Map.Generate(return1, 64);


            Map.GenerateLayer(new int[,]{
                {1,1,1,0,0,0,0,0},
                {1,1,1,1,1,1,1,0},
                {0,0,0,0,0,0,1,0},
                {1,1,1,1,1,1,1,0},
                {1,0,0,0,0,0,0,0},
                {1,1,1,0,0,0,1,1},
                {0,0,1,0,0,0,1,0},
                {1,1,1,0,0,0,1,0},
                {1,0,0,0,0,0,1,0},
                {1,0,0,0,0,0,1,0},
                {1,1,1,1,1,1,1,0},


              
            }, 64);

            //  pathfinder = new PathFinder(Map);

            //   List<Vector2> path = pathfinder.FindPath(new Point(0, 0), new Point(0,1));
            //   foreach (Vector2 point in path)
            //   {
            //        System.Diagnostics.Debug.WriteLine(point);
            //     }

            DetectionManger.Instance.setTileMap(Map);

            base.Initialize();

        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.key == Microsoft.Xna.Framework.Input.Keys.W)
            {
                ca.Start();
            }
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

            // Map.Draw(spriteBatch);
            ca.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Update activities within the level
        /// Our level currently is very standard therefore no updates are needed
        /// </summary>
        /// <param name="gameTime"></param>
        /// 
        Vector2 hello = new Vector2(0, 0);
        bool up = false;
        
        public override void Update(GameTime gameTime)
        {

           
           // Console.WriteLine(Map.DrawTiles.Count);

            for (int i = 0; i < Map.DrawTiles.Count; i++)
            {
                if (Map.DrawTiles[i].alpha >= 1)
                    up = false;
                else if (Map.DrawTiles[i].alpha < 0)
                    up = true;


                switch(up)
                {
                    case true:
                        Map.DrawTiles[i].alpha += 0.05f;
                        break;

                    case false:
                        Map.DrawTiles[i].alpha -= 0.05f;
                        break;
                }

            }
                base.Update(gameTime);
        }
        #endregion
    }

 
}
