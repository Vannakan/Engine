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
using Engine.Events.KeyboardEvent;
using Microsoft.Xna.Framework.Input;
using ADS.Serialization;

namespace Engine
{
    class meTest : BaseScreen
    {
        #region Variables
        private TileMap Map;
        private bool getName = true;
        private bool nameSet = false;

        string name = "";
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
            KeyHandler.Instance.KeyDown += GetName;
            base.Initialize();

        }

        public void generateShit(string name)
        {
            JaggedFile dd = new JaggedFile();
            XmlSerializer x = new XmlSerializer(dd.GetType());

            string cwd = System.IO.Directory.GetCurrentDirectory();

            if (cwd.EndsWith("\\bin\\Windows\\x86\\Debug"))
            {
                cwd = cwd.Replace("\\bin\\Windows\\x86\\Debug", "");

            }
            string outpit = cwd + "\\XmlLevel\\" + name + ".xml";
            using (FileStream fileStream = new FileStream(outpit, FileMode.Open))
            {
                dd = (JaggedFile)x.Deserialize(fileStream);

            }
            int[,] return1 = Utilities.Utility.convertTo2DArray(dd.IntJagged, dd.IntJagged.GetLength(0), dd.IntJagged[0].GetLength(0));
            //int[,] collisionLayer = Utility.Utility.convertTo2DArray(dd.IntJagged2, dd.IntJagged2.GetLength(0), dd.IntJagged2[0].GetLength(0));
            //Map.GenerateCollisionLayer(collisionLayer, 64);
            Map.Generate(return1, 64);


    
            DetectionManger.Instance.setTileMap(Map);

        }

        public void GetName(object sender, KeyEventArgs kae)
        {
            if (getName && !nameSet)
            {
                if (kae.key == Keys.Enter)
                {
                    nameSet = true;

                }
                else
                {
                    string Name = name + kae.key.ToString();
                    Console.WriteLine(Name);
                    name = Name;
                }
                

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
            if(Map != null)
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
            if(nameSet)
                generateShit(name);
            base.Update(gameTime);
        }
        #endregion
    }
}
