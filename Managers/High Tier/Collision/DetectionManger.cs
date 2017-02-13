using Engine.Entities;
using Engine.Events.CollisionEvent;
using Engine.Managers.EntityRelated;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Managers;
using ADS.Entities;
using ADS.Managers.High_Tier.Collision;

namespace Engine.Managers.Collision
{
    public class DetectionManger : IUpdateEngineComponent
    {

        public delegate void CollisionEventHandler(object sender, CollisionEventArgs e);

        public event CollisionEventHandler OnCollision;


        //List of collidable entities
        private List<ICollidable> collision = new List<ICollidable>();
        //Tile map
        private TileMap collTiles;

        private static DetectionManger instance;

        public static DetectionManger Instance
        {
            get
            {
                if (instance == null)
                    instance = new DetectionManger();

                return instance;
            }
        }

        /// <summary>
        /// Adds an ICollidable interface to the collision list ready to check for collisions
        /// </summary>
        /// <param name="obj"></param>
        public void addCollidable(ICollidable obj)
        {
            collision.Add(obj);
            Console.WriteLine("Object Added to Collision list" + obj.GetType());
        }

        public void removeCollidable(ICollidable obj)
        {

        }

        public void wipeList()
        {
            collision.Clear();
            collTiles = null;
        }
        public void clearManager()
        {
            collision.Clear();
            collTiles = null;

        }


        //need to go
        public void setTileMap(TileMap t)
        {
            collTiles = t;

        }




        public void Update(GameTime gameTime)
        {

           // doCollision();
            calcTerrainCollision();
        }

        /// <summary>
        /// Checks Collision between dynamic entities.
        /// </summary>
        public void doCollision()
        {
            if (collision.Count >= 2)
            {
                //Iterate through the list twice, counting one object above the first each time
                for (int i = 0; i < collision.Count; i++)
                {
                    for (int k = i + 1; k < collision.Count; k++)
                    {
                        //Check that they're not equal objects
                        if (collision[i] != collision[k])
                        {
                            var A = collision[i];
                            var B = collision[k];

                            Vector2 distance = B.Position - A.Position;
                            if (distance.Length() > 50)
                                continue;
                            else
                            //Checks if there's a collision, but also checks if A is a controller character, if so then it will move A around, otherwise tiles may have problems
                            if (AABB.Collision(A.Bounds, B.Bounds))
                            {
                                //Find minimum translation distance
                                // A.Velocity = new Vector2(A.Velocity.X, 0);
                                Vector2 mtd = TranslationVector.GetMinimumTranslation(A, B);
                                Console.WriteLine(mtd);
                                //Apply it to the source collidable
                                A.Position += mtd;
                            }
                        }
                    }
                }
            }
        }
         

        //  }


            /// <summary>
            /// Checks collision between a list of dynamic entities and a list of static (Terrain/Tile) entities
            /// Calculates the minimum translation distance and respondes by moving the 
            /// dynamic entity accordingly
            /// 
            /// This method is programmed to be used with a tilemap
            /// </summary>
            /// 

        public void calcTerrainCollision()
        {
            if (collTiles != null)
            {

                for (int i = 0; i < collTiles.CollisionTiles.Count; i++)
                {
                    for (int k = 0; k < collision.Count; k++)
                    {


                        var A = collision[k];


                        var B = collTiles.CollisionTiles[i];

                        if (AABB.Collision(A.Bounds, B.Bounds))
                        {
                            OnACollision(A, B);
                        }

                    }
                }
            }
        }



        /// <summary>
        /// Iterates through the player collision list and the tile list
        /// 
        /// Checks if the player and the 
        /// </summary>

        public void doCollisions()
        {
            {
                if (collTiles != null)
                {

                    for (int i = 0; i < collTiles.getTiles.Count; i++)
                    {
                        for (int k = 0; k < collision.Count; k++)
                        {
                            var A = collision[k];
                            var B = collTiles.getTiles[i];
                            //If !B.IsCollidable
                            //continue;
                            //else
                            //    if (Collision(A, B))
                            //  {

                            var type = collTiles.getTiles[i].GetType().Name;
                            switch (type)
                            {
                                case "DirectionTile":
                                    //Throw in Corresponding Event
                                    break;
                                case "CollisionTile":
                                    //Throw in Corresponding Event
                                    break;
                                    //  }

                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Tells any entities that care about colliding with other entities that they have collided, and what entity they have collided with.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        public void OnACollision(ICollidable A, ICollidable B)
        {
            if (OnCollision != null)
            {
                OnCollision(this, new CollisionEventArgs() { A = A, B = B });
            }
        }

    }
}