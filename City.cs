using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Civerino
{
    

    public class City
    {
        public int city_food, city_gold;
        public int food
        {
            get
            {
                int pr = 0;
                foreach (Point l in land)
                    pr += Map.grid[l.X, l.Y].food;
                return pr + city_food;
            }
        }
        public int gold
        {
            get
            {
                int gl = 0;
                foreach (Point l in land)
                    gl += Map.grid[l.X, l.Y].gold;
                return gl + city_gold;
            }
        }
        public int population;
        public List<Point> land;

        public City(int x, int y)
        {
            land = new List<Point>();
            city_food = 1; city_gold = 1; population = 10;
            land.Add(new Point(x, y));
            land.Add(new Point(x+1, y));
            land.Add(new Point(x, y+1));
            land.Add(new Point(x-1, y));
            land.Add(new Point(x, y-1));
            land.Add(new Point(x + 1, y+1));
            land.Add(new Point(x-1, y + 1));
            land.Add(new Point(x - 1, y-1));
            land.Add(new Point(x+1, y - 1));
        }
    }
}
