using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using static AnTaREs.PLC_Comunication;
using System.Windows.Forms;
using System.Timers;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Management;
using System.Net;
using MetroSet_UI;
using System.Net.Sockets;
using System.ComponentModel;

namespace AnTaREs
{
    public class PLC
    {
 // VERIFICARE DA QUI LE CLASSI
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
