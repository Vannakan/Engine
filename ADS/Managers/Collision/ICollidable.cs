using ADS.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Managers.Collision
{
    public interface ICollidable
    {
       Rectangle Bounds { get; }

       Vector2 Position { get; set; }

     //  Vector2 Velocity { get; set; }

       bool isCollidable { get; set; }
      // bool controlled { get; }

       bool isColliding { get; set; }


        
       
    }
}
