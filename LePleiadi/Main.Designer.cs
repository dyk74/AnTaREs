
namespace AnTaREs
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
            this.SetTab_Control = new MetroSet_UI.Controls.MetroSetTabControl();
            this.metroControllo = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.lbl_Osservatorio = new MetroSet_UI.Controls.MetroSetLabel();
            this.btnControlStatus = new MetroSet_UI.Controls.MetroSetEllipse();
            this.lbl_Connection = new MetroSet_UI.Controls.MetroSetLabel();
            this.swConnect = new MetroSet_UI.Controls.MetroSetSwitch();
            this.Tab_UPS = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.grpUPS = new System.Windows.Forms.GroupBox();
            this.metroTetto = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_Tetto = new System.Windows.Forms.GroupBox();
            this.Grp_FaldaSX = new System.Windows.Forms.GroupBox();
            this.Grp_faldaDX = new System.Windows.Forms.GroupBox();
            this.Tab_Parking = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_Parking = new System.Windows.Forms.GroupBox();
            this.Tab_Motori = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_Motori = new System.Windows.Forms.GroupBox();
            this.Tab_Server = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.grp_Server = new System.Windows.Forms.GroupBox();
            this.Tab_Vertigo = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.grp_Vertigo = new System.Windows.Forms.GroupBox();
            this._metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
            this.lblDateTime = new MetroSet_UI.Controls.MetroSetLabel();
            this.Tab_Telescopio = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_Autoguida = new System.Windows.Forms.GroupBox();
            this.Grp_Telescopio = new System.Windows.Forms.GroupBox();
            this.SetTab_Control.SuspendLayout();
            this.metroControllo.SuspendLayout();
            this.Tab_UPS.SuspendLayout();
            this.metroTetto.SuspendLayout();
            this.Grp_Tetto.SuspendLayout();
            this.Tab_Parking.SuspendLayout();
            this.Tab_Motori.SuspendLayout();
            this.Tab_Server.SuspendLayout();
            this.Tab_Vertigo.SuspendLayout();
            this.Tab_Telescopio.SuspendLayout();
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
            // SetTab_Control
            // 
            this.SetTab_Control.AnimateEasingType = MetroSet_UI.Enums.EasingType.CubeOut;
            this.SetTab_Control.AnimateTime = 200;
            this.SetTab_Control.BackgroundColor = System.Drawing.Color.White;
            this.SetTab_Control.Controls.Add(this.metroControllo);
            this.SetTab_Control.Controls.Add(this.Tab_UPS);
            this.SetTab_Control.Controls.Add(this.metroTetto);
            this.SetTab_Control.Controls.Add(this.Tab_Parking);
            this.SetTab_Control.Controls.Add(this.Tab_Motori);
            this.SetTab_Control.Controls.Add(this.Tab_Server);
            this.SetTab_Control.Controls.Add(this.Tab_Vertigo);
            this.SetTab_Control.Controls.Add(this.Tab_Telescopio);
            this.SetTab_Control.Cursor = System.Windows.Forms.Cursors.Default;
            this.SetTab_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetTab_Control.IsDerivedStyle = true;
            this.SetTab_Control.ItemSize = new System.Drawing.Size(100, 38);
            this.SetTab_Control.Location = new System.Drawing.Point(12, 90);
            this.SetTab_Control.Name = "SetTab_Control";
            this.SetTab_Control.SelectedIndex = 7;
            this.SetTab_Control.SelectedTextColor = System.Drawing.Color.White;
            this.SetTab_Control.Size = new System.Drawing.Size(1706, 906);
            this.SetTab_Control.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.SetTab_Control.Speed = 100;
            this.SetTab_Control.Style = MetroSet_UI.Enums.Style.Light;
            this.SetTab_Control.StyleManager = this.Stile;
            this.SetTab_Control.TabIndex = 0;
            this.SetTab_Control.ThemeAuthor = null;
            this.SetTab_Control.ThemeName = null;
            this.SetTab_Control.UnselectedTextColor = System.Drawing.Color.Gray;
            this.SetTab_Control.UseAnimation = false;
            // 
            // metroControllo
            // 
            this.metroControllo.BaseColor = System.Drawing.Color.White;
            this.metroControllo.Controls.Add(this.lbl_Osservatorio);
            this.metroControllo.Controls.Add(this.btnControlStatus);
            this.metroControllo.Controls.Add(this.lbl_Connection);
            this.metroControllo.Controls.Add(this.swConnect);
            this.metroControllo.Font = null;
            this.metroControllo.ImageIndex = 0;
            this.metroControllo.ImageKey = null;
            this.metroControllo.IsDerivedStyle = true;
            this.metroControllo.Location = new System.Drawing.Point(4, 42);
            this.metroControllo.Name = "metroControllo";
            this.metroControllo.Size = new System.Drawing.Size(1698, 860);
            this.metroControllo.Style = MetroSet_UI.Enums.Style.Light;
            this.metroControllo.StyleManager = this.Stile;
            this.metroControllo.TabIndex = 0;
            this.metroControllo.Text = "Connessione";
            this.metroControllo.ThemeAuthor = "Narwin";
            this.metroControllo.ThemeName = "MetroLite";
            this.metroControllo.ToolTipText = null;
            // 
            // lbl_Osservatorio
            // 
            this.lbl_Osservatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Osservatorio.IsDerivedStyle = true;
            this.lbl_Osservatorio.Location = new System.Drawing.Point(242, 40);
            this.lbl_Osservatorio.Name = "lbl_Osservatorio";
            this.lbl_Osservatorio.Size = new System.Drawing.Size(162, 23);
            this.lbl_Osservatorio.Style = MetroSet_UI.Enums.Style.Light;
            this.lbl_Osservatorio.StyleManager = this.Stile;
            this.lbl_Osservatorio.TabIndex = 3;
            this.lbl_Osservatorio.Text = "-";
            this.lbl_Osservatorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Osservatorio.ThemeAuthor = null;
            this.lbl_Osservatorio.ThemeName = null;
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
            this.btnControlStatus.Location = new System.Drawing.Point(565, 3);
            this.btnControlStatus.Name = "btnControlStatus";
            this.btnControlStatus.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnControlStatus.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnControlStatus.NormalTextColor = System.Drawing.Color.Black;
            this.btnControlStatus.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnControlStatus.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnControlStatus.PressTextColor = System.Drawing.Color.White;
            this.btnControlStatus.Size = new System.Drawing.Size(80, 80);
            this.btnControlStatus.Style = MetroSet_UI.Enums.Style.Light;
            this.btnControlStatus.StyleManager = this.Stile;
            this.btnControlStatus.TabIndex = 2;
            this.btnControlStatus.ThemeAuthor = null;
            this.btnControlStatus.ThemeName = null;
            // 
            // lbl_Connection
            // 
            this.lbl_Connection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_Connection.IsDerivedStyle = true;
            this.lbl_Connection.Location = new System.Drawing.Point(50, 40);
            this.lbl_Connection.Name = "lbl_Connection";
            this.lbl_Connection.Size = new System.Drawing.Size(185, 23);
            this.lbl_Connection.Style = MetroSet_UI.Enums.Style.Light;
            this.lbl_Connection.StyleManager = this.Stile;
            this.lbl_Connection.TabIndex = 1;
            this.lbl_Connection.Text = "Connessione Osservatorio";
            this.lbl_Connection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Connection.ThemeAuthor = null;
            this.lbl_Connection.ThemeName = null;
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
            this.swConnect.Location = new System.Drawing.Point(430, 40);
            this.swConnect.Name = "swConnect";
            this.swConnect.Size = new System.Drawing.Size(58, 22);
            this.swConnect.Style = MetroSet_UI.Enums.Style.Light;
            this.swConnect.StyleManager = this.Stile;
            this.swConnect.Switched = false;
            this.swConnect.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.swConnect.TabIndex = 0;
            this.swConnect.Text = "metroSetSwitch1";
            this.swConnect.ThemeAuthor = null;
            this.swConnect.ThemeName = null;
            this.swConnect.UnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.swConnect.SwitchedChanged += new MetroSet_UI.Controls.MetroSetSwitch.SwitchedChangedEventHandler(this.SwConnect_SwitchedChanged);
            // 
            // Tab_UPS
            // 
            this.Tab_UPS.BaseColor = System.Drawing.Color.White;
            this.Tab_UPS.Controls.Add(this.grpUPS);
            this.Tab_UPS.Font = null;
            this.Tab_UPS.ImageIndex = 0;
            this.Tab_UPS.ImageKey = null;
            this.Tab_UPS.IsDerivedStyle = true;
            this.Tab_UPS.Location = new System.Drawing.Point(4, 42);
            this.Tab_UPS.Name = "Tab_UPS";
            this.Tab_UPS.Size = new System.Drawing.Size(1698, 860);
            this.Tab_UPS.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_UPS.StyleManager = this.Stile;
            this.Tab_UPS.TabIndex = 2;
            this.Tab_UPS.Text = "UPS";
            this.Tab_UPS.ThemeAuthor = "Narwin";
            this.Tab_UPS.ThemeName = "MetroLite";
            this.Tab_UPS.ToolTipText = null;
            // 
            // grpUPS
            // 
            this.grpUPS.BackColor = System.Drawing.SystemColors.Window;
            this.grpUPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUPS.Location = new System.Drawing.Point(10, 0);
            this.grpUPS.Name = "grpUPS";
            this.grpUPS.Size = new System.Drawing.Size(686, 340);
            this.grpUPS.TabIndex = 0;
            this.grpUPS.TabStop = false;
            this.grpUPS.Text = "UPS";
            // 
            // metroTetto
            // 
            this.metroTetto.BaseColor = System.Drawing.Color.White;
            this.metroTetto.Controls.Add(this.Grp_Tetto);
            this.metroTetto.Font = null;
            this.metroTetto.ImageIndex = 0;
            this.metroTetto.ImageKey = null;
            this.metroTetto.IsDerivedStyle = true;
            this.metroTetto.Location = new System.Drawing.Point(4, 42);
            this.metroTetto.Name = "metroTetto";
            this.metroTetto.Size = new System.Drawing.Size(1698, 860);
            this.metroTetto.Style = MetroSet_UI.Enums.Style.Light;
            this.metroTetto.StyleManager = this.Stile;
            this.metroTetto.TabIndex = 3;
            this.metroTetto.Text = "Tetto";
            this.metroTetto.ThemeAuthor = "Narwin";
            this.metroTetto.ThemeName = "MetroLite";
            this.metroTetto.ToolTipText = null;
            // 
            // Grp_Tetto
            // 
            this.Grp_Tetto.AutoSize = true;
            this.Grp_Tetto.BackColor = System.Drawing.SystemColors.Window;
            this.Grp_Tetto.Controls.Add(this.Grp_FaldaSX);
            this.Grp_Tetto.Controls.Add(this.Grp_faldaDX);
            this.Grp_Tetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Tetto.Location = new System.Drawing.Point(3, 3);
            this.Grp_Tetto.Name = "Grp_Tetto";
            this.Grp_Tetto.Size = new System.Drawing.Size(1661, 830);
            this.Grp_Tetto.TabIndex = 2;
            this.Grp_Tetto.TabStop = false;
            this.Grp_Tetto.Text = "Tetto";
            // 
            // Grp_FaldaSX
            // 
            this.Grp_FaldaSX.Location = new System.Drawing.Point(6, 236);
            this.Grp_FaldaSX.Name = "Grp_FaldaSX";
            this.Grp_FaldaSX.Size = new System.Drawing.Size(550, 300);
            this.Grp_FaldaSX.TabIndex = 1;
            this.Grp_FaldaSX.TabStop = false;
            this.Grp_FaldaSX.Text = "falda sinistra";
            // 
            // Grp_faldaDX
            // 
            this.Grp_faldaDX.Location = new System.Drawing.Point(605, 236);
            this.Grp_faldaDX.Name = "Grp_faldaDX";
            this.Grp_faldaDX.Size = new System.Drawing.Size(550, 300);
            this.Grp_faldaDX.TabIndex = 0;
            this.Grp_faldaDX.TabStop = false;
            this.Grp_faldaDX.Text = "falda destra";
            // 
            // Tab_Parking
            // 
            this.Tab_Parking.BaseColor = System.Drawing.Color.White;
            this.Tab_Parking.Controls.Add(this.Grp_Parking);
            this.Tab_Parking.Font = null;
            this.Tab_Parking.ImageIndex = 0;
            this.Tab_Parking.ImageKey = null;
            this.Tab_Parking.IsDerivedStyle = true;
            this.Tab_Parking.Location = new System.Drawing.Point(4, 42);
            this.Tab_Parking.Name = "Tab_Parking";
            this.Tab_Parking.Size = new System.Drawing.Size(1698, 860);
            this.Tab_Parking.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_Parking.StyleManager = null;
            this.Tab_Parking.TabIndex = 4;
            this.Tab_Parking.Text = "Parking";
            this.Tab_Parking.ThemeAuthor = "Narwin";
            this.Tab_Parking.ThemeName = "MetroLite";
            this.Tab_Parking.ToolTipText = null;
            // 
            // Grp_Parking
            // 
            this.Grp_Parking.BackColor = System.Drawing.Color.White;
            this.Grp_Parking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Parking.Location = new System.Drawing.Point(3, 3);
            this.Grp_Parking.Name = "Grp_Parking";
            this.Grp_Parking.Size = new System.Drawing.Size(1055, 359);
            this.Grp_Parking.TabIndex = 5;
            this.Grp_Parking.TabStop = false;
            this.Grp_Parking.Text = "Parking";
            // 
            // Tab_Motori
            // 
            this.Tab_Motori.BaseColor = System.Drawing.Color.White;
            this.Tab_Motori.Controls.Add(this.Grp_Motori);
            this.Tab_Motori.Font = null;
            this.Tab_Motori.ImageIndex = 0;
            this.Tab_Motori.ImageKey = null;
            this.Tab_Motori.IsDerivedStyle = true;
            this.Tab_Motori.Location = new System.Drawing.Point(4, 42);
            this.Tab_Motori.Name = "Tab_Motori";
            this.Tab_Motori.Size = new System.Drawing.Size(1698, 860);
            this.Tab_Motori.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_Motori.StyleManager = null;
            this.Tab_Motori.TabIndex = 5;
            this.Tab_Motori.Text = "Motori";
            this.Tab_Motori.ThemeAuthor = "Narwin";
            this.Tab_Motori.ThemeName = "MetroLite";
            this.Tab_Motori.ToolTipText = null;
            // 
            // Grp_Motori
            // 
            this.Grp_Motori.BackColor = System.Drawing.Color.White;
            this.Grp_Motori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grp_Motori.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Motori.Location = new System.Drawing.Point(0, 0);
            this.Grp_Motori.Name = "Grp_Motori";
            this.Grp_Motori.Size = new System.Drawing.Size(1698, 860);
            this.Grp_Motori.TabIndex = 0;
            this.Grp_Motori.TabStop = false;
            this.Grp_Motori.Text = "Motori";
            // 
            // Tab_Server
            // 
            this.Tab_Server.BaseColor = System.Drawing.Color.White;
            this.Tab_Server.Controls.Add(this.grp_Server);
            this.Tab_Server.Font = null;
            this.Tab_Server.ImageIndex = 0;
            this.Tab_Server.ImageKey = null;
            this.Tab_Server.IsDerivedStyle = true;
            this.Tab_Server.Location = new System.Drawing.Point(4, 42);
            this.Tab_Server.Name = "Tab_Server";
            this.Tab_Server.Size = new System.Drawing.Size(1698, 860);
            this.Tab_Server.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_Server.StyleManager = null;
            this.Tab_Server.TabIndex = 6;
            this.Tab_Server.Text = "Server";
            this.Tab_Server.ThemeAuthor = "Narwin";
            this.Tab_Server.ThemeName = "MetroLite";
            this.Tab_Server.ToolTipText = null;
            // 
            // grp_Server
            // 
            this.grp_Server.BackColor = System.Drawing.Color.White;
            this.grp_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_Server.Location = new System.Drawing.Point(3, 3);
            this.grp_Server.Name = "grp_Server";
            this.grp_Server.Size = new System.Drawing.Size(686, 186);
            this.grp_Server.TabIndex = 3;
            this.grp_Server.TabStop = false;
            this.grp_Server.Text = "Server";
            // 
            // Tab_Vertigo
            // 
            this.Tab_Vertigo.BaseColor = System.Drawing.Color.White;
            this.Tab_Vertigo.Controls.Add(this.grp_Vertigo);
            this.Tab_Vertigo.Font = null;
            this.Tab_Vertigo.ImageIndex = 0;
            this.Tab_Vertigo.ImageKey = null;
            this.Tab_Vertigo.IsDerivedStyle = true;
            this.Tab_Vertigo.Location = new System.Drawing.Point(4, 42);
            this.Tab_Vertigo.Name = "Tab_Vertigo";
            this.Tab_Vertigo.Size = new System.Drawing.Size(1698, 860);
            this.Tab_Vertigo.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_Vertigo.StyleManager = null;
            this.Tab_Vertigo.TabIndex = 7;
            this.Tab_Vertigo.Text = "Vertigo";
            this.Tab_Vertigo.ThemeAuthor = "Narwin";
            this.Tab_Vertigo.ThemeName = "MetroLite";
            this.Tab_Vertigo.ToolTipText = null;
            // 
            // grp_Vertigo
            // 
            this.grp_Vertigo.BackColor = System.Drawing.Color.White;
            this.grp_Vertigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_Vertigo.Location = new System.Drawing.Point(3, 3);
            this.grp_Vertigo.Name = "grp_Vertigo";
            this.grp_Vertigo.Size = new System.Drawing.Size(1058, 294);
            this.grp_Vertigo.TabIndex = 4;
            this.grp_Vertigo.TabStop = false;
            this.grp_Vertigo.Text = "Vertigo";
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
            this._metroSetControlBox1.Location = new System.Drawing.Point(1615, 18);
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
            // lblDateTime
            // 
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDateTime.IsDerivedStyle = true;
            this.lblDateTime.Location = new System.Drawing.Point(366, 18);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(187, 23);
            this.lblDateTime.Style = MetroSet_UI.Enums.Style.Light;
            this.lblDateTime.StyleManager = this.Stile;
            this.lblDateTime.TabIndex = 3;
            this.lblDateTime.ThemeAuthor = null;
            this.lblDateTime.ThemeName = null;
            // 
            // Tab_Telescopio
            // 
            this.Tab_Telescopio.BaseColor = System.Drawing.Color.White;
            this.Tab_Telescopio.Controls.Add(this.Grp_Telescopio);
            this.Tab_Telescopio.Controls.Add(this.Grp_Autoguida);
            this.Tab_Telescopio.Font = null;
            this.Tab_Telescopio.ImageIndex = 0;
            this.Tab_Telescopio.ImageKey = null;
            this.Tab_Telescopio.IsDerivedStyle = true;
            this.Tab_Telescopio.Location = new System.Drawing.Point(4, 42);
            this.Tab_Telescopio.Name = "Tab_Telescopio";
            this.Tab_Telescopio.Size = new System.Drawing.Size(1698, 860);
            this.Tab_Telescopio.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_Telescopio.StyleManager = null;
            this.Tab_Telescopio.TabIndex = 8;
            this.Tab_Telescopio.Text = "Telescopio";
            this.Tab_Telescopio.ThemeAuthor = "Narwin";
            this.Tab_Telescopio.ThemeName = "MetroLite";
            this.Tab_Telescopio.ToolTipText = null;
            // 
            // Grp_Autoguida
            // 
            this.Grp_Autoguida.BackColor = System.Drawing.Color.White;
            this.Grp_Autoguida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Autoguida.Location = new System.Drawing.Point(4, 4);
            this.Grp_Autoguida.Name = "Grp_Autoguida";
            this.Grp_Autoguida.Size = new System.Drawing.Size(602, 338);
            this.Grp_Autoguida.TabIndex = 0;
            this.Grp_Autoguida.TabStop = false;
            this.Grp_Autoguida.Text = "Autoguida";
            // 
            // Grp_Telescopio
            // 
            this.Grp_Telescopio.BackColor = System.Drawing.Color.White;
            this.Grp_Telescopio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Telescopio.Location = new System.Drawing.Point(613, 4);
            this.Grp_Telescopio.Name = "Grp_Telescopio";
            this.Grp_Telescopio.Size = new System.Drawing.Size(670, 338);
            this.Grp_Telescopio.TabIndex = 1;
            this.Grp_Telescopio.TabStop = false;
            this.Grp_Telescopio.Text = "Telescopio";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1730, 1008);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this._metroSetControlBox1);
            this.Controls.Add(this.SetTab_Control);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(12, 90, 12, 12);
            this.StyleManager = this.Stile;
            this.ThemeAuthor = null;
            this.ThemeName = null;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SetTab_Control.ResumeLayout(false);
            this.metroControllo.ResumeLayout(false);
            this.Tab_UPS.ResumeLayout(false);
            this.metroTetto.ResumeLayout(false);
            this.metroTetto.PerformLayout();
            this.Grp_Tetto.ResumeLayout(false);
            this.Tab_Parking.ResumeLayout(false);
            this.Tab_Motori.ResumeLayout(false);
            this.Tab_Server.ResumeLayout(false);
            this.Tab_Vertigo.ResumeLayout(false);
            this.Tab_Telescopio.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Components.StyleManager Stile;
        private MetroSet_UI.Controls.MetroSetTabControl SetTab_Control;
        private MetroSet_UI.Child.MetroSetSetTabPage metroControllo;
        private MetroSet_UI.Controls.MetroSetEllipse btnControlStatus;
        private MetroSet_UI.Controls.MetroSetLabel lbl_Connection;
        private MetroSet_UI.Controls.MetroSetSwitch swConnect;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_UPS;
        private MetroSet_UI.Child.MetroSetSetTabPage metroTetto;
        private MetroSet_UI.Controls.MetroSetControlBox _metroSetControlBox1;
        private System.Windows.Forms.GroupBox grpUPS;
        
        public static System.Windows.Forms.ToolTip PLC_Tooltip;

        //UPS
        public static UPS_Alarm UPS_EchoMode;
        public static UPS_Alarm UPS_BatteryLow;
        public static UPS_Alarm UPS_LDInverter;
        public static UPS_Alarm UPS_Alarm;
        public static UPS_Alarm UPS_ConnectionFailure;
        public static UPS_Alarm UPS_MainFailure;
        public static PLC_ProgressBar UPS_ChargeValue;
        //UPS
        
        //SERVER
        public static PLC_KeepAlive Server_KeepAlive;

        // DA CAMBIARE CON UNO SWITCH
        public static PLC_Label PLC_ApriFaldaSX;
        public static PLC_Label PLC_ApriFaldaDX;
        public static PLC_Label PLC_ChiudiFaldaSX;
        public static PLC_Label PLC_ChiudiFaldaDX;
        // FINE DA CAMBIARE CON UNO SWITCH

        //ROOF
        public static PLC_Label PLC_FineCorsaAperturaSX;
        public static PLC_Label PLC_FineCorsaChiusuraSX;
        public static PLC_Label PLC_FineCorsaAperturaDX;
        public static PLC_Label PLC_FineCorsaChiusuraDX;
        public static PLC_Label PLC_ChiudiTetto;
        public static PLC_Label PLC_ApriTetto;
        private static PLC_Label PLC_Cicalini;
        public static PLC_Label PLC_NoResetTermici;
        private static PLC_Toggle PLC_Reset_Termici;
        private static PLC_Toggle PLC_CicaliniMute;
        private static PLC_Toggle PLC_Reset_Counter_Termici;

        //VERTIGO
        private static PLC_Label PLC_VertigoTettoChiuso;
        private static PLC_Label PLC_VertigoTettoAperto;
        private static PLC_Label PLC_VertigoAllarmeTetto;
        private static PLC_Label PLC_VertigoChiudiTetto;
        private static PLC_Label PLC_VertigoApriTetto;

        //PARKING
        private static PLC_Label PLC_FineCorsa_AR_Parking;
        private static PLC_Label PLC_FineCorsa_DEC_Parking;

        //MOTORI
        private static PLC_Label PLC_DEC_Direction;
        private static PLC_Label PLC_AR_Direction;
        private static PLC_Label PLC_DEC_Error;
        private static PLC_Label PLC_AR_Error;
        private static PLC_Toggle PLC_DEC_Run;
        private static PLC_Toggle PLC_AR_Run;
        private static PLC_Toggle PLC_Decelerated_DEC_Stop;
        private static PLC_Toggle PLC_Decelerated_AR_Stop;
        private static PLC_Toggle PLC_Immediate_DEC_Stop;
        private static PLC_Toggle PLC_Immediate_AR_Stop;
        private static PLC_Toggle PLC_Emergency_Stop;

        //AUTOGUIDA
        private static PLC_Label PLC_Autoguide_Closed;
        private static PLC_Label PLC_Autoguide_Opened;
        private static PLC_Label PLC_Telescope_Closed;
        private static PLC_Label PLC_Telescope_Opened;


        private MetroSet_UI.Controls.MetroSetLabel lblDateTime;
        private MetroSet_UI.Controls.MetroSetLabel lbl_Osservatorio;
        private System.Windows.Forms.GroupBox Grp_Tetto;
        private System.Windows.Forms.GroupBox Grp_FaldaSX;
        private System.Windows.Forms.GroupBox Grp_faldaDX;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Parking;
        private System.Windows.Forms.GroupBox Grp_Parking;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Motori;
        private System.Windows.Forms.GroupBox Grp_Motori;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Server;
        private System.Windows.Forms.GroupBox grp_Server;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Vertigo;
        private System.Windows.Forms.GroupBox grp_Vertigo;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Telescopio;
        private System.Windows.Forms.GroupBox Grp_Telescopio;
        private System.Windows.Forms.GroupBox Grp_Autoguida;
    }
}

