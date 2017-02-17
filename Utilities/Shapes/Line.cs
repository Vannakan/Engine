using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Utilities.Shapes
{
    public class Line : Engine.IDrawable
    {

        BasicEffect basicEffect;
        VertexPositionColor[] vertices;

       public Vector2 Start;
       public Vector2 End;

        public Line()
        {
            basicEffect = new BasicEffect(Constants.g);
            basicEffect.VertexColorEnabled = true;
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter(0, Constants.g.Viewport.Width, Constants.g.Viewport.Height, 0, 0, 1);

        }

        public void newLine(Vector2 start, Vector2 end, Color color)
        {
            Start = start;
            End = end;
            vertices =  new VertexPositionColor[2];
            vertices[0].Position = new Vector3(start, 0);
            vertices[0].Color = color;
            vertices[1].Position = new Vector3(end, 0);
            vertices[1].Color = color;
        }

        public void changePos(Vector2 start,Vector2 end)
        {
            Start = start;
            End = end;
            vertices[0].Position = new Vector3(Start, 0);
            vertices[1].Position = new Vector3(End, 0);

        }

        public void Draw(SpriteBatch spr)
        {
            basicEffect.CurrentTechnique.Passes[0].Apply();
            Constants.g.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, vertices, 0, 1);
        }
    }
}
