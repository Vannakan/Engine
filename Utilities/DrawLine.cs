using ADS.Utilities.Shapes;
using Engine.Managers.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Utilities
{
    static class DrawLine
    {
       
        public static Line newLine(Vector2 start, Vector2 end, Color color)
        {
            Line line = new Line();
            line.newLine(start, end, color);
            RenderManager.Instance.addDrawable(line);

            return line;
        }


    }
}
