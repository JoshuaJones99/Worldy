using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worldy
{
    class Export
    {
        List<Square> Coordinates;
        List<float> DepthListRaw = new List<float>();   //used ONLY for finding min/max
        List<float[]> DepthList = new List<float[]>();
        float MinDepth;
        float MaxDepth;

        public Export(List<Square> Coordinates)
        {
            this.Coordinates = Coordinates;
            Console.WriteLine("Creating bitmap...");
            FindMinDepth();
            RealRenderImage();
            Console.WriteLine("Creating bitmap finished!");
        }

        public void FindMinDepth() //Finds minimum depth value and sets all height values to be more than 0
        {
            foreach (Square square in Coordinates)
            {
                DepthList.Add(new float[] { (float)square.NW[2], (float)square.SW[2], (float)square.SE[2], (float)square.NE[2] });
                DepthListRaw.Add((float)square.NW[2]); DepthListRaw.Add((float)square.SW[2]); DepthListRaw.Add((float)square.SE[2]);
                DepthListRaw.Add((float)square.NE[2]);
            }
            MinDepth = DepthListRaw.Min();

            if (MinDepth < 0)
            {
                for (int i = 0; i < DepthList.Count(); i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        DepthList[i][j] -= MinDepth;
                    }
                }
            }

            MaxDepth = DepthListRaw.Max() - MinDepth;
        }

        public void RealRenderImage() //This makes sure EVERY pixel is assigned a value by finding out the square the pixel is in and then calculating the height
        {
            Bitmap image = new Bitmap(513, 513);
            int height;
            int n = 0;
            for (int i = 0; i < 513; i++)
            {
                for (int j = 0; j < 513; j++)   //Iterates through all of the different pixels in the bitmap
                {
                    height = CalculateHeight(i, j);
                    int rgbVal = Convert.ToInt32(height / (MaxDepth / 255));
                    Color color = Color.FromArgb(rgbVal, rgbVal, rgbVal);

                    image.SetPixel(i, j, color);
                    n++;
                }
            }

            image.Save((Terrain.seed + ".BMP"));



        }
        public int CalculateHeight(int i, int j)
        {
            int index = FindIndex(i, j);    //Finds the index of the square in the coordinate list, which also refers to DepthList
            float avg = (DepthList[index][0] + DepthList[index][1] + DepthList[index][2] + DepthList[index][3]) / 4;
            int y = Convert.ToInt32(avg);

            //Make this better


            return y;
        }
        public int FindIndex(int i, int j)
        {
            int index = 0;
            for (int n = 0; n < Coordinates.Count(); n++)   //Not having <= on if statements causes white outlines around every square. Looks cool, but would mess up import
            {
                if (i >= Coordinates[n].NW[0] && i <= Coordinates[n].NE[0]) //If the coordinate is in the same X range
                {
                    if (j <= Coordinates[n].NW[1] && j >= Coordinates[n].SW[1]) //If the coordinate is in the same Y range
                    {
                        index = n;
                    }
                }
            }
            return index;
        }
    }
}
