using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Engine.Managers;
using Engine;

namespace ADS.Tilemaps
{
    //Cellular Automata generation class
    public class CA
    {
        int[,] map;

        int fillPercent = 45;

        int mapWidth = 64;
        int mapHeight = 64;

        string seed = "";

        bool useRandomSeed = true;

       public  void Start()
        {
            GenerateMap();
        }

      public  void GenerateMap()
        {
            map = new int[mapWidth, mapHeight];
            RandomFill();

            for (int i = 0; i<5; i++)
            {
                SmoothMap();
            }

            Console.WriteLine("GENERATED");
        }

       public void RandomFill()
        {
            if (useRandomSeed)
                seed = DateTime.Now.TimeOfDay.ToString();

            System.Random random = new System.Random(seed.GetHashCode());

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (x == 0 || x == mapWidth - 1 || y == 0 || y == mapHeight - 1)
                    {
                        map[x, y] = 1;
                    }
                    else
                    {
                        map[x, y] = (random.Next(0, 100) < fillPercent) ? 1 : 0;
                    }
                }
            }
        }

        void SmoothMap()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    int neighbourWallTiles = GetSurroundingWallCount(x, y);
                    if (neighbourWallTiles > 4)
                        map[x, y] = 1;
                    else if (neighbourWallTiles < 4)
                        map[x, y] = 0;
                }

            }
        }

        int GetSurroundingWallCount(int x, int y)
        {
            int wallCount = 0;
            for (int neighbourX = x - 1; neighbourX <= x + 1; neighbourX++){
                for (int neighbourY = y - 1; neighbourY <= y + 1; neighbourY++){
                    if (neighbourX >= 0 && neighbourX < mapWidth && neighbourY >= 0 && neighbourY < mapHeight) {
                        if (neighbourX != x || neighbourY != y) {

                            wallCount += map[neighbourX, neighbourY];
                        }
                    }
                    else { wallCount++;
                    }

                }

            }
            return wallCount;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (map != null)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    for (int y = 0; y < mapHeight; y++)
                    {
                        if(map[x,y] == 1)
                        spriteBatch.Draw(ResourceLoader.Instance.GetTex("Tile1"), new Rectangle(x*64, y*64, 64, 64), Color.Black);
                        else
                            spriteBatch.Draw(ResourceLoader.Instance.GetTex("Tile2"), new Rectangle(x*64, y*64, 64, 64), Color.Red);

                    }

                }
            }

        }
    }
}
