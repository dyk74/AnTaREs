
namespace LePleiadi
{
    partial class PLC
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
            this.lblPLCVariabile = new MetroSet_UI.Controls.MetroSetLabel();
            this.lblPLCValue = new MetroSet_UI.Controls.MetroSetLabel();
            this.SuspendLayout();
            // 
            // lblPLCVariabile
            // 
            this.lblPLCVariabile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPLCVariabile.IsDerivedStyle = true;
            this.lblPLCVariabile.Location = new System.Drawing.Point(4, 4);
            this.lblPLCVariabile.Name = "lblPLCVariabile";
            this.lblPLCVariabile.Size = new System.Drawing.Size(68, 23);
            this.lblPLCVariabile.Style = MetroSet_UI.Enums.Style.Light;
            this.lblPLCVariabile.StyleManager = null;
            this.lblPLCVariabile.TabIndex = 0;
            this.lblPLCVariabile.Text = "Variabile";
            this.lblPLCVariabile.ThemeAuthor = "Narwin";
            this.lblPLCVariabile.ThemeName = "MetroLite";
            // 
            // lblPLCValue
            // 
            this.lblPLCValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPLCValue.IsDerivedStyle = true;
            this.lblPLCValue.Location = new System.Drawing.Point(4, 31);
            this.lblPLCValue.Name = "lblPLCValue";
            this.lblPLCValue.Size = new System.Drawing.Size(100, 23);
            this.lblPLCValue.Style = MetroSet_UI.Enums.Style.Light;
            this.lblPLCValue.StyleManager = null;
            this.lblPLCValue.TabIndex = 1;
            this.lblPLCValue.Text = "Value";
            this.lblPLCValue.ThemeAuthor = "Narwin";
            this.lblPLCValue.ThemeName = "MetroLite";
            // 
            // PLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPLCValue);
            this.Controls.Add(this.lblPLCVariabile);
            this.Name = "PLC";
            this.Size = new System.Drawing.Size(572, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetLabel lblPLCVariabile;
        private MetroSet_UI.Controls.MetroSetLabel lblPLCValue;
    }
}
