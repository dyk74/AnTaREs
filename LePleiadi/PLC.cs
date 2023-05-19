using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using static LePleiadi.Comunicazione;
using System.Windows.Forms;
using System.Timers;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Management;
using System.Net;
using MetroSet_UI;
using System.Net.Sockets;
using System.ComponentModel;

namespace LePleiadi
{
    public class PLC
    {
       public partial class PLC_UPSAlarm:MetroSet_UI.Forms.MetroSetForm
        {
            private VariableHandle PLC_Handle;
            private string PLC_VariablePath;
            private VarEnum PLC_VariableType;
            private Comunicazioni PLC_Com;
            private bool Reset_Available = false;
            private MetroSet_UI.Controls.MetroSetEllipse UPS_AlarmStatus;
            private MetroSet_UI.Controls.MetroSetDefaultButton Btn_ResetAlarm;
            private MetroSet_UI.Controls.MetroSetLabel Lbl_UPSAlarm;
            public PLC_UPSAlarm()
            {
                Initialize_UPSAlarm();
                PLC_Handle = null;
                PLC_VariablePath = "";
                PLC_VariableType = VarEnum.VT_UNKNOWN;
                PLC_Com = Comunicazioni.Instance;
                UPS_AlarmStatus.NormalColor = Color.Gray;
                Btn_ResetAlarm.Enabled = false;
                ResetDefault();
            }
            public PLC_UPSAlarm(VariableHandle OVariable)
            {
                Initialize_UPSAlarm();
                PLC_Handle = null;
                PLC_Handle = OVariable;
                PLC_Com = Comunicazioni.Instance;
                UPS_AlarmStatus.NormalColor = Color.Gray;
                Btn_ResetAlarm.Enabled = false;
                ResetDefault();
            }
            private void SetResetAvailable()
            {
                if(!ResetAvailable)
                {
                    Btn_ResetAlarm.Enabled = false;
                    Btn_ResetAlarm.Visible = false;
                }
                else
                {
                    Btn_ResetAlarm.Visible = true;
                    Btn_ResetAlarm.Enabled = true;
                }
            }
            public void ResetDefault()
            {
                UPS_AlarmStatus.NormalColor = Color.Gray;
                Btn_ResetAlarm.Enabled = false;
                Lbl_UPSAlarm.BackColor = Color.Transparent;
            }
            public bool Online(bool value)
            {
                bool ReturnValue = false;
                if(!PLC_VariablePath.Equals("")&&(PLC_VariableType!=VarEnum.VT_UNKNOWN))
                {
                    Lbl_UPSAlarm.BackColor = Color.Transparent;
                    if (PLC_Handle == null)
                        PLC_Handle = new VariableHandle(PLC_Com, PLC_VariablePath, -1, true);
                    if(value)
                    {
                        PLC_Com.RegisterVariable(PLC_Handle);
                        PLC_Handle.OnValueChange += new VariableHandle.OnVarValueChange(Handle_OnValueChange);
                    }
                    else
                    {
                        PLC_Handle.OnValueChange -= new VariableHandle.OnVarValueChange(Handle_OnValueChange);
                        PLC_Com.RemoveVariable(PLC_Handle);
                        ResetDefault();
                    }
                }
                return ReturnValue;
            }
            void Handle_OnValueChange(object sender)
            {
                UPS_AlarmStatus.Invoke((MethodInvoker)delegate
                {
                    DisplayAlarm();
                });
            }
            protected void DisplayAlarm()
            {
                if((PLC_Handle!=null)&&(PLC_Handle.ActualValue!=null))
                {
                    bool NewValue = Convert.ToBoolean(PLC_Handle.ActualValue);
                    if(NewValue)
                    {
                        UPS_AlarmStatus.NormalColor = Color.Red;
                        Btn_ResetAlarm.Enabled = true;
                    }
                    else
                    {
                        UPS_AlarmStatus.NormalColor = Color.Green;
                        Btn_ResetAlarm.Enabled = false;
                    }
                }
            }
            [Browsable(true),Description("PLC Path"),Category("PLC")]
            public string PLCVariablePath
            {
                get
                {
                    return PLC_VariablePath;
                }
                set
                {
                    PLC_VariablePath = value;
                }
            }
            [Browsable(true),Description("PLC Type"),Category("PLC")]
            public VarEnum PLCVariableType
            {
                get
                {
                    return PLC_VariableType;
                }
                set
                {
                    PLC_VariableType = value;
                }
            }
            [Browsable(true),Description("PLC Alarm Name"),Category("PLC")]
            public string AlarmName
            {
                get
                {
                    return Lbl_UPSAlarm.Text;
                }
                set
                {
                    Lbl_UPSAlarm.Text = value;
                }
            }
            [Browsable(true),Description("PLC Reset Available"),Category("PLC")]
            public bool ResetAvailable
            {
                get
                {
                    return Reset_Available;
                }
                set
                {
                    Reset_Available = value;
                    SetResetAvailable();
                }
            }
            
