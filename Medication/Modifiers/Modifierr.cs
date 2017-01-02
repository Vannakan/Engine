using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Medication.Modifiers
{
    public class Modifierr
    {
        ModifierType type;
        int value = 0;
        public Modifierr(ModifierType mT)
        {
            type = mT;
        }

        public void changeValue(int v)
        {
            value = v;
        }

        public int getValue()
        {
            return value;
        }

        public ModifierType getType()
        {
            return type;
        }
    }
}
