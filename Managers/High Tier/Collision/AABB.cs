using Engine.Managers.Collision;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Managers.High_Tier.Collision
{
    public static class AABB
    {
        //Returns true if the bounds are intersecting
        public static bool Collision(Rectangle a, Rectangle b)
        {

            return !(b.Left > a.Right ||
              b.Right < a.Left ||
              b.Top > a.Bottom ||
              b.Bottom < a.Top);


            //Icollidable approach
            //return !(b.Bounds.Left > a.Bounds.Right ||
            //         b.Bounds.Right < a.Bounds.Left ||
            //         b.Bounds.Top > a.Bounds.Bottom ||
            //         b.Bounds.Bottom < a.Bounds.Top);

        }
    }
}
