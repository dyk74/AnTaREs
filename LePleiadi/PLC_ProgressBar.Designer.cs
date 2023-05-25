
namespace AnTaREs
{
    partial class PLC_ProgressBar
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
            this.lbl_ProgressBarVariable = new MetroSet_UI.Controls.MetroSetLabel();
            this.Pb_ProgressBar = new MetroSet_UI.Controls.MetroSetProgressBar();
            this.lbl_ProgressBar_Value = new MetroSet_UI.Controls.MetroSetLabel();
            this.SuspendLayout();
            // 
            // lbl_ProgressBarVariable
            // 
            this.lbl_ProgressBarVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ProgressBarVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProgressBarVariable.IsDerivedStyle = true;
            this.lbl_ProgressBarVariable.Location = new System.Drawing.Point(0, 0);
            this.lbl_ProgressBarVariable.Name = "lbl_ProgressBarVariable";
            this.lbl_ProgressBarVariable.Size = new System.Drawing.Size(84, 42);
            this.lbl_ProgressBarVariable.Style = MetroSet_UI.Enums.Style.Light;
            this.lbl_ProgressBarVariable.StyleManager = null;
            this.lbl_ProgressBarVariable.TabIndex = 0;
            this.lbl_ProgressBarVariable.Text = "-";
            this.lbl_ProgressBarVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_ProgressBarVariable.ThemeAuthor = "Narwin";
            this.lbl_ProgressBarVariable.ThemeName = "MetroLite";
            // 
            // Pb_ProgressBar
            // 
            this.Pb_ProgressBar.BackgroundColor = System.Drawing.Color.Gray;
            this.Pb_ProgressBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.Pb_ProgressBar.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.Pb_ProgressBar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.Pb_ProgressBar.DisabledProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Pb_ProgressBar.IsDerivedStyle = true;
            this.Pb_ProgressBar.Location = new System.Drawing.Point(82, 0);
            this.Pb_ProgressBar.Maximum = 100;
            this.Pb_ProgressBar.Minimum = 0;
            this.Pb_ProgressBar.Name = "Pb_ProgressBar";
            this.Pb_ProgressBar.Orientation = MetroSet_UI.Enums.ProgressOrientation.Horizontal;
            this.Pb_ProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Pb_ProgressBar.Size = new System.Drawing.Size(200, 42);
            this.Pb_ProgressBar.Style = MetroSet_UI.Enums.Style.Light;
            this.Pb_ProgressBar.StyleManager = null;
            this.Pb_ProgressBar.TabIndex = 1;
            this.Pb_ProgressBar.ThemeAuthor = "Narwin";
            this.Pb_ProgressBar.ThemeName = "MetroLite";
            this.Pb_ProgressBar.Value = 0;
            this.Pb_ProgressBar.Click += new System.EventHandler(this.Pb_ProgressBar_Clicked);
            // 
            // lbl_ProgressBar_Value
            // 
            this.lbl_ProgressBar_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProgressBar_Value.IsDerivedStyle = true;
            this.lbl_ProgressBar_Value.Location = new System.Drawing.Point(282, 0);
            this.lbl_ProgressBar_Value.Name = "lbl_ProgressBar_Value";
            this.lbl_ProgressBar_Value.Size = new System.Drawing.Size(42, 42);
            this.lbl_ProgressBar_Value.Style = MetroSet_UI.Enums.Style.Light;
            this.lbl_ProgressBar_Value.StyleManager = null;
            this.lbl_ProgressBar_Value.TabIndex = 2;
            this.lbl_ProgressBar_Value.Text = "-";
            this.lbl_ProgressBar_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_ProgressBar_Value.ThemeAuthor = "Narwin";
            this.lbl_ProgressBar_Value.ThemeName = "MetroLite";
            // 
            // PLC_ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 42);
            this.Controls.Add(this.lbl_ProgressBar_Value);
            this.Controls.Add(this.Pb_ProgressBar);
            this.Controls.Add(this.lbl_ProgressBarVariable);
            this.Name = "PLC_ProgressBar";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetLabel lbl_ProgressBarVariable;
        private MetroSet_UI.Controls.MetroSetProgressBar Pb_ProgressBar;
        private MetroSet_UI.Controls.MetroSetLabel lbl_ProgressBar_Value;
    }
}
