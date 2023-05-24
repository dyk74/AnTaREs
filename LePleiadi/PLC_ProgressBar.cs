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
using static LePleiadi.Comunicazione;

namespace LePleiadi
{
    public partial class PLC_ProgressBar : MetroSet_UI.Forms.MetroSetForm
    {
        private VariableHandle PLC_Handle;
        private string PLC_VariablePath;
        private VarEnum PLC_VariableType;
        private Comunicazioni Com;
        private bool C_Modifiable;
        public PLC_ProgressBar()
        {
            InitializeComponent();
            PLC_Handle = null;
            PLC_VariablePath = "";
            PLC_VariableType = VarEnum.VT_UNKNOWN;
            Com = Comunicazioni.Instance;
            C_Modifiable = true;
        }
        public PLC_ProgressBar(VariableHandle C_Variable)
        {
            InitializeComponent();
            PLC_Handle = null;
            PLC_Handle = C_Variable;
            Com = Comunicazioni.Instance;
            C_Modifiable = true;
        }
        public void ResetDefault()
        {
            Pb_ProgressBar.Value = 0;
            lbl_ProgressBar_Value.Text = "-";
            C_Modifiable = true;
        }
        public bool Online(bool value)
        {
            bool ReturnValue = false;
            if (!PLC_VariablePath.Equals("") && (PLC_VariableType != VarEnum.VT_UNKNOWN))
            {
                if (PLC_Handle == null)
                    PLC_Handle = new VariableHandle(Com, PLC_VariablePath, -1, true);
                if (value)
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
            else
                lbl_ProgressBarVariable.Text = "Path or Type Error";
            return ReturnValue;
        }
        void Handle_OnValueChange(object sender)
        {
            lbl_ProgressBar_Value.Invoke((MethodInvoker)delegate
            {
                DisplayValue();
            });
        }
        protected void DisplayValue()
        {
            if((PLC_Handle!=null)&&(PLC_Handle.ActualValue!=null))
            {
                lbl_ProgressBar_Value.Text = PLC_Handle.ActualValue.ToString() + "%";
                Pb_ProgressBar.Value = Convert.ToInt16(PLC_Handle.ActualValue);
            }
        }
        private void ChangeValue()
        {
            string ResultString = "";
            InputForm C_Form = new InputForm();
            if (C_Form.ShowDialog() == DialogResult.OK)
                ResultString = C_Form.Input.Text;
            else
                return;
            C_Form = null;
            if(PLC_Handle.VariableType==VarEnum.VT_UINT)
            {
                int Result = Convert.ToInt16(ResultString);
                if (Result >= 0)
                    PLC_Handle.Write(Result);
            }
        }
        private void Pb_ProgressBar_Clicked(object sender, EventArgs e)
        {
            ChangeValue();
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
                return lbl_ProgressBarVariable.Text;
            }
            set
            {
                lbl_ProgressBarVariable.Text = value;
            }
        }
        [Browsable(true),Description("Modifiable"),Category("PLC")]
        public bool Modifiable
        {
            get
            {
                return C_Modifiable;
            }
            set
            {
                if (PLC_Handle != null)
                {
                    PLC_Handle.Modifiable = value;
                    C_Modifiable = value;
                }
                else
                    C_Modifiable = value;
            }
        }
        [Browsable(true),Description("Min Value"),Category("PLC")]
        public int MinValue
        {
            get
            {
                return Pb_ProgressBar.Minimum;
            }
            set
            {
                Pb_ProgressBar.Minimum = value;
            }
        }
        [Browsable(true),Description("Max Value"),Category("PLC")]
        public int MaxValue
        {
            get
            {
                return Pb_ProgressBar.Maximum;
            }
            set
            {
                Pb_ProgressBar.Maximum = value;
            }
        }
        [Browsable(true),Description("Style"),Category("PLC")]
        public MetroSet_UI.Enums.Style ProgressBarStyle
        {
            get
            {
                return Pb_ProgressBar.Style;
            }
            set
            {
                Pb_ProgressBar.Style = value;
            }
        }
    }
}
