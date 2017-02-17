using Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Medication.Spawner
{
    public abstract class MedGroup
    {
        protected List<Entity> spawnTypes = new List<Entity>();
        protected void addType<T>() where T : Entity, new()
        {
            Entity a = new T();
            spawnTypes.Add(a);
        }

        

        public List<Entity> getList { get { return spawnTypes; } }
    }
}
