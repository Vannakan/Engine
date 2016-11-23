using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADS
{
    class BlueRoom : BaseScreen
    {
        public override void UnloadContent() { }
       public override void Initialize()
       { }
       public override void Update(GameTime gameTime) { }
       public override void Draw(SpriteBatch spriteBatch)
       {

           spriteBatch.Draw(ResourceLoader.Instance.GetTex("enemy"), new Vector2(2, 2), Color.White);
       }

    }
}
