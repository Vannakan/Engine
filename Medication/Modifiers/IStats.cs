using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Medication.Modifiers
{
    public interface IStats
    {
        //Damage Property
        int DMG { get; set; }
       //Move Speed Property
        int mSPD { get; set; }
        //Bullet Speed Property
        int aSPD { get; set; }
        //HP Property
        int HP { get; set; }
    }
}
