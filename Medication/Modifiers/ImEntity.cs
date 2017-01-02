using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Medication.Modifiers
{
    //Interface for medication entities and their unique traits
    interface ImEntity
    {
        Stats stats { get; set; }
    }
}
