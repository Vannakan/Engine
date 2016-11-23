using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.GUI
{

    //This class will soon allow for drawing certain objects to the screen (will change into rendermanager eventually) that ignore the cameras matrix transformations
    class GuiManager
    {

        private static GuiManager instance;

            public static GuiManager Instance()
        {
            if (instance == null)
                instance = new GuiManager();

            return instance;
        }


        public void Initialize()
        {

        }
    }
}
