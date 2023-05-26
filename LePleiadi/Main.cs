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

            Main.UPS_EchoMode = new UPS_Alarm();
            Main.UPS_BatteryLow = new UPS_Alarm();
            Main.UPS_LDInverter = new UPS_Alarm();
            Main.UPS_Alarm = new UPS_Alarm();
            Main.UPS_ConnectionFailure = new UPS_Alarm();
            Main.UPS_MainFailure = new UPS_Alarm();
            Main.UPS_ChargeValue = new PLC_ProgressBar();

            Main.PLC_FineCorsaAperturaSX = new PLC_Label();
            Main.PLC_FineCorsaChiusuraSX = new PLC_Label();
            Main.PLC_FineCorsaAperturaDX = new PLC_Label();
            Main.PLC_FineCorsaChiusuraDX = new PLC_Label();
            Main.PLC_NoResetTermici = new PLC_Label();
            Main.PLC_Reset_Termici = new PLC_Toggle();
            Main.PLC_Cicalini = new PLC_Label();
            Main.PLC_CicaliniMute = new PLC_Toggle();
            Main.PLC_Reset_Counter_Termici = new PLC_Toggle();

            Main.Server_KeepAlive = new PLC_KeepAlive();

            Main.PLC_VertigoTettoChiuso = new PLC_Label();
            Main.PLC_VertigoTettoAperto = new PLC_Label();
            Main.PLC_VertigoAllarmeTetto = new PLC_Label();
            Main.PLC_VertigoChiudiTetto = new PLC_Label();
            Main.PLC_VertigoApriTetto = new PLC_Label();

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
            Main.PLC_Telescope_Closed = new PLC_Label();
            Main.PLC_Telescope_Opened = new PLC_Label();

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
            StartUpdateTimer();
            lbl_Osservatorio.Text = VPN_AdapterName;
        }
        private void InitializeTelescopeStatus()
        {
            PLC_Autoguide_Closed.TopLevel = false;
            PLC_Autoguide_Opened.TopLevel = false;
            PLC_Telescope_Closed.TopLevel = false;
            PLC_Telescope_Opened.TopLevel = false;
            this.Grp_Autoguida.Controls.Add(PLC_Autoguide_Closed);
            this.Grp_Autoguida.Controls.Add(PLC_Autoguide_Opened);
            this.Grp_Telescopio.Controls.Add(PLC_Telescope_Closed);
            this.Grp_Telescopio.Controls.Add(PLC_Telescope_Opened);
            PLC_Autoguide_Closed.Show();
            PLC_Autoguide_Opened.Show();
            PLC_Telescope_Closed.Show();
            PLC_Telescope_Opened.Show();
            PLC_Autoguide_Closed.Location = new System.Drawing.Point(20, 20);
            PLC_Autoguide_Opened.Location = new System.Drawing.Point(300, 20);
            PLC_Telescope_Closed.Location = new System.Drawing.Point(20, 20);
            PLC_Telescope_Opened.Location = new System.Drawing.Point(300, 20);
            PLC_Autoguide_Closed.Name = "PLC_Autoguide_Closed";
            PLC_Autoguide_Opened.Name = "PLC_Autoguide_Opened";
            PLC_Telescope_Closed.Name = "PLC_Telescope_Closed";
            PLC_Telescope_Opened.Name = "PLC_Telescope_Opened";
            PLC_Autoguide_Closed.PLCVariableName = "Autoguide Closed";
            PLC_Autoguide_Opened.PLCVariableName = "Autoguide Opened";
            PLC_Telescope_Closed.PLCVariableName = "Telescope Closed";
            PLC_Telescope_Opened.PLCVariableName = "Telescope Opened";
            PLC_Autoguide_Closed.PLCVariablePath = "TCPIP.S7-200.TelescopeCap.IAutoguideCapClosed";
            PLC_Autoguide_Opened.PLCVariablePath = "TCPIP.S7-200.TelescopeCap.IAutoguideCapOpen";
            PLC_Telescope_Closed.PLCVariablePath = "TCP.S7-200.TelescopeCap.ITelescopeCapClosed";
            PLC_Telescope_Opened.PLCVariablePath = "TCPIP.S7-200.TelescopeCap.ITelescopeCapOpen";
            PLC_Autoguide_Closed.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Autoguide_Opened.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Telescope_Closed.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Telescope_Opened.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Autoguide_Closed.RedOnValue = true;
            PLC_Autoguide_Opened.RedOnValue = true;
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
           // PLC_Emergency_Stop.Font= new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            PLC_Emergency_Stop.PLCVariableName = "EMERCENCY STOP";
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
            this.grp_Vertigo.Controls.Add(PLC_VertigoTettoChiuso);
            this.grp_Vertigo.Controls.Add(PLC_VertigoTettoAperto);
            this.grp_Vertigo.Controls.Add(PLC_VertigoAllarmeTetto);
            this.grp_Vertigo.Controls.Add(PLC_VertigoChiudiTetto);
            this.grp_Vertigo.Controls.Add(PLC_VertigoApriTetto);
            PLC_VertigoTettoChiuso.Show();
            PLC_VertigoTettoAperto.Show();
            PLC_VertigoAllarmeTetto.Show();
            PLC_VertigoChiudiTetto.Show();
            PLC_VertigoApriTetto.Show();
            PLC_VertigoTettoChiuso.Location = new System.Drawing.Point(20, 20);
            PLC_VertigoTettoAperto.Location = new System.Drawing.Point(200, 20);
            PLC_VertigoAllarmeTetto.Location = new System.Drawing.Point(20, 80);
            PLC_VertigoApriTetto.Location = new System.Drawing.Point(200, 80);
            PLC_VertigoChiudiTetto.Location = new System.Drawing.Point(380, 80);
            PLC_VertigoTettoChiuso.PLCVariableName = "Segnale Tetto Chiuso";
            PLC_VertigoTettoAperto.PLCVariableName = "Segnale Tetto Aperto";
            PLC_VertigoAllarmeTetto.PLCVariableName = " Segnale Allarme Tetto";
            PLC_VertigoChiudiTetto.PLCVariableName = "Segnale Chiudi Tetto";
            PLC_VertigoApriTetto.PLCVariableName = "Segnale Apri Tetto";
            PLC_VertigoTettoChiuso.Name = "PLC_VertigoTettoChiuso";
            PLC_VertigoTettoAperto.Name = "PLC_VertigoTettoAperto";
            PLC_VertigoAllarmeTetto.Name = "PLC_VertigoAllarmeTetto";
            PLC_VertigoChiudiTetto.Name = "PLC_VertigoChiudiTetto";
            PLC_VertigoApriTetto.Name = "PLC_VertigoApriTetto";
            PLC_VertigoTettoChiuso.PLCVariablePath = "TCPIP.S7-200.Vertigo.RoofIsClosedVertigo";
            PLC_VertigoTettoAperto.PLCVariablePath = "TCPIP.S7-200.Vertigo.RoofIsOpenVertigo";
            PLC_VertigoAllarmeTetto.PLCVariablePath = "TCPIP.S7-200.Vertigo.RoofAlarmVertigo";
            PLC_VertigoChiudiTetto.PLCVariablePath = "TCPIP.S7-200.Vertigo.CloseRoofVertigo";
            PLC_VertigoApriTetto.PLCVariablePath = "TCP.S7-200.Vertigo.OpenRoofVertigo";
            PLC_VertigoTettoChiuso.RedOnValue = false;
            PLC_VertigoTettoAperto.RedOnValue = true;
            PLC_VertigoAllarmeTetto.RedOnValue = true;
            PLC_VertigoChiudiTetto.RedOnValue = true;
            PLC_VertigoApriTetto.RedOnValue = true;
            PLC_VertigoTettoChiuso.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_VertigoTettoAperto.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_VertigoAllarmeTetto.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_VertigoChiudiTetto.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_VertigoApriTetto.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
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
        private void InitializeRoof()
        {
            PLC_ApriFaldaSX.TopLevel = false;
            PLC_ApriFaldaDX.TopLevel = false;
            PLC_ChiudiFaldaSX.TopLevel = false;
            PLC_ChiudiFaldaDX.TopLevel = false;
            PLC_FineCorsaAperturaSX.TopLevel = false;
            PLC_FineCorsaChiusuraSX.TopLevel = false;
            PLC_FineCorsaAperturaDX.TopLevel = false;
            PLC_FineCorsaChiusuraDX.TopLevel = false;
            PLC_NoResetTermici.TopLevel = false;
            PLC_Cicalini.TopLevel = false;
            PLC_ChiudiTetto.TopLevel = false;
            PLC_ApriTetto.TopLevel = false;
            PLC_CicaliniMute.TopLevel = false;
            PLC_Reset_Termici.TopLevel = false;
            PLC_Reset_Counter_Termici.TopLevel = false;
            this.Grp_FaldaSX.Controls.Add(PLC_ApriFaldaSX);
            this.Grp_faldaDX.Controls.Add(PLC_ApriFaldaDX);
            this.Grp_FaldaSX.Controls.Add(PLC_ChiudiFaldaSX);
            this.Grp_faldaDX.Controls.Add(PLC_ChiudiFaldaDX);
            this.Grp_FaldaSX.Controls.Add(PLC_FineCorsaAperturaSX);
            this.Grp_FaldaSX.Controls.Add(PLC_FineCorsaChiusuraSX);
            this.Grp_faldaDX.Controls.Add(PLC_FineCorsaAperturaDX);
            this.Grp_faldaDX.Controls.Add(PLC_FineCorsaChiusuraDX);
            this.Grp_Tetto.Controls.Add(PLC_NoResetTermici);
            this.Grp_Tetto.Controls.Add(PLC_Reset_Termici);
            this.Grp_Tetto.Controls.Add(PLC_Cicalini);
            this.Grp_Tetto.Controls.Add(PLC_CicaliniMute);
            this.Grp_Tetto.Controls.Add(PLC_ChiudiTetto);
            this.Grp_Tetto.Controls.Add(PLC_ApriTetto);
            this.Grp_Tetto.Controls.Add(PLC_Reset_Counter_Termici);
            PLC_ApriFaldaSX.Show();
            PLC_ApriFaldaDX.Show();
            PLC_ChiudiFaldaDX.Show();
            PLC_ChiudiFaldaSX.Show();
            PLC_FineCorsaAperturaSX.Show();
            PLC_FineCorsaChiusuraSX.Show();
            PLC_FineCorsaAperturaDX.Show();
            PLC_FineCorsaChiusuraDX.Show();
            PLC_NoResetTermici.Show();
            PLC_Cicalini.Show();
            PLC_CicaliniMute.Show();
            PLC_ChiudiTetto.Show();
            PLC_ApriTetto.Show();
            PLC_Reset_Termici.Show();
            PLC_Reset_Counter_Termici.Show();
            PLC_ApriFaldaSX.PLCVariableName = "Apri Falda Sinistra";
            PLC_ApriFaldaDX.PLCVariableName = "Apri Falda Destra";
            PLC_FineCorsaAperturaSX.PLCVariableName = "Finecorsa Apertura Sinistra";
            PLC_FineCorsaChiusuraSX.PLCVariableName = "Finecorsa Chiusura Sinistra";
            PLC_ChiudiFaldaSX.PLCVariableName = "Chiudi Falda Sinistra";
            PLC_ChiudiFaldaDX.PLCVariableName = "Chiudi Falda Destra";
            PLC_FineCorsaAperturaDX.PLCVariableName = "Finecorsa Apertura Destra";
            PLC_FineCorsaChiusuraDX.PLCVariableName = "Finecorsa Chiusura Destra";
            PLC_NoResetTermici.PLCVariableName = "Numero Reset Termici";
            PLC_ChiudiTetto.PLCVariableName = "Chiudi Tetto";
            PLC_ApriTetto.PLCVariableName = "Apri Tetto";
            PLC_Cicalini.PLCVariableName = "Cicalini";
            PLC_CicaliniMute.PLCVariableName = "Mute";
            PLC_Reset_Termici.PLCVariableName = "Reset Termico";
            PLC_Reset_Counter_Termici.PLCVariableName = "Reset Contatore Termici";
            PLC_ApriFaldaSX.Location = new System.Drawing.Point(20, 20);
            PLC_FineCorsaAperturaSX.Location = new System.Drawing.Point(20, 80);
            PLC_FineCorsaAperturaDX.Location = new System.Drawing.Point(20, 80);
            PLC_FineCorsaChiusuraSX.Location = new System.Drawing.Point(220, 80);
            PLC_FineCorsaChiusuraDX.Location = new System.Drawing.Point(220, 80);
            PLC_ApriFaldaDX.Location = new System.Drawing.Point(20, 20);
            PLC_ChiudiFaldaSX.Location = new System.Drawing.Point(220, 20);
            PLC_ChiudiFaldaDX.Location = new System.Drawing.Point(220, 20);

            PLC_NoResetTermici.Location = new System.Drawing.Point(20, 20);
            PLC_Cicalini.Location = new System.Drawing.Point(20, 80);
            PLC_ApriTetto.Location = new System.Drawing.Point(220, 20);
            PLC_CicaliniMute.Location = new System.Drawing.Point(220, 80);
            PLC_Reset_Termici.Location = new System.Drawing.Point(420, 80);
            PLC_ChiudiTetto.Location = new System.Drawing.Point(420, 20);
            PLC_Reset_Counter_Termici.Location = new System.Drawing.Point(620, 20);

            PLC_ApriFaldaSX.Name = "PLC_ApriFaldaSX";
            PLC_ApriFaldaDX.Name = "PLC_ApriFaldaDX";
            PLC_ChiudiFaldaSX.Name = "PLC_ChiudiFaldaSX";
            PLC_ChiudiFaldaDX.Name = "PLC_ChiudiFaldaDX";
            PLC_FineCorsaAperturaSX.Name = "PLC_FineCorsaAperturaSX";
            PLC_FineCorsaChiusuraSX.Name = "PLC_FineCorsaChiusuraSX";
            PLC_FineCorsaAperturaDX.Name = "PLC_FineCorsaAperturaDX";
            PLC_FineCorsaChiusuraDX.Name = "PLC_FineCorsaChiusuraDX";
            PLC_NoResetTermici.Name = "PLC_NoResetTermici";
            PLC_Cicalini.Name = "PLC_Cicalini";
            PLC_CicaliniMute.Name = "PLC_CicaliniMute";
            PLC_ChiudiTetto.Name = "PLC_ChiudiTetto";
            PLC_ApriTetto.Name = "PLC_ApriTetto";
            PLC_Reset_Termici.Name = "PLC_Reset_Termici";
            PLC_Reset_Counter_Termici.Name = "PLC_Reset_Counter_Termici";
            PLC_ApriFaldaSX.PLCVariablePath = "TCPIP.S7-200.Roof.ApriFaldaSX";
            PLC_ApriFaldaDX.PLCVariablePath = "TCPIP.S7.200.Roof.ApriFaldaDX";
            PLC_ChiudiFaldaSX.PLCVariablePath = "TCPIP.S7-200.Roof.ChiudiFaldaSX";
            PLC_ChiudiFaldaDX.PLCVariablePath = "TCPIP.S7-200.Roof.ChiudiFaldaDX";
            PLC_FineCorsaAperturaSX.PLCVariablePath = "TCPIP.S7-200.Roof.FC_FaldaSXApertura";
            PLC_FineCorsaChiusuraSX.PLCVariablePath = "TCPIP.S7-200.Roof.FC_FaldaSXChiusura";
            PLC_FineCorsaAperturaDX.PLCVariablePath = "TCPIP.S7-200.Roof.FC_FaldaDXApertura";
            PLC_FineCorsaChiusuraDX.PLCVariablePath = "TCPIP.S7-200.Roof.FC_FaldaDXChiusura";
            PLC_NoResetTermici.PLCVariablePath = "TCPIP.S7-200.Roof.ContantoreAlmTermici";
            PLC_Cicalini.PLCVariablePath = "TCPIP.S7-200.Roof.Cicalini";
            PLC_CicaliniMute.PLCVariablePath = "TCPIP.S7-200.Roof.CicaliniMute";
            PLC_ChiudiTetto.PLCVariablePath = "TCPIP.S7-200.Roof.ChiudiTetto";
            PLC_ApriTetto.PLCVariablePath = "TCPIP.S7-200.Roof.ApriTetto";
            PLC_Reset_Termici.PLCVariablePath = "TCPIP.S7-200.Roof.OResetTermico";
            PLC_Reset_Counter_Termici.PLCVariablePath = "TCPIP.S7-200.Roof.ResetContTermico";
            PLC_ApriFaldaSX.RedOnValue = true;
            PLC_ChiudiFaldaSX.RedOnValue = true;
            PLC_ApriFaldaDX.RedOnValue = true;
            PLC_ChiudiFaldaDX.RedOnValue = true;
            PLC_FineCorsaAperturaSX.RedOnValue = true;
            PLC_FineCorsaChiusuraSX.RedOnValue = true;
            PLC_FineCorsaAperturaDX.RedOnValue = true;
            PLC_FineCorsaChiusuraDX.RedOnValue = true;
            PLC_NoResetTermici.RedOnValue = true;
            PLC_Cicalini.RedOnValue = true;
            PLC_ChiudiTetto.RedOnValue = true;
            PLC_ApriTetto.RedOnValue = true;
            PLC_ApriFaldaSX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_ApriFaldaDX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_ChiudiFaldaSX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_ChiudiFaldaDX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_FineCorsaAperturaSX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_FineCorsaChiusuraSX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_FineCorsaAperturaDX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_FineCorsaChiusuraDX.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Cicalini.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_ChiudiTetto.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_ApriTetto.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_CicaliniMute.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Reset_Termici.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_Reset_Counter_Termici.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_BOOL;
            PLC_NoResetTermici.PLCVariableType = System.Runtime.InteropServices.VarEnum.VT_INT;
        }
        private void InitializeUPS()
        {
            UPS_EchoMode.TopLevel = false;
            UPS_BatteryLow.TopLevel = false;
            UPS_LDInverter.TopLevel = false;
            UPS_Alarm.TopLevel = false;
            UPS_ConnectionFailure.TopLevel = false;
            UPS_MainFailure.TopLevel = false;
            UPS_ChargeValue.TopLevel = false;
            this.grpUPS.Controls.Add(UPS_EchoMode);
            this.grpUPS.Controls.Add(UPS_BatteryLow);
            this.grpUPS.Controls.Add(UPS_LDInverter);
            this.grpUPS.Controls.Add(UPS_Alarm);
            this.grpUPS.Controls.Add(UPS_ConnectionFailure);
            this.grpUPS.Controls.Add(UPS_MainFailure);
            this.grpUPS.Controls.Add(UPS_ChargeValue);
            UPS_EchoMode.Show();
            UPS_BatteryLow.Show();
            UPS_LDInverter.Show();
            UPS_Alarm.Show();
            UPS_ConnectionFailure.Show();
            UPS_MainFailure.Show();
            UPS_ChargeValue.Show();
            UPS_EchoMode.PLCAlarmName = "Eco Mode Active";
            UPS_BatteryLow.PLCAlarmName = "Battery Low";
            UPS_LDInverter.PLCAlarmName = "Inverter Alarm";
            UPS_Alarm.PLCAlarmName = "General Alarm";
            UPS_ConnectionFailure.PLCAlarmName = "Connection Failure";
            UPS_MainFailure.PLCAlarmName = "Main Failure";
            UPS_ChargeValue.PLCVariableName = "UPS Charge";
            UPS_ChargeValue.MaxValue = 100;
            UPS_ChargeValue.MinValue = 0;
            UPS_EchoMode.Location = new System.Drawing.Point(20, 20);
            UPS_BatteryLow.Location = new System.Drawing.Point(20, 70);
            UPS_LDInverter.Location = new System.Drawing.Point(20, 120);
            UPS_Alarm.Location = new System.Drawing.Point(20, 170);
            UPS_ConnectionFailure.Location = new System.Drawing.Point(340, 20);
            UPS_MainFailure.Location = new System.Drawing.Point(340, 70);
            UPS_ChargeValue.Location = new System.Drawing.Point(20, 290);
            UPS_EchoMode.Name = "UPS_EchoMode";
            UPS_BatteryLow.Name = "UPS_BatteryLow";
            UPS_LDInverter.Name = "UPS_LDInverter";
            UPS_Alarm.Name = "UPS_Alarm";
            UPS_MainFailure.Name = "UPS_MainFailure";
            UPS_ConnectionFailure.Name = "UPS_ConnectionFailure";
            UPS_ChargeValue.Name = "UPS_ChargeValue";
            UPS_EchoMode.PLCVariablePath = "TCPIP.S7-200.UPS.I_ECOMODE";
            UPS_BatteryLow.PLCVariablePath = "TCPIP.S7-200.UPS.I_BATTLOW";
            UPS_LDInverter.PLCVariablePath = "TCPIP.S7-200.UPS.I_LDINV";
            UPS_Alarm.PLCVariablePath = "TCPIP.S7-200.UPS.I_ALARM";
            UPS_ConnectionFailure.PLCVariablePath = "TCPIP.S7-200.UPS.AlmLinkFailure";
            UPS_MainFailure.PLCVariablePath = "TCPIP.S7-200.UPS.AlmMainsFailure";
            UPS_ChargeValue.PLCVariablePath = "TCPIP.S7-200.UPS.RemainingCapacity";
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
