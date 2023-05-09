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
            private VariableHandle LO_Handle;
            private string LS_PathVarPLC;
            private VarEnum LO_TypeVarPLC;
            private Comunicazioni LO_Com;
            private bool ResetAvailable = false;
            public AlarmUPS()
            {
                LO_Handle = null;
                LS_PathVarPLC = "";
                LO_TypeVarPLC = VarEnum.VT_UNKNOWN;
                LO_Com = Comunicazioni.Instance;

            }
        }
    }
}
