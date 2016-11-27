using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Astar_Jack_
{
    public abstract class Node : INode
    {
        protected bool Collision;

        public bool hasCollision
        {
            get
            {
                return Collision;
            }

            set
            {
                Collision = value;
            }
        }

        protected int ID;

        public int getID { get { return ID; } set { ID = value; } }


        public Node(bool col, int id)
        {

            Collision = col;
            ID = id;
        }


    }
}
