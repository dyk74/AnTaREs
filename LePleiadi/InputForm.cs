using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroSet_UI.Forms;

namespace AnTaREs
{
    public partial class Frm_InputForm : MetroSetForm
    {
        public Frm_InputForm()
        {
            InitializeComponent();
        }
        public MetroSet_UI.Controls.MetroSetTextBox Input
        {
            get => txt_InputForm;
        }
    }
}
