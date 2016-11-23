using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ADS.Managers.Collision;

namespace ADS
{
   public class Tiles 
   {

        #region Variables
       //Variable to hold the tiles texture
        protected Texture2D texture;

       //Variable to hold the tiles rectangle
        protected Rectangle rectangle;

        private static ContentManager content;

       #endregion

        #region Properties
        //Property to supply classes with the tiles bounds (For collision)
        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }
       //Property to hold the content manager (all tiles can access this, currently not loaded through resource loader

        public static ContentManager Content 
        {
            protected get { return content; }
            set { content = value; }
        }
        #endregion

        #region Draw

        public  void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
        #endregion
   }
}
