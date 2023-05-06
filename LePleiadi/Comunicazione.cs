using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPCAutomation;
using System.Runtime.InteropServices;


namespace LePleiadi
{
    class Comunicazione
    {
        public class Comunicazioni
        {
            private static Comunicazioni instance;
            private OPCServer LO_TheServer;
            private OPCGroup LO_MyGroup;
            private string LS_PLCName;
            private int LS_GroupName;
            private int LI_UpdateRate;
            private int LI_HandleCreated;
            public delegate void OnPLCValueChange(object sender, int ClientHandle, object NewValue);
            public delegate void OnPLCWriteComplete(object sender, int ClientHandle, int TransactionID);

        }
        public class Variabili
        {
            protected string LS_Path;
            protected object LO_ActualValue;
            protected VarEnum LO_VarType;
            protected int LI_VarHandle;
            protected int LI_VarHandleServer;
            protected bool LB_Modifiable;
            public Variabili()
            {
                LI_VarHandle = -1;
                LS_Path = "";
                LO_ActualValue = null;
                LO_VarType = VarEnum.VT_UNKNOWN;
                LB_Modifiable = true;
                LI_VarHandleServer = -1;
            }
            public string VariablePath
            {
                get
                {
                    return LS_Path;
                }
                set
                {
                    LS_Path = value;
                }
            }
            public object ActualValue
            {
                get
                {
                    return LO_ActualValue;
                }
                set
                {
                    LO_ActualValue = value;
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
                    LB_Modifiable = value;
                }
            }
            public VarEnum VariableType
            {
                get
                {
                    return LO_VarType;
                }
                set
                {
                    LO_VarType = value;
                }
            }
            public int VariableHandle
            {
                get
                {
                    return LI_VarHandle;
                }
                set
                {
                    LI_VarHandle = value;
                }
            }
            public int VariableHandleServer
            {
                get
                {
                    return LI_VarHandleServer;
                }
                set
                {
                    LI_VarHandleServer = value;
                }
            }
        }       
    }
}
