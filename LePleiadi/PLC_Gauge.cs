using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AnTaREs.PLC_Comunication;

namespace AnTaREs
{
    public partial class PLC_Gauge : MetroSet_UI.Forms.MetroSetForm
    {
        private VariableHandle PLC_Handle;
        private string PLC_VariablePath;
        private VarEnum PLC_VariableType;
        private Comunicazioni Com;
        private const Byte ZERO = 0;
        private const Byte Number_of_Caps = 5;
        private const Byte Number_of_ranges = 5;
        private Single Font_Bound_Y1;
        private Single Font_Bound_Y2;
        private Bitmap Gauge_Bitmap;
        private Boolean Draw_Gauge_Background = true;
        private Single PLC_Value;
        private Boolean[] ValueIsInRange = { false, false, false, false, false };
        private Byte PLC_CapIdx = 1;
        private Color[] PLC_CapColor = { Color.Black, Color.Black, Color.Black, Color.Black, Color.Black };
        private String[] PLC_CapText = { "", "", "", "", "" };
        private Point[] PLC_CapPosition = { new Point(10, 10), new Point(10, 10), new Point(10, 10), new Point(10, 10), new Point(10, 10) };
        private Point PLC_Center = new Point(100, 100);
        private Single PLC_MinValue = -100;
        private Single PLC_MaxValue = 400;
        private Color PLC_BaseArcColor = Color.Gray;
        private Int32 PLC_BaseArcRadius = 80;
        private Int32 PLC_BaseArcStart = 132;
        private Int32 PLC_BaseArcSweep = 270;
        private Int32 PLC_BaseArcWidth = 2;
        private Color PLC_ScaleLinesInternalColor = Color.Black;
        private Int32 PLC_ScaleLinesInternalInnerRadius = 73;
        private Int32 PLC_ScaleLinesInternalOuterRadius = 80;
        private Int32 PLC_ScaleLinesInternalWidth = 1;
        private Int32 PLC_ScaleLinesMinorNumberOf = 9;
        private Color PLC_ScaleLinesMinorColor = Color.Gray;
        private Int32 PLC_ScaleLinesMinorInnerRadius = 75;
        private Int32 PLC_ScaleLinesMinorOuterRadius = 80;
        private Int32 PLC_ScaleLinesMinorWidth = 1;
        private Single PLC_ScaleLinesMajorStepValue = 50.0f;
        private Color PLC_ScaleLinesMajorColor = Color.Black;
        private Int32 PLC_ScaleLinesMajorInnerRadius = 70;
        private Int32 PLC_ScaleLinesMajorOuterRadius = 80;
        private Int32 PLC_ScaleLinesMajorWidth = 2;
        private Byte PLC_RangeIdx;
        private Boolean[] PLC_RangeEnabled = { true, true, false, false, false };
        private Color[] PLC_RangeColor = { Color.LightGreen, Color.Red, Color.FromKnownColor(KnownColor.Control), Color.FromKnownColor(KnownColor.Control), Color.FromKnownColor(KnownColor.Control) };
        private Single[] PLC_RangeStartValue = { -100.0f, 300.0f, 0.0f, 0.0f, 0.0f };
        private Single[] PLC_RangeEndValue = { 300.0f, 400.0f, 0.0f, 0.0f, 0.0f };
        private Int32[] PLC_RangeInnerRadius = { 70, 70, 70, 70, 70 };
        private Int32[] PLC_RangeOuterRadius = { 80, 80, 80, 80, 80 };
        private Int32 PLC_ScaleNumbersRadius = 95;
        private Color PLC_ScaleNumbersColor = Color.Black;
        private String PLC_ScaleNumbersFormat;
        private Int32 PLC_ScaleNumbersStartScaleLine;
        private Int32 PLC_ScaleNumbersStepScaleLines = 1;
        private Int32 PLC_ScaleNumbersRotation = 0;
        private Int32 PLC_NeedleType = 0;
        private Int32 PLC_NeedleRadius = 80;
        private Needle_Color NeedleColor_1 = Needle_Color.Gray;
        private Color NeedleColor_2 = Color.DimGray;
        private Int32 PLC_NeedleWidth = 2;
        public class ValueInRangeChangedEventArgs : EventArgs
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
        }
        public new Boolean AutoSize
        {
            get
            {
                return false;
            }
        }
        public new Boolean ForeColor
        {
            get
            {
                return false;
            }
        }
        public new Boolean ImeMode
        {
            get
            {
                return false;
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
                Draw_Gauge_Background = true;
                Refresh();
            }
        }
        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                Draw_Gauge_Background = true;
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
                Draw_Gauge_Background = true;
                Refresh();
            }
        }
        public enum Needle_Color
        {
            Gray = 0,
            Red = 1,
            Green = 2,
            Blue = 3,
            Yellow = 4,
            Violet = 5,
            Magenta = 6
        };
        public PLC_Gauge()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            PLC_Handle = null;
            PLC_VariablePath = "";
            PLC_VariableType = VarEnum.VT_UNKNOWN;
            Com = Comunicazioni.Instance;
        }
        public void ResetDefault()
        {
            this.PLCVariableValue = 0;
        }
        public bool Online(bool value)
        {
            bool ReturnValue = false;
            if (!PLC_VariablePath.Equals("") && (PLC_VariableType != VarEnum.VT_UNKNOWN))
            {
                if (PLC_Handle == null)
                    PLC_Handle = new VariableHandle(Com, PLC_VariablePath, -1, true);
                if (value)
                {
                    Com.RegisterVariable(PLC_Handle);
                    PLC_Handle.OnValueChange += new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                }
                else
                {
                    PLC_Handle.OnValueChange -= new VariableHandle.OnVariableValueChange(Handle_OnValueChange);
                    Com.RemoveVariable(PLC_Handle);
                    ResetDefault();
                }
            }
            return ReturnValue;
        }
        void Handle_OnValueChange(object sender)
        {
            if ((PLC_Handle != null) && (PLC_Handle.ActualValue != null))
                this.PLCVariableValue = (float)(Convert.ToDouble(PLC_Handle.ActualValue) / 1000);
        }
        public string PLCVariablePath
        {
            get
            {
                return PLC_VariablePath;
            }
            set
            {
                PLC_VariablePath = value;
            }
        }
        public VarEnum PLCVariableType
        {
            get
            {
                return PLC_VariableType;
            }
            set
            {
                PLC_VariableType = value;
            }
        }
        public Single PLCVariableValue
        {
            get
            {
                return PLC_Value;
            }
            set
            {
                if (PLC_Value != value)
                {
                    PLC_Value = Math.Min(Math.Max(value, MinValue), PLC_MaxValue);
                    if (this.DesignMode)
                        Draw_Gauge_Background = true;
                    for (Int32 Counter = 0; Counter < Number_of_ranges - 1; Counter++)
                    {
                        if ((PLC_RangeStartValue[Counter] <= PLC_Value) && (PLC_Value <= PLC_RangeEndValue[Counter]) && (PLC_RangeEnabled[Counter]))
                        {
                            if (!ValueIsInRange[Counter])
                            {
                                if (ValueInRangeChanged != null)
                                    ValueInRangeChanged(this, new ValueInRangeChangedEventArgs(Counter));
                            }
                        }
                        else
                            ValueIsInRange[Counter] = false;
                    }
                    Refresh();
                }
            }
        }
        public Byte CapIdx
        {
            get
            {
                return PLC_CapIdx;
            }
            set
            {
                if ((PLC_CapIdx != value) && (0 <= value) && (value < 5))
                    PLC_CapIdx = value;
            }
        }
        public Color CapColor
        {
            get
            {
                return PLC_CapColor[PLC_CapIdx];
            }
            set
            {
                if (PLC_CapColor[PLC_CapIdx] != value)
                {
                    PLC_CapColor[PLC_CapIdx] = value;
                    CapColors = PLC_CapColor;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Color[] CapColors
        {
            get
            {
                return PLC_CapColor;
            }
            set
            {
                PLC_CapColor = value;
            }
        }
        public String CapText
        {
            get
            {
                return PLC_CapText[PLC_CapIdx];
            }
            set
            {
                if (PLC_CapText[PLC_CapIdx] != value)
                {
                    PLC_CapText[PLC_CapIdx] = value;
                    CapsText = PLC_CapText;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public String[] CapsText
        {
            get
            {
                return PLC_CapText;
            }
            set
            {
                for (Int32 Counter = 0; Counter < 5; Counter++)
                    PLC_CapText[Counter] = value[Counter];
            }
        }
        public Point CapPosition
        {
            get
            {
                return PLC_CapPosition[PLC_CapIdx];
            }
            set
            {
                if (PLC_CapPosition[PLC_CapIdx] != value)
                {
                    PLC_CapPosition[PLC_CapIdx] = value;
                    CapsPosition = PLC_CapPosition;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Point[] CapsPosition
        {
            get
            {
                return PLC_CapPosition;
            }
            set
            {
                PLC_CapPosition = value;
            }
        }
        public Point Center
        {
            get
            {
                return PLC_Center;
            }
            set
            {
                if (PLC_Center != value)
                {
                    PLC_Center = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Single MinValue
        {
            get
            {
                return PLC_MinValue;
            }
            set
            {
                if ((PLC_MinValue != value) && (value < PLC_MaxValue))
                {
                    PLC_MinValue = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Single MaxValue
        {
            get
            {
                return PLC_MaxValue;
            }
            set
            {
                if ((PLC_MaxValue != value) && (value > PLC_MinValue))
                {
                    PLC_MaxValue = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Color BaseArcColor
        {
            get
            {
                return PLC_BaseArcColor;
            }
            set
            {
                if (PLC_BaseArcColor != value)
                {
                    PLC_BaseArcColor = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 BaseArcRadius
        {
            get => PLC_BaseArcRadius;
            set
            {
                if (PLC_BaseArcRadius != value)
                {
                    PLC_BaseArcRadius = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 BaseArcStart
        {
            get => PLC_BaseArcStart;
            set
            {
                if (PLC_BaseArcStart != value)
                {
                    PLC_BaseArcStart = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 BaseArcSweep
        {
            get => PLC_BaseArcSweep;
            set
            {
                if (PLC_BaseArcSweep != value)
                {
                    PLC_BaseArcSweep = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 BaseArcWidth
        {
            get => PLC_BaseArcWidth;
            set
            {
                if (PLC_BaseArcWidth != value)
                {
                    PLC_BaseArcWidth = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Color ScaleLinesInternalColor
        {
            get => PLC_ScaleLinesInternalColor;
            set
            {
                if (PLC_ScaleLinesInternalColor != value)
                {
                    PLC_ScaleLinesInternalColor = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesInternalInnerRadius
        {
            get => PLC_ScaleLinesInternalInnerRadius;
            set
            {
                if (PLC_ScaleLinesInternalInnerRadius != value)
                {
                    PLC_ScaleLinesInternalInnerRadius = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesInternalOuterRadius
        {
            get => PLC_ScaleLinesInternalOuterRadius;
            set
            {
                if (PLC_ScaleLinesInternalOuterRadius != value)
                {
                    PLC_ScaleLinesInternalOuterRadius = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesInternalWidth
        {
            get => PLC_ScaleLinesInternalWidth;
            set
            {
                if (PLC_ScaleLinesInternalWidth != value)
                {
                    PLC_ScaleLinesInternalWidth = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesMinorNumberOf
        {
            get => PLC_ScaleLinesMinorNumberOf;
            set
            {
                if (PLC_ScaleLinesMinorNumberOf != value)
                {
                    PLC_ScaleLinesMinorNumberOf = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Color ScaleLinesMinorColor
        {
            get => PLC_ScaleLinesMinorColor;
            set
            {
                if (PLC_ScaleLinesMinorColor != value)
                {
                    PLC_ScaleLinesMinorColor = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesMinorInnerRadius
        {
            get => PLC_ScaleLinesMinorInnerRadius;
            set
            {
                if (PLC_ScaleLinesMinorInnerRadius != value)
                {
                    PLC_ScaleLinesMinorInnerRadius = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }

            }
        }
        public Int32 ScaleLinesMinorOuterRadius
        {
            get => PLC_ScaleLinesMinorOuterRadius;
            set
            {
                if (PLC_ScaleLinesMinorOuterRadius != value)
                {
                    PLC_ScaleLinesMinorOuterRadius = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesMinorWidth
        {
            get => PLC_ScaleLinesMinorWidth;
            set
            {
                if (PLC_ScaleLinesMinorWidth != value)
                {
                    PLC_ScaleLinesMinorWidth = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Single ScaleLinesMajorStepValue
        {
            get => PLC_ScaleLinesMajorStepValue;
            set
            {
                if ((PLC_ScaleLinesMajorStepValue != value) && (value > 0))
                {
                    PLC_ScaleLinesMajorStepValue = Math.Max(Math.Min(value, PLC_MaxValue), PLC_MinValue);
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Color ScaleLinesMajorColor
        {
            get => PLC_ScaleLinesMajorColor;
            set
            {
                if (PLC_ScaleLinesMajorColor != value)
                {
                    PLC_ScaleLinesMajorColor = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesMajorInnerRadius
        {
            get => PLC_ScaleLinesMajorInnerRadius;
            set
            {
                if (PLC_ScaleLinesMajorInnerRadius != value)
                {
                    PLC_ScaleLinesMajorInnerRadius = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesMajorOuterRadius
        {
            get => PLC_ScaleLinesMajorOuterRadius;
            set
            {
                if (PLC_ScaleLinesMajorOuterRadius != value)
                {
                    PLC_ScaleLinesMajorOuterRadius = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleLinesMajorWidth
        {
            get => PLC_ScaleLinesMajorWidth;
            set
            {
                if (PLC_ScaleLinesMajorWidth != value)
                {
                    PLC_ScaleLinesMajorWidth = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Byte RangeIdx
        {
            get => PLC_RangeIdx;
            set
            {
                if ((PLC_RangeIdx != value) && (0 <= value) && (value < Number_of_ranges))
                {
                    PLC_RangeIdx = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Boolean RangeEnabled
        {
            get => PLC_RangeEnabled[PLC_RangeIdx];
            set
            {
                if (PLC_RangeEnabled[PLC_RangeIdx] != value)
                {
                    PLC_RangeEnabled[PLC_RangeIdx] = value;
                    RangesEnabled = PLC_RangeEnabled;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Boolean[] RangesEnabled
        {
            get => PLC_RangeEnabled;
            set => PLC_RangeEnabled = value;
        }
        public Color RangeColor
        {
            get => PLC_RangeColor[PLC_RangeIdx];
            set
            {
                if (PLC_RangeColor[PLC_RangeIdx] != value)
                {
                    PLC_RangeColor[PLC_RangeIdx] = value;
                    RangesColor = PLC_RangeColor;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Color[] RangesColor
        {
            get => PLC_RangeColor;
            set => PLC_RangeColor = value;
        }
        public Single RangeStartValue
        {
            get => PLC_RangeStartValue[PLC_RangeIdx];
            set
            {
                if ((PLC_RangeStartValue[PLC_RangeIdx] != value) && (value < PLC_RangeEndValue[PLC_RangeIdx]))
                {
                    PLC_RangeStartValue[PLC_RangeIdx] = value;
                    RangesStartValue = PLC_RangeStartValue;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Single[] RangesStartValue
        {
            get => PLC_RangeStartValue;
            set => PLC_RangeStartValue = value;
        }
        public Single RangeEndValue
        {
            get => PLC_RangeEndValue[PLC_RangeIdx];
            set
            {
                if ((PLC_RangeEndValue[PLC_RangeIdx] != value) && (PLC_RangeStartValue[PLC_RangeIdx] < value))
                {
                    PLC_RangeEndValue[PLC_RangeIdx] = value;
                    RangesEndValue = PLC_RangeEndValue;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Single[] RangesEndValue
        {
            get => PLC_RangeEndValue;
            set => PLC_RangeEndValue = value;
        }
        public Int32 RangeInnerRadius
        {
            get => PLC_RangeInnerRadius[PLC_RangeIdx];
            set
            {
                if (PLC_RangeInnerRadius[PLC_RangeIdx] != value)
                {
                    PLC_RangeInnerRadius[PLC_RangeIdx] = value;
                    RangesInnerRadius = PLC_RangeInnerRadius;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32[] RangesInnerRadius
        {
            get => PLC_RangeInnerRadius;
            set => PLC_RangeInnerRadius = value;
        }
        public Int32 RangeOuterRadius
        {
            get => PLC_RangeOuterRadius[PLC_RangeIdx];
            set
            {
                if (PLC_RangeOuterRadius[PLC_RangeIdx] != value)
                {
                    PLC_RangeOuterRadius[PLC_RangeIdx] = value;
                    RangesOuterRadius = PLC_RangeOuterRadius;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32[] RangesOuterRadius
        {
            get => PLC_RangeOuterRadius;
            set => PLC_RangeOuterRadius = value;
        }
        public Int32 ScaleNumbersRadius
        {
            get => PLC_ScaleNumbersRadius;
            set
            {
                if (PLC_ScaleNumbersRadius != value)
                {
                    PLC_ScaleNumbersRadius = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Color ScaleNumbersColor
        {
            get => PLC_ScaleNumbersColor;
            set
            {
                if (PLC_ScaleNumbersColor != value)
                {
                    PLC_ScaleNumbersColor = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public String ScaleNumbersFormat
        {
            get => PLC_ScaleNumbersFormat;
            set
            {
                if (PLC_ScaleNumbersFormat != value)
                {
                    PLC_ScaleNumbersFormat = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleNumbersStartScaleLine
        {
            get => PLC_ScaleNumbersStartScaleLine;
            set
            {
                if (PLC_ScaleNumbersStartScaleLine != value)
                {
                    PLC_ScaleNumbersStartScaleLine = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleNumbersStepScaleLines
        {
            get => PLC_ScaleNumbersStepScaleLines;
            set
            {
                if (PLC_ScaleNumbersStepScaleLines != value)
                {
                    PLC_ScaleNumbersStepScaleLines = Math.Max(value, 1);
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 ScaleNumbersRotation
        {
            get => PLC_ScaleNumbersRotation;
            set
            {
                if (PLC_ScaleNumbersRotation != value)
                {
                    PLC_ScaleNumbersRotation = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 NeedleType
        {
            get => PLC_NeedleType;
            set
            {
                if (PLC_NeedleType != value)
                {
                    PLC_NeedleType = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 NeedleRadius
        {
            get => PLC_NeedleRadius;
            set
            {
                if (PLC_NeedleRadius != value)
                {
                    PLC_NeedleRadius = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Needle_Color NeedleColor1
        {
            get => NeedleColor_1;
            set
            {
                if (NeedleColor_1 != value)
                {
                    NeedleColor_1 = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Color NeedleColor2
        {
            get => NeedleColor_2;
            set
            {
                if (NeedleColor_2 != value)
                {
                    NeedleColor_2 = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        public Int32 NeedleWidth
        {
            get => PLC_NeedleWidth;
            set
            {
                if (PLC_NeedleWidth != value)
                {
                    PLC_NeedleWidth = value;
                    Draw_Gauge_Background = true;
                    Refresh();
                }
            }
        }
        private void FindFontBounds()
        {
            Int32 C1;
            Int32 C2;
            Boolean BoundFound;
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
            Font_Bound_Y1 = 0;
            Font_Bound_Y2 = 0;
            C1 = 0;
            BoundFound = false;
            while ((C1 < B.Height) && (!BoundFound))
            {
                C2 = 0;
                while ((C2 < B.Width) && (!BoundFound))
                {
                    if (B.GetPixel(C2, C1) != BackBrush.Color)
                    {
                        Font_Bound_Y1 = C1;
                        BoundFound = true;
                    }
                    C2++;
                }
                C1++;
            }
            C1 = B.Height - 1;
            BoundFound = false;
            while ((0 < C1) && (!BoundFound))
            {
                C2 = 0;
                while ((C2 < B.Width) && (!BoundFound))
                {
                    if (B.GetPixel(C2, C1) != BackBrush.Color)
                    {
                        Font_Bound_Y2 = C1;
                        BoundFound = true;
                    }
                    C2++;
                }
                C1--;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if ((Width < 10) || (Height < 10))
            {
                return;
            }
            if (Draw_Gauge_Background)
            {
                Draw_Gauge_Background = false;
                FindFontBounds();
                Gauge_Bitmap = new Bitmap(Width, Height, e.Graphics);
                Graphics GGR = Graphics.FromImage(Gauge_Bitmap);
                GGR.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
                if (BackgroundImage != null)
                {
                    switch (BackgroundImageLayout)
                    {
                        case ImageLayout.Center:
                            GGR.DrawImageUnscaled(BackgroundImage, Width / 2 - BackgroundImage.Width / 2, Height / 2 - BackgroundImage.Height / 2);
                            break;
                        case ImageLayout.None:
                            GGR.DrawImageUnscaled(BackgroundImage, 0, 0);
                            break;
                        case ImageLayout.Stretch:
                            GGR.DrawImage(BackgroundImage, 0, 0, Width, Height);
                            break;
                        case ImageLayout.Tile:
                            Int32 PixelOffsetX = 0;
                            Int32 PixelOffsetY = 0;
                            while (PixelOffsetX < Width)
                            {
                                PixelOffsetY = 0;
                                while (PixelOffsetY < Height)
                                {
                                    GGR.DrawImageUnscaled(BackgroundImage, PixelOffsetX, PixelOffsetY);
                                    PixelOffsetY += BackgroundImage.Height;
                                }
                                PixelOffsetX += BackgroundImage.Width;
                            }
                            break;
                        case ImageLayout.Zoom:
                            if ((Single)(BackgroundImage.Width / Width) < (Single)(BackgroundImage.Height / Height))
                                GGR.DrawImage(BackgroundImage, 0, 0, Height, Height);
                            else
                                GGR.DrawImage(BackgroundImage, 0, 0, Width, Width);
                            break;
                    }
                }
                GGR.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                GGR.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                GraphicsPath GP = new GraphicsPath();
                Single RangeStartAngle;
                Single RangeSweepAngle;
                for (Int32 Counter = 0; Counter < Number_of_ranges; Counter++)
                {
                    if (PLC_RangeEndValue[Counter] > PLC_RangeStartValue[Counter] && PLC_RangeEnabled[Counter])
                    {
                        RangeStartAngle = PLC_BaseArcStart + (PLC_RangeStartValue[Counter] - PLC_MinValue) * PLC_BaseArcSweep / (PLC_MaxValue - PLC_MinValue);
                        RangeSweepAngle = (PLC_RangeEndValue[Counter] - PLC_RangeStartValue[Counter]) * PLC_BaseArcSweep / (PLC_MaxValue - PLC_MinValue);
                        GP.Reset();
                        GP.AddPie(new Rectangle(PLC_Center.X - PLC_RangeOuterRadius[Counter], PLC_Center.Y - PLC_RangeOuterRadius[Counter], 2 * PLC_RangeOuterRadius[Counter], 2 * PLC_RangeOuterRadius[Counter]), RangeStartAngle, RangeSweepAngle);
                        GP.Reverse();
                        GP.AddPie(new Rectangle(PLC_Center.X - PLC_RangeOuterRadius[Counter], PLC_Center.Y - PLC_RangeOuterRadius[Counter], 2 * PLC_RangeOuterRadius[Counter], 2 * PLC_RangeOuterRadius[Counter]), RangeStartAngle, RangeSweepAngle);
                        GP.Reverse();
                        GGR.SetClip(GP);
                        GGR.FillPie(new SolidBrush(PLC_RangeColor[Counter]), new Rectangle(PLC_Center.X - PLC_RangeOuterRadius[Counter], PLC_Center.Y - PLC_RangeOuterRadius[Counter], 2 * PLC_RangeOuterRadius[Counter], 2 * PLC_RangeOuterRadius[Counter]), RangeStartAngle, RangeSweepAngle);
                    }
                }
                GGR.SetClip(ClientRectangle);
                if (PLC_BaseArcRadius > 0)
                    GGR.DrawArc(new Pen(PLC_BaseArcColor, PLC_BaseArcWidth), new Rectangle(PLC_Center.X - PLC_BaseArcRadius, PLC_Center.Y - PLC_BaseArcRadius, 2 * PLC_BaseArcRadius, 2 * PLC_BaseArcRadius), PLC_BaseArcStart, PLC_BaseArcSweep);
                String ValueText = "";
                SizeF BoundingBox;
                Single CountValue = 0;
                Int32 Counter1 = 0;
                while (CountValue <= (PLC_MaxValue - PLC_MinValue))
                {
                    ValueText = (PLC_MinValue + CountValue).ToString(PLC_ScaleNumbersFormat);
                    GGR.ResetTransform();
                    BoundingBox = GGR.MeasureString(ValueText, Font, -1, StringFormat.GenericTypographic);
                    GP.Reset();
                    GP.AddEllipse(new Rectangle(PLC_Center.X - PLC_ScaleLinesMajorOuterRadius, PLC_Center.Y - PLC_ScaleLinesMajorOuterRadius, 2 * PLC_ScaleLinesMajorOuterRadius, 2 * PLC_ScaleLinesMajorOuterRadius));
                    GP.Reverse();
                    GP.AddEllipse(new Rectangle(PLC_Center.X - PLC_ScaleLinesMajorInnerRadius, PLC_Center.Y - PLC_ScaleLinesMajorInnerRadius, 2 * PLC_ScaleLinesMajorInnerRadius, 2 * PLC_ScaleLinesMajorInnerRadius));
                    GP.Reverse();
                    GGR.SetClip(GP);
                    GGR.DrawLine(new Pen(PLC_ScaleLinesMajorColor, PLC_ScaleLinesMajorWidth),
                    (Single)(Center.X),
                    (Single)(Center.Y),
                    (Single)(Center.X + 2 * PLC_ScaleLinesMajorOuterRadius * Math.Cos((PLC_BaseArcStart + CountValue * PLC_BaseArcSweep / (PLC_MaxValue - PLC_MinValue)) * Math.PI / 180.0)),
                    (Single)(Center.Y + 2 * PLC_ScaleLinesMajorOuterRadius * Math.Sin((PLC_BaseArcStart + CountValue * PLC_BaseArcSweep / (PLC_MaxValue - PLC_MinValue)) * Math.PI / 180.0)));

                    GP.Reset();
                    GP.AddEllipse(new Rectangle(PLC_Center.X - PLC_ScaleLinesMinorOuterRadius, PLC_Center.Y - PLC_ScaleLinesMinorOuterRadius, 2 * PLC_ScaleLinesMinorOuterRadius, 2 * PLC_ScaleLinesMinorOuterRadius));
                    GP.Reverse();
                    GP.AddEllipse(new Rectangle(PLC_Center.X - PLC_ScaleLinesMinorInnerRadius, PLC_Center.Y - PLC_ScaleLinesMinorInnerRadius, 2 * PLC_ScaleLinesMinorInnerRadius, 2 * PLC_ScaleLinesMinorInnerRadius));
                    GP.Reverse();
                    GGR.SetClip(GP);
                    if (CountValue < (PLC_MaxValue - PLC_MinValue))
                    {
                        for (Int32 counter2 = 1; counter2 <= PLC_ScaleLinesMinorNumberOf; counter2++)
                        {
                            if (((PLC_ScaleLinesMinorNumberOf % 2) == 1) && ((Int32)(PLC_ScaleLinesMinorNumberOf / 2) + 1 == counter2))
                            {
                                GP.Reset();
                                GP.AddEllipse(new Rectangle(PLC_Center.X - PLC_ScaleLinesInternalOuterRadius, PLC_Center.Y - PLC_ScaleLinesInternalOuterRadius, 2 * PLC_ScaleLinesInternalOuterRadius, 2 * PLC_ScaleLinesInternalOuterRadius));
                                GP.Reverse();
                                GP.AddEllipse(new Rectangle(PLC_Center.X - PLC_ScaleLinesInternalInnerRadius, PLC_Center.Y - PLC_ScaleLinesInternalInnerRadius, 2 * PLC_ScaleLinesInternalInnerRadius, 2 * PLC_ScaleLinesInternalInnerRadius));
                                GP.Reverse();
                                GGR.SetClip(GP);
                                GGR.DrawLine(new Pen(PLC_ScaleLinesInternalColor, PLC_ScaleLinesInternalWidth),
                                (Single)(Center.X),
                                (Single)(Center.Y),
                                (Single)(Center.X + 2 * PLC_ScaleLinesInternalOuterRadius * Math.Cos((PLC_BaseArcStart + CountValue * PLC_BaseArcSweep / (PLC_MaxValue - PLC_MinValue) + counter2 * PLC_BaseArcSweep / (((Single)((PLC_MaxValue - PLC_MinValue) / PLC_ScaleLinesMajorStepValue)) * (PLC_ScaleLinesMinorNumberOf + 1))) * Math.PI / 180.0)),
                                (Single)(Center.Y + 2 * PLC_ScaleLinesInternalOuterRadius * Math.Sin((PLC_BaseArcStart + CountValue * PLC_BaseArcSweep / (PLC_MaxValue - PLC_MinValue) + counter2 * PLC_BaseArcSweep / (((Single)((PLC_MaxValue - PLC_MinValue) / PLC_ScaleLinesMajorStepValue)) * (PLC_ScaleLinesMinorNumberOf + 1))) * Math.PI / 180.0)));
                                GP.Reset();
                                GP.AddEllipse(new Rectangle(PLC_Center.X - PLC_ScaleLinesMinorOuterRadius, PLC_Center.Y - PLC_ScaleLinesMinorOuterRadius, 2 * PLC_ScaleLinesMinorOuterRadius, 2 * PLC_ScaleLinesMinorOuterRadius));
                                GP.Reverse();
                                GP.AddEllipse(new Rectangle(PLC_Center.X - PLC_ScaleLinesMinorInnerRadius, PLC_Center.Y - PLC_ScaleLinesMinorInnerRadius, 2 * PLC_ScaleLinesMinorInnerRadius, 2 * PLC_ScaleLinesMinorInnerRadius));
                                GP.Reverse();
                                GGR.SetClip(GP);
                            }
                            else
                            {
                                GGR.DrawLine(new Pen(PLC_ScaleLinesMinorColor, PLC_ScaleLinesMinorWidth),
                                (Single)(Center.X),
                                (Single)(Center.Y),
                                (Single)(Center.X + 2 * PLC_ScaleLinesMinorOuterRadius * Math.Cos((PLC_BaseArcStart + CountValue * PLC_BaseArcSweep / (PLC_MaxValue - PLC_MinValue) + counter2 * PLC_BaseArcSweep / (((Single)((PLC_MaxValue - PLC_MinValue) / PLC_ScaleLinesMajorStepValue)) * (PLC_ScaleLinesMinorNumberOf + 1))) * Math.PI / 180.0)),
                                (Single)(Center.Y + 2 * PLC_ScaleLinesMinorOuterRadius * Math.Sin((PLC_BaseArcStart + CountValue * PLC_BaseArcSweep / (PLC_MaxValue - PLC_MinValue) + counter2 * PLC_BaseArcSweep / (((Single)((PLC_MaxValue - PLC_MinValue) / PLC_ScaleLinesMajorStepValue)) * (PLC_ScaleLinesMinorNumberOf + 1))) * Math.PI / 180.0)));
                            }
                        }
                    }
                    GGR.SetClip(ClientRectangle);
                    if (PLC_ScaleNumbersRotation != 0)
                    {
                        GGR.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        GGR.RotateTransform(90.0F + PLC_BaseArcStart + CountValue * PLC_BaseArcSweep / (PLC_MaxValue - PLC_MinValue));
                    }
                    GGR.TranslateTransform((Single)(Center.X + PLC_ScaleNumbersRadius * Math.Cos((PLC_BaseArcStart + CountValue * PLC_BaseArcSweep / (PLC_MaxValue - PLC_MinValue)) * Math.PI / 180.0f)), (Single)(Center.Y + PLC_ScaleNumbersRadius * Math.Sin((PLC_BaseArcStart + CountValue * PLC_BaseArcSweep / (PLC_MaxValue - PLC_MinValue)) * Math.PI / 180.0f)), System.Drawing.Drawing2D.MatrixOrder.Append);
                    if (Counter1 >= ScaleNumbersStartScaleLine - 1)
                    {
                        GGR.DrawString(ValueText, Font, new SolidBrush(PLC_ScaleNumbersColor), -BoundingBox.Width / 2, -Font_Bound_Y1 - (Font_Bound_Y2 - Font_Bound_Y1 + 1) / 2, StringFormat.GenericTypographic);
                    }
                    CountValue += PLC_ScaleLinesMajorStepValue;
                    Counter1++;
                }
                GGR.ResetTransform();
                GGR.SetClip(ClientRectangle);
                if (PLC_ScaleNumbersRotation != 0)
                    GGR.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
                for (Int32 counter = 0; counter < Number_of_Caps; counter++)
                {
                    if (PLC_CapText[counter] != "")
                        GGR.DrawString(PLC_CapText[counter], Font, new SolidBrush(PLC_CapColor[counter]), PLC_CapPosition[counter].X, PLC_CapPosition[counter].Y, StringFormat.GenericTypographic);
                }
            }

            e.Graphics.DrawImageUnscaled(Gauge_Bitmap, 0, 0);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Single brushAngle = (Int32)(PLC_BaseArcStart + (PLC_Value - PLC_MinValue) * PLC_BaseArcSweep / (PLC_MaxValue - PLC_MinValue)) % 360;
            Double needleAngle = brushAngle * Math.PI / 180;

            switch (PLC_NeedleType)
            {
                case 0:
                    PointF[] points = new PointF[3];
                    Brush brush1 = Brushes.White;
                    Brush brush2 = Brushes.White;
                    Brush brush3 = Brushes.White;
                    Brush brush4 = Brushes.White;

                    Brush brushBucket = Brushes.White;
                    Int32 subcol = (Int32)(((brushAngle + 225) % 180) * 100 / 180);
                    Int32 subcol2 = (Int32)(((brushAngle + 135) % 180) * 100 / 180);

                    e.Graphics.FillEllipse(new SolidBrush(NeedleColor_2), Center.X - PLC_NeedleWidth * 3, Center.Y - PLC_NeedleWidth * 3, PLC_NeedleWidth * 6, PLC_NeedleWidth * 6);
                    switch (NeedleColor_1)
                    {
                        case Needle_Color.Gray:
                            brush1 = new SolidBrush(Color.FromArgb(80 + subcol, 80 + subcol, 80 + subcol));
                            brush2 = new SolidBrush(Color.FromArgb(180 - subcol, 180 - subcol, 180 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(80 + subcol2, 80 + subcol2, 80 + subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(180 - subcol2, 180 - subcol2, 180 - subcol2));
                            e.Graphics.DrawEllipse(Pens.Gray, Center.X - PLC_NeedleWidth * 3, Center.Y - PLC_NeedleWidth * 3, PLC_NeedleWidth * 6, PLC_NeedleWidth * 6);
                            break;
                        case Needle_Color.Red:
                            brush1 = new SolidBrush(Color.FromArgb(145 + subcol, subcol, subcol));
                            brush2 = new SolidBrush(Color.FromArgb(245 - subcol, 100 - subcol, 100 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(145 + subcol2, subcol2, subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(245 - subcol2, 100 - subcol2, 100 - subcol2));
                            e.Graphics.DrawEllipse(Pens.Red, Center.X - PLC_NeedleWidth * 3, Center.Y - PLC_NeedleWidth * 3, PLC_NeedleWidth * 6, PLC_NeedleWidth * 6);
                            break;
                        case Needle_Color.Green:
                            brush1 = new SolidBrush(Color.FromArgb(subcol, 145 + subcol, subcol));
                            brush2 = new SolidBrush(Color.FromArgb(100 - subcol, 245 - subcol, 100 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(subcol2, 145 + subcol2, subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(100 - subcol2, 245 - subcol2, 100 - subcol2));
                            e.Graphics.DrawEllipse(Pens.Green, Center.X - PLC_NeedleWidth * 3, Center.Y - PLC_NeedleWidth * 3, PLC_NeedleWidth * 6, PLC_NeedleWidth * 6);
                            break;
                        case Needle_Color.Blue:
                            brush1 = new SolidBrush(Color.FromArgb(subcol, subcol, 145 + subcol));
                            brush2 = new SolidBrush(Color.FromArgb(100 - subcol, 100 - subcol, 245 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(subcol2, subcol2, 145 + subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(100 - subcol2, 100 - subcol2, 245 - subcol2));
                            e.Graphics.DrawEllipse(Pens.Blue, Center.X - PLC_NeedleWidth * 3, Center.Y - PLC_NeedleWidth * 3, PLC_NeedleWidth * 6, PLC_NeedleWidth * 6);
                            break;
                        case Needle_Color.Magenta:
                            brush1 = new SolidBrush(Color.FromArgb(subcol, 145 + subcol, 145 + subcol));
                            brush2 = new SolidBrush(Color.FromArgb(100 - subcol, 245 - subcol, 245 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(subcol2, 145 + subcol2, 145 + subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(100 - subcol2, 245 - subcol2, 245 - subcol2));
                            e.Graphics.DrawEllipse(Pens.Magenta, Center.X - PLC_NeedleWidth * 3, Center.Y - PLC_NeedleWidth * 3, PLC_NeedleWidth * 6, PLC_NeedleWidth * 6);
                            break;
                        case Needle_Color.Violet:
                            brush1 = new SolidBrush(Color.FromArgb(145 + subcol, subcol, 145 + subcol));
                            brush2 = new SolidBrush(Color.FromArgb(245 - subcol, 100 - subcol, 245 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(145 + subcol2, subcol2, 145 + subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(245 - subcol2, 100 - subcol2, 245 - subcol2));
                            e.Graphics.DrawEllipse(Pens.Violet, Center.X - PLC_NeedleWidth * 3, Center.Y - PLC_NeedleWidth * 3, PLC_NeedleWidth * 6, PLC_NeedleWidth * 6);
                            break;
                        case Needle_Color.Yellow:
                            brush1 = new SolidBrush(Color.FromArgb(145 + subcol, 145 + subcol, subcol));
                            brush2 = new SolidBrush(Color.FromArgb(245 - subcol, 245 - subcol, 100 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(145 + subcol2, 145 + subcol2, subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(245 - subcol2, 245 - subcol2, 100 - subcol2));
                            e.Graphics.DrawEllipse(Pens.Violet, Center.X - PLC_NeedleWidth * 3, Center.Y - PLC_NeedleWidth * 3, PLC_NeedleWidth * 6, PLC_NeedleWidth * 6);
                            break;
                    }
                    if (Math.Floor((Single)(((brushAngle + 225) % 360) / 180.0)) == 0)
                    {
                        brushBucket = brush1;
                        brush1 = brush2;
                        brush2 = brushBucket;
                    }
                    if (Math.Floor((Single)(((brushAngle + 135) % 360) / 180.0)) == 0)
                    {
                        brush4 = brush3;
                    }
                    points[0].X = (Single)(Center.X + PLC_NeedleRadius * Math.Cos(needleAngle));
                    points[0].Y = (Single)(Center.Y + PLC_NeedleRadius * Math.Sin(needleAngle));
                    points[1].X = (Single)(Center.X - PLC_NeedleRadius / 20 * Math.Cos(needleAngle));
                    points[1].Y = (Single)(Center.Y - PLC_NeedleRadius / 20 * Math.Sin(needleAngle));
                    points[2].X = (Single)(Center.X - PLC_NeedleRadius / 5 * Math.Cos(needleAngle) + PLC_NeedleWidth * 2 * Math.Cos(needleAngle + Math.PI / 2));
                    points[2].Y = (Single)(Center.Y - PLC_NeedleRadius / 5 * Math.Sin(needleAngle) + PLC_NeedleWidth * 2 * Math.Sin(needleAngle + Math.PI / 2));
                    e.Graphics.FillPolygon(brush1, points);

                    points[2].X = (Single)(Center.X - PLC_NeedleRadius / 5 * Math.Cos(needleAngle) + PLC_NeedleWidth * 2 * Math.Cos(needleAngle - Math.PI / 2));
                    points[2].Y = (Single)(Center.Y - PLC_NeedleRadius / 5 * Math.Sin(needleAngle) + PLC_NeedleWidth * 2 * Math.Sin(needleAngle - Math.PI / 2));
                    e.Graphics.FillPolygon(brush2, points);

                    points[0].X = (Single)(Center.X - (PLC_NeedleRadius / 20 - 1) * Math.Cos(needleAngle));
                    points[0].Y = (Single)(Center.Y - (PLC_NeedleRadius / 20 - 1) * Math.Sin(needleAngle));
                    points[1].X = (Single)(Center.X - PLC_NeedleRadius / 5 * Math.Cos(needleAngle) + PLC_NeedleWidth * 2 * Math.Cos(needleAngle + Math.PI / 2));
                    points[1].Y = (Single)(Center.Y - PLC_NeedleRadius / 5 * Math.Sin(needleAngle) + PLC_NeedleWidth * 2 * Math.Sin(needleAngle + Math.PI / 2));
                    points[2].X = (Single)(Center.X - PLC_NeedleRadius / 5 * Math.Cos(needleAngle) + PLC_NeedleWidth * 2 * Math.Cos(needleAngle - Math.PI / 2));
                    points[2].Y = (Single)(Center.Y - PLC_NeedleRadius / 5 * Math.Sin(needleAngle) + PLC_NeedleWidth * 2 * Math.Sin(needleAngle - Math.PI / 2));
                    e.Graphics.FillPolygon(brush4, points);

                    points[0].X = (Single)(Center.X - PLC_NeedleRadius / 20 * Math.Cos(needleAngle));
                    points[0].Y = (Single)(Center.Y - PLC_NeedleRadius / 20 * Math.Sin(needleAngle));
                    points[1].X = (Single)(Center.X + PLC_NeedleRadius * Math.Cos(needleAngle));
                    points[1].Y = (Single)(Center.Y + PLC_NeedleRadius * Math.Sin(needleAngle));

                    e.Graphics.DrawLine(new Pen(NeedleColor_2), Center.X, Center.Y, points[0].X, points[0].Y);
                    e.Graphics.DrawLine(new Pen(NeedleColor_2), Center.X, Center.Y, points[1].X, points[1].Y);
                    break;
                case 1:
                    Point startPoint = new Point((Int32)(Center.X - PLC_NeedleRadius / 8 * Math.Cos(needleAngle)),
                                               (Int32)(Center.Y - PLC_NeedleRadius / 8 * Math.Sin(needleAngle)));
                    Point endPoint = new Point((Int32)(Center.X + PLC_NeedleRadius * Math.Cos(needleAngle)),
                                             (Int32)(Center.Y + PLC_NeedleRadius * Math.Sin(needleAngle)));

                    e.Graphics.FillEllipse(new SolidBrush(NeedleColor_2), Center.X - PLC_NeedleWidth * 3, Center.Y - PLC_NeedleWidth * 3, PLC_NeedleWidth * 6, PLC_NeedleWidth * 6);

                    switch (NeedleColor_1)
                    {
                        case Needle_Color.Gray:
                            e.Graphics.DrawLine(new Pen(Color.DarkGray, PLC_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            e.Graphics.DrawLine(new Pen(Color.DarkGray, PLC_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                        case Needle_Color.Red:
                            e.Graphics.DrawLine(new Pen(Color.Red, PLC_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            e.Graphics.DrawLine(new Pen(Color.Red, PLC_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                        case Needle_Color.Green:
                            e.Graphics.DrawLine(new Pen(Color.Green, PLC_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            e.Graphics.DrawLine(new Pen(Color.Green, PLC_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                        case Needle_Color.Blue:
                            e.Graphics.DrawLine(new Pen(Color.Blue, PLC_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            e.Graphics.DrawLine(new Pen(Color.Blue, PLC_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                        case Needle_Color.Magenta:
                            e.Graphics.DrawLine(new Pen(Color.Magenta, PLC_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            e.Graphics.DrawLine(new Pen(Color.Magenta, PLC_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                        case Needle_Color.Violet:
                            e.Graphics.DrawLine(new Pen(Color.Violet, PLC_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            e.Graphics.DrawLine(new Pen(Color.Violet, PLC_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                        case Needle_Color.Yellow:
                            e.Graphics.DrawLine(new Pen(Color.Yellow, PLC_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            e.Graphics.DrawLine(new Pen(Color.Yellow, PLC_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                    }
                    break;
            }
        }
    }
}
