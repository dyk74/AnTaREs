
namespace AnTaREs
{
    partial class Frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.Sm_Stile = new MetroSet_UI.Components.StyleManager();
            this.TabCtrl_Main = new MetroSet_UI.Controls.MetroSetTabControl();
            this.Tab_Connection = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Chk_Local = new MetroSet_UI.Controls.MetroSetCheckBox();
            this.Lbl_Observatory = new MetroSet_UI.Controls.MetroSetLabel();
            this.Btn_ControlStatus = new MetroSet_UI.Controls.MetroSetEllipse();
            this.Lbl_Connection = new MetroSet_UI.Controls.MetroSetLabel();
            this.Sw_Connect = new MetroSet_UI.Controls.MetroSetSwitch();
            this.Tab_UPS = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_UPS = new System.Windows.Forms.GroupBox();
            this.Tab_Roof = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_Roof = new System.Windows.Forms.GroupBox();
            this.Grp_Flap_Left = new System.Windows.Forms.GroupBox();
            this.Grp_Flap_Right = new System.Windows.Forms.GroupBox();
            this.Tab_Parking = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_Parking = new System.Windows.Forms.GroupBox();
            this.Tab_Motors = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_Motors = new System.Windows.Forms.GroupBox();
            this.Tab_Server = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_Server = new System.Windows.Forms.GroupBox();
            this.Tab_Vertigo = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_Vertigo = new System.Windows.Forms.GroupBox();
            this.Tab_Telescope = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_Telescope = new System.Windows.Forms.GroupBox();
            this.Grp_Autopilot = new System.Windows.Forms.GroupBox();
            this.Tab_Mux = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_Mux = new System.Windows.Forms.GroupBox();
            this.Tab_Telecom = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_Telecom = new System.Windows.Forms.GroupBox();
            this.Tab_Bypass = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.Grp_Security = new System.Windows.Forms.GroupBox();
            this.Grp_Bypass = new System.Windows.Forms.GroupBox();
            this._metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
            this.Lbl_DateTime = new MetroSet_UI.Controls.MetroSetLabel();
            this.TabCtrl_Main.SuspendLayout();
            this.Tab_Connection.SuspendLayout();
            this.Tab_UPS.SuspendLayout();
            this.Tab_Roof.SuspendLayout();
            this.Grp_Roof.SuspendLayout();
            this.Tab_Parking.SuspendLayout();
            this.Tab_Motors.SuspendLayout();
            this.Tab_Server.SuspendLayout();
            this.Tab_Vertigo.SuspendLayout();
            this.Tab_Telescope.SuspendLayout();
            this.Tab_Mux.SuspendLayout();
            this.Tab_Telecom.SuspendLayout();
            this.Tab_Bypass.SuspendLayout();
            this.SuspendLayout();
            // 
            // Stile
            // 
            this.Sm_Stile.CustomTheme = "C:\\Users\\bee\\AppData\\Roaming\\Microsoft\\Windows\\Templates\\ThemeFile.xml";
            this.Sm_Stile.MetroForm = this;
            this.Sm_Stile.Style = MetroSet_UI.Enums.Style.Light;
            this.Sm_Stile.ThemeAuthor = null;
            this.Sm_Stile.ThemeName = null;
            // 
            // TabCtrl_Main
            // 
            this.TabCtrl_Main.AnimateEasingType = MetroSet_UI.Enums.EasingType.CubeOut;
            this.TabCtrl_Main.AnimateTime = 200;
            this.TabCtrl_Main.BackgroundColor = System.Drawing.Color.White;
            this.TabCtrl_Main.Controls.Add(this.Tab_Connection);
            this.TabCtrl_Main.Controls.Add(this.Tab_UPS);
            this.TabCtrl_Main.Controls.Add(this.Tab_Roof);
            this.TabCtrl_Main.Controls.Add(this.Tab_Parking);
            this.TabCtrl_Main.Controls.Add(this.Tab_Motors);
            this.TabCtrl_Main.Controls.Add(this.Tab_Server);
            this.TabCtrl_Main.Controls.Add(this.Tab_Vertigo);
            this.TabCtrl_Main.Controls.Add(this.Tab_Telescope);
            this.TabCtrl_Main.Controls.Add(this.Tab_Mux);
            this.TabCtrl_Main.Controls.Add(this.Tab_Telecom);
            this.TabCtrl_Main.Controls.Add(this.Tab_Bypass);
            this.TabCtrl_Main.Cursor = System.Windows.Forms.Cursors.Default;
            this.TabCtrl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabCtrl_Main.IsDerivedStyle = true;
            this.TabCtrl_Main.ItemSize = new System.Drawing.Size(100, 38);
            this.TabCtrl_Main.Location = new System.Drawing.Point(12, 90);
            this.TabCtrl_Main.Name = "TabCtrl_Main";
            this.TabCtrl_Main.SelectedIndex = 0;
            this.TabCtrl_Main.SelectedTextColor = System.Drawing.Color.White;
            this.TabCtrl_Main.Size = new System.Drawing.Size(1706, 906);
            this.TabCtrl_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabCtrl_Main.Speed = 100;
            this.TabCtrl_Main.Style = MetroSet_UI.Enums.Style.Light;
            this.TabCtrl_Main.StyleManager = this.Sm_Stile;
            this.TabCtrl_Main.TabIndex = 0;
            this.TabCtrl_Main.ThemeAuthor = null;
            this.TabCtrl_Main.ThemeName = null;
            this.TabCtrl_Main.UnselectedTextColor = System.Drawing.Color.Gray;
            this.TabCtrl_Main.UseAnimation = false;
            // 
            // Tab_Connection
            // 
            this.Tab_Connection.BaseColor = System.Drawing.Color.White;
            this.Tab_Connection.Controls.Add(this.Chk_Local);
            this.Tab_Connection.Controls.Add(this.Lbl_Observatory);
            this.Tab_Connection.Controls.Add(this.Btn_ControlStatus);
            this.Tab_Connection.Controls.Add(this.Lbl_Connection);
            this.Tab_Connection.Controls.Add(this.Sw_Connect);
            this.Tab_Connection.Font = null;
            this.Tab_Connection.ImageIndex = 0;
            this.Tab_Connection.ImageKey = null;
            this.Tab_Connection.IsDerivedStyle = true;
            this.Tab_Connection.Location = new System.Drawing.Point(4, 42);
            this.Tab_Connection.Name = "Tab_Connection";
            this.Tab_Connection.Size = new System.Drawing.Size(1698, 860);
            this.Tab_Connection.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_Connection.StyleManager = this.Sm_Stile;
            this.Tab_Connection.TabIndex = 0;
            this.Tab_Connection.Text = "Connessione";
            this.Tab_Connection.ThemeAuthor = "Narwin";
            this.Tab_Connection.ThemeName = "MetroLite";
            this.Tab_Connection.ToolTipText = null;
            // 
            // Chk_Local
            // 
            this.Chk_Local.BackColor = System.Drawing.Color.Transparent;
            this.Chk_Local.BackgroundColor = System.Drawing.Color.White;
            this.Chk_Local.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.Chk_Local.Checked = false;
            this.Chk_Local.CheckSignColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Chk_Local.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.Chk_Local.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Chk_Local.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.Chk_Local.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Chk_Local.IsDerivedStyle = true;
            this.Chk_Local.Location = new System.Drawing.Point(669, 40);
            this.Chk_Local.Name = "Chk_Local";
            this.Chk_Local.SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
            this.Chk_Local.Size = new System.Drawing.Size(146, 16);
            this.Chk_Local.Style = MetroSet_UI.Enums.Style.Light;
            this.Chk_Local.StyleManager = null;
            this.Chk_Local.TabIndex = 4;
            this.Chk_Local.Text = "Connessione Locale";
            this.Chk_Local.ThemeAuthor = "Narwin";
            this.Chk_Local.ThemeName = "MetroLite";
            // 
            // lbl_Osservatorio
            // 
            this.Lbl_Observatory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Observatory.IsDerivedStyle = true;
            this.Lbl_Observatory.Location = new System.Drawing.Point(242, 40);
            this.Lbl_Observatory.Name = "lbl_Osservatorio";
            this.Lbl_Observatory.Size = new System.Drawing.Size(162, 23);
            this.Lbl_Observatory.Style = MetroSet_UI.Enums.Style.Light;
            this.Lbl_Observatory.StyleManager = this.Sm_Stile;
            this.Lbl_Observatory.TabIndex = 3;
            this.Lbl_Observatory.Text = "-";
            this.Lbl_Observatory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lbl_Observatory.ThemeAuthor = null;
            this.Lbl_Observatory.ThemeName = null;
            // 
            // Btn_ControlStatus
            // 
            this.Btn_ControlStatus.BorderThickness = 7;
            this.Btn_ControlStatus.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Btn_ControlStatus.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.Btn_ControlStatus.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.Btn_ControlStatus.Enabled = false;
            this.Btn_ControlStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Btn_ControlStatus.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Btn_ControlStatus.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Btn_ControlStatus.HoverTextColor = System.Drawing.Color.White;
            this.Btn_ControlStatus.Image = null;
            this.Btn_ControlStatus.ImageSize = new System.Drawing.Size(32, 32);
            this.Btn_ControlStatus.IsDerivedStyle = true;
            this.Btn_ControlStatus.Location = new System.Drawing.Point(565, 3);
            this.Btn_ControlStatus.Name = "Btn_ControlStatus";
            this.Btn_ControlStatus.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Btn_ControlStatus.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.Btn_ControlStatus.NormalTextColor = System.Drawing.Color.Black;
            this.Btn_ControlStatus.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Btn_ControlStatus.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Btn_ControlStatus.PressTextColor = System.Drawing.Color.White;
            this.Btn_ControlStatus.Size = new System.Drawing.Size(80, 80);
            this.Btn_ControlStatus.Style = MetroSet_UI.Enums.Style.Light;
            this.Btn_ControlStatus.StyleManager = this.Sm_Stile;
            this.Btn_ControlStatus.TabIndex = 2;
            this.Btn_ControlStatus.ThemeAuthor = null;
            this.Btn_ControlStatus.ThemeName = null;
            // 
            // Lbl_Connection
            // 
            this.Lbl_Connection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lbl_Connection.IsDerivedStyle = true;
            this.Lbl_Connection.Location = new System.Drawing.Point(50, 40);
            this.Lbl_Connection.Name = "Lbl_Connection";
            this.Lbl_Connection.Size = new System.Drawing.Size(185, 23);
            this.Lbl_Connection.Style = MetroSet_UI.Enums.Style.Light;
            this.Lbl_Connection.StyleManager = this.Sm_Stile;
            this.Lbl_Connection.TabIndex = 1;
            this.Lbl_Connection.Text = "Connessione Osservatorio";
            this.Lbl_Connection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lbl_Connection.ThemeAuthor = null;
            this.Lbl_Connection.ThemeName = null;
            // 
            // Sw_Connect
            // 
            this.Sw_Connect.BackColor = System.Drawing.Color.Transparent;
            this.Sw_Connect.BackgroundColor = System.Drawing.Color.Empty;
            this.Sw_Connect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(147)))));
            this.Sw_Connect.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Sw_Connect.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.Sw_Connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Sw_Connect.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.Sw_Connect.DisabledCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Sw_Connect.DisabledUnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.Sw_Connect.IsDerivedStyle = true;
            this.Sw_Connect.Location = new System.Drawing.Point(430, 40);
            this.Sw_Connect.Name = "Sw_Connect";
            this.Sw_Connect.Size = new System.Drawing.Size(58, 22);
            this.Sw_Connect.Style = MetroSet_UI.Enums.Style.Light;
            this.Sw_Connect.StyleManager = this.Sm_Stile;
            this.Sw_Connect.Switched = false;
            this.Sw_Connect.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.Sw_Connect.TabIndex = 0;
            this.Sw_Connect.ThemeAuthor = null;
            this.Sw_Connect.ThemeName = null;
            this.Sw_Connect.UnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.Sw_Connect.SwitchedChanged += new MetroSet_UI.Controls.MetroSetSwitch.SwitchedChangedEventHandler(this.SwConnect_SwitchedChanged);
            // 
            // Tab_UPS
            // 
            this.Tab_UPS.BaseColor = System.Drawing.Color.White;
            this.Tab_UPS.Controls.Add(this.Grp_UPS);
            this.Tab_UPS.Font = null;
            this.Tab_UPS.ImageIndex = 0;
            this.Tab_UPS.ImageKey = null;
            this.Tab_UPS.IsDerivedStyle = true;
            this.Tab_UPS.Location = new System.Drawing.Point(4, 42);
            this.Tab_UPS.Name = "Tab_UPS";
            this.Tab_UPS.Size = new System.Drawing.Size(1698, 860);
            this.Tab_UPS.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_UPS.StyleManager = this.Sm_Stile;
            this.Tab_UPS.TabIndex = 2;
            this.Tab_UPS.Text = "UPS";
            this.Tab_UPS.ThemeAuthor = "Narwin";
            this.Tab_UPS.ThemeName = "MetroLite";
            this.Tab_UPS.ToolTipText = null;
            // 
            // grpUPS
            // 
            this.Grp_UPS.BackColor = System.Drawing.SystemColors.Window;
            this.Grp_UPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_UPS.Location = new System.Drawing.Point(10, 0);
            this.Grp_UPS.Name = "Grp_UPS";
            this.Grp_UPS.Size = new System.Drawing.Size(686, 340);
            this.Grp_UPS.TabIndex = 0;
            this.Grp_UPS.TabStop = false;
            this.Grp_UPS.Text = "UPS";
            // 
            // Tab_Roof
            // 
            this.Tab_Roof.BaseColor = System.Drawing.Color.White;
            this.Tab_Roof.Controls.Add(this.Grp_Roof);
            this.Tab_Roof.Font = null;
            this.Tab_Roof.ImageIndex = 0;
            this.Tab_Roof.ImageKey = null;
            this.Tab_Roof.IsDerivedStyle = true;
            this.Tab_Roof.Location = new System.Drawing.Point(4, 42);
            this.Tab_Roof.Name = "Tab_Roof";
            this.Tab_Roof.Size = new System.Drawing.Size(1698, 860);
            this.Tab_Roof.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_Roof.StyleManager = this.Sm_Stile;
            this.Tab_Roof.TabIndex = 3;
            this.Tab_Roof.Text = "Tetto";
            this.Tab_Roof.ThemeAuthor = "Narwin";
            this.Tab_Roof.ThemeName = "MetroLite";
            this.Tab_Roof.ToolTipText = null;
            // 
            // Grp_Tetto
            // 
            this.Grp_Roof.AutoSize = true;
            this.Grp_Roof.BackColor = System.Drawing.SystemColors.Window;
            this.Grp_Roof.Controls.Add(this.Grp_Flap_Left);
            this.Grp_Roof.Controls.Add(this.Grp_Flap_Right);
            this.Grp_Roof.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Roof.Location = new System.Drawing.Point(3, 3);
            this.Grp_Roof.Name = "Grp_Roof";
            this.Grp_Roof.Size = new System.Drawing.Size(1698, 873);
            this.Grp_Roof.TabIndex = 2;
            this.Grp_Roof.TabStop = false;
            this.Grp_Roof.Text = "Tetto";
            // 
            // Grp_FaldaSX
            // 
            this.Grp_Flap_Left.Location = new System.Drawing.Point(6, 554);
            this.Grp_Flap_Left.Name = "Grp_Flap_Left";
            this.Grp_Flap_Left.Size = new System.Drawing.Size(800, 300);
            this.Grp_Flap_Left.TabIndex = 1;
            this.Grp_Flap_Left.TabStop = false;
            this.Grp_Flap_Left.Text = "Falda sinistra";
            // 
            // Grp_faldaDX
            // 
            this.Grp_Flap_Right.Location = new System.Drawing.Point(892, 554);
            this.Grp_Flap_Right.Name = "Grp_Flap_Right";
            this.Grp_Flap_Right.Size = new System.Drawing.Size(800, 300);
            this.Grp_Flap_Right.TabIndex = 0;
            this.Grp_Flap_Right.TabStop = false;
            this.Grp_Flap_Right.Text = "Falda destra";
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
            this.Grp_Parking.Text = "Parcheggio";
            // 
            // Tab_Motors
            // 
            this.Tab_Motors.BaseColor = System.Drawing.Color.White;
            this.Tab_Motors.Controls.Add(this.Grp_Motors);
            this.Tab_Motors.Font = null;
            this.Tab_Motors.ImageIndex = 0;
            this.Tab_Motors.ImageKey = null;
            this.Tab_Motors.IsDerivedStyle = true;
            this.Tab_Motors.Location = new System.Drawing.Point(4, 42);
            this.Tab_Motors.Name = "Tab_Motors";
            this.Tab_Motors.Size = new System.Drawing.Size(1698, 860);
            this.Tab_Motors.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_Motors.StyleManager = null;
            this.Tab_Motors.TabIndex = 5;
            this.Tab_Motors.Text = "Motori";
            this.Tab_Motors.ThemeAuthor = "Narwin";
            this.Tab_Motors.ThemeName = "MetroLite";
            this.Tab_Motors.ToolTipText = null;
            // 
            // Grp_Motori
            // 
            this.Grp_Motors.BackColor = System.Drawing.Color.White;
            this.Grp_Motors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grp_Motors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Motors.Location = new System.Drawing.Point(0, 0);
            this.Grp_Motors.Name = "Grp_Motors";
            this.Grp_Motors.Size = new System.Drawing.Size(1698, 860);
            this.Grp_Motors.TabIndex = 0;
            this.Grp_Motors.TabStop = false;
            this.Grp_Motors.Text = "Motori";
            // 
            // Tab_Server
            // 
            this.Tab_Server.BaseColor = System.Drawing.Color.White;
            this.Tab_Server.Controls.Add(this.Grp_Server);
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
            this.Grp_Server.BackColor = System.Drawing.Color.White;
            this.Grp_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Server.Location = new System.Drawing.Point(3, 3);
            this.Grp_Server.Name = "grp_Server";
            this.Grp_Server.Size = new System.Drawing.Size(686, 186);
            this.Grp_Server.TabIndex = 3;
            this.Grp_Server.TabStop = false;
            this.Grp_Server.Text = "Server";
            // 
            // Tab_Vertigo
            // 
            this.Tab_Vertigo.BaseColor = System.Drawing.Color.White;
            this.Tab_Vertigo.Controls.Add(this.Grp_Vertigo);
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
            this.Grp_Vertigo.BackColor = System.Drawing.Color.White;
            this.Grp_Vertigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Vertigo.Location = new System.Drawing.Point(3, 3);
            this.Grp_Vertigo.Name = "Grp_Vertigo";
            this.Grp_Vertigo.Size = new System.Drawing.Size(1058, 294);
            this.Grp_Vertigo.TabIndex = 4;
            this.Grp_Vertigo.TabStop = false;
            this.Grp_Vertigo.Text = "Vertigo";
            // 
            // Tab_Telescope
            // 
            this.Tab_Telescope.BaseColor = System.Drawing.Color.White;
            this.Tab_Telescope.Controls.Add(this.Grp_Telescope);
            this.Tab_Telescope.Controls.Add(this.Grp_Autopilot);
            this.Tab_Telescope.Font = null;
            this.Tab_Telescope.ImageIndex = 0;
            this.Tab_Telescope.ImageKey = null;
            this.Tab_Telescope.IsDerivedStyle = true;
            this.Tab_Telescope.Location = new System.Drawing.Point(4, 42);
            this.Tab_Telescope.Name = "Tab_Telescope";
            this.Tab_Telescope.Size = new System.Drawing.Size(1698, 860);
            this.Tab_Telescope.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_Telescope.StyleManager = null;
            this.Tab_Telescope.TabIndex = 8;
            this.Tab_Telescope.Text = "Telescopio";
            this.Tab_Telescope.ThemeAuthor = "Narwin";
            this.Tab_Telescope.ThemeName = "MetroLite";
            this.Tab_Telescope.ToolTipText = null;
            // 
            // Grp_Telescopio
            // 
            this.Grp_Telescope.BackColor = System.Drawing.Color.White;
            this.Grp_Telescope.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Telescope.Location = new System.Drawing.Point(895, 4);
            this.Grp_Telescope.Name = "Grp_Telescope";
            this.Grp_Telescope.Size = new System.Drawing.Size(800, 400);
            this.Grp_Telescope.TabIndex = 1;
            this.Grp_Telescope.TabStop = false;
            this.Grp_Telescope.Text = "Telescopio";
            // 
            // Grp_Autoguida
            // 
            this.Grp_Autopilot.BackColor = System.Drawing.Color.White;
            this.Grp_Autopilot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Autopilot.Location = new System.Drawing.Point(4, 4);
            this.Grp_Autopilot.Name = "Grp_Autopilot";
            this.Grp_Autopilot.Size = new System.Drawing.Size(800, 400);
            this.Grp_Autopilot.TabIndex = 0;
            this.Grp_Autopilot.TabStop = false;
            this.Grp_Autopilot.Text = "Autoguida";
            // 
            // Tab_Mux
            // 
            this.Tab_Mux.BaseColor = System.Drawing.Color.White;
            this.Tab_Mux.Controls.Add(this.Grp_Mux);
            this.Tab_Mux.Font = null;
            this.Tab_Mux.ImageIndex = 0;
            this.Tab_Mux.ImageKey = null;
            this.Tab_Mux.IsDerivedStyle = true;
            this.Tab_Mux.Location = new System.Drawing.Point(4, 42);
            this.Tab_Mux.Name = "Tab_Mux";
            this.Tab_Mux.Size = new System.Drawing.Size(1698, 860);
            this.Tab_Mux.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_Mux.StyleManager = null;
            this.Tab_Mux.TabIndex = 10;
            this.Tab_Mux.Text = "Multiplexer";
            this.Tab_Mux.ThemeAuthor = "Narwin";
            this.Tab_Mux.ThemeName = "MetroLite";
            this.Tab_Mux.ToolTipText = null;
            // 
            // Grp_Mux
            // 
            this.Grp_Mux.BackColor = System.Drawing.Color.White;
            this.Grp_Mux.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Mux.Location = new System.Drawing.Point(4, 4);
            this.Grp_Mux.Name = "Grp_Mux";
            this.Grp_Mux.Size = new System.Drawing.Size(995, 352);
            this.Grp_Mux.TabIndex = 0;
            this.Grp_Mux.TabStop = false;
            this.Grp_Mux.Text = "Multiplexer";
            // 
            // Tab_Telecom
            // 
            this.Tab_Telecom.BaseColor = System.Drawing.Color.White;
            this.Tab_Telecom.Controls.Add(this.Grp_Telecom);
            this.Tab_Telecom.Font = null;
            this.Tab_Telecom.ImageIndex = 0;
            this.Tab_Telecom.ImageKey = null;
            this.Tab_Telecom.IsDerivedStyle = true;
            this.Tab_Telecom.Location = new System.Drawing.Point(4, 42);
            this.Tab_Telecom.Name = "Tab_Telecom";
            this.Tab_Telecom.Size = new System.Drawing.Size(1698, 860);
            this.Tab_Telecom.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_Telecom.StyleManager = null;
            this.Tab_Telecom.TabIndex = 11;
            this.Tab_Telecom.Text = "Comunicazioni";
            this.Tab_Telecom.ThemeAuthor = "Narwin";
            this.Tab_Telecom.ThemeName = "MetroLite";
            this.Tab_Telecom.ToolTipText = null;
            // 
            // Grp_Telecom
            // 
            this.Grp_Telecom.BackColor = System.Drawing.Color.White;
            this.Grp_Telecom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Telecom.Location = new System.Drawing.Point(4, 4);
            this.Grp_Telecom.Name = "Grp_Telecom";
            this.Grp_Telecom.Size = new System.Drawing.Size(843, 420);
            this.Grp_Telecom.TabIndex = 0;
            this.Grp_Telecom.TabStop = false;
            this.Grp_Telecom.Text = "Comunicazioni";
            // 
            // Tab_Bypass
            // 
            this.Tab_Bypass.BaseColor = System.Drawing.Color.White;
            this.Tab_Bypass.Controls.Add(this.Grp_Security);
            this.Tab_Bypass.Controls.Add(this.Grp_Bypass);
            this.Tab_Bypass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab_Bypass.ImageIndex = 0;
            this.Tab_Bypass.ImageKey = null;
            this.Tab_Bypass.IsDerivedStyle = true;
            this.Tab_Bypass.Location = new System.Drawing.Point(4, 42);
            this.Tab_Bypass.Name = "Tab_Bypass";
            this.Tab_Bypass.Size = new System.Drawing.Size(1698, 860);
            this.Tab_Bypass.Style = MetroSet_UI.Enums.Style.Light;
            this.Tab_Bypass.StyleManager = null;
            this.Tab_Bypass.TabIndex = 9;
            this.Tab_Bypass.Text = "Bypass";
            this.Tab_Bypass.ThemeAuthor = "Narwin";
            this.Tab_Bypass.ThemeName = "MetroLite";
            this.Tab_Bypass.ToolTipText = null;
            // 
            // Grp_Security
            // 
            this.Grp_Security.BackColor = System.Drawing.Color.White;
            this.Grp_Security.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Security.Location = new System.Drawing.Point(895, 3);
            this.Grp_Security.Name = "Grp_Security";
            this.Grp_Security.Size = new System.Drawing.Size(800, 400);
            this.Grp_Security.TabIndex = 4;
            this.Grp_Security.TabStop = false;
            this.Grp_Security.Text = "Security";
            // 
            // Grp_Bypass
            // 
            this.Grp_Bypass.BackColor = System.Drawing.Color.White;
            this.Grp_Bypass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Bypass.Location = new System.Drawing.Point(3, 3);
            this.Grp_Bypass.Name = "Grp_Bypass";
            this.Grp_Bypass.Size = new System.Drawing.Size(800, 400);
            this.Grp_Bypass.TabIndex = 3;
            this.Grp_Bypass.TabStop = false;
            this.Grp_Bypass.Text = "Bypass";
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
            this._metroSetControlBox1.StyleManager = this.Sm_Stile;
            this._metroSetControlBox1.TabIndex = 2;
            this._metroSetControlBox1.Text = "_metroSetControlBox1";
            this._metroSetControlBox1.ThemeAuthor = null;
            this._metroSetControlBox1.ThemeName = null;
            // 
            // lblDateTime
            // 
            this.Lbl_DateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lbl_DateTime.IsDerivedStyle = true;
            this.Lbl_DateTime.Location = new System.Drawing.Point(366, 18);
            this.Lbl_DateTime.Name = "Lbl_DateTime";
            this.Lbl_DateTime.Size = new System.Drawing.Size(187, 23);
            this.Lbl_DateTime.Style = MetroSet_UI.Enums.Style.Light;
            this.Lbl_DateTime.StyleManager = this.Sm_Stile;
            this.Lbl_DateTime.TabIndex = 3;
            this.Lbl_DateTime.ThemeAuthor = null;
            this.Lbl_DateTime.ThemeName = null;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1730, 1008);
            this.Controls.Add(this.Lbl_DateTime);
            this.Controls.Add(this._metroSetControlBox1);
            this.Controls.Add(this.TabCtrl_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Main";
            this.Padding = new System.Windows.Forms.Padding(12, 90, 12, 12);
            this.StyleManager = this.Sm_Stile;
            this.ThemeAuthor = null;
            this.ThemeName = null;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.TabCtrl_Main.ResumeLayout(false);
            this.Tab_Connection.ResumeLayout(false);
            this.Tab_UPS.ResumeLayout(false);
            this.Tab_Roof.ResumeLayout(false);
            this.Tab_Roof.PerformLayout();
            this.Grp_Roof.ResumeLayout(false);
            this.Tab_Parking.ResumeLayout(false);
            this.Tab_Motors.ResumeLayout(false);
            this.Tab_Server.ResumeLayout(false);
            this.Tab_Vertigo.ResumeLayout(false);
            this.Tab_Telescope.ResumeLayout(false);
            this.Tab_Mux.ResumeLayout(false);
            this.Tab_Telecom.ResumeLayout(false);
            this.Tab_Bypass.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private MetroSet_UI.Components.StyleManager Sm_Stile;
        private MetroSet_UI.Controls.MetroSetCheckBox Chk_Local;
        private MetroSet_UI.Controls.MetroSetTabControl TabCtrl_Main;
        private MetroSet_UI.Controls.MetroSetSwitch Sw_Connect;
        private MetroSet_UI.Controls.MetroSetEllipse Btn_ControlStatus;
        private MetroSet_UI.Controls.MetroSetControlBox _metroSetControlBox1;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Connection;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Parking;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_UPS;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Roof;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Motors;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Server;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Vertigo;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Telescope;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Bypass;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Mux;
        private MetroSet_UI.Child.MetroSetSetTabPage Tab_Telecom;
        private MetroSet_UI.Controls.MetroSetLabel Lbl_Connection;
        private MetroSet_UI.Controls.MetroSetLabel Lbl_DateTime;
        private MetroSet_UI.Controls.MetroSetLabel Lbl_Observatory;
        private System.Windows.Forms.GroupBox Grp_Roof;
        private System.Windows.Forms.GroupBox Grp_Flap_Left;
        private System.Windows.Forms.GroupBox Grp_Flap_Right;
        private System.Windows.Forms.GroupBox Grp_UPS;
        private System.Windows.Forms.GroupBox Grp_Parking;
        private System.Windows.Forms.GroupBox Grp_Motors;
        private System.Windows.Forms.GroupBox Grp_Server;
        private System.Windows.Forms.GroupBox Grp_Vertigo;
        private System.Windows.Forms.GroupBox Grp_Telescope;
        private System.Windows.Forms.GroupBox Grp_Autopilot;
        private System.Windows.Forms.GroupBox Grp_Bypass;
        private System.Windows.Forms.GroupBox Grp_Mux;
        private System.Windows.Forms.GroupBox Grp_Telecom;
        private System.Windows.Forms.GroupBox Grp_Security;

        //UPS
        private static PLC_Alarm PLC_Alarm_UPS_EchoMode;
        private static PLC_Alarm PLC_Alarm_UPS_BatteryLow;
        private static PLC_Alarm PLC_Alarm_UPS_LDInverter;
        private static PLC_Alarm PLC_Alarm_UPS_Alarm;
        private static PLC_Alarm PLC_Alarm_UPS_ConnectionFailure;
        private static PLC_Alarm PLC_Alarm_UPS_MainFailure;
        private static PLC_ProgressBar PLC_ProgressBar_UPS_ChargeValue;
        private static PLC_Toggle PLC_Toggle_PLC_UPS_Alarm_Bypass;
        
        //SERVER
        public static PLC_KeepAlive Server_KeepAlive;

        // DA CAMBIARE CON UNO SWITCH
        public static PLC_Label PLC_ApriFaldaSX;
        public static PLC_Label PLC_ApriFaldaDX;
        public static PLC_Label PLC_ChiudiFaldaSX;
        public static PLC_Label PLC_ChiudiFaldaDX;
        // FINE DA CAMBIARE CON UNO SWITCH

        //TETTO SX
        private static PLC_Label PLC_FineCorsaAperturaSX;
        private static PLC_Label PLC_FineCorsaChiusuraSX;
        private static PLC_Button PLC_Button_Stop_SX;
        private static PLC_Button PLC_Button_Close_SX;
        private static PLC_Button PLC_Button_Open_SX;
        

        //TETTO DX
        private static PLC_Label PLC_FineCorsaAperturaDX;
        private static PLC_Label PLC_FineCorsaChiusuraDX;
        private static PLC_Button PLC_Button_Stop_DX;
        private static PLC_Button PLC_Button_Close_DX;
        private static PLC_Button PLC_Button_Open_DX;

        //TETTO
        private static PLC_Label PLC_ChiudiTetto;
        private static PLC_Label PLC_ApriTetto;
        private static PLC_Label PLC_Cicalini;
        private static PLC_Label PLC_NoResetTermici;
        private static PLC_Toggle PLC_Reset_Termici;
        private static PLC_Toggle PLC_CicaliniMute;
        private static PLC_Toggle PLC_Reset_Counter_Termici;
        private static PLC_Alarm PLC_Tetto_Chiusura_Timeout;
        private static PLC_Alarm PLC_Tetto_Apertura_Timeout;
        private static PLC_Alarm PLC_Tetto_Termico;
        private static PLC_Button PLC_Button_Ascom_Abort;
        private static PLC_Button PLC_Button_Reset_Termici;
        private static PLC_Roof PLC_Roof_Tetto;

        //VERTIGO
        private static PLC_Label PLC_VertigoTettoChiuso;
        private static PLC_Label PLC_VertigoTettoAperto;
        private static PLC_Label PLC_VertigoAllarmeTetto;
        private static PLC_Label PLC_VertigoChiudiTetto;
        private static PLC_Label PLC_VertigoApriTetto;
        private static PLC_Toggle PLC_Vertigo_RoofOpen_Bypass;
        private static PLC_Toggle PLC_Toggle_Vertigo_KeepAlive_Bypass;
        private static PLC_Alarm PLC_Alarm_Vertigo_KeepAlive;

        //PARKING
        private static PLC_Label PLC_FineCorsa_AR_Parking;
        private static PLC_Label PLC_FineCorsa_DEC_Parking;
        private static PLC_Button PLC_Button_Park_Scope;
        private static PLC_Label PLC_Label_Optical_Sensor;

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
        private static PLC_FastButton PLC_FastButton_DEC_Down;
        private static PLC_FastButton PLC_FastButton_DEC_UP;
        private static PLC_FastButton PLC_FastButton_AR_DX;
        private static PLC_FastButton PLC_FastButton_AR_SX;
        private static PLC_Gauge PLC_Gauge_DEC;
        private static PLC_Gauge PLC_Gauge_AR;

        //AUTOGUIDA
        private static PLC_Label PLC_Autoguide_Closed;
        private static PLC_Label PLC_Autoguide_Opened;
        private static PLC_Toggle PLC_Autoguide_Control;
        private static PLC_Button PLC_Button_Close_Autoguide;
        private static PLC_Button PLC_Button_Open_Autoguide;

        //TELESCOPIO
        private static PLC_Label PLC_Telescope_Closed;
        private static PLC_Label PLC_Telescope_Opened;
        private static PLC_Toggle PLC_Telescope_Cap_Bypass;
        private static PLC_Toggle PLC_Telescope_FC_Bypass;
        private static PLC_Toggle PLC_Telescope_Hook;
        private static PLC_Toggle PLC_Telescope_Control;
        private static PLC_Toggle PLC_Telescope_Power;
        private static PLC_Button PLC_Button_Close_Telescope;
        private static PLC_Button PLC_Button_Open_Telescope;

        //METEO
        private static PLC_Toggle PLC_Meteo_Bypass;

        //MUX
        private static PLC_Button PLC_Button_MUX_PLC;
        private static PLC_Button PLC_Button_MUX_Vertigo;

        //TELECOM
        private static PLC_Button PLC_Button_Telecom_ON;

        //SECURITY
        private static PLC_Toggle PLC_Telescope_Emergency_mode;
        private static PLC_Button PLC_Button_Security_Reset;
        private static PLC_SecurityChain PLC_SecurityChain_Quadro;
        private static PLC_SecurityChain PLC_SecurityChain_Enabled;
        private static PLC_SecurityChain PLC_SecurityChain_Timeout_Closing;
        private static PLC_SecurityChain PLC_SecurityChain_Timeout_Opening;
        private static PLC_SecurityChain PLC_SecurityChain_Allarme_Termici;
        private static PLC_SecurityChain PLC_SecurityChain_Allarme_Fusibili;
        private static PLC_SecurityChain PLC_SecurityChain_Allarme_Fusibili_PLC;
        private static PLC_SecurityChain PLC_SecurityChain_Allarme_Meteo;
        private static PLC_SecurityChain PLC_SecurityChain_Vertigo;
        private static PLC_SecurityChain PLC_SecurityChain_Primary_Power;
        private static PLC_SecurityChain PLC_SecurityChain_Secondary_Power;
        private static PLC_SecurityChain PLC_SecurityChain_Reinsert;
        private static PLC_SecurityChain PLC_SecurityChain_UPS_Failure;


    }
}

