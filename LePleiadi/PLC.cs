using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using static LePleiadi.Comunicazione;
using System.Windows.Forms;

namespace LePleiadi
{
    class PLC
    {
        public  class Alarm_UPS
        {
            public static VariableHandle LO_Handle;
            private readonly string LS_PathVarPLC;
            private readonly VarEnum LO_TypeVarPLC;
            private readonly Comunicazioni LO_Com;
            private static readonly bool ResetAvailable = false;      
            public void ResetAsDefault()
            {
                Main.btnUPS.NormalColor = System.Drawing.Color.FromArgb(192, 192, 0);
                Main.btnUPS.NormalBorderColor = System.Drawing.Color.FromArgb(192, 192, 0);
                Main.btnUPS.Enabled = false;
            }
            private static void Alarm_BTN(string status)
            {
                if (status == "normal") { 
                    Main.btnUPS.NormalColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    Main.btnUPS.NormalBorderColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    Main.lblUPS.BackColor = System.Drawing.Color.Transparent;
                    Main.lblUPS.Text = "";
                    Main.btnUPS.Enabled = false;
                    Main.btnUPS.DisabledForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    Main.btnUPS.DisabledBorderColor = System.Drawing.Color.FromArgb(0, 192, 0);
                }
                else if (status == "alarm")
                {
                    Main.btnUPS.NormalColor = System.Drawing.Color.FromArgb(192, 0, 0);
                    Main.btnUPS.NormalBorderColor = System.Drawing.Color.FromArgb(192, 0, 0);
                    Main.btnUPS.Enabled = true;
                    Main.btnUPS.DisabledForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                    Main.btnUPS.DisabledBorderColor = System.Drawing.Color.FromArgb(192, 0, 0);
                    Main.lblUPS.BackColor = System.Drawing.Color.FromArgb(192, 192, 0);
                }
                else if (status == "reset")
                {
                    Main.btnUPS.NormalColor = System.Drawing.Color.FromArgb(192, 192, 0);
                    Main.btnUPS.NormalBorderColor = System.Drawing.Color.FromArgb(192, 192, 0);
                    Main.btnUPS.Enabled = false;
                    Main.btnUPS.DisabledForeColor = System.Drawing.Color.FromArgb(192, 192, 0);
                    Main.btnUPS.DisabledBorderColor = System.Drawing.Color.FromArgb(192, 192, 0);
                    Main.lblUPS.BackColor = System.Drawing.Color.FromArgb(192, 192, 0);
                }
            }
            public Alarm_UPS()
            {
                LO_Handle = null;
                LS_PathVarPLC = "";
                LO_TypeVarPLC = VarEnum.VT_UNKNOWN;
                LO_Com = Comunicazioni.Instance;
                Alarm_BTN("normal");
                ResetAsDefault();
            }
            public Alarm_UPS(VariableHandle OVariable)
            {
                LO_Handle = null;
                LO_Handle = OVariable;
                LO_Com = Comunicazioni.Instance;
                Alarm_BTN("normal");
                ResetAsDefault();
            }
            public static void SetResetAvailable()
            {
                if (!ResetAvailable)
                    Alarm_BTN("normal");
                else
                    Alarm_BTN("alarm");
            }
            public bool OnLine(bool value)
            {
                bool RetVal = false;
                if(!LS_PathVarPLC.Equals("")&&(LO_TypeVarPLC!=VarEnum.VT_UNKNOWN))
                {
                    Main.lblUPS.BackColor = System.Drawing.Color.Transparent;
                    if(LO_Handle==null)
                    {
                        LO_Handle = new VariableHandle(LO_Com, LS_PathVarPLC, -1, true);
                    }
                    if(value)
                    {
                        LO_Com.RegisterVariable(LO_Handle);
                        LO_Handle.OnValueChange += new VariableHandle.OnVarValueChange(LO_Handle_OnValueChange);
                    }
                    else
                    {
                        LO_Handle.OnValueChange -= new VariableHandle.OnVarValueChange(LO_Handle_OnValueChange);
                        LO_Com.RemoveVariable(LO_Handle);
                        ResetAsDefault();
                    }
                }
                return RetVal;
            }
            private void DisplayAlarm()
            {
                if ((LO_Handle != null) && (LO_Handle.ActualValue != null))
                    Alarm_BTN("alarm");
                else
                    Alarm_BTN("normal");
            }
            void LO_Handle_OnValueChange(object sender)
            {
                DisplayAlarm();
            }
        }
        public class PLC_Roof
        {
            private VariableHandle LO_HandleLeftOpen;
            private VariableHandle LO_HandleLeftClose;
            private VariableHandle LO_HandleRightOpen;
            private VariableHandle LO_HandleRightClose;
            private string LS_PathVarPLCLeftOpen;
            private string LS_PathVarPLCLeftClose;
            private string LS_PathVarPLCRightOpen;
            private string LS_PathVarPLCRightClose;
            private VarEnum LO_TypeVarPLC;
            private readonly Comunicazioni LO_Com;
            public PLC_Roof()
            {
                LO_HandleLeftOpen = null;
                LO_HandleLeftClose = null;
                LO_HandleRightClose = null;
                LO_HandleRightOpen = null;
                LS_PathVarPLCLeftClose = "";
                LS_PathVarPLCLeftOpen = "";
                LS_PathVarPLCRightClose = "";
                LS_PathVarPLCRightOpen = "";
                LO_TypeVarPLC = VarEnum.VT_UNKNOWN;
                LO_Com = Comunicazioni.Instance;
            }
            public PLC_Roof(VariableHandle OVariable)
            {
                LO_HandleLeftClose = null;
                LO_HandleLeftOpen = null;
                LO_HandleRightClose = null;
                LO_HandleRightOpen = null;
                LO_Com = Comunicazioni.Instance;
            }
            public void ResetAsDefault()
            {
                Main.RoofOpenClose.DisabledBackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                Main.RoofOpenClose.Text = "Closed";
                Main.RoofOpenClose.DisabledForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            }
            public bool Online(bool value)
            {
                bool RetVal = false;
                if(!LS_PathVarPLCLeftOpen.Equals("") && !LS_PathVarPLCLeftClose.Equals("") && !LS_PathVarPLCRightClose.Equals("") && !LS_PathVarPLCRightOpen.Equals("") && (LO_TypeVarPLC!=VarEnum.VT_UNKNOWN))
                {
                    if (LO_HandleLeftOpen == null)
                        LO_HandleLeftOpen = new VariableHandle(LO_Com, LS_PathVarPLCLeftOpen, -1, true);
                    if (LO_HandleLeftClose == null)
                        LO_HandleLeftClose = new VariableHandle(LO_Com, LS_PathVarPLCLeftClose, -1, true);
                    if (LO_HandleRightOpen == null)
                        LO_HandleRightOpen = new VariableHandle(LO_Com, LS_PathVarPLCRightOpen, -1, true);
                    if (LO_HandleRightClose == null)
                        LO_HandleRightClose = new VariableHandle(LO_Com, LS_PathVarPLCRightClose, -1, true);
                    if(value)
                    {
                        LO_Com.RegisterVariable(LO_HandleLeftOpen);
                        LO_HandleLeftOpen.OnValueChange += new VariableHandle.OnVarValueChange(LO_Roof_OnValueChange);
                        LO_Com.RegisterVariable(LO_HandleLeftClose);
                        LO_HandleLeftClose.OnValueChange+= new VariableHandle.OnVarValueChange(LO_Roof_OnValueChange);
                        LO_Com.RegisterVariable(LO_HandleRightOpen);
                        LO_HandleRightOpen.OnValueChange+=new VariableHandle.OnVarValueChange(LO_Roof_OnValueChange);
                        LO_Com.RegisterVariable(LO_HandleRightClose);
                        LO_HandleRightClose.OnValueChange += new VariableHandle.OnVarValueChange(LO_Roof_OnValueChange);
                    }
                    else
                    {
                        LO_HandleLeftOpen.OnValueChange -= new VariableHandle.OnVarValueChange(LO_Roof_OnValueChange);
                        LO_HandleLeftClose.OnValueChange -= new VariableHandle.OnVarValueChange(LO_Roof_OnValueChange);
                        LO_HandleRightOpen.OnValueChange -= new VariableHandle.OnVarValueChange(LO_Roof_OnValueChange);
                        LO_HandleRightClose.OnValueChange -= new VariableHandle.OnVarValueChange(LO_Roof_OnValueChange);
                        LO_Com.RemoveVariable(LO_HandleLeftOpen);
                        LO_Com.RemoveVariable(LO_HandleLeftClose);
                        LO_Com.RemoveVariable(LO_HandleRightOpen);
                        LO_Com.RemoveVariable(LO_HandleRightClose);
                        ResetAsDefault();
                    }
                }
                return RetVal;
            }
            protected void DisplayValue()
            {
                if((LO_HandleLeftClose!=null && LO_HandleLeftClose.ActualValue!=null) && (LO_HandleLeftOpen!=null && LO_HandleLeftOpen.ActualValue!=null) && (LO_HandleRightClose!=null && LO_HandleRightClose.ActualValue!=null) &&(LO_HandleRightOpen!=null && LO_HandleRightOpen.ActualValue!=null))
                {
                    bool RightOpen = Convert.ToBoolean(LO_HandleRightOpen.ActualValue);
                    bool RightClose = Convert.ToBoolean(LO_HandleRightClose.ActualValue);
                    bool LeftOpen = Convert.ToBoolean(LO_HandleLeftOpen.ActualValue);
                    bool LeftClose = Convert.ToBoolean(LO_HandleLeftClose.ActualValue);
                    if(RightClose && LeftClose)
                    {
                        Main.RoofOpenClose.DisabledBackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                        Main.RoofRight.DisabledBackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                        Main.RoofLeft.DisabledBackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                    }
                    else if(RightOpen && LeftClose)
                    {
                        Main.RoofOpenClose.DisabledBackColor = System.Drawing.Color.FromArgb(192, 192, 192);
                        Main.RoofLeft.DisabledBackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                        Main.RoofRight.DisabledBackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                    }
                    else if(RightOpen && LeftOpen)
                    {
                        Main.RoofOpenClose.DisabledBackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                        Main.RoofLeft.DisabledBackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                        Main.RoofRight.DisabledBackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                    }
                    else if(RightClose && LeftOpen)
                    {
                        Main.RoofOpenClose.DisabledBackColor = System.Drawing.Color.FromArgb(192, 192, 192);
                        Main.RoofLeft.DisabledBackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                        Main.RoofRight.DisabledBackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                    }
                    else
                    {
                        Main.RoofOpenClose.DisabledBackColor = System.Drawing.Color.FromArgb(192, 0, 0);
                        Main.RoofLeft.DisabledBackColor = System.Drawing.Color.FromArgb(192, 0, 0);
                        Main.RoofRight.DisabledBackColor = System.Drawing.Color.FromArgb(192, 0, 0);
                    }
                }
            }
            void LO_Roof_OnValueChange(object sender)
            {
                DisplayValue();
            }
            public string PathVarPLC_OpenRightRoof
            {
                get
                {
                    return LS_PathVarPLCRightOpen;
                }
                set
                {
                    LS_PathVarPLCRightOpen = value;
                }
            }
            public string PathVarPLC_CloseRightRoof
            {
                get
                {
                    return LS_PathVarPLCRightClose;
                }
                set
                {
                    LS_PathVarPLCRightClose = value;
                }
            }
            public string PathVarPLC_OpenLeftRoof
            {
                get
                {
                    return LS_PathVarPLCLeftOpen;
                }
                set
                {
                    LS_PathVarPLCLeftOpen = value;
                }
            }
            public string PathVarPLC_CloseLeftRoof
            {
                get
                {
                    return LS_PathVarPLCLeftClose;
                }
                set
                {
                    LS_PathVarPLCLeftClose = value;
                }
            }
            public VarEnum Type
            {
                get
                {
                    return LO_TypeVarPLC;
                }
                set
                {
                    LO_TypeVarPLC = value;
                }
            }
        }
        public class PLC_FastValue
        {
            private VariableHandle LO_Handle;
            private string LS_PathVarPLC;
            private VarEnum LO_TypeVarPLC;
            private readonly Comunicazioni LO_Com;
            private bool LB_Modifiable;
            private Color LC_ColorOnTrue;
            private Color LC_ColorOnFalse;
            public PLC_FastValue()
            {
                LO_Handle = null;
                LS_PathVarPLC = "";
                LO_TypeVarPLC = VarEnum.VT_UNKNOWN;
                LO_Com = Comunicazioni.Instance;
                LB_Modifiable = false;
            }
            public PLC_FastValue(VariableHandle OVariable)
            {
                LO_Handle = null;
                LO_Handle = OVariable;
                LO_Com = Comunicazioni.Instance;
                LB_Modifiable = false;
            }
            public void ResetAsDefault()
            {
                Main.LblPLCVariableValue.Text = "";
                LB_Modifiable = false;
                Main.LblPLCVariableValue.BackColor = Color.Yellow;
            }
            public bool OnLine(bool value)
            {
                bool RetVal = false;
                if(!LS_PathVarPLC.Equals("")&&(LO_TypeVarPLC!=VarEnum.VT_UNKNOWN))
                {
                    if(LO_Handle==null)
                    {
                        LO_Handle = new VariableHandle(LO_Com, LS_PathVarPLC, -1, true, LO_TypeVarPLC);
                    }
                    if(value)
                    {
                        LO_Com.RegisterVariable(LO_Handle);
                        LO_Handle.OnValueChange += new VariableHandle.OnVarValueChange(LO_Handle_OnValueChange);
                    }
                    else
                    {
                        LO_Handle.OnValueChange -= new VariableHandle.OnVarValueChange(LO_Handle_OnValueChange);
                        LO_Com.RemoveVariable(LO_Handle);
                        ResetAsDefault();
                    }
                }
                return RetVal;
            }
            protected void DisplayValue()
            {
                if((LO_Handle!=null)&&(LO_Handle.ActualValue!=null))
                {
                    if(LO_Handle.VariableType==VarEnum.VT_BOOL)
                    {
                        bool res = Convert.ToBoolean(LO_Handle.ActualValue);
                        Main.LblPLCVariableValue.Text = res.ToString();
                        if(res)
                        {
                            Main.LblPLCVariableValue.BackColor = LC_ColorOnTrue;
                        }
                        else
                        {
                            Main.LblPLCVariableValue.BackColor = LC_ColorOnFalse;
                        }
                    }
                    else
                    {
                        Main.LblPLCVariableValue.Text = LO_Handle.ActualValue.ToString();
                    }
                }  
            }
            void LO_Handle_OnValueChange(object sender)
            {
                DisplayValue();
            }
            public string PathVarPLC
            {
                get
                {
                    return LS_PathVarPLC;
                }
                set
                {
                    LS_PathVarPLC = value;
                }
            }
            public VarEnum Type
            {
                get
                {
                    return LO_TypeVarPLC;
                }
                set
                {
                    LO_TypeVarPLC = value;
                }
            }
            public string VariableName
            {
                get
                {
                    return Main.LblPLCVariableName.Text;
                }
                set
                {
                    Main.LblPLCVariableName.Text = value;
                }
            }
            public Color ColorOnTrue
            {
                get
                {
                    return LC_ColorOnTrue;
                }
                set
                {
                    LC_ColorOnTrue = value;
                }
            }
            public Color ColorOnFalse
            {
                get
                {
                    return LC_ColorOnFalse;
                }
                set
                {
                    LC_ColorOnFalse = value;
                }
            }
            public bool Modifiable
            {
                get
                {
                    return LB_Modifiable;
                }
                set
                {
                    if (LO_Handle != null)
                    {
                        LO_Handle.Modifiable = value;
                        LB_Modifiable = value;
                    }
                    else
                        LB_Modifiable = value;
                }
            }
        }
        public class PLC_ChangeValue
        {
            private static VariableHandle LO_HandleRun;
            private string LS_PathVarPLCRun;
            private VarEnum LO_TypeVarPLCRun;
            private static VariableHandle LO_HandleDirection;
            private string LS_PathVarPLCDirection;
            private VarEnum LO_TypeVarPLCDirection;
            private static bool LB_DirectionValue;
            private readonly Comunicazioni LO_Com;
            public PLC_ChangeValue()
            {
                LO_HandleRun = null;
                LS_PathVarPLCRun = "";
                LO_TypeVarPLCRun = VarEnum.VT_UNKNOWN;
                LO_HandleDirection = null;
                LS_PathVarPLCDirection = "";
                LO_TypeVarPLCDirection = VarEnum.VT_UNKNOWN;
                LO_Com = Comunicazioni.Instance;
                ResetDefault();
            }
            public PLC_ChangeValue(VariableHandle OVariableRun, VariableHandle OVariableDirection)
            {
                LO_HandleRun = null;
                LO_HandleRun = OVariableRun;
                LO_HandleDirection = null;
                LO_HandleDirection = OVariableDirection;
                LO_Com = Comunicazioni.Instance;
                ResetDefault();
            }
            public void ResetDefault()
            {
                Main.lblValueDirection.Text = "-";
                Main.lblValueRun.Text = "-";
                Main.lblValueDirection.BackColor = Color.Yellow;
                Main.lblValueRun.BackColor = Color.Yellow;
            }
            public bool Online(bool value)
            {
                bool retVal = false;
                if(!LS_PathVarPLCRun.Equals("")&&(LO_TypeVarPLCRun!=VarEnum.VT_UNKNOWN))
                {
                    if (LO_HandleRun == null)
                        LO_HandleRun = new VariableHandle(LO_Com, LS_PathVarPLCRun, -1, true, LO_TypeVarPLCRun);
                    if (LO_HandleDirection == null)
                        LO_HandleDirection = new VariableHandle(LO_Com, LS_PathVarPLCDirection, -1, true, LO_TypeVarPLCDirection);
                    if(value)
                    {
                        LO_Com.RegisterVariable(LO_HandleRun);
                        LO_HandleRun.OnValueChange += new VariableHandle.OnVarValueChange(LO_Handle_OnValueChangeRun);
                        LO_Com.RegisterVariable(LO_HandleDirection);
                        LO_HandleDirection.OnValueChange += new VariableHandle.OnVarValueChange(LO_Handle_OnValueChangeDirection);
                        Main.lblValueRun.BackColor = Color.Transparent;
                        Main.lblValueDirection.BackColor = Color.Transparent;
                    }
                    else
                    {
                        LO_HandleRun.OnValueChange -= new VariableHandle.OnVarValueChange(LO_Handle_OnValueChangeRun);
                        LO_Com.RemoveVariable(LO_HandleRun);
                        LO_HandleDirection.OnValueChange -= new VariableHandle.OnVarValueChange(LO_Handle_OnValueChangeDirection);
                        LO_Com.RemoveVariable(LO_HandleDirection);
                        ResetDefault();
                    }
                }
                return retVal;
            }
            void LO_Handle_OnValueChangeRun(object sender)
            {
                DisplayValueRun();
            }
            void LO_Handle_OnValueChangeDirection(object sender)
            {
                DisplayValueDirection();
            }
            protected void DisplayValueRun()
            {
                if((LO_HandleRun!=null)&&(LO_HandleRun.ActualValue!=null))
                {
                    if (LO_HandleRun.VariableType == VarEnum.VT_BOOL)
                    {
                        bool res = Convert.ToBoolean(LO_HandleRun.ActualValue);
                        if (res)
                            Main.lblValueRun.Text = "R1";
                        else
                            Main.lblValueRun.Text = "R0";
                    }
                    else
                        Main.lblValueRun.Text = LO_HandleRun.ActualValue.ToString();
                }
            }
            protected void DisplayValueDirection()
            {
                if((LO_HandleDirection!=null)&&(LO_HandleDirection.ActualValue!=null))
                {
                    if (LO_HandleDirection.VariableType == VarEnum.VT_BOOL)
                    {
                        bool res = Convert.ToBoolean(LO_HandleDirection.ActualValue);
                        if (res)
                            Main.lblValueDirection.Text = "D1";
                        else
                            Main.lblValueDirection.Text = "D0";
                    }
                    else
                        Main.lblValueDirection.Text = LO_HandleDirection.ActualValue.ToString();
                }
            }
            public string PathVarPLCRun
            {
                get
                {
                    return LS_PathVarPLCRun;
                }
                set
                {
                    LS_PathVarPLCRun = value;
                }
            }
            public string PathVarPLCDirection
            {
                get
                {
                    return LS_PathVarPLCDirection;
                }
                set
                {
                    LS_PathVarPLCDirection = value;
                }
            }
            public bool DirectionValue
            {
                get
                {
                    return LB_DirectionValue;
                }
                set
                {
                    LB_DirectionValue = value;
                }
            }
            public VarEnum TypeRun
            {
                get
                {
                    return LO_TypeVarPLCRun;
                }
                set
                {
                    LO_TypeVarPLCRun = value;
                }
            }
            public VarEnum TypeDirection
            {
                get
                {
                    return LO_TypeVarPLCDirection;
                }
                set
                {
                    LO_TypeVarPLCDirection = value;
                }
            }
            public string VariableName
            {
                get
                {
                    return Main.btnEvent.Text;
                }
                set
                {
                    Main.btnEvent.Text = value;
                }
            }
            public static void BtnEvent_Click(object sender, System.EventArgs e)
            {
                if (LO_HandleDirection.Write(LB_DirectionValue))
                {
                    if(LO_HandleRun.Write(true))
                    {
                        //
                    }
                }
            }
        }
        public class PLC_CPU
        {
            private VariableHandle LO_HandleErrorCode;
            private VariableHandle LO_HandleUnit;
            private string LS_PathVarPLCUnit;
            private string LS_PathVarPLCErrorCode;
            private VarEnum LO_TypeVarPLCUnit;
            private VarEnum LO_TypeVarPLCErrorCode;
            private readonly Comunicazioni LO_Com;
            private int UnityNumber;
            private static int ErrValue = -1;
            public PLC_CPU()
            {
                LO_HandleUnit = null;
                LS_PathVarPLCUnit = "";
                LO_TypeVarPLCUnit = VarEnum.VT_UNKNOWN;
                LO_HandleErrorCode = null;
                LS_PathVarPLCErrorCode = "";
                LO_TypeVarPLCErrorCode = VarEnum.VT_UNKNOWN;
                LO_Com = Comunicazioni.Instance;
            }
            public void ResetDefault()
            {
                Main.lblErrorCode.Text = "";
                Main.lblUnit.Text = "";
            }
            public bool Online(bool value)
            {
                bool retVal = false;
                if(!LS_PathVarPLCUnit.Equals("") && !LS_PathVarPLCErrorCode.Equals("") && (LO_TypeVarPLCErrorCode!=VarEnum.VT_UNKNOWN) &&(LO_TypeVarPLCUnit!=VarEnum.VT_UNKNOWN))
                {
                    if (LO_HandleUnit==null)
                        LO_HandleUnit = new VariableHandle(LO_Com, LS_PathVarPLCUnit, -1, true);
                    if (LO_HandleErrorCode == null)
                        LO_HandleErrorCode = new VariableHandle(LO_Com, LS_PathVarPLCErrorCode, -1, true);
                    if(value)
                    {
                        LO_Com.RegisterVariable(LO_HandleUnit);
                        LO_HandleUnit.OnValueChange += new VariableHandle.OnVarValueChange(LO_HandleUnit_OnValueChange);
                        LO_Com.RegisterVariable(LO_HandleErrorCode);
                        LO_HandleErrorCode.OnValueChange += new VariableHandle.OnVarValueChange(LO_HandleErrorCode_OnValueChange);
                    }
                    else
                    {
                        LO_HandleUnit.OnValueChange -= new VariableHandle.OnVarValueChange(LO_HandleUnit_OnValueChange);
                        LO_Com.RemoveVariable(LO_HandleUnit);
                        LO_HandleErrorCode.OnValueChange -= new VariableHandle.OnVarValueChange(LO_HandleErrorCode_OnValueChange);
                        LO_Com.RemoveVariable(LO_HandleErrorCode);
                        ResetDefault();
                    }
                }
                return retVal;
            }
            void LO_HandleUnit_OnValueChange(object sender)
            {
                ChangeUnityName();
            }
            void LO_HandleErrorCode_OnValueChange(object sender)
            {
                ChangeErrorCode();
            }
            protected void ChangeUnityName()
            {
                if((LO_HandleUnit!=null)&&(LO_HandleUnit.ActualValue!=null))
                {
                    if (LO_HandleUnit.ActualValue.ToString().Equals(""))
                        Main.lblUnit.Text = "Unit: " + UnityNumber;
                    else
                        Main.lblUnit.Text = LO_HandleUnit.ActualValue.ToString();
                }
            }
            protected void ChangeErrorCode()
            {
                if((LO_HandleErrorCode!=null)&&(LO_HandleErrorCode.ActualValue!=null))
                {
                    Main.lblErrorCode.Text = LO_HandleErrorCode.ActualValue.ToString();
                    if(LO_HandleErrorCode.VariableType==VarEnum.VT_INT)
                    {
                        ErrValue = Convert.ToInt32(LO_HandleErrorCode.ActualValue);
                        if (ErrValue > 0)
                            Main.lblErrorCode.BackColor = Color.Red;
                        else
                            Main.lblErrorCode.BackColor = Color.Green;
                    }
                }
            }
            public string PathVarPLCUnit
            {
                get
                {
                    return LS_PathVarPLCUnit;
                }
                set
                {
                    LS_PathVarPLCUnit = value;
                }
            }
            public VarEnum TypeUnit
            {
                get
                {
                    return LO_TypeVarPLCUnit;
                }
                set
                {
                    LO_TypeVarPLCUnit = value;
                }
            }
            public string PathVarErrorCode
            {
                get
                {
                    return LS_PathVarPLCErrorCode;
                }
                set
                {
                    LS_PathVarPLCErrorCode = value;
                }
            }
            public VarEnum TypeErrorCode
            {
                get
                {
                    return LO_TypeVarPLCErrorCode;
                }
                set
                {
                    LO_TypeVarPLCErrorCode = value;
                }
            }
            public int UnitNumber
            {
                get
                {
                    return UnityNumber;
                }
                set
                {
                    UnityNumber = value;
                }
            }
            public static void LblErrorCode_Click(object sender, EventArgs e)
            {

                if (ErrValue >= 0)
                    MessageBox.Show("Binary: " + Convert.ToString(Convert.ToByte(ErrValue), 2));
                else
                    MessageBox.Show("Error reading data");
            }
        }
        public class PLC_Value
        {
            private static VariableHandle LO_Handle;
            private string LS_PathVarPLC;
            private VarEnum LO_TypeVarPLC;
            private readonly Comunicazioni LO_Com;
            private Boolean LB_ResetState = false;
            public PLC_Value()
            {
                LO_Handle = null;
                LS_PathVarPLC = "";
                LO_TypeVarPLC = VarEnum.VT_UNKNOWN;
                LO_Com = Comunicazioni.Instance;
                ResetDefault();
            }
            public PLC_Value(VariableHandle OVariable)
            {
                LO_Handle = null;
                LO_Handle = OVariable;
                LO_Com = Comunicazioni.Instance;
                ResetDefault();
            }
            public void ResetDefault()
            {
                Main.lblChange.Text = "-";
                Main.lblChange.BackColor = Color.Yellow;
            }
            public bool Online(bool value)
            {
                bool retVal = false;
                if(!LS_PathVarPLC.Equals("") &&(LO_TypeVarPLC!=VarEnum.VT_UNKNOWN))
                {
                    if (LO_Handle == null)
                        LO_Handle = new VariableHandle(LO_Com, LS_PathVarPLC, -1, true, LO_TypeVarPLC);
                    if(value)
                    {
                        LO_Com.RegisterVariable(LO_Handle);
                        LO_Handle.OnValueChange += new VariableHandle.OnVarValueChange(LO_Handle_OnValueChange);
                        Main.lblChange.BackColor = Color.Transparent;
                    }
                    else
                    {
                        LO_Handle.OnValueChange -= new VariableHandle.OnVarValueChange(LO_Handle_OnValueChange);
                        LO_Com.RemoveVariable(LO_Handle);
                        ResetDefault();
                    }
                }
                return retVal;
            }
            void LO_Handle_OnValueChange(object sender)
            {
                DisplayValue();
            }
            protected void DisplayValue()
            {
                if((LO_Handle!=null)&&LO_Handle.ActualValue!=null)
                {
                    if (LO_Handle.VariableType == VarEnum.VT_BOOL)
                    {
                        bool res = Convert.ToBoolean(LO_Handle.ActualValue);
                        if (res)
                            Main.lblChange.Text = "1";
                        else
                            Main.lblChange.Text = "0";
                    }
                    else
                        Main.lblChange.Text = LO_Handle.ActualValue.ToString();
                }
            }
            public string PathVarPLC
            {
                get
                {
                    return LS_PathVarPLC;
                }
                set
                {
                    LS_PathVarPLC = value;
                }
            }
            public VarEnum Type
            {
                get
                {
                    return LO_TypeVarPLC;
                }
                set
                {
                    LO_TypeVarPLC = value;
                }
            }
            public string VariableName
            {
                get
                {
                    return Main.btnChange.Text;
                }
                set
                {
                    Main.btnChange.Text = value;
                }
            }
            public Boolean ResetState
            {
                get
                {
                    return LB_ResetState;
                }
                set
                {
                    LB_ResetState = value;
                }
            }
            public static void BtnChange_Click(object sender, EventArgs e)
            {
                LO_Handle.Write(true);
            }
        }
        public class PLC_Toogle
        {
            private static VariableHandle LO_Handle;
            private string LS_PathVarPLC;
            private VarEnum LO_TypeVarPLC;
            private readonly Comunicazioni LO_Com;
            public PLC_Toogle()
            {
                LO_Handle = null;
                LS_PathVarPLC = "";
                LO_TypeVarPLC = VarEnum.VT_UNKNOWN;
                LO_Com = Comunicazioni.Instance;
                ResetDefault();
            }
            private void ResetDefault()
            {
                ChangeCheckButton(false);
                Main.chkToogle.BackgroundColor = Color.Yellow;
            }
            private void ChangeCheckButton(bool value)
            {
                Main.chkToogle.Checked = value;
            }
            public bool Online(bool value)
            {
                bool RetVal = false;
                if((!LS_PathVarPLC.Equals(""))&& (LO_TypeVarPLC!=VarEnum.VT_UNKNOWN))
                {
                    if (LO_Handle == null)
                        LO_Handle = new VariableHandle(LO_Com, LS_PathVarPLC, -1, true);
                    if(value)
                    {
                        LO_Com.RegisterVariable(LO_Handle);
                        LO_Handle.OnValueChange += new VariableHandle.OnVarValueChange(LO_Handle_OnValueChange);
                        Main.chkToogle.BackgroundColor = Color.Transparent;
                    }
                    else
                    {
                        LO_Handle.OnValueChange -= new VariableHandle.OnVarValueChange(LO_Handle_OnValueChange);
                        LO_Com.RemoveVariable(LO_Handle);
                        ResetDefault();
                    }
                }
                return RetVal;
            }
            void LO_Handle_OnValueChange(object sender)
            {
                if((LO_Handle!=null)&&(LO_Handle.ActualValue!=null))
                {
                    bool res = Convert.ToBoolean(LO_Handle.ActualValue);
                    ChangeCheckButton(res);
                }
            }
            public static void ChkToogle_CheckedChanged(object sender)
            {
                if (LO_Handle == null)
                    return;
                bool res = Main.chkToogle.Checked;
                if (res == true || res == false)
                    LO_Handle.Write(res);
            }
            public string PathVarPLC
            {
                get
                {
                    return LS_PathVarPLC;
                }
                set
                {
                    LS_PathVarPLC = value;
                }
            }
            public VarEnum Type
            {
                get
                {
                    return LO_TypeVarPLC;
                }
                set
                {
                    LO_TypeVarPLC = value;
                }
            }
            public string VariableName
            {
                get
                {
                    return Main.chkToogle.Text;
                }
                set
                {
                    Main.chkToogle.Text = value;
                }
            }
        }
        public class PLC_ChainElement
        {
            private VariableHandle LO_Handle;
            private string LS_PathVarPLC;
            private VarEnum LO_TypeVarPLC;
            private readonly Comunicazioni LO_Com;
            private bool LB_AlmOnValue;
            private string LS_ToolTip = "";
            public PLC_ChainElement()
            {
                LO_Handle = null;
                LS_PathVarPLC = "";
                LO_TypeVarPLC = VarEnum.VT_UNKNOWN;
                LO_Com = Comunicazioni.Instance;
                LB_AlmOnValue = true;
                ResetDefault();
            }
            public PLC_ChainElement(VariableHandle OVariable)
            {
                LO_Handle = null;
                LO_Handle = OVariable;
                LO_Com = Comunicazioni.Instance;
                LB_AlmOnValue = true;
                ResetDefault();
            }
            public void ResetDefault()
            {
                Main.eclSecurityChain.NormalColor = Color.Yellow;
            }
            public bool Online(bool value)
            {
                Main.PLC_Tooltip.SetToolTip(Main.lblSecurityChain, LS_ToolTip);
                Main.PLC_Tooltip.SetToolTip(Main.eclSecurityChain, LS_ToolTip);
                bool RetVal = false;
                if(!LS_PathVarPLC.Equals("")&&(LO_TypeVarPLC!=VarEnum.VT_UNKNOWN))
                {
                    if (LO_Handle == null)
                        LO_Handle = new VariableHandle(LO_Com, LS_PathVarPLC, -1, true, LO_TypeVarPLC);
                    if(value)
                    {
                        LO_Com.RegisterVariable(LO_Handle);
                        LO_Handle.OnValueChange += new VariableHandle.OnVarValueChange(LO_Handle_OnValueChange);
                    }
                    else
                    {
                        LO_Handle.OnValueChange -= new VariableHandle.OnVarValueChange(LO_Handle_OnValueChange);
                        LO_Com.RemoveVariable(LO_Handle);
                        ResetDefault();
                    }
                }
                return RetVal;
            }
            void LO_Handle_OnValueChange(object sender)
            {
                DisplayValue();
            }
            protected void DisplayValue()
            {
                if ((LO_Handle != null) && (LO_Handle.ActualValue != null))
                {
                    if (LO_Handle.VariableType == VarEnum.VT_BOOL)
                    {
                        bool res = Convert.ToBoolean(LO_Handle.ActualValue);
                        if (res == LB_AlmOnValue)
                            Main.eclSecurityChain.NormalColor = Color.Red;
                        else
                            Main.eclSecurityChain.NormalColor = Color.Green;
                    }
                }
                else
                    Main.lblSecurityChain.Text = LO_Handle.ActualValue.ToString();
            }
            public string PathVarPLC
            {
                get
                {
                    return LS_PathVarPLC;
                }
                set
                {
                    LS_PathVarPLC = value;
                }
            }
            public VarEnum Type
            {
                get
                {
                    return LO_TypeVarPLC;
                }
                set
                {
                    LO_TypeVarPLC = value;
                }
            }
            public string AlarmName
            {
                get
                {
                    return Main.lblSecurityChain.Text;
                }
                set
                {
                    Main.lblSecurityChain.Text = value;
                }
            }
            public bool AlarmOnValue
            {
                get
                {
                    return LB_AlmOnValue;
                }
                set
                {
                    LB_AlmOnValue = value;
                }
            }
            public string ToolTipTextValue
            {
                get
                {
                    return LS_ToolTip;
                }
                set
                {
                    LS_ToolTip = value;
                }
            }
        }
    }
}
