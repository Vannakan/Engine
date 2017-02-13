using ADS.Entities;
using Engine.Entities;
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

        private List<IEntity> cdList = new List<IEntity>();


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

        public List<IEntity> getCamList()
        {
            return cdList;
        }

        public IEntity getPlayer()
        {
            for(int i = 0; i < cdList.Count; i++)
            {
                if (cdList[i].GetType() == typeof(pEntity))
                    return  cdList[i];
            }
            return null;
        }


       public void addEntity(IEntity e)
       {
          
           eList.Add(e);
           Console.WriteLine("Added Entity -  ID " + e.UniqueID);
       }

        public void addCamEntity(IEntity e)
        {
            cdList.Add(e);
            Console.WriteLine("Added CamDrawEntity -  ID " + e.UniqueID );

        }


        public IEntity createEntity<T>(Vector2 Position) where T : IEntity, new()
       {
           IEntity a = new T();
           a.Initialize(Position);
           addEntity(a);       
           return a;
       }

     public IEntity createEntityCamDrawable<T>(Vector2 Position) where T : IEntity, new()
     {
         IEntity a = new T();
         a.Initialize(Position);
            addCamEntity(a);
        
         return a;
     }

      

        //public IEntity createProjectile<T>(Vector2 Position, string t, Direction d) where T : IEntity, new()
        //{
        //    IEntity a = new T();
        //    IProjectile e = a as IProjectile;
        //    e.setDirection(d);
        //    a.Initialize(Position, t);
        //    addCamEntity(a);
        //    return a;
            
        //}


//Public IEntity createProjectileCamDrawable<T>(Vector2 Position, string tex, DIRECTION direction 
   

        public IEntity createEntityDrawable<T>(Vector2 Position) where T : IEntity, new()
     {
         IEntity a = new T();
         a.Initialize(Position);
        
         RenderManager.Instance.addCamDrawEntity(a as IDrawable);
         return a;
     }

        public void tempCamClear()
        {
            RenderManager.Instance.clearTempEntity();
            BehaviourManager.Instance.clearList();

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

       

public void removeCamEntity(int entityID)
        {
            for (int i = 0; i < cdList.Count; i++)
            {
                if (cdList[i].UniqueID == entityID)
                {
                    cdList.Remove(cdList[i]);
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

            for (int i = 0; i < cdList.Count; i++)
            {
                Console.WriteLine(cdList[i].UniqueID);
            }
        }
    }
}
