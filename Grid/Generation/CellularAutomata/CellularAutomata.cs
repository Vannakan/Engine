using Engine.Entities;
using Engine.Managers.EntityRelated;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Grid.Generation.CellularAutomata
{
    public static class CellularAutomata
    {

        public static int[,] makeMap(int fillPercent, int mapWidth, int mapHeight)
        {
            int[,] map = new int[mapWidth, mapHeight];
            map = randomFill(map,fillPercent);
            for (int i = 0; i < 5; i++)
            {
                map = smoothMap(map);

            }
            return map;
        }

      //  private static int[,] generate

        private static int[,] makeTunnels()
        {
            return new int[4, 5];
        }

        private static int[,] randomFill(int[,] _map, int fillPercent)
        {
            int[,] map = _map;
            System.Random random = new System.Random();
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (x == 0 || x == map.GetLength(0) - 1 || y == 0 || y == map.GetLength(1) - 1)
                    {
                        map[x, y] = 1;
                    }
                    else
                    {
                        map[x, y] = (random.Next(0, 100) < fillPercent) ? 1 : 0;
                    }
                }
            }
            return map;
        }

        private static int[,] smoothMap(int[,] _map)
        {
            int[,] map = _map;
            for (int x = 0; x < _map.GetLength(0); x++)
            {
                for (int y = 0; y < _map.GetLength(1); y++)
                {
                    int neighbourWallTiles = getsurroundingwalls(x, y,map, map.GetLength(0), map.GetLength(1));
                    if (neighbourWallTiles > 4)
                        map[x, y] = 1;
                    else if (neighbourWallTiles < 4)
                        map[x, y] = 0;


                }

            }
            return new int[4, 5];
        }

        private static int getsurroundingwalls (int x,int y, int[,] map, int mapWidth, int mapHeight)
            {

            //number of neighbours which are walls
            int wallCount = 0;
            for (int neighbourX = x - 1; neighbourX <= x + 1; neighbourX++)
            {
                for (int neighbourY = y - 1; neighbourY <= y + 1; neighbourY++)
                {
                    //Make sure in bounds of index && Check for walls
                    if (neighbourX >= 0 && neighbourX < mapWidth && neighbourY >= 0 && neighbourY < mapHeight)
                    {
                        if (neighbourX != x || neighbourY != y)
                        {
                            wallCount += map[neighbourX, neighbourY];
                        }
                    }
                    else
                    {
                        wallCount++;
                    }

                }

            }
            return wallCount;
        }

        private static int[,] makeSpawn(int[,] _map)
        {
            int[,] map = _map;
            bool entityAdded = false;

            for (int x = 0; x < map. GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == 0 && entityAdded == false)
                    {
                        EntityManager.Instance.createEntityCamDrawable<pEntity>(new Vector2(x * 64, y * 64));
                        entityAdded = true;
                        return map;
                    }

                }


            }


            return map;
        }



    }
}
