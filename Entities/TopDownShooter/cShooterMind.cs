using Engine.Events.KeyboardEvent;
using Engine.Events.MouseEvent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Entities.TopDownShooter
{
    public class cShooterMind : Mind
    {
        int moveSpeed = 7;

        public cShooterMind()
        {
            MouseHandler.Instance.MouseClick += OnMouseDown;
            KeyHandler.Instance.KeyDown += OnKeyDown;
            KeyHandler.Instance.KeyHeld += OnKeyHeld;
        }



        public override void Unload()
        {
            base.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Initialize(Vector2 Position, string t)
        {
            // base.Initialize(Position, t);
        }


        #region Input Related
        private void OnKeyHeld(object sender, KeyEventArgs kea)
        {
            switch (kea.key)
            {
                case Keys.W:
                    e.Position = new Vector2(e.Position.X, e.Position.Y - moveSpeed);
                    break;
                case Keys.S:
                    e.Position = new Vector2(e.Position.X, e.Position.Y + moveSpeed);
                    break;
                case Keys.D:
                    e.Position = new Vector2(e.Position.X + moveSpeed, e.Position.Y);
                    break;
                case Keys.A:
                    e.Position = new Vector2(e.Position.X - moveSpeed, e.Position.Y);
                    break;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            // throw new NotImplementedException();
        }

        #endregion
    }
}
