using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LePleiadi.Comunicazione;
using MetroSet_UI.Forms;
using MetroSet_UI.Enums;
using MetroSet_UI.Controls;
using System.Windows.Forms;

namespace LePleiadi
{
    public partial class Main : MetroSetForm
    {
        
        public Main()
        {
            Main.btnUPS = new MetroSet_UI.Controls.MetroSetButton();
            Main.lblUPS = new MetroSet_UI.Controls.MetroSetLabel();
            Main.RoofOpenClose = new MetroSet_UI.Controls.MetroSetEllipse();
            Main.RoofLeft = new MetroSet_UI.Controls.MetroSetEllipse();
            Main.RoofRight = new MetroSet_UI.Controls.MetroSetEllipse();
            Main.LblPLCVariableName = new MetroSet_UI.Controls.MetroSetLabel();
            Main.LblPLCVariableValue = new MetroSet_UI.Controls.MetroSetLabel();
            Main.btnEvent = new MetroSet_UI.Controls.MetroSetButton();
            Main.lblValueDirection = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblValueRun = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblUnit = new MetroSet_UI.Controls.MetroSetLabel();
            Main.lblErrorCode = new MetroSet_UI.Controls.MetroSetLabel();
            Main.btnChange= new MetroSet_UI.Controls.MetroSetButton();
            Main.lblChange = new MetroSet_UI.Controls.MetroSetLabel();
            Main.chkToogle = new MetroSet_UI.Controls.MetroSetCheckBox();
            Main.eclSecurityChain = new MetroSet_UI.Controls.MetroSetEllipse();
            Main.lblSecurityChain = new MetroSet_UI.Controls.MetroSetLabel();
            Main.PLC_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            InitializeComponent();
            BtnUPS_Initialize();
            LblUPS_Initialize();
            RoofOpenClose_Initialize();
            PLCLabel_Initialize();
            PLCFastChange_initialize();
            PLCChange_Initialize();
            PLCCPU_Initialize();
            PLCToogle_Initialize();
            PLCChainElement_Initialize();
        }
        private void PLCChainElement_Initialize()
        {
            this.grpSecurityChain.Controls.Add(Main.lblSecurityChain);
            this.grpSecurityChain.Controls.Add(Main.eclSecurityChain);
            eclSecurityChain.BorderThickness = 0;
            eclSecurityChain.Enabled = false;
            eclSecurityChain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            eclSecurityChain.Image = null;
            eclSecurityChain.ImageSize = new System.Drawing.Size(64, 64);
            eclSecurityChain.IsDerivedStyle = true;
            eclSecurityChain.Location = new System.Drawing.Point(6, 19);
            eclSecurityChain.Name = "eclSecurityChain";
            eclSecurityChain.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            eclSecurityChain.NormalTextColor = System.Drawing.Color.Black;
            eclSecurityChain.PressTextColor = System.Drawing.Color.White;
            eclSecurityChain.Size = new System.Drawing.Size(75, 75);
            eclSecurityChain.Style = MetroSet_UI.Enums.Style.Light;
            eclSecurityChain.StyleManager = null;
            eclSecurityChain.TabIndex = 0;
            eclSecurityChain.ThemeAuthor = "Narwin";
            eclSecurityChain.ThemeName = "MetroLite";
            lblSecurityChain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            lblSecurityChain.IsDerivedStyle = true;
            lblSecurityChain.Location = new System.Drawing.Point(87, 40);
            lblSecurityChain.Name = "lblSecurityChain";
            lblSecurityChain.Size = new System.Drawing.Size(130, 23);
            lblSecurityChain.Style = MetroSet_UI.Enums.Style.Light;
            lblSecurityChain.StyleManager = null;
            lblSecurityChain.TabIndex = 1;
            lblSecurityChain.Text = "-";
            lblSecurityChain.ThemeAuthor = "Narwin";
            lblSecurityChain.ThemeName = "MetroLite";
        }
        private void PLCToogle_Initialize()
        {
            this.grpTooglePLC.Controls.Add(Main.chkToogle);
            chkToogle.BackColor = System.Drawing.Color.Transparent;
            chkToogle.Checked = false;
            chkToogle.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            chkToogle.Cursor = System.Windows.Forms.Cursors.Hand;
            chkToogle.IsDerivedStyle = true;
            chkToogle.Location = new System.Drawing.Point(6, 19);
            chkToogle.Name = "chkToogle";
            chkToogle.SignStyle = MetroSet_UI.Enums.SignStyle.Shape;
            chkToogle.Size = new System.Drawing.Size(154, 16);
            chkToogle.Style = MetroSet_UI.Enums.Style.Light;
            chkToogle.StyleManager = this.Stile;
            chkToogle.TabIndex = 10;
            chkToogle.Text = "-";
            chkToogle.ThemeAuthor = null;
            chkToogle.ThemeName = null;
            chkToogle.CheckedChanged += ChkToogle_CheckedChanged; 
        }
        private void ChkToogle_CheckedChanged(object sender)
        {
            PLC.PLC_Toogle.ChkToogle_CheckedChanged(sender);
        }
        private void PLCChange_Initialize()
        {
            this.grpToogle.Controls.Add(Main.lblChange);
            this.grpToogle.Controls.Add(Main.btnChange);
            btnChange.IsDerivedStyle = true;
            btnChange.Location = new System.Drawing.Point(6, 25);
            btnChange.Name = "btnChange";
            btnChange.Size = new System.Drawing.Size(124, 45);
            btnChange.Style = MetroSet_UI.Enums.Style.Light;
            btnChange.StyleManager = null;
            btnChange.TabIndex = 0;
            btnChange.Text = "Event";
            btnChange.ThemeAuthor = "Narwin";
            btnChange.ThemeName = "MetroLite";
            btnChange.Click += BtnChange_Click;
            lblChange.IsDerivedStyle = true;
            lblChange.Location = new System.Drawing.Point(136, 25);
            lblChange.Name = "lblChange";
            lblChange.Size = new System.Drawing.Size(100, 23);
            lblChange.Style = MetroSet_UI.Enums.Style.Light;
            lblChange.StyleManager = null;
            lblChange.TabIndex = 1;
            lblChange.Text = "-";
            lblChange.ThemeAuthor = "Narwin";
            lblChange.ThemeName = "MetroLite";
        }
        private void PLCCPU_Initialize()
        {
            this.grpCPU.Controls.Add(Main.lblUnit);
            this.grpCPU.Controls.Add(Main.lblErrorCode);
            lblUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            lblUnit.IsDerivedStyle = true;
            lblUnit.Location = new System.Drawing.Point(7, 20);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new System.Drawing.Size(100, 23);
            lblUnit.Style = MetroSet_UI.Enums.Style.Light;
            lblUnit.StyleManager = null;
            lblUnit.TabIndex = 0;
            lblUnit.Text = "0";
            lblUnit.ThemeAuthor = "Narwin";
            lblUnit.ThemeName = "MetroLite";
            lblErrorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            lblErrorCode.IsDerivedStyle = true;
            lblErrorCode.Location = new System.Drawing.Point(7, 47);
            lblErrorCode.Name = "lblErrorCode";
            lblErrorCode.Size = new System.Drawing.Size(100, 23);
            lblErrorCode.Style = MetroSet_UI.Enums.Style.Light;
            lblErrorCode.StyleManager = null;
            lblErrorCode.TabIndex = 1;
            lblErrorCode.Text = "0";
            lblErrorCode.ThemeAuthor = "Narwin";
            lblErrorCode.ThemeName = "MetroLite";
            lblErrorCode.Click += LblErrorCode_Click;

        }
        private void PLCFastChange_initialize()
        {
            this.grpFastChange.Controls.Add(Main.lblValueRun);
            this.grpFastChange.Controls.Add(Main.lblValueDirection);
            this.grpFastChange.Controls.Add(Main.btnEvent);
            btnEvent.Location = new System.Drawing.Point(6, 25);
            btnEvent.Name = "btnEvent";
            btnEvent.PressTextColor = System.Drawing.Color.White;
            btnEvent.Size = new System.Drawing.Size(124, 45);
            btnEvent.Style = MetroSet_UI.Enums.Style.Light;
            btnEvent.StyleManager = null;
            btnEvent.TabIndex = 3;
            btnEvent.Text = "Event";
            btnEvent.ThemeAuthor = "Narwin";
            btnEvent.ThemeName = "MetroLite";
            btnEvent.Click += BtnEvent_Click;
            lblValueDirection.IsDerivedStyle = true;
            lblValueDirection.Location = new System.Drawing.Point(136, 47);
            lblValueDirection.Name = "lblValueDirection";
            lblValueDirection.Size = new System.Drawing.Size(100, 23);
            lblValueDirection.Style = MetroSet_UI.Enums.Style.Light;
            lblValueDirection.StyleManager = null;
            lblValueDirection.TabIndex = 5;
            lblValueDirection.Text = "-";
            lblValueDirection.ThemeAuthor = "Narwin";
            lblValueDirection.ThemeName = "MetroLite";
            lblValueRun.IsDerivedStyle = true;
            lblValueRun.Location = new System.Drawing.Point(136, 25);
            lblValueRun.Name = "lblValueRun";
            lblValueRun.Size = new System.Drawing.Size(100, 23);
            lblValueRun.Style = MetroSet_UI.Enums.Style.Light;
            lblValueRun.StyleManager = null;
            lblValueRun.TabIndex = 6;
            lblValueRun.Text = "-";
            lblValueRun.ThemeAuthor = "Narwin";
            lblValueRun.ThemeName = "MetroLite";

        }
        private void LblErrorCode_Click(object sender,EventArgs e)
        {

        }
        private void BtnEvent_Click(object sender, EventArgs e)
        {
            PLC.PLC_ChangeValue.BtnEvent_Click(sender, e);
        }
        private void BtnChange_Click(object sender, EventArgs e)
        {
            PLC.PLC_Value.BtnChange_Click(sender, e);
        }
        private void PLCLabel_Initialize()
        {
            this.grpPLC.Controls.Add(Main.LblPLCVariableValue);
            this.grpPLC.Controls.Add(Main.LblPLCVariableName);
            LblPLCVariableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            LblPLCVariableName.IsDerivedStyle = true;
            LblPLCVariableName.Location = new System.Drawing.Point(6, 25);
            LblPLCVariableName.Name = "LblPLCVariableName";
            LblPLCVariableName.Size = new System.Drawing.Size(100, 23);
            LblPLCVariableName.Style = MetroSet_UI.Enums.Style.Light;
            LblPLCVariableName.StyleManager = null;
            LblPLCVariableName.TabIndex = 0;
            LblPLCVariableName.Text = "Variable";
            LblPLCVariableName.ThemeAuthor = "Narwin";
            LblPLCVariableName.ThemeName = "MetroLite";
            LblPLCVariableValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            LblPLCVariableValue.IsDerivedStyle = true;
            LblPLCVariableValue.Location = new System.Drawing.Point(70, 25);
            LblPLCVariableValue.Name = "LblPLCVariableValue";
            LblPLCVariableValue.Size = new System.Drawing.Size(100, 23);
            LblPLCVariableValue.Style = MetroSet_UI.Enums.Style.Light;
            LblPLCVariableValue.StyleManager = null;
            LblPLCVariableValue.TabIndex = 1;
            LblPLCVariableValue.Text = "0";
            LblPLCVariableValue.ThemeAuthor = "Narwin";
            LblPLCVariableValue.ThemeName = "MetroLite";
        }
        private void BtnUPS_Initialize()
        {
            btnUPS.IsDerivedStyle = true;
            btnUPS.Location = new System.Drawing.Point(10, 25);
            btnUPS.Name = "btnUPS";
            btnUPS.Size = new System.Drawing.Size(130, 60);
            btnUPS.Style = MetroSet_UI.Enums.Style.Light;
            btnUPS.StyleManager = null;
            btnUPS.TabIndex = 1;
            btnUPS.Text = "UPS";
            btnUPS.ThemeAuthor = "Narwin";
            btnUPS.ThemeName = "MetroLite";
            this.metroAllarmi.Controls.Add(Main.btnUPS);

            btnUPS.HoverTextColor = Color.FromArgb(255, 255, 255);
            btnUPS.NormalTextColor = Color.FromArgb(255, 255, 255);
            btnUPS.PressTextColor = Color.FromArgb(255, 255, 255);
            btnUPS.DisabledBorderColor = Color.FromArgb(192, 192, 192);
            btnUPS.DisabledForeColor = Color.FromArgb(255, 255, 255);
            btnUPS.DisabledBackColor = Color.FromArgb(192, 192, 192);
            btnUPS.Click += new System.EventHandler(BtnUPS_Click);
            btnUPS.Enabled = false;
        }
        private void LblUPS_Initialize()
        {
            this.metroAllarmi.Controls.Add(Main.lblUPS);
            lblUPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            lblUPS.IsDerivedStyle = true;
            lblUPS.Location = new System.Drawing.Point(10, 100);
            lblUPS.Name = "lblUPS";
            lblUPS.Size = new System.Drawing.Size(100, 23);
            lblUPS.Style = MetroSet_UI.Enums.Style.Light;
            lblUPS.StyleManager = null;
            lblUPS.TabIndex = 0;
            lblUPS.Text = "";
            lblUPS.ThemeAuthor = "Narwin";
            lblUPS.ThemeName = "MetroLite";
        }
        private void RoofOpenClose_Initialize()
        {
            this.grpRoof.Controls.Add(Main.RoofOpenClose);
            this.grpRoof.Controls.Add(Main.RoofRight);
            this.grpRoof.Controls.Add(Main.RoofLeft);
            RoofOpenClose.BorderThickness = 0;
            RoofLeft.BorderThickness = 5;
            RoofLeft.DisabledBorderColor = System.Drawing.Color.FromArgb(0, 192, 0);
            RoofRight.BorderThickness = 5;
            RoofRight.DisabledBorderColor = System.Drawing.Color.FromArgb(0, 192, 0);
            RoofOpenClose.Enabled = false;
            RoofRight.Enabled = false;
            RoofLeft.Enabled = false;
            RoofOpenClose.DisabledBackColor = System.Drawing.Color.FromArgb(192,192,192);
            RoofRight.DisabledBackColor = System.Drawing.Color.FromArgb(192, 192, 192);
            RoofLeft.DisabledBackColor = System.Drawing.Color.FromArgb(192, 192, 192);
            RoofOpenClose.ImageSize = new System.Drawing.Size(64, 64);
            RoofLeft.ImageSize = new System.Drawing.Size(32, 32);
            RoofRight.ImageSize = new System.Drawing.Size(32, 32);
            RoofOpenClose.Location = new System.Drawing.Point(64, 12);
            RoofLeft.Location = new System.Drawing.Point(150, 33);
            RoofRight.Location = new System.Drawing.Point(190, 33);
            RoofOpenClose.Name = "RoofOpenClose";
            RoofOpenClose.Size = new System.Drawing.Size(76, 76);
            RoofLeft.Size = new System.Drawing.Size(38, 38);
            RoofRight.Size = new System.Drawing.Size(38, 38);
            RoofOpenClose.Style = MetroSet_UI.Enums.Style.Light;
            RoofOpenClose.StyleManager = this.Stile;
            RoofOpenClose.ThemeAuthor = "Narwin";
            RoofOpenClose.ThemeName = "MetroLite";
        }
        private void SwConnect_SwitchedChanged(object sender)
        {

            MetroSetSwitch swC = sender as MetroSetSwitch;
            if (swC.CheckState==MetroSet_UI.Enums.CheckState.Checked)
            {
                swC.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
                btnControlStatus.DisabledBorderColor = Color.FromArgb(192, 0, 0);
                btnControlStatus.DisabledForeColor = Color.FromArgb(192, 0, 0);
                btnControlStatus.DisabledBackColor = Color.FromArgb(192, 0, 0);
            }
            else if(swC.CheckState==MetroSet_UI.Enums.CheckState.Unchecked)
            {
                swC.CheckState = MetroSet_UI.Enums.CheckState.Checked;
                btnControlStatus.DisabledBorderColor = Color.FromArgb(0, 192, 0);
                btnControlStatus.DisabledForeColor = Color.FromArgb(0, 192, 0);
                btnControlStatus.DisabledBackColor = Color.FromArgb(0, 192, 0);
               // MetroSetMessageBox.Show(this, "connesso");
            }
        }
        private void BtnUPS_Click(object sender,EventArgs e)
        {
            PLC.Alarm_UPS.LO_Handle.Write(false);
            PLC.Alarm_UPS.SetResetAvailable();
        }

    }
}
