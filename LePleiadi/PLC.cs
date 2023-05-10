using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using static LePleiadi.Comunicazione;


namespace LePleiadi
{
    class PLC
    {
        public  class AlarmUPS
        {
            public static VariableHandle LO_Handle;
            private string LS_PathVarPLC;
            private VarEnum LO_TypeVarPLC;
            private Comunicazioni LO_Com;
            private static bool ResetAvailable = false;      
            public void resetAsDefault()
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
            public AlarmUPS()
            {
                LO_Handle = null;
                LS_PathVarPLC = "";
                LO_TypeVarPLC = VarEnum.VT_UNKNOWN;
                LO_Com = Comunicazioni.Instance;
                Alarm_BTN("normal");
                resetAsDefault();
            }
            public AlarmUPS(VariableHandle OVariable)
            {
                LO_Handle = null;
                LO_Handle = OVariable;
                LO_Com = Comunicazioni.Instance;
                Alarm_BTN("normal");
                resetAsDefault();
            }
            public static void setResetAvailable()
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
                        resetAsDefault();
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
        public class PLCRoof
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
            private Comunicazioni LO_Com;
            public PLCRoof()
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
            public PLCRoof(VariableHandle OVariable)
            {
                LO_HandleLeftClose = null;
                LO_HandleLeftOpen = null;
                LO_HandleRightClose = null;
                LO_HandleRightOpen = null;
                LO_Com = Comunicazioni.Instance;
            }
            public void resetAsDefault()
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
                        resetAsDefault();
                    }
                }
                return RetVal;
            }
            protected void DisplayValue()
            {

            }
            void LO_Roof_OnValueChange(object sender)
            {
                DisplayValue();
            }
        }
        
    }
}
