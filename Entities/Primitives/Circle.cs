using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Entities
{
    public class Circle
    {
        public float Radius { get; set; }
        private Vector2 centre;
        public Vector2 Centre { get { return centre; } set { centre = value; } }
        private Texture2D texture;
        public Circle(int radius, Vector2 Centre)
        {
            this.Radius = radius;
            this.Centre = Centre;
            texture = createCircleText(radius);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, centre, Color.White);
        }


        //Solution not by me
        Texture2D createCircleText(int radius)
        {
            Texture2D texture = new Texture2D(Game1.Instance.GraphicsDevice, radius, radius);
            Color[] colorData = new Color[radius * radius];

            float diam = radius / 2f;
            float diamsq = diam * diam;

            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    int index = x * radius + y;
                    Vector2 pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq)
                    {
                        colorData[index] = Color.White;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;
        }
        
    }
}
