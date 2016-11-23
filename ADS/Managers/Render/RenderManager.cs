using ADS.Managers.EntityRelated;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Managers.Render
{
    public class RenderManager
    {

        private List<IEntity> entities = new List<IEntity>();
       //Reference to the kernels spritebatch in which all entities will be drawn
        public SpriteBatch spriteBatch { get; set; }
        //Singleton
        private static RenderManager instance;

        public static RenderManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new RenderManager();
                return instance;
            }
        }

        public RenderManager()
        {

        }

        //An initialize method that is called every time a new
        //screen is ready to be drawn
        public void Initialize()
        {
            getEntityList();
        }

        public void getEntityList()
        {
            entities = EntityManager.Instance.getList();
        }


        public void StartDrawing()
        {
            spriteBatch.Begin();
            Draw(spriteBatch);
        }

        public void StopDrawing()
        {
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            ScreenManager.Instance.Draw(spriteBatch);

            foreach(IEntity i in entities)
            {
                if (i.isVisible)
                {
                    i.Draw(spriteBatch);
                }
            }

        }

       


    


    }
}
