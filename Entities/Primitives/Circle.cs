using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Entities
{
    public class Circle : IDrawable
    {

        BasicEffect basicEffect;
        VertexPositionColor[] vertices;

        private Random random = Constants.r;

        public float Radius { get; set; }
        private Vector2 centre;
        public Vector2 Centre { get { return centre; } set { centre = value; } }
        private Texture2D texture;


        public Circle(int radius, Vector2 Centre)
        {
            this.Radius = radius;
            this.Centre = Centre;
            texture = createCircleText(radius);

            basicEffect = new BasicEffect(Constants.g);
            basicEffect.VertexColorEnabled = true;
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter(0, Constants.g.Viewport.Width, Constants.g.Viewport.Height, 0, 0, 1);



            vertices = new VertexPositionColor[100];
            for (int i = 0; i < 99; i++)
            {
                float angle = (float)(i / 100.0f * Math.PI * 2);
                vertices[i].Position = new Vector3(Centre.X + (float)Math.Cos(angle) * 100, Centre.Y + (float)Math.Sin(angle) * 100, 0);
                vertices[i].Color = Color.Green;
            }

            vertices[99] = vertices[0];
        }


        public void Draw(SpriteBatch spriteBatch)
        {


            for (int i = 0; i < 99; i++)
            {
                float angle = (float)(i / 100.0f * Math.PI * 2);
                vertices[i].Position = new Vector3(Centre.X + (float)Math.Cos(angle) * Radius, Centre.Y + (float)Math.Sin(angle) * Radius, 0);
                vertices[i].Color = Color.Green;
            }
            vertices[99] = vertices[0];
     

            basicEffect.CurrentTechnique.Passes[0].Apply();
           // Constants.g.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, vertices, 0, 2);

            Constants.g.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineStrip, vertices, 0, 99);


            //   spriteBatch.Draw(texture, centre , Color.White);
        }


        //Solution not by me
        Texture2D createCircleText(int radius)
        {
            Texture2D texture = new Texture2D(Game1.Instance.GraphicsDevice, radius, radius);
            Color[] colorData = new Color[radius * radius];

            float diam = Radius / 2f;
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

        public Vector2 randomPos()
        {
            int x =(int)centre.X + (int)Radius * (int)Math.Cos(random.Next(0,(int)Radius));
            int y = (int)centre.Y + (int)Radius * (int)Math.Sin(random.Next(0, (int)Radius));

            if (x > centre.X)      
                x = (int)centre.X- (random.Next() % (int)Radius);
            else
                x = (int)centre.X + (random.Next() % (int)Radius);

            if (y > centre.Y)
                y = (int)centre.Y - (random.Next() % (int)Radius);
            else
                y = (int)centre.Y + (random.Next() % (int)Radius);

            return new Vector2(x, y);
        }
        
    }
}
