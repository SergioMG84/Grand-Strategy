using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Civerino
{
    public class City
    {
        public int city_food, city_gold; //food and gold generation of the city itself
        public Point pos;                //position in the grid
        public int food
        {
            get
            {
                int pr = 0;
                foreach (Point l in land)
                    pr += Map.grid[l.X, l.Y].food;
                return pr + city_food;
            }
        }               //total food of the city (city+surrounding land)
        public int gold
        {
            get
            {
                int gl = 0;
                foreach (Point l in land)
                    gl += Map.grid[l.X, l.Y].gold;
                return gl + city_gold;
            }
        }               //total gold of the city
        public int population;           //population
        public List<Point> land;         //list of controlled land (position in grid)

        public City(int x, int y)       //create land list, set position, set starting values and annex surrounding land
        {
            land = new List<Point>();
            pos = new Point(x, y);
            city_food = 1; city_gold = 1; population = 10;
            Annex(2);

        }

        public void Annex(int r) //annex surrounding, non-occupied, not out-of-bounds land in a r-radius star shape
        {
            for (int i = -r; i <= r; i++)
                for (int j = -(int)(r - Math.Abs(i)); j <= (int)(r - Math.Abs(i)); j++)
                    if(new Rectangle(0,0, Map.grid.GetLength(0), Map.grid.GetLength(1)).Contains(new Point(pos.X +i, pos.Y+j)))
                        if (!Map.grid[pos.X + i, pos.Y + j].occupied)
                        {
                            land.Add(new Point(pos.X + i, pos.Y + j));
                            Map.grid[pos.X + i, pos.Y + j].occupied = true;
                        }
        }
    }
}
