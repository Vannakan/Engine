using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Medication.Modifiers
{
    public enum ModifierType { DMG ,RSPEED,MSPEED,HP}
    public abstract class Modifier
    {

        //Holds all of the values that the modifier will manipulate
        private ModifierType damage = ModifierType.DMG;
        ModifierType f;
        Modifierr strength = new Modifierr(ModifierType.DMG);
        
        public Modifier()
        {
            //strength.
        }
      
        public virtual void Modify(ModifierType m, int value)
        {
            
                switch (m)
            {
                case ModifierType.DMG:
                    
                    break;
                case ModifierType.HP:
                    break;
                case ModifierType.MSPEED:
                    break;
                case ModifierType.RSPEED:
                    break;
            }
        }
        
        
    }
}
