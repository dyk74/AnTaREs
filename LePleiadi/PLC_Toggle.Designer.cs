
namespace AnTaREs
{
    partial class PLC_Toggle
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
            this.sw_Toggle = new MetroSet_UI.Controls.MetroSetSwitch();
            this.lbl_ToggleLabel = new MetroSet_UI.Controls.MetroSetLabel();
            this.SuspendLayout();
            // 
            // sw_Toggle
            // 
            this.sw_Toggle.BackColor = System.Drawing.Color.Transparent;
            this.sw_Toggle.BackgroundColor = System.Drawing.Color.Empty;
            this.sw_Toggle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(147)))));
            this.sw_Toggle.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.sw_Toggle.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.sw_Toggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sw_Toggle.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.sw_Toggle.DisabledCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.sw_Toggle.DisabledUnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.sw_Toggle.IsDerivedStyle = true;
            this.sw_Toggle.Location = new System.Drawing.Point(0, 0);
            this.sw_Toggle.Name = "sw_Toggle";
            this.sw_Toggle.Size = new System.Drawing.Size(58, 22);
            this.sw_Toggle.Style = MetroSet_UI.Enums.Style.Light;
            this.sw_Toggle.StyleManager = null;
            this.sw_Toggle.Switched = false;
            this.sw_Toggle.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.sw_Toggle.TabIndex = 0;
            this.sw_Toggle.ThemeAuthor = "Narwin";
            this.sw_Toggle.ThemeName = "MetroLite";
            this.sw_Toggle.UnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.sw_Toggle.SwitchedChanged += new MetroSet_UI.Controls.MetroSetSwitch.SwitchedChangedEventHandler(this.Sw_Toggle_SwitchedChanged);
            // 
            // lbl_ToggleLabel
            // 
            this.lbl_ToggleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ToggleLabel.IsDerivedStyle = true;
            this.lbl_ToggleLabel.Location = new System.Drawing.Point(65, 0);
            this.lbl_ToggleLabel.Name = "lbl_ToggleLabel";
            this.lbl_ToggleLabel.Size = new System.Drawing.Size(141, 23);
            this.lbl_ToggleLabel.Style = MetroSet_UI.Enums.Style.Light;
            this.lbl_ToggleLabel.StyleManager = null;
            this.lbl_ToggleLabel.TabIndex = 1;
            this.lbl_ToggleLabel.Text = "-";
            this.lbl_ToggleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_ToggleLabel.ThemeAuthor = "Narwin";
            this.lbl_ToggleLabel.ThemeName = "MetroLite";
            // 
            // PLC_Toggle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 23);
            this.Controls.Add(this.lbl_ToggleLabel);
            this.Controls.Add(this.sw_Toggle);
            this.Name = "PLC_Toggle";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetSwitch sw_Toggle;
        private MetroSet_UI.Controls.MetroSetLabel lbl_ToggleLabel;
    }
}
