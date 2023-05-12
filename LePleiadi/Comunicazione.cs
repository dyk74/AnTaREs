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
        public class VariableHandle:Variabili
        {
            private readonly Comunicazioni LO_Com;
            public delegate void OnVarValueChange(object sender);
            public delegate void OnVarWriteComplete(object sender);
            public event OnVarValueChange OnValueChange;
            public event OnVarWriteComplete OnWriteComplete;
            public OPCAutomation.OPCItem VarOPCItem { get; set; }
            public bool WritePending { get; set; }
            public int WriteTransactionID { get; set; }
            public VariableHandle(Comunicazioni Com, string Path, int VarHandle, bool Modifiable)
            {
                LO_Com = Com;
                LS_Path = Path;
                LI_VarHandle = VarHandle;
                LO_ActualValue = null;
                LB_Modifiable = Modifiable;
                LO_VarType = VarEnum.VT_UNKNOWN;
                LO_Com.OnValueChange += new Comunicazioni.OnPLCValueChange(LO_Com_OnValueChange);
                LO_Com.OnWriteComplete += new Comunicazioni.OnPLCWriteComplete(LO_Com_OnWriteComplete);
            }
            public VariableHandle(Comunicazioni Com,string Path, int VarHandle, bool Modifiable, VarEnum VarType)
            {
                LO_Com = Com;
                LS_Path = Path;
                LI_VarHandle = VarHandle;
                LO_ActualValue = null;
                LB_Modifiable = Modifiable;
                LO_VarType = VarType;
                LO_Com.OnValueChange += new Comunicazioni.OnPLCValueChange(LO_Com_OnValueChange);
                LO_Com.OnWriteComplete += new Comunicazioni.OnPLCWriteComplete(LO_Com_OnWriteComplete);
            }
            void LO_Com_OnWriteComplete(object sender,int ClientHandle, int TransactionID)
            {
                if(ClientHandle!=this.LI_VarHandle)
                {
                    return;
                }
                else
                {
                    this.WritePending = false;
                    if (OnWriteComplete != null)
                        OnWriteComplete(this);
                }
            }
            void LO_Com_OnValueChange(object sender,Int32 ClientHandle, object NewValue)
            {
                try
                {
                    if (ClientHandle != this.LI_VarHandle)
                        return;
                    else
                    {
                        LO_ActualValue = NewValue;
                        if (OnValueChange != null)
                            OnValueChange(this);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Value Change: " + ex.Message);
                }

            }
            public bool Write(object res)
            {
                return LO_Com.SyncWrite(this, res, typeof(bool));
            }
            public bool Deregister()
            {
                return LO_Com.RemoveVariable(this);
            }
        }
        public class Comunicazioni
        {
            private static readonly Comunicazioni instance;
            private readonly OPCServer LO_TheServer;
            private OPCGroup LO_MyGroup;
            private readonly string LS_PLCName;
            private readonly string LS_GroupName;
            private readonly int LI_UpdateRate;
            private int LI_HandleCreated;
            public delegate void OnPLCValueChange(object sender, int ClientHandle, object NewValue);
            public delegate void OnPLCWriteComplete(object sender, int ClientHandle, int TransactionID);
            public event OnPLCValueChange OnValueChange;
            public event OnPLCWriteComplete OnWriteComplete;
            public static Comunicazioni Instance
            {
                get
                {
                    if(instance==null)
                    {
                        instance.Connect();
                    }
                    return instance;
                }
            }
            public Comunicazioni(string PLCName,string GroupName, int UpdateRate)
            {
                try
                {
                    LO_TheServer = new OPCServer();
                    LS_GroupName = GroupName;
                    LS_PLCName = PLCName;
                    LI_UpdateRate = UpdateRate;
                }
                catch(Exception ex)
                {
                    throw new Exception("Comunication Error: " + ex.Message);
                }
            }
            public bool IsConnected()
            {
                if (LO_TheServer == null)
                    return false;
                if (LO_MyGroup.IsActive)
                    return true;
                else
                    return false;
            }
            public void Disconnect()
            {
                try
                {
                    LO_MyGroup.OPCItems.DefaultIsActive = false;
                    LO_MyGroup.DataChange -= new DIOPCGroupEvent_DataChangeEventHandler(LO_MyGroup_DataChange);
                    LO_MyGroup.AsyncWriteComplete -= new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(LO_MyGroup_AsyncWriteComplete);
                    LO_TheServer.Disconnect();
                }
                catch(Exception ex)
                {
                    throw new Exception("Comunication Error: " + ex.Message);
                }
            }
            public void Connect()
            {
                try
                {
                    LO_TheServer.Connect(LS_PLCName, "");
                    LO_MyGroup = LO_TheServer.OPCGroups.Add(LS_GroupName);
                    LO_MyGroup.IsSubscribed = true;
                    LO_MyGroup.UpdateRate = LI_UpdateRate;
                    LO_MyGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(LO_MyGroup_DataChange);
                    LO_MyGroup.AsyncWriteComplete += new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(LO_MyGroup_AsyncWriteComplete);
                    LO_MyGroup.OPCItems.DefaultIsActive = true;
                    LI_HandleCreated = 0;
                }
                catch(Exception ex)
                {
                    throw new Exception("Connection Error: " + ex.Message);
                }
            }
            public bool RemoveVariable(VariableHandle Var)
            {
                Array OPLCHndServer = new Int32[2];
                Array ErrArray = new Int32[1];
                OPLCHndServer.SetValue(0, 1);
                OPLCHndServer.SetValue(Var.VariableHandleServer, 1);
                int NoItems = 1;
                if(Var.VariableHandleServer>-1)
                {
                    LO_MyGroup.OPCItems.Remove(NoItems, ref OPLCHndServer, out ErrArray);
                }
                return true;
            }
            public bool RegisterVariable(VariableHandle Var)
            {
                OPCItem Item = LO_MyGroup.OPCItems.AddItem(Var.VariablePath, LI_HandleCreated);
                Var.VariableHandle = LI_HandleCreated;
                Var.VarOPCItem = Item;
                Var.VariableHandleServer = Item.ServerHandle;
                LI_HandleCreated += 1;
                return Item.IsActive;
            }
            public void AsyncRead(VariableHandle OItem)
            {
                throw new NotImplementedException();
            }
            public string SyncRead(VariableHandle OItem)
            {
                Array SyncItemServerHandles = new int[2];
                SyncItemServerHandles.SetValue(0, 0);
                SyncItemServerHandles.SetValue(OItem.VariableHandleServer, 1);
                Array SyncItemValues = new Object[2];
                Array SyncItemServerError = new int[1];
                Object Quality;
                Object Timestamp;
                int ItemCount = 1;
                short Source = 2;
                try
                {
                    LO_MyGroup.SyncRead(Source, ItemCount, ref SyncItemServerHandles, out SyncItemValues, out SyncItemServerError, out Quality, out Timestamp);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                string RetVal = "";
                if(Convert.ToInt32(SyncItemServerError.GetValue(1))==0)
                {
                    if(SyncItemValues.GetValue(1).GetType().IsArray)
                    {
                        var MyArray = new object[1];
                        RetVal = "Array not supported";
                    }
                    else
                    {
                        RetVal = Convert.ToString(SyncItemValues.GetValue(1));
                    }
                }
                else
                {
                    RetVal = "Error in Sync Read";
                }
                OItem.ActualValue = RetVal;
                return RetVal;
            }
            public bool SyncWrite(VariableHandle Variable, object NewValue, Type ValueType)
            {
                Array SyncItemServerHandles = new int[2];
                SyncItemServerHandles.SetValue(0, 0);
                SyncItemServerHandles.SetValue(Variable.VariableHandleServer, 1);
                Array SyncItemValues = new Object[2];
                SyncItemValues.SetValue(0, 0);
                SyncItemValues.SetValue(Convert.ToBoolean(NewValue), 1);
                Array SyncItemServerErrors = new int[1];
                int ItemCount = 1;
                try
                {
                    LO_MyGroup.SyncWrite(ItemCount, ref SyncItemServerHandles, ref SyncItemValues, out SyncItemServerErrors);
                    return true;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            public void ASyncWrite(VariableHandle Variable, object NewValue, Type ValueType)
            {
                Variable.WritePending = true;
                Array WriteItemServerHandles = new int[2];
                WriteItemServerHandles.SetValue(0, 0);
                WriteItemServerHandles.SetValue(Variable.VariableHandleServer, 1);
                Array ASyncItemValues = new Object[2];
                ASyncItemValues.SetValue(0, 0);
                ASyncItemValues.SetValue(Convert.ToBoolean(NewValue), 1);
                Array SyncItemServerError = new int[1];
                int ItemCount = 1;
                try
                {
                    LO_MyGroup.SyncWrite(ItemCount, ref WriteItemServerHandles, ref ASyncItemValues, out SyncItemServerError);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            void LO_MyGroup_AsyncWriteComplete(int TransactionID,int NumItems,ref Array ClientHandles, ref Array Errors)
            {
                try
                {
                    int i;
                    for(i=1;i<ClientHandles.Length;i++)
                    {
                        OnWriteComplete(this, Convert.ToInt32(ClientHandles.GetValue(i)), TransactionID);
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            void LO_MyGroup_DataChange(int TransactionID,int NumItems,ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
            {
                int i;
                try
                {
                    for(i=0;i<=ClientHandles.Length;i++)
                    {
                        OnValueChange(this, Convert.ToInt32(ClientHandles.GetValue(i)), ItemValues.GetValue(i));
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
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
