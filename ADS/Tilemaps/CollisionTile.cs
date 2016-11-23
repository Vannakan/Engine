using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ADS.Managers.Collision;
using ADS.Entities;

namespace ADS
{
   public class CollisionTile : Tiles, ICollidable
   {

       #region Data Members
       public bool isCollidable { get; set; }
       #endregion
       public IMind gMind { get { return null; } }
        public Rectangle Bounds { get { return rectangle; } }
        Vector2 pos;
        public Vector2 Position { get { return new Vector2(rectangle.Center.X, rectangle.Center.Y); } set { pos = value; } }

        public Vector2 Velocity { get; set; }

        private bool C;
        public bool controlled { get { return C; } }
        public bool isColliding { get; set; } 

        #region Constructors

        public CollisionTile()
        {
            isCollidable = false;
        }

        public CollisionTile(int i, Rectangle rect )
        {

            texture = ResourceLoader.Instance.GetTex("Tile" + i);
                this.Rectangle = rect;

                if (i > 0)
                {
                    isCollidable = true;
                }
                else
                {
                    isCollidable = false;
                }
        }

        #endregion

    }
}
