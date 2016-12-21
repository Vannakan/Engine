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
        public int mSPD { get { return mspd; } set { mspd = value; } }

        //Attack SPEED & Property
        int atkSPD;
        public int aSPD { get { return atkSPD; } set { atkSPD = value; } }
        //HP & Property
        int hp;
        public int HP { get { return hp; } set { hp = value; } }

        //Luck & Property
        int luck;
        public int Luck { get { return luck; } set { luck = value; } }

        public Stats()
        {
            DMG = 0;
            mSPD = 0;
            atkSPD = 0;
            hp = 1;
            luck = 0;
        }

        public Stats(int d, int m, int a, int hp, int luck)
        {
            DMG = d;
            mSPD = m;
            atkSPD = a;
            this.hp = hp;
            this.luck = luck;
            Console.WriteLine("Stats created");
        }

      
    }
}
