
namespace AnTaREs
{
    partial class PLC_Roof
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PB_RoofSX = new MetroSet_UI.Controls.MetroSetProgressBar();
            this.PB_Roof_DX = new MetroSet_UI.Controls.MetroSetProgressBar();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(1, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 252);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // PB_RoofSX
            // 
            this.PB_RoofSX.BackgroundColor = System.Drawing.Color.Transparent;
            this.PB_RoofSX.BorderColor = System.Drawing.Color.Transparent;
            this.PB_RoofSX.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.PB_RoofSX.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.PB_RoofSX.DisabledProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.PB_RoofSX.IsDerivedStyle = true;
            this.PB_RoofSX.Location = new System.Drawing.Point(1, 24);
            this.PB_RoofSX.Maximum = 100;
            this.PB_RoofSX.Minimum = 0;
            this.PB_RoofSX.Name = "PB_RoofSX";
            this.PB_RoofSX.Orientation = MetroSet_UI.Enums.ProgressOrientation.Horizontal;
            this.PB_RoofSX.ProgressColor = System.Drawing.SystemColors.Control;
            this.PB_RoofSX.Size = new System.Drawing.Size(150, 25);
            this.PB_RoofSX.Style = MetroSet_UI.Enums.Style.Light;
            this.PB_RoofSX.StyleManager = null;
            this.PB_RoofSX.TabIndex = 0;
            this.PB_RoofSX.Text = "metroSetProgressBar1";
            this.PB_RoofSX.ThemeAuthor = "Narwin";
            this.PB_RoofSX.ThemeName = "MetroLite";
            this.PB_RoofSX.Value = 0;
            // 
            // PB_Roof_DX
            // 
            this.PB_Roof_DX.BackgroundColor = System.Drawing.SystemColors.Control;
            this.PB_Roof_DX.BorderColor = System.Drawing.Color.White;
            this.PB_Roof_DX.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.PB_Roof_DX.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.PB_Roof_DX.DisabledProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.PB_Roof_DX.IsDerivedStyle = true;
            this.PB_Roof_DX.Location = new System.Drawing.Point(150, 23);
            this.PB_Roof_DX.Maximum = 100;
            this.PB_Roof_DX.Minimum = 0;
            this.PB_Roof_DX.Name = "PB_Roof_DX";
            this.PB_Roof_DX.Orientation = MetroSet_UI.Enums.ProgressOrientation.Horizontal;
            this.PB_Roof_DX.ProgressColor = System.Drawing.Color.White;
            this.PB_Roof_DX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PB_Roof_DX.Size = new System.Drawing.Size(150, 25);
            this.PB_Roof_DX.Style = MetroSet_UI.Enums.Style.Light;
            this.PB_Roof_DX.StyleManager = null;
            this.PB_Roof_DX.TabIndex = 1;
            this.PB_Roof_DX.Text = "metroSetProgressBar2";
            this.PB_Roof_DX.ThemeAuthor = "Narwin";
            this.PB_Roof_DX.ThemeName = "MetroLite";
            this.PB_Roof_DX.Value = 0;
            // 
            // PLC_Roof
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.PB_Roof_DX);
            this.Controls.Add(this.PB_RoofSX);
            this.Controls.Add(this.groupBox1);
            this.Name = "PLC_Roof";
            this.SmallRectThickness = 1;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroSet_UI.Controls.MetroSetProgressBar PB_RoofSX;
        private MetroSet_UI.Controls.MetroSetProgressBar PB_Roof_DX;
    }
}
