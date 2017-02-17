using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Engine.Events.KeyboardEvent;
using Engine.Events.MouseEvent;
using ADS.Utility;
using ADS.Utilities;
using ADS.Utilities.Shapes;

namespace Engine
{
    //Basic screen for you to play around with baby <3
    public class GrantsPlayground : BaseScreen
    {

        #region Variables

        #endregion
        Line a;
        #region Constructor & Initialize
        public GrantsPlayground()
        {
        }

        public override void Initialize()
        {
            //Bind events

            KeyHandler.Instance.KeyDown += OnKeyDown;
            KeyHandler.Instance.KeyHeld += OnKeyHeld;
                MouseHandler.Instance.MouseMoved += OnMouseMoved;
            MouseHandler.Instance.MouseHeld += OnMouseHeld;


           a = DrawLine.newLine(Vector2.Zero, new Vector2(800, 800), Color.Black);
            DrawLine.newLine(new Vector2(800, 0), new Vector2(0, 800), Color.Black);
            base.Initialize();
        }


        #endregion

        #region Update & Draw


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Constants.g.Clear(Color.White);
            DrawPrimitives.DrawRect(spriteBatch, new Rectangle(100, 100, 100, 100), Color.Black);

            a.changePos(a.Start + new Vector2(1, 0), a.End + new Vector2(1, 0));
            base.Draw(spriteBatch);
        }

        #endregion

        #region InputEvents
        /// <summary>
        /// Example 
        /// if(k.key == Keys.A)
        //   Do action
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="k"></param>
        public void OnKeyDown(object sender, KeyEventArgs k)
        {
           
        }

        public void OnKeyHeld(object sender, KeyEventArgs k)
        {

        }
        public void OnMouseMoved(object sender, MouseEventArgs k)
        {

        }
        public void OnMouseHeld(object sender, MouseEventArgs k)
        {
            
        }

        #endregion
    }
}
