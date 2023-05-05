using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            InitializeComponent();
            btnControlStatus.DisabledBorderColor = Color.FromArgb(192, 0, 0);
            btnControlStatus.DisabledForeColor = Color.FromArgb(192, 0, 0);
            btnControlStatus.DisabledBackColor = Color.FromArgb(192, 0, 0);
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
    }
}
