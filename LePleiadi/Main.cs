using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AnTaREs.Comunicazione;
using MetroSet_UI.Forms;
using MetroSet_UI.Enums;
using MetroSet_UI.Controls;
using System.Windows.Forms;
using System.Timers;
using static AnTaREs.VPN ;

namespace AnTaREs
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

            Main.PLC_Alarm_UPS_EchoMode = new PLC_Alarm();
            Main.UPS_BatteryLow = new PLC_Alarm();
            Main.UPS_LDInverter = new PLC_Alarm();
            Main.UPS_Alarm = new PLC_Alarm();
            Main.UPS_ConnectionFailure = new PLC_Alarm();
            Main.UPS_MainFailure = new PLC_Alarm();
            Main.UPS_ChargeValue = new PLC_ProgressBar();
            Main.PLC_UPS_Alarm_Bypass = new PLC_Toggle();

            Main.PLC_FineCorsaAperturaSX = new PLC_Label();
            Main.PLC_FineCorsaChiusuraSX = new PLC_Label();
            Main.PLC_FineCorsaAperturaDX = new PLC_Label();
            Main.PLC_FineCorsaChiusuraDX = new PLC_Label();
            Main.PLC_NoResetTermici = new PLC_Label();
            Main.PLC_Reset_Termici = new PLC_Toggle();
            Main.PLC_Cicalini = new PLC_Label();
            Main.PLC_CicaliniMute = new PLC_Toggle();
            Main.PLC_Reset_Counter_Termici = new PLC_Toggle();
            Main.PLC_Tetto_Chiusura_Timeout = new PLC_Alarm();
            Main.PLC_Tetto_Apertura_Timeout = new PLC_Alarm();
            Main.PLC_Tetto_Termico = new PLC_Alarm();

            Main.Server_KeepAlive = new PLC_KeepAlive();

            Main.PLC_VertigoTettoChiuso = new PLC_Label();
            Main.PLC_VertigoTettoAperto = new PLC_Label();
            Main.PLC_VertigoAllarmeTetto = new PLC_Label();
            Main.PLC_VertigoChiudiTetto = new PLC_Label();
            Main.PLC_VertigoApriTetto = new PLC_Label();
            Main.PLC_Vertigo_RoofOpen_Bypass = new PLC_Toggle();
            Main.PLC_Toggle_Vertigo_KeepAlive_Bypass = new PLC_Toggle();
            Main.PLC_Alarm_Vertigo_KeepAlive = new PLC_Alarm();

            Main.PLC_FineCorsa_AR_Parking = new PLC_Label();
            Main.PLC_FineCorsa_DEC_Parking = new PLC_Label();

            Main.PLC_DEC_Direction = new PLC_Label();
            Main.PLC_AR_Direction = new PLC_Label();
            Main.PLC_DEC_Error = new PLC_Label();
            Main.PLC_AR_Error = new PLC_Label();
            Main.PLC_DEC_Run = new PLC_Toggle();
            Main.PLC_AR_Run = new PLC_Toggle();
            Main.PLC_Decelerated_DEC_Stop = new PLC_Toggle();
            Main.PLC_Decelerated_AR_Stop = new PLC_Toggle();
            Main.PLC_Immediate_DEC_Stop = new PLC_Toggle();
            Main.PLC_Immediate_AR_Stop = new PLC_Toggle();
            Main.PLC_Emergency_Stop = new PLC_Toggle();

            Main.PLC_Autoguide_Closed = new PLC_Label();
            Main.PLC_Autoguide_Opened = new PLC_Label();
            Main.PLC_Autoguide_Control = new PLC_Toggle();

            Main.PLC_Telescope_Closed = new PLC_Label();
            Main.PLC_Telescope_Opened = new PLC_Label();
            Main.PLC_Telescope_Cap_Bypass = new PLC_Toggle();
            Main.PLC_Telescope_FC_Bypass = new PLC_Toggle();
            Main.PLC_Telescope_Emergency_mode = new PLC_Toggle();
            Main.PLC_Telescope_Hook = new PLC_Toggle();
            Main.PLC_Telescope_Control = new PLC_Toggle();
            Main.PLC_Telescope_Power = new PLC_Toggle();

            Main.PLC_Meteo_Bypass = new PLC_Toggle();

            //DA CAMBIARE CON UNO SWITCH
            Main.PLC_ApriFaldaSX = new PLC_Label();
            Main.PLC_ApriFaldaDX = new PLC_Label();
            Main.PLC_ChiudiFaldaSX = new PLC_Label();
            Main.PLC_ChiudiFaldaDX = new PLC_Label();
            Main.PLC_ChiudiTetto = new PLC_Label();
            Main.PLC_ApriTetto = new PLC_Label();
            //FINE CAMBIARE CON UNO SWITCH

            InitializeComponent();
            InitializeTelescopeStatus();
            InitializeMotorsStatus();
            InitializeParkingStatus();
            InitializeVertigoStatus();
            InitializeUPS();
            InitializeRoof();
            InitializeServerStatus();
            InitializeBypassStatus();
            InitializeAutoGuideStatus();
            InitializeRoofRight();
            InitializeRoofLeft();
            StartUpdateTimer();
            lbl_Osservatorio.Text = VPN_AdapterName;
        }
        private void InitializeAutoGuideStatus()
        {
            PLC_Autoguide_Closed.TopLevel = false;
            PLC_Autoguide_Opened.TopLevel = false;
            PLC_Autoguide_Control.TopLevel = false;
            this.Grp_Autoguida.Controls.Add(PLC_Autoguide_Closed);
            this.Grp_Autoguida.Controls.Add(PLC_Autoguide_Opened);
            this.Grp_Autoguida.Controls.Add(PLC_Autoguide_Control);

            PLC_Autoguide_Closed.Show();
            PLC_Autoguide_Opened.Show();
            PLC_Autoguide_Control.Show();
            PLC_Autoguide_Closed.Location = new System.Drawing.Point(50, 50);
            PLC_Autoguide_Opened.Location = new System.Drawing.Point(300, 50);
            PLC_Autoguide_Control.Location = new System.Drawing.Point(50, 100);
            PLC_Autoguide_Closed.Name = "PLC_Autoguide_Closed";
            PLC_Autoguide_Opened.Name = "PLC_Autoguide_Opened";
            PLC_Autoguide_Control.Name = "PLC_Autguide_Control";
            PLC_Autoguide_Closed.PLCVariableName = "Autoguide Closed";
            PLC_Autoguide_Opened.PLCVariableName = "Autoguide Opened";
            PLC_Autoguide_Control.PLCVariableName = "Autoguide Control";
            PLC_Autoguide_Closed.PLCVariablePath = "TCPIP.S7-200.TelescopeCap.IAutoguideCapClosed";
            PLC_Autoguide_Opened.PLCVariablePath = "TCPIP.S7-200.TelescopeCap.IAutoguideCapOpen";
            PLC_Autoguide_Control.PLCVariablePath = "TCPIP.S7-200.TelescopeCap.OTelescopeCapAutoguideControl";
            PLC_Autoguide_Closed.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Autoguide_Opened.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Autoguide_Control.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Autoguide_Closed.RedOnValue = true;
            PLC_Autoguide_Opened.RedOnValue = true;
        }
        private void InitializeBypassStatus()
        {
            PLC_Telescope_Cap_Bypass.TopLevel = false;
            PLC_Telescope_FC_Bypass.TopLevel = false;
            PLC_Telescope_Emergency_mode.TopLevel = false;
            PLC_Vertigo_RoofOpen_Bypass.TopLevel = false;
            PLC_UPS_Alarm_Bypass.TopLevel = false;
            PLC_Toggle_Vertigo_KeepAlive_Bypass.TopLevel = false;
            PLC_Meteo_Bypass.TopLevel = false;
            this.Grp_Bypass.Controls.Add(PLC_Telescope_FC_Bypass);
            this.Grp_Bypass.Controls.Add(PLC_Telescope_Emergency_mode);
            this.Grp_Bypass.Controls.Add(PLC_Telescope_Cap_Bypass);
            this.Grp_Bypass.Controls.Add(PLC_Vertigo_RoofOpen_Bypass);
            this.Grp_Bypass.Controls.Add(PLC_UPS_Alarm_Bypass);
            this.Grp_Bypass.Controls.Add(PLC_Meteo_Bypass);
            PLC_Telescope_Cap_Bypass.Show();
            PLC_Telescope_FC_Bypass.Show();
            PLC_Telescope_Emergency_mode.Show();
            PLC_Vertigo_RoofOpen_Bypass.Show();
            PLC_UPS_Alarm_Bypass.Show();
            PLC_Toggle_Vertigo_KeepAlive_Bypass.Show();
            PLC_Meteo_Bypass.Show();
            PLC_Telescope_Cap_Bypass.Location = new System.Drawing.Point(50, 50);
            PLC_Telescope_FC_Bypass.Location = new System.Drawing.Point(50, 100);
            PLC_Meteo_Bypass.Location = new System.Drawing.Point(50, 150);
            PLC_Telescope_Emergency_mode.Location = new System.Drawing.Point(300, 50);
            PLC_Vertigo_RoofOpen_Bypass.Location = new System.Drawing.Point(300, 100);
            PLC_UPS_Alarm_Bypass.Location = new System.Drawing.Point(550, 50);
            PLC_Toggle_Vertigo_KeepAlive_Bypass.Location = new System.Drawing.Point(550, 100);
            PLC_Telescope_Cap_Bypass.Name = "PLC_Telescope_Cap_Bypass";
            PLC_Telescope_FC_Bypass.Name = "PLC_Telescope_FC_Bypass";
            PLC_Telescope_Emergency_mode.Name = "PLC_Telescope_Emercency_mode";
            PLC_Vertigo_RoofOpen_Bypass.Name = "PLC_Vertigo_RoofOpen_Bypass";
            PLC_UPS_Alarm_Bypass.Name = "PLC_UPS_Alarm_Bypass";
            PLC_Toggle_Vertigo_KeepAlive_Bypass.Name = "PLC_Vertigo_KeepAlive_Bypass";
            PLC_Meteo_Bypass.Name = "PLC_Meteo_Bypass";
            PLC_Telescope_FC_Bypass.PLCVariableName = "FC Telescope Bypass";
            PLC_Telescope_Cap_Bypass.PLCVariableName = "Safe Cap Bypass";
            PLC_Vertigo_RoofOpen_Bypass.PLCVariableName = "Vertigo Roof Open Bypass";
            PLC_UPS_Alarm_Bypass.PLCVariableName = "UPS Alarm Bypass";
            PLC_Toggle_Vertigo_KeepAlive_Bypass.PLCVariableName = "Vertigo KeepAlive Bypass";
            PLC_Meteo_Bypass.PLCVariableName = "Meteo Bypass";
            PLC_Telescope_Cap_Bypass.PLCVariablePath = "TCPIP.S7-200.TelescopeCap.MTelescopeCapBypass";
            PLC_Telescope_FC_Bypass.PLCVariablePath = "TCPIP.S7-200.Bypass.MFCTelescopeBypass";
            PLC_Telescope_Emergency_mode.PLCVariablePath = "TCPIP.S7-200.SecurityChain.EmergencyMode";
            PLC_Vertigo_RoofOpen_Bypass.PLCVariablePath = "TCPIP.S7-200.Bypass.MApertoVertigoBypass";
            PLC_UPS_Alarm_Bypass.PLCVariablePath = "TCPIP.S7-200.Bypass.MAlmUPSBypass";
            PLC_Toggle_Vertigo_KeepAlive_Bypass.PLCVariablePath = "TCPIP.S7-200.Bypass.MalmVertigoBypass";
            PLC_Meteo_Bypass.PLCVariablePath = "TCPIP.S7-200.Bypass.MalMeteoBypass";
            PLC_Telescope_Cap_Bypass.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Telescope_Cap_Bypass.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Telescope_Emergency_mode.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Vertigo_RoofOpen_Bypass.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_UPS_Alarm_Bypass.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Toggle_Vertigo_KeepAlive_Bypass.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Meteo_Bypass.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
        }
        private void InitializeTelescopeStatus()
        {

            PLC_Telescope_Closed.TopLevel = false;
            PLC_Telescope_Opened.TopLevel = false;
            PLC_Telescope_Hook.TopLevel = false;
            PLC_Telescope_Control.TopLevel = false;
            PLC_Telescope_Power.TopLevel = false;

            this.Grp_Telescopio.Controls.Add(PLC_Telescope_Closed);
            this.Grp_Telescopio.Controls.Add(PLC_Telescope_Opened);
            this.Grp_Telescopio.Controls.Add(PLC_Telescope_Hook);
            this.Grp_Telescopio.Controls.Add(PLC_Telescope_Control);
            this.Grp_Telescopio.Controls.Add(PLC_Telescope_Power);

            PLC_Telescope_Closed.Show();
            PLC_Telescope_Opened.Show();
            PLC_Telescope_Hook.Show();
            PLC_Telescope_Control.Show();
            PLC_Telescope_Power.Show();
            PLC_Telescope_Closed.Location = new System.Drawing.Point(50, 50);
            PLC_Telescope_Hook.Location = new System.Drawing.Point(50, 100);
            PLC_Telescope_Opened.Location = new System.Drawing.Point(300, 50);
            PLC_Telescope_Control.Location = new System.Drawing.Point(300, 100);
            PLC_Telescope_Power.Location = new System.Drawing.Point(550, 50);

            PLC_Telescope_Closed.Name = "PLC_Telescope_Closed";
            PLC_Telescope_Opened.Name = "PLC_Telescope_Opened";
            PLC_Telescope_Hook.Name = "PLC_Telescope_Hook";
            PLC_Telescope_Control.Name = "PLC_Telescope_Control";
            PLC_Telescope_Power.Name = "PLC_Telescope_Power";

            PLC_Telescope_Closed.PLCVariableName = "Telescope Closed";
            PLC_Telescope_Opened.PLCVariableName = "Telescope Opened";
            PLC_Telescope_Hook.PLCVariableName = "Hook";
            PLC_Telescope_Control.PLCVariableName = "Telescope Control";
            PLC_Telescope_Power.PLCVariableName = "Telescope Power";

            PLC_Telescope_Emergency_mode.PLCVariableName = "Emergency Mode";

            PLC_Telescope_Closed.PLCVariablePath = "TCP.S7-200.TelescopeCap.ITelescopeCapClosed";
            PLC_Telescope_Opened.PLCVariablePath = "TCPIP.S7-200.TelescopeCap.ITelescopeCapOpen";
            PLC_Telescope_Hook.PLCVariablePath = "TCPIP.S7-200.TelescopeCap.OTelescopeCapHook";
            PLC_Telescope_Control.PLCVariablePath = "TCPIP.S7-200.TelescopeCap.OTelescopeCapControl";
            PLC_Telescope_Power.PLCVariablePath = "TCPIP.S7-200.TelescopeCap.OTelescopeCapPower";

            PLC_Telescope_Closed.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Telescope_Opened.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Telescope_Hook.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Telescope_Control.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Telescope_Power.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;

            PLC_Telescope_Closed.RedOnValue = true;
            PLC_Telescope_Opened.RedOnValue = true;
            PLC_Autoguide_Closed.Modifiable = false;
            PLC_Autoguide_Opened.Modifiable = false;
            PLC_Telescope_Closed.Modifiable = false;
            PLC_Telescope_Opened.Modifiable = false;
        }
        private void InitializeMotorsStatus()
        {
            PLC_DEC_Direction.TopLevel = false;
            PLC_AR_Direction.TopLevel = false;
            PLC_DEC_Error.TopLevel = false;
            PLC_AR_Error.TopLevel = false;
            PLC_DEC_Run.TopLevel = false;
            PLC_AR_Run.TopLevel = false;
            PLC_Decelerated_DEC_Stop.TopLevel = false;
            PLC_Decelerated_AR_Stop.TopLevel = false;
            PLC_Immediate_DEC_Stop.TopLevel = false;
            PLC_Immediate_AR_Stop.TopLevel = false;
            PLC_Emergency_Stop.TopLevel = false;
            this.Grp_Motori.Controls.Add(PLC_DEC_Direction);
            this.Grp_Motori.Controls.Add(PLC_AR_Direction);
            this.Grp_Motori.Controls.Add(PLC_DEC_Error);
            this.Grp_Motori.Controls.Add(PLC_AR_Error);
            this.Grp_Motori.Controls.Add(PLC_DEC_Run);
            this.Grp_Motori.Controls.Add(PLC_AR_Run);
            this.Grp_Motori.Controls.Add(PLC_Decelerated_DEC_Stop);
            this.Grp_Motori.Controls.Add(PLC_Decelerated_AR_Stop);
            this.Grp_Motori.Controls.Add(PLC_Immediate_DEC_Stop);
            this.Grp_Motori.Controls.Add(PLC_Immediate_AR_Stop);
            this.Grp_Motori.Controls.Add(PLC_Emergency_Stop);
            PLC_DEC_Direction.Show();
            PLC_AR_Direction.Show();
            PLC_DEC_Error.Show();
            PLC_AR_Error.Show();
            PLC_DEC_Run.Show();
            PLC_AR_Run.Show();
            PLC_Decelerated_DEC_Stop.Show();
            PLC_Decelerated_AR_Stop.Show();
            PLC_Immediate_DEC_Stop.Show();
            PLC_Immediate_AR_Stop.Show();
            PLC_Emergency_Stop.Show();
            PLC_Emergency_Stop.ForeColor = Color.Red;
            PLC_Emergency_Stop.BackColor = Color.Red;
            PLC_Emergency_Stop.BackgroundColor = Color.Red;
            PLC_Emergency_Stop.Font = new System.Drawing.Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            PLC_DEC_Direction.Location = new System.Drawing.Point(50, 50);
            PLC_AR_Direction.Location = new System.Drawing.Point(300, 50);
            PLC_DEC_Error.Location = new System.Drawing.Point(50, 100);
            PLC_AR_Error.Location = new System.Drawing.Point(300, 100);
            PLC_DEC_Run.Location = new System.Drawing.Point(550, 50);
            PLC_AR_Run.Location = new System.Drawing.Point(550, 100);
            PLC_Decelerated_DEC_Stop.Location = new System.Drawing.Point(800, 50);
            PLC_Immediate_DEC_Stop.Location = new System.Drawing.Point(800, 100);
            PLC_Decelerated_AR_Stop.Location = new System.Drawing.Point(1050, 50);
            PLC_Immediate_AR_Stop.Location = new System.Drawing.Point(1050,100);
            PLC_Emergency_Stop.Location = new System.Drawing.Point(1300, 50);
            PLC_DEC_Direction.Modifiable = true;
            PLC_AR_Direction.Modifiable = true;
            PLC_DEC_Error.Modifiable = false;
            PLC_AR_Error.Modifiable = false;
            PLC_DEC_Direction.Name = "PLC_DEC_Direction";
            PLC_AR_Direction.Name = "PLC_AR_Direction";
            PLC_DEC_Error.Name = "PLC_DEC_Error";
            PLC_AR_Error.Name = "PLC_AR_Error";
            PLC_DEC_Run.Name = "PLC_DEC_Run";
            PLC_Immediate_DEC_Stop.Name = "PLC_Immediate_DEC_Stop";
            PLC_Immediate_AR_Stop.Name = "PLC_Immediate_AR_Stop";
            PLC_Decelerated_AR_Stop.Name = "PLC_Decelerated_AR_Stop";
            PLC_Decelerated_DEC_Stop.Name = "PLC_Decelerated_DEC_Stop";
            PLC_Emergency_Stop.Name = "PLC_Emercency_Stop";
            PLC_DEC_Direction.PLCVariableName = "DEC Direction";
            PLC_AR_Direction.PLCVariableName = "AR Direction";
            PLC_DEC_Error.PLCVariableName = "DEC Error";
            PLC_AR_Error.PLCVariableName = "AR Error";
            PLC_DEC_Run.PLCVariableName = "Declination Run";
            PLC_AR_Run.PLCVariableName = "Right Ascension Run";
            PLC_Decelerated_DEC_Stop.PLCVariableName = "DEC Decelerated Stop";
            PLC_Immediate_DEC_Stop.PLCVariableName = "DEC Immediate Stop";
            PLC_Immediate_AR_Stop.PLCVariableName = "AR Immediate Stop";
            PLC_Decelerated_AR_Stop.PLCVariableName = "AR Decelerated Stop";
            PLC_Emergency_Stop.PLCVariableName = "PLC EMERCENCY STOP";
            PLC_DEC_Direction.PLCVariablePath = "TCPIP.S7-200.TMotors.Dec.MotorDecParkDirection";
            PLC_AR_Direction.PLCVariablePath = "TCPIP.S7-200.TMotors.AR.MotorRAParkDirection";
            PLC_DEC_Error.PLCVariablePath = "TCPIP.S7-200.TMotors.Dec.MotorDECError";
            PLC_AR_Error.PLCVariablePath = "TCPIP.S7-200.TMotors.AR.MotorRAError";
            PLC_DEC_Run.PLCVariablePath = "TCPIP.S7-200.TMotors.Dec.MotorDECRun";
            PLC_AR_Run.PLCVariablePath = "TCPIP.S7-200.TMotors.AR.MotorRARun";
            PLC_Decelerated_DEC_Stop.PLCVariablePath = "TCPIP.S7-200.TMotors.Dec.MotorDECDStop";
            PLC_Immediate_DEC_Stop.PLCVariablePath = "TCPIP.S7-200.TMotors.Dec.MotorDECIStop";
            PLC_Decelerated_AR_Stop.PLCVariablePath = "TCPIP.S7-200.TMotors.AR.MotorRADDStop";
            PLC_Immediate_AR_Stop.PLCVariablePath = "TCPIP.S7-200.TMotors.AR.Motor.RAIStop";
            PLC_Emergency_Stop.PLCVariablePath = "TCPIP.S7-200.SecurityChain.InhibitPLC";
            PLC_DEC_Direction.RedOnValue = true;
            PLC_DEC_Error.RedOnValue = true;
            PLC_AR_Direction.RedOnValue = true;
            PLC_AR_Error.RedOnValue = true;
            PLC_DEC_Direction.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_DEC_Error.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_INT;
            PLC_AR_Error.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_INT;
            PLC_AR_Direction.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_DEC_Run.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Decelerated_DEC_Stop.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Immediate_DEC_Stop.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_AR_Run.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Decelerated_AR_Stop.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Immediate_AR_Stop.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Emergency_Stop.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
        }
        private void InitializeParkingStatus()
        {
            PLC_FineCorsa_AR_Parking.TopLevel = false;
            PLC_FineCorsa_DEC_Parking.TopLevel = false;
            this.Grp_Parking.Controls.Add(PLC_FineCorsa_AR_Parking);
            this.Grp_Parking.Controls.Add(PLC_FineCorsa_DEC_Parking);
            PLC_FineCorsa_AR_Parking.Show();
            PLC_FineCorsa_DEC_Parking.Show();
            PLC_FineCorsa_AR_Parking.Location = new System.Drawing.Point(20, 20);
            PLC_FineCorsa_DEC_Parking.Location = new System.Drawing.Point(20, 80);
            PLC_FineCorsa_AR_Parking.Modifiable = false;
            PLC_FineCorsa_DEC_Parking.Modifiable = false;
            PLC_FineCorsa_AR_Parking.Name = "PLC_FineCorsa_AR_Parking";
            PLC_FineCorsa_DEC_Parking.Name = "PLC_FineCorsa_DEC_Parking";
            PLC_FineCorsa_AR_Parking.RedOnValue = false;
            PLC_FineCorsa_DEC_Parking.RedOnValue = false;
            PLC_FineCorsa_AR_Parking.PLCVariablePath = "TCPIP.S7-200.Parking.ISondaRAPark";
            PLC_FineCorsa_DEC_Parking.PLCVariablePath = "TCPIP.S7-200.Parking.ISondaDECPark";
            PLC_FineCorsa_AR_Parking.PLCVariableName = "Fine Corsa AR Parking";
            PLC_FineCorsa_DEC_Parking.PLCVariableName = "Fine Corsa DEC Parking";
            PLC_FineCorsa_AR_Parking.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_FineCorsa_DEC_Parking.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
        }
        private void InitializeVertigoStatus()
        {
            PLC_VertigoTettoChiuso.TopLevel = false;
            PLC_VertigoTettoAperto.TopLevel = false;
            PLC_VertigoAllarmeTetto.TopLevel = false;
            PLC_VertigoChiudiTetto.TopLevel = false;
            PLC_VertigoApriTetto.TopLevel = false;
            PLC_Alarm_Vertigo_KeepAlive.TopLevel = false;
            this.grp_Vertigo.Controls.Add(PLC_VertigoTettoChiuso);
            this.grp_Vertigo.Controls.Add(PLC_VertigoTettoAperto);
            this.grp_Vertigo.Controls.Add(PLC_VertigoAllarmeTetto);
            this.grp_Vertigo.Controls.Add(PLC_VertigoChiudiTetto);
            this.grp_Vertigo.Controls.Add(PLC_VertigoApriTetto);
            this.grp_Vertigo.Controls.Add(PLC_Alarm_Vertigo_KeepAlive);
            PLC_VertigoTettoChiuso.Show();
            PLC_VertigoTettoAperto.Show();
            PLC_VertigoAllarmeTetto.Show();
            PLC_VertigoChiudiTetto.Show();
            PLC_VertigoApriTetto.Show();
            PLC_Alarm_Vertigo_KeepAlive.Show();
            PLC_VertigoTettoChiuso.Location = new System.Drawing.Point(50, 50);
            PLC_VertigoTettoAperto.Location = new System.Drawing.Point(300, 50);
            PLC_VertigoAllarmeTetto.Location = new System.Drawing.Point(50, 100);
            PLC_VertigoApriTetto.Location = new System.Drawing.Point(300, 100);
            PLC_VertigoChiudiTetto.Location = new System.Drawing.Point(550, 50);
            PLC_Alarm_Vertigo_KeepAlive.Location = new System.Drawing.Point(550, 100);
            PLC_VertigoTettoChiuso.PLCVariableName = "Segnale Tetto Chiuso";
            PLC_VertigoTettoAperto.PLCVariableName = "Segnale Tetto Aperto";
            PLC_VertigoAllarmeTetto.PLCVariableName = " Segnale Allarme Tetto";
            PLC_VertigoChiudiTetto.PLCVariableName = "Segnale Chiudi Tetto";
            PLC_VertigoApriTetto.PLCVariableName = "Segnale Apri Tetto";
            PLC_Alarm_Vertigo_KeepAlive.PLCAlarmName = "Keepalive Alarm";
            PLC_VertigoTettoChiuso.Name = "PLC_VertigoTettoChiuso";
            PLC_VertigoTettoAperto.Name = "PLC_VertigoTettoAperto";
            PLC_VertigoAllarmeTetto.Name = "PLC_VertigoAllarmeTetto";
            PLC_VertigoChiudiTetto.Name = "PLC_VertigoChiudiTetto";
            PLC_VertigoApriTetto.Name = "PLC_VertigoApriTetto";
            PLC_Alarm_Vertigo_KeepAlive.Name = "LC_Alarm_Vertigo_KeepAlive";
            PLC_VertigoTettoChiuso.PLCVariablePath = "TCPIP.S7-200.Vertigo.RoofIsClosedVertigo";
            PLC_VertigoTettoAperto.PLCVariablePath = "TCPIP.S7-200.Vertigo.RoofIsOpenVertigo";
            PLC_VertigoAllarmeTetto.PLCVariablePath = "TCPIP.S7-200.Vertigo.RoofAlarmVertigo";
            PLC_VertigoChiudiTetto.PLCVariablePath = "TCPIP.S7-200.Vertigo.CloseRoofVertigo";
            PLC_VertigoApriTetto.PLCVariablePath = "TCP.S7-200.Vertigo.OpenRoofVertigo";
            PLC_Alarm_Vertigo_KeepAlive.PLCVariablePath = "TCPIP.S7-200.Vertigo.AlmVertigoNoAlive";
            PLC_VertigoTettoChiuso.RedOnValue = false;
            PLC_VertigoTettoAperto.RedOnValue = true;
            PLC_VertigoAllarmeTetto.RedOnValue = true;
            PLC_VertigoChiudiTetto.RedOnValue = true;
            PLC_VertigoApriTetto.RedOnValue = true;
            PLC_Alarm_Vertigo_KeepAlive.ResetAvailable = false;
            PLC_VertigoTettoChiuso.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_VertigoTettoAperto.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_VertigoAllarmeTetto.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_VertigoChiudiTetto.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_VertigoApriTetto.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Alarm_Vertigo_KeepAlive.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
        }
        private void InitializeServerStatus()
        {
            Server_KeepAlive.TopLevel = false;
            this.grp_Server.Controls.Add(Server_KeepAlive);
            Server_KeepAlive.Show();
            Server_KeepAlive.Location = new System.Drawing.Point(20, 20);
            Server_KeepAlive.Name = "Server_KeepAlive";
            Server_KeepAlive.PLCVariablePath="TCPIP.S7-200.Server.KeepaliveValue";
            Server_KeepAlive.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_UI8;
        }
        private void InitializeRoofRight()
        {
            PLC_ApriFaldaDX.TopLevel = false;
            PLC_ChiudiFaldaDX.TopLevel = false;
            PLC_FineCorsaAperturaDX.TopLevel = false;
            PLC_FineCorsaChiusuraDX.TopLevel = false;
            this.Grp_faldaDX.Controls.Add(PLC_ApriFaldaDX);
            this.Grp_faldaDX.Controls.Add(PLC_ChiudiFaldaDX);
            this.Grp_faldaDX.Controls.Add(PLC_FineCorsaAperturaDX);
            this.Grp_faldaDX.Controls.Add(PLC_FineCorsaChiusuraDX);
            PLC_ApriFaldaDX.Show();
            PLC_ChiudiFaldaDX.Show();
            PLC_FineCorsaAperturaDX.Show();
            PLC_FineCorsaChiusuraDX.Show();
            PLC_ApriFaldaDX.PLCVariableName = "Apri Falda Destra";
            PLC_ChiudiFaldaDX.PLCVariableName = "Chiudi Falda Destra";
            PLC_FineCorsaAperturaDX.PLCVariableName = "Finecorsa Apertura Destra";
            PLC_FineCorsaChiusuraDX.PLCVariableName = "Finecorsa Chiusura Destra";
            PLC_ApriFaldaDX.Location = new System.Drawing.Point(50, 50);
            PLC_ChiudiFaldaDX.Location = new System.Drawing.Point(300, 50);
            PLC_FineCorsaAperturaDX.Location = new System.Drawing.Point(50, 100);
            PLC_FineCorsaChiusuraDX.Location = new System.Drawing.Point(300,100);
            PLC_ApriFaldaDX.Name = "PLC_ApriFaldaDX";
            PLC_ChiudiFaldaDX.Name = "PLC_ChiudiFaldaDX";
            PLC_FineCorsaAperturaDX.Name = "PLC_FineCorsaAperturaDX";
            PLC_FineCorsaChiusuraDX.Name = "PLC_FineCorsaChiusuraDX";
            PLC_ApriFaldaDX.PLCVariablePath = "TCPIP.S7.200.Roof.ApriFaldaDX";
            PLC_ChiudiFaldaDX.PLCVariablePath = "TCPIP.S7-200.Roof.ChiudiFaldaDX";
            PLC_FineCorsaAperturaDX.PLCVariablePath = "TCPIP.S7-200.Roof.FC_FaldaDXApertura";
            PLC_FineCorsaChiusuraDX.PLCVariablePath = "TCPIP.S7-200.Roof.FC_FaldaDXChiusura";
            PLC_ApriFaldaDX.RedOnValue = true;
            PLC_ChiudiFaldaDX.RedOnValue = true;
            PLC_FineCorsaAperturaDX.RedOnValue = true;
            PLC_FineCorsaChiusuraDX.RedOnValue = true;
            PLC_ApriFaldaDX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_ChiudiFaldaDX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_FineCorsaAperturaDX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_FineCorsaChiusuraDX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
        }
        private void InitializeRoofLeft()
        {
            PLC_ApriFaldaSX.TopLevel = false;
            PLC_ChiudiFaldaSX.TopLevel = false;
            PLC_FineCorsaAperturaSX.TopLevel = false;
            PLC_FineCorsaChiusuraSX.TopLevel = false;
            this.Grp_FaldaSX.Controls.Add(PLC_ApriFaldaSX);
            this.Grp_FaldaSX.Controls.Add(PLC_ChiudiFaldaSX);
            this.Grp_FaldaSX.Controls.Add(PLC_FineCorsaAperturaSX);
            this.Grp_FaldaSX.Controls.Add(PLC_FineCorsaChiusuraSX);
            PLC_ApriFaldaSX.Show();
            PLC_ChiudiFaldaSX.Show();
            PLC_FineCorsaAperturaSX.Show();
            PLC_FineCorsaChiusuraSX.Show();
            PLC_ChiudiFaldaSX.PLCVariableName = "Chiudi Falda Sinistra";
            PLC_ApriFaldaSX.PLCVariableName = "Apri Falda Sinistra";
            PLC_FineCorsaAperturaSX.PLCVariableName = "Finecorsa Apertura Sinistra";
            PLC_FineCorsaChiusuraSX.PLCVariableName = "Finecorsa Chiusura Sinistra";
            PLC_ApriFaldaSX.Location = new System.Drawing.Point(50, 50);
            PLC_ChiudiFaldaSX.Location = new System.Drawing.Point(300, 50);
            PLC_FineCorsaAperturaSX.Location = new System.Drawing.Point(50, 100);
            PLC_FineCorsaChiusuraSX.Location = new System.Drawing.Point(300, 100);
            PLC_ApriFaldaSX.Name = "PLC_ApriFaldaSX";
            PLC_ChiudiFaldaSX.Name = "PLC_ChiudiFaldaSX";
            PLC_FineCorsaAperturaSX.Name = "PLC_FineCorsaAperturaSX";
            PLC_FineCorsaChiusuraSX.Name = "PLC_FineCorsaChiusuraSX";
            PLC_ApriFaldaSX.PLCVariablePath = "TCPIP.S7-200.Roof.ApriFaldaSX";
            PLC_ChiudiFaldaSX.PLCVariablePath = "TCPIP.S7-200.Roof.ChiudiFaldaSX";
            PLC_FineCorsaAperturaSX.PLCVariablePath = "TCPIP.S7-200.Roof.FC_FaldaSXApertura";
            PLC_FineCorsaChiusuraSX.PLCVariablePath = "TCPIP.S7-200.Roof.FC_FaldaSXChiusura";
            PLC_ApriFaldaSX.RedOnValue = true;
            PLC_ChiudiFaldaSX.RedOnValue = true;
            PLC_FineCorsaAperturaSX.RedOnValue = true;
            PLC_FineCorsaChiusuraSX.RedOnValue = true;
            PLC_ApriFaldaSX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_ChiudiFaldaSX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_FineCorsaAperturaSX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_FineCorsaChiusuraSX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
        }
        private void InitializeRoof()
        {
            PLC_NoResetTermici.TopLevel = false;
            PLC_Cicalini.TopLevel = false;
            PLC_ChiudiTetto.TopLevel = false;
            PLC_ApriTetto.TopLevel = false;
            PLC_CicaliniMute.TopLevel = false;
            PLC_Reset_Termici.TopLevel = false;
            PLC_Reset_Counter_Termici.TopLevel = false;
            PLC_Tetto_Chiusura_Timeout.TopLevel = false;
            PLC_Tetto_Apertura_Timeout.TopLevel = false;
            PLC_Tetto_Termico.TopLevel = false;
            this.Grp_Tetto.Controls.Add(PLC_NoResetTermici);
            this.Grp_Tetto.Controls.Add(PLC_Reset_Termici);
            this.Grp_Tetto.Controls.Add(PLC_Cicalini);
            this.Grp_Tetto.Controls.Add(PLC_CicaliniMute);
            this.Grp_Tetto.Controls.Add(PLC_ChiudiTetto);
            this.Grp_Tetto.Controls.Add(PLC_ApriTetto);
            this.Grp_Tetto.Controls.Add(PLC_Reset_Counter_Termici);
            this.Grp_Tetto.Controls.Add(PLC_Tetto_Chiusura_Timeout);
            this.Grp_Tetto.Controls.Add(PLC_Tetto_Apertura_Timeout);
            this.Grp_Tetto.Controls.Add(PLC_Tetto_Termico);
            PLC_NoResetTermici.Show();
            PLC_Cicalini.Show();
            PLC_CicaliniMute.Show();
            PLC_ChiudiTetto.Show();
            PLC_ApriTetto.Show();
            PLC_Reset_Termici.Show();
            PLC_Reset_Counter_Termici.Show();
            PLC_Tetto_Chiusura_Timeout.Show();
            PLC_Tetto_Apertura_Timeout.Show();
            PLC_Tetto_Termico.Show();
            PLC_NoResetTermici.PLCVariableName = "Numero Reset Termici";
            PLC_ChiudiTetto.PLCVariableName = "Chiudi Tetto";
            PLC_ApriTetto.PLCVariableName = "Apri Tetto";
            PLC_Cicalini.PLCVariableName = "Cicalini";
            PLC_CicaliniMute.PLCVariableName = "Mute";
            PLC_Reset_Termici.PLCVariableName = "Reset Termico";
            PLC_Reset_Counter_Termici.PLCVariableName = "Reset Contatore Termici";
            PLC_Tetto_Chiusura_Timeout.PLCAlarmName = "Timeout Chiusura";
            PLC_Tetto_Apertura_Timeout.PLCAlarmName = "Timeout Apertura";
            PLC_Tetto_Termico.PLCAlarmName = "Termica Motore";
            PLC_NoResetTermici.Location = new System.Drawing.Point(50, 50);
            PLC_Cicalini.Location = new System.Drawing.Point(50, 100);
            PLC_ApriTetto.Location = new System.Drawing.Point(300, 50);
            PLC_ChiudiTetto.Location = new System.Drawing.Point(300, 100);
            PLC_Reset_Termici.Location = new System.Drawing.Point(550, 50);
            PLC_CicaliniMute.Location = new System.Drawing.Point(550, 100);
            PLC_Reset_Counter_Termici.Location = new System.Drawing.Point(550, 150);
            PLC_Tetto_Chiusura_Timeout.Location = new System.Drawing.Point(800, 50);
            PLC_Tetto_Apertura_Timeout.Location = new System.Drawing.Point(800, 100);
            PLC_Tetto_Termico.Location = new System.Drawing.Point(800, 150);
            PLC_NoResetTermici.Name = "PLC_NoResetTermici";
            PLC_Cicalini.Name = "PLC_Cicalini";
            PLC_CicaliniMute.Name = "PLC_CicaliniMute";
            PLC_ChiudiTetto.Name = "PLC_ChiudiTetto";
            PLC_ApriTetto.Name = "PLC_ApriTetto";
            PLC_Reset_Termici.Name = "PLC_Reset_Termici";
            PLC_Reset_Counter_Termici.Name = "PLC_Reset_Counter_Termici";
            PLC_Tetto_Chiusura_Timeout.Name = "PLC_Tetto_Chiusura_Timeout";
            PLC_Tetto_Apertura_Timeout.Name = "PLC_Tetto_Apertura_Timeout";
            PLC_Tetto_Termico.Name = "PLC_Tetto_Termico";
            PLC_NoResetTermici.PLCVariablePath = "TCPIP.S7-200.Roof.ContantoreAlmTermici";
            PLC_Cicalini.PLCVariablePath = "TCPIP.S7-200.Roof.Cicalini";
            PLC_CicaliniMute.PLCVariablePath = "TCPIP.S7-200.Roof.CicaliniMute";
            PLC_ChiudiTetto.PLCVariablePath = "TCPIP.S7-200.Roof.ChiudiTetto";
            PLC_ApriTetto.PLCVariablePath = "TCPIP.S7-200.Roof.ApriTetto";
            PLC_Reset_Termici.PLCVariablePath = "TCPIP.S7-200.Roof.OResetTermico";
            PLC_Reset_Counter_Termici.PLCVariablePath = "TCPIP.S7-200.Roof.ResetContTermico";
            PLC_Tetto_Chiusura_Timeout.PLCVariablePath = "TCPIP.S7-200.Roof.AlmTimeoutFaldaChiusura";
            PLC_Tetto_Apertura_Timeout.PLCVariablePath = "TCPIP.S7-200.Roof.AlmTimeoutFaldaApertura";
            PLC_Tetto_Termico.PLCVariablePath = "TCPIP.S7-200.Roof.AlmTermico";
            PLC_NoResetTermici.RedOnValue = true;
            PLC_Cicalini.RedOnValue = true;
            PLC_ChiudiTetto.RedOnValue = true;
            PLC_ApriTetto.RedOnValue = true;
            PLC_Tetto_Chiusura_Timeout.ResetAvailable = true;
            PLC_Tetto_Apertura_Timeout.ResetAvailable = true;
            PLC_Tetto_Termico.ResetAvailable = false;
            PLC_Cicalini.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_ChiudiTetto.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_ApriTetto.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_CicaliniMute.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Reset_Termici.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Reset_Counter_Termici.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_NoResetTermici.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_INT;
            PLC_Tetto_Chiusura_Timeout.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Tetto_Apertura_Timeout.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Tetto_Termico.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
        }
        private void InitializeUPS()
        {
            PLC_Alarm_UPS_EchoMode.TopLevel = false;
            UPS_BatteryLow.TopLevel = false;
            UPS_LDInverter.TopLevel = false;
            UPS_Alarm.TopLevel = false;
            UPS_ConnectionFailure.TopLevel = false;
            UPS_MainFailure.TopLevel = false;
            UPS_ChargeValue.TopLevel = false;
            this.grpUPS.Controls.Add(PLC_Alarm_UPS_EchoMode);
            this.grpUPS.Controls.Add(UPS_BatteryLow);
            this.grpUPS.Controls.Add(UPS_LDInverter);
            this.grpUPS.Controls.Add(UPS_Alarm);
            this.grpUPS.Controls.Add(UPS_ConnectionFailure);
            this.grpUPS.Controls.Add(UPS_MainFailure);
            this.grpUPS.Controls.Add(UPS_ChargeValue);
            PLC_Alarm_UPS_EchoMode.Show();
            UPS_BatteryLow.Show();
            UPS_LDInverter.Show();
            UPS_Alarm.Show();
            UPS_ConnectionFailure.Show();
            UPS_MainFailure.Show();
            UPS_ChargeValue.Show();
            PLC_Alarm_UPS_EchoMode.PLCAlarmName = "Eco Mode Active";
            UPS_BatteryLow.PLCAlarmName = "Battery Low";
            UPS_LDInverter.PLCAlarmName = "Inverter Alarm";
            UPS_Alarm.PLCAlarmName = "General Alarm";
            UPS_ConnectionFailure.PLCAlarmName = "Connection Failure";
            UPS_MainFailure.PLCAlarmName = "Main Failure";
            UPS_ChargeValue.PLCVariableName = "UPS Charge";
            UPS_ChargeValue.MaxValue = 100;
            UPS_ChargeValue.MinValue = 0;
            PLC_Alarm_UPS_EchoMode.Location = new System.Drawing.Point(20, 20);
            UPS_BatteryLow.Location = new System.Drawing.Point(20, 70);
            UPS_LDInverter.Location = new System.Drawing.Point(20, 120);
            UPS_Alarm.Location = new System.Drawing.Point(20, 170);
            UPS_ConnectionFailure.Location = new System.Drawing.Point(340, 20);
            UPS_MainFailure.Location = new System.Drawing.Point(340, 70);
            UPS_ChargeValue.Location = new System.Drawing.Point(20, 290);
            PLC_Alarm_UPS_EchoMode.Name = "UPS_EchoMode";
            UPS_BatteryLow.Name = "UPS_BatteryLow";
            UPS_LDInverter.Name = "UPS_LDInverter";
            UPS_Alarm.Name = "UPS_Alarm";
            UPS_MainFailure.Name = "UPS_MainFailure";
            UPS_ConnectionFailure.Name = "UPS_ConnectionFailure";
            UPS_ChargeValue.Name = "UPS_ChargeValue";
            PLC_Alarm_UPS_EchoMode.PLCVariablePath = "TCPIP.S7-200.UPS.I_ECOMODE";
            UPS_BatteryLow.PLCVariablePath = "TCPIP.S7-200.UPS.I_BATTLOW";
            UPS_LDInverter.PLCVariablePath = "TCPIP.S7-200.UPS.I_LDINV";
            UPS_Alarm.PLCVariablePath = "TCPIP.S7-200.UPS.I_ALARM";
            UPS_ConnectionFailure.PLCVariablePath = "TCPIP.S7-200.UPS.AlmLinkFailure";
            UPS_MainFailure.PLCVariablePath = "TCPIP.S7-200.UPS.AlmMainsFailure";
            UPS_ChargeValue.PLCVariablePath = "TCPIP.S7-200.UPS.RemainingCapacity";
            PLC_Alarm_UPS_EchoMode.ResetAvailable = false;
            UPS_BatteryLow.ResetAvailable = false;
            UPS_LDInverter.ResetAvailable = false;
            UPS_Alarm.ResetAvailable = false;
            UPS_ConnectionFailure.ResetAvailable = false;
            UPS_MainFailure.ResetAvailable = false;
            PLC_Alarm_UPS_EchoMode.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            UPS_BatteryLow.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            UPS_LDInverter.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            UPS_Alarm.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            UPS_ConnectionFailure.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            UPS_MainFailure.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            UPS_ChargeValue.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_UINT;
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
