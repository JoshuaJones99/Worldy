using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worldy
{
    public class Square
    {
        public double[] NW { get; set; }
        public double[] SW { get; set; }
        public double[] SE { get; set; }
        public double[] NE { get; set; }
        public double[] midpoint { get; set; }
        public double[][] corners = new double[4][];
        public string biomeType { get; set; }
        public Object obj { get; set; }

        public Square(double[] NW, double[] SW, double[] SE, double[] NE)
        {
            this.NW = NW; this.SW = SW; this.SE = SE; this.NE = NE;
            corners[0] = this.NW; corners[1] = this.SW; corners[2] = this.SE; corners[3] = this.NE;
            FindDuplicates();
            DiamondStep();
        }

        public void FindDuplicates()
        {

            foreach (Square square in Terrain.Queue)
            {
                foreach (double[] current_corner in corners)
                {
                    double[][] square_corners = new double[4][] { square.NW, square.SW, square.SE, square.NE };

                    foreach (double[] exterior_corner in square_corners)
                    {
                        if (current_corner[0] == exterior_corner[0] && current_corner[1] == exterior_corner[1])
                        {
                            current_corner[2] = exterior_corner[2];
                        }
                    }
                }
            }

            NW = corners[0]; SW = corners[1]; SE = corners[2]; NE = corners[3];
        }

        public void DiamondStep()
        {
            midpoint = new double[] { ((NW[0] + SE[0]) / 2), ((NW[1] + SE[1]) / 2), 0 };
            double avgheight = (NW[2] + SW[2] + SE[2] + NE[2]) / 4;
            midpoint[2] = avgheight + randHeight(NW[0], SE[0]);
        }

        public void SquareStep()
        {
            double[] west = new double[3] { (NW[0]), (midpoint[1]), (((NW[2] + SW[2] + midpoint[2]) / 3)) + randHeight(NW[1], SW[1]) };
            double[] south = new double[3] { midpoint[0], SE[1], (((SW[2] + SE[2] + midpoint[2]) / 3)) + randHeight(SW[0], SE[0]) };
            double[] east = new double[3] { SE[0], midpoint[1], (((SE[2] + NE[2] + midpoint[2]) / 3)) + randHeight(SE[1], NE[1]) };
            double[] north = new double[3] { midpoint[0], NW[1], (((NE[2] + NW[2] + midpoint[2]) / 3)) + randHeight(NE[0], NW[0]) };

            Terrain.Queue.Add(new Square(NW, west, midpoint, north));
            Terrain.Queue.Add(new Square(west, SW, south, midpoint));
            Terrain.Queue.Add(new Square(midpoint, south, SE, east));
            Terrain.Queue.Add(new Square(north, midpoint, east, NE));
        }

        public double randHeight(double coord1, double coord2)
        {
            int range = Convert.ToInt32(Math.Abs(coord1 - coord2));
            double rand = (Terrain.rand.Next(-range, range)) * 0.1 * Terrain.mountainJaggedness;
            return rand;
        }
    }
}
