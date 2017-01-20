using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worldy
{
    class Terrain
    {
        //Test
        public static int gridSize = 512;    //CONSTANT
        public static float mountainJaggedness;
        public static int terrainComplexity;
        public static int objectDensity;
        public static int biomeSize;
        public static int biomeRand;
        public static bool objectsEnabled;
        public static bool biomesEnabled;
        public static bool Render;
        public static bool exportEnabled;
        public static bool renderTime = false;
        public static string seed;
        public static Random rand;
        public static List<Square> Queue = new List<Square>();
        public List<Square> CoordDB;

        public Terrain(float umountainJaggedness, int uterrainComplexity, int uobjectDensity, int ubiomeSize, bool uobjectsEnabled,
                       bool ubiomesEnabled, bool uRender, bool uexportEnabled, string useed)
        {
            mountainJaggedness = umountainJaggedness;
            terrainComplexity = uterrainComplexity;
            objectDensity = uobjectDensity;
            biomeSize = ubiomeSize;
            objectsEnabled = uobjectsEnabled;
            biomesEnabled = ubiomesEnabled;
            Render = uRender;
            exportEnabled = uexportEnabled;
            seed = useed;

            rand = new Random(seed.GetHashCode());  //Makes a seeded random generator with the hash code of the seed.
            GenerateTerrain();

            if (biomesEnabled == true) { GenerateBiomes(); }
            if (objectsEnabled == true) { GenerateObjects(); }
            if (Render == true)
            {
                Render render = new Render(CoordDB);
                render.Run(30.0f);
            }
            else { renderTime = true; }
            if (exportEnabled == true && renderTime == true)
            {
                Export heightmap = new Export(CoordDB); //Should take CoordDB
            }
        }

        public void GenerateTerrain()
        {
            Console.WriteLine("Generating terrain...");
            CoordDB = new List<Square>
            {
                new Square
                (
                    new double[] { 0, gridSize, 0 },
                    new double[] { 0, 0, 0 },
                    new double[] { gridSize, 0, 0 },
                    new double[] { gridSize, gridSize, 0 }
                )
            };

            int n = 0;

            while (n < terrainComplexity)
            {
                foreach (Square square in CoordDB) { square.SquareStep(); }

                foreach (Square square in Queue) { CoordDB.Add(square); }

                for (int i = 0; i < Math.Pow(4, n); i++) { CoordDB.RemoveAt(0); }

                Queue.Clear();
                n++;
            }
            Console.WriteLine("Generating terrain... Finished!");
        }

        public void GenerateBiomes()
        {
            string BiomeType;
            Console.WriteLine("Generating Biomes...");
            for (int i = 0; i < CoordDB.Count; i += biomeSize)
            {
                BiomeType = (i == 0) ?
                                        DetermineBiome(rand.NextDouble(), "") :
                                        DetermineBiome(rand.NextDouble(), CoordDB[i - 1].biomeType);

                for (int j = i; j < (i + biomeSize); j += 1)
                {
                    if (j < CoordDB.Count) { CoordDB[j].biomeType = BiomeType; }
                    else break;

                }
            }
            Console.WriteLine("Generating biomes... Finished!");
        }

        public string DetermineBiome(double rand, string surrounding)
        {
            string biome = "";
            if (surrounding == "")
            {
                if (rand < 0.25) { biome = "Forest"; }
                if (0.25 < rand && rand < 0.5) { biome = "Plains"; }
                if (0.5 < rand && rand < 0.75) { biome = "Desert"; }
                if (0.75 < rand) { biome = "Tundra"; }
            }
            else if (surrounding == "Forest")
            {
                if (rand < 0.7) { biome = "Forest"; }
                if (0.7 < rand && rand < 0.8) { biome = "Plains"; }
                if (0.8 < rand && rand < 0.9) { biome = "Desert"; }
                if (0.9 < rand) { biome = "Tundra"; }
            }
            else if (surrounding == "Plains")
            {
                if (rand < 0.7) { biome = "Plains"; }
                if (0.7 < rand && rand < 0.8) { biome = "Desert"; }
                if (0.8 < rand && rand < 0.9) { biome = "Tundra"; }
                if (0.9 < rand) { biome = "Forest"; }
            }
            else if (surrounding == "Desert")
            {
                if (rand < 0.7) { biome = "Tundra"; }
                if (0.7 < rand && rand < 0.8) { biome = "Forest"; }
                if (0.8 < rand && rand < 0.9) { biome = "Plains"; }
                if (0.9 < rand) { biome = "Desert"; }
            }
            else if (surrounding == "Tundra")
            {
                if (rand < 0.7) { biome = "Tundra"; }
                if (0.7 < rand && rand < 0.8) { biome = "Forest"; }
                if (0.8 < rand && rand < 0.9) { biome = "Plains"; }
                if (0.9 < rand) { biome = "Desert"; }
            }
            return biome;


        }

        public void GenerateObjects()
        {
            int SquareIndex, n = 0;
            List<int> existing = new List<int>();
            while (n < objectDensity)
            {
                SquareIndex = rand.Next(0, CoordDB.Count());
                if (existing.Contains(SquareIndex) == false) //Checks if the index has already been used.
                {
                    CoordDB[SquareIndex].obj = new Object(CoordDB[SquareIndex].biomeType);  //Create a new object for that Square with the biome of the square
                    existing.Add(SquareIndex);
                    n++;
                }

            }
        }
    }
}
