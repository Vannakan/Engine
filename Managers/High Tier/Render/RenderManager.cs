using ADS.GUI;
using ADS.Utilities;
using ADS.Utility;
using Engine.Managers.CamManage;
using Engine.Managers.EntityRelated;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Managers.Render
{
    public class RenderManager :  IUpdateEngineComponent
    {
        private Queue<string> LinesToBeDrawn = new Queue<string>();
        private Queue<GameText> TextToBeDrawn = new Queue<GameText>();

        private List<IEntity> entities = new List<IEntity>();
       //Reference to the kernels spritebatch in which all entities will be drawn
        public SpriteBatch spriteBatch { get; set; }

        //List containing items/entities that arent drawn within the cameras perams
        private List<IDrawable> Drawables = new List<IDrawable>();

        public List<IDrawable> getD { get { return Drawables; } }
        public List<IDrawable> getD1 { get { return CamDrawables; } }

        //List containing items/entities which will be drawn with cam perams
        private List<IDrawable> CamDrawables = new List<IDrawable>();

        private List<IEntity> CamDrawEntities = new List<IEntity>();

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

        public void getCamEntityList()
        {
            CamDrawEntities = EntityManager.Instance.getCamList();
        }

        //For items which dont wish to be drawn in regards to the cameras matrix translations (such as GUI)
        public void addDrawable(IDrawable d)
        {
            Drawables.Add(d);
            Console.WriteLine("Added to Drawable List");
        }

        //For Scenery/Entities which wish to be drawn in regards to the cameras matrix translations
        public void addCamDrawable(IDrawable d)
        {
            CamDrawables.Add(d);
            Console.WriteLine("Added to CamDrawable List");

        }

        //For Entities which wish to be drawn in regards to the cameras matrix translations
        public void addCamDrawEntity(IDrawable d)
        {
            CamDrawEntities.Add(d as IEntity);
            Console.WriteLine("Added to CamDrawEntities List");

        }



        //Change method name
        //Draws everything within the camera
        public void DrawCameraRelatedArtefacts()
        {
            spriteBatch.Begin(SpriteSortMode.Deferred,
                        BlendState.AlphaBlend,
                        null,
                        null,
                        null,
                        null,
                        CameraManager.Instance.getCam().get_transformation(Game1.Instance.GraphicsDevice));
            DrawComponents();
            DrawCamDrawables();
            DrawCamDrawEntities();


            spriteBatch.End();
        }

       
        public void clearTempEntity()
        {
            CamDrawEntities.Clear();
        }

        //Change method name
        //Draws everything the camera doesnt need to know about
  public void DrawNonCameraRelatedArtefacts()
  {
      spriteBatch.Begin();
      DrawDrawables();
            DrawEntities();

            spriteBatch.End();

  }

        public void addString(GameText gameText)
        {
            TextToBeDrawn.Enqueue(gameText);
        }

     

        public void Update(GameTime gameTime)
  {
      getEntityList();
            getCamEntityList();
  }

        public void Draw()
        {
            DrawCameraRelatedArtefacts();
            DrawNonCameraRelatedArtefacts();
            GuiManager.Instance.DrawGUI();

        }

        public void Draw(Texture2D texture, Rectangle rect, Color col)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null);
            spriteBatch.Draw(texture, rect, col);
            spriteBatch.End();
        }

        /// <summary>
        /// Draws all entities that are currently waiting to be drawn
        /// </summary>
        /// <param name="spriteBatch"></param>

        public void DrawEntities()
        {
            foreach (IEntity i in entities)
            {
                if (i.isVisible)
                {
                    i.Draw(spriteBatch);
                }
            }
        }

        /// <summary>
        /// Draws any components that require a draw
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawComponents()
        {
            ScreenManager.Instance.Draw(spriteBatch);

        }

        /// <summary>
        /// Draws any objects that don't wish to be scales/manipulated via the camera
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void AddToDrawAble(IDrawable d)
        {
         
        }

        public void DrawDrawables()
        {
            for(int i = 0; i < Drawables.Count; i++)
            {
                Drawables[i].Draw(spriteBatch);
            }

            for(int i = 0; i < TextToBeDrawn.Count; i++)
            {
                GameText a = TextToBeDrawn.Dequeue();
                a.Draw(spriteBatch);
            }
        }

        public void DrawCamDrawables()
        {
            for (int i = 0; i < CamDrawables.Count; i++)
            {
                CamDrawables[i].Draw(spriteBatch);
            }
        }

        public void DrawCamDrawEntities()
        {
            for (int i = 0; i < CamDrawEntities.Count; i++)
            {
                CamDrawEntities[i].Draw(spriteBatch);
            }
        }





    }
}


