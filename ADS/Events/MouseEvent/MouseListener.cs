using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Events.MouseEvent
{
   public class MouseListener
    {

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Listener hears you : X " + e.mouseState.X + " Y " + e.mouseState.Y);
            Console.WriteLine("Listener hears you : LEFT CLICK" + e.mouseState.LeftButton + " RIGHT CLICK " + e.mouseState.RightButton);
      
        }
    }
}



