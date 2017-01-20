using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Worldy
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            ObjectDensity_Slider.Enabled = false;
            ObjectDensity_Label.Enabled = false;
            BiomeSize_Label.Enabled = false;
            BiomeSize_Slider.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void RANDOMISE_BUTTON_Click_1(object sender, EventArgs e)
        {
            Random randomGen = new Random();
            int mountainjag = randomGen.Next(0, MountainJaggedness_Slider.Maximum);
            int terraincomplexity = randomGen.Next(0, TerrainComplexity_Slider.Maximum);
            int objectdensity = randomGen.Next(0, ObjectDensity_Slider.Maximum);
            int biomesize = randomGen.Next(0, BiomeSize_Slider.Maximum);

            bool objectsEnabled = randomGen.Next(0, 2) == 0;
            bool biomesEnabled = randomGen.Next(0, 2) == 0;
            bool render = randomGen.Next(0, 2) == 0;
            bool heightmap = randomGen.Next(0, 2) == 0;

            MountainJaggedness_Slider.Value = mountainjag;
            MountainJaggedness_Label.Text = "" + mountainjag;

            TerrainComplexity_Slider.Value = terraincomplexity;
            TerrainComplexity_Label.Text = "" + terraincomplexity;

            ObjectDensity_Slider.Value = objectdensity;
            ObjectDensity_Label.Text = "" + objectdensity;

            BiomeSize_Slider.Value = biomesize;
            BiomeSize_Label.Text = "" + biomesize;

            ObjectsEnabled_Checkbox.Checked = objectsEnabled;
            BiomesEnabled_Checkbox.Checked = biomesEnabled;
            Render_Checkbox.Checked = render;
            Heightmap_Checkbox.Checked = heightmap;

        }
        private void MountainJaggedness_Slider_Scroll_1(object sender, EventArgs e)
        {
            MountainJaggedness_Label.Text = "" + MountainJaggedness_Slider.Value;
        }

        private void ObjectDensity_Slider_Scroll_1(object sender, EventArgs e)
        {
            ObjectDensity_Label.Text = "" + ObjectDensity_Slider.Value;
        }

        private void TerrainComplexity_Slider_Scroll_1(object sender, EventArgs e)
        {
            TerrainComplexity_Label.Text = "" + TerrainComplexity_Slider.Value;
        }

        private void BiomeSize_Slider_Scroll_1(object sender, EventArgs e)
        {
            BiomeSize_Label.Text = "" + BiomeSize_Slider.Value;
        }

        private void ObjectsEnabled_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ObjectsEnabled_Checkbox.Checked == true)
            {
                ObjectDensity_Label.Enabled = true;
                ObjectDensity_Slider.Enabled = true;
            }
            else
            {
                ObjectDensity_Label.Enabled = false;
                ObjectDensity_Slider.Enabled = false;
            }
        }

        private void BiomesEnabled_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (BiomesEnabled_Checkbox.Checked)
            {
                BiomeSize_Slider.Enabled = true;
                BiomeSize_Label.Enabled = true;
            }
            else
            {
                BiomeSize_Slider.Enabled = false;
                BiomeSize_Label.Enabled = false;
            }
        }

        private void GENERATE_BUTTON_Click(object sender, EventArgs e)
        {
            //Creates seed out of all values
            //The seed is a string compiled of hex values and raw int/bool values of user defined variables
            //Seed is stored in format 'ABCCDEF0000' A = Mountain jaggedness hex, B = Terrain Complexity etc...

            string mountainJag = MountainJaggedness_Slider.Value.ToString("X1"); //Hex of length 1
            string terrainComplexity = TerrainComplexity_Slider.Value.ToString("D1"); //Decimal of length 1
            string objDensityHex = ObjectDensity_Slider.Value.ToString("X2"); //Stores ObjectDensity as 2bit hex value
            string biomeSize = BiomeSize_Slider.Value.ToString("D1");
            string objectsEnabled = Convert.ToInt32(ObjectsEnabled_Checkbox.Checked).ToString("D1");
            string biomesEnabled = Convert.ToInt32(BiomesEnabled_Checkbox.Checked).ToString("D1");

            Random randSeedGen = new Random();
            string thisSeed = mountainJag + terrainComplexity + objDensityHex + biomeSize + objectsEnabled + biomesEnabled;
            int randNumber = randSeedGen.Next(0, 4096); //4096 is max value for a 3 digit hexadecimal number
            thisSeed += randNumber.ToString("X3"); //Adds hex of randNumber to seed
            this.Hide();
            Terrain terrain = new Terrain(MountainJaggedness_Slider.Value, TerrainComplexity_Slider.Value, ObjectDensity_Slider.Value,
                                          BiomeSize_Slider.Value, ObjectsEnabled_Checkbox.Checked, BiomesEnabled_Checkbox.Checked,
                                          Render_Checkbox.Checked, Heightmap_Checkbox.Checked, thisSeed);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validating this will hurt
            string thisSeed = Interaction.InputBox("Please enter your seed here:", "Seed Prompt", "", -1, -1);

            //Seed is stored in format 'ABCCDEF0000' A = Mountain jaggedness hex, B = Terrain Complexity etc...
            //Splits the seed into the appropriate format and assigns variables
            char[] seedChars = thisSeed.ToCharArray();
            string hexMountainJaggedness = seedChars[0].ToString();
            int mountainJaggedness = int.Parse(hexMountainJaggedness, System.Globalization.NumberStyles.HexNumber);

            int terrainComplexity = Convert.ToInt32(seedChars[1].ToString());

            int objectDensity = int.Parse((seedChars[2].ToString() + seedChars[3].ToString()).ToString(), System.Globalization.NumberStyles.HexNumber);

            int biomeSize = Convert.ToInt32(seedChars[4].ToString());
            int biomeRand = Convert.ToInt32(seedChars[5].ToString());

            bool objectsEnabled = (seedChars[6]) == 1;
            bool biomesEnabled = (seedChars[7]) == 1;

            this.Hide();
            Terrain terrain = new Terrain(mountainJaggedness, terrainComplexity, objectDensity, biomeSize, objectsEnabled, biomesEnabled, true, true, thisSeed);


        }

        private void Simple_Load(object sender, EventArgs e)
        {

        }

        private void Help_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Controls are as follows:\n\nMouse to rotate terrain\nEnter to confirm terrain and render\nEscape to exit to options", "Terrain Generator Controls");
        }
    }
}
