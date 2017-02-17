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
using Microsoft.Xna.Framework.Input;
using ADS.Medication.Spawner;
using ADS.Entities.Platformer;
using ADS.States.Levels;
using ADS.Entities.SATTEST;

namespace Engine
{
    class Level1 : BaseScreen
    {
        #region Variables
        private TileMap Map;

        private int counter = 0;
        private bool spawnerset = false;
   
        private Vector2[] test = new Vector2[7];
        private Random random;

        Spawner spawner;

        RECTANGLE r;



        CollisionTest ct;


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
            random = new Random();
            Constants.colour = Color.Maroon;
            CameraManager.Instance.getCam().Zoom = 1f;

            KeyHandler.Instance.KeyDown += OnKeyDown;
    
            this.SoundTrack = "SoundTrack1";

            // Map = new TileMap();
            //Map.GenerateCA(41, 32, 32);
            // DetectionManger.Instance.setTileMap(Map);


            //EntityManager.Instance.getCamEntity("Player");


            //EntityManager.Instance.createEntity<PhysicsEntity>(new Vector2);

            ct = new CollisionTest();


            // EntityManager.Instance.createEntityCamDrawable<pEntity>(Vector2.Zero);
            //for(int x = Constants.r.Next(0, Map.Map.GetLength(0)); x < Map.Map.GetLength(0); x++)
            //{
            //    for(int y = Constants.r.Next(0, Map.Map.GetLength(1)); y < Map.Map.GetLength(1);y++)
            //    {
            //        if (!spawnerset)
            //        {
            //            spawner = new Spawner(300, new Vector2(x * 64, y * 64));
            //            Console.WriteLine(x + " " + y);
            //            spawnerset = true;
            //        }
            //    }
            //}
            //spawner.assignGroup(new Test()); 
            //
            //    Vector2 p1 = Projection(a.

            r = new RECTANGLE(400,200,100,100 );
            base.Initialize();

        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {


            //if (e.key == Microsoft.Xna.Framework.Input.Keys.E)
            //{
            //    if (CameraManager.Instance.getCam().Zoom == 1f)
            //        CameraManager.Instance.getCam().Zoom = 0.1f;
            //    else if (CameraManager.Instance.getCam().Zoom == 0.1f)
            //        CameraManager.Instance.getCam().Zoom = 1f;
            //}

            //if (e.key == Microsoft.Xna.Framework.Input.Keys.Q)
            //{
            //    EntityManager.Instance.clearList();
            //    Map.CollisionTiles.Clear();
            //    Map.GenerateCA(46, 64, 64);
            //}


            //if (e.key == Keys.N)
            //{
            //        spawner.sendWave(2);
               
            //}
        }



        public override void Unload()
        {
            EntityManager.Instance.tempCamClear();
            EntityManager.Instance.clearList();
            Console.WriteLine("Unloading");
            Constants.colour = Color.DarkRed;
            KeyHandler.Instance.KeyDown -= OnKeyDown;


        }

        #endregion


        #region Update & Draw
        /// <summary>
        /// Draw the map
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //  Map.Draw(spriteBatch);
            r.Draw(spriteBatch);
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


            ct.Update();

            counter += 1;

            if(counter <=200)

            {
                RenderManager.Instance.addString(new ADS.Utilities.GameText(this.GetType().ToString().Split('.').Last(), "SnapTitle", new Vector2(300,0), Color.Yellow, 0.5f));
            }

            
           

            /*
             * 
             * if(A.Distance(to B) is less than X)
             * 
             */
            //float dot = DotProduct(a.Position, b.Position);
            // Vector2 proa = Projection(new Vector2(a.Bounds.X - a.Bounds.Width, a.Bounds.Y - a.Bounds.Height), new Vector2,dot );
            base.Update(gameTime);
        }
        #endregion


        #region TemporaryCollision


       
    }
    #endregion


}

 

