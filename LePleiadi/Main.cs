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
            InitializeComponent();
            btnUPS_Initialize();
            lblUPS_Initialize();
            RoofOpenClose_Initialize();
            
        }
        private void btnUPS_Initialize()
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
            btnUPS.Click += new System.EventHandler(btnUPS_Click);
            btnUPS.Enabled = false;
        }
        private void lblUPS_Initialize()
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
            this.metroTetto.Controls.Add(Main.RoofOpenClose);
            this.metroTetto.Controls.Add(Main.RoofRight);
            this.metroTetto.Controls.Add(Main.RoofLeft);
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
            RoofLeft.Location = new System.Drawing.Point(128, 64);
            RoofOpenClose.Name = "RoofOpenClose";
            RoofOpenClose.Size = new System.Drawing.Size(76, 76);
            RoofLeft.Size = new System.Drawing.Size(38, 38);
            RoofOpenClose.Style = MetroSet_UI.Enums.Style.Light;
            RoofOpenClose.StyleManager = this.Stile;
            RoofOpenClose.ThemeAuthor = "Narwin";
            RoofOpenClose.ThemeName = "MetroLite";
        }
        private void swConnect_SwitchedChanged(object sender)
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
        private void btnUPS_Click(object sender,EventArgs e)
        {
            PLC.AlarmUPS.LO_Handle.Write(false);
            PLC.AlarmUPS.setResetAvailable();
        }


    }
}
