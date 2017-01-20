using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worldy
{
    public class Object
    {
        public string Biome { get; set; }
        public string Type { get; set; }

        public Object(string Biome)
        {
            this.Biome = Biome;

            if (Terrain.biomesEnabled == true)
            {
                if (Biome == "Forest") { Type = "Tree"; }
                if (Biome == "Plains") { Type = "Bush"; }
                if (Biome == "Desert") { Type = "Cactus"; }
                if (Biome == "Tundra") { Type = "Rock"; }
            }
        }

        public string getInfo()
        {
            return (Biome + " " + Type);
        }
    }
}
