using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPCAutomation;
using OPC.Data;
using System.Runtime.InteropServices;


namespace AnTaREs
{
    public class PLC_Comunication
    {
        public class Variabili
        {
            protected string PLC_Variable_Path;
            protected object PLC_Variable_ActualValue;
            protected VarEnum PLC_Variable_VariableType;
            protected int PLC_Variable_Handle;
            protected int PLC_Variable_HandleServer;
            protected bool PLC_Variable_Modifiable;
            public Variabili()
            {
                PLC_Variable_Handle = -1;
                PLC_Variable_Path = "";
                PLC_Variable_ActualValue = null;
                PLC_Variable_VariableType = VarEnum.VT_UNKNOWN;
                PLC_Variable_Modifiable = true;
                PLC_Variable_HandleServer = -1;
            }
            public string VariablePath
            {
                get => PLC_Variable_Path;
                set=> PLC_Variable_Path = value;
            }
            public object ActualValue
            {
                get => PLC_Variable_ActualValue;
                set => PLC_Variable_ActualValue = value;
            }
            public bool Modifiable
            {
                get => PLC_Variable_Modifiable;
                set => PLC_Variable_Modifiable = value;
            }
            public VarEnum VariableType
            {
                get=> PLC_Variable_VariableType;
                set=> PLC_Variable_VariableType = value;
            }
            public int VariableHandle
            {
                get => PLC_Variable_Handle;
                set=> PLC_Variable_Handle = value;
            }
            public int VariableHandleServer
            {
                get => PLC_Variable_HandleServer;
                set=> PLC_Variable_HandleServer = value;
            }
        }
        public class Comunicazioni
        {
            private static Comunicazioni instance;
            private readonly OPCServer ServerName;
            private OPCGroup Group;
            private readonly string PLCName;
            private readonly string GroupName;
            private readonly int UpdateRate;
            private int HandleCreated;
            public delegate void OnPLCValueChange(object sender, int ClientHandle, object NewValue);
            public delegate void OnPLCWriteComplete(object sender, int ClientHandle, int TransactionID);
            public event OnPLCValueChange ValueChange;
            public event OnPLCWriteComplete WriteComplete;
            public static Comunicazioni Instance
            {
                get
                {
                    if(instance==null)
                    {
                        instance = new Comunicazioni("Kepware.KEPServerEX.V5", "Group", 1000);
                        instance.Connect();
                    }
                    return instance;
                }
            }
            public Comunicazioni (string C_PLCName,string C_GroupName,int C_UpdateRate)
            {
                try
                {
                    ServerName = new OPCServer();
                    GroupName = C_GroupName;
                    PLCName = C_PLCName;
                    UpdateRate = C_UpdateRate;
                }
                catch(Exception ex)
                {
                    VPN.Disconnect();
                    throw new Exception("Comunication Error: " + ex.Message);
                }
            }
            public bool IsConnected()
            {
                if (ServerName == null)
                    return false;
                if (Group.IsActive)
                    return true;
                else
                    return false;
            }
            public void Disconnect()
            {
                try
                {
                    Group.OPCItems.DefaultIsActive = false;
                    Group.DataChange -= new DIOPCGroupEvent_DataChangeEventHandler(Group_DataChange);
                    Group.AsyncWriteComplete -= new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(Group_AsyncWriteComplete);
                    ServerName.Disconnect();
                }
                catch (Exception ex)
                {
                    VPN.Disconnect();
                    throw new Exception("Comunication Error: " + ex.Message);
                }
            }
            public void Connect()
            {
                try
                {
                    ServerName.Connect(PLCName, "");
                    Group = ServerName.OPCGroups.Add(GroupName);
                    Group.IsSubscribed = true;
                    Group.UpdateRate = UpdateRate;
                    Group.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(Group_DataChange);
                    Group.AsyncWriteComplete += new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(Group_AsyncWriteComplete);
                    Group.OPCItems.DefaultIsActive = true;
                    HandleCreated = 0;
                }
                catch (Exception ex)
                {
                    VPN.Disconnect();
                    throw new Exception("Connection Error: " + ex.Message);
                }
            }
            public bool RemoveVariable(VariableHandle Variable)
            {
                Array PLCHandleServer = new Int32[2];
                _ = new int[1];
                PLCHandleServer.SetValue(0, 1);
                PLCHandleServer.SetValue(Variable.VariableHandleServer, 1);
                int NoItem = 1;
                if (Variable.VariableHandleServer > -1)
                    Group.OPCItems.Remove(NoItem, ref PLCHandleServer, out _);
                return true;
            }
            public bool RegisterVariable(VariableHandle Variable)
            {
                OPCItem Item = Group.OPCItems.AddItem(Variable.VariablePath, HandleCreated);
                Variable.VariableHandle = HandleCreated;
                Variable.Variable_OPCItem = Item;
                Variable.VariableHandleServer = Item.ServerHandle;
                HandleCreated += 1;
                return Item.IsActive;
            }
            public void AsyncRead(VariableHandle Item)
            {
                throw new NotImplementedException();
            }
            public string SyncRead(VariableHandle Item)
            {
                Array SyncItemServerHandle = new int[2];
                Array SyncItemValues = new Object[2];
                Array SyncItemServerErrors = new int[1];
                int ItemCount = 1;
                short Source = 2;

                SyncItemServerHandle.SetValue(0, 0);
                SyncItemServerHandle.SetValue(Item.VariableHandleServer, 1);
                try
                {
                    Group.SyncRead(Source, ItemCount, ref SyncItemServerHandle, out SyncItemValues, out SyncItemServerErrors, out object Quality, out object Timestamp);
                }
                catch (Exception ex)
                {
                    VPN.Disconnect();
                    throw new Exception("Sync Read Error: " + ex.Message);
                }
                string ReturnValue;
                if (Convert.ToInt32(SyncItemServerErrors.GetValue(1)) == 0)
                {
                    if (SyncItemValues.GetValue(1).GetType().IsArray)
                    {
                        var MyArray = new object[1];
                        ReturnValue = "Array Not Supported";
                    }
                    else
                        ReturnValue = Convert.ToString(SyncItemValues.GetValue(1));
                }
                else
                    ReturnValue = "Error in SyncRead";
                Item.ActualValue = ReturnValue;
                return ReturnValue;
            }
            public bool SyncWrite(VariableHandle Variable,object NewValue,Type ValueType)
            {
                Array SyncIntemServerHandles = new int[2];
                Array SyncItemValues = new Object[2];
                Array SyncItemServerErrors = new int[1];
                int ItemCount = 1;
                SyncIntemServerHandles.SetValue(0, 0);
                SyncIntemServerHandles.SetValue(Variable.VariableHandleServer, 1);
                SyncItemValues.SetValue(0, 0);
                SyncItemValues.SetValue(Convert.ToBoolean(NewValue), 1);
                try
                {
                    Group.SyncWrite(ItemCount, ref SyncIntemServerHandles, ref SyncItemValues, out SyncItemServerErrors);
                    return true;
                }
                catch(Exception ex)
                {
                    throw new Exception("Error on Sync Write: " + ex.Message);
                }
            }
            public void AsyncWrite(VariableHandle Variable, object NewValue, Type ValueType)
            {
                Variable.WritePending = true;
                Array WriteItemServerHandles = new int[2];
                Array ASyncItemValues = new Object[2];
                Array SyncItemServerErrors = new int[1];
                int ItemCount = 1;
                WriteItemServerHandles.SetValue(0, 0);
                WriteItemServerHandles.SetValue(Variable.VariableHandleServer, 1);
                ASyncItemValues.SetValue(0, 0);
                ASyncItemValues.SetValue(Convert.ToBoolean(NewValue), 1);
                try
                {
                    Group.SyncWrite(ItemCount, ref WriteItemServerHandles, ref ASyncItemValues, out SyncItemServerErrors);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Async Write: " + ex.Message);
                }
            }
            void Group_AsyncWriteComplete(int TransactionID,int NumItems,ref Array ClientHandles, ref Array Errors)
            {
                try
                {
                    int i;
                    for(i=1;i<=ClientHandles.Length;i++)
                    {
                        WriteComplete(this, Convert.ToInt32(ClientHandles.GetValue(i)), TransactionID);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Async Write Complete: " + ex.Message);
                }
            }
            void Group_DataChange(int TransactionID,int NumItems,ref Array ClientHandles, ref Array ItemValues,ref Array Quality, ref Array TimeStamps)
            {
                int i;
                try
                {
                    for(i=1;i<=ClientHandles.Length; i++)
                    {
                        ValueChange(this, Convert.ToInt32(ClientHandles.GetValue(i)), ItemValues.GetValue(i));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error on Group Data Change: " + ex.Message);
                }
            }
        }
        public class VariableHandle:Variabili
        {
            private readonly Comunicazioni Com;
            public delegate void OnVariableValueChange(object sender);
            public delegate void OnVariableWriteComplete(object sender);
            public event OnVariableValueChange OnValueChange;
            public event OnVariableWriteComplete OnWriteComplete;
            public VariableHandle(Comunicazioni C_Com, string C_Path,int C_Variable,bool C_Modifiable)
            {
                Com = C_Com;
                PLC_Variable_Path = C_Path;
                PLC_Variable_Handle = C_Variable;
                PLC_Variable_ActualValue = null;
                PLC_Variable_Modifiable = C_Modifiable;
                PLC_Variable_VariableType = VarEnum.VT_UNKNOWN;
                Com.ValueChange += new Comunicazioni.OnPLCValueChange(Com_OnValueChange);
                Com.WriteComplete += new Comunicazioni.OnPLCWriteComplete(Com_OnWriteComplete);
            }
            public VariableHandle(Comunicazioni C_Com,string C_Path, int C_Variable,bool C_Modifiable,VarEnum C_VarType)
            {
                Com = C_Com;
                PLC_Variable_Path = C_Path;
                PLC_Variable_Handle = C_Variable;
                PLC_Variable_ActualValue = null;
                PLC_Variable_Modifiable = C_Modifiable;
                PLC_Variable_VariableType = C_VarType;
                Com.ValueChange += new Comunicazioni.OnPLCValueChange(Com_OnValueChange);
                Com.WriteComplete += new Comunicazioni.OnPLCWriteComplete(Com_OnWriteComplete);
            }
            void Com_OnWriteComplete(object C_sender, int C_ClientHandle,int C_TransactionID)
            {
                if (C_ClientHandle != this.PLC_Variable_Handle)
                    return;
                else
                {
                    this.WritePending = false;
                    OnWriteComplete?.Invoke(this);
                }
            }
            void Com_OnValueChange(object C_sender,Int32 C_ClientHandle, object C_NewValue)
            {
                try
                {
                    if (C_ClientHandle != this.PLC_Variable_Handle)
                        return;
                    else
                    {
                        PLC_Variable_ActualValue = C_NewValue;
                        OnValueChange?.Invoke(this);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Value Change Error: " + ex.Message);
                }
            }
            public bool Write(object C_Res)
            {
                return Com.SyncWrite(this, C_Res, typeof(bool));
            }
            public bool Deregister()
            {
                return Com.RemoveVariable(this);
            }
            public OPCAutomation.OPCItem Variable_OPCItem
            {
                get;
                set;
            }
            public bool WritePending
            {
                get;
                set;
            }
            public int WriteTransactionID
            {
                get;
                set;
            }
        }
    }
}