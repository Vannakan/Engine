using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ADS.Managers.EntityRelated;
using ADS.Managers.Collision;

namespace ADS
{
   public abstract class BaseScreen : IScreen
    {

        #region Fields/Properties/Enums

       //Variable to hold the Game1 content manager
       protected ContentManager content;
       public bool HasLoaded { get; set; }
       public bool HasEnded { get; set; }
       public bool Active { get; set; }
      
        #endregion

        #region Constructor & Initialize
       public BaseScreen()
       {
          
           //Set the current content variable to the Screen Managers current content instance
          // content = ScreenManager.Instance.content;
       }

       /// <summary>
       /// Initialization logic here (For child screens)
       /// Set the two properties to false as the second the screen
       /// has been added, it wont have ended(so no transition to next level)
       /// and it hasn't loaded until the bool returns true to tell the screenmanager to stop loading
       /// </summary>
       public virtual void Initialize()
       {
           
           HasLoaded = false;
           HasEnded = false;
           Active = true;
       }

       public virtual void UnloadContent()
       {

       }


       #endregion

        #region Update & Draw

       /// <summary>
       /// Update the screen
       /// </summary>
       /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {

        }
       /// <summary>
       /// Draw the screen
       /// </summary>
       /// <param name="spriteBatch"></param>

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        #endregion

        #region Unloading

       //When the screen is to be unloaded, clear any entities from the screen, remove the entities from the detection manager as well
       public void Unload()
        {
            EntityManager.Instance.clearList();
            DetectionManger.Instance.clearManager();
        }

        #endregion
    }

}
