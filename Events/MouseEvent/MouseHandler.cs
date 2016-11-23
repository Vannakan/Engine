using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Managers;

using System.Windows.Input;
namespace Engine.Events.MouseEvent
{
    //1- Define a delegate
    public class MouseHandler : IUpdateEngineComponent
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
        public event MouseEventHandler MouseMoved;
        public event MouseEventHandler MouseHeld;
        public event MouseEventHandler MouseScrollUp;
        public event MouseEventHandler MouseScrollDown;
        //An event that clients can us to be notified whenever
        //change occurs

  
        public void Update(GameTime gameTime)
        {
            prev = current;
            current = Mouse.GetState();

            if (current.X != prev.X || current.Y != prev.Y)
                OnMouseMoved(current);
         
            if(prev.LeftButton == ButtonState.Pressed && current.LeftButton == ButtonState.Released)
                OnMouseDown(current);

            if (current.ScrollWheelValue > prev.ScrollWheelValue)
            {
                OnMouseScrollUp(current);

            }
            if (current.ScrollWheelValue < prev.ScrollWheelValue)
            {
                OnMouseScrollDown(current);

            }
        }

        //Raise the event
        protected virtual void OnMouseDown(MouseState m)
        {
            if (MouseClick != null)
            {
                MouseClick(this, new MouseEventArgs() { mouseState = m});
            }

        }

        protected virtual void OnMouseScrollUp(MouseState m)
        {
            if(MouseScrollUp != null)
            {
                MouseScrollUp(this, new MouseEventArgs() { mouseState = m });
            }
        }

        protected virtual void OnMouseScrollDown(MouseState m)
        {
            if (MouseScrollDown != null)
            {
                MouseScrollDown(this, new MouseEventArgs() { mouseState = m });
            }
        }

        protected virtual void OnMouseReleased(MouseState m)
        {
            if(MouseReleased != null)
            {
                MouseReleased(this, new MouseEventArgs() { mouseState = m });
            }
        }

        protected virtual void OnMouseMoved(MouseState m)
        {
            if(MouseMoved != null)
            {
                MouseMoved(this, new MouseEventArgs() { mouseState = m});
            }
        }

        


    }
}
