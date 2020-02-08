using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortPathAStar
{
    public class Node
    {
            private Node parentNode;
            public Point Location { get; set; }
            public bool IsWalkable { get; set; }
            public double G { get; set; }
            public double H { get; set; }
            public NodeState State { get; set; }
            public double F
            {
                get { return this.G + this.H; }
            }
            public Node ParentNode
            {
                get { return this.parentNode; }
                set
                {                    
                    this.parentNode = value;           
                }
            }
            public Node(int x, int y, bool isWalkable,Point startLocation, Point endLocation)
            {
                this.Location = new Point(x, y);
                this.State = NodeState.Untested;
                this.IsWalkable = isWalkable;
                this.G = LenghtBetweenTwoPoints(this.Location, startLocation);
                this.H = LenghtBetweenTwoPoints(this.Location, endLocation);
              
            }      

            public static double LenghtBetweenTwoPoints(Point location, Point otherLocation)
            {
                double deltaX = Math.Abs(otherLocation.X - location.X);
                double deltaY = Math.Abs(otherLocation.Y - location.Y);
                return (deltaX + deltaY);      
            }        
    }
}
