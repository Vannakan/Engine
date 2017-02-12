using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Engine.Managers.Collision;

namespace Engine
{
   public class Tiles
   {

        #region Variables
       //Variable to hold the tiles texture
        public Texture2D texture;
        public float alpha = 1;
        public Vector2 POS;

       //Variable to hold the tiles rectangle
        protected Rectangle rectangle;


       #endregion

        #region Properties
        //Property to supply classes with the tiles bounds (For collision)
        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }
     
        #endregion

        #region Draw

        public  void Draw(SpriteBatch spriteBatch)
        {
            if(texture != null)
            spriteBatch.Draw(texture, rectangle, Color.White * alpha);
        }
        #endregion
   }
}
