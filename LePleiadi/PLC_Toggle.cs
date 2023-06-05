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
    public partial class PLC_Toggle : MetroSet_UI.Forms.MetroSetForm
    {
        private VariableHandle PLC_Handle;
        private string PLC_VariablePath;
        private VarEnum PLC_VariableType;
        private Comunicazioni Com;
        public PLC_Toggle()
        {
            InitializeComponent();
            PLC_Handle = null;
            PLC_VariablePath = "";
            PLC_VariableType = VarEnum.VT_UNKNOWN;
            Com = Comunicazioni.Instance;
            ResetDefault();
        }
        public void ResetDefault()
        {
            ChangeStatus(false);
            lbl_ToggleLabel.BackColor = Color.Transparent;
        }
        private void ChangeStatus(bool value)
        {
            sw_Toggle.Switched = value;
        }
        public bool Online(bool value)
        {
            bool ReturnValue = false;
            if(!PLC_Handle.Equals("")&&(PLC_VariableType!=VarEnum.VT_UNKNOWN))
            {
                if (PLC_Handle == null)
                    PLC_Handle = new VariableHandle(Com, PLC_VariablePath, -1, true);
                if(value)
                {
                    Com.RegisterVariable(PLC_Handle);
                    PLC_Handle.OnValueChange += new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                    lbl_ToggleLabel.BackColor = Color.Transparent;
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
            if((PLC_Handle!=null)&&(PLC_Handle.ActualValue!=null))
            {
                bool Result = Convert.ToBoolean(PLC_Handle.ActualValue);
                ChangeStatus(Result);
            }
        }
        private void Sw_Toggle_SwitchedChanged(object sender)
        {

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
        [Browsable(true),Description("Variable Type"),Category("PLC")]
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
        [Browsable(true),Description("Variable Name"),Category("PLC")]
        public string PLCVariableName
        {
            get
            {
                return lbl_ToggleLabel.Text;
            }
            set
            {
                lbl_ToggleLabel.Text = value;
            }
        }
    }
}
