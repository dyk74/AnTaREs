
namespace AnTaREs
{
    partial class PLC_SecurityChain
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
            this.Security_Chain_Eclipse = new MetroSet_UI.Controls.MetroSetEllipse();
            this.Ttip_Security_Chain = new MetroSet_UI.Components.MetroSetSetToolTip();
            this.Lbl_Security_Chain_Label = new MetroSet_UI.Controls.MetroSetLabel();
            this.SuspendLayout();
            // 
            // Security_Chain_Eclipse
            // 
            this.Security_Chain_Eclipse.BorderThickness = 1;
            this.Security_Chain_Eclipse.DisabledBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Security_Chain_Eclipse.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.Security_Chain_Eclipse.DisabledForeColor = System.Drawing.Color.Transparent;
            this.Security_Chain_Eclipse.Enabled = false;
            this.Security_Chain_Eclipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Security_Chain_Eclipse.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Security_Chain_Eclipse.HoverColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Security_Chain_Eclipse.HoverTextColor = System.Drawing.Color.White;
            this.Security_Chain_Eclipse.Image = null;
            this.Security_Chain_Eclipse.ImageSize = new System.Drawing.Size(64, 64);
            this.Security_Chain_Eclipse.IsDerivedStyle = true;
            this.Security_Chain_Eclipse.Location = new System.Drawing.Point(1, 1);
            this.Security_Chain_Eclipse.Name = "Security_Chain_Eclipse";
            this.Security_Chain_Eclipse.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Security_Chain_Eclipse.NormalColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Security_Chain_Eclipse.NormalTextColor = System.Drawing.Color.White;
            this.Security_Chain_Eclipse.PressBorderColor = System.Drawing.Color.Transparent;
            this.Security_Chain_Eclipse.PressColor = System.Drawing.Color.Transparent;
            this.Security_Chain_Eclipse.PressTextColor = System.Drawing.Color.Transparent;
            this.Security_Chain_Eclipse.Size = new System.Drawing.Size(40, 40);
            this.Security_Chain_Eclipse.Style = MetroSet_UI.Enums.Style.Light;
            this.Security_Chain_Eclipse.StyleManager = null;
            this.Security_Chain_Eclipse.TabIndex = 0;
            this.Security_Chain_Eclipse.Text = "X";
            this.Security_Chain_Eclipse.ThemeAuthor = "Narwin";
            this.Security_Chain_Eclipse.ThemeName = "MetroLite";
            // 
            // Ttip_Security_Chain
            // 
            this.Ttip_Security_Chain.BackColor = System.Drawing.Color.White;
            this.Ttip_Security_Chain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Ttip_Security_Chain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.Ttip_Security_Chain.IsDerivedStyle = true;
            this.Ttip_Security_Chain.OwnerDraw = true;
            this.Ttip_Security_Chain.Style = MetroSet_UI.Enums.Style.Light;
            this.Ttip_Security_Chain.StyleManager = null;
            this.Ttip_Security_Chain.ThemeAuthor = "Narwin";
            this.Ttip_Security_Chain.ThemeName = "MetroLite";
            // 
            // Lbl_Security_Chain_Label
            // 
            this.Lbl_Security_Chain_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Security_Chain_Label.IsDerivedStyle = true;
            this.Lbl_Security_Chain_Label.Location = new System.Drawing.Point(41, 1);
            this.Lbl_Security_Chain_Label.Name = "Lbl_Security_Chain_Label";
            this.Lbl_Security_Chain_Label.Size = new System.Drawing.Size(150, 40);
            this.Lbl_Security_Chain_Label.Style = MetroSet_UI.Enums.Style.Light;
            this.Lbl_Security_Chain_Label.StyleManager = null;
            this.Lbl_Security_Chain_Label.TabIndex = 1;
            this.Lbl_Security_Chain_Label.Text = "-";
            this.Lbl_Security_Chain_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lbl_Security_Chain_Label.ThemeAuthor = "Narwin";
            this.Lbl_Security_Chain_Label.ThemeName = "MetroLite";
            // 
            // PLC_SecurityChain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 42);
            this.Controls.Add(this.Lbl_Security_Chain_Label);
            this.Controls.Add(this.Security_Chain_Eclipse);
            this.Name = "PLC_SecurityChain";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetEllipse Security_Chain_Eclipse;
        private MetroSet_UI.Components.MetroSetSetToolTip Ttip_Security_Chain;
        private MetroSet_UI.Controls.MetroSetLabel Lbl_Security_Chain_Label;
    }
}
