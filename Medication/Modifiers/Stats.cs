using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Medication.Modifiers
{
    public class Stats : IStats
    {

        int level = 1;
        public int LEVEL { get { return level; } set { level = value;    } }
        //EXP & Property
        int exp;
        public int EXP { get { return exp; } set { exp = value; } }

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
            exp = 0;
        }

        public Stats(int d, int m, int a, int hp, int luck)
        {
            DMG = d;
            mSPD = m;
            atkSPD = a;
            this.hp = hp;
            this.luck = luck;
            exp = 0;
            Console.WriteLine("Stats created");
        }

        public void IncreaseStat(string Stat, int value)
        {
            switch(Stat)
            {
                case "HP":
                    hp += value;
                    break;
                case "LUCK":
                    luck += value;
                    break;
                case "aPSD":
                    atkSPD += value;
                    break;
                case "mSPD":
                    mspd += value;
                    break;
                case "EXP":
                    exp += value;
                    if (exp >= 200 * level)
                    {
                        level += 1;
                        exp = 0;
                    }
                    break;
            }
        }

        public void DecreaseStat(string Stat, int value)
        {
            switch (Stat)
            {
                case "HP":
                    hp -= value;
                    break;
                case "LUCK":
                    luck -= value;
                    break;
                case "aPSD":
                    atkSPD -= value;
                    break;
                case "mSPD":
                    mspd -= value;
                    break;
                case "EXP":
                    exp -= value;
                  
                    
                    break;
            }
        }

      
    }
}
