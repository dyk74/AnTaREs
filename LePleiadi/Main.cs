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
using static LePleiadi.VPN ;

namespace LePleiadi
{
    public partial class Main : MetroSetForm
    {
        private System.Timers.Timer UpdateTimer;
        private DateTime DateTime;

        public static bool Connected1 { get; set; }

        public Main()
        {
            // DA METTERE IN CONFIG FILE
            VPN.VPN_Server = "vpn.lepleiadi.ch";
            VPN.VPN_Protocol = "L2TP";
            VPN.VPN_AdapterName = "Le Pleiadi";
            VPN.VPN_Username = "pleiadi";
            VPN.VPN_Password = "le12$pleiadi99";
            VPN.VPN_PreSharedKey = "le12$pleiadi99";
            //
            Main.Connected1 = false;
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
            Main.Lbl_Loading = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblUptime = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblUptime_Value = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblCPUUsage = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lbl_RamUsage = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblIP = new MetroSet_UI.Controls.MetroSetLabel();
            Main.LblIP_Value = new MetroSet_UI.Controls.MetroSetLabel();
            Main.txtIP = new System.Windows.Forms.MaskedTextBox();
            Main.btn_Ping = new MetroSet_UI.Controls.MetroSetButton();
            Main.btnIPStatus = new MetroSet_UI.Controls.MetroSetEllipse();

            Main.UPS_EchoMode = new UPS_Alarm();
            Main.UPS_BatteryLow = new UPS_Alarm();
            Main.UPS_LDInverter = new UPS_Alarm();
            Main.UPS_Alarm = new UPS_Alarm();
            Main.UPS_ConnectionFailure = new UPS_Alarm();
            Main.UPS_MainFailure = new UPS_Alarm();

            Main.PLC_FineCorsaAperturaSX = new PLC_Label();
            Main.PLC_FineCorsaChiusuraSX = new PLC_Label();
            Main.PLC_FineCorsaAperturaDX = new PLC_Label();
            Main.PLC_FineCorsaChiusuraDX = new PLC_Label();
            //DA CAMBIARE CON UNO SWITCH
            Main.PLC_ApriFaldaSX = new PLC_Label();
            Main.PLC_ApriFaldaDX = new PLC_Label();
            Main.PLC_ChiudiFaldaSX = new PLC_Label();
            Main.PLC_ChiudiFaldaDX = new PLC_Label();
            //FINE CAMBIARE CON UNO SWITCH
        
            InitializeComponent();
            InitializeUPS();
            InitializeRoof();
            PLCFastChange_initialize();
            PLCChange_Initialize();
            PLCCPU_Initialize();
            PLCToogle_Initialize();
            PLCChainElement_Initialize();
            KeepAlive_Initialize();
            StartUpdateTimer();
            lbl_Osservatorio.Text = VPN_AdapterName;
        }
        public void InitializeRoof()
        {
            PLC_ApriFaldaSX.TopLevel = false;
            PLC_ApriFaldaDX.TopLevel = false;
            PLC_ChiudiFaldaSX.TopLevel = false;
            PLC_ChiudiFaldaDX.TopLevel = false;
            PLC_FineCorsaAperturaSX.TopLevel = false;
            PLC_FineCorsaChiusuraSX.TopLevel = false;
            PLC_FineCorsaAperturaDX.TopLevel = false;
            PLC_FineCorsaChiusuraDX.TopLevel = false;
            this.grp_FaldaSX.Controls.Add(PLC_ApriFaldaSX);
            this.grp_faldaDX.Controls.Add(PLC_ApriFaldaDX);
            this.grp_FaldaSX.Controls.Add(PLC_ChiudiFaldaSX);
            this.grp_faldaDX.Controls.Add(PLC_ChiudiFaldaDX);
            this.grp_FaldaSX.Controls.Add(PLC_FineCorsaAperturaSX);
            this.grp_FaldaSX.Controls.Add(PLC_FineCorsaChiusuraSX);
            this.grp_faldaDX.Controls.Add(PLC_FineCorsaAperturaDX);
            this.grp_faldaDX.Controls.Add(PLC_FineCorsaChiusuraDX);
            PLC_ApriFaldaSX.Show();
            PLC_ApriFaldaDX.Show();
            PLC_ChiudiFaldaDX.Show();
            PLC_ChiudiFaldaSX.Show();
            PLC_FineCorsaAperturaSX.Show();
            PLC_FineCorsaChiusuraSX.Show();
            PLC_FineCorsaAperturaDX.Show();
            PLC_FineCorsaChiusuraDX.Show();
            PLC_ApriFaldaSX.PLCVariableName = "Apri Falda Sinistra";
            PLC_ApriFaldaDX.PLCVariableName = "Apri Falda Destra";
            PLC_FineCorsaAperturaSX.PLCVariableName = "Finecorsa Apertura Sinistra";
            PLC_FineCorsaChiusuraSX.PLCVariableName = "Finecorsa Chiusura Sinistra";
            PLC_ChiudiFaldaSX.PLCVariableName = "Chiudi Falda Sinistra";
            PLC_ChiudiFaldaDX.PLCVariableName = "Chiudi Falda Destra";
            PLC_FineCorsaAperturaDX.PLCVariableName = "Finecorsa Apertura Destra";
            PLC_FineCorsaChiusuraDX.PLCVariableName = "Finecorsa Chiusura Destra";
            PLC_ApriFaldaSX.Location = new System.Drawing.Point(20, 20);
            PLC_FineCorsaAperturaSX.Location = new System.Drawing.Point(20, 80);
            PLC_FineCorsaAperturaDX.Location = new System.Drawing.Point(20, 80);
            PLC_FineCorsaChiusuraSX.Location = new System.Drawing.Point(200, 80);
            PLC_FineCorsaChiusuraDX.Location = new System.Drawing.Point(200, 80);
            PLC_ApriFaldaDX.Location = new System.Drawing.Point(20, 20);
            PLC_ChiudiFaldaSX.Location = new System.Drawing.Point(200, 20);
            PLC_ChiudiFaldaDX.Location = new System.Drawing.Point(200, 20);
            PLC_ApriFaldaSX.Size = new System.Drawing.Size(180, 42);
            PLC_ApriFaldaDX.Size = new System.Drawing.Size(180, 42);
            PLC_ChiudiFaldaSX.Size = new System.Drawing.Size(180, 42);
            PLC_ChiudiFaldaDX.Size = new System.Drawing.Size(180, 42);
            PLC_FineCorsaChiusuraSX.Size = new System.Drawing.Size(180, 42);
            PLC_FineCorsaAperturaSX.Size = new System.Drawing.Size(180, 42);
            PLC_FineCorsaAperturaDX.Size = new System.Drawing.Size(180, 42);
            PLC_FineCorsaChiusuraDX.Size = new System.Drawing.Size(180, 42);
            PLC_ApriFaldaSX.Name = "PLC_ApriFaldaSX";
            PLC_ApriFaldaDX.Name = "PLC_ApriFaldaDX";
            PLC_ChiudiFaldaSX.Name = "PLC_ChiudiFaldaSX";
            PLC_ChiudiFaldaDX.Name = "PLC_ChiudiFaldaDX";
            PLC_FineCorsaAperturaSX.Name = "PLC_FineCorsaAperturaSX";
            PLC_FineCorsaChiusuraSX.Name = "PLC_FineCorsaChiusuraSX";
            PLC_FineCorsaAperturaDX.Name = "PLC_FineCorsaAperturaDX";
            PLC_FineCorsaChiusuraDX.Name = "PLC_FineCorsaChiusuraDX";
            PLC_ApriFaldaSX.PLCVariablePath = "TCPIP.S7-200.Roof.ApriFaldaSX";
            PLC_ApriFaldaDX.PLCVariablePath = "TCPIP.S7.200.Roof.ApriFaldaDX";
            PLC_ChiudiFaldaSX.PLCVariablePath = "TCPIP.S7-200.Roof.ChiudiFaldaSX";
            PLC_ChiudiFaldaDX.PLCVariablePath = "TCPIP.S7-200.Roof.ChiudiFaldaDX";
            PLC_FineCorsaAperturaSX.PLCVariablePath = "TCPIP.S7-200.Roof.FC_FaldaSXApertura";
            PLC_FineCorsaChiusuraSX.PLCVariablePath = "TCPIP.S7-200.Roof.FC_FaldaSXChiusura";
            PLC_FineCorsaAperturaDX.PLCVariablePath = "TCPIP.S7-200.Roof.FC_FaldaDXApertura";
            PLC_FineCorsaChiusuraDX.PLCVariablePath = "TCPIP.S7-200.Roof.FC_FaldaDXChiusura";
            PLC_ApriFaldaSX.RedOnValue = true;
            PLC_ChiudiFaldaSX.RedOnValue = true;
            PLC_ApriFaldaDX.RedOnValue = true;
            PLC_ChiudiFaldaDX.RedOnValue = true;
            PLC_FineCorsaAperturaSX.RedOnValue = true;
            PLC_FineCorsaChiusuraSX.RedOnValue = true;
            PLC_FineCorsaAperturaDX.RedOnValue = true;
            PLC_FineCorsaChiusuraDX.RedOnValue = true;
            PLC_ApriFaldaSX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_ApriFaldaDX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_ChiudiFaldaSX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_ChiudiFaldaDX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_FineCorsaAperturaSX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_FineCorsaChiusuraSX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_FineCorsaAperturaDX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_FineCorsaChiusuraDX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
        }
        public void InitializeUPS()
        {
            UPS_EchoMode.TopLevel = false;
            UPS_BatteryLow.TopLevel = false;
            UPS_LDInverter.TopLevel = false;
            UPS_Alarm.TopLevel = false;
            UPS_ConnectionFailure.TopLevel = false;
            UPS_MainFailure.TopLevel = false;
            this.grpUPS.Controls.Add(UPS_EchoMode);
            this.grpUPS.Controls.Add(UPS_BatteryLow);
            this.grpUPS.Controls.Add(UPS_LDInverter);
            this.grpUPS.Controls.Add(UPS_Alarm);
            this.grpUPS.Controls.Add(UPS_ConnectionFailure);
            this.grpUPS.Controls.Add(UPS_MainFailure);
            UPS_EchoMode.Show();
            UPS_BatteryLow.Show();
            UPS_LDInverter.Show();
            UPS_Alarm.Show();
            UPS_ConnectionFailure.Show();
            UPS_MainFailure.Show();
            UPS_EchoMode.PLCAlarmName = "Eco Mode Active";
            UPS_BatteryLow.PLCAlarmName = "Battery Low";
            UPS_LDInverter.PLCAlarmName = "Inverter Alarm";
            UPS_Alarm.PLCAlarmName = "General Alarm";
            UPS_ConnectionFailure.PLCAlarmName = "Connection Failure";
            UPS_MainFailure.PLCAlarmName = "Main Failure";
            UPS_EchoMode.Location = new System.Drawing.Point(20, 20);
            UPS_BatteryLow.Location = new System.Drawing.Point(20, 70);
            UPS_LDInverter.Location = new System.Drawing.Point(20, 120);
            UPS_Alarm.Location = new System.Drawing.Point(20, 170);
            UPS_ConnectionFailure.Location = new System.Drawing.Point(340, 20);
            UPS_MainFailure.Location = new System.Drawing.Point(340, 70);
            UPS_EchoMode.Name = "UPS_EchoMode";
            UPS_BatteryLow.Name = "UPS_BatteryLow";
            UPS_LDInverter.Name = "UPS_LDInverter";
            UPS_Alarm.Name = "UPS_Alarm";
            UPS_MainFailure.Name = "UPS_MainFailure";
            UPS_ConnectionFailure.Name = "UPS_ConnectionFailure";
            UPS_EchoMode.PLCVariablePath = "TCPIP.S7-200.UPS.I_ECOMODE";
            UPS_BatteryLow.PLCVariablePath = "TCPIP.S7-200.UPS.I_BATTLOW";
            UPS_LDInverter.PLCVariablePath = "TCPIP.S7-200.UPS.I_LDINV";
            UPS_Alarm.PLCVariablePath = "TCPIP.S7-200.UPS.I_ALARM";
            UPS_ConnectionFailure.PLCVariablePath = "TCPIP.S7-200.UPS.AlmLinkFailure";
            UPS_MainFailure.PLCVariablePath = "TCPIP.S7-200.UPS.AlmMainsFailure";
            UPS_EchoMode.ResetAvailable = false;
            UPS_BatteryLow.ResetAvailable = false;
            UPS_LDInverter.ResetAvailable = false;
            UPS_Alarm.ResetAvailable = false;
            UPS_ConnectionFailure.ResetAvailable = false;
            UPS_MainFailure.ResetAvailable = false;
            UPS_EchoMode.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            UPS_BatteryLow.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            UPS_LDInverter.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            UPS_Alarm.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            UPS_ConnectionFailure.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            UPS_MainFailure.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
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
                        lblDateTime.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss} UTC", DateTime);
                    }
                    catch(Exception ex)
                    {
                    lblDateTime.Text = "Error on NTP Server: "+ex;
                    }
                }
                else
                {
                    DateTime = DateTime.AddSeconds(1.0);
                    lblDateTime.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss} UTC", DateTime);
                }
           }
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
        private void SwConnect_SwitchedChanged(object sender)
        {   
            MetroSetSwitch swC = sender as MetroSetSwitch;
            if (swC.CheckState==MetroSet_UI.Enums.CheckState.Checked)
            {
                VPN.Disconnect();
                Main.Connected1 = false;
                swC.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
                btnControlStatus.DisabledBorderColor = Color.Red;
                btnControlStatus.DisabledForeColor = Color.Red;
                btnControlStatus.DisabledBackColor = Color.Red;
            }
            else if(swC.CheckState==MetroSet_UI.Enums.CheckState.Unchecked)
            {
                DialogResult YESNO = MetroSetMessageBox.Show(this, "Vuoi veramente connetterti a "+VPN_AdapterName, "Connessione", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (YESNO==DialogResult.Yes)
                {
                    try
                    {
                        swC.CheckState = MetroSet_UI.Enums.CheckState.Checked;
                        VPN.Connect();
                        if (VPN._handle != null)
                        {
                            Main.Connected1 = true;
                            btnControlStatus.DisabledBorderColor = Color.Green;
                            btnControlStatus.DisabledForeColor = Color.Green;
                            btnControlStatus.DisabledBackColor = Color.Green;
                        }
                        else
                        {
                            swC.Switched = false;
                            Main.Connected1 = false;
                        }
                    }
                    catch(Exception ex)
                    {
                        VPN.Disconnect();
                        swC.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
                        btnControlStatus.DisabledBorderColor = Color.Red;
                        btnControlStatus.DisabledForeColor = Color.Red;
                        btnControlStatus.DisabledBackColor = Color.Red;
                        throw new Exception("Connection Error: " + ex.Message);
                    }
                }
                else if(YESNO==DialogResult.No)
                {
                    swC.Switched = false;
                }
            }
        }

    }
}
