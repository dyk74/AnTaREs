using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPCAutomation;
using OPC.Data;
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
            private string LS_GroupName;
            private int LI_UpdateRate;
            private int LI_HandleCreated;
            public delegate void OnPLCValueChange(object sender, int ClientHandle, object NewValue);
            public delegate void OnPLCWriteComplete(object sender, int ClientHandle, int TransactionID);
            public event OnPLCValueChange OnValueChange;
            public event OnPLCWriteComplete OnWriteComplete;
            public Comunicazioni(string PLCName, string GroupName, int UpdateRate)
            {
                try
                {
                    LO_TheServer = new OPCServer();
                    LS_GroupName = GroupName;
                    LS_PLCName = PLCName;
                    LI_UpdateRate = UpdateRate;
                }
                catch (Exception ex)
                {
                    throw new Exception("Errore di comunicazione: " + ex.Message);
                }
            }
            public static Comunicazioni Instance
            {
                get
                {
                    if(instance==null)
                    {
                        instance = new Comunicazioni("Kepware.KEPServerEX.V5", "myGroup", 1000);
                    }
                    return instance;
                }
            }
            public bool IsConnected()
            {
                if (LO_TheServer == null)
                    return false;
                SERVERSTATUS status;
                LO_TheServer.GetStatus(out status);
                OPCSERVERSTATE state;
                state = status.eServerState;
                if (state == OPCSERVERSTATE.OPC_STATUS_RUNNING)
                    return true;
                else
                    return false;
            }
            public void Disconnect()
            {
                try
                {
                    LO_MyGroup.Active = false;
                    LO_MyGroup.DataChanged -= new DataChangeEventHAndler(OnDataChanged);
                    LO_MyGroup.ReadCompleted -= new ReadCompleteEventHandler(OnReadCompleted);
                    LO_MyGroup.WriteCompleted -= new WriteCompleteEventHandler(OnWriteCompleted);
                    LO_TheServer.Disconnect();
                }
                catch(Exception ex)
                {
                    throw new Exception("Errore di connessione: " + ex.Message);
                }
            }
            public bool RemoveVariable(VariableHandle cvar)
            {
                int[] retVal;
                int[] OPLHndServer = new int[1];
                OPLHndServer[0] = cvar.VariableHandleServer;
                bool result = false;
                result = LO_MyGroup.RemoveItems(OPLHndServer, out retVal);
                return result;
            }
            public OPCItemResult RegisterVariable(VariableHandle cvar)
            {
                OPCItemResult[] retVal;
                OPCItemDef[] oPLCItemDef = new OPCItemDef[1];
                oPLCItemDef[0] = new OPCItemDef(cvar.VariablePath, true, LI_HandleCreated, VarEnum.VT_EMPTY);
                LO_MyGroup.AddItems(oPLCItemDef, out retVal);
                cvar.VariableHandle = LI_HandleCreated;
                cvar.VariableHandleServer = retVal[0].HandleServer;
                LI_HandleCreated += 1;
                return retVal[0];
            }
            public void AsyncRead(OPCItemResult oItem)
            {
                int CancelID = 0;
                int[] ArrayErr = new int[1];
                int[] ArrayItem = new int[1];
                ArrayItem[0] = oItem.HandleServer;
                try
                {
                    LO_MyGroup.AsyncRead(ArrayItem, 55667788, out CancelID, out ArrayErr);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            public string SyncRead(OPCItemResult oItem)
            {
                string retVal = "";
                int[] ArrayErr = new int[1];
                int[] ArrayItem = new int[1];
                OPCItemState[] ArrayResult = new OPCItemState[1];
                ArrayItem[0] = oItem.HandleServer;
                try
                {
                    LO_MyGroup.SyncRead(OPC.Data.Interface.OPCDATASOURCE.OPC_DS_DEVICE, ArrayItem, out ArrayResult);
                    retVal = ArrayResult[0].DataValue.ToString();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                return retVal;
            }
            public void write(VariableHandle variable, object newValue)
            {
                int[] aE = new int[1];
                int[] handle = new int[1];
                object[] ItemValues = new object[1];
                handle[0] = variable.VariableHandleServer;
                ItemValues[0] = newValue;
                try
                {
                    LO_MyGroup.SyncWrite(handle, ItemValues, out aE);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            public void ASyncWrite(VariableHandle variable, object newValue)
            {
                Random random = new Random();
                int[] ae = new int[1];
                int CancelID;
                int[] handle = new int[1];
                object[] ItemValues = new object[1];
                handle[0] = variable.VariableHandleServer;
                ItemValues[0] = newValue;
                try
                {
                    LO_MyGroup.AsyncWrite(handle, ItemValues, random.Next(10000000, 9999999), out CancelID, out ae);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            void OnWriteCompleted(object sender,WriteCompleteEventArgs e)
            {
                Console.WriteLine("Write Complete: " + e.TransactionID.ToString());
                foreach (OPCWriteResult s in e.res)
                {
                    if(s.Error>0)
                    {
                        throw new Exception("Error Read:" + s.Error.ToString());
                    }
                    else
                    {
                        OnWriteComplete(this, e);
                    }
                }
            }
            void UpdateData(OPCItemState[] e)
            {
                //
            }
            void OnReadCompleted(object sender, ReadCompleteEventArgs e)
            {
                Console.WriteLine("Read Complete: " + e.TransactionID.ToString());
                foreach(OPCItemState s in e.sts)
                {
                    if(s.Error>0)
                    {
                        throw new Exception("Error in Read:" + s.Error.ToString());
                    }
                    else
                    {
                        OnValueChange(this, s);
                    }
                }
            }
            void OnDataChanged(object sender, DataChangeEventArgs e)
            {
                Console.WriteLine("Data Change Event: " + e.TransactionID.ToString());
                foreach(OPCItemState s in e.sts)
                {
                    if(s.Error>0)
                    {
                        throw new Exception("Error in read: " + s.Error.ToString());
                    }
                    else
                    {
                        OnValueChange(this, s);
                    }
                }
            }
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
