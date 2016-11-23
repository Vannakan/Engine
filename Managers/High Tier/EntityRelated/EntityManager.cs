using Engine.Entities;
using Engine.Entities.TopDownShooter;
using Engine.Managers.Behaviour;
using Engine.Managers.CamManage;
using Engine.Managers.Render;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Managers.EntityRelated
{
    public class EntityManager : IUpdateEngineComponent
    {
        //Reference to the camera
        Camera cam = CameraManager.Instance.getCam();
        //List of entities that have been created
        private List<IEntity> eList = new List<IEntity>();
        //Singleton
        private static EntityManager instance;

        public static EntityManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new EntityManager();
                return instance;
            }
        }

        public EntityManager()
        {

        }

        public List<IEntity> getList()
        {
            return eList;
        }

        public IEntity getPlayer()
        {
            for(int i = 0; i < eList.Count; i++)
            {
                if (eList[i].GetType() == typeof(pEntity))
                    return  eList[i];
            }
            return null;
        }


       public void addEntity(IEntity e)
       {
          
           eList.Add(e);
           Console.WriteLine("Added Entity -  ID " + e.UniqueID);
       }

       
     public IEntity createEntity<T>(Vector2 Position, string Texture) where T : IEntity, new()
       {
           IEntity a = new T();
           a.Initialize(Position, Texture);
           addEntity(a);
           if(a.GetType() == typeof(cShooterEntity))
               cam.setEntity(a, "Follow");
           
           return a;
       }

     public IEntity createEntityCamDrawable<T>(Vector2 Position, string Texture) where T : IEntity, new()
     {
         IEntity a = new T();
         a.Initialize(Position, Texture);
         if (a.GetType() == typeof(pEntity))
         {
             cam.setEntity(a, "Follow");
         }
         RenderManager.Instance.addCamDrawable(a as IDrawable);
         return a;
     }

     public IEntity createEntityDrawable<T>(Vector2 Position, string Texture) where T : IEntity, new()
     {
         IEntity a = new T();
         a.Initialize(Position, Texture);
        
         RenderManager.Instance.addDrawable(a as IDrawable);
         return a;
     }

      public void clearList()
     {
         eList.Clear();
         BehaviourManager.Instance.clearList();
     }

     

        public void removeEntity(int entityID)
       {
            for(int i = 0; i < eList.Count; i++)
            {
                if(eList[i].UniqueID == entityID)
                {
                    eList.Remove(eList[i]);
                    BehaviourManager.Instance.removeMind(entityID);
                    Console.WriteLine("Removed Entity - ID " + entityID);
                    
                }
            }
       }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < eList.Count; i++)
            {
                if (eList[i].Position.X < -100 || eList[i].Position.Y > 1000)
                {
                    removeEntity(eList[i].UniqueID);
                }
            }
        }
    }
}
