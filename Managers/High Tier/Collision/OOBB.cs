using Engine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Managers.High_Tier.Collision
{
   public static  class OOBB
    {

        //Check for collision between two circles
        public static bool circleCollision(Circle a, Circle b)
        {
            float distance = Vector2.Distance(a.Centre, b.Centre);
            if (a.Radius + b.Radius > distance)
            {
                return true;
            }
            return false;
        }
    }
}
