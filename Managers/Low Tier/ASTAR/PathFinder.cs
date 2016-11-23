using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Managers.ASTAR
{
    class PathFinder
    {
        //A List of search nodes that are available to search
        private List<SearchNode> openList = new List<SearchNode>();

        //A list of nodes that have already been searched
        private List<SearchNode> closedList = new List<SearchNode>();
        /// <summary>
        /// Returns an estimate of the distance between two points
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        private float Heuristic(Point point1, Point point2)
        {
            return Math.Abs(point1.X - point2.X) +
                   Math.Abs(point1.Y - point2.Y);
        }


        //Stores an arrayt of the walkable searchnodes
        private SearchNode[,] searchNodes;


        //Width of the map

        private int levelWidth;

        //Height of the map
        private int levelHeight;

        TileMap Map;

        public PathFinder(TileMap map)
        {

            levelHeight = map.Height;
            levelWidth = map.Width;
            Map = map;
            InitializeSearchNodes(map);
        }


        //splits out level into a grid of nodes

        private void InitializeSearchNodes(TileMap map)
        {
            searchNodes = new SearchNode[levelWidth,levelHeight];

            //For each of the tiles in the map,
            //create a note for it

            for (int x = 0; x < levelWidth; x++)
            {
                for (int y = 0; y < levelHeight; y++)
                {
                    //Create a search node to represent this tile.
                    SearchNode node = new SearchNode();

                    node.Position = new Point(x, y);

                    //Make it so entity can only walk on 1 type of tile
                    node.Walkable = map.Map[x, y] == 0;

                    //Store nodes that can be walked on
                    if (node.Walkable == true)
                    {
                        node.Neighbors = new SearchNode[4];

                        searchNodes[x, y] = node;
                    }
                }
            }

            //Search for each of the search nodes
            //connect it to the neighbours
            for (int x = 0; x < levelWidth; x++)
            {
                for (int y = 0; y < levelHeight; y++)
                {
                    SearchNode node = searchNodes[x, y];

                    //Look at nodes you can walk on
                    if (node == null || node.Walkable == false)
                    {
                        continue;
                    }

                    //Array of all possible neighbours
                    //this node could have

                    Point[] neighbours = new Point[]
                    {
                        new Point(x,y-1), //Above current

                        new Point(x,y+1), //Under current

                        new Point(x-1,y), //Left of current

                        new Point(x+1,y),//Right of current
                    };

                    //Loop through possible neighbors

                    for(int i = 0; i<neighbours.Length; i++)
                    {
                        Point position = neighbours[i];

                        //Make sure neighbour is part of level

                        if(position.X < 0 || position.X > levelWidth -1 ||
                            position.Y < 0 || position.Y > levelHeight-1)
                        {
                            continue;
                        }

                        SearchNode neighbor = searchNodes[position.X, position.Y];

                        //Only keep reference of the nodes that can be walked on

                        if(neighbor == null || neighbor.Walkable == false)
                        {
                            continue;
                        }


                        //store reference to the neighbor
                        node.Neighbors[i] = neighbor;
                    }

                }
            }
        }
     
        //Resets the state of the search nodes

        private void Reset()
        {
            openList.Clear();
            closedList.Clear();

            for (int x = 0; x < levelWidth; x++)
            {
                for (int y = 0; y < levelHeight; y++)
                {
                    SearchNode node = searchNodes[x, y];
                    if (node == null)
                    {
                        continue;
                    }

                    node.InOpenList = false;
                    node.InClosedList = false;

                    node.DistanceTraveled = float.MaxValue;
                    node.DistanceToGoal = float.MaxValue;

                }
            }

        }



        /// <summary>
        /// This method creates a float with a massive value
        /// it then iterates through the open list of nodes
        /// and if the DistanceToGoal is smaller than the float
        /// it adds it as the next best distance. 
        /// </summary>
        /// <returns></returns>
        private SearchNode BestNode()
        {
            SearchNode current = openList[0];

           
            float smallestDistanceToGoal = float.MaxValue;

            // Find the closest node to the goal.
    for (int i = 0; i < openList.Count; i++)
    {
        if (openList[i].DistanceToGoal < smallestDistanceToGoal)
        {
            current = openList[i];
            smallestDistanceToGoal = current.DistanceToGoal;
        }
    }
    return current;
        }


        //Use the parent field of the search node to trace a path from the end node
        //to the start noad

        private List<Vector2>FindFinalPath (SearchNode startNode, SearchNode endNode)
        {
            closedList.Add(endNode);

            SearchNode parent = endNode.Parent;

            //Trace back through the nodes using the parent fields 
            //to find the best path

            while(parent != startNode)
            {
                closedList.Add(parent);
                parent = parent.Parent;
            }

            List<Vector2> finalPath = new List<Vector2>();

            //Reverse the patha nd transform into world space
            for(int i = closedList.Count - 1; i >= 0; i--)
            {
                finalPath.Add(new Vector2(closedList[i].Position.X * 32,
                                        closedList[i].Position.Y * 32));
            }

            return finalPath;
        }

        //Finds the optimal path from one point to another

        public List<Vector2> FindPath(Point startPoint, Point endPoint)
        {
            //Only try to find a path if the start and end points are different

            if(startPoint == endPoint)
            {
                return new List<Vector2>();
            }

            //Clear the Open and Closed lists.
            //Reset each nodes F and G values incase they are still set from the
            //last time we tried to find a path

            Reset();

            //Store reference to the start and end nodes for convenience
            SearchNode startNode = new SearchNode();
            startNode.Position = new Point(startPoint.X, startPoint.Y);

            SearchNode endNode = new SearchNode();
            endNode.Position = new Point(endPoint.X, endPoint.Y);

           // SearchNode endNode = searchNodes[endPoint.X, endPoint.Y];

            //Set the start nodes G value to 0 and its F value to the
            //estimated distance between the start node and the goal node

            startNode.InOpenList = true;
            startNode.DistanceToGoal = Heuristic(startPoint, endPoint);
            startNode.DistanceTraveled = 0;

            openList.Add(startNode);

            //While there are still nodes to look at in the open list

            while(openList.Count > 0)
            {
                //Loop through open list and find node with smallest F value

                SearchNode currentNode = BestNode();

                //If the open list empty or no node found
                //there is no path so break
                if(currentNode == null)
                {
                    break;
                }

                //if the active node is the goal ndoe, find and return path

                if(currentNode == endNode)
                {
                    return FindFinalPath(startNode, endNode);
                }

               for(int i = 0; i <currentNode.Neighbors.Length; i++)
               {
                   SearchNode neighbour = currentNode.Neighbors[i];

                   //Make sure neighbour can be walked across

                   if(neighbour == null || neighbour.Walkable == false)
                   {
                       continue;
                   }

                   //Calculate new G value for the neighbouring node
                   float distanceTravelled = currentNode.DistanceTraveled + 1;

                   //Estimate of the distance from this node to the end node
                   float h = Heuristic(neighbour.Position, endPoint);

                   //If the neighoburing node is not in either open or closed

                   if(!neighbour.InOpenList && !neighbour.InClosedList)
                   {
                       //Set the neighbouring nodes g value tot he value we just calced
                       neighbour.DistanceTraveled = distanceTravelled;
                       //set the neighbouring nodes F value to the new G value
                       //and estimate distance between beighbouring node and goal node
                       neighbour.DistanceToGoal = distanceTravelled + h;
                       //Set the neighbouring nodes parent property to point at active node
                       neighbour.Parent = currentNode;
                       //add the neighbouring node to open list
                       neighbour.InOpenList = true;
                       openList.Add(neighbour);
                   }

                   //Else if neighbouring node is in either open or closed lists

                   else if(neighbour.InOpenList || neighbour.InClosedList)
                   {
                       //If calced g value is less than neighbouring nodes g value, do 
                       //same steps as if the nodes are not in open or closed
                       //except for dont add them to the open list again


                       if(neighbour.DistanceTraveled > distanceTravelled)
                       {
                           neighbour.DistanceTraveled = distanceTravelled;
                           neighbour.DistanceToGoal = distanceTravelled + h;
                           neighbour.Parent = currentNode;
                       }
                   }
               }
                //Remove the active node from the open list and add it to the closed list
               openList.Remove(currentNode);
               currentNode.InClosedList = true;
            }
            //No path found
            return new List<Vector2>();
        }




        }
}
