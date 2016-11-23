using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Service_Locator
{
    class ServiceLocator
    {
        //Hashmap that contains references managers
        private IDictionary<object, object> services;

        internal ServiceLocator()
        {
        }
    }
}
