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
            System.Timers.Timer MyTimer;
            public void Start()
            {
                MyTimer = new System.Timers.Timer();
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
                    DateTime UTCDateTime = NetworkDateTime.ToUniversalTime();
                    return UTCDateTime;
                    //return NetworkDateTime;
                }
            }
            public static bool HasICMPConnectivity(string IP)
            {
                Ping Ping = new Ping();
                PingOptions Options = new PingOptions
                {
                    DontFragment = true
                };
                byte[] Buffer = null;
                PingReply Reply = Ping.Send(IP, 500, Buffer, Options);
                return Reply.Status == IPStatus.Success;
            }
        }
    }
}
