using Engine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS
{
   public class spawnerTest : Mind
    {

        int radius;
        int cx;
        int cy;
        int i = 0;
        Vector2[] test = new Vector2[5];

        public spawnerTest(int x,int y, int radius)
        {
            cx = x;
            cy = y;
            this.radius = radius;
        }

        
    }
}
