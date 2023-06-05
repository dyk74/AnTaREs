using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AnTaREs.PLC_Comunication;

namespace AnTaREs
{
    public partial class PLC_SecurityChain : MetroSet_UI.Forms.MetroSetForm
    {
        private VariableHandle PLC_Handle;
        private string PLC_Variable_Path;
        private VarEnum PLC_Variable_Type;
        private Comunicazioni Com;
        private bool PLC_AlarmOnValue;
        private string PLC_Tooltip = "";
        public PLC_SecurityChain()
        {
            InitializeComponent();
            PLC_Handle = null;
            PLC_Variable_Path="";
            PLC_Variable_Type = VarEnum.VT_UNKNOWN;
            Com = Comunicazioni.Instance;
            PLC_AlarmOnValue = true;
            ResetDefault();
        }
        public PLC_SecurityChain(VariableHandle C_Variable)
        {
            InitializeComponent();
            PLC_Handle = null;
            PLC_Handle = C_Variable;
            Com = Comunicazioni.Instance;
            PLC_AlarmOnValue = true;
            ResetDefault();
        }
        public void ResetDefault()
        {
            Security_Chain_Eclipse.DisabledBackColor = Color.FromName("ControlDarkDark");
            Lbl_Security_Chain_Label.Text = "-";
        }
        public bool Online(bool value)
        {
            Ttip_Security_Chain.SetToolTip(Lbl_Security_Chain_Label, PLC_Tooltip);
            Ttip_Security_Chain.SetToolTip(Security_Chain_Eclipse, PLC_Tooltip);
            bool ReturnValue = false;
            if(!PLC_Variable_Path.Equals("")&&(PLC_Variable_Type!=VarEnum.VT_UNKNOWN))
            {
                if (PLC_Handle == null)
                    PLC_Handle = new VariableHandle(Com, PLC_Variable_Path, -1, true, PLC_Variable_Type);
                if(value)
                {
                    Com.RegisterVariable(PLC_Handle);
                    PLC_Handle.OnValueChange += new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                }
                else
                {
                    PLC_Handle.OnValueChange -= new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                    Com.RemoveVariable(PLC_Handle);
                    ResetDefault();
                }
            }
            return ReturnValue;
        }
        void Handle_OnValueChange(object sender)
        {
            Security_Chain_Eclipse.Invoke((MethodInvoker)delegate
            {
                DisplayValue();
            });
        }
        protected void DisplayValue()
        {
            if((PLC_Handle!=null)&&(PLC_Handle.ActualValue!=null))
            {
                if (PLC_Handle.VariableType == VarEnum.VT_BOOL)
                {
                    bool Result = Convert.ToBoolean(PLC_Handle.ActualValue);
                    if (Result == PLC_AlarmOnValue)
                        Security_Chain_Eclipse.DisabledBackColor = Color.Red;
                    else
                        Security_Chain_Eclipse.DisabledBackColor = Color.Green;
                }
                else
                    Lbl_Security_Chain_Label.Text = PLC_Handle.ActualValue.ToString();
            }
        }
        [Browsable(true),Description("Variable Path"),Category("PLC")]
        public string PLCVariablePath
        {
            get
            {
                return PLC_Variable_Path;
            }
            set
            {
                PLC_Variable_Path = value;
            }
        }
        [Browsable(true),Description("Variable Type"),Category("PLC")]
        public VarEnum PLCVariableType
        {
            get
            {
                return PLC_Variable_Type;
            }
            set
            {
                PLC_Variable_Type = value;
            }
        }
        [Browsable(true),Description("Alarm Name"),Category("PLC")]
        public string PLCAlarmName
        {
            get
            {
                return Lbl_Security_Chain_Label.Text;
            }
            set
            {
                Lbl_Security_Chain_Label.Text = value;
            }
        }
        [Browsable(true),Description("Alarm Value"),Category("PLC")]
        public bool PLCAlarmOnValue
        {
            get
            {
                return PLC_AlarmOnValue;
            }
            set
            {
                PLC_AlarmOnValue = value;
            }
        }
        [Browsable(true),Description("Tip Value"),Category("PLC")]
        public string PLCToolTipTextValue
        {
            get
            {
                return PLC_Tooltip;
            }
            set
            {
                PLC_Tooltip = value;
            }
        }
    }
}
