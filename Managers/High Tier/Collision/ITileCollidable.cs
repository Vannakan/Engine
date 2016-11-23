using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Managers.Collision
{
   public interface ITileCollidable
    {
        Rectangle Bounds { get; }

         Vector2 Position { get; set; }

         Vector2 Velocity { get; set; }

         bool C { get; }
         bool controlled { get;}
         bool isColliding { get; set; } 
    }
}
