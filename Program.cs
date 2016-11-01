using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Civerino
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Empire> empires = new List<Empire>();
            Map.load("map");
            Empire em = new Empire();
            em.cities.Add(new City(10,10));
            em.cities.Add(new City(11, 12));


            Console.WriteLine(em.population);
            Console.WriteLine(em.gold);
            Console.WriteLine(em.food);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            empires.Add(em);
            Map.displayTerrain(empires);


            Unit uni = new Unit(3, 3);
            uni.direction = Node.path(uni.pos, new Point(7, 10), uni.movement);

            for (int i = 0; i < uni.direction.Count; i++)
            {

                Console.WriteLine(uni.direction.ElementAt(i).X + "  " + uni.direction.ElementAt(i).Y);
                
            }
        }
    }
}
