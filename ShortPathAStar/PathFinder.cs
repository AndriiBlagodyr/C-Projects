using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortPathAStar
{
    public class PathFinder
    {
        public SearchParameters searchParameters;
        public int height;
        public int width;
        public Node[,] nodes;
        public Node startNode;
        public Node endNode;
        private static int state;

        public PathFinder(SearchParameters searchParameters)
        {
            this.searchParameters = searchParameters;
            this.height = searchParameters.Map.GetLength(0);
            this.width = searchParameters.Map.GetLength(1);
            this.nodes = new Node[this.height, this.width];
            for (int x = 0; x < this.height; x++)
            {
                for (int y = 0; y < this.width; y++)
                {
                    this.nodes[x, y] = new Node(x, y, true, this.searchParameters.StartLocation, this.searchParameters.EndLocation);
                }
            }

            this.startNode = this.nodes[searchParameters.StartLocation.X, searchParameters.StartLocation.Y];
            this.startNode.State = NodeState.Open;
            this.endNode = this.nodes[searchParameters.EndLocation.X, searchParameters.EndLocation.Y];

            Random rand = new Random();
            for (int i = 0; i < searchParameters.BlocksQuantity; i++)
            {
                int x, y = 0;
                x = rand.Next(0, this.width);
                y = rand.Next(0, this.width);
                if ((x == y & y == 0) || (x == (this.width - 1) & y == (this.height - 1) || nodes[x, y].IsWalkable == false))
                {
                    --i;
                    continue;
                }
                nodes[x, y].IsWalkable = false;
            }
        }

        public List<Point> FindPath()
        {
            List<Point> path = new List<Point>();
            bool success = Search(startNode);
            if (success)
            {
                Node node = this.endNode;
                while (node.ParentNode != null)
                {
                    path.Add(node.Location);
                    node = node.ParentNode;
                }
                path.Reverse();
            }
            return path;
        }

        private bool Search(Node currentNode)
        {
            currentNode.State = NodeState.Closed;
            List<Node> nextNodes = GetNeighbourWalkableNodes(currentNode);

            nextNodes.Sort((node1, node2) => node1.F.CompareTo(node2.F));
            foreach (var nextNode in nextNodes)
            {
                if (nextNode.Location == this.endNode.Location)
                {
                    return true;
                }
                else
                {
                    if (Search(nextNode))
                        return true;
                }
            }
            return false;
        }

        private List<Node> GetNeighbourWalkableNodes(Node fromNode)
        {
            List<Node> walkableNodes = new List<Node>();
            IEnumerable<Point> nextLocations = GetMoveLocations(fromNode.Location);

            foreach (var location in nextLocations)
            {
                int x = location.X;
                int y = location.Y;

                if (x < 0 || x >= this.width || y < 0 || y >= this.height)
                    continue;

                Node node = this.nodes[x, y];

                if (!node.IsWalkable)
                    continue;

                if (node.State == NodeState.Closed)
                    continue;
  
                else
                {
                    node.ParentNode = fromNode;
                    node.State = NodeState.Open;
                    walkableNodes.Add(node);
                }
            }
            return walkableNodes;
        }

        private static IEnumerable<Point> GetMoveLocations(Point fromLocation)
        {            
            if (state % 2 == 0)
            {
                ++state;
                return new Point[]
            {           
                new Point(fromLocation.X+1, fromLocation.Y  ),
                new Point(fromLocation.X,   fromLocation.Y+1),            
                new Point(fromLocation.X-1, fromLocation.Y  ),  
                new Point(fromLocation.X,   fromLocation.Y-1)
            };

            }
            else
            {
                ++state;
                return new Point[]
            {    
                new Point(fromLocation.X,   fromLocation.Y+1),
                new Point(fromLocation.X+1, fromLocation.Y  ),                          
                new Point(fromLocation.X-1, fromLocation.Y  ),  
                new Point(fromLocation.X,   fromLocation.Y-1)
            };
            }

        }
    }
}


