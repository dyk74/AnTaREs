
namespace AnTaREs
{
    partial class PLC_Alarm
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
            this.Ecl_Alarm = new MetroSet_UI.Controls.MetroSetEllipse();
            this.Btn_Reset = new MetroSet_UI.Controls.MetroSetButton();
            this.Lbl_Alarm = new MetroSet_UI.Controls.MetroSetLabel();
            this.SuspendLayout();
            // 
            // Ecl_Alarm
            // 
            this.Ecl_Alarm.BorderThickness = 0;
            this.Ecl_Alarm.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Ecl_Alarm.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.Ecl_Alarm.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.Ecl_Alarm.Enabled = false;
            this.Ecl_Alarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Ecl_Alarm.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Ecl_Alarm.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Ecl_Alarm.HoverTextColor = System.Drawing.Color.White;
            this.Ecl_Alarm.Image = null;
            this.Ecl_Alarm.ImageSize = new System.Drawing.Size(64, 64);
            this.Ecl_Alarm.IsDerivedStyle = true;
            this.Ecl_Alarm.Location = new System.Drawing.Point(1, 1);
            this.Ecl_Alarm.Name = "Ecl_Alarm";
            this.Ecl_Alarm.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Ecl_Alarm.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.Ecl_Alarm.NormalTextColor = System.Drawing.Color.Black;
            this.Ecl_Alarm.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Ecl_Alarm.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Ecl_Alarm.PressTextColor = System.Drawing.Color.White;
            this.Ecl_Alarm.Size = new System.Drawing.Size(40, 40);
            this.Ecl_Alarm.Style = MetroSet_UI.Enums.Style.Light;
            this.Ecl_Alarm.StyleManager = null;
            this.Ecl_Alarm.TabIndex = 0;
            this.Ecl_Alarm.ThemeAuthor = "Narwin";
            this.Ecl_Alarm.ThemeName = "MetroLite";
            // 
            // Btn_Reset
            // 
            this.Btn_Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Reset.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Btn_Reset.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Btn_Reset.DisabledForeColor = System.Drawing.Color.Gray;
            this.Btn_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Reset.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Btn_Reset.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Btn_Reset.HoverTextColor = System.Drawing.Color.White;
            this.Btn_Reset.IsDerivedStyle = true;
            this.Btn_Reset.Location = new System.Drawing.Point(50, 1);
            this.Btn_Reset.Name = "Btn_Reset";
            this.Btn_Reset.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Btn_Reset.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Btn_Reset.NormalTextColor = System.Drawing.Color.White;
            this.Btn_Reset.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Btn_Reset.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Btn_Reset.PressTextColor = System.Drawing.Color.White;
            this.Btn_Reset.Size = new System.Drawing.Size(100, 40);
            this.Btn_Reset.Style = MetroSet_UI.Enums.Style.Light;
            this.Btn_Reset.StyleManager = null;
            this.Btn_Reset.TabIndex = 1;
            this.Btn_Reset.Text = "Reset";
            this.Btn_Reset.ThemeAuthor = "Narwin";
            this.Btn_Reset.ThemeName = "MetroLite";
            this.Btn_Reset.Click += new System.EventHandler(this.Btn_Reset_Click);
            this.Btn_Reset.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Btn_Reset_ControlAdded);
            // 
            // Lbl_Alarm
            // 
            this.Lbl_Alarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Alarm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lbl_Alarm.IsDerivedStyle = true;
            this.Lbl_Alarm.Location = new System.Drawing.Point(170, 0);
            this.Lbl_Alarm.Name = "Lbl_Alarm";
            this.Lbl_Alarm.Size = new System.Drawing.Size(130, 40);
            this.Lbl_Alarm.Style = MetroSet_UI.Enums.Style.Light;
            this.Lbl_Alarm.StyleManager = null;
            this.Lbl_Alarm.TabIndex = 2;
            this.Lbl_Alarm.Text = "-";
            this.Lbl_Alarm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lbl_Alarm.ThemeAuthor = "Narwin";
            this.Lbl_Alarm.ThemeName = "MetroLite";
            // 
            // PLC_Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 42);
            this.Controls.Add(this.Lbl_Alarm);
            this.Controls.Add(this.Btn_Reset);
            this.Controls.Add(this.Ecl_Alarm);
            this.HeaderHeight = 1;
            this.Moveable = false;
            this.Name = "PLC_Alarm";
            this.ShowIcon = false;
            this.SmallRectThickness = 1;
            this.ResumeLayout(false);

        }



        #endregion
        private MetroSet_UI.Controls.MetroSetEllipse Ecl_Alarm;
        private MetroSet_UI.Controls.MetroSetButton Btn_Reset;
        private MetroSet_UI.Controls.MetroSetLabel Lbl_Alarm;
    }
}
