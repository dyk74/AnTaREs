
namespace AnTaREs
{
    partial class PLC_Button
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
            this.Btn_PLC_Button = new MetroSet_UI.Controls.MetroSetButton();
            this.Lbl_PLC_Button = new MetroSet_UI.Controls.MetroSetLabel();
            this.SuspendLayout();
            // 
            // Btn_PLC_Button
            // 
            this.Btn_PLC_Button.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Btn_PLC_Button.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Btn_PLC_Button.DisabledForeColor = System.Drawing.Color.Gray;
            this.Btn_PLC_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Btn_PLC_Button.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Btn_PLC_Button.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Btn_PLC_Button.HoverTextColor = System.Drawing.Color.White;
            this.Btn_PLC_Button.IsDerivedStyle = true;
            this.Btn_PLC_Button.Location = new System.Drawing.Point(1, 1);
            this.Btn_PLC_Button.Name = "Btn_PLC_Button";
            this.Btn_PLC_Button.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Btn_PLC_Button.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Btn_PLC_Button.NormalTextColor = System.Drawing.Color.White;
            this.Btn_PLC_Button.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Btn_PLC_Button.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Btn_PLC_Button.PressTextColor = System.Drawing.Color.White;
            this.Btn_PLC_Button.Size = new System.Drawing.Size(100, 40);
            this.Btn_PLC_Button.Style = MetroSet_UI.Enums.Style.Light;
            this.Btn_PLC_Button.StyleManager = null;
            this.Btn_PLC_Button.TabIndex = 0;
            this.Btn_PLC_Button.Text = "Value";
            this.Btn_PLC_Button.ThemeAuthor = "Narwin";
            this.Btn_PLC_Button.ThemeName = "MetroLite";
            this.Btn_PLC_Button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_PLC_Button_MouseDown);
            this.Btn_PLC_Button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_PLC_Button_MouseUp);
            // 
            // Lbl_PLC_Button
            // 
            this.Lbl_PLC_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_PLC_Button.IsDerivedStyle = true;
            this.Lbl_PLC_Button.Location = new System.Drawing.Point(101, 1);
            this.Lbl_PLC_Button.Name = "Lbl_PLC_Button";
            this.Lbl_PLC_Button.Size = new System.Drawing.Size(100, 40);
            this.Lbl_PLC_Button.Style = MetroSet_UI.Enums.Style.Light;
            this.Lbl_PLC_Button.StyleManager = null;
            this.Lbl_PLC_Button.TabIndex = 1;
            this.Lbl_PLC_Button.Text = "-";
            this.Lbl_PLC_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lbl_PLC_Button.ThemeAuthor = "Narwin";
            this.Lbl_PLC_Button.ThemeName = "MetroLite";
            // 
            // PLC_Button
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 42);
            this.Controls.Add(this.Lbl_PLC_Button);
            this.Controls.Add(this.Btn_PLC_Button);
            this.Name = "PLC_Button";
            this.SmallRectThickness = 1;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetButton Btn_PLC_Button;
        private MetroSet_UI.Controls.MetroSetLabel Lbl_PLC_Button;
    }
}
