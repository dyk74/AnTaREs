using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using DotRas;

namespace LePleiadi
{
    public class VPN
    {
        public static string VPN_Server = string.Empty;
        public static string VPN_Protocol = string.Empty;
        public static string VPN_AdapterName = string.Empty;
        public static string VPN_Username = string.Empty;
        public static string VPN_Password = string.Empty;
        public static string VPN_PreSharedKey = string.Empty;
        private static RasDialer _dialer;
        private static RasHandle _handle;

        
        public static void Connect()
        {
            _dialer = new RasDialer();
            using(RasPhoneBook PhoneBook =new RasPhoneBook())
            {
                PhoneBook.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User));
                RasEntry Entry;
                if (PhoneBook.Entries.Contains(VPN_AdapterName))
                    PhoneBook.Entries.Remove(VPN_AdapterName);
                if (VPN_AdapterName.Equals("PPTP"))
                    Entry = RasEntry.CreateVpnEntry(VPN_AdapterName, VPN_Server, RasVpnStrategy.PptpOnly, RasDevice.GetDeviceByName("(PPTP)", RasDeviceType.Vpn));
                else
                    Entry = RasEntry.CreateVpnEntry(VPN_AdapterName, VPN_Server, RasVpnStrategy.L2tpOnly, RasDevice.GetDeviceByName("L2TP)", RasDeviceType.Vpn));
                PhoneBook.Entries.Add(Entry);
                Entry.Options.PreviewDomain = false;
                Entry.Options.ShowDialingProgress = false;
                Entry.Options.PromoteAlternates = false;
                Entry.Options.DoNotNegotiateMultilink = false;
                if(VPN_Protocol.Equals("L2TP"))
                {
                    Entry.Options.UsePreSharedKey = true;
                    Entry.UpdateCredentials(RasPreSharedKey.Client, VPN_PreSharedKey);
                    Entry.Update();
                }
                _dialer.EntryName = VPN_AdapterName;
                _dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User);
                _dialer.Credentials = new NetworkCredential(VPN_Username, VPN_Password);
            }
            _handle = _dialer.Dial();
        }
        public static void Disconnect()
        {
            if (_dialer.IsBusy)
                _dialer.DialAsyncCancel();
            else
            {
                if(_handle!=null)
                {
                    RasConnection RAS_Connection = RasConnection.GetActiveConnectionByHandle(_handle);
                    if (RAS_Connection != null)
                        RAS_Connection.HangUp();
                }
            }
            using (RasPhoneBook PhoneBook=new RasPhoneBook())
            {
                PhoneBook.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers));
                if (PhoneBook.Entries.Contains(VPN_AdapterName))
                    PhoneBook.Entries.Remove(VPN_AdapterName);
            }
        }
    }
}
