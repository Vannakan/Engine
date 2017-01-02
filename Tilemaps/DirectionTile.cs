using ADS.Entities;
using Engine.Entities;
using Engine.Managers.Collision;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Tilemaps
{
    /// <summary>
    /// Contains a direction enum 
    /// Whenever entity collides, entity can change it's direction based on tiles direction
    /// </summary>
    public class DirectionTile : Tiles, ICollidable
    {
        public Direction Direction;
        public Rectangle Bounds { get { return rectangle; } }
        Vector2 pos;
        public Vector2 Position { get { return new Vector2(rectangle.Center.X, rectangle.Center.Y); } set { pos = value; } }

        public bool isCollidable { get; set; }
        public bool isColliding { get; set; }
       public DirectionTile(Rectangle rect, Direction d)
        {
            Direction = d;
            this.Rectangle = rect;
            texture = ResourceLoader.Instance.GetTex("Tile1");
        }
    }
}
