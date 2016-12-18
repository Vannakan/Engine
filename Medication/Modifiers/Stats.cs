using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Medication.Modifiers
{
    public class Stats : IStats
    {
        //Damage & Property
        int dmg;
        public int DMG { get { return dmg;} set { dmg = value; } }

        //MoveSpeed & Property
        int mspd;
        public int mSPD { get { return mspd; } set { mSPD = value; } }

        //Attack SPEED & Property
        int atkSPD;
        public int aSPD { get { return atkSPD; } set { atkSPD = value; } }
        //HP & Property
        int hp;
        public int HP { get { return hp; } set { hp = value; } }

        public Stats()
        {
            DMG = 0;
            mSPD = 0;
            atkSPD = 0;
            hp = 1;
        }

        public Stats(int d, int m, int a, int hp)
        {
            DMG = d;
            mSPD = m;
            atkSPD = a;
            this.hp = hp;
        }

      
    }
}
