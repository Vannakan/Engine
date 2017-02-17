using Engine;
using Engine.Entities;
using Engine.Managers.EntityRelated;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Medication.Spawner
{
    public class Spawner
    {
        //Radius for spawning
        Circle radius;
        //Position of the spawner
        Vector2 position;
        //Entity Group for spawner
        MedGroup spawns;

        public Spawner(int Radius, Vector2 Position)
        {
            position = Position;
            radius = new Circle(Radius, Position);
        }

       
        /// <summary>
        /// Assigns a group of types to be spawned by the spawner
        /// </summary>
        /// <param name="m"></param>
        public void assignGroup(MedGroup m)
        {
            spawns = m;
        }


        //Send a wave of a predefined amount of Entities in a random radius
        public void sendWave(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                foreach (Entity e in spawns.getList)
                {
                  
                    switch (e.ToString().Split('.').Last())
                    {
                        case "steerEntity":
                            {
                                EntityManager.Instance.createEntityCamDrawable<steerEntity>(radius.randomPos());

                            }

                            break;

                    }
                }

        }

        }

      
    }
}
