using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ADS.Managers.EntityRelated;
using ADS.Entities;

namespace ADS
{
   public class TileMap
   {
       #region Variables
       //Variable to hold all tiles 
        private List<CollisionTile> collisionTiles = new List<CollisionTile>();
       //List to hold all tiles that dont contain collision
        private List<DrawTile> drawTiles = new List<DrawTile>();

       //Variables to hold the tiles width and height
        private int width, height;

       #endregion


       #region Properties

        //Property to give all tiles reference to another class (used to compare intersection)
        public List<CollisionTile> CollisionTiles
        {
            get { return collisionTiles; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        #endregion

       #region Constructor & Map Generation method
        public TileMap()
        {

        }

        public void GenerateLayer(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if (number > 0 & number < 9)
                        drawTiles.Add(new DrawTile(number, new Rectangle(x * size, y * size, size, size)));
                }
            }
        }
        
               
               public void Generate(int[,] map, int size)
        {

            for (int x = 0; x < map.GetLength(1); x++)
            {
                for(int y = 0; y < map.GetLength(0); y++)
                {
                   int number = map[y, x];
                    
                    if (number > 0 & number <9)
                        collisionTiles.Add(new CollisionTile(number, new Rectangle(x * size, y * size, size, size)));
                    if(number == 10)
                    {
                        EntityManager.Instance.createEntity<pEntity>(new Vector2(x * size, y * size), "player");
                    }
                    if (number == 11)
                    {
                        EntityManager.Instance.createEntity<trapEntity>(new Vector2(x * size, y * size), "player");
                    }
                    if(number == 12 )
                    {
                        EntityManager.Instance.createEntity<c1Entity>(new Vector2(x * size, y * size), "c1");

                    }
                  if(number == 13)
                  {
                      EntityManager.Instance.createEntity<c1Entity>(new Vector2(x * size, y * size), "c2");

                  }
                    if(number == 14)
                    {
                        EntityManager.Instance.createEntity<c1Entity>(new Vector2(x * size, y * size), "c3");

                    }
                    if(number == 15)
                    {
                        EntityManager.Instance.createEntity<c1Entity>(new Vector2(x * size, y * size), "c4");

                    }
                    if(number == 16)
                    {
                        EntityManager.Instance.createEntity<c1Entity>(new Vector2(x * size, y * size), "c5");

                    }
                    if(number == 17)
                    {
                        EntityManager.Instance.createEntity<c1Entity>(new Vector2(x * size, y * size), "c6");

                    }
                  

                    width = (x + 1) * size;
                    height = (y + 1) * size;
                }
            }

        }

        #endregion

        #region Draw
        public void Draw(SpriteBatch spriteBatch)
        {

            foreach(DrawTile tile in drawTiles)
            {
                tile.Draw(spriteBatch);
            }
            foreach(CollisionTile tile in collisionTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
        #endregion


   }
}
