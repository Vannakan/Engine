using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Service_Locator
{
    public class Service2 : IService
    {

        public string getString()
        {
            return this.GetType().ToString();
        }

        public void execute()
        {
            Console.WriteLine("Executing" + this.GetType().ToString());
        }
    }
}
