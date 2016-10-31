using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Civerino
{
    public class Empire
    {
        public List<City> cities;
        public int food
        {
            get
            {
                int pr = 0;
                foreach (City c in cities)
                    pr += c.food;
                return pr;
            }
        }
        public int gold
        {
            get
            {
                int gl = 0;
                foreach (City c in cities)
                    gl += c.gold;
                return gl;
            }
        }
        public int population
        {
            get
            {
                int pop = 0;
                foreach (City c in cities)
                    pop += c.population;
                return pop;
            }

        }

        public Empire()
        { cities = new List<City>(); }

    }
}
