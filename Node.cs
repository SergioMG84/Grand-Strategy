using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Civerino
{
    public class Node
    {
        private Point pos;
        private Node parent;
        private double G, H;
        private double F
        { get { return G + H; } }

        public Node(Point pos, Point end)
        {
            this.pos = pos;
            this.parent = this;
            G = 0;
            H = Math.Sqrt((pos.X - end.X) * (pos.X - end.X) + (pos.Y - end.Y) * (pos.Y - end.Y));
        }
        public Node(Point pos, Node parent, Point end)
        {
            this.pos = pos; this.parent = parent;
            G = 1 + parent.G;
            H = Math.Sqrt((pos.X - end.X) * (pos.X - end.X) + (pos.Y - end.Y) * (pos.Y - end.Y));
        }
        public static Queue<Point> path(Point start, Point end, Dictionary<terraintype, bool> movement)
        {
            Queue<Point> pointpath = new Queue<Point>();
            //A* path algorithm
            List<Node> closed = new List<Node>();             //already evaluated
            List<Node> open = new List<Node>() {new Node(start, end)};         //to evaluate
            bool finished = false;
            Node current = open[0];
            while (!finished)
            {
                double min = double.MaxValue;
                foreach (Node n in open) //select node with less distance
                {
                    if (n.pos == end)
                    {
                        finished = true;
                        current = n;
                        break;
                    }
                    if (n.F < min)
                    {
                        min = n.F;
                        current = n;
                    }
                }

                if (finished)
                {
                    break;
                }
                else
                {
                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                        {
                            Point next = new Point(current.pos.X + i, current.pos.Y + j);
                            bool repeated = false;
                            foreach (Node n in closed)
                                if (n.pos == next)
                                {
                                    if(n.F > (n.H + current.G + 1))
                                        n.parent = current;
                                    repeated = true;
                                }
                            if ((i != 0 || j != 0)  && !repeated)
                            {
                                open.Add(new Node(next, current, end));
                            }
                        }
                    closed.Add(current);
                    open.Remove(current);
                }   
            }
            while(current.pos != start)
            {
                pointpath.Enqueue(current.pos);
                current= current.parent;
            }
            pointpath.Reverse();
            return pointpath;
        }
    }
}
