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
    public partial class PLC_Roof : MetroSet_UI.Forms.MetroSetForm
    {
        private VariableHandle PLC_Handle_Open_SX;
        private VariableHandle PLC_Handle_Close_SX;
        private VariableHandle PLC_Handle_Open_DX;
        private VariableHandle PLC_Handle_Close_DX;
        private string PLC_Variable_Path_Open_SX;
        private string PLC_Variable_Path_Close_SX;
        private string PLC_Variable_Path_Open_DX;
        private string PLC_Variable_Path_Close_DX;
        private VarEnum PLC_Variable_Type;
        private Comunicazioni Com;
        public PLC_Roof()
        {
            InitializeComponent();
            PLC_Handle_Close_DX = null;
            PLC_Handle_Close_SX = null;
            PLC_Handle_Open_DX = null;
            PLC_Handle_Open_SX = null;
            PLC_Variable_Path_Close_DX = "";
            PLC_Variable_Path_Close_SX = "";
            PLC_Variable_Path_Open_DX = "";
            PLC_Variable_Path_Open_SX = "";
            PLC_Variable_Type = VarEnum.VT_UNKNOWN;
            Com = Comunicazioni.Instance;
        }
        public PLC_Roof(VariableHandle C_Variable)
        {
            InitializeComponent();
            PLC_Handle_Close_DX = null;
            PLC_Handle_Close_SX = null;
            PLC_Handle_Open_DX = null;
            PLC_Handle_Open_SX = null;
            Com = Comunicazioni.Instance;
        }
        public void ResetDefault()
        {
            PB_RoofSX.ProgressColor = Color.FromName("Control");
            PB_Roof_DX.ProgressColor = Color.White;
            PB_RoofSX.Value = 100;
            PB_Roof_DX.Value = 0;
        }
        public bool Online(bool value)
        {
            bool ReturnValue = false;
            if(!PLC_Variable_Path_Open_SX.Equals("")&& !PLC_Variable_Path_Close_SX.Equals("") && !PLC_Variable_Path_Open_DX.Equals("") && !PLC_Variable_Path_Close_DX.Equals("")&&(PLC_Variable_Type!=VarEnum.VT_UNKNOWN))
            {
                if (PLC_Handle_Open_SX == null)
                    PLC_Handle_Open_SX = new VariableHandle(Com, PLC_Variable_Path_Open_SX, -1, true);
                if (PLC_Handle_Close_SX == null)
                    PLC_Handle_Close_SX = new VariableHandle(Com, PLC_Variable_Path_Close_SX, -1, true);
                if (PLC_Handle_Open_DX == null)
                    PLC_Handle_Open_DX = new VariableHandle(Com, PLC_Variable_Path_Open_DX, -1, true);
                if (PLC_Handle_Close_DX == null)
                    PLC_Handle_Close_DX = new VariableHandle(Com, PLC_Variable_Path_Close_DX, -1, true);
                if (value)
                {
                    Com.RegisterVariable(PLC_Handle_Open_SX);
                    PLC_Handle_Open_SX.OnValueChange += new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                    Com.RegisterVariable(PLC_Handle_Close_SX);
                    PLC_Handle_Close_SX.OnValueChange += new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                    Com.RegisterVariable(PLC_Handle_Open_DX);
                    PLC_Handle_Open_DX.OnValueChange += new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                    Com.RegisterVariable(PLC_Handle_Close_DX);
                    PLC_Handle_Close_DX.OnValueChange += new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                }
                else
                {
                    PLC_Handle_Open_SX.OnValueChange -= new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                    PLC_Handle_Close_SX.OnValueChange -= new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                    PLC_Handle_Open_DX.OnValueChange -= new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                    PLC_Handle_Close_DX.OnValueChange -= new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                    Com.RemoveVariable(PLC_Handle_Open_SX);
                    Com.RemoveVariable(PLC_Handle_Close_SX);
                    Com.RemoveVariable(PLC_Handle_Open_DX);
                    Com.RemoveVariable(PLC_Handle_Close_DX);
                    ResetDefault();
                }

            }
            return ReturnValue;
        }
        void Handle_OnValueChange(object sender)
        {
            PB_RoofSX.Invoke((MethodInvoker)delegate
            {
                DisplayValue();
            });
            PB_Roof_DX.Invoke((MethodInvoker)delegate
            {
                DisplayValue();
            });
        }
        protected void DisplayValue()
        {
            if((PLC_Handle_Open_SX!=null)&&(PLC_Handle_Close_SX!=null)&&(PLC_Handle_Open_SX.ActualValue!=null)&&(PLC_Handle_Close_SX.ActualValue!=null)&&(PLC_Handle_Open_DX!=null)&&(PLC_Handle_Close_DX!=null)&&(PLC_Handle_Open_DX.ActualValue!=null)&&(PLC_Handle_Close_DX.ActualValue!=null))
            {
                bool Closed_SX = Convert.ToBoolean(PLC_Handle_Close_SX.ActualValue);
                bool Closed_DX = Convert.ToBoolean(PLC_Handle_Close_DX.ActualValue);
                bool Opened_SX = Convert.ToBoolean(PLC_Handle_Open_SX.ActualValue);
                bool Opened_DX = Convert.ToBoolean(PLC_Handle_Open_DX.ActualValue);
                if (Closed_SX && Closed_DX)
                {
                    PB_RoofSX.Value = 100;
                    PB_Roof_DX.Value = 0;
                }
                else if(Closed_SX && Opened_DX)
                {
                    PB_RoofSX.Value = 100;
                    PB_Roof_DX.Value = 100;
                }
                else if(Opened_SX && Closed_DX)
                {
                    PB_RoofSX.Value = 0;
                    PB_Roof_DX.Value = 0;
                }
                else if(Opened_SX && Opened_DX)
                {
                    PB_RoofSX.Value = 0;
                    PB_Roof_DX.Value = 100;
                }
                else
                {
                    PB_RoofSX.ProgressColor = Color.Red;
                    PB_Roof_DX.BackColor = Color.Red;
                    PB_RoofSX.Value = 100;
                    PB_Roof_DX.Value = 0;
                }
            }
        }
        [Browsable(true),Description("Variable Path"),Category("PLC")]
        public string PLCVariablePathLeftOpen
        {
            get
            {
                return PLC_Variable_Path_Open_SX;
            }
            set
            {
                PLC_Variable_Path_Open_SX = value;
            }
        }
        [Browsable(true),Description("Variable Path"),Category("PLC")]
        public string PLCVariablePathLeftClose
        {
            get
            {
                return PLC_Variable_Path_Close_SX;
            }
            set
            {
                PLC_Variable_Path_Close_SX = value;
            }
        }
        [Browsable(true), Description("Variable Path"), Category("PLC")]
        public string PLCVariablePathRightOpen
        {
            get
            {
                return PLC_Variable_Path_Open_DX;
            }
            set
            {
                PLC_Variable_Path_Open_DX = value;
            }
        }
        [Browsable(true), Description("Variable Path"), Category("PLC")]
        public string PLCVariablePathRightClose
        {
            get
            {
                return PLC_Variable_Path_Close_DX;
            }
            set
            {
                PLC_Variable_Path_Close_DX = value;
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
    }
}
