using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Engine.Managers.EntityRelated;
using Engine.Managers.Collision;
using Engine.Managers.CamManage;

namespace Engine
{
    public enum State { Entering,Running,Exiting}
   public abstract class BaseScreen : IScreen
    {

        #region Fields/Properties/Enums

       //Variable to hold the Game1 content manager


       public bool Active { get; set; }

       public string SoundTrack { get; set; }

      
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
       public virtual void Unload()
        {
            EntityManager.Instance.clearList();
            DetectionManger.Instance.clearManager();
        }

        #endregion

        #region Misc
    

        #endregion
    }

}
