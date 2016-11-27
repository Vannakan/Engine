using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Astar_Jack_
{
    public interface INode
    {
        bool hasCollision { get; set; }

        int getID { get; set; }
    }
}
