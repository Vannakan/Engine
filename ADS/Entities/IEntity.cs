using ADS.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADS
{
   public interface IEntity
    {
       //Entities Texture
       Texture2D Texture { get; set; }
       //Entities Position
       Vector2 Position { get; set; }
       //Draw method
       void Draw(SpriteBatch spriteBatch);
       //Sprites unique ID
       int UniqueID { get; }
       //void Update(GameTime gameTime);
       Rectangle Bounds { get; }
       //Does the sprite allow for collisions?
       bool isCollidable { get; set; }
       //Should the sprite be drawn?
       bool isVisible { get; set; }
       //Is the sprite controlled?
       bool controlled { get; set; }
       //Give the sprite a position and texture
       void Initialize(Vector2 Position, string Texture);
        
    }
}
