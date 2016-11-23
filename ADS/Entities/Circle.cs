using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Entities
{
    public class Circle
    {
        private double PI = 3.14159;
        public float Radius { get; set; }
        private Vector2 centre;
        public Vector2 Centre { get{return centre;} set{centre = value;} }

        public Circle(float radius ,Vector2 Centre)
        {
            this.Radius = radius;
            this.Centre = Centre;
        }


     public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, centre, Color.White);
        }
    }
}
