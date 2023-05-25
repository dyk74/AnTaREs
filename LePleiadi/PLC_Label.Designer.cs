
namespace AnTaREs
{
    partial class PLC_Label
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
            this.ecl_ValueStatus = new MetroSet_UI.Controls.MetroSetEllipse();
            this.lbl_ValueDescription = new MetroSet_UI.Controls.MetroSetLabel();
            this.SuspendLayout();
            // 
            // ecl_ValueStatus
            // 
            this.ecl_ValueStatus.BorderThickness = 1;
            this.ecl_ValueStatus.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.ecl_ValueStatus.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.ecl_ValueStatus.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.ecl_ValueStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ecl_ValueStatus.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ecl_ValueStatus.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ecl_ValueStatus.HoverTextColor = System.Drawing.Color.White;
            this.ecl_ValueStatus.Image = null;
            this.ecl_ValueStatus.ImageSize = new System.Drawing.Size(64, 64);
            this.ecl_ValueStatus.IsDerivedStyle = true;
            this.ecl_ValueStatus.Location = new System.Drawing.Point(0, 0);
            this.ecl_ValueStatus.Name = "ecl_ValueStatus";
            this.ecl_ValueStatus.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.ecl_ValueStatus.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ecl_ValueStatus.NormalTextColor = System.Drawing.Color.Black;
            this.ecl_ValueStatus.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ecl_ValueStatus.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ecl_ValueStatus.PressTextColor = System.Drawing.Color.White;
            this.ecl_ValueStatus.Size = new System.Drawing.Size(40, 40);
            this.ecl_ValueStatus.Style = MetroSet_UI.Enums.Style.Light;
            this.ecl_ValueStatus.StyleManager = null;
            this.ecl_ValueStatus.TabIndex = 0;
            this.ecl_ValueStatus.ThemeAuthor = "Narwin";
            this.ecl_ValueStatus.ThemeName = "MetroLite";
            this.ecl_ValueStatus.Click += new System.EventHandler(this.Ecl_ValueStatus_Click);
            // 
            // lbl_ValueDescription
            // 
            this.lbl_ValueDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValueDescription.IsDerivedStyle = true;
            this.lbl_ValueDescription.Location = new System.Drawing.Point(47, 0);
            this.lbl_ValueDescription.Name = "lbl_ValueDescription";
            this.lbl_ValueDescription.Size = new System.Drawing.Size(150, 42);
            this.lbl_ValueDescription.Style = MetroSet_UI.Enums.Style.Light;
            this.lbl_ValueDescription.StyleManager = null;
            this.lbl_ValueDescription.TabIndex = 1;
            this.lbl_ValueDescription.Text = "-";
            this.lbl_ValueDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_ValueDescription.ThemeAuthor = "Narwin";
            this.lbl_ValueDescription.ThemeName = "MetroLite";
            // 
            // PLC_Label
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 42);
            this.Controls.Add(this.lbl_ValueDescription);
            this.Controls.Add(this.ecl_ValueStatus);
            this.Name = "PLC_Label";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetEllipse ecl_ValueStatus;
        private MetroSet_UI.Controls.MetroSetLabel lbl_ValueDescription;
    }
}
