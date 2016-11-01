using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Civerino
{
    public class Unit
    {
        public Point pos;
        public Queue<Point> direction;
        public Dictionary<terraintype, bool> movement;

        public Unit(int x, int y)
        {
            pos = new Point(x, y);
            direction = new Queue<Point>();
            movement = new Dictionary<terraintype, bool>();
            movement.Add(terraintype.crops, true);
            movement.Add(terraintype.forest, true);
            movement.Add(terraintype.mountain, false);
            movement.Add(terraintype.plain, true);
            movement.Add(terraintype.river, false);
            movement.Add(terraintype.sea, false);
        }

        public void Move(int x, int y)
        {

        }

        public void pathfind(int x, int y)
        {
            
            while(true)
            {

            }
        }
    }
}
