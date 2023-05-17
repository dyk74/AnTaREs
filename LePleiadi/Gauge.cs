using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private Color M_ScaleLinesInterColor = Color.Black;
        private Int32 M_ScaleLinesInterInnerRadius = 73;
        private Int32 M_ScaleLinesInterOuterRadius = 80;
        private Int32 M_ScaleLinesInterWidth = 1;
        private Int32 M_ScaleLinesMinorNumOf = 9;
        private Color M_ScaleLinesMinorColor = Color.Gray;
        private Int32 M_ScaleLinesMinorInnerRadius = 75;
        private Int32 M_ScaleLinesMinorOuterRadius = 80;
        private Int32 M_ScaleLinesMinorWidth = 1;
        private Single M_ScaleLinesMajorStepValue = 50.0f;
        private Color M_ScaleLinesMajorColor = Color.Black;
        private Int32 M_ScaleLinesMajorInnerRadius = 70;
        private Int32 M_ScaleLinesMajorOuterRadius = 80;
        private Int32 M_ScaleLinesMajorWidth = 2;
        private Byte M_RangeIdx;
        private Boolean[] M_RangeEnabled = { true, true, false, false, false };
        private Color[] M_RangeColor = { Color.LightGreen, Color.Red, Color.FromKnownColor(KnownColor.Control), Color.FromKnownColor(KnownColor.Control), Color.FromKnownColor(KnownColor.Control) };
        private Single[] M_RangeStartValue = { -100.0f, 300.0f, 0.0f, 0.0f, 0.0f };
        private Single[] M_RangeEndValue = { 300.0f, 400.0f, 0.0f, 0.0f, 0.0f };
        private Int32[] M_RangeInnerRadius = { 70, 70, 70, 70, 70 };
        private Int32[] M_RangeOuterRadius = { 80, 80, 80, 80, 80 };
        private Int32 M_ScaleNumbersRadius = 95;
        private Color M_ScaleNumbersColor = Color.Black;
        private String M_ScaleNumberFormat;
        private Int32 M_ScaleNumbersStartScaleLine;
        private Int32 M_ScaleNumbersStepScaleLines = 1;
        private Int32 M_ScaleNumbersRotation = 0;
        private Int32 M_NeedleType = 0;
        private Int32 M_NeedleRadius = 80;
        private NeedleColorEnum M_NeedleColor1 = NeedleColorEnum.Gray;
        private Color M_NeedleColor2 = Color.DimGray;
        private Int32 M_NeedleWidth = 2;
        public class ValueInRangeChangedEventArgs:EventArgs
        {
            public Int32 ValueInRange;
            public ValueInRangeChangedEventArgs(Int32 ValueInRange)
            {
                this.ValueInRange = ValueInRange;
            }
        }
        public delegate void ValueInRangeChangedDelegate(Object sender, ValueInRangeChangedEventArgs e);
        public event ValueInRangeChangedDelegate ValueInRangeChanged;
        public new Boolean AllowDrop
        {
            get
            {
                return false;
            }
            set
            {
                //
            }
        }
        public new Boolean AutoSize
        {
            get
            {
                return false;
            }
            set
            {
                //
            }
        }
        public new Boolean ForeColor
        {
            get
            {
                return false;
            }
            set
            {
                //
            }
        }
        public new Boolean ImeMode
        {
            get
            {
                return false;
            }
            set
            {
                //
            }
        }
        public override System.Drawing.Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                DrawGaugeBackground = true;
                Refresh();
            }
        }
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                DrawGaugeBackground = true;
                Refresh();
            }
        }
        public override System.Windows.Forms.ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
                DrawGaugeBackground = true;
                Refresh();
            }
        }
        public Gauge()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            LO_Handle = null;
            LS_PathVarPLC = "";
            LO_TypeVarPLC = VarEnum.VT_UNKNOWN;
            LO_Com = Comunicazioni.Instance;
        }
        public void ResetDefault()
        {
            this.Value = 0;
        }
        public bool Online(bool value)
        {
            bool RetVal = false;
            if(!LS_PathVarPLC.Equals("")&&(LO_TypeVarPLC!=VarEnum.VT_UNKNOWN))
            {
                if (LO_Handle == null)
                    LO_Handle = new VariableHandle(LO_Com, LS_PathVarPLC, -1, true);
                if(value)
                {
                    LO_Com.RegisterVariable(LO_Handle);
                    LO_Handle.OnValueChange += new VariableHandle.OnVarValueChange(LO_Handle_OnValueChange);
                }
                else
                {
                    LO_Handle.OnValueChange -= new VariableHandle.OnVarValueChange(LO_Handle_OnValueChange);
                    LO_Com.RemoveVariable(LO_Handle);
                    ResetDefault();
                }
            }
            return RetVal;
        }
        void LO_Handle_OnValueChange(object sender)
        {
            if ((LO_Handle != null) && (LO_Handle.ActualValue != null))
                this.Value = (float)(Convert.ToDouble(LO_Handle.ActualValue) / 1000);
        }
        public string PathVarPLC
        {
            get
            {
                return LS_PathVarPLC;
            }
            set
            {
                LS_PathVarPLC = value;
            }
        }
        public VarEnum Type
        {
            get
            {
                return LO_TypeVarPLC;
            }
            set
            {
                LO_TypeVarPLC = value;
            }
        }
        public Single Value
        {
            get
            {
                return M_Value;
            }
            set
            {
                if(M_Value!=value)
                {
                    M_Value = Math.Min(Math.Max(value, M_MinValue), M_MaxValue);
                    if (this.DesignMode)
                        DrawGaugeBackground = true;
                    for(Int32 counter=0;counter<NumOfRanges-1;counter++)
                    {
                        if ((M_RangeStartValue[counter] <= M_Value) && (M_Value <= M_RangeEndValue[counter]) && (M_RangeEnabled[counter]))
                        {
                            if (!M_ValueIsInRange[counter])
                                if (ValueInRangeChanged != null)
                                    ValueInRangeChanged(this, new ValueInRangeChangedEventArgs(counter));
                        }

                        else
                            M_ValueIsInRange[counter] = false;
                    }
                    Refresh();
                }
            }
        }
        public Byte Cap_Idx
        {
            get
            {
                return M_CapIdx;
            }
            set
            {
                if ((M_CapIdx != value) && (0 <= value) && (value < 5))
                    M_CapIdx = value;
            }
        }
        private Color CapColor
        {
            get
            {
                return M_CapColor[M_CapIdx];
            }
            set
            {
                if(M_CapColor[M_CapIdx]!=value)
                {
                    M_CapColor[M_CapIdx] = value;
                    CapColors = M_CapColor;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Color[] CapColors
        {
            get
            {
                return M_CapColor;
            }
            set
            {
                M_CapColor = value;
            }
        }
        public String CapText
        {
            get
            {
                return M_CapText[M_CapIdx];
            }
            set
            {
                if(M_CapText[M_CapIdx]!=value)
                {
                    M_CapText[M_CapIdx] = value;
                    CapsText = M_CapText;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public String[] CapsText
        {
            get
            {
                return M_CapText;
            }
            set
            {
                for (Int32 counter = 0; counter < 5; counter++)
                    M_CapText[counter] = value[counter];
            }
        }
        public Point CapPosition
        {
            get
            {
                return M_CapPosition[M_CapIdx];
            }
            set
            {
                if(M_CapPosition[M_CapIdx]!=value)
                {
                    M_CapPosition[M_CapIdx] = value;
                    CapsPosition = M_CapPosition;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Point[] CapsPosition
        {
            get
            {
                return M_CapPosition;
            }
            set
            {
                M_CapPosition = value;
            }
        }
        public Point Center
        {
            get
            {
                return M_Center;
            }
            set
            {
                if(M_Center!=value)
                {
                    M_Center = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Single MinValue
        {
            get
            {
                return M_MinValue;
            }
            set
            {
                if((M_MinValue!=value)&&(value<M_MaxValue))
                {
                    M_MinValue = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Single MaxValue
        {
            get
            {
                return M_MaxValue;
            }
            set
            {
                if((M_MaxValue!=value)&&(value>M_MinValue))
                {
                    M_MaxValue = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Color BaseColor
        {
            get
            {
                return M_BaseArcColor;
            }
            set
            {
                if(M_BaseArcColor!=value)
                {
                    M_BaseArcColor = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 BaseArcRadius
        {
            get
            {
                return M_BaseArcRadius;
            }
            set
            {
                if(M_BaseArcRadius!=value)
                {
                    M_BaseArcRadius = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 BaseArcStart
        {
            get
            {
                return M_BaseArcStart;
            }
            set
            {
                if(M_BaseArcStart!=value)
                {
                    M_BaseArcStart = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 BaseArcSweep
        {
            get
            {
                return M_BaseArcSweep;
            }
            set
            {
                if(M_BaseArcSweep!=value)
                {
                    M_BaseArcSweep = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }

            }
        }
        public Int32 BaseArcWidth
        {
            get
            {
                return M_BaseArcWidth;
            }
            set
            {
                if(M_BaseArcWidth!=value)
                {
                    M_BaseArcWidth = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Color ScaleLinesInterColor
        {
            get
            {
                return M_ScaleLinesInterColor;
            }
            set
            {
                if(M_ScaleLinesInterColor!=value)
                {
                    M_ScaleLinesInterColor = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesInterInnerRadius
        {
            get
            {
                return M_ScaleLinesInterInnerRadius;
            }
            set
            {
                if (M_ScaleLinesInterInnerRadius!=value)
                {
                    M_ScaleLinesInterInnerRadius = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesInterOuterRadius
        {
            get
            {
                return M_ScaleLinesInterOuterRadius;
            }
            set
            {
                if(M_ScaleLinesInterOuterRadius!=value)
                {
                    M_ScaleLinesInterOuterRadius = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesInterWidth
        {
            get
            {
                return M_ScaleLinesInterWidth;
            }
            set
            {
                if (M_ScaleLinesInterWidth!=value)
                {
                    M_ScaleLinesInterWidth = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesMinorNumOf
        {
            get
            {
                return M_ScaleLinesMinorNumOf;
            }
            set
            {
                if(M_ScaleLinesMinorNumOf!=value)
                {
                    M_ScaleLinesMinorNumOf = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Color ScaleLinesMinorColor
        {
            get
            {
                return M_ScaleLinesMinorColor;
            }
            set
            {
                if(M_ScaleLinesMinorColor!=value)
                {
                    M_ScaleLinesMinorColor = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesMinorInnerRadius
        {
            get
            {
                return M_ScaleLinesMinorInnerRadius;
            }
            set
            {
                if(M_ScaleLinesMinorInnerRadius!=value)
                {
                    M_ScaleLinesMinorInnerRadius = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesMinorOuterRadius
        {
            get
            {
                return M_ScaleLinesMinorOuterRadius;
            }
            set
            {
                if(M_ScaleLinesMinorOuterRadius!=value)
                {
                    M_ScaleLinesMinorOuterRadius = value;
                    DrawGaugeBackground = true ;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesMinorWidth
        {
            get
            {
                return M_ScaleLinesMinorWidth;
            }
            set
            {
                if(M_ScaleLinesMinorWidth!=value)
                {
                    M_ScaleLinesMinorWidth = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Single ScaleLinesMajorStepValue
        {
            get
            { 
                return M_ScaleLinesMajorStepValue;
            }
            set
            {
                if((M_ScaleLinesMajorStepValue!=value)&&(value>0))
                {
                    M_ScaleLinesMajorStepValue = Math.Max(Math.Min(value, M_MaxValue), M_MinValue);
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Color ScaleLinesMajorColor
        {
            get
            {
                return M_ScaleLinesMajorColor;
            }
            set
            {
                if(M_ScaleLinesMajorColor!=value)
                {
                    M_ScaleLinesMajorColor = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesMajorInnerRadius
        {
            get
            {
                return M_ScaleLinesMajorInnerRadius;
            }
            set
            {
                if(M_ScaleLinesMajorInnerRadius!=value)
                {
                    M_ScaleLinesMajorInnerRadius = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesMajorOuterRadius
        {
            get
            {
                return M_ScaleLinesMajorOuterRadius;
            }
            set
            {
                if(M_ScaleLinesMajorOuterRadius!=value)
                {
                    M_ScaleLinesMajorOuterRadius = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesMajorWidth
        {
            get
            {
                return M_ScaleLinesMajorWidth;
            }
            set
            {
                if(M_ScaleLinesMajorWidth!=value)
                {
                    M_ScaleLinesMajorWidth = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Byte Range_Idx
        {
            get
            {
                return M_RangeIdx;
            }
            set
            {
                if ((M_RangeIdx!=value)&&(0<=value)&&(value<NumOfRanges))
                {
                    M_RangeIdx = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Boolean RangeEnabled
        {
            get
            {
                return M_RangeEnabled[M_RangeIdx];
            }
            set
            {
                if(M_RangeEnabled[M_RangeIdx]!=value)
                {
                    M_RangeEnabled[M_RangeIdx] = value;
                    RangesEnabled = M_RangeEnabled;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Boolean[] RangesEnabled
        {
            get
            {
                return M_RangeEnabled;
            }
            set
            {
                M_RangeEnabled = value;
            }
        }
        public Color RangeColor
        {
            get
            {
                return M_RangeColor[M_RangeIdx];
            }
            set
            {
                if(M_RangeColor[M_RangeIdx]!=value)
                {
                    M_RangeColor[M_RangeIdx] = value;
                    RangesColor = M_RangeColor;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Color[] RangesColor
        {
            get
            {
                return M_RangeColor;
            }
            set
            {
                M_RangeColor = value;
            }
        }
        public Single RangeStartValue
        {
            get
            {
                return M_RangeStartValue[M_RangeIdx];
            }
            set
            {
                if((M_RangeStartValue[M_RangeIdx]!=value)&&(value<M_RangeStartValue[M_RangeIdx]))
                {
                    M_RangeStartValue[M_RangeIdx] = value;
                    RangesStartValue = M_RangeStartValue;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Single[] RangesStartValue
        {
            get
            {
                return M_RangeStartValue;
            }
            set
            {
                M_RangeStartValue = value;
            }
        }
        public Single RangeEndValue
        {
            get
            {
                return M_RangeEndValue[M_RangeIdx];
            }
            set
            {
                if((M_RangeEndValue[M_RangeIdx]!=value)&&(M_RangeEndValue[M_RangeIdx]<value))
                {
                    M_RangeEndValue[M_RangeIdx] = value;
                    RangesEndValue = M_RangeEndValue;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Single[] RangesEndValue
        {
            get
            {
                return M_RangeEndValue;
            }
            set
            {
                M_RangeEndValue = value;
            }
        }
        public Int32 RangeInnerRadius
        {
            get
            {
                return M_RangeInnerRadius[M_RangeIdx];
            }
            set
            {
                if(M_RangeInnerRadius[M_RangeIdx]!=value)
                {
                    M_RangeInnerRadius[M_RangeIdx] = value;
                    RangesInnerRadius = M_RangeInnerRadius;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32[] RangesInnerRadius
        {
            get
            {
                return M_RangeInnerRadius;
            }
            set
            {
                M_RangeInnerRadius = value;
            }
        }
        public Int32 RangeOuterRadius
        {
            get
            {
                return M_RangeOuterRadius[M_RangeIdx];
            }
            set
            {
                if(M_RangeOuterRadius[M_RangeIdx]!=value)
                {
                    M_RangeOuterRadius[M_RangeIdx] = value;
                    RangesOuterRadius = M_RangeOuterRadius;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32[] RangesOuterRadius
        {
            get
            {
                return M_RangeOuterRadius;
            }
            set
            {
                M_RangeOuterRadius = value;
            }
        }
        public Int32 ScaleNumbersRadius
        {
            get
            {
                return M_ScaleNumbersRadius;
            }
            set
            {
                if(M_ScaleNumbersRadius!=value)
                {
                    M_ScaleNumbersRadius = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Color ScaleNumbersColor
        {
            get
            {
                return M_ScaleNumbersColor;
            }
            set
            {
                if(M_ScaleNumbersColor!=value)
                {
                    M_ScaleNumbersColor = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public String ScaleNumbersFormat
        {
            get
            {
                return M_ScaleNumberFormat;
            }
            set
            {
                if(M_ScaleNumberFormat!=value)
                {
                    M_ScaleNumberFormat = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleNumbersStartScaleLine
        {
            get
            {
                return M_ScaleNumbersStartScaleLine;
            }
            set
            {
                if(M_ScaleNumbersStartScaleLine!=value)
                {
                    M_ScaleNumbersStartScaleLine = Math.Max(value, 1);
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleNumbersStepScaleLines
        {
            get
            {
                return M_ScaleNumbersStepScaleLines;
            }
            set
            {
                if(M_ScaleNumbersStepScaleLines!=value)
                {
                    M_ScaleNumbersStepScaleLines = Math.Max(value, 1);
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleNumbersRotation
        {
            get
            {
                return M_ScaleNumbersRotation;
            }
            set
            {
                if(M_ScaleNumbersRotation!=value)
                {
                    M_ScaleNumbersRotation = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 NeedleType
        {
            get
            {
                return M_NeedleType;
            }
            set
            {
                if(M_NeedleType!=value)
                {
                    M_NeedleType = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 NeedleRadius
        {
            get
            {
                return M_NeedleRadius;
            }
            set
            {
                if(M_NeedleRadius!=value)
                {
                    M_NeedleRadius = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public NeedleColorEnum NeedleColor1
        {
            get
            {
                return M_NeedleColor1;
            }
            set
            {
                if(M_NeedleColor1!=value)
                {
                    M_NeedleColor1 = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Color NeedleColor2
        {
            get
            {
                return M_NeedleColor2;
            }
            set
            {
                if(M_NeedleColor2!=value)
                {
                    M_NeedleColor2 = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        public Int32 NeedleWidth
        {
            get
            {
                return M_NeedleWidth;
            }
            set
            {
                if(M_NeedleWidth!=value)
                {
                    M_NeedleWidth = value;
                    DrawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        private void FindFontBounds()
        {
            Int32 C1;
            Int32 C2;
            Boolean Boundfound;
            Bitmap B;
            Graphics G;
            SolidBrush BackBrush = new SolidBrush(Color.White);
            SolidBrush ForeBrush = new SolidBrush(Color.Black);
            SizeF BoundingBox;
            B = new Bitmap(5, 5);
            G = Graphics.FromImage(B);
            BoundingBox = G.MeasureString("0123456789", Font, -1, StringFormat.GenericTypographic);
            B = new Bitmap((Int32)(BoundingBox.Width), (Int32)(BoundingBox.Height));
            G = Graphics.FromImage(B);
            G.FillRectangle(BackBrush, 0.0F, 0.0F, BoundingBox.Width, BoundingBox.Height);
            G.DrawString("0123456789", Font, ForeBrush, 0.0F, 0.0F, StringFormat.GenericTypographic);
            FontBoundY1 = 0;
            FontBoundY2 = 0;
            C1 = 0;
            Boundfound = false;
            while((C1<B.Height)&&(!Boundfound))
            {
                C2 = 0;
                while((C2<B.Width)&&(!Boundfound))
                {
                    if(B.GetPixel(C2,C1)!=BackBrush.Color)
                    {
                        FontBoundY1 = C1;
                        Boundfound = true;
                    }
                    C2++;
                }
                C1++;
            }
            C1 = B.Height - 1;
            Boundfound = false;
            while((0<C1)&&(!Boundfound))
            {
                C2 = 0;
                while((C2<B.Width)&&(!Boundfound))
                {
                    if(B.GetPixel(C2,C1)!=BackBrush.Color)
                    {
                        FontBoundY2 = C1;
                        Boundfound = true;
                    }
                    C2++;
                }
                C1--;
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            if ((Width < 10) || (Height < 10))
                return;
            if(DrawGaugeBackground)
            {
                DrawGaugeBackground = false;
                FindFontBounds();
                GaugeBitmap = new Bitmap(Width, Height, pe.Graphics);
                Graphics ggr = Graphics.FromImage(GaugeBitmap);
                ggr.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
                if(BackgroundImage!=null)
                {
                    switch(BackgroundImageLayout)
                    {
                        case ImageLayout.Center:
                            ggr.DrawImageUnscaled(BackgroundImage, Width / 2 - BackgroundImage.Width / 2, Height / 2 - BackgroundImage.Height / 2);
                            break;
                        case ImageLayout.None:
                            ggr.DrawImageUnscaled(BackgroundImage, 0, 0);
                            break;
                        case ImageLayout.Stretch:
                            ggr.DrawImage(BackgroundImage, 0, 0, Width, Height);
                            break;
                        case ImageLayout.Tile:
                            Int32 PixelOffsetX = 0;
                            Int32 PixelOffsetY = 0;
                            while(PixelOffsetX<Width)
                            {
                                PixelOffsetY = 0;
                                while(PixelOffsetY<Height)
                                {
                                    ggr.DrawImageUnscaled(BackgroundImage, PixelOffsetX, PixelOffsetY);
                                    PixelOffsetY += BackgroundImage.Height;
                                }
                                PixelOffsetX += BackgroundImage.Width;
                            }
                            break;
                        case ImageLayout.Zoom:
                            if ((Single)(BackgroundImage.Width / Width) < (Single)(BackgroundImage.Height / Height))
                                ggr.DrawImage(BackgroundImage, 0, 0, Height, Height);
                            else
                                ggr.DrawImage(BackgroundImage, 0, 0, Width, Width);
                            break;
                    }
                }
                ggr.SmoothingMode = SmoothingMode.HighQuality;
                ggr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                GraphicsPath gp = new GraphicsPath();
                Single RangeStartAngle;
                Single RangeSweepAngle;
                for(Int32 counter=0; counter<NumOfRanges;counter++)
                {
                    if((M_RangeEndValue[counter]>M_RangeStartValue[counter])&& M_RangeEnabled[counter])
                    {
                        RangeStartAngle = M_BaseArcStart + (M_RangeStartValue[counter] - M_MinValue) * M_BaseArcSweep / (M_MaxValue - M_MinValue);
                        RangeSweepAngle = (M_RangeEndValue[counter] - M_RangeStartValue[counter]) * M_BaseArcSweep / (M_MaxValue - M_MinValue);
                        gp.Reset();
                        gp.AddPie(new Rectangle(M_Center.X - M_RangeOuterRadius[counter], M_Center.Y - M_RangeOuterRadius[counter], 2 * M_RangeOuterRadius[counter], 2 * M_RangeOuterRadius[counter]), RangeStartAngle, RangeSweepAngle);
                        gp.Reverse();
                        gp.AddPie(new Rectangle(M_Center.X - M_RangeInnerRadius[counter], M_Center.Y - M_RangeInnerRadius[counter], 2 * M_RangeInnerRadius[counter], 2 * M_RangeInnerRadius[counter]), RangeStartAngle, RangeSweepAngle);
                        gp.Reverse();
                        ggr.SetClip(gp);
                        ggr.FillPie(new SolidBrush(M_RangeColor[counter]), new Rectangle(M_Center.X - M_RangeOuterRadius[counter], M_Center.Y - M_RangeOuterRadius[counter], 2 * M_RangeOuterRadius[counter], 2 * M_RangeOuterRadius[counter]), RangeStartAngle, RangeSweepAngle);
                    }
                }
                ggr.SetClip(ClientRectangle);
                if (M_BaseArcRadius > 0)
                    ggr.DrawArc(new Pen(M_BaseArcColor, M_BaseArcWidth), new Rectangle(M_Center.X - M_BaseArcRadius, M_Center.Y - M_BaseArcRadius, 2 * M_BaseArcRadius, 2 * M_BaseArcRadius), M_BaseArcStart, M_BaseArcSweep);
                String ValueText = "";
                SizeF BoundingBox;
                Single CountValue = 0;
                Int32 Counter1 = 0;
                while(CountValue<=(M_MaxValue-M_MinValue))
                {
                    ValueText = (M_MinValue + CountValue).ToString(M_ScaleNumberFormat);
                    ggr.ResetTransform();
                    BoundingBox = ggr.MeasureString(ValueText, Font, -1, StringFormat.GenericTypographic);
                    gp.Reset();
                    gp.AddEllipse(new Rectangle(M_Center.X - M_ScaleLinesMajorOuterRadius, M_Center.Y - M_ScaleLinesMajorOuterRadius, 2 * M_ScaleLinesMajorOuterRadius, 2 * M_ScaleLinesMajorOuterRadius));
                    gp.Reverse();
                    gp.AddEllipse(new Rectangle(M_Center.X - M_ScaleLinesMajorInnerRadius, M_Center.Y - M_ScaleLinesMajorInnerRadius, 2 * M_ScaleLinesMajorInnerRadius, 2 * M_ScaleLinesMajorInnerRadius));
                    gp.Reverse();
                    ggr.SetClip(gp);
                    ggr.DrawLine(new Pen(M_ScaleLinesMajorColor, M_ScaleLinesMajorWidth),(Single)(Center.X),(Single)(Center.Y),(Single)(Center.X + 2 * M_ScaleLinesMajorOuterRadius * Math.Cos((M_BaseArcStart + CountValue * M_BaseArcSweep / (M_MaxValue - M_MinValue)) * Math.PI / 180.0)),(Single)(Center.Y + 2 * M_ScaleLinesMajorOuterRadius * Math.Sin((M_BaseArcStart + CountValue * M_BaseArcSweep / (M_MaxValue - M_MinValue)) * Math.PI / 180.0)));
                    gp.Reset();
                    gp.AddEllipse(new Rectangle(M_Center.X - M_ScaleLinesMinorOuterRadius, M_Center.Y - M_ScaleLinesMinorOuterRadius, 2 * M_ScaleLinesMinorOuterRadius, 2 * M_ScaleLinesMinorOuterRadius));
                    gp.Reverse();
                    gp.AddEllipse(new Rectangle(M_Center.X - M_ScaleLinesMinorInnerRadius, M_Center.Y - M_ScaleLinesMinorInnerRadius, 2 * M_ScaleLinesMinorInnerRadius, 2 * M_ScaleLinesMinorInnerRadius));
                    gp.Reverse();
                    ggr.SetClip(gp);
                    if(CountValue<(M_MaxValue-M_MinValue))
                    {
                        for(Int32 Counter2=1;Counter2<=M_ScaleLinesMinorNumOf;Counter2++)
                        {
                            if(((M_ScaleLinesMinorNumOf%2)==1)&&((Int32)(M_ScaleLinesMinorNumOf/2)+1==Counter2))
                            {
                                gp.Reset();
                                gp.AddEllipse(new Rectangle(M_Center.X - M_ScaleLinesInterOuterRadius, M_Center.Y - M_ScaleLinesInterOuterRadius, 2 * M_ScaleLinesInterOuterRadius, 2 * M_ScaleLinesInterOuterRadius));
                                gp.Reverse();
                                gp.AddEllipse(new Rectangle(M_Center.X - M_ScaleLinesInterInnerRadius, M_Center.Y - M_ScaleLinesInterInnerRadius, 2 * M_ScaleLinesInterInnerRadius, 2 * M_ScaleLinesInterInnerRadius));
                                gp.Reverse();
                                ggr.SetClip(gp);
                                ggr.DrawLine(new Pen(M_ScaleLinesInterColor, M_ScaleLinesInterWidth),(Single)(Center.X),(Single)(Center.Y),(Single)(Center.X + 2 * M_ScaleLinesInterOuterRadius * Math.Cos((M_BaseArcStart + CountValue * M_BaseArcSweep / (M_MaxValue - M_MinValue) + Counter2 * M_BaseArcSweep / (((Single)((M_MaxValue - M_MinValue) / M_ScaleLinesMajorStepValue)) * (M_ScaleLinesMinorNumOf + 1))) * Math.PI / 180.0)),(Single)(Center.Y + 2 * M_ScaleLinesInterOuterRadius * Math.Sin((M_BaseArcStart + CountValue * M_BaseArcSweep / (M_MaxValue - M_MinValue) + Counter2 * M_BaseArcSweep / (((Single)((M_MaxValue - M_MinValue) / M_ScaleLinesMajorStepValue)) * (M_ScaleLinesMinorNumOf + 1))) * Math.PI / 180.0)));
                                gp.Reset();
                                gp.AddEllipse(new Rectangle(M_Center.X - M_ScaleLinesMinorOuterRadius, M_Center.Y - M_ScaleLinesMinorOuterRadius, 2 * M_ScaleLinesMinorOuterRadius, 2 * M_ScaleLinesMinorOuterRadius));
                                gp.Reverse();
                                gp.AddEllipse(new Rectangle(M_Center.X - M_ScaleLinesMinorInnerRadius, M_Center.Y - M_ScaleLinesMinorInnerRadius, 2 *M_ScaleLinesMinorInnerRadius, 2 * M_ScaleLinesMinorInnerRadius));
                                gp.Reverse();
                                ggr.SetClip(gp);
                            }
                            else
                            {
                                ggr.DrawLine(new Pen(M_ScaleLinesMinorColor, M_ScaleLinesMinorWidth),
                                (Single)(Center.X),
                                (Single)(Center.Y),
                                (Single)(Center.X + 2 * M_ScaleLinesMinorOuterRadius * Math.Cos((M_BaseArcStart + CountValue * M_BaseArcSweep / (M_MaxValue - M_MinValue) + Counter2 * M_BaseArcSweep / (((Single)((M_MaxValue - M_MinValue) / M_ScaleLinesMajorStepValue)) * (M_ScaleLinesMinorNumOf + 1))) * Math.PI / 180.0)),
                                (Single)(Center.Y + 2 * M_ScaleLinesMinorOuterRadius * Math.Sin((M_BaseArcStart + CountValue * M_BaseArcSweep / (M_MaxValue - M_MinValue) + Counter2 * M_BaseArcSweep / (((Single)((M_MaxValue - M_MinValue) / M_ScaleLinesMajorStepValue)) * (M_ScaleLinesMinorNumOf + 1))) * Math.PI / 180.0)));
                            }
                        }
                    }
                    ggr.SetClip(ClientRectangle);
                    if(M_ScaleNumbersRotation!=0)
                    {
                        ggr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        ggr.RotateTransform(90.0F + M_BaseArcStart + CountValue * M_BaseArcSweep / (M_MaxValue - M_MinValue));
                    }
                    ggr.TranslateTransform((Single)(Center.X + M_ScaleNumbersRadius * Math.Cos((M_BaseArcStart + CountValue * M_BaseArcSweep / (M_MaxValue - M_MinValue)) * Math.PI / 180.0f)),(Single)(Center.Y + M_ScaleNumbersRadius * Math.Sin((M_BaseArcStart + CountValue * M_BaseArcSweep / (M_MaxValue - M_MinValue)) * Math.PI / 180.0f)),System.Drawing.Drawing2D.MatrixOrder.Append);
                    CountValue += M_ScaleLinesMajorStepValue;
                    Counter1++;
                }
                ggr.ResetTransform();
                ggr.SetClip(ClientRectangle);
                if (M_ScaleNumbersRotation != 0)
                    ggr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
                for(Int32 Counter=0;Counter<NumOfCaps;Counter++)
                {
                    if(M_CapText[Counter]!="")
                        ggr.DrawString(M_CapText[Counter], Font, new SolidBrush(M_CapColor[Counter]), M_CapPosition[Counter].X, M_CapPosition[Counter].Y, StringFormat.GenericTypographic);
                }
                pe.Graphics.DrawImageUnscaled(GaugeBitmap, 0, 0);
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                pe.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Single BrushAngle = (Int32)(M_BaseArcStart + (M_Value - M_MinValue) * M_BaseArcSweep / (M_MaxValue - M_MinValue)) % 360;
                Double NeedleAngle = BrushAngle * Math.PI / 180;
                switch(M_NeedleType)
                {
                    case 0:
                        PointF[] points = new PointF[3];
                        Brush brush1 = Brushes.White;
                        Brush brush2 = Brushes.White;
                        Brush brush3 = Brushes.White;
                        Brush brush4 = Brushes.White;
                        Brush brushBucket = Brushes.White;
                        Int32 subcol = (Int32)(((BrushAngle + 225) % 180) * 100 / 180);
                        Int32 subcol2 = (Int32)(((BrushAngle + 135) % 180) * 100 / 180);
                        pe.Graphics.FillEllipse(new SolidBrush(M_NeedleColor2), Center.X - M_NeedleWidth * 3, Center.Y - M_NeedleWidth * 3, M_NeedleWidth * 6, M_NeedleWidth * 6);
                        switch (M_NeedleColor1)
                        {
                            case NeedleColorEnum.Gray:
                                brush1 = new SolidBrush(Color.FromArgb(80 + subcol, 80 + subcol, 80 + subcol));
                                brush2 = new SolidBrush(Color.FromArgb(180 - subcol, 180 - subcol, 180 - subcol));
                                brush3 = new SolidBrush(Color.FromArgb(80 + subcol2, 80 + subcol2, 80 + subcol2));
                                brush4 = new SolidBrush(Color.FromArgb(180 - subcol2, 180 - subcol2, 180 - subcol2));
                                pe.Graphics.DrawEllipse(Pens.Gray, Center.X - M_NeedleWidth * 3, Center.Y - M_NeedleWidth * 3, M_NeedleWidth * 6, M_NeedleWidth * 6);
                                break;
                            case NeedleColorEnum.Red:
                                brush1 = new SolidBrush(Color.FromArgb(145 + subcol, subcol, subcol));
                                brush2 = new SolidBrush(Color.FromArgb(245 - subcol, 100 - subcol, 100 - subcol));
                                brush3 = new SolidBrush(Color.FromArgb(145 + subcol2, subcol2, subcol2));
                                brush4 = new SolidBrush(Color.FromArgb(245 - subcol2, 100 - subcol2, 100 - subcol2));
                                pe.Graphics.DrawEllipse(Pens.Red, Center.X - M_NeedleWidth * 3, Center.Y - M_NeedleWidth * 3, M_NeedleWidth * 6, M_NeedleWidth * 6);
                                break;
                            case NeedleColorEnum.Green:
                                brush1 = new SolidBrush(Color.FromArgb(subcol, 145 + subcol, subcol));
                                brush2 = new SolidBrush(Color.FromArgb(100 - subcol, 245 - subcol, 100 - subcol));
                                brush3 = new SolidBrush(Color.FromArgb(subcol2, 145 + subcol2, subcol2));
                                brush4 = new SolidBrush(Color.FromArgb(100 - subcol2, 245 - subcol2, 100 - subcol2));
                                pe.Graphics.DrawEllipse(Pens.Green, Center.X - M_NeedleWidth * 3, Center.Y - M_NeedleWidth * 3, M_NeedleWidth * 6, M_NeedleWidth * 6);
                                break;
                            case NeedleColorEnum.Blue:
                                brush1 = new SolidBrush(Color.FromArgb(subcol, subcol, 145 + subcol));
                                brush2 = new SolidBrush(Color.FromArgb(100 - subcol, 100 - subcol, 245 - subcol));
                                brush3 = new SolidBrush(Color.FromArgb(subcol2, subcol2, 145 + subcol2));
                                brush4 = new SolidBrush(Color.FromArgb(100 - subcol2, 100 - subcol2, 245 - subcol2));
                                pe.Graphics.DrawEllipse(Pens.Blue, Center.X - M_NeedleWidth * 3, Center.Y - M_NeedleWidth * 3, M_NeedleWidth * 6, M_NeedleWidth * 6);
                                break;
                            case NeedleColorEnum.Magenta:
                                brush1 = new SolidBrush(Color.FromArgb(subcol, 145 + subcol, 145 + subcol));
                                brush2 = new SolidBrush(Color.FromArgb(100 - subcol, 245 - subcol, 245 - subcol));
                                brush3 = new SolidBrush(Color.FromArgb(subcol2, 145 + subcol2, 145 + subcol2));
                                brush4 = new SolidBrush(Color.FromArgb(100 - subcol2, 245 - subcol2, 245 - subcol2));
                                pe.Graphics.DrawEllipse(Pens.Magenta, Center.X - M_NeedleWidth * 3, Center.Y - M_NeedleWidth * 3, M_NeedleWidth * 6, M_NeedleWidth * 6);
                                break;
                            case NeedleColorEnum.Violet:
                                brush1 = new SolidBrush(Color.FromArgb(145 + subcol, subcol, 145 + subcol));
                                brush2 = new SolidBrush(Color.FromArgb(245 - subcol, 100 - subcol, 245 - subcol));
                                brush3 = new SolidBrush(Color.FromArgb(145 + subcol2, subcol2, 145 + subcol2));
                                brush4 = new SolidBrush(Color.FromArgb(245 - subcol2, 100 - subcol2, 245 - subcol2));
                                pe.Graphics.DrawEllipse(Pens.Violet, Center.X - M_NeedleWidth * 3, Center.Y - M_NeedleWidth * 3, M_NeedleWidth * 6, M_NeedleWidth * 6);
                                break;
                            case NeedleColorEnum.Yellow:
                                brush1 = new SolidBrush(Color.FromArgb(145 + subcol, 145 + subcol, subcol));
                                brush2 = new SolidBrush(Color.FromArgb(245 - subcol, 245 - subcol, 100 - subcol));
                                brush3 = new SolidBrush(Color.FromArgb(145 + subcol2, 145 + subcol2, subcol2));
                                brush4 = new SolidBrush(Color.FromArgb(245 - subcol2, 245 - subcol2, 100 - subcol2));
                                pe.Graphics.DrawEllipse(Pens.Violet, Center.X - M_NeedleWidth * 3, Center.Y - M_NeedleWidth * 3, M_NeedleWidth * 6, M_NeedleWidth * 6);
                                break;
                        }
                        if (Math.Floor((Single)(((BrushAngle + 225) % 360) / 180.0)) == 0)
                        {
                            brushBucket = brush1;
                            brush1 = brush2;
                            brush2 = brushBucket;
                        }
                        if (Math.Floor((Single)(((BrushAngle + 135) % 360) / 180.0)) == 0)
                            brush4 = brush3;
                        points[0].X = (Single)(Center.X + M_NeedleRadius * Math.Cos(NeedleAngle));
                        points[0].Y = (Single)(Center.Y + M_NeedleRadius * Math.Sin(NeedleAngle));
                        points[1].X = (Single)(Center.X - M_NeedleRadius / 20 * Math.Cos(NeedleAngle));
                        points[1].Y = (Single)(Center.Y - M_NeedleRadius / 20 * Math.Sin(NeedleAngle));
                        points[2].X = (Single)(Center.X - M_NeedleRadius / 5 * Math.Cos(NeedleAngle) + M_NeedleWidth * 2 * Math.Cos(NeedleAngle + Math.PI / 2));
                        points[2].Y = (Single)(Center.Y - M_NeedleRadius / 5 * Math.Sin(NeedleAngle) + M_NeedleWidth * 2 * Math.Sin(NeedleAngle + Math.PI / 2));
                        pe.Graphics.FillPolygon(brush1, points);
                        points[2].X = (Single)(Center.X - M_NeedleRadius / 5 * Math.Cos(NeedleAngle) + M_NeedleWidth * 2 * Math.Cos(NeedleAngle - Math.PI / 2));
                        points[2].Y = (Single)(Center.Y - M_NeedleRadius / 5 * Math.Sin(NeedleAngle) + M_NeedleWidth * 2 * Math.Sin(NeedleAngle - Math.PI / 2));
                        pe.Graphics.FillPolygon(brush2, points);
                        points[0].X = (Single)(Center.X - (M_NeedleRadius / 20 - 1) * Math.Cos(NeedleAngle));
                        points[0].Y = (Single)(Center.Y - (M_NeedleRadius / 20 - 1) * Math.Sin(NeedleAngle));
                        points[1].X = (Single)(Center.X - M_NeedleRadius / 5 * Math.Cos(NeedleAngle) + M_NeedleWidth * 2 * Math.Cos(NeedleAngle + Math.PI / 2));
                        points[1].Y = (Single)(Center.Y - M_NeedleRadius / 5 * Math.Sin(NeedleAngle) + M_NeedleWidth * 2 * Math.Sin(NeedleAngle + Math.PI / 2));
                        points[2].X = (Single)(Center.X - M_NeedleRadius / 5 * Math.Cos(NeedleAngle) + M_NeedleWidth * 2 * Math.Cos(NeedleAngle - Math.PI / 2));
                        points[2].Y = (Single)(Center.Y - M_NeedleRadius / 5 * Math.Sin(NeedleAngle) + M_NeedleWidth * 2 * Math.Sin(NeedleAngle - Math.PI / 2));
                        pe.Graphics.FillPolygon(brush4, points);
                        points[0].X = (Single)(Center.X - M_NeedleRadius / 20 * Math.Cos(NeedleAngle));
                        points[0].Y = (Single)(Center.Y - M_NeedleRadius / 20 * Math.Sin(NeedleAngle));
                        points[1].X = (Single)(Center.X + M_NeedleRadius * Math.Cos(NeedleAngle));
                        points[1].Y = (Single)(Center.Y + M_NeedleRadius * Math.Sin(NeedleAngle));
                        pe.Graphics.DrawLine(new Pen(M_NeedleColor2), Center.X, Center.Y, points[0].X, points[0].Y);
                        pe.Graphics.DrawLine(new Pen(M_NeedleColor2), Center.X, Center.Y, points[1].X, points[1].Y);
                        break;
                    case 1:
                        Point startPoint = new Point((Int32)(Center.X - M_NeedleRadius / 8 * Math.Cos(NeedleAngle)),(Int32)(Center.Y - M_NeedleRadius / 8 * Math.Sin(NeedleAngle)));
                        Point endPoint = new Point((Int32)(Center.X + M_NeedleRadius * Math.Cos(NeedleAngle)),(Int32)(Center.Y + M_NeedleRadius * Math.Sin(NeedleAngle)));
                        pe.Graphics.FillEllipse(new SolidBrush(M_NeedleColor2), Center.X - M_NeedleWidth * 3, Center.Y - M_NeedleWidth * 3, M_NeedleWidth * 6, M_NeedleWidth * 6);
                        switch (M_NeedleColor1)
                        {
                            case NeedleColorEnum.Gray:
                                pe.Graphics.DrawLine(new Pen(Color.DarkGray, M_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                                pe.Graphics.DrawLine(new Pen(Color.DarkGray, M_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                                break;
                            case NeedleColorEnum.Red:
                                pe.Graphics.DrawLine(new Pen(Color.Red, M_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                                pe.Graphics.DrawLine(new Pen(Color.Red, M_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                                break;
                            case NeedleColorEnum.Green:
                                pe.Graphics.DrawLine(new Pen(Color.Green, M_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                                pe.Graphics.DrawLine(new Pen(Color.Green, M_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                                break;
                            case NeedleColorEnum.Blue:
                                pe.Graphics.DrawLine(new Pen(Color.Blue, M_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                                pe.Graphics.DrawLine(new Pen(Color.Blue, M_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                                break;
                            case NeedleColorEnum.Magenta:
                                pe.Graphics.DrawLine(new Pen(Color.Magenta, M_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                                pe.Graphics.DrawLine(new Pen(Color.Magenta, M_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                                break;
                            case NeedleColorEnum.Violet:
                                pe.Graphics.DrawLine(new Pen(Color.Violet, M_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                                pe.Graphics.DrawLine(new Pen(Color.Violet, M_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                                break;
                            case NeedleColorEnum.Yellow:
                                pe.Graphics.DrawLine(new Pen(Color.Yellow, M_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                                pe.Graphics.DrawLine(new Pen(Color.Yellow, M_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                                break;
                        }
                        break;
                }
            }
        }
        protected override void OnResize(EventArgs e)
        {
            DrawGaugeBackground = true;
            Refresh();
        }
    }
    partial class Gauge
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components!=null))
                components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
    }
}
