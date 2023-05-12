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
            InitializeComponent();
            BtnUPS_Initialize();
            LblUPS_Initialize();
            RoofOpenClose_Initialize();
            PLCLabel_Initialize();
            PLCChange_initialize();
        }
        private void PLCCPU_Initialize()
        {
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
        private void PLCChange_initialize()
        {
            this.grpChange.Controls.Add(Main.lblValueRun);
            this.grpChange.Controls.Add(Main.lblValueDirection);
            this.grpChange.Controls.Add(Main.btnEvent);
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
            PLC.PLCChangeValue.BtnEvent_Click(sender, e);
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
            PLC.AlarmUPS.LO_Handle.Write(false);
            PLC.AlarmUPS.SetResetAvailable();
        }


    }
}
