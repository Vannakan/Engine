using Engine.Entities;
using Engine.Events.KeyboardEvent;
using Engine.Events.MouseEvent;
using Engine.Managers.CamManage;
using Engine.Managers.Collision;
using Engine.Managers.EntityRelated;
using Engine.Managers.Render;
using Engine.Serialization;
using Engine.Tilemaps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Engine.States
{
    public class MapEditor
    {

        int layer = 1;
        TileMap map;
        Tiles currentTile;
        int selected;
        string currentTileString;

        Texture2D t;
        Texture2D display;
        Texture2D changeTile;
        string message = "";


        public MapEditor()
        {
           
        }

        public void Initialize()
        {
            MouseHandler.Instance.MouseClick += OnMouseClick;
            MouseHandler.Instance.MouseMoved += OnMouseMoved;
            MouseHandler.Instance.MouseScrollDown += OnMouseScrollDown;
            MouseHandler.Instance.MouseScrollUp += OnMouseScrollUp;
            KeyHandler.Instance.KeyDown += OnKeyDown;

            map = new TileMap();
            map.GenerateEmpty(64);
            


            t = new Texture2D(Constants.g, 1, 1);
            t.SetData(new[] { Color.White });
            selected = 1;
            display = ResourceLoader.Instance.GetTex("Tile1");
            currentTileString = display.ToString();


        }

        public void Unload()
        {
            MouseHandler.Instance.MouseClick -= OnMouseClick;
            MouseHandler.Instance.MouseMoved -= OnMouseMoved;
            MouseHandler.Instance.MouseScrollDown -= OnMouseScrollDown;
            MouseHandler.Instance.MouseScrollUp -= OnMouseScrollUp;
            
        }

        public void Update(GameTime gameTime)
        {

        

            if(selected >= 2)
            {
                selected = 2;
            }
            if(selected < 1)
            {
                selected = 1;
            }
            /*
             * 
             * if mouse click
             * check click area
             * check where in multi array * size click was
             * add map
             * 
             * 
             * 
             * 
             * */
        }

        public void changeDisplay(int s)
        {
           changeTile = ResourceLoader.Instance.GetTex("Tile" + s);
           display = changeTile;
           currentTileString = "Tile" + s;
        }

        /// <summary>
        /// Creates a tile based on the currentTile skin and based on what tile type the user wants to add in
        /// Int i = Texture index
        /// Rect = TileMap location reference
        /// currentTile = Tile type
        /// </summary>
        /// <param name="i"></param>
        /// <param name="rect"></param>
        /// <param name="currentTile"></param>
        /// <returns></returns>
        public Tiles createTile(int i, Rectangle rect, int currentTile)
        {
            Tiles tile = null;
           // switch(currentTile)
         //   {
          //      case 1:
                tile = new CollisionTile(i,rect);
           //     break;
           //     case 2:
           //     tile = new DirectionTile(rect, Direction.down);
           //     break;
         //   }

            return tile;
        }

        public void saveMap()
        {
            saveDataTest dd = new saveDataTest();
            int[,] saveMap = map.Map;
            if (saveMap != null)
            {
                dd.Colums = saveMap.GetLength(0);
                dd.Rows = saveMap.GetLength(1);
                dd.IntJagged = Utility.Utility.convertToJaggedArray(saveMap, dd.Colums, dd.Rows);

                XmlSerializer x = new XmlSerializer(dd.GetType());
                using (TextWriter writer = new StreamWriter("CustomLevel.xml"))
                {
                    x.Serialize(writer, dd);
                    Console.WriteLine("Map Saved");
                    message = "Map Saved";
                    Console.WriteLine(map.Map[0,0]);

                }
            }
            else Console.WriteLine("CANT SAVE");
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
            if(currentTile != null)
            {
                spriteBatch.Draw(t, new Rectangle(currentTile.Rectangle.Left, currentTile.Rectangle.Top, 2, currentTile.Rectangle.Height), Color.Black); // Left
                spriteBatch.Draw(t, new Rectangle(currentTile.Rectangle.Right, currentTile.Rectangle.Top, 2, currentTile.Rectangle.Height), Color.Black); // Right
                spriteBatch.Draw(t, new Rectangle(currentTile.Rectangle.Left, currentTile.Rectangle.Top, currentTile.Rectangle.Width, 2), Color.Black); // Top
                spriteBatch.Draw(t, new Rectangle(currentTile.Rectangle.Left, currentTile.Rectangle.Bottom, currentTile.Rectangle.Width, 2), Color.Black); // Bottom

            }
            spriteBatch.Draw(display, new Rectangle((int)CameraManager.Instance.getCam().Pos.X - 550, (int)CameraManager.Instance.getCam().Pos.Y + 200, 64,64), Color.White);

          //  RenderManager.Instance.AddToDrawAble(display, new Vector2(0, 0));
                spriteBatch.DrawString(ResourceLoader.Instance.GetFont("mFont"), currentTileString, new Vector2((int)CameraManager.Instance.getCam().Pos.X - 550, (int)CameraManager.Instance.getCam().Pos.Y + 280), Color.Black);
           
                spriteBatch.DrawString(ResourceLoader.Instance.GetFont("mFont"), message, new Vector2((int)CameraManager.Instance.getCam().Pos.X - 300, (int)CameraManager.Instance.getCam().Pos.Y ), Color.Black);

       
        }

        #region Events

        public void OnMouseClick(object sender, MouseEventArgs mea)
        {

            for (int i = 0; i < map.getTiles.Count; i++ )
            {
                if (mea.boundsToWorldView.Intersects(map.getTiles[i].Rectangle))
                {
                    //This works to a point,
                    //Now we need the tilemap to only contain 1 list of tiles that sub from the Tiles class
                    //Even better we could have 1 list for drawing all of the tiles
                    //and a second getter method that iterates through all of the current collidable tiles on the mao
                    //and throws it up to the detection manager.
                    //And at the end of every update, the detection manager will request a new tilemap if the tilemap has changed
                    //this couyld be changed into an event but that sounds like a bit of effort
                    map.getTiles[i] = createTile(selected, map.getTiles[i].Rectangle, selected);
                    int qq =map.getTiles[i].Rectangle.X / 64;
                    int rr = map.getTiles[i].Rectangle.Y / 64;
                    map.MapRef[rr,qq] = selected;
                    Console.WriteLine(qq +" " + " " + rr);
                   
                }
            }
              
        }

        public void OnMouseScrollUp(object sender, MouseEventArgs mea)
        {
          

            CameraManager.Instance.getCam().Zoom += 0.01f;
        }

        public void OnMouseScrollDown(object sender, MouseEventArgs mea)
        {
          
            CameraManager.Instance.getCam().Zoom -= 0.01f;

        }

        public void OnMouseMoved(object sender, MouseEventArgs mea)
        {
             for (int i = 0; i < map.getTiles.Count; i++ )
            {
                 if (mea.boundsToWorldView.Intersects(map.getTiles[i].Rectangle))
                {
                    currentTile = map.getTiles[i];
                    // map.getTiles[i].texture = ResourceLoader.Instance.GetTex("Tile1");
                }
            }
          
              
        }

        public void OnKeyDown(object sender, KeyEventArgs kae)
        {
            if(kae.key == Keys.F)
            {
                saveMap();
            }

            if (kae.key == Keys.Up)
                if (selected < 8)
                {
                    selected += 1;
                    changeDisplay(selected);
                }
            if (kae.key == Keys.Down)
                if (selected > 1)
                {
                    selected -= 1;
                    changeDisplay(selected);

                }

          
        }

    
        #endregion


    }
}

