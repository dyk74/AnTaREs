
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
            this.Stile = new MetroSet_UI.Components.StyleManager();
            this.TabConnection = new MetroSet_UI.Controls.MetroSetTabControl();
            this.metroControllo = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.btnControlStatus = new MetroSet_UI.Controls.MetroSetEllipse();
            this.metroSetLabel1 = new MetroSet_UI.Controls.MetroSetLabel();
            this.swConnect = new MetroSet_UI.Controls.MetroSetSwitch();
            this.metroPLC = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.grpChange = new System.Windows.Forms.GroupBox();
            this.LblTetto = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroTetto = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.metroAllarmi = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.grpRoof = new System.Windows.Forms.GroupBox();
            this.grpPLC = new System.Windows.Forms.GroupBox();
            this._metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
            this.TabConnection.SuspendLayout();
            this.metroControllo.SuspendLayout();
            this.metroPLC.SuspendLayout();
            this.grpRoof.SuspendLayout();
            this.SuspendLayout();
            // 
            // Stile
            // 
            this.Stile.CustomTheme = "C:\\Users\\bee\\AppData\\Roaming\\Microsoft\\Windows\\Templates\\ThemeFile.xml";
            this.Stile.MetroForm = this;
            this.Stile.Style = MetroSet_UI.Enums.Style.Light;
            this.Stile.ThemeAuthor = null;
            this.Stile.ThemeName = null;
            // 
            // TabConnection
            // 
            this.TabConnection.AnimateEasingType = MetroSet_UI.Enums.EasingType.CubeOut;
            this.TabConnection.AnimateTime = 200;
            this.TabConnection.BackgroundColor = System.Drawing.Color.White;
            this.TabConnection.Controls.Add(this.metroControllo);
            this.TabConnection.Controls.Add(this.metroPLC);
            this.TabConnection.Controls.Add(this.metroTetto);
            this.TabConnection.Controls.Add(this.metroAllarmi);
            this.TabConnection.Cursor = System.Windows.Forms.Cursors.Default;
            this.TabConnection.IsDerivedStyle = true;
            this.TabConnection.ItemSize = new System.Drawing.Size(100, 38);
            this.TabConnection.Location = new System.Drawing.Point(2, 73);
            this.TabConnection.Name = "TabConnection";
            this.TabConnection.SelectedIndex = 1;
            this.TabConnection.SelectedTextColor = System.Drawing.Color.White;
            this.TabConnection.Size = new System.Drawing.Size(798, 374);
            this.TabConnection.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabConnection.Speed = 100;
            this.TabConnection.Style = MetroSet_UI.Enums.Style.Light;
            this.TabConnection.StyleManager = this.Stile;
            this.TabConnection.TabIndex = 0;
            this.TabConnection.ThemeAuthor = null;
            this.TabConnection.ThemeName = null;
            this.TabConnection.UnselectedTextColor = System.Drawing.Color.Gray;
            this.TabConnection.UseAnimation = false;
            // 
            // metroControllo
            // 
            this.metroControllo.BaseColor = System.Drawing.Color.White;
            this.metroControllo.Controls.Add(this.btnControlStatus);
            this.metroControllo.Controls.Add(this.metroSetLabel1);
            this.metroControllo.Controls.Add(this.swConnect);
            this.metroControllo.Font = null;
            this.metroControllo.ImageIndex = 0;
            this.metroControllo.ImageKey = null;
            this.metroControllo.IsDerivedStyle = true;
            this.metroControllo.Location = new System.Drawing.Point(4, 42);
            this.metroControllo.Name = "metroControllo";
            this.metroControllo.Size = new System.Drawing.Size(790, 328);
            this.metroControllo.Style = MetroSet_UI.Enums.Style.Light;
            this.metroControllo.StyleManager = null;
            this.metroControllo.TabIndex = 0;
            this.metroControllo.Text = "Controllo";
            this.metroControllo.ThemeAuthor = "Narwin";
            this.metroControllo.ThemeName = "MetroLite";
            this.metroControllo.ToolTipText = null;
            // 
            // btnControlStatus
            // 
            this.btnControlStatus.BorderThickness = 7;
            this.btnControlStatus.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnControlStatus.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.btnControlStatus.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.btnControlStatus.Enabled = false;
            this.btnControlStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnControlStatus.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnControlStatus.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnControlStatus.HoverTextColor = System.Drawing.Color.White;
            this.btnControlStatus.Image = null;
            this.btnControlStatus.ImageSize = new System.Drawing.Size(32, 32);
            this.btnControlStatus.IsDerivedStyle = true;
            this.btnControlStatus.Location = new System.Drawing.Point(570, 3);
            this.btnControlStatus.Name = "btnControlStatus";
            this.btnControlStatus.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnControlStatus.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
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
            this.swConnect.StyleManager = this.Stile;
            this.swConnect.Switched = false;
            this.swConnect.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.swConnect.TabIndex = 0;
            this.swConnect.Text = "metroSetSwitch1";
            this.swConnect.ThemeAuthor = "Narwin";
            this.swConnect.ThemeName = "MetroLite";
            this.swConnect.UnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.swConnect.SwitchedChanged += new MetroSet_UI.Controls.MetroSetSwitch.SwitchedChangedEventHandler(this.SwConnect_SwitchedChanged);
            // 
            // metroPLC
            // 
            this.metroPLC.BaseColor = System.Drawing.Color.White;
            this.metroPLC.Controls.Add(this.grpPLC);
            this.metroPLC.Controls.Add(this.grpRoof);
            this.metroPLC.Controls.Add(this.grpChange);
            this.metroPLC.Font = null;
            this.metroPLC.ImageIndex = 0;
            this.metroPLC.ImageKey = null;
            this.metroPLC.IsDerivedStyle = true;
            this.metroPLC.Location = new System.Drawing.Point(4, 42);
            this.metroPLC.Name = "metroPLC";
            this.metroPLC.Size = new System.Drawing.Size(790, 328);
            this.metroPLC.Style = MetroSet_UI.Enums.Style.Light;
            this.metroPLC.StyleManager = null;
            this.metroPLC.TabIndex = 1;
            this.metroPLC.Text = "PLC";
            this.metroPLC.ThemeAuthor = "Narwin";
            this.metroPLC.ThemeName = "MetroLite";
            this.metroPLC.ToolTipText = null;
            // 
            // grpChange
            // 
            this.grpChange.BackColor = System.Drawing.SystemColors.Window;
            this.grpChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChange.ForeColor = System.Drawing.Color.Black;
            this.grpChange.Location = new System.Drawing.Point(518, 3);
            this.grpChange.Name = "grpChange";
            this.grpChange.Size = new System.Drawing.Size(245, 90);
            this.grpChange.TabIndex = 5;
            this.grpChange.TabStop = false;
            this.grpChange.Text = "Change Event";
            // 
            // LblTetto
            // 
            this.LblTetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTetto.IsDerivedStyle = true;
            this.LblTetto.Location = new System.Drawing.Point(6, 34);
            this.LblTetto.Name = "LblTetto";
            this.LblTetto.Size = new System.Drawing.Size(47, 23);
            this.LblTetto.Style = MetroSet_UI.Enums.Style.Light;
            this.LblTetto.StyleManager = null;
            this.LblTetto.TabIndex = 1;
            this.LblTetto.Text = "Tetto";
            this.LblTetto.ThemeAuthor = "Narwin";
            this.LblTetto.ThemeName = "MetroLite";
            // 
            // metroTetto
            // 
            this.metroTetto.BaseColor = System.Drawing.Color.White;
            this.metroTetto.Font = null;
            this.metroTetto.ImageIndex = 0;
            this.metroTetto.ImageKey = null;
            this.metroTetto.IsDerivedStyle = true;
            this.metroTetto.Location = new System.Drawing.Point(4, 42);
            this.metroTetto.Name = "metroTetto";
            this.metroTetto.Size = new System.Drawing.Size(790, 328);
            this.metroTetto.Style = MetroSet_UI.Enums.Style.Light;
            this.metroTetto.StyleManager = null;
            this.metroTetto.TabIndex = 3;
            this.metroTetto.Text = "Tetto";
            this.metroTetto.ThemeAuthor = "Narwin";
            this.metroTetto.ThemeName = "MetroLite";
            this.metroTetto.ToolTipText = null;
            // 
            // metroAllarmi
            // 
            this.metroAllarmi.BaseColor = System.Drawing.Color.White;
            this.metroAllarmi.Font = null;
            this.metroAllarmi.ImageIndex = 0;
            this.metroAllarmi.ImageKey = null;
            this.metroAllarmi.IsDerivedStyle = true;
            this.metroAllarmi.Location = new System.Drawing.Point(4, 42);
            this.metroAllarmi.Name = "metroAllarmi";
            this.metroAllarmi.Size = new System.Drawing.Size(790, 328);
            this.metroAllarmi.Style = MetroSet_UI.Enums.Style.Light;
            this.metroAllarmi.StyleManager = null;
            this.metroAllarmi.TabIndex = 2;
            this.metroAllarmi.Text = "Allarmi";
            this.metroAllarmi.ThemeAuthor = "Narwin";
            this.metroAllarmi.ThemeName = "MetroLite";
            this.metroAllarmi.ToolTipText = null;
            // 
            // grpRoof
            // 
            this.grpRoof.BackColor = System.Drawing.SystemColors.Window;
            this.grpRoof.Controls.Add(this.LblTetto);
            this.grpRoof.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRoof.Location = new System.Drawing.Point(518, 100);
            this.grpRoof.Name = "grpRoof";
            this.grpRoof.Size = new System.Drawing.Size(245, 105);
            this.grpRoof.TabIndex = 6;
            this.grpRoof.TabStop = false;
            this.grpRoof.Text = "Roof";
            // 
            // grpPLC
            // 
            this.grpPLC.BackColor = System.Drawing.SystemColors.Window;
            this.grpPLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPLC.Location = new System.Drawing.Point(518, 212);
            this.grpPLC.Name = "grpPLC";
            this.grpPLC.Size = new System.Drawing.Size(245, 113);
            this.grpPLC.TabIndex = 7;
            this.grpPLC.TabStop = false;
            this.grpPLC.Text = "PLC Label";
            // 
            // _metroSetControlBox1
            // 
            this._metroSetControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._metroSetControlBox1.BackColor = System.Drawing.Color.Transparent;
            this._metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this._metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this._metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.Gray;
            this._metroSetControlBox1.DisabledForeColor = System.Drawing.Color.DimGray;
            this._metroSetControlBox1.IsDerivedStyle = true;
            this._metroSetControlBox1.Location = new System.Drawing.Point(685, 18);
            this._metroSetControlBox1.MaximizeBox = true;
            this._metroSetControlBox1.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this._metroSetControlBox1.MaximizeHoverForeColor = System.Drawing.Color.Gray;
            this._metroSetControlBox1.MaximizeNormalForeColor = System.Drawing.Color.Gray;
            this._metroSetControlBox1.MinimizeBox = true;
            this._metroSetControlBox1.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this._metroSetControlBox1.MinimizeHoverForeColor = System.Drawing.Color.Gray;
            this._metroSetControlBox1.MinimizeNormalForeColor = System.Drawing.Color.Gray;
            this._metroSetControlBox1.Name = "_metroSetControlBox1";
            this._metroSetControlBox1.Size = new System.Drawing.Size(100, 25);
            this._metroSetControlBox1.Style = MetroSet_UI.Enums.Style.Light;
            this._metroSetControlBox1.StyleManager = this.Stile;
            this._metroSetControlBox1.TabIndex = 2;
            this._metroSetControlBox1.Text = "_metroSetControlBox1";
            this._metroSetControlBox1.ThemeAuthor = null;
            this._metroSetControlBox1.ThemeName = null;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._metroSetControlBox1);
            this.Controls.Add(this.TabConnection);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(12, 90, 12, 12);
            this.StyleManager = this.Stile;
            this.TextColor = System.Drawing.Color.White;
            this.ThemeName = "MetroLight";
            this.TabConnection.ResumeLayout(false);
            this.metroControllo.ResumeLayout(false);
            this.metroPLC.ResumeLayout(false);
            this.grpRoof.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Components.StyleManager Stile;
        private MetroSet_UI.Controls.MetroSetTabControl TabConnection;
        private MetroSet_UI.Child.MetroSetSetTabPage metroControllo;
        private MetroSet_UI.Controls.MetroSetEllipse btnControlStatus;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel1;
        private MetroSet_UI.Controls.MetroSetSwitch swConnect;
        private MetroSet_UI.Child.MetroSetSetTabPage metroPLC;
        private MetroSet_UI.Child.MetroSetSetTabPage metroAllarmi;
        public static MetroSet_UI.Controls.MetroSetButton btnUPS;
        public static MetroSet_UI.Controls.MetroSetLabel lblUPS;
        private MetroSet_UI.Child.MetroSetSetTabPage metroTetto;
        public static MetroSet_UI.Controls.MetroSetEllipse RoofOpenClose;
        public static MetroSet_UI.Controls.MetroSetEllipse RoofRight;
        public static MetroSet_UI.Controls.MetroSetEllipse RoofLeft;
        public static  MetroSet_UI.Controls.MetroSetLabel LblPLCVariableValue;
        public static MetroSet_UI.Controls.MetroSetLabel LblPLCVariableName;
        private MetroSet_UI.Controls.MetroSetLabel LblTetto;
        private System.Windows.Forms.GroupBox grpChange;
        public static MetroSet_UI.Controls.MetroSetLabel lblValueRun;
        public static MetroSet_UI.Controls.MetroSetLabel lblValueDirection;
        public static MetroSet_UI.Controls.MetroSetButton btnEvent;
        private System.Windows.Forms.GroupBox grpRoof;
        private System.Windows.Forms.GroupBox grpPLC;
        private MetroSet_UI.Controls.MetroSetControlBox _metroSetControlBox1;
    }
}

