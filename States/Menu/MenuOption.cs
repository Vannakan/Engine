using Engine;
using Engine.Managers.CamManage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.States.Menu
{
    public class MenuOption
    {

        private Vector2 position;
        private Vector2 _texCenter;
        private Vector2 _screenCenter = CameraManager.Instance.getWorldPosition(new Vector2(Game1.Instance.graphics.PreferredBackBufferWidth / 2, Game1.Instance.graphics.PreferredBackBufferHeight / 2));

        private bool selected = false;
        public bool IsSelected { get { return selected; } set { selected = value; } }
        private string name = "";
        public string Name { get { return name; } set { name = value; } }
        private int index;
        public int Index { get { return index; } set { index = value; } }

        private float scale = 1.5f;

        private SpriteFont sf = ResourceLoader.Instance.GetFont("mFont");


        #region Constructor

        public MenuOption(string _name, float offset, int _index)
        {

        }

        /// <summary>
        /// Process:
        /// - Draw the button
        /// - Set the colour to white
        /// - If the Menu index == to the Buttons index, change the colour to yellow
        ///   to signify that it has been highlighted and is waiting for input
        /// </summary>
        /// <param name="spriteBatch"></param>
        ///
        int width = Game1.Instance.GraphicsDevice.Viewport.Width;
        int height = Game1.Instance.GraphicsDevice.Viewport.Height;
        public void Draw(SpriteBatch spriteBatch)
        {
            //  spriteBatch.Draw(buttonTexture, screenCenter,null, Color.White,0f,textureCenter,1f,SpriteEffects.None,0.5f);
            Color color = Color.Black;
            if (IsSelected)
            {
                color = Color.DarkRed;
                spriteBatch.DrawString(sf, Name, _screenCenter, color, 0, new Vector2(_texCenter.X / 7, _texCenter.Y / 2), scale + 0.25f, SpriteEffects.None, 0.5f);
            }
            else spriteBatch.DrawString(sf, Name, _screenCenter, color, 0, new Vector2(_texCenter.X / 7, _texCenter.Y / 2), scale, SpriteEffects.None, 0.5f);

        }

        #endregion
    }
}
