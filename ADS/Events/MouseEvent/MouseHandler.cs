using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace ADS.Events.MouseEvent
{
    //1- Define a delegate
    public class MouseHandler
    {
        public delegate void MouseEventHandler(object sender, MouseEventArgs e);
      

       //Singleton
        private static MouseHandler instance;
        public static MouseHandler Instance
        {
            get
            {
                if (instance == null)
                    instance = new MouseHandler();
                return instance;
            }
        }
        private MouseState prev, current;

        //Define an event based on that delegate
        public event MouseEventHandler MouseClick;
        public event MouseEventHandler MouseReleased;
        public event MouseEventHandler MouseHeld;
        //An event that clients can us to be notified whenever
        //change occurs

  
        public void Update()
        {
            prev = current;
            current = Mouse.GetState();

            if (current.LeftButton == ButtonState.Pressed || current.RightButton == ButtonState.Pressed)
                OnMouseDown(current);
        }

        //Raise the event
        protected virtual void OnMouseDown(MouseState m)
        {
            if (MouseClick != null)
            {
                MouseClick(this, new MouseEventArgs() { mouseState = m});
            }

        }

        protected virtual void OnMouseReleased(MouseState m)
        {
            if(MouseReleased != null)
            {
                MouseReleased(this, new MouseEventArgs() { mouseState = m });
            }
        }


    }
}
