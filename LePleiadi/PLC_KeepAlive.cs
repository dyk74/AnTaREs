using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static AnTaREs.Comunicazione;

namespace AnTaREs
{
    public partial class PLC_KeepAlive : MetroSet_UI.Forms.MetroSetForm
    {
        private VariableHandle PLC_Handle;
        private string PLC_VariablePath;
        private VarEnum PLC_VariableType;
        private readonly Comunicazioni Com;
        static byte Counter = 0;
        static System.Timers.Timer Timer;
        public PLC_KeepAlive()
        {
            InitializeComponent();
            PLC_Handle = null;
            PLC_VariablePath = "";
            PLC_VariableType = VarEnum.VT_UNKNOWN;
            Com = Comunicazioni.Instance;
            RegisterTimer();
        }
        public PLC_KeepAlive(VariableHandle C_Variable)
        {
            InitializeComponent();
            PLC_Handle = null;
            PLC_Handle = C_Variable;
            Com = Comunicazioni.Instance;
            RegisterTimer();
        }
        public bool Online(bool value)
        {
            bool ReturnValue=false;
            if(PLC_VariablePath.Equals("")&&(PLC_VariableType!=VarEnum.VT_UNKNOWN))
            {
                if (PLC_Handle == null)
                    PLC_Handle = new VariableHandle(Com, PLC_VariablePath, -1, true);
                if(value)
                {
                    Com.RegisterVariable(PLC_Handle);
                    Timer.Start();
                }
                else
                {
                    Com.RemoveVariable(PLC_Handle);
                    Timer.Stop();
                }
            }
            return ReturnValue;
        }
        private void RegisterTimer()
        {
            Timer = new System.Timers.Timer(500);
            Timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
        }
        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Com.SyncWrite(PLC_Handle, Counter, typeof(byte));
            Counter++;
            ecl_LedKeepAlive.Invoke((MethodInvoker)delegate
            {
                ChangeVisibility();
            });
        }
        void ChangeVisibility()
        {
            if (ecl_LedKeepAlive.NormalColor == Color.Green)
                ecl_LedKeepAlive.NormalColor = Color.White;
            else if (ecl_LedKeepAlive.NormalColor == Color.White)
                ecl_LedKeepAlive.NormalColor = Color.Green;
        }
        [Browsable(true),Description("Variable Path"),Category("PLC")]
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
        [Browsable(true),Description("Variable Type)"),Category("PLC")]
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
    }
}
