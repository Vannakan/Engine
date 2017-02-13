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
        Circle radius;
        Vector2 position;
        List<Entity> spawnTypes = new List<Entity>();
      

        public Spawner(int Radius, Vector2 Position)
        {
            position = Position;
            radius = new Circle(Radius, Position);
        }

        public void addType<T>() where T : Entity, new()
        {
            Entity a = new T();
            spawnTypes.Add(a);
        }

        public void Update()
        {

        }

        public void sendWave(int amount)
        {
            Console.WriteLine(spawnTypes[0].GetType().ToString());
            for (int i = 0; i < amount; i++)
            {
                foreach (Entity e in spawnTypes)
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
