using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Utilities
{
    public class GameText
    {
       private string text, font;
       private float size;
       private  Vector2 pos;
       private Color color;
        public GameText(string text, string font, Vector2 pos, Color color, float size)
        {
            this.text = text;
            this.font = font;
            this.pos = pos;
            this.color = color;
            this.size = size;
        }

        public void Draw(SpriteBatch spr)
        {
            if(font == null)
            Utility.DrawString.Draw(text, spr, pos, color, size);
            else
                Utility.DrawString.Draw(text,font, spr, pos, color, size);

        }

    }
}
