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

namespace Engine
{
    class meTest : BaseScreen
    {
        #region Variables
        private TileMap Map;
        private PathFinder pathfinder;
        #endregion
        #region Constructor, Initialization & Unload
        public meTest()
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
            saveDataTest dd = new saveDataTest();
            XmlSerializer x = new XmlSerializer(dd.GetType());

             string cwd = System.IO.Directory.GetCurrentDirectory();

            if (cwd.EndsWith("\\bin\\Windows\\x86\\Debug"))
            {
                cwd = cwd.Replace("\\bin\\Windows\\x86\\Debug", "");
                Console.WriteLine(cwd);

            }
            string outpit = cwd + "\\XmlLevel\\test123.xml";
            using (FileStream fileStream = new FileStream(outpit, FileMode.Open))
            {
                dd = (saveDataTest)x.Deserialize(fileStream);

            }
            int[,] return1 = Utility.Utility.convertTo2DArray(dd.IntJagged, dd.IntJagged.GetLength(0),dd.IntJagged[0].GetLength(0));
            //int[,] collisionLayer = Utility.Utility.convertTo2DArray(dd.IntJagged2, dd.IntJagged2.GetLength(0), dd.IntJagged2[0].GetLength(0));
            //Map.GenerateCollisionLayer(collisionLayer, 64);
            Map.Generate(return1, 64);


            //Console.WriteLine(return1[0, 0]);


            //  pathfinder = new PathFinder(Map);

            //   List<Vector2> path = pathfinder.FindPath(new Point(0, 0), new Point(0,1));
            //   foreach (Vector2 point in path)
            //   {
            //        System.Diagnostics.Debug.WriteLine(point);
            //     }

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

        /// <summary>
        /// Update activities within the level
        /// Our level currently is very standard therefore no updates are needed
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
        #endregion
    }
}
