using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Managers.ASTAR
{
    //Represents one node in the search space
   public class SearchNode
    {
        public Point Position { get; set; }


        /// <summary>
        /// A reference to the node that transfered this node to
        /// the open list. This will be used to trace our path back
        /// from the goal node to the start node.
        /// </summary>
        public SearchNode Parent;

        /// <summary>
        /// Provides an easy way to check if this node
        /// is in the open list.
        /// </summary>
        public bool InOpenList;
        /// <summary>
        /// Provides an easy way to check if this node
        /// is in the closed list.
        /// </summary>
        public bool InClosedList;

        /// <summary>
        /// The approximate distance from the start node to the
        /// goal node if the path goes through this node. (F)
        /// </summary>
        public float DistanceToGoal;
        /// <summary>
        /// Distance traveled from the spawn point. (G)
        /// </summary>
        public float DistanceTraveled;

        //G value is the distance required to travel to get from the starting node, to this node
        public float G;

        //Each node will also have an associated F value.
        //This is a rough estimate of how far we would have 
        //to travel to get from the starting node to the end node 
        //if the path crosses this node. To work out an F value we can
        //do the following : F = G + H – it is basically how far we will
        //have already had to travel to get to this node add a rough estimate of how much further we need to travel.

        public float F;

        //If true this tile can be walked on
        public bool Walkable;

       //Contains references to the for nodes surrounding
        //this tile (up,down,left,right)

        public SearchNode[] Neighbors;

    }
}
