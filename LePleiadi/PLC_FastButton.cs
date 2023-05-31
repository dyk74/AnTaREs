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
using static AnTaREs.Comunicazione;

namespace AnTaREs
{
    public partial class PLC_FastButton : MetroSet_UI.Forms.MetroSetForm
    {
        private VariableHandle PLC_Handle_Run;
        private string PLC_Variable_Run_Path;
        private VarEnum PLC_Variable_Run_Type;
        private VariableHandle PLC_Handle_Direction;
        private string PLC_Variable_Direction_Path;
        private VarEnum PLC_Variable_Direction_Type;
        private bool PLC_Direction_Value;
        private Comunicazioni Com;
        public PLC_FastButton()
        {
            InitializeComponent();
            PLC_Handle_Run = null;
            PLC_Handle_Direction = null;
            PLC_Variable_Run_Path = "";
            PLC_Variable_Direction_Path = "";
            PLC_Variable_Run_Type = VarEnum.VT_UNKNOWN;
            PLC_Variable_Direction_Type = VarEnum.VT_UNKNOWN;
            Com = Comunicazioni.Instance;
            ResetDefault();
        }
        public PLC_FastButton(VariableHandle C_Variable_Run, VariableHandle C_Variable_Direction)
        {
            PLC_Handle_Run = null;
            PLC_Handle_Direction = null;
            PLC_Handle_Run = C_Variable_Run;
            PLC_Handle_Direction = C_Variable_Direction;
            Com = Comunicazioni.Instance;
            ResetDefault();
        }
        public void ResetDefault()
        {
            lbl_Value_FastButton.Text = "-";
            lbl_Value_FastButton.BackColor = Color.Transparent;
            Lbl_Direction_FastButton.Text = "-";
            Lbl_Direction_FastButton.BackColor = Color.Transparent;
        }
        public bool Online(bool value)
        {
            bool ReturnValue = false;
            if(!PLC_Variable_Run_Path.Equals("") && (PLC_Variable_Run_Type!=VarEnum.VT_UNKNOWN))
            {
                if (PLC_Handle_Run == null)
                    PLC_Handle_Run = new VariableHandle(Com, PLC_Variable_Run_Path, -1, true, PLC_Variable_Run_Type);
                if (PLC_Handle_Direction == null)
                    PLC_Handle_Direction = new VariableHandle(Com, PLC_Variable_Direction_Path, -1, true, PLC_Variable_Direction_Type);
                if(value)
                {
                    Com.RegisterVariable(PLC_Handle_Run);
                    Com.RegisterVariable(PLC_Handle_Direction);
                    PLC_Handle_Run.OnValueChange += new VariableHandle.OnVariableValueChange(Handle_OnValueChange_Run);
                    PLC_Handle_Direction.OnValueChange += new VariableHandle.OnVariableValueChange(Handle_OnValueChange_Direction);
                    lbl_Value_FastButton.BackColor = Color.Transparent;
                    Lbl_Direction_FastButton.BackColor = Color.Transparent;
                }
                else
                {
                    PLC_Handle_Run.OnValueChange -= new VariableHandle.OnVariableValueChange(Handle_OnValueChange_Run);
                    PLC_Handle_Direction.OnValueChange -= new VariableHandle.OnVariableValueChange(Handle_OnValueChange_Direction);
                    Com.RemoveVariable(PLC_Handle_Run);
                    Com.RemoveVariable(PLC_Handle_Direction);
                    ResetDefault();
                }
            }
            return ReturnValue;
        }
        void Handle_OnValueChange_Run(object sender)
        {
            lbl_Value_FastButton.Invoke((MethodInvoker)delegate
            {
                DisplayValueRun();
            });
        }
        void Handle_OnValueChange_Direction(object sender)
        {
            Lbl_Direction_FastButton.Invoke((MethodInvoker)delegate
            {
                DisplayValueDirection();
            });
        }
        protected void DisplayValueRun()
        {
            if ((PLC_Handle_Run != null) && (PLC_Handle_Run.ActualValue != null))
            {
                bool Result = Convert.ToBoolean(PLC_Handle_Run.ActualValue);
                if (Result)
                    lbl_Value_FastButton.Text = "R1";
                else
                    lbl_Value_FastButton.Text = "R0";
            }
            else
                lbl_Value_FastButton.Text = PLC_Handle_Run.ActualValue.ToString();
        }
        protected void DisplayValueDirection()
        {
            if ((PLC_Handle_Direction != null) && (PLC_Handle_Direction.ActualValue != null))
            {
                bool Result = Convert.ToBoolean(PLC_Handle_Direction.ActualValue);
                if (Result)
                    Lbl_Direction_FastButton.Text = "D1";
                else
                    Lbl_Direction_FastButton.Text = "D0";
            }
            else
                Lbl_Direction_FastButton.Text = PLC_Handle_Direction.ActualValue.ToString();
        }
        [Browsable(true),Description("PLC Variable Run Path"),Category("PLC")]
        public string PLCVariablePathRun
        {
            get
            {
                return PLC_Variable_Run_Path;
            }
            set
            {
                PLC_Variable_Run_Path = value;
            }
        }
        [Browsable(true),Description("PLC Variable Direction Path"),Category("PLC")]
        public string PLCVariablePathDirection
        {
            get
            {
                return PLC_Variable_Direction_Path;
            }
            set
            {
                PLC_Variable_Direction_Path = value;
            }
        }
        [Browsable(true), Description("PLC Direction Value"), Category("PLC")]
        public bool PLCDirectionValue
        {
            get
            {
                return PLC_Direction_Value;
            }
            set
            {
                PLC_Direction_Value = value;
            }
        }
        [Browsable(true),Description("PLC  Variable Type Run"),Category("PLC")]
        public VarEnum PLCVariableTypeRun
        {
            get
            {
                return PLC_Variable_Run_Type;
            }
            set
            {
                PLC_Variable_Run_Type = value;
            }
        }
        [Browsable(true),Description("PLC Variable Type Direction"),Category("PLC")]
        public VarEnum PLCVariableTypeDirection
        {
            get
            {
                return PLC_Variable_Direction_Type;
            }
            set
            {
                PLC_Variable_Direction_Type = value;
            }
        }
        [Browsable(true),Description("PLC Variable Name"),Category("PLC")]
        public string PLCVariableName
        {
            get
            {
                return Btn_FastButton.Text;
            }
            set
            {
                Btn_FastButton.Text = value;
            }
        }

    }
}
