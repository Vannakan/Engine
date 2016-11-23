using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Events.MouseEvent
{
    public class MouseEventArgs : EventArgs
    {

        public int X { get; set; }
        public int Y { get; set; }
        public MouseState mouseState { get; set; }
    }
}
