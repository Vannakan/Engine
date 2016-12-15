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

namespace Engine.Managers.Collision
{
    public class DetectionManger : IUpdateEngineComponent
    {

        public delegate void CollisionEventHandler(object sender, CollisionEventArgs e);

        public event CollisionEventHandler OnCollision;

        public event CollisionEventHandler OnDirectionSwitch;

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
           Console.WriteLine("Object Added to Collision list");
        }

        public void clearManager()
    {
        collision.Clear();
        collTiles = null;
            
    }

    public void setTileMap(TileMap t)
    {
        collTiles = t;
    }

    //Check for collision between two circles
    public bool circleCollision(Circle a, Circle b)
    {
        float distance = Vector2.Distance(a.Centre, b.Centre);
        if (a.Radius + b.Radius > distance)
        {
            return true;
        }
        return false;
    }

        //Returns true if the bounds are intersecting
        public bool Collision(ICollidable a, ICollidable b)
    {
        return !(b.Bounds.Left > a.Bounds.Right||
                 b.Bounds.Right < a.Bounds.Left ||
                 b.Bounds.Top > a.Bounds.Bottom ||
                 b.Bounds.Bottom < a.Bounds.Top  );
        
    }




        public void Update(GameTime gameTime)
        {

            //doCollision();
            calcTerrainCollision();
            calcDirectionCollision();
        }

        /// <summary>
        /// Checks Collision between dynamic entities.
        /// </summary>
        //public void doCollision()
        //{
        //    if (collision.Count >= 2 )
        //    {
        //        //Iterate through the list twice, counting one object above the first each time
        //        for (int i = 0; i < collision.Count; i++)
        //        {
        //            for (int k = i + 1; k < collision.Count; k++)
        //            {
        //                //Check that they're not equal objects
        //                if (collision[i] != collision[k])
        //                {
        //                    var A = collision[i];
        //                    var B = collision[k];

        //                    //Checks if there's a collision, but also checks if A is a controller character, if so then it will move A around, otherwise tiles may have problems
        //                    if (Collision(A, B) && A.isCollidable && B.isCollidable)
        //                    {
        //                        //Find minimum translation distance
        //                        A.Velocity = new Vector2(A.Velocity.X, 0);
        //                        Vector2 mtd = GetMinimumTranslation(A.Bounds, B.Bounds);
        //                        Console.WriteLine(mtd);
        //                        //Apply it to the source collidable
        //                        A.Position += mtd;
        //                    }
        //                }
        //            }
        //        }
        //    }
            //If the two Entities are colliding,
            //calculate the minimum translation distance
            //then adjust the position by the minimum translation distance
     
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

                            if (Collision(A, B))
                            {
                                OnACollision(A, B);
                            }
                        
                    }
                }
            }
        }

        //Method needs to go
        public void calcDirectionCollision()
        {
            if (collTiles != null)
            {

                for (int i = 0; i < collTiles.DirectionTiles.Count; i++)
                {
                    for (int k = 0; k < collision.Count; k++)
                    {


                        var A = collision[k];
                        if (A.GetType().Equals(typeof(CreepMind)))
                        {

                            var B = collTiles.DirectionTiles[i];

                            if (Collision(A, B))
                            {
                                OnADirectionSwitch(B.Direction, B);
                            }
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
                if(OnCollision != null)
                {
                    OnCollision(this, new CollisionEventArgs() { A = A, B = B });
                }
        }

        public void OnADirectionSwitch(Direction D, ICollidable B)
            {
            if(OnDirectionSwitch != null)
            {
                OnDirectionSwitch(this, new CollisionEventArgs() { D = D, B = B});
            }
            }

        /// <summary>
        /// Tells any entities that care about terrain collisions that they have collided with terrain, and what terrain they have collided with.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
      
        


        /// <summary>
        /// Method is simply a template to use inside of classes and isn't used in this manager
        /// </summary>
        /// <param name="A1"></param>
        /// <param name="B1"></param>
        /// <returns></returns>

        public Vector2 GetMinimumTranslation(ICollidable A1, ICollidable B1)
        {
            //Vector for the minimum translation distance
            Vector2 mtd = new Vector2();
           Rectangle A = A1.Bounds;
           Rectangle B = B1.Bounds;
            //Calculate corners of both Bounding Boxes
           float xAMin = A.X;
           float xAMax = A.X + A.Width;
           float yAMin = A.Y;
           float yAMax = A.Y + A.Height;

           float xBMin = B.X;
           float xBMax = B.X + B.Width;
           float yBMin = B.Y;
           float yBMax = B.Y + B.Height;


            float left = (xBMin - xAMax);
            float right = (xBMax - xAMin);
            float top = (yBMin - yAMax);
            float bottom = (yBMax - yAMin);


         
           //Select direction that we need to move the ICollidable back by
            if (Math.Abs(left) < right)
            {
                mtd.X = left;
            }
            else
            {
                mtd.X = right;
            }

            if (Math.Abs(top) < bottom)
            {
                mtd.Y = top;
            }
            else
                mtd.Y = bottom;

            // 0 is the axis with the largest translation value/depth
            if (Math.Abs(mtd.X) < Math.Abs(mtd.Y))
            {
                mtd.Y = 0;
            }
            else
            {
                mtd.X = 0;

            }

            if(mtd.X > 0)
            {
             //   Console.WriteLine("Left");
            }

            if (mtd.X < 0)
            {
              //  Console.WriteLine("Right");
            }

            if (mtd.Y > 0)
            {
               // Console.WriteLine("Up");
            }
            if (mtd.X > 0)
            {
               // Console.WriteLine("Down");
            }




            return mtd;
        }
    }
}
