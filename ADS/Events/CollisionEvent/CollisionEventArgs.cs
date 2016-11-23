using ADS.Managers.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Events.CollisionEvent
{
   public class CollisionEventArgs
    {
      public ICollidable A { get; set; }
      public ICollidable B { get; set; }
    }
}
