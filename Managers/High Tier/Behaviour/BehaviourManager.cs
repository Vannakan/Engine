
using ADS.Entities;
using Engine.Entities;
using Engine.Managers.Collision;
using Engine.Managers.EntityRelated;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Managers.Behaviour
{
    public class BehaviourManager : IUpdateEngineComponent
    {
        
       
        //List for all of the AI to update and check
        private List<IMind> minds = new List<IMind>();
        //singleton
        private static BehaviourManager instance;

        public static BehaviourManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BehaviourManager();
                    

                }
                return instance;
            }
        }

       /// <summary>
       /// Creates and returns an IMind interface
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="ie"></param>
       /// <returns></returns>
        public IMind Create<T>(IEntity ie) where T : IMind, new()
        {
            IMind e = new T();
            e.Link(ie);
            DetectionManger.Instance.addCollidable(e.getCollidable());
            Console.WriteLine("New " + e.GetType() + " added ");
            minds.Add(e);
            return e;

        }

        public IMind CreateProjectile<T>(IEntity ie,Direction d) where T : IMind, new()
        {
            IMind e = new T();
            e.Link(ie);
            IProjectile a = e as IProjectile;
            a.setDirection(d);
            Console.WriteLine("NEW" + e.GetType() + " ADDED");
            minds.Add(e);
            return e;
        }

      

        /// <summary>
        /// Clears the current Mind List
        /// </summary>

        public void clearList()
        {
            for (int i = 0; i < minds.Count; i++)
            {

                removeMind(minds[i].UniqueID);
            }
            minds.Clear();
        }

        /// <summary>
        /// Removes a specific mind from the list via its ID. 
        /// </summary>
        /// <param name="id"></param>
        public void removeMind(int id)
        {
            for (int i = 0; i < minds.Count; i++)
            {
                //If the mind is out of the boundaries set
                //remove it
                //Temporary Behaviour response.
                if (minds[i].UniqueID == id)
                {
                    Console.WriteLine("Removed Mind " + minds[i].UniqueID);
                    minds[i].Unload();
                    minds.Remove(minds[i]);

                }
            }
        }


        /// <summary>
        /// Iterate through the mind list and call the minds update
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime) 
        {           
               for (int i = 0; i < minds.Count; i++)
            {

                    if(minds[i].Active)
                    minds[i].Update(gameTime);
            }
        }
    }
}
