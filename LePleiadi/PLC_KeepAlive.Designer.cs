
namespace AnTaREs
{
    partial class PLC_KeepAlive
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
            this.lbl_KeepAlive = new MetroSet_UI.Controls.MetroSetLabel();
            this.ecl_LedKeepAlive = new MetroSet_UI.Controls.MetroSetEllipse();
            this.SuspendLayout();
            // 
            // lbl_KeepAlive
            // 
            this.lbl_KeepAlive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_KeepAlive.IsDerivedStyle = true;
            this.lbl_KeepAlive.Location = new System.Drawing.Point(0, 0);
            this.lbl_KeepAlive.Name = "lbl_KeepAlive";
            this.lbl_KeepAlive.Size = new System.Drawing.Size(100, 42);
            this.lbl_KeepAlive.Style = MetroSet_UI.Enums.Style.Light;
            this.lbl_KeepAlive.StyleManager = null;
            this.lbl_KeepAlive.TabIndex = 0;
            this.lbl_KeepAlive.Text = "Server Keep Alive";
            this.lbl_KeepAlive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_KeepAlive.ThemeAuthor = "Narwin";
            this.lbl_KeepAlive.ThemeName = "MetroLite";
            // 
            // ecl_LedKeepAlive
            // 
            this.ecl_LedKeepAlive.BorderThickness = 1;
            this.ecl_LedKeepAlive.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.ecl_LedKeepAlive.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.ecl_LedKeepAlive.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.ecl_LedKeepAlive.Enabled = false;
            this.ecl_LedKeepAlive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ecl_LedKeepAlive.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ecl_LedKeepAlive.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ecl_LedKeepAlive.HoverTextColor = System.Drawing.Color.White;
            this.ecl_LedKeepAlive.Image = null;
            this.ecl_LedKeepAlive.ImageSize = new System.Drawing.Size(64, 64);
            this.ecl_LedKeepAlive.IsDerivedStyle = true;
            this.ecl_LedKeepAlive.Location = new System.Drawing.Point(106, 0);
            this.ecl_LedKeepAlive.Name = "ecl_LedKeepAlive";
            this.ecl_LedKeepAlive.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.ecl_LedKeepAlive.NormalColor = System.Drawing.Color.Green;
            this.ecl_LedKeepAlive.NormalTextColor = System.Drawing.Color.Black;
            this.ecl_LedKeepAlive.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ecl_LedKeepAlive.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ecl_LedKeepAlive.PressTextColor = System.Drawing.Color.White;
            this.ecl_LedKeepAlive.Size = new System.Drawing.Size(42, 42);
            this.ecl_LedKeepAlive.Style = MetroSet_UI.Enums.Style.Light;
            this.ecl_LedKeepAlive.StyleManager = null;
            this.ecl_LedKeepAlive.TabIndex = 1;
            this.ecl_LedKeepAlive.ThemeAuthor = "Narwin";
            this.ecl_LedKeepAlive.ThemeName = "MetroLite";
            // 
            // PLC_KeepAlive
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(152, 42);
            this.Controls.Add(this.ecl_LedKeepAlive);
            this.Controls.Add(this.lbl_KeepAlive);
            this.Name = "PLC_KeepAlive";
            this.SmallRectThickness = 1;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetLabel lbl_KeepAlive;
        private MetroSet_UI.Controls.MetroSetEllipse ecl_LedKeepAlive;
    }
}
