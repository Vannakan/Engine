using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.GUI
{
    public abstract class GuiElement : IGuiElement
    {
        //A list of elements that can be changed (HP
        protected Dictionary<string, int> vElements;
        public GuiElement()
        {

        }


       
    }
}
