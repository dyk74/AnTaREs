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
    public partial class PLC_Button : MetroSet_UI.Forms.MetroSetForm
    {
        private VariableHandle PLC_Handle;
        private string PLC_VariablePath;
        private VarEnum PLC_VariableType;
        private Comunicazioni Com;
        private Boolean C_ResetState = false;
        public PLC_Button()
        {
            InitializeComponent();
            PLC_Handle = null;
            PLC_VariablePath = "";
            PLC_VariableType = VarEnum.VT_UNKNOWN;
            Com = Comunicazioni.Instance;
            ResetDefault();
        }
        public PLC_Button(VariableHandle C_Variable)
        {
            InitializeComponent();
            PLC_Handle = null;
            PLC_Handle = C_Variable;
            Com = Comunicazioni.Instance;
            ResetDefault();
        }
        public void ResetDefault()
        {
            Lbl_PLC_Button.Text = "-";
            Lbl_PLC_Button.BackColor = Color.Transparent;
        }
        public bool Online(bool value)
        {
            bool ReturnValue = false;
            if(!PLC_VariablePath.Equals("")&&(PLC_VariableType!=VarEnum.VT_UNKNOWN))
            {
                if (PLC_Handle == null)
                    PLC_Handle = new VariableHandle(Com, PLC_VariablePath, -1, true, PLC_VariableType);
                if(value)
                {
                    Com.RegisterVariable(PLC_Handle);
                    PLC_Handle.OnValueChange += new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                    Lbl_PLC_Button.BackColor = Color.Transparent;
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
            Lbl_PLC_Button.Invoke((MethodInvoker)delegate
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
                    if (Result)
                        Lbl_PLC_Button.Text = "1";
                    else
                        Lbl_PLC_Button.Text = "0";
                }
                else
                    Lbl_PLC_Button.Text = PLC_Handle.ActualValue.ToString();
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
        [Browsable(true),Description("PLC Name"),Category("PLC")]
        public string PLCVariableName
        {
            get
            {
                return Btn_PLC_Button.Text;
            }
            set
            {
                Btn_PLC_Button.Text = value;
            }
        }
        [Browsable(true),Description("PLC Reset"),Category("PLC")]
        public Boolean ResetState
        {
            get
            {
                return C_ResetState;
            }
            set
            {
                C_ResetState = value;
            }
        }
        private void Btn_PLC_Button_MouseUp(object sender, MouseEventArgs e)
        {
            if (C_ResetState)
                PLC_Handle.Write(false);
        }
        private void Btn_PLC_Button_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Handle.Write(true);
        }
    }
}
