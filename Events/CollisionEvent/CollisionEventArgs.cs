using ADS.Entities;
using Engine.Entities;
using Engine.Managers.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Events.CollisionEvent
{
   public class CollisionEventArgs
    {
       //entity
      public ICollidable A { get; set; }
       //Object in which the entity is colliding with
      public ICollidable B { get; set; }

       //Used for Direction tiles
     // public Direction D { get; set; }
    }
}
