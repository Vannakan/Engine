using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Utility
{
    static class DrawPrimitives
    {
        //Temporary
        public static void DrawRect(SpriteBatch spriteBatch, Rectangle Bounds, Color color)
        {
            var t  = new Texture2D(Engine.Constants.g, 1, 1);
            t.SetData(new[] { Color.White });
            spriteBatch.Draw(t, new Rectangle(Bounds.Left, Bounds.Top, 1, Bounds.Height), color); // Left
            spriteBatch.Draw(t, new Rectangle(Bounds.Right, Bounds.Top, 1, Bounds.Height), color); // Right
            spriteBatch.Draw(t, new Rectangle(Bounds.Left, Bounds.Top, Bounds.Width, 1), color); // Top
            spriteBatch.Draw(t, new Rectangle(Bounds.Left, Bounds.Bottom, Bounds.Width, 1), color); // Bottom
        }
        public static void DrawCircle(SpriteBatch spriteBatch, Engine.Entities.Circle circle)
        {

        }
    }
}
