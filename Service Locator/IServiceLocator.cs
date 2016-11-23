using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Service_Locator
{
    public interface IServiceLocator
    {
        T GetService<T>();
    }
}
