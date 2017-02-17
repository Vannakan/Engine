using ADS.Utilities;
using Engine;
using Engine.Managers.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Entities.SATTEST
{

    public struct OBB
    {
        public Point c; //centre point
        public Vector2[ ] u;//local axis
        public Vector2 e; 
    }
    public class RECTANGLE
    {
        //Basic Shader
        BasicEffect basicEffect;
        //A List of vertices that will be used to draw the shape
        VertexPositionColor[] vertices;

        //The edges of the rect
        Vector2 Max;
        Vector2 Min;

        Vector2 Pos;

        Vector2 center;

        float x, y, width, height;

        public  RECTANGLE(Vector2 pos)
        {
            Pos = pos;
            basicEffect = new BasicEffect(Constants.g);
            basicEffect.VertexColorEnabled = true;
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter(0, Constants.g.Viewport.Width, Constants.g.Viewport.Height, 0, 0, 1);

            vertices = new VertexPositionColor[8];
            vertices[0].Position = new Vector3(100 + Pos.X, 100 + Pos.Y, 0);
            vertices[0].Color = Color.Black;
            vertices[1].Position = new Vector3(200 + Pos.X, 100 + Pos.Y, 0);
            vertices[1].Color = Color.Black;
            vertices[2].Position = new Vector3(200 + Pos.X, 200 + Pos.Y, 0);
            vertices[2].Color = Color.Black;
            vertices[3].Position = new Vector3(100 + Pos.X, 200 + Pos.Y, 0);
            vertices[3].Color = Color.Black;
            vertices[4].Position = new Vector3(100+ Pos.X, 100 + Pos.Y, 0);
            vertices[4].Color = Color.Black;
            vertices[5].Position = new Vector3(100 + Pos.X, 200 + Pos.Y, 0);
            vertices[5].Color = Color.Black;
            vertices[6].Position = new Vector3(200 + Pos.X, 100 + Pos.Y, 0);
            vertices[6].Color = Color.Black;
            vertices[7].Position = new Vector3(200 + Pos.X, 200 + Pos.Y, 0);
            vertices[7].Color = Color.Black;


        }

        public RECTANGLE(Vector2 max, Vector2 min)
        {
            Max = max;
            Min = min;


            basicEffect = new BasicEffect(Constants.g);
            basicEffect.VertexColorEnabled = true;
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter(0, Constants.g.Viewport.Width, Constants.g.Viewport.Height, 0, 0, 1);

            //Apply vertice positions based on the corners of the square. Used for detection + something else I forgot im stoned atm
            vertices = new VertexPositionColor[8];
            vertices[0].Position = new Vector3(min.X, min.Y, 0);
            vertices[0].Color = Color.Black;
            vertices[1].Position = new Vector3(max.X, min.Y, 0);
            vertices[1].Color = Color.Black;
            vertices[2].Position = new Vector3(max.X, max.Y, 0);
            vertices[2].Color = Color.Black;
            vertices[3].Position = new Vector3(min.X, max.Y, 0);
            vertices[3].Color = Color.Black;
            vertices[4].Position = new Vector3(min.X, min.Y, 0);
            vertices[4].Color = Color.Black;
            vertices[5].Position = new Vector3(min.X, max.Y, 0);
            vertices[5].Color = Color.Black;
            vertices[6].Position = new Vector3(max.Y, min.X, 0);
            vertices[6].Color = Color.Black;
            vertices[7].Position = new Vector3(max.X, max.Y, 0);
            vertices[7].Color = Color.Black;

            center = new Vector2((Min.X + Max.X) / 2, (Min.Y + Max.Y) / 2);
        }

        public RECTANGLE( float X, float Y, float Width,float Height)
        {
            x = X;
            y = Y;
            width = Width;
            height = Height;
            Pos = new Vector2(x, y);
            Min = new Vector2(x, y);
            Max = new Vector2(width, height);

            basicEffect = new BasicEffect(Constants.g);
            basicEffect.VertexColorEnabled = true;
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter(0, Constants.g.Viewport.Width, Constants.g.Viewport.Height, 0, 0, 1);

            //Apply vertice positions based on the corners of the square. Used for detection + something else I forgot im stoned atm
            vertices = new VertexPositionColor[8];
            //Top Left
            vertices[0].Position = new Vector3(x, y, 0);
            vertices[0].Color = Color.Black;
            //top Right
            vertices[1].Position = new Vector3(width, y, 0);
            vertices[1].Color = Color.Black;
            //bottom Right
            vertices[2].Position = new Vector3(width, height, 0);
            vertices[2].Color = Color.Black;
            //bottom Left
            vertices[3].Position = new Vector3(x, height, 0);
            vertices[3].Color = Color.Black;
            //Top LEft
            vertices[4].Position = new Vector3(x, y, 0);
            vertices[4].Color = Color.Black;
            //Bottom Left
            vertices[5].Position = new Vector3(x, height, 0);
            vertices[5].Color = Color.Black;
           // Top Right
            vertices[6].Position = new Vector3(width, y, 0);
            vertices[6].Color = Color.Black;
            //Bottom Right
            vertices[7].Position = new Vector3(width, height, 0);
            vertices[7].Color = Color.Black;

            center = new Vector2((x + width) / 2, (y + height) / 2);
        }

        public void Draw(SpriteBatch spr)
        {

            testMove();
            basicEffect.CurrentTechnique.Passes[0].Apply();
            Constants.g.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, vertices, 0, 4);
            RenderManager.Instance.addString(new GameText("Centre", "mFont", center, Color.Black, 1f));
        }

        public void testMove()
        {

            x++;

            width++;

            vertices[0].Position = new Vector3(x, y, 0);
            vertices[0].Color = Color.Black;
            //top Right
            vertices[1].Position = new Vector3(width, y, 0);
            vertices[1].Color = Color.Black;
            //bottom Right
            vertices[2].Position = new Vector3(width, height, 0);
            vertices[2].Color = Color.Black;
            //bottom Left
            vertices[3].Position = new Vector3(x, height, 0);
            vertices[3].Color = Color.Black;
            //Top LEft
            vertices[4].Position = new Vector3(x, y, 0);
            vertices[4].Color = Color.Black;
            //Bottom Left
            vertices[5].Position = new Vector3(x, height, 0);
            vertices[5].Color = Color.Black;
            // Top Right
            vertices[6].Position = new Vector3(width, y, 0);
            vertices[6].Color = Color.Black;
            //Bottom Right
            vertices[7].Position = new Vector3(width, height, 0);
            vertices[7].Color = Color.Black;
        }
    }
}
