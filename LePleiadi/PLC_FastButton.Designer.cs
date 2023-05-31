
namespace AnTaREs
{
    partial class PLC_FastButton
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
            this.Btn_FastButton = new MetroSet_UI.Controls.MetroSetButton();
            this.lbl_Value_FastButton = new MetroSet_UI.Controls.MetroSetLabel();
            this.Lbl_Direction_FastButton = new MetroSet_UI.Controls.MetroSetLabel();
            this.SuspendLayout();
            // 
            // Btn_FastButton
            // 
            this.Btn_FastButton.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Btn_FastButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Btn_FastButton.DisabledForeColor = System.Drawing.Color.Gray;
            this.Btn_FastButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Btn_FastButton.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Btn_FastButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Btn_FastButton.HoverTextColor = System.Drawing.Color.White;
            this.Btn_FastButton.IsDerivedStyle = true;
            this.Btn_FastButton.Location = new System.Drawing.Point(1, 1);
            this.Btn_FastButton.Name = "Btn_FastButton";
            this.Btn_FastButton.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Btn_FastButton.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Btn_FastButton.NormalTextColor = System.Drawing.Color.White;
            this.Btn_FastButton.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Btn_FastButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Btn_FastButton.PressTextColor = System.Drawing.Color.White;
            this.Btn_FastButton.Size = new System.Drawing.Size(100, 40);
            this.Btn_FastButton.Style = MetroSet_UI.Enums.Style.Light;
            this.Btn_FastButton.StyleManager = null;
            this.Btn_FastButton.TabIndex = 0;
            this.Btn_FastButton.Text = "-";
            this.Btn_FastButton.ThemeAuthor = "Narwin";
            this.Btn_FastButton.ThemeName = "MetroLite";
            // 
            // lbl_Value_FastButton
            // 
            this.lbl_Value_FastButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_FastButton.IsDerivedStyle = true;
            this.lbl_Value_FastButton.Location = new System.Drawing.Point(101, 1);
            this.lbl_Value_FastButton.Name = "lbl_Value_FastButton";
            this.lbl_Value_FastButton.Size = new System.Drawing.Size(20, 20);
            this.lbl_Value_FastButton.Style = MetroSet_UI.Enums.Style.Light;
            this.lbl_Value_FastButton.StyleManager = null;
            this.lbl_Value_FastButton.TabIndex = 1;
            this.lbl_Value_FastButton.Text = "-";
            this.lbl_Value_FastButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Value_FastButton.ThemeAuthor = "Narwin";
            this.lbl_Value_FastButton.ThemeName = "MetroLite";
            // 
            // Lbl_Direction_FastButton
            // 
            this.Lbl_Direction_FastButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Direction_FastButton.IsDerivedStyle = true;
            this.Lbl_Direction_FastButton.Location = new System.Drawing.Point(101, 21);
            this.Lbl_Direction_FastButton.Name = "Lbl_Direction_FastButton";
            this.Lbl_Direction_FastButton.Size = new System.Drawing.Size(20, 20);
            this.Lbl_Direction_FastButton.Style = MetroSet_UI.Enums.Style.Light;
            this.Lbl_Direction_FastButton.StyleManager = null;
            this.Lbl_Direction_FastButton.TabIndex = 2;
            this.Lbl_Direction_FastButton.Text = "-";
            this.Lbl_Direction_FastButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lbl_Direction_FastButton.ThemeAuthor = "Narwin";
            this.Lbl_Direction_FastButton.ThemeName = "MetroLite";
            // 
            // PLC_FastButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(125, 42);
            this.Controls.Add(this.Lbl_Direction_FastButton);
            this.Controls.Add(this.lbl_Value_FastButton);
            this.Controls.Add(this.Btn_FastButton);
            this.Name = "PLC_FastButton";
            this.SmallRectThickness = 1;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetButton Btn_FastButton;
        private MetroSet_UI.Controls.MetroSetLabel lbl_Value_FastButton;
        private MetroSet_UI.Controls.MetroSetLabel Lbl_Direction_FastButton;
    }
}
