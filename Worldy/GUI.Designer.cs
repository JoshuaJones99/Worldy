namespace Worldy
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Help_Button = new System.Windows.Forms.Button();
            this.GENERATE_BUTTON = new System.Windows.Forms.Button();
            this.RANDOMISE_BUTTON = new System.Windows.Forms.Button();
            this.ImportSeed = new System.Windows.Forms.Button();
            this.BiomeSize_Slider = new System.Windows.Forms.TrackBar();
            this.ObjectDensity_Slider = new System.Windows.Forms.TrackBar();
            this.Heightmap_Checkbox = new System.Windows.Forms.CheckBox();
            this.Render_Checkbox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TerrainComplexity_Label = new System.Windows.Forms.Label();
            this.TerrainComplexity_Slider = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.BiomeSize_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ObjectDensity_Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MountainJaggedness_Label = new System.Windows.Forms.Label();
            this.BiomesEnabled_Checkbox = new System.Windows.Forms.CheckBox();
            this.ObjectsEnabled_Checkbox = new System.Windows.Forms.CheckBox();
            this.MountainJaggedness_Slider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.BiomeSize_Slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectDensity_Slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainComplexity_Slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MountainJaggedness_Slider)).BeginInit();
            this.SuspendLayout();
            // 
            // Help_Button
            // 
            this.Help_Button.Location = new System.Drawing.Point(46, 153);
            this.Help_Button.Name = "Help_Button";
            this.Help_Button.Size = new System.Drawing.Size(75, 40);
            this.Help_Button.TabIndex = 78;
            this.Help_Button.Text = "Help";
            this.Help_Button.UseVisualStyleBackColor = true;
            // 
            // GENERATE_BUTTON
            // 
            this.GENERATE_BUTTON.Location = new System.Drawing.Point(289, 153);
            this.GENERATE_BUTTON.Name = "GENERATE_BUTTON";
            this.GENERATE_BUTTON.Size = new System.Drawing.Size(75, 40);
            this.GENERATE_BUTTON.TabIndex = 64;
            this.GENERATE_BUTTON.Text = "Generate";
            this.GENERATE_BUTTON.UseVisualStyleBackColor = true;
            // 
            // RANDOMISE_BUTTON
            // 
            this.RANDOMISE_BUTTON.Location = new System.Drawing.Point(208, 153);
            this.RANDOMISE_BUTTON.Name = "RANDOMISE_BUTTON";
            this.RANDOMISE_BUTTON.Size = new System.Drawing.Size(75, 40);
            this.RANDOMISE_BUTTON.TabIndex = 71;
            this.RANDOMISE_BUTTON.Text = "Randomise";
            this.RANDOMISE_BUTTON.UseVisualStyleBackColor = true;
            // 
            // ImportSeed
            // 
            this.ImportSeed.Location = new System.Drawing.Point(127, 153);
            this.ImportSeed.Name = "ImportSeed";
            this.ImportSeed.Size = new System.Drawing.Size(75, 40);
            this.ImportSeed.TabIndex = 76;
            this.ImportSeed.Text = "Import Seed";
            this.ImportSeed.UseVisualStyleBackColor = true;
            // 
            // BiomeSize_Slider
            // 
            this.BiomeSize_Slider.Location = new System.Drawing.Point(124, 118);
            this.BiomeSize_Slider.Maximum = 4;
            this.BiomeSize_Slider.Name = "BiomeSize_Slider";
            this.BiomeSize_Slider.Size = new System.Drawing.Size(149, 45);
            this.BiomeSize_Slider.TabIndex = 63;
            // 
            // ObjectDensity_Slider
            // 
            this.ObjectDensity_Slider.Location = new System.Drawing.Point(124, 83);
            this.ObjectDensity_Slider.Maximum = 50;
            this.ObjectDensity_Slider.Name = "ObjectDensity_Slider";
            this.ObjectDensity_Slider.Size = new System.Drawing.Size(149, 45);
            this.ObjectDensity_Slider.TabIndex = 62;
            this.ObjectDensity_Slider.TickFrequency = 5;
            // 
            // Heightmap_Checkbox
            // 
            this.Heightmap_Checkbox.AutoSize = true;
            this.Heightmap_Checkbox.Location = new System.Drawing.Point(292, 113);
            this.Heightmap_Checkbox.Name = "Heightmap_Checkbox";
            this.Heightmap_Checkbox.Size = new System.Drawing.Size(110, 17);
            this.Heightmap_Checkbox.TabIndex = 77;
            this.Heightmap_Checkbox.Text = "Heightmap Export";
            this.Heightmap_Checkbox.UseVisualStyleBackColor = true;
            // 
            // Render_Checkbox
            // 
            this.Render_Checkbox.AutoSize = true;
            this.Render_Checkbox.Location = new System.Drawing.Point(292, 85);
            this.Render_Checkbox.Name = "Render_Checkbox";
            this.Render_Checkbox.Size = new System.Drawing.Size(61, 17);
            this.Render_Checkbox.TabIndex = 75;
            this.Render_Checkbox.Text = "Render";
            this.Render_Checkbox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 74;
            this.label7.Text = "Terrain Complexity";
            // 
            // TerrainComplexity_Label
            // 
            this.TerrainComplexity_Label.AutoSize = true;
            this.TerrainComplexity_Label.Location = new System.Drawing.Point(270, 50);
            this.TerrainComplexity_Label.Name = "TerrainComplexity_Label";
            this.TerrainComplexity_Label.Size = new System.Drawing.Size(13, 13);
            this.TerrainComplexity_Label.TabIndex = 73;
            this.TerrainComplexity_Label.Text = "0";
            // 
            // TerrainComplexity_Slider
            // 
            this.TerrainComplexity_Slider.Location = new System.Drawing.Point(124, 46);
            this.TerrainComplexity_Slider.Maximum = 7;
            this.TerrainComplexity_Slider.Name = "TerrainComplexity_Slider";
            this.TerrainComplexity_Slider.Size = new System.Drawing.Size(149, 45);
            this.TerrainComplexity_Slider.TabIndex = 72;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Biome Size";
            // 
            // BiomeSize_Label
            // 
            this.BiomeSize_Label.AutoSize = true;
            this.BiomeSize_Label.Location = new System.Drawing.Point(270, 122);
            this.BiomeSize_Label.Name = "BiomeSize_Label";
            this.BiomeSize_Label.Size = new System.Drawing.Size(13, 13);
            this.BiomeSize_Label.TabIndex = 69;
            this.BiomeSize_Label.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Object Density";
            // 
            // ObjectDensity_Label
            // 
            this.ObjectDensity_Label.AutoSize = true;
            this.ObjectDensity_Label.Location = new System.Drawing.Point(270, 87);
            this.ObjectDensity_Label.Name = "ObjectDensity_Label";
            this.ObjectDensity_Label.Size = new System.Drawing.Size(13, 13);
            this.ObjectDensity_Label.TabIndex = 67;
            this.ObjectDensity_Label.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Mountain Jaggedness";
            // 
            // MountainJaggedness_Label
            // 
            this.MountainJaggedness_Label.AutoSize = true;
            this.MountainJaggedness_Label.Location = new System.Drawing.Point(270, 15);
            this.MountainJaggedness_Label.Name = "MountainJaggedness_Label";
            this.MountainJaggedness_Label.Size = new System.Drawing.Size(13, 13);
            this.MountainJaggedness_Label.TabIndex = 65;
            this.MountainJaggedness_Label.Text = "0";
            // 
            // BiomesEnabled_Checkbox
            // 
            this.BiomesEnabled_Checkbox.AutoSize = true;
            this.BiomesEnabled_Checkbox.Location = new System.Drawing.Point(292, 57);
            this.BiomesEnabled_Checkbox.Name = "BiomesEnabled_Checkbox";
            this.BiomesEnabled_Checkbox.Size = new System.Drawing.Size(102, 17);
            this.BiomesEnabled_Checkbox.TabIndex = 60;
            this.BiomesEnabled_Checkbox.Text = "Biomes Enabled";
            this.BiomesEnabled_Checkbox.UseVisualStyleBackColor = true;
            // 
            // ObjectsEnabled_Checkbox
            // 
            this.ObjectsEnabled_Checkbox.AutoSize = true;
            this.ObjectsEnabled_Checkbox.Location = new System.Drawing.Point(292, 28);
            this.ObjectsEnabled_Checkbox.Name = "ObjectsEnabled_Checkbox";
            this.ObjectsEnabled_Checkbox.Size = new System.Drawing.Size(104, 17);
            this.ObjectsEnabled_Checkbox.TabIndex = 59;
            this.ObjectsEnabled_Checkbox.Text = "Objects Enabled";
            this.ObjectsEnabled_Checkbox.UseVisualStyleBackColor = true;
            // 
            // MountainJaggedness_Slider
            // 
            this.MountainJaggedness_Slider.Location = new System.Drawing.Point(124, 11);
            this.MountainJaggedness_Slider.Name = "MountainJaggedness_Slider";
            this.MountainJaggedness_Slider.Size = new System.Drawing.Size(149, 45);
            this.MountainJaggedness_Slider.TabIndex = 61;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 204);
            this.Controls.Add(this.Help_Button);
            this.Controls.Add(this.GENERATE_BUTTON);
            this.Controls.Add(this.RANDOMISE_BUTTON);
            this.Controls.Add(this.ImportSeed);
            this.Controls.Add(this.BiomeSize_Slider);
            this.Controls.Add(this.ObjectDensity_Slider);
            this.Controls.Add(this.Heightmap_Checkbox);
            this.Controls.Add(this.Render_Checkbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TerrainComplexity_Label);
            this.Controls.Add(this.TerrainComplexity_Slider);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BiomeSize_Label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ObjectDensity_Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MountainJaggedness_Label);
            this.Controls.Add(this.BiomesEnabled_Checkbox);
            this.Controls.Add(this.ObjectsEnabled_Checkbox);
            this.Controls.Add(this.MountainJaggedness_Slider);
            this.Name = "GUI";
            this.Text = "Worldy";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BiomeSize_Slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectDensity_Slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainComplexity_Slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MountainJaggedness_Slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Help_Button;
        private System.Windows.Forms.Button GENERATE_BUTTON;
        private System.Windows.Forms.Button RANDOMISE_BUTTON;
        private System.Windows.Forms.Button ImportSeed;
        private System.Windows.Forms.TrackBar BiomeSize_Slider;
        private System.Windows.Forms.TrackBar ObjectDensity_Slider;
        private System.Windows.Forms.CheckBox Heightmap_Checkbox;
        private System.Windows.Forms.CheckBox Render_Checkbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label TerrainComplexity_Label;
        private System.Windows.Forms.TrackBar TerrainComplexity_Slider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label BiomeSize_Label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ObjectDensity_Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MountainJaggedness_Label;
        private System.Windows.Forms.CheckBox BiomesEnabled_Checkbox;
        private System.Windows.Forms.CheckBox ObjectsEnabled_Checkbox;
        private System.Windows.Forms.TrackBar MountainJaggedness_Slider;
    }
}

