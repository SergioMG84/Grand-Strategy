using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Civerino
{
    public enum terraintype
    {
        plain = 0,
        crops = 1,
        forest = 2,
        mountain = 3,
        river = 4,
        sea = 5
    }

    public class Terrain
    {
        public bool occupied;
        public terraintype type;
        public int food
        {
            get 
            {
                int fd=0;
                switch (type)
                {
                    case(terraintype.sea):
                        fd = 3;
                        break;
                    case(terraintype.river):
                        fd = 3;
                        break;
                    case(terraintype.forest):
                        fd = 2;
                        break;
                    case(terraintype.crops):
                        fd = 5;
                        break;
                    case(terraintype.mountain):
                        fd = 0;
                        break;
                    case(terraintype.plain):
                        fd = 1;
                        break;
                }
                return fd;
            }
        }
        public int gold
        {
            get 
            {
                int gd = 0;
                switch (type)
                {
                    case (terraintype.river):
                        gd = 1;
                        break;
                    case (terraintype.mountain):
                        gd = 3;
                        break;
                    default:
                        gd = 0;
                        break;
                }
                return gd;
            }
        }

        public Terrain(terraintype type)
        {
            this.type = type; occupied = false;
        }

    }
}
