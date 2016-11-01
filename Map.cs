using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;

namespace Civerino
{
    public static class Map
    {
        public static Terrain[,] grid;
        public static List<string> line;

        public static void load(string path) 
        {
            line = File.ReadAllLines(path + ".txt").ToList<string>();
            grid = new Terrain[line[0].Length, line.Count];
            for (int j = 0; j < line.Count; j++)
                for (int i = 0; i < line[0].Length; i++)
                    switch (line[j][i])
                    {
                        case('p'):
                            grid[i, j] = new Terrain(terraintype.plain);
                            break;
                        case ('f'):
                            grid[i, j] = new Terrain(terraintype.forest);
                            break;
                        case ('c'):
                            grid[i, j] = new Terrain(terraintype.crops);
                            break;
                        case ('m'):
                            grid[i, j] = new Terrain(terraintype.mountain);
                            break;
                        case ('s'):
                            grid[i, j] = new Terrain(terraintype.sea);
                            break;
                        case ('r'):
                            grid[i, j] = new Terrain(terraintype.river);
                            break;
                    }
        }


        public static void displayTerrain(List<Empire> empires)
        {
            Console.WriteLine("Terrain map:\n\n");
            char[,] displaylist = new char[line[0].Length, line.Count];
            for(int i=0; i<line[0].Length; i++)
                for(int j=0; j<line.Count;j++)
                    displaylist[i,j] = line[j][i];
            foreach (Empire em in empires)
                foreach (City c in em.cities)
                {
                    foreach (Point t in c.land)
                        displaylist[t.X, t.Y] = em.cities.IndexOf(c).ToString()[0];
                    displaylist[c.pos.X, c.pos.Y] = 'C';
                }
            for (int i = 0; i <= line[0].Length; i++)
                Console.Write("--");
            Console.Write("\n");
            for(int j=0; j<line.Count;j++)
            {
                for(int i=0; i<line[0].Length; i++)
                    Console.Write("|" + displaylist[i,j].ToString());
                Console.Write("|\n");
                for (int i = 0; i <= line[0].Length; i++)
                    Console.Write("--");
                Console.Write("\n");
            }
            Console.Write("\n\n");
        }
    }
}
