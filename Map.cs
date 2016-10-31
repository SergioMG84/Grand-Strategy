using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Civerino
{
    public static class Map
    {
        public static Terrain[,] grid;

        public static void load(string path) 
        {
            List<string> line = File.ReadAllLines(path + ".txt").ToList<string>();
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
    }
}
