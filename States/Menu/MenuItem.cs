using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Managers.CamManage;

namespace Engine
{
    class MenuItem
    {
        #region Variables
        public Vector2 position;
        //Variable to hold the Items SpriteFont
        private SpriteFont spriteFont;
        //Variable to hold the Items Texture
        Texture2D buttonTexture;
        Vector2 textureCenter;
        Vector2 screenCenter = CameraManager.Instance.getWorldPosition(new Vector2(Game1.Instance.graphics.PreferredBackBufferWidth / 2, Game1.Instance.graphics.PreferredBackBufferHeight / 2));
        //Unused for now
        Vector2 textCenter;
        #endregion
        #region Properties
        public bool IsSelected { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }

        public float scale = 1.5f;
        float enlarged = 1.75f;
        
        #endregion
        #region Constructor


        public MenuItem(string _name, float yOffset, SpriteFont _spriteFont, int _index,Texture2D bTex)
        {
            Name = _name;
            spriteFont = _spriteFont;
            IsSelected = false;
            Index = _index;
            buttonTexture = bTex;
             textureCenter = CameraManager.Instance.getWorldPosition( new Vector2(buttonTexture.Width / 2, buttonTexture.Height / 2));
            
             screenCenter.Y = yOffset;

           textureCenter = new Vector2(spriteFont.Texture.Width/2, spriteFont.Texture.Height/2);

        }

        public MenuItem(string _name, float yOffset, SpriteFont _spriteFont, int _index, Texture2D bTex,float scale)
        {
            Name = _name;
            spriteFont = _spriteFont;
            IsSelected = false;
            Index = _index;
            buttonTexture = bTex;
            textureCenter = CameraManager.Instance.getWorldPosition(new Vector2(buttonTexture.Width / 2, buttonTexture.Height / 2));

            screenCenter.Y = yOffset;

            textureCenter = new Vector2(spriteFont.Texture.Width / 2, spriteFont.Texture.Height / 2);

            this.scale = scale;

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
        ///
        int width = Game1.Instance.GraphicsDevice.Viewport.Width;
        int height = Game1.Instance.GraphicsDevice.Viewport.Height;
        public void Draw(SpriteBatch spriteBatch)
        {
          //  spriteBatch.Draw(buttonTexture, screenCenter,null, Color.White,0f,textureCenter,1f,SpriteEffects.None,0.5f);
            Color color = Color.Black;
            if (IsSelected)
            {
                color = Color.Red;
                spriteBatch.DrawString(spriteFont, Name, screenCenter, color, 0, new Vector2(textureCenter.X / 7, textureCenter.Y / 2), scale + 0.25f, SpriteEffects.None, 0.5f);
            }
            else spriteBatch.DrawString(spriteFont, Name, screenCenter, color, 0, new Vector2(textureCenter.X / 7, textureCenter.Y / 2), scale, SpriteEffects.None, 0.5f);

        }
        #endregion
    }
}
