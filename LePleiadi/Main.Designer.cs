
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
            this.TabConnection = new MetroSet_UI.Controls.MetroSetTabControl();
            this.metroControllo = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.lbl_Osservatorio = new MetroSet_UI.Controls.MetroSetLabel();
            this.btnControlStatus = new MetroSet_UI.Controls.MetroSetEllipse();
            this.lbl_Connection = new MetroSet_UI.Controls.MetroSetLabel();
            this.swConnect = new MetroSet_UI.Controls.MetroSetSwitch();
            this.metroPLC = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.grpConnectivity = new System.Windows.Forms.GroupBox();
            this.grpSecurityChain = new System.Windows.Forms.GroupBox();
            this.grpTooglePLC = new System.Windows.Forms.GroupBox();
            this.grpToogle = new System.Windows.Forms.GroupBox();
            this.grpCPU = new System.Windows.Forms.GroupBox();
            this.grpPLC = new System.Windows.Forms.GroupBox();
            this.grpFastChange = new System.Windows.Forms.GroupBox();
            this.metroAllarmi = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.grp_Server = new System.Windows.Forms.GroupBox();
            this.grpTetto = new System.Windows.Forms.GroupBox();
            this.grp_FaldaSX = new System.Windows.Forms.GroupBox();
            this.grp_faldaDX = new System.Windows.Forms.GroupBox();
            this.grpUPS = new System.Windows.Forms.GroupBox();
            this.metroTetto = new MetroSet_UI.Child.MetroSetSetTabPage();
            this._metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
            this.lblDateTime = new MetroSet_UI.Controls.MetroSetLabel();
            this.TabConnection.SuspendLayout();
            this.metroControllo.SuspendLayout();
            this.metroPLC.SuspendLayout();
            this.metroAllarmi.SuspendLayout();
            this.grpTetto.SuspendLayout();
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
            this.TabConnection.Controls.Add(this.metroAllarmi);
            this.TabConnection.Controls.Add(this.metroTetto);
            this.TabConnection.Cursor = System.Windows.Forms.Cursors.Default;
            this.TabConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabConnection.IsDerivedStyle = true;
            this.TabConnection.ItemSize = new System.Drawing.Size(100, 38);
            this.TabConnection.Location = new System.Drawing.Point(12, 90);
            this.TabConnection.Name = "TabConnection";
            this.TabConnection.SelectedIndex = 2;
            this.TabConnection.SelectedTextColor = System.Drawing.Color.White;
            this.TabConnection.Size = new System.Drawing.Size(1706, 581);
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
            this.metroControllo.Size = new System.Drawing.Size(1698, 535);
            this.metroControllo.Style = MetroSet_UI.Enums.Style.Light;
            this.metroControllo.StyleManager = null;
            this.metroControllo.TabIndex = 0;
            this.metroControllo.Text = "Controllo";
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
            this.lbl_Osservatorio.StyleManager = null;
            this.lbl_Osservatorio.TabIndex = 3;
            this.lbl_Osservatorio.Text = "-";
            this.lbl_Osservatorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Osservatorio.ThemeAuthor = "Narwin";
            this.lbl_Osservatorio.ThemeName = "MetroLite";
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
            this.btnControlStatus.StyleManager = null;
            this.btnControlStatus.TabIndex = 2;
            this.btnControlStatus.ThemeAuthor = "Narwin";
            this.btnControlStatus.ThemeName = "MetroLite";
            // 
            // lbl_Connection
            // 
            this.lbl_Connection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_Connection.IsDerivedStyle = true;
            this.lbl_Connection.Location = new System.Drawing.Point(50, 40);
            this.lbl_Connection.Name = "lbl_Connection";
            this.lbl_Connection.Size = new System.Drawing.Size(185, 23);
            this.lbl_Connection.Style = MetroSet_UI.Enums.Style.Light;
            this.lbl_Connection.StyleManager = null;
            this.lbl_Connection.TabIndex = 1;
            this.lbl_Connection.Text = "Connessione Osservatorio";
            this.lbl_Connection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Connection.ThemeAuthor = "Narwin";
            this.lbl_Connection.ThemeName = "MetroLite";
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
            this.swConnect.ThemeAuthor = "Narwin";
            this.swConnect.ThemeName = "MetroLite";
            this.swConnect.UnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.swConnect.SwitchedChanged += new MetroSet_UI.Controls.MetroSetSwitch.SwitchedChangedEventHandler(this.SwConnect_SwitchedChanged);
            // 
            // metroPLC
            // 
            this.metroPLC.BaseColor = System.Drawing.Color.White;
            this.metroPLC.Controls.Add(this.grpConnectivity);
            this.metroPLC.Controls.Add(this.grpSecurityChain);
            this.metroPLC.Controls.Add(this.grpTooglePLC);
            this.metroPLC.Controls.Add(this.grpToogle);
            this.metroPLC.Controls.Add(this.grpCPU);
            this.metroPLC.Controls.Add(this.grpPLC);
            this.metroPLC.Controls.Add(this.grpFastChange);
            this.metroPLC.Font = null;
            this.metroPLC.ImageIndex = 0;
            this.metroPLC.ImageKey = null;
            this.metroPLC.IsDerivedStyle = true;
            this.metroPLC.Location = new System.Drawing.Point(4, 42);
            this.metroPLC.Name = "metroPLC";
            this.metroPLC.Size = new System.Drawing.Size(1698, 535);
            this.metroPLC.Style = MetroSet_UI.Enums.Style.Light;
            this.metroPLC.StyleManager = null;
            this.metroPLC.TabIndex = 1;
            this.metroPLC.Text = "PLC";
            this.metroPLC.ThemeAuthor = "Narwin";
            this.metroPLC.ThemeName = "MetroLite";
            this.metroPLC.ToolTipText = null;
            // 
            // grpConnectivity
            // 
            this.grpConnectivity.BackColor = System.Drawing.SystemColors.Window;
            this.grpConnectivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConnectivity.Location = new System.Drawing.Point(0, 320);
            this.grpConnectivity.Name = "grpConnectivity";
            this.grpConnectivity.Size = new System.Drawing.Size(340, 150);
            this.grpConnectivity.TabIndex = 14;
            this.grpConnectivity.TabStop = false;
            this.grpConnectivity.Text = "Connectivity";
            // 
            // grpSecurityChain
            // 
            this.grpSecurityChain.BackColor = System.Drawing.SystemColors.Window;
            this.grpSecurityChain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSecurityChain.Location = new System.Drawing.Point(0, 0);
            this.grpSecurityChain.Name = "grpSecurityChain";
            this.grpSecurityChain.Size = new System.Drawing.Size(340, 150);
            this.grpSecurityChain.TabIndex = 11;
            this.grpSecurityChain.TabStop = false;
            this.grpSecurityChain.Text = "Security Chain";
            // 
            // grpTooglePLC
            // 
            this.grpTooglePLC.BackColor = System.Drawing.SystemColors.Window;
            this.grpTooglePLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTooglePLC.Location = new System.Drawing.Point(720, 320);
            this.grpTooglePLC.Name = "grpTooglePLC";
            this.grpTooglePLC.Size = new System.Drawing.Size(340, 150);
            this.grpTooglePLC.TabIndex = 10;
            this.grpTooglePLC.TabStop = false;
            this.grpTooglePLC.Text = "Toogle PLC";
            // 
            // grpToogle
            // 
            this.grpToogle.BackColor = System.Drawing.SystemColors.Window;
            this.grpToogle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpToogle.Location = new System.Drawing.Point(720, 160);
            this.grpToogle.Name = "grpToogle";
            this.grpToogle.Size = new System.Drawing.Size(340, 150);
            this.grpToogle.TabIndex = 9;
            this.grpToogle.TabStop = false;
            this.grpToogle.Text = "Change Event";
            // 
            // grpCPU
            // 
            this.grpCPU.BackColor = System.Drawing.SystemColors.Window;
            this.grpCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCPU.Location = new System.Drawing.Point(360, 0);
            this.grpCPU.Name = "grpCPU";
            this.grpCPU.Size = new System.Drawing.Size(340, 150);
            this.grpCPU.TabIndex = 8;
            this.grpCPU.TabStop = false;
            this.grpCPU.Text = "CPU";
            // 
            // grpPLC
            // 
            this.grpPLC.BackColor = System.Drawing.SystemColors.Window;
            this.grpPLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPLC.Location = new System.Drawing.Point(360, 320);
            this.grpPLC.Name = "grpPLC";
            this.grpPLC.Size = new System.Drawing.Size(340, 150);
            this.grpPLC.TabIndex = 7;
            this.grpPLC.TabStop = false;
            this.grpPLC.Text = "PLC Label";
            // 
            // grpFastChange
            // 
            this.grpFastChange.BackColor = System.Drawing.SystemColors.Window;
            this.grpFastChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFastChange.ForeColor = System.Drawing.Color.Black;
            this.grpFastChange.Location = new System.Drawing.Point(720, 0);
            this.grpFastChange.Name = "grpFastChange";
            this.grpFastChange.Size = new System.Drawing.Size(340, 150);
            this.grpFastChange.TabIndex = 5;
            this.grpFastChange.TabStop = false;
            this.grpFastChange.Text = "Fast Change Event";
            // 
            // metroAllarmi
            // 
            this.metroAllarmi.BaseColor = System.Drawing.Color.White;
            this.metroAllarmi.Controls.Add(this.grp_Server);
            this.metroAllarmi.Controls.Add(this.grpTetto);
            this.metroAllarmi.Controls.Add(this.grpUPS);
            this.metroAllarmi.Font = null;
            this.metroAllarmi.ImageIndex = 0;
            this.metroAllarmi.ImageKey = null;
            this.metroAllarmi.IsDerivedStyle = true;
            this.metroAllarmi.Location = new System.Drawing.Point(4, 42);
            this.metroAllarmi.Name = "metroAllarmi";
            this.metroAllarmi.Size = new System.Drawing.Size(1698, 535);
            this.metroAllarmi.Style = MetroSet_UI.Enums.Style.Light;
            this.metroAllarmi.StyleManager = null;
            this.metroAllarmi.TabIndex = 2;
            this.metroAllarmi.Text = "Allarmi";
            this.metroAllarmi.ThemeAuthor = "Narwin";
            this.metroAllarmi.ThemeName = "MetroLite";
            this.metroAllarmi.ToolTipText = null;
            // 
            // grp_Server
            // 
            this.grp_Server.BackColor = System.Drawing.Color.White;
            this.grp_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_Server.Location = new System.Drawing.Point(10, 346);
            this.grp_Server.Name = "grp_Server";
            this.grp_Server.Size = new System.Drawing.Size(686, 100);
            this.grp_Server.TabIndex = 2;
            this.grp_Server.TabStop = false;
            this.grp_Server.Text = "Server";
            // 
            // grpTetto
            // 
            this.grpTetto.BackColor = System.Drawing.SystemColors.Window;
            this.grpTetto.Controls.Add(this.grp_FaldaSX);
            this.grpTetto.Controls.Add(this.grp_faldaDX);
            this.grpTetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTetto.Location = new System.Drawing.Point(702, 0);
            this.grpTetto.Name = "grpTetto";
            this.grpTetto.Size = new System.Drawing.Size(831, 340);
            this.grpTetto.TabIndex = 1;
            this.grpTetto.TabStop = false;
            this.grpTetto.Text = "Tetto";
            // 
            // grp_FaldaSX
            // 
            this.grp_FaldaSX.Location = new System.Drawing.Point(6, 19);
            this.grp_FaldaSX.Name = "grp_FaldaSX";
            this.grp_FaldaSX.Size = new System.Drawing.Size(400, 212);
            this.grp_FaldaSX.TabIndex = 1;
            this.grp_FaldaSX.TabStop = false;
            this.grp_FaldaSX.Text = "falda sinistra";
            // 
            // grp_faldaDX
            // 
            this.grp_faldaDX.Location = new System.Drawing.Point(412, 19);
            this.grp_faldaDX.Name = "grp_faldaDX";
            this.grp_faldaDX.Size = new System.Drawing.Size(400, 212);
            this.grp_faldaDX.TabIndex = 0;
            this.grp_faldaDX.TabStop = false;
            this.grp_faldaDX.Text = "falda destra";
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
            this.metroTetto.Font = null;
            this.metroTetto.ImageIndex = 0;
            this.metroTetto.ImageKey = null;
            this.metroTetto.IsDerivedStyle = true;
            this.metroTetto.Location = new System.Drawing.Point(4, 42);
            this.metroTetto.Name = "metroTetto";
            this.metroTetto.Size = new System.Drawing.Size(1698, 535);
            this.metroTetto.Style = MetroSet_UI.Enums.Style.Light;
            this.metroTetto.StyleManager = null;
            this.metroTetto.TabIndex = 3;
            this.metroTetto.Text = "Tetto";
            this.metroTetto.ThemeAuthor = "Narwin";
            this.metroTetto.ThemeName = "MetroLite";
            this.metroTetto.ToolTipText = null;
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1730, 683);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this._metroSetControlBox1);
            this.Controls.Add(this.TabConnection);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(12, 90, 12, 12);
            this.StyleManager = this.Stile;
            this.TextColor = System.Drawing.Color.White;
            this.ThemeName = "MetroLight";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TabConnection.ResumeLayout(false);
            this.metroControllo.ResumeLayout(false);
            this.metroPLC.ResumeLayout(false);
            this.metroAllarmi.ResumeLayout(false);
            this.grpTetto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Components.StyleManager Stile;
        private MetroSet_UI.Controls.MetroSetTabControl TabConnection;
        private MetroSet_UI.Child.MetroSetSetTabPage metroControllo;
        private MetroSet_UI.Controls.MetroSetEllipse btnControlStatus;
        private MetroSet_UI.Controls.MetroSetLabel lbl_Connection;
        private MetroSet_UI.Controls.MetroSetSwitch swConnect;
        private MetroSet_UI.Child.MetroSetSetTabPage metroPLC;
        private MetroSet_UI.Child.MetroSetSetTabPage metroAllarmi;
        private MetroSet_UI.Child.MetroSetSetTabPage metroTetto;
        private System.Windows.Forms.GroupBox grpFastChange;
        private System.Windows.Forms.GroupBox grpPLC;
        private MetroSet_UI.Controls.MetroSetControlBox _metroSetControlBox1;
        private System.Windows.Forms.GroupBox grpCPU;
        private System.Windows.Forms.GroupBox grpToogle;
        private System.Windows.Forms.GroupBox grpTooglePLC;
        private System.Windows.Forms.GroupBox grpSecurityChain;
        private System.Windows.Forms.GroupBox grpConnectivity;
        private System.Windows.Forms.GroupBox grpUPS;
        

        public static MetroSet_UI.Controls.MetroSetLabel lblValueRun;
        public static MetroSet_UI.Controls.MetroSetLabel lblValueDirection;
        public static MetroSet_UI.Controls.MetroSetButton btnEvent;
        public static MetroSet_UI.Controls.MetroSetLabel lblErrorCode;
        public static MetroSet_UI.Controls.MetroSetLabel lblUnit;
        public static MetroSet_UI.Controls.MetroSetLabel lblChange;
        public static MetroSet_UI.Controls.MetroSetButton btnChange;
        public static MetroSet_UI.Controls.MetroSetCheckBox chkToogle;
        public static MetroSet_UI.Controls.MetroSetLabel lblSecurityChain;
        public static MetroSet_UI.Controls.MetroSetEllipse eclSecurityChain;
        public static System.Windows.Forms.ToolTip PLC_Tooltip;
        public static MetroSet_UI.Controls.MetroSetLabel Lbl_Loading;
        public static MetroSet_UI.Controls.MetroSetLabel lbl_RamUsage;
        public static MetroSet_UI.Controls.MetroSetLabel lblCPUUsage;
        public static MetroSet_UI.Controls.MetroSetLabel lblUptime_Value;
        public static MetroSet_UI.Controls.MetroSetLabel lblUptime;
        public static MetroSet_UI.Controls.MetroSetEllipse btnIPStatus;
        public static MetroSet_UI.Controls.MetroSetButton btn_Ping;
        public static System.Windows.Forms.MaskedTextBox txtIP;
        public static MetroSet_UI.Controls.MetroSetLabel LblIP_Value;
        public static MetroSet_UI.Controls.MetroSetLabel lblIP;

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

        public static PLC_Label PLC_FineCorsaAperturaSX;
        public static PLC_Label PLC_FineCorsaChiusuraSX;
        public static PLC_Label PLC_FineCorsaAperturaDX;
        public static PLC_Label PLC_FineCorsaChiusuraDX;

        private MetroSet_UI.Controls.MetroSetLabel lblDateTime;
        private MetroSet_UI.Controls.MetroSetLabel lbl_Osservatorio;
        private System.Windows.Forms.GroupBox grpTetto;
        private System.Windows.Forms.GroupBox grp_faldaDX;
        private System.Windows.Forms.GroupBox grp_FaldaSX;
        private System.Windows.Forms.GroupBox grp_Server;
    }
}

