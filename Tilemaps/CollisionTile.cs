using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Engine.Managers.Collision;
using Engine.Entities;

namespace Engine
{
    /// <summary>
    /// Tile that provides collision
    /// </summary>
   public class CollisionTile : Tiles, ICollidable
   {

       #region Data Members
       public bool isCollidable { get; set; }
       #endregion
        public Rectangle Bounds { get { return rectangle; } }
        Vector2 pos;
        public Vector2 Position { get { return new Vector2(rectangle.Center.X, rectangle.Center.Y); } set { pos = value; } }


        public bool isColliding { get; set; } 

        #region Constructors

        public CollisionTile()
        {
            isCollidable = true;
        }

        public CollisionTile(Rectangle rect)
        {
            isCollidable = true;
        }


        public CollisionTile(int i, Rectangle rect )
        {

            texture = ResourceLoader.Instance.GetTex("Tile" + i);
                this.Rectangle = rect;

               
        }

        #endregion

    }
}
