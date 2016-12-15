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
    public class BlankTile : Tiles, ICollidable
    {
        public Direction Direction;
        public Rectangle Bounds { get { return rectangle; } }
        Vector2 pos;
        public Vector2 Position { get { return new Vector2(rectangle.Center.X, rectangle.Center.Y); } set { pos = value; } }

        public bool isCollidable { get; set; }
        public bool isColliding { get; set; }
        public BlankTile(Rectangle rect)
        {
            this.Rectangle = rect;
            texture = ResourceLoader.Instance.GetTex("Tile8");
        }
    }
}
