using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    static class Constants
    {
        public static int ID = 0;
        public static GraphicsDevice g {get; set;}
        public static Vector2 ScreenCentre { get; set; }
        public static Camera cam { get; set; }
        public static int TileSize = 64;
        public static Color colour = Color.Maroon;
        public static Random r;
       
    }
}
