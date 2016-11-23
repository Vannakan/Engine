using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Events.KeyboardEvent
{
   public class KeyListener
    {

        public void OnKeyDown(object sender, KeyEventArgs e)
       {
           Console.WriteLine("Key Event fired, KEY PRESSED : " + e.key);
       }
    }
}
