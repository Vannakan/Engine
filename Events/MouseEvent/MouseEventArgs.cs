using Engine.Managers.CamManage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Events.MouseEvent
{
    public class MouseEventArgs : EventArgs
    {

        public int X { get { return mouseState.X; } }
        public int Y { get { return mouseState.Y; } }
       public ButtonState currentButton { get; set; }
        public MouseState mouseState { get; set; }
        public Rectangle Bounds { get { return new Rectangle(mouseState.X ,mouseState.Y,1,1); } }

        public Rectangle boundsToWorldView { get {

            Vector2 worldPos = CameraManager.Instance.getWorldPosition(new Vector2(mouseState.X,mouseState.Y));
            return new Rectangle((int)worldPos.X, (int)worldPos.Y, 1, 1);
        } }
    }
}
