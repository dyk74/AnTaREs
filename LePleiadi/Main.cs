using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LePleiadi.Comunicazione;
using MetroSet_UI.Forms;
using MetroSet_UI.Enums;
using MetroSet_UI.Controls;
using System.Windows.Forms;
using System.Timers;

namespace LePleiadi
{
    public partial class Main : MetroSetForm
    {
        private bool Connected = false;
        private System.Timers.Timer UpdateTimer;
        private DateTime DateTime;
        public Main()
        {
            Main.btnUPS = new MetroSet_UI.Controls.MetroSetButton();
            Main.lblUPS = new MetroSet_UI.Controls.MetroSetLabel();
            Main.RoofOpenClose = new MetroSet_UI.Controls.MetroSetEllipse();
            Main.RoofLeft = new MetroSet_UI.Controls.MetroSetEllipse();
            Main.RoofRight = new MetroSet_UI.Controls.MetroSetEllipse();
            Main.LblPLCVariableName = new MetroSet_UI.Controls.MetroSetLabel();
            Main.LblPLCVariableValue = new MetroSet_UI.Controls.MetroSetLabel();
            Main.btnEvent = new MetroSet_UI.Controls.MetroSetButton();
            Main.lblValueDirection = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblValueRun = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblUnit = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblErrorCode = new MetroSet_UI.Controls.MetroSetLabel();
            Main.btnChange= new MetroSet_UI.Controls.MetroSetButton();
            Main.lblChange = new MetroSet_UI.Controls.MetroSetLabel();
            Main.chkToogle = new MetroSet_UI.Controls.MetroSetCheckBox();
            Main.eclSecurityChain = new MetroSet_UI.Controls.MetroSetEllipse();
            Main.lblSecurityChain = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblKeepAlive = new MetroSet_UI.Controls.MetroSetLabel();
            Main.btn_KeepAlive = new MetroSet_UI.Controls.MetroSetEllipse();
            Main.Pb_Loading = new MetroSet_UI.Controls.MetroSetProgressBar();
            Main.Lbl_Loading = new MetroSet_UI.Controls.MetroSetLabel();
            Main.PB_CPUUsage = new MetroSet_UI.Controls.MetroSetProgressBar();
            Main.PB_Ram = new MetroSet_UI.Controls.MetroSetProgressBar();
            Main.lblUptime = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblUptime_Value = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblCPUUsage = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lbl_RamUsage = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblIP = new MetroSet_UI.Controls.MetroSetLabel();
            Main.LblIP_Value = new MetroSet_UI.Controls.MetroSetLabel();
            Main.txtIP = new System.Windows.Forms.MaskedTextBox();
            Main.btn_Ping = new MetroSet_UI.Controls.MetroSetButton();
            Main.btnIPStatus = new MetroSet_UI.Controls.MetroSetEllipse();
            InitializeComponent();
            BtnUPS_Initialize();
            LblUPS_Initialize();
            RoofOpenClose_Initialize();
            PLCLabel_Initialize();
            PLCFastChange_initialize();
            PLCChange_Initialize();
            PLCCPU_Initialize();
            PLCToogle_Initialize();
            PLCChainElement_Initialize();
            Loading_Initialize();
            KeepAlive_Initialize();
            ConnectivityStatus_Initialize();
            StartUpdateTimer();

        }
        public void StartUpdateTimer()
        {
            UpdateTimer = new System.Timers.Timer();
            UpdateTimer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateTimerExpired);
            UpdateTimer.Interval = 1000;
            UpdateTimer.Start();
        }
        public void StopUpdateTimer()
        {
            UpdateTimer.Stop();
            UpdateTimer = null;
        }
        delegate void UpdateTimerExpiredCallback(object source, ElapsedEventArgs e);
        public void UpdateTimerExpired(object source,ElapsedEventArgs e)
        {
           if(this.lblDateTime.InvokeRequired)
            {
                UpdateTimerExpiredCallback UpadateCallback = new UpdateTimerExpiredCallback(UpdateTimerExpired);
                this.Invoke(UpadateCallback, new object[] { source, e });
            }
           else
           { 
                if(DateTime==DateTime.MinValue)
                {
                    try
                    {
                        DateTime = PLC.PLC_Utility.NtpClient.GetNetworkTime();
                        lblDateTime.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime);
                    }
                    catch(Exception ex)
                    {
                    lblDateTime.Text = "Error on NTP Server";
                    }
                }
                else
                {
                    DateTime = DateTime.AddSeconds(1.0);
                    lblDateTime.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime);
                }
           }
        }
        private void ConnectivityStatus_Initialize()
        {
            this.grpConnectivity.Controls.Add(Main.btnIPStatus);
            this.grpConnectivity.Controls.Add(Main.btn_Ping);
            this.grpConnectivity.Controls.Add(Main.txtIP);
            this.grpConnectivity.Controls.Add(Main.LblIP_Value);
            this.grpConnectivity.Controls.Add(Main.lblIP);
            this.grpConnectivity.Controls.Add(Main.lbl_RamUsage);
            this.grpConnectivity.Controls.Add(Main.lblCPUUsage);
            this.grpConnectivity.Controls.Add(Main.lblUptime_Value);
            this.grpConnectivity.Controls.Add(Main.lblUptime);
            this.grpConnectivity.Controls.Add(Main.PB_Ram);
            this.grpConnectivity.Controls.Add(Main.PB_CPUUsage);
            PB_CPUUsage.IsDerivedStyle = true;
            PB_CPUUsage.Location = new System.Drawing.Point(90, 20);
            PB_CPUUsage.Maximum = 100;
            PB_CPUUsage.Minimum = 0;
            PB_CPUUsage.Name = "PB_CPUUsage";
            PB_CPUUsage.Orientation = MetroSet_UI.Enums.ProgressOrientation.Horizontal;
            PB_CPUUsage.Size = new System.Drawing.Size(230, 25);
            PB_CPUUsage.Style = MetroSet_UI.Enums.Style.Light;
            PB_CPUUsage.StyleManager = null;
            PB_CPUUsage.TabIndex = 0;
            PB_CPUUsage.Text = "0%";
            PB_CPUUsage.ThemeAuthor = "Narwin";
            PB_CPUUsage.ThemeName = "MetroLite";
            PB_CPUUsage.Value = 0;
            PB_Ram.IsDerivedStyle = true;
            PB_Ram.Location = new System.Drawing.Point(90, 50);
            PB_Ram.Maximum = 100;
            PB_Ram.Minimum = 0;
            PB_Ram.Name = "PB_Ram";
            PB_Ram.Orientation = MetroSet_UI.Enums.ProgressOrientation.Horizontal;
            PB_Ram.Size = new System.Drawing.Size(230, 25);
            PB_Ram.Style = MetroSet_UI.Enums.Style.Light;
            PB_Ram.StyleManager = null;
            PB_Ram.TabIndex = 1;
            PB_Ram.Text = "0 MB";
            PB_Ram.ThemeAuthor = "Narwin";
            PB_Ram.ThemeName = "MetroLite";
            PB_Ram.Value = 0;
            lblUptime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblUptime.IsDerivedStyle = true;
            lblUptime.Location = new System.Drawing.Point(7, 80);
            lblUptime.Name = "lblUptime";
            lblUptime.Size = new System.Drawing.Size(56, 25);
            lblUptime.Style = MetroSet_UI.Enums.Style.Light;
            lblUptime.StyleManager = null;
            lblUptime.TabIndex = 2;
            lblUptime.Text = "Uptime";
            lblUptime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblUptime.ThemeAuthor = "Narwin";
            lblUptime.ThemeName = "MetroLite";
            lblUptime_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblUptime_Value.IsDerivedStyle = true;
            lblUptime_Value.Location = new System.Drawing.Point(58, 80);
            lblUptime_Value.Name = "lblUptime_Value";
            lblUptime_Value.Size = new System.Drawing.Size(83, 25);
            lblUptime_Value.Style = MetroSet_UI.Enums.Style.Light;
            lblUptime_Value.StyleManager = null;
            lblUptime_Value.TabIndex = 3;
            lblUptime_Value.Text = "0";
            lblUptime_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblUptime_Value.ThemeAuthor = "Narwin";
            lblUptime_Value.ThemeName = "MetroLite";
            lblCPUUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblCPUUsage.IsDerivedStyle = true;
            lblCPUUsage.Location = new System.Drawing.Point(7, 20);
            lblCPUUsage.Name = "lblCPUUsage";
            lblCPUUsage.Size = new System.Drawing.Size(77, 25);
            lblCPUUsage.Style = MetroSet_UI.Enums.Style.Light;
            lblCPUUsage.StyleManager = null;
            lblCPUUsage.TabIndex = 4;
            lblCPUUsage.Text = "CPU Usage";
            lblCPUUsage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblCPUUsage.ThemeAuthor = "Narwin";
            lblCPUUsage.ThemeName = "MetroLite";
            lbl_RamUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl_RamUsage.IsDerivedStyle = true;
            lbl_RamUsage.Location = new System.Drawing.Point(7, 49);
            lbl_RamUsage.Name = "lbl_RamUsage";
            lbl_RamUsage.Size = new System.Drawing.Size(77, 25);
            lbl_RamUsage.Style = MetroSet_UI.Enums.Style.Light;
            lbl_RamUsage.StyleManager = null;
            lbl_RamUsage.TabIndex = 5;
            lbl_RamUsage.Text = "RAM Usage";
            lbl_RamUsage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lbl_RamUsage.ThemeAuthor = "Narwin";
            lbl_RamUsage.ThemeName = "MetroLite";
            lblIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblIP.IsDerivedStyle = true;
            lblIP.Location = new System.Drawing.Point(162, 79);
            lblIP.Name = "lblIP";
            lblIP.Size = new System.Drawing.Size(78, 25);
            lblIP.Style = MetroSet_UI.Enums.Style.Light;
            lblIP.StyleManager = null;
            lblIP.TabIndex = 6;
            lblIP.Text = "IP Address";
            lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblIP.ThemeAuthor = "Narwin";
            lblIP.ThemeName = "MetroLite";
            LblIP_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblIP_Value.IsDerivedStyle = true;
            LblIP_Value.Location = new System.Drawing.Point(235, 79);
            LblIP_Value.Name = "LblIP_Value";
            LblIP_Value.Size = new System.Drawing.Size(100, 25);
            LblIP_Value.Style = MetroSet_UI.Enums.Style.Light;
            LblIP_Value.StyleManager = null;
            LblIP_Value.TabIndex = 7;
            LblIP_Value.Text = "255.255.255.255";
            LblIP_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            LblIP_Value.ThemeAuthor = "Narwin";
            LblIP_Value.ThemeName = "MetroLite";
            txtIP.Location = new System.Drawing.Point(7, 117);
            txtIP.Mask = "###.###.###.###";
            txtIP.Name = "txtIP";
            txtIP.Size = new System.Drawing.Size(100, 20);
            txtIP.TabIndex = 8;
            btn_Ping.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            btn_Ping.IsDerivedStyle = true;
            btn_Ping.Location = new System.Drawing.Point(162, 117);
            btn_Ping.Name = "btn_Ping";
            btn_Ping.Size = new System.Drawing.Size(75, 20);
            btn_Ping.Click += Btn_Ping_Click;
            btn_Ping.StyleManager = null;
            btn_Ping.TabIndex = 9;
            btn_Ping.Text = "Ping";
            btn_Ping.ThemeAuthor = "Narwin";
            btn_Ping.ThemeName = "MetroLite";
            btnIPStatus.BorderThickness = 0;
            btnIPStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            btnIPStatus.Image = null;
            btnIPStatus.IsDerivedStyle = true;
            btnIPStatus.Location = new System.Drawing.Point(300, 117);
            btnIPStatus.Name = "btnIPStatus";
            btnIPStatus.NormalBorderColor = System.Drawing.Color.Gray;
            btnIPStatus.NormalColor = System.Drawing.Color.Gray;
            btnIPStatus.NormalTextColor = System.Drawing.Color.Black;
            btnIPStatus.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            btnIPStatus.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            btnIPStatus.PressTextColor = System.Drawing.Color.White;
            btnIPStatus.Size = new System.Drawing.Size(20, 20);
            btnIPStatus.Style = MetroSet_UI.Enums.Style.Light;
            btnIPStatus.StyleManager = null;
            btnIPStatus.TabIndex = 10;
            btnIPStatus.ThemeAuthor = "Narwin";
            btnIPStatus.ThemeName = "MetroLite";
        }
        private void Btn_Ping_Click(object sender, EventArgs e)
        {
            PLC.PLC_CheckConnectivity.Btn_Ping_Click(sender, e);
        }
        private void KeepAlive_Initialize()
        {
            this.grp_KeepAlive.Controls.Add(Main.btn_KeepAlive);
            this.grp_KeepAlive.Controls.Add(Main.lblKeepAlive);
            lblKeepAlive.IsDerivedStyle = true;
            lblKeepAlive.Location = new System.Drawing.Point(7, 51);
            lblKeepAlive.Name = "lblKeepAlive";
            lblKeepAlive.Size = new System.Drawing.Size(77, 23);
            lblKeepAlive.Style = MetroSet_UI.Enums.Style.Light;
            lblKeepAlive.Text = "Server";
            lblKeepAlive.ThemeAuthor = "Narwin";
            lblKeepAlive.ThemeName = "MetroLite";
            btn_KeepAlive.BorderThickness = 0;
            btn_KeepAlive.Enabled = false;
            btn_KeepAlive.Image = null;
            btn_KeepAlive.ImageSize = new System.Drawing.Size(64, 64);
            btn_KeepAlive.IsDerivedStyle = true;
            btn_KeepAlive.Location = new System.Drawing.Point(90, 34);
            btn_KeepAlive.Name = "btn_KeepAlive";
            btn_KeepAlive.NormalColor = System.Drawing.Color.Red;
            btn_KeepAlive.Size = new System.Drawing.Size(55, 55);
            btn_KeepAlive.Style = MetroSet_UI.Enums.Style.Light;
            btn_KeepAlive.StyleManager = null;
            btn_KeepAlive.TabIndex = 1;
            btn_KeepAlive.ThemeAuthor = "Narwin";
            btn_KeepAlive.ThemeName = "MetroLite";
        }
        private void Loading_Initialize()
        {
            this.grpLoading.Controls.Add(Main.Lbl_Loading);
            this.grpLoading.Controls.Add(Main.Pb_Loading);
            Pb_Loading.IsDerivedStyle = true;
            Pb_Loading.Location = new System.Drawing.Point(263, 19);
            Pb_Loading.Maximum = 100;
            Pb_Loading.Minimum = 0;
            Pb_Loading.Name = "Pb_Loading";
            Pb_Loading.Orientation = MetroSet_UI.Enums.ProgressOrientation.Horizontal;
            Pb_Loading.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            Pb_Loading.Size = new System.Drawing.Size(490, 20);
            Pb_Loading.Style = MetroSet_UI.Enums.Style.Light;
            Pb_Loading.StyleManager = null;
            Pb_Loading.TabIndex = 0;
            Pb_Loading.Click += Pb_Loading_Click;
            Pb_Loading.ThemeAuthor = "Narwin";
            Pb_Loading.ThemeName = "MetroLite";
            Pb_Loading.Value = 0;
            Lbl_Loading.IsDerivedStyle = true;
            Lbl_Loading.Location = new System.Drawing.Point(12, 15);
            Lbl_Loading.Name = "Lbl_Loading";
            Lbl_Loading.Size = new System.Drawing.Size(245, 23);
            Lbl_Loading.Style = MetroSet_UI.Enums.Style.Light;
            Lbl_Loading.StyleManager = null;
            Lbl_Loading.TabIndex = 1;
            Lbl_Loading.Text = ".";
            Lbl_Loading.ThemeAuthor = "Narwin";
            Lbl_Loading.ThemeName = "MetroLite";
        }
        private void Pb_Loading_Click(object sender, EventArgs e)
        {
            PLC.PLC_Loading.Pb_Loading_Click(sender, e);
        }
        private void PLCChainElement_Initialize()
        {
            this.grpSecurityChain.Controls.Add(Main.lblSecurityChain);
            this.grpSecurityChain.Controls.Add(Main.eclSecurityChain);
            eclSecurityChain.BorderThickness = 0;
            eclSecurityChain.Enabled = false;
            eclSecurityChain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            eclSecurityChain.Image = null;
            eclSecurityChain.ImageSize = new System.Drawing.Size(64, 64);
            eclSecurityChain.IsDerivedStyle = true;
            eclSecurityChain.Location = new System.Drawing.Point(6, 19);
            eclSecurityChain.Name = "eclSecurityChain";
            eclSecurityChain.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            eclSecurityChain.NormalTextColor = System.Drawing.Color.Black;
            eclSecurityChain.PressTextColor = System.Drawing.Color.White;
            eclSecurityChain.Size = new System.Drawing.Size(75, 75);
            eclSecurityChain.Style = MetroSet_UI.Enums.Style.Light;
            eclSecurityChain.StyleManager = null;
            eclSecurityChain.TabIndex = 0;
            eclSecurityChain.ThemeAuthor = "Narwin";
            eclSecurityChain.ThemeName = "MetroLite";
            lblSecurityChain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            lblSecurityChain.IsDerivedStyle = true;
            lblSecurityChain.Location = new System.Drawing.Point(87, 40);
            lblSecurityChain.Name = "lblSecurityChain";
            lblSecurityChain.Size = new System.Drawing.Size(130, 23);
            lblSecurityChain.Style = MetroSet_UI.Enums.Style.Light;
            lblSecurityChain.StyleManager = null;
            lblSecurityChain.TabIndex = 1;
            lblSecurityChain.Text = "-";
            lblSecurityChain.ThemeAuthor = "Narwin";
            lblSecurityChain.ThemeName = "MetroLite";  
        }
        private void PLCToogle_Initialize()
        {
            this.grpTooglePLC.Controls.Add(Main.chkToogle);
            chkToogle.BackColor = System.Drawing.Color.Transparent;
            chkToogle.Checked = false;
            chkToogle.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            chkToogle.Cursor = System.Windows.Forms.Cursors.Hand;
            chkToogle.IsDerivedStyle = true;
            chkToogle.Location = new System.Drawing.Point(6, 19);
            chkToogle.Name = "chkToogle";
            chkToogle.SignStyle = MetroSet_UI.Enums.SignStyle.Shape;
            chkToogle.Size = new System.Drawing.Size(154, 16);
            chkToogle.Style = MetroSet_UI.Enums.Style.Light;
            chkToogle.StyleManager = this.Stile;
            chkToogle.TabIndex = 10;
            chkToogle.Text = "-";
            chkToogle.ThemeAuthor = null;
            chkToogle.ThemeName = null;
            chkToogle.CheckedChanged += ChkToogle_CheckedChanged; 
        }
        private void ChkToogle_CheckedChanged(object sender)
        {
            PLC.PLC_Toogle.ChkToogle_CheckedChanged(sender);
        }
        private void PLCChange_Initialize()
        {
            this.grpToogle.Controls.Add(Main.lblChange);
            this.grpToogle.Controls.Add(Main.btnChange);
            btnChange.IsDerivedStyle = true;
            btnChange.Location = new System.Drawing.Point(6, 25);
            btnChange.Name = "btnChange";
            btnChange.Size = new System.Drawing.Size(124, 45);
            btnChange.Style = MetroSet_UI.Enums.Style.Light;
            btnChange.StyleManager = null;
            btnChange.TabIndex = 0;
            btnChange.Text = "Event";
            btnChange.ThemeAuthor = "Narwin";
            btnChange.ThemeName = "MetroLite";
            btnChange.Click += BtnChange_Click;
            lblChange.IsDerivedStyle = true;
            lblChange.Location = new System.Drawing.Point(136, 25);
            lblChange.Name = "lblChange";
            lblChange.Size = new System.Drawing.Size(100, 23);
            lblChange.Style = MetroSet_UI.Enums.Style.Light;
            lblChange.StyleManager = null;
            lblChange.TabIndex = 1;
            lblChange.Text = "-";
            lblChange.ThemeAuthor = "Narwin";
            lblChange.ThemeName = "MetroLite";
        }
        private void PLCCPU_Initialize()
        {
            this.grpCPU.Controls.Add(Main.lblUnit);
            this.grpCPU.Controls.Add(Main.lblErrorCode);
            lblUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            lblUnit.IsDerivedStyle = true;
            lblUnit.Location = new System.Drawing.Point(7, 20);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new System.Drawing.Size(100, 23);
            lblUnit.Style = MetroSet_UI.Enums.Style.Light;
            lblUnit.StyleManager = null;
            lblUnit.TabIndex = 0;
            lblUnit.Text = "0";
            lblUnit.ThemeAuthor = "Narwin";
            lblUnit.ThemeName = "MetroLite";
            lblErrorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            lblErrorCode.IsDerivedStyle = true;
            lblErrorCode.Location = new System.Drawing.Point(7, 47);
            lblErrorCode.Name = "lblErrorCode";
            lblErrorCode.Size = new System.Drawing.Size(100, 23);
            lblErrorCode.Style = MetroSet_UI.Enums.Style.Light;
            lblErrorCode.StyleManager = null;
            lblErrorCode.TabIndex = 1;
            lblErrorCode.Text = "0";
            lblErrorCode.ThemeAuthor = "Narwin";
            lblErrorCode.ThemeName = "MetroLite";
            lblErrorCode.Click += LblErrorCode_Click;

        }
        private void PLCFastChange_initialize()
        {
            this.grpFastChange.Controls.Add(Main.lblValueRun);
            this.grpFastChange.Controls.Add(Main.lblValueDirection);
            this.grpFastChange.Controls.Add(Main.btnEvent);
            btnEvent.Location = new System.Drawing.Point(6, 25);
            btnEvent.Name = "btnEvent";
            btnEvent.PressTextColor = System.Drawing.Color.White;
            btnEvent.Size = new System.Drawing.Size(124, 45);
            btnEvent.Style = MetroSet_UI.Enums.Style.Light;
            btnEvent.StyleManager = null;
            btnEvent.TabIndex = 3;
            btnEvent.Text = "Event";
            btnEvent.ThemeAuthor = "Narwin";
            btnEvent.ThemeName = "MetroLite";
            btnEvent.Click += BtnEvent_Click;
            lblValueDirection.IsDerivedStyle = true;
            lblValueDirection.Location = new System.Drawing.Point(136, 47);
            lblValueDirection.Name = "lblValueDirection";
            lblValueDirection.Size = new System.Drawing.Size(100, 23);
            lblValueDirection.Style = MetroSet_UI.Enums.Style.Light;
            lblValueDirection.StyleManager = null;
            lblValueDirection.TabIndex = 5;
            lblValueDirection.Text = "-";
            lblValueDirection.ThemeAuthor = "Narwin";
            lblValueDirection.ThemeName = "MetroLite";
            lblValueRun.IsDerivedStyle = true;
            lblValueRun.Location = new System.Drawing.Point(136, 25);
            lblValueRun.Name = "lblValueRun";
            lblValueRun.Size = new System.Drawing.Size(100, 23);
            lblValueRun.Style = MetroSet_UI.Enums.Style.Light;
            lblValueRun.StyleManager = null;
            lblValueRun.TabIndex = 6;
            lblValueRun.Text = "-";
            lblValueRun.ThemeAuthor = "Narwin";
            lblValueRun.ThemeName = "MetroLite";

        }
        private void LblErrorCode_Click(object sender,EventArgs e)
        {

        }
        private void BtnEvent_Click(object sender, EventArgs e)
        {
            PLC.PLC_ChangeValue.BtnEvent_Click(sender, e);
        }
        private void BtnChange_Click(object sender, EventArgs e)
        {
            PLC.PLC_Value.BtnChange_Click(sender, e);
        }
        private void PLCLabel_Initialize()
        {
            this.grpPLC.Controls.Add(Main.LblPLCVariableValue);
            this.grpPLC.Controls.Add(Main.LblPLCVariableName);
            LblPLCVariableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            LblPLCVariableName.IsDerivedStyle = true;
            LblPLCVariableName.Location = new System.Drawing.Point(6, 25);
            LblPLCVariableName.Name = "LblPLCVariableName";
            LblPLCVariableName.Size = new System.Drawing.Size(100, 23);
            LblPLCVariableName.Style = MetroSet_UI.Enums.Style.Light;
            LblPLCVariableName.StyleManager = null;
            LblPLCVariableName.TabIndex = 0;
            LblPLCVariableName.Text = "Variable";
            LblPLCVariableName.ThemeAuthor = "Narwin";
            LblPLCVariableName.ThemeName = "MetroLite";
            LblPLCVariableValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            LblPLCVariableValue.IsDerivedStyle = true;
            LblPLCVariableValue.Location = new System.Drawing.Point(70, 25);
            LblPLCVariableValue.Name = "LblPLCVariableValue";
            LblPLCVariableValue.Size = new System.Drawing.Size(100, 23);
            LblPLCVariableValue.Style = MetroSet_UI.Enums.Style.Light;
            LblPLCVariableValue.StyleManager = null;
            LblPLCVariableValue.TabIndex = 1;
            LblPLCVariableValue.Text = "0";
            LblPLCVariableValue.ThemeAuthor = "Narwin";
            LblPLCVariableValue.ThemeName = "MetroLite";
        }
        private void BtnUPS_Initialize()
        {
            btnUPS.IsDerivedStyle = true;
            btnUPS.Location = new System.Drawing.Point(10, 25);
            btnUPS.Name = "btnUPS";
            btnUPS.Size = new System.Drawing.Size(130, 60);
            btnUPS.Style = MetroSet_UI.Enums.Style.Light;
            btnUPS.StyleManager = null;
            btnUPS.TabIndex = 1;
            btnUPS.Text = "UPS";
            btnUPS.ThemeAuthor = "Narwin";
            btnUPS.ThemeName = "MetroLite";
            this.metroAllarmi.Controls.Add(Main.btnUPS);

            btnUPS.HoverTextColor = Color.FromArgb(255, 255, 255);
            btnUPS.NormalTextColor = Color.FromArgb(255, 255, 255);
            btnUPS.PressTextColor = Color.FromArgb(255, 255, 255);
            btnUPS.DisabledBorderColor = Color.FromArgb(192, 192, 192);
            btnUPS.DisabledForeColor = Color.FromArgb(255, 255, 255);
            btnUPS.DisabledBackColor = Color.FromArgb(192, 192, 192);
            btnUPS.Click += new System.EventHandler(BtnUPS_Click);
            btnUPS.Enabled = false;
        }
        private void LblUPS_Initialize()
        {
            this.metroAllarmi.Controls.Add(Main.lblUPS);
            lblUPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            lblUPS.IsDerivedStyle = true;
            lblUPS.Location = new System.Drawing.Point(10, 100);
            lblUPS.Name = "lblUPS";
            lblUPS.Size = new System.Drawing.Size(100, 23);
            lblUPS.Style = MetroSet_UI.Enums.Style.Light;
            lblUPS.StyleManager = null;
            lblUPS.TabIndex = 0;
            lblUPS.Text = "";
            lblUPS.ThemeAuthor = "Narwin";
            lblUPS.ThemeName = "MetroLite";
        }
        private void RoofOpenClose_Initialize()
        {
            this.grpRoof.Controls.Add(Main.RoofOpenClose);
            this.grpRoof.Controls.Add(Main.RoofRight);
            this.grpRoof.Controls.Add(Main.RoofLeft);
            RoofOpenClose.BorderThickness = 0;
            RoofLeft.BorderThickness = 5;
            RoofLeft.DisabledBorderColor = System.Drawing.Color.FromArgb(0, 192, 0);
            RoofRight.BorderThickness = 5;
            RoofRight.DisabledBorderColor = System.Drawing.Color.FromArgb(0, 192, 0);
            RoofOpenClose.Enabled = false;
            RoofRight.Enabled = false;
            RoofLeft.Enabled = false;
            RoofOpenClose.DisabledBackColor = System.Drawing.Color.FromArgb(192,192,192);
            RoofRight.DisabledBackColor = System.Drawing.Color.FromArgb(192, 192, 192);
            RoofLeft.DisabledBackColor = System.Drawing.Color.FromArgb(192, 192, 192);
            RoofOpenClose.ImageSize = new System.Drawing.Size(64, 64);
            RoofLeft.ImageSize = new System.Drawing.Size(32, 32);
            RoofRight.ImageSize = new System.Drawing.Size(32, 32);
            RoofOpenClose.Location = new System.Drawing.Point(64, 12);
            RoofLeft.Location = new System.Drawing.Point(150, 33);
            RoofRight.Location = new System.Drawing.Point(190, 33);
            RoofOpenClose.Name = "RoofOpenClose";
            RoofOpenClose.Size = new System.Drawing.Size(76, 76);
            RoofLeft.Size = new System.Drawing.Size(38, 38);
            RoofRight.Size = new System.Drawing.Size(38, 38);
            RoofOpenClose.Style = MetroSet_UI.Enums.Style.Light;
            RoofOpenClose.StyleManager = this.Stile;
            RoofOpenClose.ThemeAuthor = "Narwin";
            RoofOpenClose.ThemeName = "MetroLite";
        }
        private void SwConnect_SwitchedChanged(object sender)
        {

            MetroSetSwitch swC = sender as MetroSetSwitch;
            if (swC.CheckState==MetroSet_UI.Enums.CheckState.Checked)
            {
                swC.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
                btnControlStatus.DisabledBorderColor = Color.FromArgb(192, 0, 0);
                btnControlStatus.DisabledForeColor = Color.FromArgb(192, 0, 0);
                btnControlStatus.DisabledBackColor = Color.FromArgb(192, 0, 0);
            }
            else if(swC.CheckState==MetroSet_UI.Enums.CheckState.Unchecked)
            {
                swC.CheckState = MetroSet_UI.Enums.CheckState.Checked;
                btnControlStatus.DisabledBorderColor = Color.FromArgb(0, 192, 0);
                btnControlStatus.DisabledForeColor = Color.FromArgb(0, 192, 0);
                btnControlStatus.DisabledBackColor = Color.FromArgb(0, 192, 0);
               // MetroSetMessageBox.Show(this, "connesso");
            }
        }
        private void BtnUPS_Click(object sender,EventArgs e)
        {
            PLC.Alarm_UPS.LO_Handle.Write(false);
            PLC.Alarm_UPS.SetResetAvailable();
        }

    }
}