            private void Initialize_UPSAlarm()
            {
                UPS_AlarmStatus = new MetroSet_UI.Controls.MetroSetEllipse();
                Btn_ResetAlarm = new MetroSet_UI.Controls.MetroSetDefaultButton();
                Lbl_UPSAlarm = new MetroSet_UI.Controls.MetroSetLabel();
                SuspendLayout();
                UPS_AlarmStatus.Size= new System.Drawing.Size(25, 25);
                UPS_AlarmStatus.Location= new System.Drawing.Point(10, 10);
                Lbl_UPSAlarm.Name = "LblUPSAlarm";
                Btn_ResetAlarm.Name = "Btn_ResetAlarm";
                Btn_ResetAlarm.ControlAdded += Btn_ResetAlarm_ControlAdded;
                Btn_ResetAlarm.Click += Btn_ResetAlarm_Click;
                UPS_AlarmStatus.Name = "UPS_AlarmStatus";

            }

            private void Btn_ResetAlarm_Click(object sender, EventArgs e)
            {
                PLC_Handle.Write(false);
            }

            private void Btn_ResetAlarm_ControlAdded(object sender, ControlEventArgs e)
            {
                SetResetAvailable();
            }
        }
 // VERIFICARE DA QUI LE CLASSI
        public class PLC_KeepAlive
        {
            private VariableHandle LO_Handle;
            private string LS_PathVarPLC;
            private VarEnum LO_TypeVarPLC;
            private Comunicazioni LO_Com;
            static byte counter = 0;
            static System.Timers.Timer timer;
            public PLC_KeepAlive()
            {
                LO_Handle = null;
                LS_PathVarPLC = "";
                LO_TypeVarPLC = VarEnum.VT_UNKNOWN;
                LO_Com = Comunicazioni.Instance;
                RegisterTimer();
            }
            public PLC_KeepAlive(VariableHandle OVariable)
            {
                LO_Handle = null;
                LO_Handle = OVariable;
                LO_Com = Comunicazioni.Instance;
                RegisterTimer();
            }
            public bool Online(bool value)
            {
                bool retVal = false;
                if(LS_PathVarPLC.Equals("") &&(LO_TypeVarPLC!=VarEnum.VT_UNKNOWN))
                {
                    if (LO_Handle == null)
                        LO_Handle = new VariableHandle(LO_Com, LS_PathVarPLC, -1, true);
                    if(value)
                    {
                        LO_Com.RegisterVariable(LO_Handle);
                        timer.Start();
                    }
                    else
                    {
                        LO_Com.RemoveVariable(LO_Handle);
                        timer.Stop();
                    }
                }
                return retVal;
            }
            private void RegisterTimer()
            {
                timer = new System.Timers.Timer(500);
                timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            }
            void Timer_Elapsed(object sender,ElapsedEventArgs e)
            {
                LO_Com.SyncWrite(LO_Handle, counter, typeof(byte));
                counter++;
                Main.btn_KeepAlive.Invoke((MethodInvoker)delegate
                    {
                    ChangeVisibility();
                });
            }
            void ChangeVisibility()
            {
                if (Main.btn_KeepAlive.NormalColor == Color.Red)
                    Main.btn_KeepAlive.NormalColor = Color.White;
                else if (Main.btn_KeepAlive.NormalColor == Color.White)
                    Main.btn_KeepAlive.NormalColor = Color.Red;
            }
            public string PathVarPLC
            {
                get
                {
                    return LS_PathVarPLC;
                }
                set
                {
                    LS_PathVarPLC = value;
                }
            }
            public VarEnum Type
            {
                get
                {
                    return LO_TypeVarPLC;
                }
                set
                {
                    LO_TypeVarPLC = value;
                }
            }
        }
        public class PLC_CheckConnectivity
        {
            public string DestinationIP
            {
                get
                {
                    return Main.txtIP.Text;
                }
                set
                {
                    Main.txtIP.Text = value;
                }
            }
            public static void Btn_Ping_Click(object sender,EventArgs e)
            {
                Main.btnIPStatus.NormalColor = Color.Gray;
                TestConnectivity();
            }
            public static void TestConnectivity()
            {
                if (Main.txtIP.Equals(""))
                    return;
                if (PLC_Utility.HasICMPConnectivity(Main.txtIP.Text))
                    Main.btnIPStatus.NormalColor = Color.Green;
                else
                    Main.btnIPStatus.NormalColor = Color.Red;
            }
        }
        public class PLC_SystemInformation
        {
            PerformanceCounter CpuCounter;
            PerformanceCounter RamCounter;
            System.Timers.Timer MyTimer;
            public PLC_SystemInformation()
            {
                CpuCounter = new PerformanceCounter();
                CpuCounter.CategoryName = "Processor";
                CpuCounter.CounterName = "% Processor Time";
                CpuCounter.InstanceName = "_Total";
                RamCounter = new PerformanceCounter("Memory", "Available MBytes");
                Main.PB_Ram.Maximum = Convert.ToInt32(GetTotalMemoryInKByte() / 1048576);
                Main.PB_CPUUsage.Maximum = 100;
                Main.PB_CPUUsage.Style = (MetroSet_UI.Enums.Style)ProgressBarStyle.Continuous;
                Main.PB_Ram.Style = (MetroSet_UI.Enums.Style)ProgressBarStyle.Continuous;
            }
            public void Start()
            {
                MyTimer = new System.Timers.Timer();
                MyTimer.Elapsed += new ElapsedEventHandler(UpdateIndicators);
                MyTimer.Interval = 1000;
                MyTimer.Start();
            }
            public void Stop()
            {
                MyTimer.Stop();
                MyTimer = null;
            }
            static ulong GetTotalMemoryInKByte()
            {
                ObjectQuery OQuery=new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(OQuery);
                ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
                ulong Total_Visible_Memory=0 ;
                ulong Free_Physical_Memory;
                ulong Total_Virtual_Memory;
                ulong Free_Virtual_Memory;
                foreach (ManagementObject managementObject in managementObjectCollection)
                {
                    Total_Visible_Memory= (ulong)managementObject["TotalVisibleMemorySize"];
                    Free_Physical_Memory= (ulong)managementObject["FreePhysicalMemory"];
                    Total_Virtual_Memory= (ulong)managementObject["TotalVirtualMemorySize"];
                    Free_Virtual_Memory= (ulong)managementObject["FreeVirtualMemory"];
                }
                return Total_Visible_Memory;
            }
            public void UpdateIndicators(object source,ElapsedEventArgs e)
            {
                Main.PB_CPUUsage.Invoke((MethodInvoker)delegate
                {
                    UpdateCPU();
                });
                Main.PB_Ram.Invoke((MethodInvoker)delegate
                {
                    UpdateMemory();
                });
                Main.lblUptime_Value.Invoke((MethodInvoker)delegate
                {
                    UpdateServerTime();
                });
                Main.LblIP_Value.Invoke((MethodInvoker)delegate
                {
                    UpdateIpAddress();
                });
            }
            private void UpdateIpAddress()
            {
                IPAddress[] IpAddress = Dns.GetHostAddresses(Dns.GetHostName());
                for(int i=0;i<IpAddress.Length;i++)
                {
                    if(i>1)
                    {
                        Main.LblIP_Value.Text = IpAddress[i].ToString() + "(*)";
                        Main.LblIP_Value.Click -= new EventHandler(LblIP_Value_Click);
                        Main.LblIP_Value.Click += new EventHandler(LblIP_Value_Click);
                        Main.LblIP_Value.Cursor = System.Windows.Forms.Cursors.Hand;
                    }
                    else
                    {
                        Main.LblIP_Value.Click -= new EventHandler(LblIP_Value_Click);
                        Main.LblIP_Value.Cursor = System.Windows.Forms.Cursors.Default;
                    }
                }
            }
            void LblIP_Value_Click(object sender,EventArgs e)
            {
                IPAddress[] IPAddress = Dns.GetHostAddresses(Dns.GetHostName());
                string IPs = "";
                for (int i = 0; i < IPAddress.Length; i++)
                    IPs += String.Format("IP: {0}: {1}\r\n", i, IPAddress[i].ToString());
                MetroSet_UI.Forms.MetroSetMessageBox.Show((MetroSet_UI.Forms.MetroSetForm)Main.ActiveForm, IPs);
            }
            void UpdateServerTime()
            {
                TimeSpan T = TimeSpan.FromSeconds(System.Environment.TickCount / 1000);
                Main.lblUptime_Value.Text = string.Format("{0:D4}h:{1:D2}m:{2:D2}s", T.Hours, T.Minutes, T.Seconds);
                PerformanceCounter PC = new PerformanceCounter("System", "System Up Time");
                PC.NextValue();
                TimeSpan TS = TimeSpan.FromSeconds(PC.NextValue());
                Main.lblUptime_Value.Text = TS.Days + " dd " + TS.Hours + "h " + TS.Minutes + "min " + TS.Seconds + "s";
            }
            void UpdateCPU()
            {
                float NextValue = CpuCounter.NextValue();
                Main.PB_CPUUsage.Text = NextValue + "%";
                Main.PB_CPUUsage.Value = Convert.ToInt32(NextValue);
            }
            void UpdateMemory()
            {
                float NextValue = RamCounter.NextValue();
                Main.PB_Ram.Text = (Main.PB_Ram.Maximum - NextValue) + "MB";
                Main.PB_Ram.Value = Convert.ToInt32(Main.PB_Ram.Maximum - NextValue);
            }
        }
        public class PLC_Utility
        { 
            public class NtpClient
            {
                public static DateTime GetNetworkTime()
                {
                    return GetNetworkTime("time-a.nist.gov");
                }
                public static DateTime GetNetworkTime(string NtpServer)
                {
                    IPAddress[] Address = Dns.GetHostEntry(NtpServer).AddressList;
                    if (Address == null || Address.Length == 0)
                        throw new ArgumentException("COuld not resolve IP Address from " + NtpServer);
                    IPEndPoint EP = new IPEndPoint(Address[0], 123);
                    return GetNetworkTime(EP);
                }
                public static DateTime GetNetworkTime(IPEndPoint EP)
                {
                    Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    S.Connect(EP);
                    byte[] NtpData = new byte[48];
                    NtpData[0] = 0x1B;
                    for (int i = 1; i < 48; i++)
                        NtpData[i] = 0;
                    S.Send(NtpData);
                    S.Receive(NtpData);
                    byte OffsetTransmitTime = 40;
                    ulong IntPart = 0;
                    ulong FractPart = 0;
                    for (int i = 0; i <= 3; i++)
                        IntPart = 256 * IntPart + NtpData[OffsetTransmitTime + i];
                    for (int i = 4; i <= 7; i++)
                        FractPart = 256 * FractPart + NtpData[OffsetTransmitTime + i];
                    ulong Milliseconds = (IntPart * 1000 + (FractPart * 1000) / 0x100000000L);
                    S.Close();
                    TimeSpan TimeSpan = TimeSpan.FromTicks((long)Milliseconds * TimeSpan.TicksPerMillisecond);
                    DateTime DateTime = new DateTime(1900, 1, 1);
                    DateTime += TimeSpan;
                    TimeSpan OffsetAmount = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime);
                    DateTime NetworkDateTime = (DateTime + OffsetAmount);
                    return NetworkDateTime;
                }
            }
            public static bool HasICMPConnectivity(string IP)
            {
                Ping Ping = new Ping();
                PingOptions Options = new PingOptions();
                Options.DontFragment = true;
                byte[] Buffer = null;
                PingReply Reply = Ping.Send(IP, 500, Buffer, Options);
                return Reply.Status == IPStatus.Success;
            }
        }
    }
}
