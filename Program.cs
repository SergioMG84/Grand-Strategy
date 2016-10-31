using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Civerino
{
    class Program
    {
        static void Main(string[] args)
        {
            Map.load("map");
            Empire em = new Empire();
            em.cities.Add(new City(10,10));

            Console.WriteLine(em.population);
            Console.WriteLine(em.gold);
            Console.WriteLine(em.food);
        }
    }
}
