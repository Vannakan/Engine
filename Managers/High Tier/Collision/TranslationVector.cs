using Engine.Managers.Collision;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Managers.High_Tier.Collision
{
    public static class TranslationVector
    {

        public static Vector2 GetMinimumTranslation(ICollidable A1, ICollidable B1)
        {
            //Vector for the minimum translation distance
            Vector2 mtd = new Vector2();
            Rectangle A = A1.Bounds;
            Rectangle B = B1.Bounds;
            //Calculate corners of both Bounding Boxes
            float xAMin = A.X;
            float xAMax = A.X + A.Width;
            float yAMin = A.Y;
            float yAMax = A.Y + A.Height;

            float xBMin = B.X;
            float xBMax = B.X + B.Width;
            float yBMin = B.Y;
            float yBMax = B.Y + B.Height;


            float left = (xBMin - xAMax);
            float right = (xBMax - xAMin);
            float top = (yBMin - yAMax);
            float bottom = (yBMax - yAMin);



            //Select direction that we need to move the ICollidable back by
            if (Math.Abs(left) < right)
            {
                mtd.X = left;
            }
            else
            {
                mtd.X = right;
            }

            if (Math.Abs(top) < bottom)
            {
                mtd.Y = top;
            }
            else
                mtd.Y = bottom;

            // 0 is the axis with the largest translation value/depth
            if (Math.Abs(mtd.X) < Math.Abs(mtd.Y))
            {
                mtd.Y = 0;
            }
            else
            {
                mtd.X = 0;

            }

            if (mtd.X > 0)
            {
                //   Console.WriteLine("Left");
            }

            if (mtd.X < 0)
            {
                //  Console.WriteLine("Right");
            }

            if (mtd.Y > 0)
            {
                // Console.WriteLine("Up");
            }
            if (mtd.X > 0)
            {
                // Console.WriteLine("Down");
            }




            return mtd;
        }
    }
}

