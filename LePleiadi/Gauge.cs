using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LePleiadi.Comunicazione;

namespace LePleiadi
{
    public partial class Gauge:Control
    {
        private VariableHandle LO_Handle;
        private string LS_PathVarPLC;
        private VarEnum LO_TypeVarPLC;
        private Comunicazioni LO_Com;
        public enum NeedleColorEnum
        {
            Gray=0,
            Red=1,
            Green=2,
            Blue=3,
            Yellow=4,
            Violet=5,
            Magenta=6
        };
        private const Byte Zero = 0;
        private const Byte NumOfCaps = 5;
        private const Byte NumOfRanges = 5;
        private Single FontBoundY1;
        private Single FontBoundY2;
        private Bitmap GaugeBitmap;
        private Boolean DrawGaugeBackground = true;
        private Single M_Value;
        private Boolean[] M_ValueIsInRange ={ false,false,false,false,false};
        private Byte M_CapIdx = 1;
        private Color[] M_CapColor = { Color.Black, Color.Black, Color.Black, Color.Black, Color.Black };
        private String[] M_CapText = { "", "", "", "", "" };
        private Point[] M_CapPosition = { new Point(10, 10), new Point(10, 10), new Point(10, 10), new Point(10, 10), new Point(10, 10) };
        private Point M_Center = new Point(100, 100);
        private Single M_MinValue = -100;
        private Single M_MaxValue = 400;
        private Color M_BaseArcColor = Color.Gray;
        private Int32 M_BaseArcRadius = 80;
        private Int32 M_BaseArcStart = 135;
        private Int32 M_BaseArcSweep = 270;
        private Int32 M_BaseArcWidth = 2;
    }
}
