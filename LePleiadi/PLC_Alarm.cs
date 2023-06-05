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
    public partial class PLC_Alarm : MetroSet_UI.Forms.MetroSetForm
    {
        private VariableHandle PLC_Handle;
        private string PLC_VariablePath;
        private VarEnum PLC_VariableType;
        private Comunicazioni PLC_Com;
        private bool Reset_Available = false;
        public PLC_Alarm()
        {
            InitializeComponent();
            PLC_Handle = null;
            PLC_VariablePath = "";
            PLC_VariableType = VarEnum.VT_UNKNOWN;
            PLC_Com = Comunicazioni.Instance;
            Ecl_Alarm.NormalColor = Color.Gray;
            Btn_Reset.Enabled = false;
        }
        public PLC_Alarm(VariableHandle C_Variable)
        {
            InitializeComponent();
            PLC_Handle = null;
            PLC_Handle = C_Variable;
            PLC_Com = Comunicazioni.Instance;
            Ecl_Alarm.NormalColor = Color.Gray;
            Btn_Reset.Enabled = false;
        }
        private void SetReset()
        {
            if(!Reset_Available)
            {
                Btn_Reset.Enabled = false;
                Btn_Reset.NormalColor = Color.Gray;
            }
            else
            {
                Btn_Reset.Enabled = true;
                Btn_Reset.NormalColor = Color.FromArgb(65, 177, 255);
            }
        }
        public void ResetDefault()
        {
            Ecl_Alarm.NormalColor = Color.Gray;
            Btn_Reset.Enabled = false;
            Lbl_Alarm.BackColor = Color.Transparent;
        }
        public bool Online(bool value)
        {
            bool ReturnValue = false;
            if(!PLC_VariablePath.Equals("")&&(PLC_VariableType!=VarEnum.VT_UNKNOWN))
            {
                Lbl_Alarm.BackColor = Color.Transparent;
                if (PLC_Handle == null)
                    PLC_Handle = new VariableHandle(PLC_Com, PLC_VariablePath, -1, true);
                if(value)
                {
                    PLC_Com.RegisterVariable(PLC_Handle);
                    PLC_Handle.OnValueChange += new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                }
                else
                {
                    PLC_Handle.OnValueChange -= new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                    PLC_Com.RemoveVariable(PLC_Handle);
                    ResetDefault();
                }
            }
            return ReturnValue;
        }
        void Handle_OnValueChange(object sender)
        {
            Ecl_Alarm.Invoke((MethodInvoker)delegate
            {
                DisplayAlarm();
            });
        }
        protected void DisplayAlarm()
        {
            bool NewValue = Convert.ToBoolean(PLC_Handle.ActualValue);
            if(NewValue)
            {
                Ecl_Alarm.NormalColor = Color.Red;
                Btn_Reset.Enabled = true;
                Lbl_Alarm.BackColor = Color.Yellow;
                Btn_Reset.NormalColor = Color.FromArgb(65, 177, 255);
            }
            else
            {
                Ecl_Alarm.NormalColor = Color.Green;
                Btn_Reset.Enabled = false;
                Lbl_Alarm.BackColor = Color.Transparent;
                Btn_Reset.NormalColor = Color.Gray;
            }
        }
        [Browsable(true),Description("PLC Path"),Category("UPS")]
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
        [Browsable(true),Description("PLC Type"),Category("UPS")]
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
        [Browsable(true),Description("PLC Name"),Category("UPS")]
        public string PLCAlarmName
        {
            get
            {
                return Lbl_Alarm.Text;
            }
            set
            {
                Lbl_Alarm.Text = value;
            }
        }
        public bool ResetAvailable
        {
            get
            {
                return Reset_Available;
            }
            set
            {
                Reset_Available = value;
                SetReset();
            }
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            PLC_Handle.Write(false);
        }
        private void Btn_Reset_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            SetReset();
        }
    }
}
