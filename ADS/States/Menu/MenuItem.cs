using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ADS
{
    class MenuItem
    {
        #region Variables
        private Vector2 position;
        //Variable to hold the Items SpriteFont
        private SpriteFont spriteFont;
        //Variable to hold the Items Texture
        Texture2D buttonTexture;

        #endregion
        #region Properties
        public bool IsSelected { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        #endregion
        #region Constructor


        public MenuItem(string _name, Vector2 _position, SpriteFont _spriteFont, int _index,Texture2D bTex)
        {
            Name = _name;
            position = _position;
            spriteFont = _spriteFont;
            IsSelected = false;
            Index = _index;
            buttonTexture = bTex;
        }
        #endregion
        #region Draw

        /// <summary>
        /// Process:
        /// - Draw the button
        /// - Set the colour to white
        /// - If the Menu index == to the Buttons index, change the colour to yellow
        ///   to signify that it has been highlighted and is waiting for input
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(buttonTexture, new Vector2(position.X -50, position.Y-5), Color.White);
            Color color = Color.White;
            if (IsSelected)
            {
                color = Color.Yellow;                
                spriteBatch.DrawString(spriteFont, Name, position, color);
            }
            else spriteBatch.DrawString(spriteFont, Name, position, color);
        }
        #endregion
    }
}
