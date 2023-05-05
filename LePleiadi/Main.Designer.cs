
namespace LePleiadi
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.styleManager1 = new MetroSet_UI.Components.StyleManager();
            this.TabConnection = new MetroSet_UI.Controls.MetroSetTabControl();
            this.metroSetSetTabPage1 = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.swConnect = new MetroSet_UI.Controls.MetroSetSwitch();
            this.metroSetLabel1 = new MetroSet_UI.Controls.MetroSetLabel();
            this.btnControlStatus = new MetroSet_UI.Controls.MetroSetEllipse();
            this.TabConnection.SuspendLayout();
            this.metroSetSetTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.CustomTheme = "C:\\Users\\bee\\AppData\\Roaming\\Microsoft\\Windows\\Templates\\ThemeFile.xml";
            this.styleManager1.MetroForm = this;
            this.styleManager1.Style = MetroSet_UI.Enums.Style.Light;
            this.styleManager1.ThemeAuthor = null;
            this.styleManager1.ThemeName = null;
            // 
            // TabConnection
            // 
            this.TabConnection.AnimateEasingType = MetroSet_UI.Enums.EasingType.CubeOut;
            this.TabConnection.AnimateTime = 200;
            this.TabConnection.BackgroundColor = System.Drawing.Color.White;
            this.TabConnection.Controls.Add(this.metroSetSetTabPage1);
            this.TabConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TabConnection.IsDerivedStyle = true;
            this.TabConnection.ItemSize = new System.Drawing.Size(100, 38);
            this.TabConnection.Location = new System.Drawing.Point(2, 73);
            this.TabConnection.Name = "TabConnection";
            this.TabConnection.SelectedIndex = 0;
            this.TabConnection.SelectedTextColor = System.Drawing.Color.White;
            this.TabConnection.Size = new System.Drawing.Size(798, 374);
            this.TabConnection.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabConnection.Speed = 100;
            this.TabConnection.Style = MetroSet_UI.Enums.Style.Light;
            this.TabConnection.StyleManager = this.styleManager1;
            this.TabConnection.TabIndex = 0;
            this.TabConnection.ThemeAuthor = null;
            this.TabConnection.ThemeName = null;
            this.TabConnection.UnselectedTextColor = System.Drawing.Color.Gray;
            this.TabConnection.UseAnimation = false;
            // 
            // metroSetSetTabPage1
            // 
            this.metroSetSetTabPage1.BaseColor = System.Drawing.Color.White;
            this.metroSetSetTabPage1.Controls.Add(this.btnControlStatus);
            this.metroSetSetTabPage1.Controls.Add(this.metroSetLabel1);
            this.metroSetSetTabPage1.Controls.Add(this.swConnect);
            this.metroSetSetTabPage1.Font = null;
            this.metroSetSetTabPage1.ImageIndex = 0;
            this.metroSetSetTabPage1.ImageKey = null;
            this.metroSetSetTabPage1.IsDerivedStyle = true;
            this.metroSetSetTabPage1.Location = new System.Drawing.Point(4, 42);
            this.metroSetSetTabPage1.Name = "metroSetSetTabPage1";
            this.metroSetSetTabPage1.Size = new System.Drawing.Size(790, 328);
            this.metroSetSetTabPage1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetSetTabPage1.StyleManager = null;
            this.metroSetSetTabPage1.TabIndex = 0;
            this.metroSetSetTabPage1.Text = "Controllo";
            this.metroSetSetTabPage1.ThemeAuthor = "Narwin";
            this.metroSetSetTabPage1.ThemeName = "MetroLite";
            this.metroSetSetTabPage1.ToolTipText = null;
            // 
            // swConnect
            // 
            this.swConnect.BackColor = System.Drawing.Color.Transparent;
            this.swConnect.BackgroundColor = System.Drawing.Color.Empty;
            this.swConnect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(147)))));
            this.swConnect.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.swConnect.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.swConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swConnect.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.swConnect.DisabledCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.swConnect.DisabledUnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.swConnect.IsDerivedStyle = true;
            this.swConnect.Location = new System.Drawing.Point(398, 39);
            this.swConnect.Name = "swConnect";
            this.swConnect.Size = new System.Drawing.Size(58, 22);
            this.swConnect.Style = MetroSet_UI.Enums.Style.Light;
            this.swConnect.StyleManager = this.styleManager1;
            this.swConnect.Switched = false;
            this.swConnect.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.swConnect.TabIndex = 0;
            this.swConnect.Text = "metroSetSwitch1";
            this.swConnect.ThemeAuthor = "Narwin";
            this.swConnect.ThemeName = "MetroLite";
            this.swConnect.UnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.swConnect.SwitchedChanged += new MetroSet_UI.Controls.MetroSetSwitch.SwitchedChangedEventHandler(this.swConnect_SwitchedChanged);
            // 
            // metroSetLabel1
            // 
            this.metroSetLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetLabel1.IsDerivedStyle = true;
            this.metroSetLabel1.Location = new System.Drawing.Point(157, 38);
            this.metroSetLabel1.Name = "metroSetLabel1";
            this.metroSetLabel1.Size = new System.Drawing.Size(185, 23);
            this.metroSetLabel1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel1.StyleManager = null;
            this.metroSetLabel1.TabIndex = 1;
            this.metroSetLabel1.Text = "Connessione Osservatorio";
            this.metroSetLabel1.ThemeAuthor = "Narwin";
            this.metroSetLabel1.ThemeName = "MetroLite";
            // 
            // btnControlStatus
            // 
            this.btnControlStatus.BorderThickness = 7;
            this.btnControlStatus.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnControlStatus.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnControlStatus.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnControlStatus.Enabled = false;
            this.btnControlStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnControlStatus.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnControlStatus.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnControlStatus.HoverTextColor = System.Drawing.Color.White;
            this.btnControlStatus.Image = null;
            this.btnControlStatus.ImageSize = new System.Drawing.Size(32, 32);
            this.btnControlStatus.IsDerivedStyle = true;
            this.btnControlStatus.Location = new System.Drawing.Point(570, 3);
            this.btnControlStatus.Name = "btnControlStatus";
            this.btnControlStatus.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnControlStatus.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnControlStatus.NormalTextColor = System.Drawing.Color.Black;
            this.btnControlStatus.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnControlStatus.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnControlStatus.PressTextColor = System.Drawing.Color.White;
            this.btnControlStatus.Size = new System.Drawing.Size(93, 88);
            this.btnControlStatus.Style = MetroSet_UI.Enums.Style.Light;
            this.btnControlStatus.StyleManager = null;
            this.btnControlStatus.TabIndex = 2;
            this.btnControlStatus.ThemeAuthor = "Narwin";
            this.btnControlStatus.ThemeName = "MetroLite";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TabConnection);
            this.Name = "Form1";
            this.StyleManager = this.styleManager1;
            this.ThemeName = "MetroLight";
            this.TabConnection.ResumeLayout(false);
            this.metroSetSetTabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Components.StyleManager styleManager1;
        private MetroSet_UI.Controls.MetroSetTabControl TabConnection;
        private MetroSet_UI.Child.MetroSetSetTabPage metroSetSetTabPage1;
        private MetroSet_UI.Controls.MetroSetEllipse btnControlStatus;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel1;
        private MetroSet_UI.Controls.MetroSetSwitch swConnect;
    }
}

