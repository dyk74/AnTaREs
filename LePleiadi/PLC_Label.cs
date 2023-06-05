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
    public partial class PLC_Label : MetroSet_UI.Forms.MetroSetForm
    {
        private VariableHandle PLC_VariableHandle;
        private string PLC_VariablePath;
        private VarEnum PLC_VariableType;
        private Comunicazioni Com;
        private bool C_Modifiable;
        private bool C_RedOnValue;
        public PLC_Label()
        {
            InitializeComponent();
            PLC_VariableHandle = null;
            PLC_VariablePath = "";
            PLC_VariableType = VarEnum.VT_UNKNOWN;
            Com = Comunicazioni.Instance;
            C_Modifiable = true;
            C_RedOnValue = true;
            ResetDefault();
        }
        public PLC_Label(VariableHandle C_Variable)
        {
            InitializeComponent();
            PLC_VariableHandle = null;
            PLC_VariableHandle = C_Variable;
            Com = Comunicazioni.Instance;
            C_Modifiable = true;
            C_RedOnValue = true;
            ResetDefault();
        }
        public void ResetDefault()
        {
            lbl_ValueDescription.Text = "-";
            ecl_ValueStatus.NormalColor = Color.Gray;
            C_Modifiable = true;
            lbl_ValueDescription.BackColor = Color.Transparent;
        }
        public bool Online(bool value)
        {
            bool ReturnValue = false;
            if(PLC_VariablePath.Equals("")&&(PLC_VariableType!=VarEnum.VT_UNKNOWN))
            {
                lbl_ValueDescription.BackColor = Color.Transparent;
                if(PLC_VariableHandle==null)
                    PLC_VariableHandle = new VariableHandle(Com, PLC_VariablePath, -1, true, PLC_VariableType);
                if(value)
                {
                    Com.RegisterVariable(PLC_VariableHandle);
                    PLC_VariableHandle.OnValueChange += new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                }
                else
                {
                    PLC_VariableHandle.OnValueChange -= new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                    Com.RemoveVariable(PLC_VariableHandle);
                    ResetDefault();
                }
            }
            return ReturnValue;
        }
        void Handle_OnValueChange(object sender)
        {
            ecl_ValueStatus.Invoke((MethodInvoker)delegate
            {
                DisplayValue();
            });
        }
        protected void DisplayValue()
        {
            if((PLC_VariableHandle!=null)&&(PLC_VariableHandle.ActualValue!=null))
            {
                if (PLC_VariableHandle.VariableType == VarEnum.VT_BOOL)
                {
                    bool Res = Convert.ToBoolean(PLC_VariableHandle.ActualValue);
                    lbl_ValueDescription.Text = Res.ToString();
                    if (Res == C_RedOnValue)
                    {
                        ecl_ValueStatus.NormalColor = Color.Red;
                        lbl_ValueDescription.BackColor = Color.Yellow;
                    }
                    else
                    {
                        ecl_ValueStatus.NormalColor = Color.Green;
                        lbl_ValueDescription.BackColor = Color.Transparent;
                    }
                }
                else
                    ecl_ValueStatus.Text = PLC_VariableHandle.ActualValue.ToString();
            }
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
                return lbl_ValueDescription.Text;
            }
            set
            {
                lbl_ValueDescription.Text = value;
            }
        }
        [Browsable(true),Description("Variable Value"),Category("PLC")]
        public bool RedOnValue
        {
            get
            {
                return C_RedOnValue;
            }
            set
            {
                C_RedOnValue = value;
            }
        }
        [Browsable(true),Description("Variable Modifiable"),Category("PLC")]
        public bool Modifiable
        {
            get
            {
                return C_Modifiable;
            }
            set
            {
                if (PLC_VariableHandle != null)
                {
                    PLC_VariableHandle.Modifiable = value;
                    C_Modifiable = value;
                }
                else
                    C_Modifiable = value;
            }
        }

        private void Ecl_ValueStatus_Click(object sender, EventArgs e)
        {
            if (!C_Modifiable)
                return;
            InputForm C_Form = new InputForm();
            string ResultString;
            if (C_Form.ShowDialog() == DialogResult.OK)
                ResultString = C_Form.Input.Text;
            else
                return;
            if (PLC_VariableHandle.VariableType==VarEnum.VT_BOOL)
            {
                bool Result = Convert.ToBoolean(ResultString);
                if (Result == true || Result == false)
                    PLC_VariableHandle.Write(Result);
            }
            else if(PLC_VariableHandle.VariableType==VarEnum.VT_INT)
            {
                int Result = Convert.ToInt32(ResultString);
                PLC_VariableHandle.Write(Result);
            }
            else if(PLC_VariableHandle.VariableType==VarEnum.VT_I1)
            {
                byte Result = Convert.ToByte(ResultString);
                PLC_VariableHandle.Write(Result);
            }
        }
    }
}
