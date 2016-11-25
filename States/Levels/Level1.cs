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
using Engine.Entities.TopDownShooter;

namespace Engine
{
    class Level1 : BaseScreen
    {
        #region Variables
        private TileMap Map;
        private PathFinder pathfinder;
        private CA ca;

        IEntity e;
        #endregion
        #region Constructor, Initialization & Unload
        public Level1()
        {
        }

        /// <summary>
        /// Run Initialization logic
        /// - Generate the TileMap
        /// - Add a player to the game
        /// /// </summary>
        public override void Initialize()
        {

            Constants.colour = Color.Maroon;
            CameraManager.Instance.getCam().Zoom = 1f;

            KeyHandler.Instance.KeyDown += OnKeyDown;
            ca = new CA();
         // ca.Start();
            this.SoundTrack = "SoundTrack1";

            Map = new TileMap();
            Map.GenerateC(48,64,64);

            
            //saveDataTest dd = new saveDataTest();
            //XmlSerializer x = new XmlSerializer(dd.GetType());

            //            using (FileStream fileStream = new FileStream(@"C:\Coding Stuff\Level1.xml", FileMode.Open))
            //            {
            //                dd = (saveDataTest)x.Deserialize(fileStream);
                           
            //            }
            //            int[,] return1 = new int[dd.Colums, dd.Rows];

            //            for (int i = 0; i < dd.Colums; i++ )
            //            {
            //                for(int j = 0; j<dd.Rows; j++)
            //                {
            //                    return1[i,j] = dd.IntJagged[i][j];
            //                }
            //            }

        
            //  pathfinder = new PathFinder(Map);

            //   List<Vector2> path = pathfinder.FindPath(new Point(0, 0), new Point(0,1));
            //   foreach (Vector2 point in path)
            //   {
            //        System.Diagnostics.Debug.WriteLine(point);
            //     }

            //DetectionManger.Instance.setTileMap(Map);

            base.Initialize();

        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
           

            if(e.key == Microsoft.Xna.Framework.Input.Keys.E)
            {
                if (CameraManager.Instance.getCam().Zoom == 1f)
                    CameraManager.Instance.getCam().Zoom = 0.1f;
                else  if (CameraManager.Instance.getCam().Zoom == 0.1f)
                        CameraManager.Instance.getCam().Zoom = 1f;
            }

            if (e.key == Microsoft.Xna.Framework.Input.Keys.Q)
                Map.GenerateC(45, 40, 40);
        }



        public override void Unload()
        {
            EntityManager.Instance.tempCamClear();
            Console.WriteLine("Unloading");
            Constants.colour = Color.White;
                
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
        /// 
     
        
        public override void Update(GameTime gameTime)
        {

           
      
                
            

    
                base.Update(gameTime);
        }
        #endregion
    }

 
}
