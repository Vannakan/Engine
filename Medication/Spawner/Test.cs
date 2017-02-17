using Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Medication.Spawner
{
    public class Test : MedGroup
    {

        public Test()
        {
            addType<steerEntity>();
        }
    }
}
