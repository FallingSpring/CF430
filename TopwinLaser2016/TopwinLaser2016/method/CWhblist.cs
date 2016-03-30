using System;
using System.Drawing;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace TopwinLaser2016
{
    public struct tagDXFSTRING
    {
        public string strCode;
        public string strValue;

        public tagDXFSTRING(string s1,string s2)
        {
            strCode = s1;
            strValue = s2;
        }
    }
    public class CWhCommon : LinkedList<object>
    {
        public int m_nRefCount;

        public void AddRef()
        {
            m_nRefCount++;
        }
        public int GetRefCount()
        {
            return m_nRefCount;
        }
        public void Release()
        {
            m_nRefCount--;
        }
    }
    public class CWhVirtual : CWhCommon
    {
        public static int s_lID;
        public int m_lID;
        public int m_nObjType;
        public RectangleF m_rcBound = new RectangleF();
        public CWhListContainer m_pParentList;

        public int m_nMachineCount; //加工次数
        public bool m_bMachineStyle; //加工方式
        public int m_nMachineFrequence; //加工频率
        public bool m_bIsShow;
        public bool m_bIsShowHandle;
        public bool m_bIsSelect;
        public bool m_bIsFilled;

        public int m_nPenWidth; //线宽
        public int m_nPenType; //线型
        public Color m_colPenColor; //颜色

        public int m_nBrushType;
        public Color m_colBrush;
        public bool m_bFlagIsRegister;

        public PointF TransRPtoLP(PointF ptInput)
        {
            PointF ptRet = new PointF();

            ptRet.X = ptInput.X;
            ptRet.Y = -ptInput.Y;
            return ptRet;
        }
        public PointF TransLPtoRP(PointF ptInput)
        {
            PointF ptRet = new PointF();
            ptRet.X = ptInput.X;
            ptRet.Y = -ptInput.Y;
            return ptRet;
        }
        public PointF TopLeft(RectangleF rcInput)
        {
            PointF oldpoint = new PointF();
            oldpoint.X = rcInput.Left;
            oldpoint.Y = rcInput.Top;
            return oldpoint;
        }
        public RectangleF TransRPtoLP(RectangleF rcInput)
        {
            RectangleF rcRet = new RectangleF(TransRPtoLP(TopLeft(rcInput)),rcInput.Size);
            return rcRet;
        }
        public RectangleF TransLPtoRP(RectangleF rcInput)
        {
            RectangleF rcRet = new RectangleF(TransRPtoLP(TopLeft(rcInput)), rcInput.Size);
            return rcRet;
        }
        public PointF TransDPtoLP(PointF ptInput, ref Graphics pDC)
        {
            PointF[] ptRet ={ ptInput,ptInput};
            pDC.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace.Page,System.Drawing.Drawing2D.CoordinateSpace.World,ptRet);
            //pDC.DPtoLP(ptRet);
            return ptRet[0];
        }
        public RectangleF TransDPtoLP(RectangleF rcInput, ref Graphics pDC)
        {
            RectangleF rcRet = rcInput;
            PointF[] ptRet = { TopLeft(rcInput), TopLeft(rcInput)};
            ptRet[1].X = rcInput.Right;
            ptRet[1].Y = rcInput.Bottom;
            pDC.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace.Page, System.Drawing.Drawing2D.CoordinateSpace.World, ptRet);
            rcRet = new RectangleF(ptRet[0].X, ptRet[0].Y,ptRet[1].X-ptRet[0].X, ptRet[0].Y-ptRet[1].Y);            
            return rcRet;
        }
        public PointF TransDPtoRP(PointF ptInput, ref Graphics pDC)
        {
            PointF ptRet = new PointF();
            PointF ptTem = new PointF();
            ptTem = TransDPtoLP(ptInput, ref pDC);
            ptRet = TransLPtoRP(ptTem);
            return ptRet;
        }
        public RectangleF TransDPtoRP(RectangleF rcInput, ref Graphics pDC)
        {
            RectangleF rcRet = new RectangleF();
            RectangleF rcTem = new RectangleF();
            rcTem = TransDPtoLP(rcInput, ref pDC);
            rcRet = TransLPtoRP(rcTem);
            return rcRet;
        }
               
        public virtual void Serialize(ref BinaryFormatter ar)
        {                       
            if(ar)
            {
                GetObjectData(m_nRefCount,ar);
            }
            else
            {

            }
            if (ar.IsLoading() != 0)
            {
                ar >> m_nRefCount >> m_lID >> m_nObjType >> m_rcBound >> m_bIsShow >> m_nMachineCount >> m_bIsFilled >> m_bIsShowHandle >> m_nPenWidth >> m_nPenType >> m_colPenColor >> m_nBrushType >> m_colBrush >> m_nMachineFrequence >> m_bFlagIsRegister >> m_bMachineStyle;
            }
            else
            {
                ar << m_nRefCount << m_lID << m_nObjType << m_rcBound << m_bIsShow << m_nMachineCount << m_bIsFilled << m_bIsShowHandle << m_nPenWidth << m_nPenType << m_colPenColor << m_nBrushType << m_colBrush << m_nMachineFrequence << m_bFlagIsRegister << m_bMachineStyle;
            }
        }

        public virtual bool IsValid()
        {
            return true;
        }
        public virtual void Draw(ref Graphics pDC, RectangleF rcClient)
        {

        }
        public virtual void DrawHandle(ref Graphics pDC)
        {

        }
        public virtual void DrawArrow(ref Graphics pDC)
        {

        }
        public virtual void DrawStartPoint(ref Graphics pDC)
        {

        }
        public virtual void DrawNumber(ref Graphics pDC)
        {

        }
        public virtual void UpdateBoundRect()
        {

        }
        public virtual void Move(float nX, float nY)
        {

        }
        public virtual void SetIsShowHandle(bool bIsShowHandle)
        {
            m_bIsShowHandle = bIsShowHandle;
        }
        public virtual void ExchangeStartToEnd()
        {

        }
        public virtual PointF GetStartPoint()
        {
            PointF ptRet = new PointF(0, 0);
            return ptRet;
        }
        public virtual PointF GetEndPoint()
        {
            PointF ptRet = new PointF(0, 0);
            return ptRet;
        }
        public virtual bool IsObjValid()
        {
            return true;
        }
        public virtual bool IsSelected(PointF ptClick, int nLimit)
        {
            return false;
        }
        public virtual bool IsSelected(RectangleF rcClick, int bFlagMode)
        {
            return false;
        }
        public virtual bool IsObjInRect(RectangleF rcClient)
        {
            return IsObjInRect(rcClient,false);
        }
        public virtual bool IsObjInRect(RectangleF rcClient, bool bFlagDepth = false)
        {
            RectangleF rcInterSectRect = new RectangleF(0, 0, 0, 0);
            rcInterSectRect = RectangleF.Intersect(m_rcBound, rcClient);
            if (!rcInterSectRect.IsEmpty)
            {
                return true;
            }
            return false;
        }
        public virtual bool IsPointSnap(ref PointF ptSnap, PointF ptInput, float fDiatance)
        {
            bool bRet = false;
            return bRet;
        }
        public virtual bool IsPointSelect(ref PointF ptSnap, ref int nSnap, PointF ptInput, float fDiatance)
        {
            return false;
        }
        public virtual bool IsStartPointSelect(ref PointF ptRet, PointF ptInput, float fDiatance)
        {
            return false;
        }
        public virtual void SetObjDefaultProperty()
        {

        }
        public virtual void SetPenColor(Color colRef)
        {
            m_colPenColor = colRef;
        }
        public virtual void SetBrushColor(Color colRef)
        {
            m_colBrush = colRef;
        }
        public void SetObjType(int nObjType)
        {
            m_nObjType = nObjType;
        }
        public int GetObjType()
        {
            return m_nObjType;
        }
        public void SetIsShow(bool bIsShow)
        {
            m_bIsShow = bIsShow;
        }
        public bool GetIsShow()
        {
            return m_bIsShow;
        }
        public virtual void SetMachineCount(int nMachineCount)
        {
            m_nMachineCount = nMachineCount;
        }
        public int GetMachineCount()
        {
            return m_nMachineCount;
        }
        public virtual void SetMachineFrequence(int nMachineFrequence)
        {
            m_nMachineFrequence = nMachineFrequence;
        }
        public int GetMachineFrequence()
        {
            return m_nMachineFrequence;
        }
        public void SetPenWidth(int nPenWidth)
        {
            m_nPenWidth = nPenWidth;
        }
        public int GetPenWidth()
        {
            return m_nPenWidth;
        }
        public void SetPenType(int nPenType)
        {
            m_nPenType = nPenType;
        }
        public int GetPenType()
        {
            return m_nPenType;
        }
        public Color GetPenColor()
        {
            return m_colPenColor;
        }
        public void SetIsFilled(bool bIsFilled)
        {
            m_bIsFilled = bIsFilled;
        }
        public void SetMachineStyle(bool bMachineStyle)
        {
            m_bMachineStyle = bMachineStyle;
        }
        public bool GetMachineStyle()
        {
            return m_bMachineStyle;
        }
        public RectangleF MyRectangle(PointF m_ptStart, PointF m_ptEnd)
        {
            return new RectangleF(m_ptStart.X, m_ptStart.Y, m_ptEnd.X - m_ptStart.X, m_ptStart.Y - m_ptEnd.Y);
        }
    }
    public class CWhSysFunction 
    {
        public static float PointToLineDistance(PointF pt1, PointF pt2, PointF pt3)
        {
            if (pt1 == pt2)
            {
                return 0;
            }

            if (pt1 == pt3)
            {
                return 0;
            }


            if (pt1.X == pt2.X)
            {
                return System.Math.Abs(pt1.X - pt3.X);
            }
            else if (pt1.Y == pt2.Y)
            {
                return System.Math.Abs(pt1.Y - pt3.Y);
            }


            float k1 = 0;
            float k2 = 0;
            float x1 = 0;
            float y1 = 0;
            float x2 = 0;
            float y2 = 0;
            float x3 = 0;
            float y3 = 0;
            float xt = 0;
            float yt = 0;
            float fDistance = 0;
            x1 = pt1.X / DefineConstantsFdxf.TRANSRATIO;
            y1 = pt1.Y / DefineConstantsFdxf.TRANSRATIO;
            x2 = pt2.X / DefineConstantsFdxf.TRANSRATIO;
            y2 = pt2.Y / DefineConstantsFdxf.TRANSRATIO;
            x3 = pt3.X / DefineConstantsFdxf.TRANSRATIO;
            y3 = pt3.Y / DefineConstantsFdxf.TRANSRATIO;

            k1 = (y2 - y1) / (x2 - x1);
            k2 = -1 / k1;
            xt = (y3 - y1 + k1 * x1 - k2 * x3) / (k1 - k2);
            yt = k2 * xt + y3 - k2 * x3;

            fDistance = (x3 - xt) * (x3 - xt) + (y3 - yt) * (y3 - yt);
            fDistance = (float)System.Math.Sqrt((double)(fDistance));
            fDistance *= DefineConstantsFdxf.TRANSRATIO;

            return fDistance;
        }
        public static float PointToPointDistance(PointF pt1, PointF pt2)
        {
            float x1 = 0;
            float y1 = 0;
            float x2 = 0;
            float y2 = 0;
            float fDistance = 0;
            x1 = pt1.X / DefineConstantsFdxf.TRANSRATIO;
            y1 = pt1.Y / DefineConstantsFdxf.TRANSRATIO;
            x2 = pt2.X / DefineConstantsFdxf.TRANSRATIO;
            y2 = pt2.Y / DefineConstantsFdxf.TRANSRATIO;

            fDistance = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
            fDistance = (float)System.Math.Sqrt((double)(fDistance));
            fDistance *= DefineConstantsFdxf.TRANSRATIO;

            return fDistance;
        }
        public static PointF CalCenterPoint(PointF pt1, PointF pt2, PointF pt3)
        {
            PointF ptRet = new PointF(0, 0);
            float k1 = 0;
            float k2 = 0;
            float k_1 = 0;
            float k_2 = 0;
            float x_1 = 0;
            float y_1 = 0;
            float x_2 = 0;
            float y_2 = 0;
            float xret = 0;
            float yret = 0;

            x_1 = (pt1.X + pt2.X) / 2;
            y_1 = (pt1.Y + pt2.Y) / 2;
            x_2 = (pt2.X + pt3.X) / 2;
            y_2 = (pt2.Y + pt3.Y) / 2;

            if ((pt1.X == pt2.X) && (pt2.Y == pt3.Y))
            {
                xret = x_2;
                yret = y_1;
                ptRet.X = (xret);
                ptRet.Y = (yret);
                return ptRet;
            }
            else if ((pt1.Y == pt2.Y) & (pt2.X == pt3.X))
            {
                xret = x_1;
                yret = y_2;
                ptRet.X = (xret);
                ptRet.Y = (yret);
                return ptRet;
            }
            else if (pt1.X == pt2.X)
            {
                yret = y_1;

                k2 = (float)(pt3.Y - pt2.Y) / (float)(pt3.X - pt2.X);
                k_2 = -1 / k2;
                xret = (yret - y_2 + k_2 * x_2) / k_2;
                ptRet.X = (xret);
                ptRet.Y = (yret);
                return ptRet;
            }
            else if (pt1.Y == pt2.Y)
            {
                xret = x_1;

                k2 = (float)(pt3.Y - pt2.Y) / (float)(pt3.X - pt2.X);
                k_2 = -1 / k2;
                yret = k_2 * xret + y_2 - k_2 * x_2;
                ptRet.X = (xret);
                ptRet.Y = (yret);
                return ptRet;
            }
            else if (pt2.X == pt3.X)
            {
                yret = y_2;

                k1 = (float)(pt2.Y - pt1.Y) / (float)(pt2.X - pt1.X);
                k_1 = -1 / k1;
                xret = (yret - y_1 + k1 * x_1) / k1;
                ptRet.X = (xret);
                ptRet.Y = (yret);
                return ptRet;
            }
            else if (pt2.Y == pt3.Y)
            {
                xret = x_2;

                k1 = (float)(pt2.Y - pt1.Y) / (float)(pt2.X - pt1.X);
                k_1 = -1 / k1;
                yret = k_1 * xret + y_1 - k_1 * x_1;
                ptRet.X = (xret);
                ptRet.Y = (yret);
                return ptRet;
            }


            k1 = (float)(pt2.Y - pt1.Y) / (float)(pt2.X - pt1.X);
            k_1 = -1 / k1;
            k2 = (float)(pt3.Y - pt2.Y) / (float)(pt3.X - pt2.X);
            k_2 = -1 / k2;

            xret = (y_2 - y_1 - k_2 * x_2 + k_1 * x_1) / (k_1 - k_2);
            yret = k_1 * xret + y_1 - k_1 * x_1;

            ptRet.X = (xret);
            ptRet.Y = (yret);
            return ptRet;
        }
    }
    public class DefineConstantsFdxf
    {
        public const int _AFX = 1;
        public const int _MFC_VER = 0x0600;
        public const int STRICT = 1;
        public const int _WIN32_WINDOWS = 0x0500;
        public const int WM_MOUSELAST = 0x0209;
        public const string MSH_MOUSEWHEEL = "MSWHEEL_ROLLMSG";
        public const int WHEEL_DELTA = 120;
        public const string MOUSEZ_CLASSNAME = "MouseZ";
        public const string MOUSEZ_TITLE = "Magellan MSWHEEL";
        public const string MSH_WHEELSUPPORT = "MSH_WHEELSUPPORT_MSG";
        public const string MSH_SCROLL_LINES = "MSH_SCROLL_LINES_MSG";
        public const int SPI_SETWHEELSCROLLLINES = 105;
        public const int _WIN32_IE = 0x0400;
        public const int MAXPROPPAGES = 100;
        public const int PSP_DEFAULT = 0x00000000;
        public const int PSP_DLGINDIRECT = 0x00000001;
        public const int PSP_USEHICON = 0x00000002;
        public const int PSP_USEICONID = 0x00000004;
        public const int PSP_USETITLE = 0x00000008;
        public const int PSP_RTLREADING = 0x00000010;
        public const int PSP_HASHELP = 0x00000020;
        public const int PSP_USEREFPARENT = 0x00000040;
        public const int PSP_USECALLBACK = 0x00000080;
        public const int PSP_PREMATURE = 0x00000400;
        public const int PSP_HIDEHEADER = 0x00000800;
        public const int PSP_USEHEADERTITLE = 0x00001000;
        public const int PSP_USEHEADERSUBTITLE = 0x00002000;
        public const int PSPCB_RELEASE = 1;
        public const int PSPCB_CREATE = 2;
        public const int PSH_DEFAULT = 0x00000000;
        public const int PSH_PROPTITLE = 0x00000001;
        public const int PSH_USEHICON = 0x00000002;
        public const int PSH_USEICONID = 0x00000004;
        public const int PSH_PROPSHEETPAGE = 0x00000008;
        public const int PSH_WIZARDHASFINISH = 0x00000010;
        public const int PSH_WIZARD = 0x00000020;
        public const int PSH_USEPSTARTPAGE = 0x00000040;
        public const int PSH_NOAPPLYNOW = 0x00000080;
        public const int PSH_USECALLBACK = 0x00000100;
        public const int PSH_HASHELP = 0x00000200;
        public const int PSH_MODELESS = 0x00000400;
        public const int PSH_RTLREADING = 0x00000800;
        public const int PSH_WIZARDCONTEXTHELP = 0x00001000;
        public const int PSH_WIZARD97 = 0x00002000;
        public const int PSH_WATERMARK = 0x00008000;
        public const int PSH_USEHBMWATERMARK = 0x00010000;
        public const int PSH_USEHPLWATERMARK = 0x00020000;
        public const int PSH_STRETCHWATERMARK = 0x00040000;
        public const int PSH_HEADER = 0x00080000;
        public const int PSH_USEHBMHEADER = 0x00100000;
        public const int PSH_USEPAGELANG = 0x00200000;
        public const int PSCB_INITIALIZED = 1;
        public const int PSCB_PRECREATE = 2;
        public const int PSNRET_NOERROR = 0;
        public const int PSNRET_INVALID = 1;
        public const int PSNRET_INVALID_NOCHANGEPAGE = 2;
        public const int PSWIZB_BACK = 0x00000001;
        public const int PSWIZB_NEXT = 0x00000002;
        public const int PSWIZB_FINISH = 0x00000004;
        public const int PSWIZB_DISABLEDFINISH = 0x00000008;
        public const int PSBTN_BACK = 0;
        public const int PSBTN_NEXT = 1;
        public const int PSBTN_FINISH = 2;
        public const int PSBTN_OK = 3;
        public const int PSBTN_APPLYNOW = 4;
        public const int PSBTN_CANCEL = 5;
        public const int PSBTN_HELP = 6;
        public const int PSBTN_MAX = 6;
        public const int ID_PSRESTARTWINDOWS = 0x2;
        public const int WIZ_CXDLG = 276;
        public const int WIZ_CYDLG = 140;
        public const int WIZ_CXBMP = 80;
        public const int WIZ_BODYX = 92;
        public const int WIZ_BODYCX = 184;
        public const int PROP_SM_CXDLG = 212;
        public const int PROP_SM_CYDLG = 188;
        public const int PROP_MED_CXDLG = 227;
        public const int PROP_MED_CYDLG = 215;
        public const int PROP_LG_CXDLG = 252;
        public const int PROP_LG_CYDLG = 218;
        public const int ICC_LISTVIEW_CLASSES = 0x00000001;
        public const int ICC_TREEVIEW_CLASSES = 0x00000002;
        public const int ICC_BAR_CLASSES = 0x00000004;
        public const int ICC_TAB_CLASSES = 0x00000008;
        public const int ICC_UPDOWN_CLASS = 0x00000010;
        public const int ICC_PROGRESS_CLASS = 0x00000020;
        public const int ICC_HOTKEY_CLASS = 0x00000040;
        public const int ICC_ANIMATE_CLASS = 0x00000080;
        public const int ICC_WIN95_CLASSES = 0x000000FF;
        public const int ICC_DATE_CLASSES = 0x00000100;
        public const int ICC_USEREX_CLASSES = 0x00000200;
        public const int ICC_COOL_CLASSES = 0x00000400;
        public const int ICC_INTERNET_CLASSES = 0x00000800;
        public const int ICC_PAGESCROLLER_CLASS = 0x00001000;
        public const int ICC_NATIVEFNTCTL_CLASS = 0x00002000;
        public const int ODT_HEADER = 100;
        public const int ODT_TAB = 101;
        public const int ODT_LISTVIEW = 102;
        public const int LVM_FIRST = 0x1000;
        public const int TV_FIRST = 0x1100;
        public const int HDM_FIRST = 0x1200;
        public const int TCM_FIRST = 0x1300;
        public const int PGM_FIRST = 0x1400;
        public const int CCM_FIRST = 0x2000;
        public const int INFOTIPSIZE = 1024;
        public const int MSGF_COMMCTRL_BEGINDRAG = 0x4200;
        public const int MSGF_COMMCTRL_SIZEHEADER = 0x4201;
        public const int MSGF_COMMCTRL_DRAGSELECT = 0x4202;
        public const int MSGF_COMMCTRL_TOOLBARCUST = 0x4203;
        public const int CDRF_DODEFAULT = 0x00000000;
        public const int CDRF_NEWFONT = 0x00000002;
        public const int CDRF_SKIPDEFAULT = 0x00000004;
        public const int CDRF_NOTIFYPOSTPAINT = 0x00000010;
        public const int CDRF_NOTIFYITEMDRAW = 0x00000020;
        public const int CDRF_NOTIFYSUBITEMDRAW = 0x00000020;
        public const int CDRF_NOTIFYPOSTERASE = 0x00000040;
        public const int CDDS_PREPAINT = 0x00000001;
        public const int CDDS_POSTPAINT = 0x00000002;
        public const int CDDS_PREERASE = 0x00000003;
        public const int CDDS_POSTERASE = 0x00000004;
        public const int CDDS_ITEM = 0x00010000;
        public const int CDDS_SUBITEM = 0x00020000;
        public const int CDIS_SELECTED = 0x0001;
        public const int CDIS_GRAYED = 0x0002;
        public const int CDIS_DISABLED = 0x0004;
        public const int CDIS_CHECKED = 0x0008;
        public const int CDIS_FOCUS = 0x0010;
        public const int CDIS_DEFAULT = 0x0020;
        public const int CDIS_HOT = 0x0040;
        public const int CDIS_MARKED = 0x0080;
        public const int CDIS_INDETERMINATE = 0x0100;
        public const long CLR_NONE = 0xFFFFFFFFL;
        public const long CLR_DEFAULT = 0xFF000000L;
        public const int ILC_MASK = 0x0001;
        public const int ILC_COLOR = 0x0000;
        public const int ILC_COLORDDB = 0x00FE;
        public const int ILC_COLOR4 = 0x0004;
        public const int ILC_COLOR8 = 0x0008;
        public const int ILC_COLOR16 = 0x0010;
        public const int ILC_COLOR24 = 0x0018;
        public const int ILC_COLOR32 = 0x0020;
        public const int ILC_PALETTE = 0x0800;
        public const int ILD_NORMAL = 0x0000;
        public const int ILD_TRANSPARENT = 0x0001;
        public const int ILD_MASK = 0x0010;
        public const int ILD_IMAGE = 0x0020;
        public const int ILD_ROP = 0x0040;
        public const int ILD_BLEND25 = 0x0002;
        public const int ILD_BLEND50 = 0x0004;
        public const int ILD_OVERLAYMASK = 0x0F00;
        public const int ILCF_MOVE = 0x00000000;
        public const int ILCF_SWAP = 0x00000001;
        public const string WC_HEADERA = "SysHeader32";
        public const string WC_HEADER = "SysHeader";
        public const int HDS_HORZ = 0x0000;
        public const int HDS_BUTTONS = 0x0002;
        public const int HDS_HOTTRACK = 0x0004;
        public const int HDS_HIDDEN = 0x0008;
        public const int HDS_DRAGDROP = 0x0040;
        public const int HDS_FULLDRAG = 0x0080;
        public const int HDI_WIDTH = 0x0001;
        public const int HDI_TEXT = 0x0002;
        public const int HDI_FORMAT = 0x0004;
        public const int HDI_LPARAM = 0x0008;
        public const int HDI_BITMAP = 0x0010;
        public const int HDI_IMAGE = 0x0020;
        public const int HDI_DI_SETITEM = 0x0040;
        public const int HDI_ORDER = 0x0080;
        public const int HDF_LEFT = 0;
        public const int HDF_RIGHT = 1;
        public const int HDF_CENTER = 2;
        public const int HDF_JUSTIFYMASK = 0x0003;
        public const int HDF_RTLREADING = 4;
        public const int HDF_OWNERDRAW = 0x8000;
        public const int HDF_STRING = 0x4000;
        public const int HDF_BITMAP = 0x2000;
        public const int HDF_BITMAP_ON_RIGHT = 0x1000;
        public const int HDF_IMAGE = 0x0800;
        public const int HHT_NOWHERE = 0x0001;
        public const int HHT_ONHEADER = 0x0002;
        public const int HHT_ONDIVIDER = 0x0004;
        public const int HHT_ONDIVOPEN = 0x0008;
        public const int HHT_ABOVE = 0x0100;
        public const int HHT_BELOW = 0x0200;
        public const int HHT_TORIGHT = 0x0400;
        public const int HHT_TOLEFT = 0x0800;
        public const string TOOLBARCLASSNAMEA = "ToolbarWindow32";
        public const string TOOLBARCLASSNAME = "ToolbarWindow";
        public const int CMB_MASKED = 0x02;
        public const int TBSTATE_CHECKED = 0x01;
        public const int TBSTATE_PRESSED = 0x02;
        public const int TBSTATE_ENABLED = 0x04;
        public const int TBSTATE_HIDDEN = 0x08;
        public const int TBSTATE_INDETERMINATE = 0x10;
        public const int TBSTATE_WRAP = 0x20;
        public const int TBSTATE_ELLIPSES = 0x40;
        public const int TBSTATE_MARKED = 0x80;
        public const int TBSTYLE_BUTTON = 0x0000;
        public const int TBSTYLE_SEP = 0x0001;
        public const int TBSTYLE_CHECK = 0x0002;
        public const int TBSTYLE_GROUP = 0x0004;
        public const int TBSTYLE_DROPDOWN = 0x0008;
        public const int TBSTYLE_AUTOSIZE = 0x0010;
        public const int TBSTYLE_NOPREFIX = 0x0020;
        public const int TBSTYLE_TOOLTIPS = 0x0100;
        public const int TBSTYLE_WRAPABLE = 0x0200;
        public const int TBSTYLE_ALTDRAG = 0x0400;
        public const int TBSTYLE_FLAT = 0x0800;
        public const int TBSTYLE_LIST = 0x1000;
        public const int TBSTYLE_CUSTOMERASE = 0x2000;
        public const int TBSTYLE_REGISTERDROP = 0x4000;
        public const int TBSTYLE_TRANSPARENT = 0x8000;
        public const int TBSTYLE_EX_DRAWDDARROWS = 0x00000001;
        public const int TBCDRF_NOEDGES = 0x00010000;
        public const int TBCDRF_HILITEHOTTRACK = 0x00020000;
        public const int TBCDRF_NOOFFSET = 0x00040000;
        public const int TBCDRF_NOMARK = 0x00080000;
        public const int TBCDRF_NOETCHEDEFFECT = 0x00100000;
        public const int IDB_STD_SMALL_COLOR = 0;
        public const int IDB_STD_LARGE_COLOR = 1;
        public const int IDB_VIEW_SMALL_COLOR = 4;
        public const int IDB_VIEW_LARGE_COLOR = 5;
        public const int IDB_HIST_SMALL_COLOR = 8;
        public const int IDB_HIST_LARGE_COLOR = 9;
        public const int STD_CUT = 0;
        public const int STD_COPY = 1;
        public const int STD_PASTE = 2;
        public const int STD_UNDO = 3;
        public const int STD_REDOW = 4;
        public const int STD_DELETE = 5;
        public const int STD_FILENEW = 6;
        public const int STD_FILEOPEN = 7;
        public const int STD_FILESAVE = 8;
        public const int STD_PRINTPRE = 9;
        public const int STD_PROPERTIES = 10;
        public const int STD_HELP = 11;
        public const int STD_FIND = 12;
        public const int STD_REPLACE = 13;
        public const int STD_PRINT = 14;
        public const int VIEW_LARGEICONS = 0;
        public const int VIEW_SMALLICONS = 1;
        public const int VIEW_LIST = 2;
        public const int VIEW_DETAILS = 3;
        public const int VIEW_SORTNAME = 4;
        public const int VIEW_SORTSIZE = 5;
        public const int VIEW_SORTDATE = 6;
        public const int VIEW_SORTTYPE = 7;
        public const int VIEW_PARENTFOLDER = 8;
        public const int VIEW_NETCONNECT = 9;
        public const int VIEW_NETDISCONNECT = 10;
        public const int VIEW_NEWFOLDER = 11;
        public const int VIEW_VIEWMENU = 12;
        public const int HIST_BACK = 0;
        public const int HIST_FORWARD = 1;
        public const int HIST_FAVORITES = 2;
        public const int HIST_ADDTOFAVORITES = 3;
        public const int HIST_VIEWTREE = 4;
        public const int TBIMHT_AFTER = 0x00000001;
        public const int TBIMHT_BACKGROUND = 0x00000002;
        public const int TBBF_LARGE = 0x0001;
        public const int TBIF_IMAGE = 0x00000001;
        public const int TBIF_TEXT = 0x00000002;
        public const int TBIF_STATE = 0x00000004;
        public const int TBIF_STYLE = 0x00000008;
        public const int TBIF_LPARAM = 0x00000010;
        public const int TBIF_COMMAND = 0x00000020;
        public const int TBIF_SIZE = 0x00000040;
        public const int HICF_OTHER = 0x00000000;
        public const int HICF_MOUSE = 0x00000001;
        public const int HICF_ARROWKEYS = 0x00000002;
        public const int HICF_ACCELERATOR = 0x00000004;
        public const int HICF_DUPACCEL = 0x00000008;
        public const int HICF_ENTERING = 0x00000010;
        public const int HICF_LEAVING = 0x00000020;
        public const int HICF_RESELECT = 0x00000040;
        public const int TBNF_IMAGE = 0x00000001;
        public const int TBNF_TEXT = 0x00000002;
        public const int TBNF_DI_SETITEM = 0x10000000;
        public const int TBDDRET_DEFAULT = 0;
        public const int TBDDRET_NODEFAULT = 1;
        public const int TBDDRET_TREATPRESSED = 2;
        public const string REBARCLASSNAMEA = "ReBarWindow32";
        public const string REBARCLASSNAME = "ReBarWindow";
        public const int RBIM_IMAGELIST = 0x00000001;
#if RBS_TOOLTIPS_AlternateDefinition1
	public const int RBS_TOOLTIPS = 0x0100;
#elif RBS_TOOLTIPS_AlternateDefinition2
	public const int RBS_TOOLTIPS = 0x00000100;
#endif
#if RBS_VARHEIGHT_AlternateDefinition1
	public const int RBS_VARHEIGHT = 0x0200;
#elif RBS_VARHEIGHT_AlternateDefinition2
	public const int RBS_VARHEIGHT = 0x00000200;
#endif
#if RBS_BANDBORDERS_AlternateDefinition1
	public const int RBS_BANDBORDERS = 0x0400;
#elif RBS_BANDBORDERS_AlternateDefinition2
	public const int RBS_BANDBORDERS = 0x00000400;
#endif
#if RBS_FIXEDORDER_AlternateDefinition1
	public const int RBS_FIXEDORDER = 0x0800;
#elif RBS_FIXEDORDER_AlternateDefinition2
	public const int RBS_FIXEDORDER = 0x00000800;
#endif
        public const int RBS_REGISTERDROP = 0x1000;
        public const int RBS_AUTOSIZE = 0x2000;
        public const int RBS_VERTICALGRIPPER = 0x4000;
        public const int RBS_DBLCLKTOGGLE = 0x8000;
        public const int RBBS_BREAK = 0x00000001;
        public const int RBBS_FIXEDSIZE = 0x00000002;
        public const int RBBS_CHILDEDGE = 0x00000004;
        public const int RBBS_HIDDEN = 0x00000008;
        public const int RBBS_NOVERT = 0x00000010;
        public const int RBBS_FIXEDBMP = 0x00000020;
        public const int RBBS_VARIABLEHEIGHT = 0x00000040;
        public const int RBBS_GRIPPERALWAYS = 0x00000080;
        public const int RBBS_NOGRIPPER = 0x00000100;
        public const int RBBIM_STYLE = 0x00000001;
        public const int RBBIM_COLORS = 0x00000002;
        public const int RBBIM_TEXT = 0x00000004;
        public const int RBBIM_IMAGE = 0x00000008;
        public const int RBBIM_CHILD = 0x00000010;
        public const int RBBIM_CHILDSIZE = 0x00000020;
        public const int RBBIM_SIZE = 0x00000040;
        public const int RBBIM_BACKGROUND = 0x00000080;
        public const int RBBIM_ID = 0x00000100;
        public const int RBBIM_IDEALSIZE = 0x00000200;
        public const int RBBIM_LPARAM = 0x00000400;
        public const int RBBIM_HEADERSIZE = 0x00000800;
        public const int RBNM_ID = 0x00000001;
        public const int RBNM_STYLE = 0x00000002;
        public const int RBNM_LPARAM = 0x00000004;
        public const int RBHT_NOWHERE = 0x0001;
        public const int RBHT_CAPTION = 0x0002;
        public const int RBHT_CLIENT = 0x0003;
        public const int RBHT_GRABBER = 0x0004;
        public const string TOOLTIPS_CLASSA = "tooltips_class32";
        public const string TOOLTIPS_CLASS = "tooltips_class";
        public const int TTS_ALWAYSTIP = 0x01;
        public const int TTS_NOPREFIX = 0x02;
        public const int TTF_IDISHWND = 0x0001;
        public const int TTF_CENTERTIP = 0x0002;
        public const int TTF_RTLREADING = 0x0004;
        public const int TTF_SUBCLASS = 0x0010;
        public const int TTF_TRACK = 0x0020;
        public const int TTF_ABSOLUTE = 0x0080;
        public const int TTF_TRANSPARENT = 0x0100;
        public const int TTF_DI_SETITEM = 0x8000;
        public const int TTDT_AUTOMATIC = 0;
        public const int TTDT_RESHOW = 1;
        public const int TTDT_AUTOPOP = 2;
        public const int TTDT_INITIAL = 3;
        public const int SBARS_SIZEGRIP = 0x0100;
        public const string STATUSCLASSNAMEA = "msctls_statusbar32";
        public const string STATUSCLASSNAME = "msctls_statusbar";
        public const int SBT_OWNERDRAW = 0x1000;
        public const int SBT_NOBORDERS = 0x0100;
        public const int SBT_POPOUT = 0x0200;
        public const int SBT_RTLREADING = 0x0400;
        public const int SBT_TOOLTIPS = 0x0800;
        public const string TRACKBAR_CLASSA = "msctls_trackbar32";
        public const string TRACKBAR_CLASS = "msctls_trackbar";
        public const int TBS_AUTOTICKS = 0x0001;
        public const int TBS_VERT = 0x0002;
        public const int TBS_HORZ = 0x0000;
        public const int TBS_TOP = 0x0004;
        public const int TBS_BOTTOM = 0x0000;
        public const int TBS_LEFT = 0x0004;
        public const int TBS_RIGHT = 0x0000;
        public const int TBS_BOTH = 0x0008;
        public const int TBS_NOTICKS = 0x0010;
        public const int TBS_ENABLESELRANGE = 0x0020;
        public const int TBS_FIXEDLENGTH = 0x0040;
        public const int TBS_NOTHUMB = 0x0080;
        public const int TBS_TOOLTIPS = 0x0100;
        public const int TBTS_TOP = 0;
        public const int TBTS_LEFT = 1;
        public const int TBTS_BOTTOM = 2;
        public const int TBTS_RIGHT = 3;
        public const int TB_LINEUP = 0;
        public const int TB_LINEDOWN = 1;
        public const int TB_PAGEUP = 2;
        public const int TB_PAGEDOWN = 3;
        public const int TB_THUMBPOSITION = 4;
        public const int TB_THUMBTRACK = 5;
        public const int TB_TOP = 6;
        public const int TB_BOTTOM = 7;
        public const int TB_ENDTRACK = 8;
        public const int TBCD_TICS = 0x0001;
        public const int TBCD_THUMB = 0x0002;
        public const int TBCD_CHANNEL = 0x0003;
        public const int DL_CURSORSET = 0;
        public const int DL_STOPCURSOR = 1;
        public const int DL_COPYCURSOR = 2;
        public const int DL_MOVECURSOR = 3;
        public const string UPDOWN_CLASSA = "msctls_updown32";
        public const string UPDOWN_CLASS = "msctls_updown";
        public const int UD_MAXVAL = 0x7fff;
        public const int UDS_WRAP = 0x0001;
        public const int UDS_SETBUDDYINT = 0x0002;
        public const int UDS_ALIGNRIGHT = 0x0004;
        public const int UDS_ALIGNLEFT = 0x0008;
        public const int UDS_AUTOBUDDY = 0x0010;
        public const int UDS_ARROWKEYS = 0x0020;
        public const int UDS_HORZ = 0x0040;
        public const int UDS_NOTHOUSANDS = 0x0080;
        public const int UDS_HOTTRACK = 0x0100;
        public const string PROGRESS_CLASSA = "msctls_progress32";
        public const string PROGRESS_CLASS = "msctls_progress";
        public const int PBS_SMOOTH = 0x01;
        public const int PBS_VERTICAL = 0x04;
        public const int HOTKEYF_SHIFT = 0x01;
        public const int HOTKEYF_CONTROL = 0x02;
        public const int HOTKEYF_ALT = 0x04;
#if HOTKEYF_EXT_AlternateDefinition1
	public const int HOTKEYF_EXT = 0x80;
#elif HOTKEYF_EXT_AlternateDefinition2
	public const int HOTKEYF_EXT = 0x08;
#endif
        public const int HKCOMB_NONE = 0x0001;
        public const int HKCOMB_S = 0x0002;
        public const int HKCOMB_C = 0x0004;
        public const int HKCOMB_A = 0x0008;
        public const int HKCOMB_SC = 0x0010;
        public const int HKCOMB_SA = 0x0020;
        public const int HKCOMB_CA = 0x0040;
        public const int HKCOMB_SCA = 0x0080;
        public const string HOTKEY_CLASSA = "msctls_hotkey32";
        public const string HOTKEY_CLASS = "msctls_hotkey";
        public const long CCS_TOP = 0x00000001L;
        public const long CCS_NOMOVEY = 0x00000002L;
        public const long CCS_BOTTOM = 0x00000003L;
        public const long CCS_NORESIZE = 0x00000004L;
        public const long CCS_NOPARENTALIGN = 0x00000008L;
        public const long CCS_ADJUSTABLE = 0x00000020L;
        public const long CCS_NODIVIDER = 0x00000040L;
        public const long CCS_VERT = 0x00000080L;
        public const string WC_LISTVIEWA = "SysListView32";
        public const string WC_LISTVIEW = "SysListView";
        public const int LVS_ICON = 0x0000;
        public const int LVS_REPORT = 0x0001;
        public const int LVS_SMALLICON = 0x0002;
        public const int LVS_LIST = 0x0003;
        public const int LVS_TYPEMASK = 0x0003;
        public const int LVS_SINGLESEL = 0x0004;
        public const int LVS_SHOWSELALWAYS = 0x0008;
        public const int LVS_SORTASCENDING = 0x0010;
        public const int LVS_SORTDESCENDING = 0x0020;
        public const int LVS_SHAREIMAGELISTS = 0x0040;
        public const int LVS_NOLABELWRAP = 0x0080;
        public const int LVS_AUTOARRANGE = 0x0100;
        public const int LVS_EDITLABELS = 0x0200;
        public const int LVS_OWNERDATA = 0x1000;
        public const int LVS_NOSCROLL = 0x2000;
        public const int LVS_TYPESTYLEMASK = 0xfc00;
        public const int LVS_ALIGNTOP = 0x0000;
        public const int LVS_ALIGNLEFT = 0x0800;
        public const int LVS_ALIGNMASK = 0x0c00;
        public const int LVS_OWNERDRAWFIXED = 0x0400;
        public const int LVS_NOCOLUMNHEADER = 0x4000;
        public const int LVS_NOSORTHEADER = 0x8000;
        public const int LVSIL_NORMAL = 0;
        public const int LVSIL_SMALL = 1;
        public const int LVSIL_STATE = 2;
        public const int LVIF_TEXT = 0x0001;
        public const int LVIF_IMAGE = 0x0002;
        public const int LVIF_PARAM = 0x0004;
        public const int LVIF_STATE = 0x0008;
        public const int LVIF_INDENT = 0x0010;
        public const int LVIF_NORECOMPUTE = 0x0800;
        public const int LVIS_FOCUSED = 0x0001;
        public const int LVIS_SELECTED = 0x0002;
        public const int LVIS_CUT = 0x0004;
        public const int LVIS_DROPHILITED = 0x0008;
        public const int LVIS_ACTIVATING = 0x0020;
        public const int LVIS_OVERLAYMASK = 0x0F00;
        public const int LVIS_STATEIMAGEMASK = 0xF000;
        public const int LVNI_ALL = 0x0000;
        public const int LVNI_FOCUSED = 0x0001;
        public const int LVNI_SELECTED = 0x0002;
        public const int LVNI_CUT = 0x0004;
        public const int LVNI_DROPHILITED = 0x0008;
        public const int LVNI_ABOVE = 0x0100;
        public const int LVNI_BELOW = 0x0200;
        public const int LVNI_TOLEFT = 0x0400;
        public const int LVNI_TORIGHT = 0x0800;
        public const int LVFI_PARAM = 0x0001;
        public const int LVFI_STRING = 0x0002;
        public const int LVFI_PARTIAL = 0x0008;
        public const int LVFI_WRAP = 0x0020;
        public const int LVFI_NEARESTXY = 0x0040;
        public const int LVIR_BOUNDS = 0;
        public const int LVIR_ICON = 1;
        public const int LVIR_LABEL = 2;
        public const int LVIR_SELECTBOUNDS = 3;
        public const int LVHT_NOWHERE = 0x0001;
        public const int LVHT_ONITEMICON = 0x0002;
        public const int LVHT_ONITEMLABEL = 0x0004;
        public const int LVHT_ONITEMSTATEICON = 0x0008;
        public const int LVHT_ABOVE = 0x0008;
        public const int LVHT_BELOW = 0x0010;
        public const int LVHT_TORIGHT = 0x0020;
        public const int LVHT_TOLEFT = 0x0040;
        public const int LVA_DEFAULT = 0x0000;
        public const int LVA_ALIGNLEFT = 0x0001;
        public const int LVA_ALIGNTOP = 0x0002;
        public const int LVA_SNAPTOGRID = 0x0005;
        public const int LVCF_FMT = 0x0001;
        public const int LVCF_WIDTH = 0x0002;
        public const int LVCF_TEXT = 0x0004;
        public const int LVCF_SUBITEM = 0x0008;
        public const int LVCF_IMAGE = 0x0010;
        public const int LVCF_ORDER = 0x0020;
        public const int LVCFMT_LEFT = 0x0000;
        public const int LVCFMT_RIGHT = 0x0001;
        public const int LVCFMT_CENTER = 0x0002;
        public const int LVCFMT_JUSTIFYMASK = 0x0003;
        public const int LVCFMT_IMAGE = 0x0800;
        public const int LVCFMT_BITMAP_ON_RIGHT = 0x1000;
        public const int LVCFMT_COL_HAS_IMAGES = 0x8000;
        public const int LVSICF_NOINVALIDATEALL = 0x00000001;
        public const int LVSICF_NOSCROLL = 0x00000002;
        public const int LVS_EX_GRIDLINES = 0x00000001;
        public const int LVS_EX_SUBITEMIMAGES = 0x00000002;
        public const int LVS_EX_CHECKBOXES = 0x00000004;
        public const int LVS_EX_TRACKSELECT = 0x00000008;
        public const int LVS_EX_HEADERDRAGDROP = 0x00000010;
        public const int LVS_EX_FULLROWSELECT = 0x00000020;
        public const int LVS_EX_ONECLICKACTIVATE = 0x00000040;
        public const int LVS_EX_TWOCLICKACTIVATE = 0x00000080;
        public const int LVS_EX_FLATSB = 0x00000100;
        public const int LVS_EX_REGIONAL = 0x00000200;
        public const int LVS_EX_INFOTIP = 0x00000400;
        public const int LVS_EX_UNDERLINEHOT = 0x00000800;
        public const int LVS_EX_UNDERLINECOLD = 0x00001000;
        public const int LVS_EX_MULTIWORKAREAS = 0x00002000;
        public const int LV_MAX_WORKAREAS = 16;
        public const int LVBKIF_SOURCE_NONE = 0x00000000;
        public const int LVBKIF_SOURCE_HBITMAP = 0x00000001;
        public const int LVBKIF_SOURCE_URL = 0x00000002;
        public const int LVBKIF_SOURCE_MASK = 0x00000003;
        public const int LVBKIF_STYLE_NORMAL = 0x00000000;
        public const int LVBKIF_STYLE_TILE = 0x00000010;
        public const int LVBKIF_STYLE_MASK = 0x00000010;
        public const int LVKF_ALT = 0x0001;
        public const int LVKF_CONTROL = 0x0002;
        public const int LVKF_SHIFT = 0x0004;
        public const int LVIF_DI_SETITEM = 0x1000;
        public const int LVGIT_UNFOLDED = 0x0001;
        public const string WC_TREEVIEWA = "SysTreeView32";
        public const string WC_TREEVIEW = "SysTreeView";
        public const int TVS_HASBUTTONS = 0x0001;
        public const int TVS_HASLINES = 0x0002;
        public const int TVS_LINESATROOT = 0x0004;
        public const int TVS_EDITLABELS = 0x0008;
        public const int TVS_DISABLEDRAGDROP = 0x0010;
        public const int TVS_SHOWSELALWAYS = 0x0020;
        public const int TVS_RTLREADING = 0x0040;
        public const int TVS_NOTOOLTIPS = 0x0080;
        public const int TVS_CHECKBOXES = 0x0100;
        public const int TVS_TRACKSELECT = 0x0200;
        public const int TVS_SINGLEEXPAND = 0x0400;
        public const int TVS_INFOTIP = 0x0800;
        public const int TVS_FULLROWSELECT = 0x1000;
        public const int TVS_NOSCROLL = 0x2000;
        public const int TVS_NONEVENHEIGHT = 0x4000;
        public const int TVIF_TEXT = 0x0001;
        public const int TVIF_IMAGE = 0x0002;
        public const int TVIF_PARAM = 0x0004;
        public const int TVIF_STATE = 0x0008;
        public const int TVIF_HANDLE = 0x0010;
        public const int TVIF_SELECTEDIMAGE = 0x0020;
        public const int TVIF_CHILDREN = 0x0040;
        public const int TVIF_INTEGRAL = 0x0080;
        public const int TVIS_SELECTED = 0x0002;
        public const int TVIS_CUT = 0x0004;
        public const int TVIS_DROPHILITED = 0x0008;
        public const int TVIS_BOLD = 0x0010;
        public const int TVIS_EXPANDED = 0x0020;
        public const int TVIS_EXPANDEDONCE = 0x0040;
        public const int TVIS_EXPANDPARTIAL = 0x0080;
        public const int TVIS_OVERLAYMASK = 0x0F00;
        public const int TVIS_STATEIMAGEMASK = 0xF000;
        public const int TVIS_USERMASK = 0xF000;
        public const int TVE_COLLAPSE = 0x0001;
        public const int TVE_EXPAND = 0x0002;
        public const int TVE_TOGGLE = 0x0003;
        public const int TVE_EXPANDPARTIAL = 0x4000;
        public const int TVE_COLLAPSERESET = 0x8000;
        public const int TVSIL_NORMAL = 0;
        public const int TVSIL_STATE = 2;
        public const int TVGN_ROOT = 0x0000;
        public const int TVGN_NEXT = 0x0001;
        public const int TVGN_PREVIOUS = 0x0002;
        public const int TVGN_PARENT = 0x0003;
        public const int TVGN_CHILD = 0x0004;
        public const int TVGN_FIRSTVISIBLE = 0x0005;
        public const int TVGN_NEXTVISIBLE = 0x0006;
        public const int TVGN_PREVIOUSVISIBLE = 0x0007;
        public const int TVGN_DROPHILITE = 0x0008;
        public const int TVGN_CARET = 0x0009;
        public const int TVGN_LASTVISIBLE = 0x000A;
        public const int TVHT_NOWHERE = 0x0001;
        public const int TVHT_ONITEMICON = 0x0002;
        public const int TVHT_ONITEMLABEL = 0x0004;
        public const int TVHT_ONITEMINDENT = 0x0008;
        public const int TVHT_ONITEMBUTTON = 0x0010;
        public const int TVHT_ONITEMRIGHT = 0x0020;
        public const int TVHT_ONITEMSTATEICON = 0x0040;
        public const int TVHT_ABOVE = 0x0100;
        public const int TVHT_BELOW = 0x0200;
        public const int TVHT_TORIGHT = 0x0400;
        public const int TVHT_TOLEFT = 0x0800;
        public const int TVC_UNKNOWN = 0x0000;
        public const int TVC_BYMOUSE = 0x0001;
        public const int TVC_BYKEYBOARD = 0x0002;
        public const int TVIF_DI_SETITEM = 0x1000;
        public const int TVCDRF_NOIMAGES = 0x00010000;
        public const string WC_COMBOBOXEXA = "ComboBoxEx32";
        public const int CBEIF_TEXT = 0x00000001;
        public const int CBEIF_IMAGE = 0x00000002;
        public const int CBEIF_SELECTEDIMAGE = 0x00000004;
        public const int CBEIF_OVERLAY = 0x00000008;
        public const int CBEIF_INDENT = 0x00000010;
        public const int CBEIF_LPARAM = 0x00000020;
        public const int CBEIF_DI_SETITEM = 0x10000000;
        public const int CBES_EX_NOEDITIMAGE = 0x00000001;
        public const int CBES_EX_NOEDITIMAGEINDENT = 0x00000002;
        public const int CBES_EX_PATHWORDBREAKPROC = 0x00000004;
        public const int CBES_EX_NOSIZELIMIT = 0x00000008;
        public const int CBES_EX_CASESENSITIVE = 0x00000010;
        public const int CBENF_KILLFOCUS = 1;
        public const int CBENF_RETURN = 2;
        public const int CBENF_ESCAPE = 3;
        public const int CBENF_DROPDOWN = 4;
        public const int CBEMAXSTRLEN = 260;
        public const string WC_TABCONTROLA = "SysTabControl32";
        public const string WC_TABCONTROL = "SysTabControl";
        public const int TCS_SCROLLOPPOSITE = 0x0001;
        public const int TCS_BOTTOM = 0x0002;
        public const int TCS_RIGHT = 0x0002;
        public const int TCS_MULTISELECT = 0x0004;
        public const int TCS_FLATBUTTONS = 0x0008;
        public const int TCS_FORCEICONLEFT = 0x0010;
        public const int TCS_FORCELABELLEFT = 0x0020;
        public const int TCS_HOTTRACK = 0x0040;
        public const int TCS_VERTICAL = 0x0080;
        public const int TCS_TABS = 0x0000;
        public const int TCS_BUTTONS = 0x0100;
        public const int TCS_SINGLELINE = 0x0000;
        public const int TCS_MULTILINE = 0x0200;
        public const int TCS_RIGHTJUSTIFY = 0x0000;
        public const int TCS_FIXEDWIDTH = 0x0400;
        public const int TCS_RAGGEDRIGHT = 0x0800;
        public const int TCS_FOCUSONBUTTONDOWN = 0x1000;
        public const int TCS_OWNERDRAWFIXED = 0x2000;
        public const int TCS_TOOLTIPS = 0x4000;
        public const int TCS_FOCUSNEVER = 0x8000;
        public const int TCS_EX_FLATSEPARATORS = 0x00000001;
        public const int TCS_EX_REGISTERDROP = 0x00000002;
        public const int TCIF_TEXT = 0x0001;
        public const int TCIF_IMAGE = 0x0002;
        public const int TCIF_RTLREADING = 0x0004;
        public const int TCIF_PARAM = 0x0008;
        public const int TCIF_STATE = 0x0010;
        public const int TCIS_BUTTONPRESSED = 0x0001;
        public const int TCIS_HIGHLIGHTED = 0x0002;
        public const int TCHT_NOWHERE = 0x0001;
        public const int TCHT_ONITEMICON = 0x0002;
        public const int TCHT_ONITEMLABEL = 0x0004;
        public const string ANIMATE_CLASSA = "SysAnimate32";
        public const int ACS_CENTER = 0x0001;
        public const int ACS_TRANSPARENT = 0x0002;
        public const int ACS_AUTOPLAY = 0x0004;
        public const int ACS_TIMER = 0x0008;
        public const int ACN_START = 1;
        public const int ACN_STOP = 2;
        public const string MONTHCAL_CLASSA = "SysMonthCal32";
        public const int MCM_FIRST = 0x1000;
        public const int MCSC_BACKGROUND = 0;
        public const int MCSC_TEXT = 1;
        public const int MCSC_TITLEBK = 2;
        public const int MCSC_TITLETEXT = 3;
        public const int MCSC_MONTHBK = 4;
        public const int MCSC_TRAILINGTEXT = 5;
        public const int MCHT_TITLE = 0x00010000;
        public const int MCHT_CALENDAR = 0x00020000;
        public const int MCHT_TODAYLINK = 0x00030000;
        public const int MCHT_NEXT = 0x01000000;
        public const int MCHT_PREV = 0x02000000;
        public const int MCHT_NOWHERE = 0x00000000;
        public const int MCS_DAYSTATE = 0x0001;
        public const int MCS_MULTISELECT = 0x0002;
        public const int MCS_WEEKNUMBERS = 0x0004;
        public const int MCS_NOTODAYCIRCLE = 0x0008;
#if MCS_NOTODAY_AlternateDefinition1
	public const int MCS_NOTODAY = 0x0010;
#elif MCS_NOTODAY_AlternateDefinition2
	public const int MCS_NOTODAY = 0x0008;
#endif
        public const int GMR_VISIBLE = 0;
        public const int GMR_DAYSTATE = 1;
        public const string DATETIMEPICK_CLASSA = "SysDateTimePick32";
        public const int DTM_FIRST = 0x1000;
        public const int DTS_UPDOWN = 0x0001;
        public const int DTS_SHOWNONE = 0x0002;
        public const int DTS_SHORTDATEFORMAT = 0x0000;
        public const int DTS_LONGDATEFORMAT = 0x0004;
        public const int DTS_TIMEFORMAT = 0x0009;
        public const int DTS_APPCANPARSE = 0x0010;
        public const int DTS_RIGHTALIGN = 0x0020;
        public const int GDTR_MIN = 0x0001;
        public const int GDTR_MAX = 0x0002;
        public const int GDT_VALID = 0;
        public const int GDT_NONE = 1;
        public const string WC_IPADDRESSA = "SysIPAddress32";
        public const string WC_PAGESCROLLERA = "SysPager";
        public const int PGS_VERT = 0x00000000;
        public const int PGS_HORZ = 0x00000001;
        public const int PGS_AUTOSCROLL = 0x00000002;
        public const int PGS_DRAGNDROP = 0x00000004;
        public const int PGF_INVISIBLE = 0;
        public const int PGF_NORMAL = 1;
        public const int PGF_GRAYED = 2;
        public const int PGF_DEPRESSED = 4;
        public const int PGF_HOT = 8;
        public const int PGB_TOPORLEFT = 0;
        public const int PGB_BOTTOMORRIGHT = 1;
        public const int PGF_SCROLLUP = 1;
        public const int PGF_SCROLLDOWN = 2;
        public const int PGF_SCROLLLEFT = 4;
        public const int PGF_SCROLLRIGHT = 8;
        public const int PGK_SHIFT = 1;
        public const int PGK_CONTROL = 2;
        public const int PGK_MENU = 4;
        public const int PGF_CALCWIDTH = 1;
        public const int PGF_CALCHEIGHT = 2;
        public const string WC_NATIVEFONTCTLA = "NativeFontCtl";
        public const int NFS_EDIT = 0x0001;
        public const int NFS_STATIC = 0x0002;
        public const int NFS_LISTCOMBO = 0x0004;
        public const int NFS_BUTTON = 0x0008;
        public const int NFS_ALL = 0x0010;
        public const int WM_MOUSEHOVER = 0x02A1;
        public const int WM_MOUSELEAVE = 0x02A3;
        public const int TME_HOVER = 0x00000001;
        public const int TME_LEAVE = 0x00000002;
        public const int TME_QUERY = 0x40000000;
        public const long TME_CANCEL = 0x80000000;
        public const long HOVER_DEFAULT = 0xFFFFFFFF;
        public const long WSB_PROP_CYVSCROLL = 0x00000001L;
        public const long WSB_PROP_CXHSCROLL = 0x00000002L;
        public const long WSB_PROP_CYHSCROLL = 0x00000004L;
        public const long WSB_PROP_CXVSCROLL = 0x00000008L;
        public const long WSB_PROP_CXHTHUMB = 0x00000010L;
        public const long WSB_PROP_CYVTHUMB = 0x00000020L;
        public const long WSB_PROP_VBKGCOLOR = 0x00000040L;
        public const long WSB_PROP_HBKGCOLOR = 0x00000080L;
        public const long WSB_PROP_VSTYLE = 0x00000100L;
        public const long WSB_PROP_HSTYLE = 0x00000200L;
        public const long WSB_PROP_WINSTYLE = 0x00000400L;
        public const long WSB_PROP_PALETTE = 0x00000800L;
        public const long WSB_PROP_MASK = 0x00000FFFL;
        public const int FSB_FLAT_MODE = 2;
        public const int FSB_ENCARTA_MODE = 1;
        public const int FSB_REGULAR_MODE = 0;
        public const int _MS = 0x01;
        public const int _MP = 0x02;
        public const int _M1 = 0x04;
        public const int _M2 = 0x08;
        public const int _SBUP = 0x10;
        public const int _SBLOW = 0x20;
        public const int _MBC_SINGLE = 0;
        public const int _MBC_LEAD = 1;
        public const int _MBC_TRAIL = 2;
        public const int _KANJI_CP = 932;
        public const int _MB_CP_SBCS = 0;
        public const int _NLSCMPERROR = 2147483647;
        public const int WM_CTLCOLOR = 0x0019;
#if _AFX_PACKING_AlternateDefinition1
	public const int _AFX_PACKING = 8;
#elif _AFX_PACKING_AlternateDefinition2
	public const int _AFX_PACKING = 4;
#endif
        public const int VK_KANA = 0x15;
        public const int _CRT_WARN = 0;
        public const int _CRT_ERROR = 1;
        public const int _CRT_ASSERT = 2;
        public const int _CRT_ERRCNT = 3;
        public const int _CRTDBG_MODE_FILE = 0x1;
        public const int _CRTDBG_MODE_DEBUG = 0x2;
        public const int _CRTDBG_MODE_WNDW = 0x4;
        public const int _HOOK_ALLOC = 1;
        public const int _HOOK_REALLOC = 2;
        public const int _HOOK_FREE = 3;
        public const int _CRTDBG_ALLOC_MEM_DF = 0x01;
        public const int _CRTDBG_DELAY_FREE_MEM_DF = 0x02;
        public const int _CRTDBG_CHECK_ALWAYS_DF = 0x04;
        public const int _CRTDBG_RESERVED_DF = 0x08;
        public const int _CRTDBG_CHECK_CRT_DF = 0x10;
        public const int _CRTDBG_LEAK_CHECK_DF = 0x20;
        public const int _FREE_BLOCK = 0;
        public const int _NORMAL_BLOCK = 1;
        public const int _CRT_BLOCK = 2;
        public const int _IGNORE_BLOCK = 3;
        public const int _CLIENT_BLOCK = 4;
        public const int _MAX_BLOCKS = 5;
        public const long VERSIONABLE_SCHEMA = 0x80000000;
        public const int AFX_STACK_DUMP_TARGET_TRACE = 0x0001;
        public const int AFX_STACK_DUMP_TARGET_CLIPBOARD = 0x0002;
        public const int AFX_STACK_DUMP_TARGET_BOTH = 0x0003;
        public const int AFX_STACK_DUMP_TARGET_ODS = 0x0004;
        public const int WH_DRAW_POINT = 1;
        public const int WH_DRAW_LINE = 2;
        public const int WH_DRAW_ARC = 3;
        public const int WH_DRAW_CIRCLE = 4;
        public const int WH_DRAW_RECT = 5;
        public const int WH_DRAW_ELLIPSE = 6;
        public const int WH_DRAW_SPLINE = 7;
        public const int WH_DRAW_POLY = 8;
        public const int WH_DRAW_TEXT = 9;
        public const int WH_DRAW_FILL = 10;
        public const int WH_DRAW_SURFACE = 11;
        public const int WH_DRAW_GRID = 12;
        public const int WH_RED = 30;
        public const int WH_GREEN = 31;
        public const int WH_BLUE = 32;
        public const int WH_PEN_SOLID = 40;
        public const int WH_PEN_DASH = 41;
        public const int WH_PEN_DOT = 42;
        public const int WH_PEN_DASHDOT = 43;
        public const int WH_BRUSH_SOLID = 50;
        public const int WH_BRUSH_TRANSPARENT = 51;
        public const int WH_SELECT = 100;
        public const int WH_MOVE = 101;
        public const int WH_COPY = 102;
        public const int WH_DELETE = 103;
        public const int WH_DELETE_ALL = 104;
        public const int WH_MIRROR = 105;
        public const int WH_ZOOM = 106;
        public const int WH_TYPE_LAYER = 1000;
        public const int WH_TYPE_GROUP = 1001;
        public const int WH_TYPE_BLOCK = 1002;
        public const int WH_TYPE_PINTD = 1003;
        public const int WH_TYPE_LINE = 1004;
        public const int WH_TYPE_LINED = 1005;
        public const int WH_TYPE_ARC = 1006;
        public const int WH_TYPE_ARCD = 1007;
        public const int WH_TYPE_RECTD = 1008;
        public const int WH_TYPE_POLYLINE = 1009;
        public const int WH_TYPE_ELLIPSE = 1010;
        public const int WH_TYPE_GRID = 1011;
        public const int WH_MODIFY_LINE = 2000;
        public const int WH_MODIFY_ARC = 2001;
        public const int WH_MODIFY_ELLIPSE = 2002;
        public const int WH_MODIFY_GROUP = 2003;
        public const int WH_HAND_TRANSFORM = 3000;
        public const int WH_AUTO_TRANSFORM = 3001;
        public const float PI = 3.14159265358979323846f;
        public const float TRANSRATIO = 1000.0f;
    }
    public class DefineTypes:CWhVirtual
    {
        //----------------------------------------------------------------------
        public struct tagWHY_SEG
        {
            long fX;
            long fY;
            bool bIsUsed;
            unsafe tagWHY_SEG* pPrev;
            unsafe tagWHY_SEG* pNext;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_SEG_LIST
        {
            unsafe tagWHY_SEG pHeadSeg;
            unsafe tagWHY_SEG_LIST* pNext;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_FREE_MAN
        {
            long nObjectLabel;
            long nStartX;
            long nStartY;
            long nStepNum;
            bool bIsOutBorder;
            long pXChain;
            long pYChain;
            Byte pChain;
            unsafe tagWHY_FREE_MAN* pNext;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_RUN_LEN
        {
            long nStartX;
            long nEndX;
            long nLabel;
            long nLeftLabel;
            long nRightLabel;
            long nUpNum;
            long nDownNum;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_RUN_LIST
        {
            long nSegNum;
            unsafe tagWHY_RUN_LEN pHead;
        };


        //----------------------------------------------------------------------
        // Run Length Label List
        public struct tagWHY_RUN_LABEL
        {
            long nLabel;
            long nNewLabel;
            unsafe tagWHY_RUN_LABEL* pNewRunLabel;
            unsafe tagWHY_RUN_LABEL* pNext;
        };


        //----------------------------------------------------------------------
        // Chain Code Segment 
        // The ChainCode with the Same Direction Will Be Merged
        public struct tagWHY_CHAIN_SEG
        {
            Byte nDir;
            long nLen;
            unsafe tagWHY_CHAIN_SEG* pNext;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_CHAIN
        {
            long nStartX;
            long nStartY;
            long nObjectLabel;
            long nStepNum;
            long nPrevLabel;
            long nNextLabel;
            Byte nUsedTimes;
            bool bIsTop;

            // used only when m_bTraceMethod==true
            long nMemNum;
            Byte pChain;

            // used only when m_bTraceMethod==false
            tagWHY_CHAIN_SEG pHeadChainSeg;
            tagWHY_CHAIN_SEG pTailChainSeg;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_CHAIN_LIST
        {
            long nStartX;
            long nStartY;
            long nPointNum;
            long pXChain;
            long pYChain;
            Byte pChain;

        };


        //----------------------------------------------------------------------
        public struct tagWHY_PITCH
        {
            long nLabel;
            //float		M00,M01,M10,M11,M02,M20;
            float fA, fB, fC;
            float fXc, fYc;
            float fAngle;
            float fWidth;
            float fArea;
            unsafe tagWHY_PITCH* pNext;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_LINE
        {
            float fA, fB, fC;
            float fXc, fYc;
            float fWidth;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_LINE_SEG
        {
            long nStartX;
            long nStartY;
            long nEndX;
            long nEndY;
            unsafe tagWHY_LINE_SEG* pNext;
        };


        //----------------------------------------------------------------
        public struct tagWHY_REGION
        {
            long nRegionType;
            long nPointNum;
            POINTD pPointList;
        };


        //----------------------------------------------------------------
        public struct tagWHY_POINT_OBJECT
        {
            long nPointType;
            tagWHY_REGION pRegion1;
            tagWHY_REGION pRegion2;
        };


        //----------------------------------------------------------------
        public struct tagWHY_LINE_OBJECT
        {
            long nLineType;
            tagWHY_REGION pRegion1;
            tagWHY_REGION pRegion2;
        };


        //----------------------------------------------------------------
        public struct tagWHY_INSTRUCTION
        {
            long nMeasureType;

            tagWHY_REGION pRegion;
            tagWHY_POINT_OBJECT pPointObject1;
            tagWHY_LINE_OBJECT pLineObject1;

            tagWHY_POINT_OBJECT pPointObject2;
            tagWHY_LINE_OBJECT pLineObject2;

            unsafe tagWHY_INSTRUCTION* pNext;
        };


        public struct tagWHY_FEATURE
        {
            long nLabel;
            long nHoleNum;

            float fXc, fYc;
            float fA, fB, fC;
            float fAngle;
            float fArea;
            float fPerimeter;
            tagWHY_RUN_LEN pRunLen;
            tagWHY_FREE_MAN pOuterHeadFreeMan;
            tagWHY_FREE_MAN pInnerHeadFreeMan;
            unsafe tagWHY_FEATURE* pNext;
        };


        // This structure for passing data into LineDDA
        public struct tagWHY_PTS
        {
            long nPos;
            LPPOINTD lpPoints;
        };

        // This structure for passing data into LineDDA
        public struct tagWHY_PTS2
        {
            long nPos;
            long pXList;
            long pYList;
        };

        public struct tagWHY_FILTER
        {
            short nMethod;
            short ppMask;
            short nMaskSize;
            short nOrientation;
            short nStrength;
            float fVariant;
            float fAngle;
            float fAlpha;
            float fMean;
            float fPeriod;
            unsafe fixed char Reserve[32];
        };


        public struct tagWHY_SIGMA
        {
            bool bFlag;
            float fS00;
            float fS10;
            float fS01;
            float fS20;
            float fS11;
            float fS02;
            float fS30;
            float fS21;
            float fS12;
            float fS03;
        };


        // float 
        public struct tagRECTF
        {
            float left;
            float top;
            float right;
            float bottom;
        };

        public struct RECTF
        {
            float left;
            float top;
            float right;
            float bottom;
        };
        public struct PRECTF
        {
            float left;
            float top;
            float right;
            float bottom;
        };
        public struct LPRECTF
        {
            float left;
            float top;
            float right;
            float bottom;
        };

        public struct tagPOINTF
        {
            float x;
            float y;
        };

        public struct POINTF
        {
            float x;
            float y;
        };

        public struct PPOINTF
        {
            float x;
            float y;
        };

        public struct LPPOINTF
        {
            float x;
            float y;
        };

        public struct tagSIZEF
        {
            float cx;
            float cy;
        };
        public struct SIZEF
        {
            float cx;
            float cy;
        };
        public struct PSIZEF
        {
            float cx;
            float cy;
        };
        public struct LPSIZEF
        {
            float cx;
            float cy;
        };

        // float 
        public struct tagRECTD
        {
            float left;
            float top;
            float right;
            float bottom;
        };
        public struct RECTD
        {
            float left;
            float top;
            float right;
            float bottom;
        };
        public struct PRECTD
        {
            float left;
            float top;
            float right;
            float bottom;
        };
        public struct LPRECTD
        {
            float left;
            float top;
            float right;
            float bottom;
        };

        public struct PointF
        {
            float x;
            float y;
        };
//         public struct PointF
//         {
//             float x;
//             float y;
//         };
        public struct tagPOINTD
        {
            float x;
            float y;
        };
        public struct POINTD
        {
            float x;
            float y;
        };
        public struct PPOINTD
        {
            float x;
            float y;
        };
        public struct LPPOINTD
        {
            float x;
            float y;
        };

        public struct CSize
        {
            float cx;
            float cy;
        };
        public struct tagSIZED
        {
            float cx;
            float cy;
        };
        public struct SIZED
        {
            float cx;
            float cy;
        };
        public struct PSIZED
        {
            float cx;
            float cy;
        };
        public struct LPSIZED
        {
            float cx;
            float cy;
        };
    }
    public class CWhListContainer
    {        
        private LinkedList<object> m_pListContainer = new LinkedList<object>();
        public RectangleF m_rcBound = new RectangleF();

        public void Serialize(ref BinaryFormatter ar)
        {            
            m_pListContainer.Serialize(ref ar);
            if (ar.IsLoading() != 0)
            {
                ar >> m_rcBound;
            }
            else
            {
                ar << m_rcBound;
            }
        }
        public void UpdateBoundRect()
        {            
            m_rcBound = new RectangleF(0, 0, 0, 0);


            RectangleF rcUnion = new RectangleF();
            CWhVirtual pObj = null;
            LinkedListNode<object> pos = GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);

                if (pObj.GetIsShow())
                {
                    continue;
                }
                pObj.UpdateBoundRect();

                if (m_rcBound.IsEmpty)
                {
                    m_rcBound = pObj.m_rcBound;
                }
                else
                {
                    rcUnion = RectangleF.Union(m_rcBound, pObj.m_rcBound);
                    m_rcBound = new RectangleF(rcUnion.Left, rcUnion.Top, rcUnion.Right - rcUnion.Left, rcUnion.Top - rcUnion.Bottom);
                    //m_rcBound.NormalizeRect();
                }
            }
        }
        public RectangleF GetRcBound()
        {
            return m_rcBound;
        }
        public void UpdateListObjParent()
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListContainer.First;
            while (posObj != null)
            {
                pObj = (CWhVirtual)posObj.Next.Value;

                pObj.m_pParentList = this;
                if (pObj.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObj).m_pListLayer.UpdateListObjParent();
                }
            }
        }
        public void UpdateListObjID(ref int lIDBegin)
        {

            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListContainer.First;
            while (posObj != null)
            {
                pObj = (CWhVirtual)posObj.Next.Value;
                pObj = (CWhVirtual)posObj.Value;
                pObj.m_lID = ++lIDBegin;
                if (pObj.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObj).m_pListLayer.UpdateListObjID(ref lIDBegin);
                }
            }
        }

        public LinkedList<object> GetObjList()
        {
            return m_pListContainer;
        }
        public int GetCount()
        {
            return m_pListContainer.Count;
        }
        public int IsEmpty()
        {
            return m_pListContainer.Count;
        }
        public CWhVirtual GetTail()
        {
            CWhVirtual pObj = null;
            if (IsEmpty() == 0)
            {
                pObj = (CWhVirtual)m_pListContainer.Last.Value;
            }
            return pObj;
        }
        public CWhVirtual GetHead()
        {
            CWhVirtual pObj = null;
            if (IsEmpty() == 0)
            {
                pObj = (CWhVirtual)m_pListContainer.First.Value;
            }
            return pObj;
        }
        public LinkedListNode<object> GetHeadPosition()
        {
            return m_pListContainer.First;
        }
        public LinkedListNode<object> GetTailPosition()
        {
            return m_pListContainer.Last;
        }
        public CWhVirtual GetNext(ref LinkedListNode<object> pos)
        {
            return (CWhVirtual)pos.Next.Value;
        }
        public CWhVirtual GetPrev(ref LinkedListNode<object> pos)
        {
            return (CWhVirtual)pos.Previous.Value;
        }
        public CWhVirtual GetAt(ref LinkedListNode<object> pos)
        {
            CWhVirtual pObj = null;
            pObj = (CWhVirtual)pos.Value;
            return pObj;
        }
        public bool IsObjInListContainer(CWhVirtual pObj)
        {
            if (FindObject(pObj))
            {
                return true;
            }
            return false;
        }
        public bool FindObject(CWhVirtual pObj)
        {

            bool bRet = false;
            LinkedListNode<object> pos = m_pListContainer.Find(pObj);
            if (pos != null)
            {
                bRet = true;
                return bRet;
            }

            CWhVirtual pObjNext = null;
            LinkedListNode<object> posNext = m_pListContainer.First;
            while (posNext != null)
            {
                pObjNext = (CWhVirtual)posNext.Next.Value;
                if (pObjNext.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    if (((CWhLayer)pObjNext).FindObject(pObj))
                    {
                        bRet = true;
                        return bRet;
                    }
                }
            }

            return bRet;
        }
        public CWhVirtual FindObjectFromID(int lID)
        {
            CWhVirtual pObjRet = null;
            CWhVirtual pObj = null;
            LinkedListNode<object> pos = m_pListContainer.First;
            while (pos != null)
            {

                pObj = (CWhVirtual)pos.Next.Value;
                if (pObj.m_lID == lID)
                {
                    pObjRet = pObj;
                    return pObjRet;
                }

                if (pObj.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    pObjRet = ((CWhLayer)pObj).FindObjectFromID(lID);
                    if (pObjRet != null)
                    {
                        break;
                    }
                }
            }

            return pObjRet;
        }
        public CWhVirtual FindLayerFromName(string strLayerName)
        {
            CWhVirtual pObjRet = null;
            CWhVirtual pObj = null;
            LinkedListNode<object> pos = m_pListContainer.First;
            while (pos != null)
            {

                pObj = (CWhVirtual)pos.Next.Value;
                if (pObj.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    if (((CWhLayer)pObj).m_strLayerName == strLayerName)
                    {
                        pObjRet = pObj;
                        break;
                    }
                }
            }

            return pObjRet;
        }
        public LinkedListNode<object> Find(CWhVirtual pObj)
        {
            LinkedListNode<object> posRet = new LinkedListNode<object>(null);
            posRet = m_pListContainer.Find(pObj);
            return posRet;
        }
        public void SetAt(LinkedListNode<object> pos, CWhVirtual pObj)
        {

            pObj.AddRef();
            if (pObj.m_pParentList==null)
            {
                pObj.m_pParentList = this;
            }
            m_pListContainer.AddAfter(pos, pObj);
            m_pListContainer.Remove(pos);
            RectangleF rcUnion = new RectangleF();
            if (m_rcBound.IsEmpty)
            {
                m_rcBound = pObj.m_rcBound;
            }
            else
            {                
                rcUnion = RectangleF.Union(m_rcBound, pObj.m_rcBound);
                m_rcBound= new RectangleF(rcUnion.Left, m_rcBound.Top, m_rcBound.Right-rcUnion.Left, m_rcBound.Top-m_rcBound.Bottom);
                //m_rcBound.NormalizeRect();
            }
        }
        public void InsertAfterObj(CWhVirtual pObj, CWhVirtual pObjAfter)
        {
            LinkedListNode<object> posAfter = Find(pObj);

            pObjAfter.AddRef();

            if (pObjAfter.m_pParentList==null)
            {
                pObjAfter.m_pParentList = this;
            }

            m_pListContainer.AddAfter(posAfter, pObjAfter);

            RectangleF rcUnion = new RectangleF();
            if (m_rcBound.IsEmpty)
            {
                m_rcBound = pObjAfter.m_rcBound;
            }
            else
            {
                rcUnion = RectangleF.Union(m_rcBound, pObjAfter.m_rcBound);
                m_rcBound = new RectangleF(rcUnion.Left, rcUnion.Top, rcUnion.Right - rcUnion.Left, rcUnion.Top - rcUnion.Bottom);
                //m_rcBound.NormalizeRect();
            }
        }
        public void InsertPreObj(CWhVirtual pObj, CWhVirtual pObjPre)
        {
            LinkedListNode<object> posPre = Find(pObj);

            pObjPre.AddRef();

            if (pObjPre.m_pParentList==null)
            {
                pObjPre.m_pParentList = this;
            }

            m_pListContainer.AddBefore(posPre, pObjPre);

            RectangleF rcUnion = new RectangleF();
            if (m_rcBound.IsEmpty)
            {
                m_rcBound = pObjPre.m_rcBound;
            }
            else
            {
                rcUnion = RectangleF.Union(m_rcBound, pObjPre.m_rcBound);
                m_rcBound = new RectangleF(rcUnion.Left, rcUnion.Top, rcUnion.Right - rcUnion.Left, rcUnion.Top - rcUnion.Bottom);
                //m_rcBound.NormalizeRect();
            }
        }
        public CWhVirtual GetAfterObj(CWhVirtual pObj)
        {
            CWhVirtual pObjRet = null;
            LinkedListNode<object> posObj = Find(pObj);
            if (posObj != null)
            {
                pObjRet = GetNext(ref posObj);
                pObjRet = GetNext(ref posObj);
            }
            return pObjRet;
        }
        public CWhVirtual GetPreObj(CWhVirtual pObj)
        {
            CWhVirtual pObjRet = null;
            LinkedListNode<object> posObj = Find(pObj);
            if (posObj != null)
            {
                pObjRet = GetPrev(ref posObj);
                pObjRet = GetPrev(ref posObj);
            }
            return pObjRet;
        }
        public void MoveObjNext(CWhVirtual pObj)
        {

            CWhVirtual pObjNext = null;
            LinkedListNode<object> posMove = Find(pObj);
            if (posMove != null)
            {

                pObjNext = GetNext(ref posMove);
                if (posMove != null)
                {
                    m_pListContainer.AddAfter(posMove, pObjNext);
                    pObjNext = GetPrev(ref posMove);
                    m_pListContainer.Remove(posMove.Value);
                }
                return;
            }

            posMove = GetHeadPosition();
            while (posMove != null)
            {
                pObjNext = GetNext(ref posMove);
                if (pObjNext.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObjNext).MoveObjNext(pObj);
                }
            }
        }
        public void MoveObjPrev(CWhVirtual pObj)
        {

            CWhVirtual pObjPrev = null;
            LinkedListNode<object> posMove = Find(pObj);
            if (posMove != null)
            {

                pObjPrev = GetPrev(ref posMove);
                if (posMove != null)
                {
                    m_pListContainer.AddBefore(posMove, pObjPrev);

                    pObjPrev = GetNext(ref posMove);
                    m_pListContainer.Remove(posMove.Value);
                }
                return;
            }

            posMove = GetHeadPosition();
            while (posMove != null)
            {
                pObjPrev = GetNext(ref posMove);
                if (pObjPrev.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObjPrev).MoveObjPrev(pObj);
                }
            }
        }
        public void MoveObjHead(CWhVirtual pObj)
        {

            CWhVirtual pObjHead = null;
            LinkedListNode<object> posMove = Find(pObj);
            if (posMove != null)
            {
                m_pListContainer.Remove(posMove.Value);
                m_pListContainer.AddFirst(pObj);
                return;
            }

            posMove = GetHeadPosition();
            while (posMove != null)
            {
                pObjHead = GetNext(ref posMove);
                if (pObjHead.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObjHead).m_pListLayer.MoveObjHead(pObj);
                }
            }
        }
        public void MoveObjEnd(CWhVirtual pObj)
        {

            CWhVirtual pObjEnd = null;
            LinkedListNode<object> posMove = Find(pObj);
            if (posMove != null)
            {
                m_pListContainer.Remove(posMove.Value);
                m_pListContainer.AddLast(pObj);
                return;
            }

            posMove = GetHeadPosition();
            while (posMove != null)
            {
                pObjEnd = GetNext(ref posMove);
                if (pObjEnd.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObjEnd).m_pListLayer.MoveObjEnd(pObj);
                }
            }
        }
        public void AntiList()
        {
            LinkedList<object> pAntiList = new LinkedList<object>();
            CWhVirtual pObj = null;
            LinkedListNode<object> posAnti = GetHeadPosition();
            while (posAnti != null)
            {
                pObj = GetNext(ref posAnti);
                pAntiList.AddFirst(pObj);
            }

            m_pListContainer.Clear();

            m_pListContainer = null;

            m_pListContainer = pAntiList;
        }

        public void AddTail(CWhVirtual pObj)
        {
            AddObject(pObj);
        }
        public void AddHead(CWhVirtual pObj)
        {

            pObj.AddRef();

            if (pObj.m_pParentList==null)
            {
                pObj.m_pParentList = this;
            }

            m_pListContainer.AddFirst(pObj);

            RectangleF rcUnion = new RectangleF();
            if (m_rcBound.IsEmpty)
            {
                m_rcBound = pObj.m_rcBound;
            }
            else
            {
                rcUnion = RectangleF.Union(m_rcBound, pObj.m_rcBound);
                m_rcBound= new RectangleF(rcUnion.Left, rcUnion.Top, rcUnion.Right-rcUnion.Left, rcUnion.Top-rcUnion.Bottom);
                //m_rcBound.NormalizeRect();
            }
        }
        public void AddObject(CWhVirtual pObj)
        {

            pObj.AddRef();

            if (pObj.m_pParentList==null)
            {
                pObj.m_pParentList = this;
            }

            m_pListContainer.AddLast(pObj);

            RectangleF rcUnion = new RectangleF();
            if (m_rcBound.IsEmpty)
            {
                m_rcBound = pObj.m_rcBound;
            }
            else
            {
                rcUnion = RectangleF.Union(m_rcBound, pObj.m_rcBound);
                m_rcBound= new RectangleF(rcUnion.Left, rcUnion.Top, rcUnion.Right-rcUnion.Left, rcUnion.Top-rcUnion.Bottom);
                //m_rcBound.NormalizeRect();
            }
        }
        public void AddObjects(CWhListContainer pList)
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> pos = pList.GetHeadPosition();
            while (pos != null)
            {
                pObj = pList.GetNext(ref pos);
                AddObject(pObj);
            }
        }

        public bool RemoveObject(CWhVirtual pObj)
        {
            return RemoveObject(pObj, false);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: int RemoveObject(CWhVirtual pObj, bool bFlagDepth = false)
        public bool RemoveObject(CWhVirtual pObj, bool bFlagDepth = false)
        {
            bool bRet = false;
            LinkedListNode<object> pos = m_pListContainer.Find(pObj);
            if (pos != null)
            {

                bRet = true;
                if (bFlagDepth)
                {
                    if (pObj.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                    {
                        ((CWhLayer)pObj).RemoveAll(bFlagDepth);
                    }
                }

                m_pListContainer.Remove(pos.Value);

                pObj.Release();

                if (pObj.GetRefCount() == 0)
                {
                    pObj = null;
                }

                return bRet;
            }


            CWhVirtual pObjNext = null;
            LinkedListNode<object> posNext = m_pListContainer.First;
            while (posNext != null)
            {
                pObjNext = (CWhVirtual)posNext.Next.Value;

                if (pObjNext.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    if (((CWhLayer)pObjNext).RemoveObject(pObj, bFlagDepth))
                    {
                        bRet = true;
                        return bRet;
                    }
                }
            }


            return bRet;
        }
        public void RemoveObjects(CWhListContainer pList)
        {
            RemoveObjects(pList, false);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void RemoveObjects(CWhListContainer pList, bool bFlagDepth = false)
        public void RemoveObjects(CWhListContainer pList, bool bFlagDepth = false)
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> pos = pList.GetHeadPosition();
            while (pos != null)
            {
                pObj = pList.GetNext(ref pos);
                RemoveObject(pObj, bFlagDepth);
            }

            UpdateBoundRect();
        }
        public void RemoveAll()
        {
            RemoveAll(false);
        }
        public void RemoveAll(bool bFlagDepth)
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> pos = GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);
                RemoveObject(pObj, bFlagDepth);
            }

            m_rcBound = new RectangleF(0, 0, 0, 0);
        }
        public void DeleteObject(CWhVirtual pObj)
        {
            DeleteObject(pObj, false);
        }
        public void DeleteObject(CWhVirtual pObj, bool bFlagDepth = false)
        {
            pObj = null;
        }
        public void DeleteObjects(CWhListContainer pList)
        {
            DeleteObjects(pList, false);
        }
        public void DeleteObjects(CWhListContainer pList, bool bFlagDepth = false)
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> pos = pList.GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);
                DeleteObject(pObj);
            }
        }
        public void DeleteAll()
        {
            DeleteAll(false);
        }
        public void DeleteAll(bool bFlagDepth)
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> pos = GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);
                DeleteObject(pObj);
            }
            m_rcBound = new RectangleF(0, 0, 0, 0);
        }

        public void GroupObj(CWhListContainer pListObj)
        {

            CWhGroup pGroup = new CWhGroup();
            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = pListObj.GetHeadPosition();
            while (posObj != null)
            {
                pObj = pListObj.GetNext(ref posObj);
                pGroup.AddObject(pObj);

                pObj.m_pParentList = pGroup.m_pListGroup;
            }

            AddObject(pGroup);


        }
        public void ApartAll()
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = GetHeadPosition();
            while (posObj != null)
            {
                pObj = GetNext(ref posObj);
                if (pObj.m_nObjType == DefineConstantsFdxf.WH_TYPE_GROUP)
                {
                    ((CWhGroup)pObj).Apart();
                    RemoveObject(pObj);
                }
                else if (pObj.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObj).m_pListLayer.ApartAll();
                }
            }
        }

        public void FindObjInRect(CWhListContainer pListDestination, RectangleF rcRect)
        {
            CWhVirtual pObjInRect = null;
            LinkedListNode<object> posInRect = GetHeadPosition();
            while (posInRect != null)
            {
                pObjInRect = GetNext(ref posInRect);
                if (pObjInRect.IsObjInRect(rcRect))
                {

                    if (pObjInRect.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                    {
                        ((CWhLayer)pObjInRect).m_pListLayer.FindObjInRect(pListDestination, rcRect);
                        continue;
                    }

                    pListDestination.AddObject(pObjInRect);
                }
            }
        }
        public bool SelectObj(CWhListContainer pListSelect, PointF ptClick, int nLimit, ref Graphics pDC)
        {
            bool bRet = false;
            CWhVirtual pObj = null;
            LinkedListNode<object> pos = GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);
                if (!pObj.GetIsShow())
                {
                    continue;
                }
                if (pObj.IsSelected(ptClick, nLimit))
                {

                    if (pObj.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                    {
                        if (((CWhLayer)pObj).m_pListLayer.SelectObj(pListSelect, ptClick, nLimit, ref pDC))
                        {
                            bRet = true;
                            return bRet;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    pObj.SetIsShowHandle(true);
                    pObj.SetPenColor(Color.FromArgb(255, 0, 0));

                    pListSelect.AddObject(pObj);

                    bRet = true;
                    return bRet;
                }
            }

            return bRet;
        }
        public bool SelectObj(CWhListContainer pListSelect, RectangleF rcClick, int bFlagMode, ref Graphics pDC)
        {
            bool bRet = false;
            CWhVirtual pObj = null;
            LinkedListNode<object> pos = GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);
                if (pObj.IsSelected(rcClick, bFlagMode))
                {

                    if (pObj.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                    {
                        ((CWhLayer)pObj).m_pListLayer.SelectObj(pListSelect, rcClick, bFlagMode, ref pDC);
                        continue;
                    }

                    pObj.SetIsShowHandle(true);
                    pObj.SetPenColor(Color.FromArgb(255, 0, 0));

                    pListSelect.AddObject(pObj);
                }
            }

            return bRet;
        }
        public bool SnapPoint(ref PointF ptSnap, PointF ptInput, float fDiatance)
        {
            bool bRet = false;

            CWhVirtual pObjSnap = null;
            LinkedListNode<object> posSnap = GetHeadPosition();
            while (posSnap != null)
            {
                pObjSnap = GetNext(ref posSnap);
                if (pObjSnap.IsPointSnap(ref ptSnap, ptInput, fDiatance))
                {

                    if (pObjSnap.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                    {
                        if (!((CWhLayer)pObjSnap).m_pListLayer.SnapPoint(ref ptSnap, ptInput, fDiatance))
                        {
                            continue;
                        }
                    }
                    bRet = true;
                    return bRet;
                }
            }

            return bRet;
        }
        public bool SelectPoint(ref CWhVirtual pSnap, ref PointF ptSnap, ref int nSnap, PointF ptInput, float fDiatance)
        {
            bool bRet = false;
            CWhVirtual pObjSnap = null;
            LinkedListNode<object> posSnap = GetHeadPosition();
            while (posSnap != null)
            {
                pObjSnap = GetNext(ref posSnap);
                if (pObjSnap.IsPointSelect(ref ptSnap, ref nSnap, ptInput, fDiatance))
                {

                    if (pObjSnap.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                    {
                        if (!((CWhLayer)pObjSnap).m_pListLayer.SelectPoint(ref pSnap, ref ptSnap, ref nSnap, ptInput, fDiatance))
                        {
                            continue;
                        }
                    }
                    pSnap = pObjSnap;
                    bRet = true;
                    return bRet;
                }
            }

            return bRet;
        }

        public bool SelectStartPoint(ref CWhVirtual pObj, ref PointF ptRet, PointF ptInput, float fDiatance)
        {
            bool bRet = false;
            CWhVirtual pObjStart = null;
            LinkedListNode<object> posStart = GetHeadPosition();
            while (posStart != null)
            {
                pObjStart = GetNext(ref posStart);
                if (pObjStart.IsStartPointSelect(ref ptRet, ptInput, fDiatance))
                {

                    if (pObjStart.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                    {
                        if (!((CWhLayer)pObjStart).m_pListLayer.SelectStartPoint(ref pObj, ref ptRet, ptInput, fDiatance))
                        {
                            continue;
                        }
                    }
                    pObj = pObjStart;
                    bRet = true;
                    return bRet;
                }
            }

            return bRet;
        }

        public void CopyObjToList(CWhListContainer pList)
        {
            CopyObjToList(pList, false);
        }
        public void CopyObjToList(CWhListContainer pList, bool bFlagSingle = false)
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> pos = GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);
                if (bFlagSingle && pObj.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    CWhLayer pLayer = new CWhLayer();

                    pLayer.m_lID = pObj.m_lID;
                    pLayer.m_bIsShowHandle = pObj.m_bIsShowHandle;
                    pLayer.m_strLayerName = ((CWhLayer)pObj).m_strLayerName;
                    pLayer.m_nMachineCount = pObj.m_nMachineCount;
                    pLayer.m_bMachineStyle = pObj.m_bMachineStyle;
                    pLayer.m_nMachineFrequence = pObj.m_nMachineFrequence;

                    ((CWhLayer)pObj).m_pListLayer.CopyObjToList(pLayer.m_pListLayer, bFlagSingle);
                    pLayer.UpdateBoundRect();
                    pList.AddObject(pLayer);
                    continue;
                }

                pList.AddObject(pObj);
            }
        }

        public void OptimizeObjOrder()
        {

            if (m_pListContainer.Equals(null))
            {
                return;
            }

            CWhListContainer pListDestinate = new CWhListContainer();
            while (!m_pListContainer.Equals(null))
            {
                ExtractGroup(this, pListDestinate, 5);
            }

            OptimizeGroup(pListDestinate);

            ArangeGroupOrder(pListDestinate);
            pListDestinate.RemoveAll();
            pListDestinate = null;
        }
        public bool SearchNearlyNextObj(CWhListContainer pListSource, PointF ptInput, float fDistanceGap, ref CWhVirtual pObjRet, bool bFlagType)
        {
            bool bRet = false;
            PointF ptstart = new PointF(0, 0);
            PointF ptEnd = new PointF(0, 0);
            CWhVirtual pObjSearch = null;
            LinkedListNode<object> posObjSearch = pListSource.GetHeadPosition();
            while (posObjSearch != null)
            {
                pObjSearch = pListSource.GetNext(ref posObjSearch);
                ptstart = pObjSearch.GetStartPoint();
                ptEnd = pObjSearch.GetEndPoint();


                if (CWhSysFunction.PointToPointDistance(ptInput, ptstart) < fDistanceGap)
                {
                    if (bFlagType)
                    {
                        pObjSearch.ExchangeStartToEnd();

                    }
                    pObjRet = pObjSearch;
                    bRet = true;
                    break;
                }
                else if (CWhSysFunction.PointToPointDistance(ptInput, ptEnd) < fDistanceGap)
                {
                    if (bFlagType)
                    {
                        pObjSearch.ExchangeStartToEnd();
                    }
                    pObjRet = pObjSearch;
                    bRet = true;
                    break;
                }
            }

            return bRet;
        }
        public bool ExtractGroup(CWhListContainer pListSource, CWhListContainer pListDestinate, float fDistanceGap)
        {
            bool bRet = false;
            PointF ptStartSearch = new PointF(0, 0);
            PointF ptEndSearch = new PointF(0, 0);
            CWhGroup pGroup = new CWhGroup();
            pListDestinate.AddObject(pGroup);
            CWhVirtual pObjOptimize = null;
            CWhVirtual pObjRet = null;

            pObjOptimize = pListSource.GetHead();
            if (pObjOptimize != null)
            {
                pGroup.AddObject(pObjOptimize);
                pListSource.RemoveObject(pObjOptimize);
            }
            if ((pObjOptimize.m_nObjType == DefineConstantsFdxf.WH_TYPE_LINE) || (pObjOptimize.m_nObjType == DefineConstantsFdxf.WH_TYPE_ARC))
            {
                ptStartSearch = pObjOptimize.GetStartPoint();
                ptEndSearch = pObjOptimize.GetEndPoint();
            }

            while (SearchNearlyNextObj(pListSource, ptEndSearch, fDistanceGap, ref pObjRet, true))
            {
                pGroup.AddObject(pObjRet);
                pListSource.RemoveObject(pObjRet);
                ptEndSearch = pObjRet.GetEndPoint();
            }

            while (SearchNearlyNextObj(pListSource, ptStartSearch, fDistanceGap, ref pObjRet, false))
            {
                pGroup.m_pListGroup.AddHead(pObjRet);
                pListSource.RemoveObject(pObjRet);
                ptStartSearch = pObjRet.GetStartPoint();
            }

            return bRet;
        }
        public bool OptimizeGroup(CWhListContainer pList)
        {
            CWhListContainer pListGroup = new CWhListContainer();
            RectangleF rcSearch = new RectangleF(0, 0, 0, 0);
            CWhVirtual pObj = null;

            pList.UpdateBoundRect();

            pObj = pList.GetHead();
            rcSearch = pObj.m_rcBound;
            //rcSearch.NormalizeRect();
            if (pObj != null)
            {
                pListGroup.AddObject(pObj);
                pList.RemoveObject(pObj);
            }

            while (pList.IsEmpty() == 0)
            {
                SearchNearlyNextGroup(ref rcSearch, pList, pListGroup);
            }

            pList.AddObjects(pListGroup);
            pListGroup.RemoveAll();
            pListGroup = null;

            return true;
        }
        public void SearchNearlyNextGroup(ref RectangleF rcInPut, CWhListContainer pList, CWhListContainer pListDestinate)
        {
            CWhVirtual pObjRet = null;
            float fDistancePre = 0;
            float fDistanceCur = 0;
            int i = 0;
            RectangleF rcCurrent = new RectangleF(0, 0, 0, 0);
            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = pList.GetHeadPosition();
            while (posObj != null)
            {
                pObj = pList.GetNext(ref posObj);
                rcCurrent = pObj.m_rcBound;
                PointF centerpoint1 = new PointF(rcInPut.Left+rcInPut.Width/2, rcInPut.Top-rcInPut.Height/2);
                PointF centerpoint2 = new PointF(rcCurrent.Left + rcCurrent.Width / 2, rcCurrent.Top - rcCurrent.Height / 2);
                fDistanceCur = CWhSysFunction.PointToPointDistance(centerpoint1, centerpoint2);
                if (i == 0)
                {
                    fDistancePre = fDistanceCur;
                    pObjRet = pObj;
                    i++;
                    continue;
                }
                if (fDistanceCur < fDistancePre)
                {
                    fDistancePre = fDistanceCur;
                    pObjRet = pObj;
                    continue;
                }
            }

            rcInPut = pObjRet.m_rcBound;
            //rcInPut.NormalizeRect();
            pListDestinate.AddObject(pObjRet);
            pList.RemoveObject(pObjRet);
        }
        public void ArangeGroupOrder(CWhListContainer pList)
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = pList.GetHeadPosition();
            while (posObj != null)
            {
                pObj = pList.GetNext(ref posObj);
                if (pObj.m_nObjType == DefineConstantsFdxf.WH_TYPE_GROUP)
                {
                    AddObjects(((CWhGroup)pObj).m_pListGroup);
                }
            }
        }
    }
    public class CWhPointD : CWhVirtual
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhPointD()
        {
            m_fx = 0;
            m_fy = 0;
        }
        public CWhPointD(ref CWhPointD PointF)
        {
            m_fx = PointF.m_fx;
            m_fy = PointF.m_fy;
        }
        public CWhPointD(float x, float y)
        {
            m_fx = x;
            m_fy = y;
        }
        public CWhPointD(PointF PointF)
        {
            m_fx = PointF.X;
            m_fy = PointF.Y;
        }
        public float m_fx;
        public float m_fy;        
        public void CopyFrom(CWhPointD PointF)
        {
            m_fx = PointF.m_fx;
            m_fy = PointF.m_fy;
        }        
        public static CWhPointD operator +(CWhPointD ImpliedObject, CWhPointD PointF)
        {
            CWhPointD ptRet = new CWhPointD();

            return ptRet;
        }
        public static CWhPointD operator -(CWhPointD ImpliedObject, CWhPointD PointF)
        {
            CWhPointD ptRet = new CWhPointD();

            return ptRet;
        }

        public float Distance(ref CWhPointD ptInput)
        {
            float fRet = 0;

            fRet = (m_fx - ptInput.m_fx) * (m_fx - ptInput.m_fx) + (m_fy - ptInput.m_fy) * (m_fy - ptInput.m_fy);
            fRet = (float)System.Math.Sqrt((double)(fRet));
            return fRet;
        }
    }
    public class CWhRectD : CWhVirtual
    {
        public CWhPointD m_ptdTopLeft = new CWhPointD();
        public CWhPointD m_ptdBtmRight = new CWhPointD();        
    }
    public class CWhLine : CWhVirtual
    {
        public CWhLine()
        {
            m_ptStart = new PointF();
            m_ptEnd = new PointF();
            m_nObjType = DefineConstantsFdxf.WH_TYPE_LINE;
            SetObjDefaultProperty();
            UpdateBoundRect();
        }
        public CWhLine(PointF ptStart, PointF ptEnd)
        {
            m_ptStart = ptStart;
            m_ptEnd = ptEnd;
            m_nObjType = DefineConstantsFdxf.WH_TYPE_LINE;
            SetObjDefaultProperty();
            UpdateBoundRect();
        }
        public PointF m_ptStart = new PointF();
        public PointF m_ptEnd = new PointF();

        public override void Serialize(ref BinaryFormatter ar)
        {
            CWhVirtual.Serialize(ref ar);
            if (ar.IsStoring() != 0)
            {
                ar << m_ptStart << m_ptEnd;
            }
            else
            {
                ar >> m_ptStart >> m_ptEnd;
            }
        }
        public override void UpdateBoundRect()
        {
            m_rcBound= new RectangleF(m_ptStart,new SizeF(m_ptEnd.X-m_ptStart.X, m_ptStart.X- m_ptEnd.Y));
            //m_rcBound.NormalizeRect();
            if (m_rcBound.IsEmpty)
            {
                m_rcBound.Inflate(m_rcBound.Width>0 ? 0 : 1, m_rcBound.Height>0 ? 0 : 1);
            }
        }
        public override void Draw(ref Graphics pDC, RectangleF rcClient)
        {

            if (m_bIsShow)
            {

                RectangleF rcInterSectRect = new RectangleF(0, 0, 0, 0);
                RectangleF rcClientReal = TransDPtoRP(rcClient, ref pDC);
                if (RectangleF.Intersect(m_rcBound, rcClientReal).IsEmpty)
                {
                    return;
                }
                PointF ptStart = new PointF();
                PointF ptEnd = new PointF();

                ptStart = TransRPtoLP(m_ptStart);
                ptEnd = TransRPtoLP(m_ptEnd);

                Pen pOldPen = null;
                Pen penLine = new Pen( m_colPenColor,m_nPenWidth);               
                pOldPen = penLine;
                if (m_bIsShowHandle)
                {
                    pDC.DrawLine(pOldPen, ptStart, ptEnd);
                }
            }
        }
        public override void DrawHandle(ref Graphics pDC)
        {
            PointF ptStart = new PointF();
            PointF ptEnd = new PointF();

            ptStart = TransRPtoLP(m_ptStart);
            ptEnd = TransRPtoLP(m_ptEnd);

            RectangleF rcHandle = new RectangleF(0, 2, 2, 2);
            //pDC.DPtoLP(rcHandle);
            RectangleF rcStart = new RectangleF(ptStart.X, ptStart.Y, 0, 0);
            RectangleF rcEnd = new RectangleF(ptEnd.X, ptEnd.Y, 0, 0);

            rcStart.Inflate(rcHandle.Width, rcHandle.Height);
            rcEnd.Inflate(rcHandle.Width, rcHandle.Height);


            //设置画笔
            Pen pOldPen = null;
            Pen pen = new Pen(Color.FromArgb(0, 0, 255),rcHandle.Width*2);
            pOldPen = pen;
            pDC.DrawRectangle(pen,rcEnd.X, rcEnd.Y, rcEnd.Width, rcEnd.Height);

            //设置画笔
            Pen pOldPen1 = null;
            Pen pen1 = new Pen(Color.FromArgb(255, 0, 0),rcHandle.Width*2);
            pOldPen1 = pen1;
            pDC.DrawRectangle(pen, rcStart.X, rcStart.Y, rcStart.Width, rcStart.Height);
        }
        public override void DrawArrow(ref Graphics pDC)
        {

        }
        public override void DrawStartPoint(ref Graphics pDC)
        {
            PointF ptStart = new PointF();
            ptStart = TransRPtoLP(m_ptStart);
            RectangleF rcHandle = new RectangleF(0, 3, 3, 3);
            //pDC.DPtoLP(rcHandle);
            RectangleF rcStart = new RectangleF(ptStart.X, ptStart.Y, 0, 0);
            rcStart.Inflate(rcHandle.Width, rcHandle.Height);           
            Pen pOldPen = null;
            Pen pen = new Pen(Color.FromArgb(255, 0, 0),0);
            pOldPen = pen;
            pDC.DrawRectangle(pen, rcStart.X, rcStart.Y, rcStart.Width, rcStart.Height);            
        }
        public override bool IsValid()
        {
            if (m_ptStart == m_ptEnd)
            {
                return false;
            }
            return true;
        }
        public override void Move(float nX, float nY)
        {
            PointF ptMove = new PointF(nX, nY);
            m_ptStart.X = m_ptStart.X + ptMove.X;
            m_ptStart.Y = m_ptStart.Y + ptMove.Y;
            m_ptEnd.X = m_ptEnd.X + ptMove.X;
            m_ptEnd.Y = m_ptEnd.Y + ptMove.Y;
            UpdateBoundRect();
        }
        public override void ExchangeStartToEnd()
        {
            PointF ptTem = new PointF(0, 0);
            ptTem = m_ptStart;
            SetStartPoint(m_ptEnd);
            SetEndPoint(ptTem);
            UpdateBoundRect();
        }
        public override void DrawNumber(ref Graphics pDC)
        {
            string strNum;
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            strNum = string.Format("%d", m_lID);
            PointF pt = TransRPtoLP(m_ptStart);
            pDC.DrawString(strNum, drawFont, drawBrush, pt.X, pt.Y);
        }

        public override bool IsSelected(PointF ptClick, int nLimit)
        {
            bool bRet = false;

            RectangleF rcBound = new RectangleF();
            rcBound.Inflate(nLimit, nLimit); 

            if (rcBound.Contains(ptClick))
            {

                float nDisTance = CWhSysFunction.PointToLineDistance(m_ptStart, m_ptEnd, ptClick);
                if (nDisTance <= nLimit)
                {
                    bRet = true;
                    return bRet;
                }
            }

            return bRet;
        }
        public override bool IsSelected(RectangleF rcClick, int bFlagMode)
        {
            bool bRet = false;

            RectangleF rcBound = new RectangleF();
            RectangleF rcInterSectRect = new RectangleF(0, 0, 0, 0);
            rcBound.Inflate(1, 1);

            if (bFlagMode == -1)
            {
                if (RectangleF.Intersect(m_rcBound, rcClick).IsEmpty)
                {
                    bRet = true;
                    return bRet;
                }
            }
            else if (bFlagMode == 1)
            {
                rcInterSectRect = RectangleF.Intersect(m_rcBound, rcClick);
                if (rcInterSectRect == m_rcBound)
                {
                    bRet = true;
                    return bRet;
                }
            }

            return bRet;
        }
        public override bool IsPointSnap(ref PointF ptSnap, PointF ptInput, float fDiatance)
        {
            bool bRet = false;
            RectangleF rcSnap = m_rcBound;
            rcSnap.Inflate(2 * fDiatance, 2 * fDiatance);


            if (!rcSnap.Contains(ptInput))
            {
                return false;
            }

            RectangleF[] rc = new RectangleF[3];
            rc[0] = new RectangleF(m_ptStart, new SizeF(0, 0) );
            rc[1] = new RectangleF(m_ptEnd, new SizeF(0, 0));
            rc[2] = new RectangleF(new PointF((float)((m_ptStart.X + m_ptEnd.X) / 2.0), (float)((m_ptStart.Y + m_ptEnd.Y) / 2.0)), new SizeF(0,0));

            for (int i = 0; i < 3; i++)
            {
                rc[i].Inflate(fDiatance, fDiatance);
            }

            if (rc[0].Contains(ptInput))
            {
                ptSnap = m_ptStart;
                bRet = true;
                return bRet;
            }
            else if (rc[1].Contains(ptInput))
            {
                ptSnap = m_ptEnd;
                bRet = true;
                return bRet;
            }
            else if (rc[2].Contains(ptInput))
            {
                ptSnap = new PointF(((m_ptStart.X + m_ptEnd.X) / 2.0f), ((m_ptStart.Y + m_ptEnd.Y) / 2.0f));
                bRet = true;
                return bRet;
            }

            return bRet;
        }
        public override bool IsPointSelect(ref PointF ptSnap, ref int nSnap, PointF ptInput, float fDiatance)
        {
            bool bRet = false;

            RectangleF rcSnap = m_rcBound;
            rcSnap.Inflate(fDiatance, fDiatance);
            if (!rcSnap.Contains(ptInput))
            {
                return bRet;
            }


            RectangleF[] rc = new RectangleF[3];
            rc[0] = new RectangleF(m_ptStart, new SizeF(0,0));
            rc[1] = new RectangleF(m_ptEnd, new SizeF(0, 0));
            rc[2] = new RectangleF(new PointF(((m_ptStart.X + m_ptEnd.X) / 2.0f), ((m_ptStart.Y + m_ptEnd.Y) / 2.0f)), new SizeF(0, 0));

            for (int i = 0; i < 3; i++)
            {
                rc[i].Inflate(fDiatance, fDiatance);
            }


            if (rc[0].Contains(ptInput))
            {
                ptSnap = m_ptStart;
                nSnap = 1;
                bRet = true;
                return bRet;
            }
            else if (rc[1].Contains(ptInput))
            {
                ptSnap = m_ptEnd;
                nSnap = 2;
                bRet = true;
                return bRet;
            }
            else if (rc[2].Contains(ptInput))
            {
                return bRet;
            }

            return bRet;
        }
        public override bool IsStartPointSelect(ref PointF ptRet, PointF ptInput, float fDiatance)
        {
            bool bRet = false;
            RectangleF rcSnap = m_rcBound;
            rcSnap.Inflate(2 * fDiatance, 2 * fDiatance);

            if (!rcSnap.Contains(ptInput))
            {
                return false;
            }

            RectangleF rcStart = new RectangleF();
            rcStart = new RectangleF(m_ptStart, new SizeF(0, 0));
            rcStart.Inflate(fDiatance, fDiatance);
            if (rcStart.Contains(ptInput))
            {
                ptRet = m_ptStart;
                bRet = true;
                return bRet;
            }
            return bRet;
        }

        public void SetStartPoint(PointF ptStart)
        {
            m_ptStart = ptStart;
            UpdateBoundRect();
        }
        public void SetEndPoint(PointF ptEnd)
        {
            m_ptEnd = ptEnd;
            UpdateBoundRect();
        }
        public void SetStartPoint(int x, int y)
        {
            m_ptStart.X = x;
            m_ptStart.Y = y;
            UpdateBoundRect();
        }
        public void SetEndPoint(int x, int y)
        {
            m_ptEnd.X = x;
            m_ptEnd.Y = y;
            UpdateBoundRect();
        }
        public override PointF GetStartPoint()
        {
            return m_ptStart;
        }
        public override PointF GetEndPoint()
        {
            return m_ptEnd;
        }
        public override bool IsObjValid()
        {
            if (m_ptStart == m_ptEnd)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void SetObjDefaultProperty()
        {
            m_colPenColor = Color.FromArgb(0, 0, 0);
        }
    }
    public class CWhLayer : CWhVirtual
    {
        public override void Serialize(ref BinaryFormatter ar)
        {
            CWhVirtual.Serialize(ref ar);
            m_pListLayer.Serialize(ref ar);
            if (ar.IsLoading() != 0)
            {
                ar >> m_strLayerName;
            }
            else
            {
                ar << m_strLayerName;
            }
        }
        public override void UpdateBoundRect()
        {
            m_pListLayer.UpdateBoundRect();
            m_rcBound = m_pListLayer.m_rcBound;
        }
        public override void Move(float nX, float nY)
        {
            CWhVirtual pObj = null;
            if (m_pListLayer.IsEmpty() == 0)
            {
                LinkedListNode<object> pos = m_pListLayer.GetHeadPosition();
                while (pos != null)
                {
                    pObj = m_pListLayer.GetNext(ref pos);

                    pObj.Move(nX, nY);
                }
            }
            UpdateBoundRect();
        }
        public override void DrawHandle(ref Graphics pDC)
        {
            RectangleF rcHandle = new RectangleF(0, 2, 2, 2);
            //pDC.DPtoLP(rcHandle);
            RectangleF rcBoundLog = TransRPtoLP(m_rcBound);
            PointF centerpoint1 = new PointF(rcBoundLog.Left + rcBoundLog.Width / 2, rcBoundLog.Top - rcBoundLog.Height / 2);
            RectangleF[] rcHandPoint = new RectangleF[5];

            rcHandPoint[0]= new RectangleF(rcBoundLog.Left, rcBoundLog.Top, 0, 0);
            rcHandPoint[1]= new RectangleF(rcBoundLog.Right, rcBoundLog.Top, 0, 0);
            rcHandPoint[2]= new RectangleF(rcBoundLog.Right, rcBoundLog.Bottom, 0, 0);
            rcHandPoint[3]= new RectangleF(rcBoundLog.Left, rcBoundLog.Bottom, 0, 0);
            rcHandPoint[4]= new RectangleF(centerpoint1.X, centerpoint1.Y, 0, 0);
            for (int i = 0; i < 5; i++)
            {
                rcHandPoint[i].Inflate(rcHandle.Width, rcHandle.Height);
            }

            Pen pOldPen = null;
            Pen pen = new Pen(Color.FromArgb(255, 0, 0),rcHandle.Width*2);
            pOldPen = pen;
            for (int j = 0; j < 5; j++)
            {
                pDC.DrawRectangle(pen, rcHandPoint[j].X, rcHandPoint[j].Y, rcHandPoint[j].Width, rcHandPoint[j].Height);
            }
        }
        public override void DrawArrow(ref Graphics pDC)
        {

        }
        public override void DrawStartPoint(ref Graphics pDC)
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> pos = m_pListLayer.GetHeadPosition();
            while (pos != null)
            {
                pObj = m_pListLayer.GetNext(ref pos);
                pObj.DrawStartPoint(ref pDC);
            }
        }
        public override void Draw(ref Graphics pDC, RectangleF rcClient)
        {
            if (m_bIsShow)
            {

                RectangleF rcInterSectRect = new RectangleF(0, 0, 0, 0);
                RectangleF rcClientReal = TransDPtoRP(rcClient,ref pDC);
                if (RectangleF.Intersect(m_rcBound, rcClientReal).IsEmpty)
                {
                    return;
                }


                CWhVirtual pObj = null;
                LinkedListNode<object> pos = m_pListLayer.GetHeadPosition();
                while (pos != null)
                {
                    pObj = m_pListLayer.GetNext(ref pos);
                    pObj.Draw(ref pDC, rcClient);
                }


                if (m_bIsShowHandle)
                {
                    DrawHandle(ref pDC);
                }
            }
        }
        public override void DrawNumber(ref Graphics pDC)
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> pos = m_pListLayer.GetHeadPosition();
            while (pos != null)
            {
                pObj = m_pListLayer.GetNext(ref pos);
                pObj.DrawNumber(ref pDC);
            }
        }
        public override PointF GetStartPoint()
        {
            PointF ptRet = new PointF(0, 0);
            CWhVirtual pObj = m_pListLayer.GetHead();
            ptRet = pObj.GetStartPoint();
            return ptRet;
        }
        public override PointF GetEndPoint()
        {
            PointF ptRet = new PointF(0, 0);
            CWhVirtual pObj = m_pListLayer.GetTail();
            ptRet = pObj.GetEndPoint();
            return ptRet;
        }

        public override void SetPenColor(Color colRef)
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListLayer.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListLayer.GetNext(ref posObj);
                pObj.SetPenColor(colRef);
            }
        }
        public override void SetObjDefaultProperty()
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListLayer.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListLayer.GetNext(ref posObj);
                pObj.SetObjDefaultProperty();
            }
        }
        public override void SetMachineCount(int nMachineCount)
        {

            m_nMachineCount = nMachineCount;

            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListLayer.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListLayer.GetNext(ref posObj);
                pObj.SetMachineCount(nMachineCount);
            }
        }
        public override void SetMachineFrequence(int nMachineFrequence)
        {

            m_nMachineFrequence = nMachineFrequence;

            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListLayer.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListLayer.GetNext(ref posObj);
                pObj.SetMachineCount(nMachineFrequence);
            }
        }
        public new void SetMachineStyle(bool bMachineStyle)
        {

            m_bMachineStyle = bMachineStyle;

            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListLayer.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListLayer.GetNext(ref posObj);
                pObj.SetMachineStyle(bMachineStyle);
            }
        }

        public override bool IsSelected(PointF ptClick, int nLimit)
        {
            bool bRet = false;

            RectangleF rcBound = new RectangleF();
            rcBound.Inflate(nLimit, nLimit);
            if (m_pListLayer.IsEmpty() == 0)
            {
                if (rcBound.Contains(ptClick))
                {
                    bRet = true;
                    return bRet;
                }
            }

            return bRet;
        }
        public override bool IsSelected(RectangleF rcClick, int bFlagMode)
        {
            bool bRet = false;
            if (m_pListLayer.IsEmpty() != 0)
            {
                return bRet;
            }            
            if (RectangleF.Intersect(m_rcBound, rcClick).IsEmpty)
            {
                bRet = true;
                return bRet;
            }
            return bRet;
        }
        public override bool IsPointSnap(ref PointF ptSnap, PointF ptInput, float fDiatance)
        {
            bool bRet = false;
            if (m_rcBound.Contains(ptInput))
            {
                bRet = true;
                return bRet;
            }
            return bRet;
        }
        public override bool IsStartPointSelect(ref PointF ptRet, PointF ptInput, float fDiatance)
        {
            bool bRet = false;
            return bRet;
        }

        public CWhListContainer GetListLayer()
        {
            return m_pListLayer;
        }
        public bool FindObject(CWhVirtual pObj)
        {
            return m_pListLayer.FindObject(pObj);
        }
        public CWhVirtual FindObjectFromID(int lID)
        {
            return m_pListLayer.FindObjectFromID(lID);
        }
        public void MoveObjNext(CWhVirtual pObj)
        {
            m_pListLayer.MoveObjNext(pObj);
        }
        public void MoveObjPrev(CWhVirtual pObj)
        {
            m_pListLayer.MoveObjPrev(pObj);
        }

        public void AddObject(CWhVirtual pObj)
        {
            m_pListLayer.AddObject(pObj);
            m_rcBound = m_pListLayer.m_rcBound;
        }
        public void AddObjects(CWhListContainer pListObj)
        {
            m_pListLayer.AddObjects(pListObj);
            m_rcBound = m_pListLayer.m_rcBound;
        }

        public bool RemoveObject(CWhVirtual pObj)
        {
            return RemoveObject(pObj, false);
        }
        public bool RemoveObject(CWhVirtual pObj, bool bFlagDepth = false)
        {
            return m_pListLayer.RemoveObject(pObj, bFlagDepth);
        }
        public void RemoveObjects(CWhListContainer pListObj)
        {
            RemoveObjects(pListObj, false);
        }
        public void RemoveObjects(CWhListContainer pListObj, bool bFlagDepth = false)
        {
            m_pListLayer.RemoveObjects(pListObj, bFlagDepth);
        }
        public void RemoveAll()
        {
            RemoveAll(false);
        }
        public void RemoveAll(bool bFlagDepth = false)
        {
            m_pListLayer.RemoveAll(bFlagDepth);
        }
        public void DeleteObject(CWhVirtual pObj)
        {
            DeleteObject(pObj, false);
        }
        public void DeleteObject(CWhVirtual pObj, bool bFlagDepth = false)
        {
            m_pListLayer.DeleteObject(pObj, bFlagDepth);
        }
        public void DeleteObjects(CWhListContainer pListObj)
        {
            DeleteObjects(pListObj, false);
        }
        public void DeleteObjects(CWhListContainer pListObj, bool bFlagDepth = false)
        {
            m_pListLayer.DeleteObjects(pListObj, bFlagDepth);
        }
        public void DeleteAll()
        {
            DeleteAll(false);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void DeleteAll(int bFlagDepth)
        public void DeleteAll(bool bFlagDepth = false)
        {
            m_pListLayer.DeleteAll(bFlagDepth);
        }

        public void SetLayerName(string strLayerName)
        {
            m_strLayerName = strLayerName;
        }
        public string GetLayerName()
        {
            return m_strLayerName;
        }

        public CWhListContainer m_pListLayer;
        public string m_strLayerName;
    }
    public class CWhGroup : CWhVirtual
    {
        
        public override void Serialize(ref BinaryFormatter ar)
        {
            CWhVirtual.Serialize(ref ar);
            m_pListGroup.Serialize(ref ar);
            if (ar.IsStoring() != 0)
            {
                ar << m_rcGridBound;
            }
            else
            {
                ar >> m_rcGridBound;
            }
        }
        public override void UpdateBoundRect()
        {
            m_pListGroup.UpdateBoundRect();
            m_rcBound = m_pListGroup.m_rcBound;
        }
        public override void Move(float nX, float nY)
        {
            CWhVirtual pObj = null;
            if (m_pListGroup.IsEmpty() == 0)
            {
                LinkedListNode<object> pos = m_pListGroup.GetHeadPosition();
                while (pos != null)
                {
                    pObj = m_pListGroup.GetNext(ref pos);

                    pObj.Move(nX, nY);
                }
            }
            UpdateBoundRect();
        }
        public override void DrawHandle(ref Graphics pDC)
        {
            CWhVirtual pObjFirst = m_pListGroup.GetHead();
            CWhVirtual pObjEnd = m_pListGroup.GetTail();
            PointF ptStart = new PointF();
            PointF ptEnd = new PointF();
            ptStart = TransRPtoLP(pObjFirst.GetStartPoint());
            ptEnd = TransRPtoLP(pObjEnd.GetEndPoint());
            RectangleF rcHandle = new RectangleF(0, 2, 2, 2);
            //pDC.DPtoLP(rcHandle);
            RectangleF rcStart = new RectangleF(ptStart.X, ptStart.Y, 0, 0);
            RectangleF rcEnd = new RectangleF(ptEnd.X, ptEnd.Y, 0, 0);
            rcStart.Inflate(rcHandle.Width, rcHandle.Height);
            rcEnd.Inflate(rcHandle.Width, rcHandle.Height);
            Pen pOldPen = null;
            Pen pen = new Pen(Color.FromArgb(0, 0, 255),rcHandle.Width*2);
            pOldPen = pen;
            pDC.DrawRectangle(pen, rcEnd.X, rcEnd.Y, rcEnd.Width, rcEnd.Height);
            Pen pOldPen1 = null;
            Pen pen1 = new Pen(Color.FromArgb(255, 0, 0),rcHandle.Width*2);
            pOldPen1 = pen1;
            pDC.DrawRectangle(pen, rcStart.X, rcStart.Y, rcStart.Width, rcStart.Height);
        }
        public override void DrawArrow(ref Graphics pDC)
        {

        }
        public override void DrawStartPoint(ref Graphics pDC)
        {
            CWhVirtual pObjStart = m_pListGroup.GetHead();
            if (pObjStart != null)
            {
                pObjStart.DrawStartPoint(ref pDC);
            }
        }
        public override void DrawNumber(ref Graphics pDC)
        {
            CWhVirtual pObjFirst = m_pListGroup.GetHead();
            string strNum;
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            strNum = string.Format("%d", m_lID);
            PointF pt = TransRPtoLP(pObjFirst.GetStartPoint());
            pDC.DrawString(strNum, drawFont, drawBrush,pt.X, pt.Y);
        }
        public override void Draw(ref Graphics pDC, RectangleF rcClient)
        {
            if (m_bIsShow)
            {
                RectangleF rcInterSectRect = new RectangleF(0, 0, 0, 0);
                RectangleF rcClientReal = TransDPtoRP(rcClient,ref pDC);
                if (RectangleF.Intersect(m_rcBound, rcClientReal).IsEmpty)
                {
                    return;
                }
                CWhVirtual pObj = null;
                LinkedListNode<object> pos = m_pListGroup.GetHeadPosition();
                while (pos != null)
                {
                    pObj = m_pListGroup.GetNext(ref pos);
                    pObj.Draw(ref pDC, rcClient);
                }
                if (m_bIsShowHandle)
                {
                    DrawHandle(ref pDC);
                }
            }
        }
        public override void ExchangeStartToEnd()
        {

            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                pObj.ExchangeStartToEnd();
            }

            m_pListGroup.AntiList();
        }
        public override PointF GetStartPoint()
        {
            PointF ptRet = new PointF(0, 0);
            CWhVirtual pObj = m_pListGroup.GetHead();
            ptRet = pObj.GetStartPoint();
            return ptRet;
        }
        public override PointF GetEndPoint()
        {
            PointF ptRet = new PointF(0, 0);
            CWhVirtual pObj = m_pListGroup.GetTail();
            ptRet = pObj.GetEndPoint();
            return ptRet;
        }

        public override void SetPenColor(Color colRef)
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                pObj.SetPenColor(colRef);
            }
        }
        public override void SetObjDefaultProperty()
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                pObj.SetObjDefaultProperty();
            }
        }
        public override void SetMachineCount(int nMachineCount)
        {

            m_nMachineCount = nMachineCount;

            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                pObj.SetMachineCount(nMachineCount);
            }
        }
        public override void SetMachineFrequence(int nMachineFrequence)
        {

            m_nMachineFrequence = nMachineFrequence;

            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                pObj.SetMachineCount(nMachineFrequence);
            }
        }
        public override void SetMachineStyle(bool bMachineStyle)
        {

            m_bMachineStyle = bMachineStyle;

            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                pObj.SetMachineStyle(bMachineStyle);
            }
        }

        public override bool IsSelected(PointF ptClick, int nLimit)
        {
            bool bRet = false;
            if (m_pListGroup.IsEmpty() == 0)
            {

                RectangleF rcBound = new RectangleF();
                rcBound.Inflate(nLimit, nLimit);

                if (rcBound.Contains(ptClick))
                {

                    CWhVirtual pObjSelect = null;
                    LinkedListNode<object> posSelect = m_pListGroup.GetHeadPosition();
                    while (posSelect != null)
                    {
                        pObjSelect = m_pListGroup.GetNext(ref posSelect);

                        if (!pObjSelect.IsSelected(ptClick, nLimit))
                        {
                            bRet = true;
                            return bRet;
                        }
                    }
                }
            }

            return bRet;
        }
        public override bool IsSelected(RectangleF rcClick, int bFlagMode)
        {
            bool bRet = false;
            RectangleF rcInterSectRect = new RectangleF(0, 0, 0, 0);

            if (bFlagMode == -1)
            {
                if (!RectangleF.Intersect(m_rcBound, rcClick).IsEmpty)
                {
                    CWhVirtual pObjSelect = null;
                    LinkedListNode<object> posSelect = m_pListGroup.GetHeadPosition();
                    while (posSelect != null)
                    {
                        pObjSelect = m_pListGroup.GetNext(ref posSelect);

                        if (!pObjSelect.IsSelected(rcClick, bFlagMode))
                        {
                            bRet = true;
                            return bRet;
                        }
                    }
                }
            }
            else if (bFlagMode == 1)
            {
                rcInterSectRect = RectangleF.Intersect(m_rcBound, rcClick);
                if (rcInterSectRect == m_rcBound)
                {
                    bRet = true;
                    return bRet;
                }
            }
            return bRet;
        }
        public override bool IsPointSnap(ref PointF ptSnap, PointF ptInput, float fDiatance)
        {
            bool bRet = false;
            if (m_rcBound.Contains(ptInput))
            {
                bRet = true;
                return bRet;
            }
            return bRet;
        }
        public override bool IsStartPointSelect(ref PointF ptRet, PointF ptInput, float fDiatance)
        {
            bool bRet = false;
            RectangleF rcSnap = m_rcBound;
            rcSnap.Inflate(2 * fDiatance, 2 * fDiatance);

            if (!rcSnap.Contains(ptInput))
            {
                return false;
            }

            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListGroup.GetHeadPosition();
            pObj = m_pListGroup.GetNext(ref posObj);
            if (!pObj.IsStartPointSelect(ref ptRet, ptInput, fDiatance))
            {
                bRet = true;
                return bRet;
            }
            return bRet;
        }

        public bool FindObject(CWhVirtual pObj)
        {
            return m_pListGroup.FindObject(pObj);
        }
        public CWhListContainer GetListGroup()
        {
            return m_pListGroup;
        }

        public void AddObject(CWhVirtual pObj)
        {
            m_pListGroup.AddObject(pObj);
            m_rcBound = m_pListGroup.m_rcBound;
        }
        public void AddObjects(CWhListContainer pListObj)
        {
            m_pListGroup.AddObjects(pListObj);
            m_rcBound = m_pListGroup.m_rcBound;
        }

        public bool RemoveObject(CWhVirtual pObj)
        {
            return RemoveObject(pObj, false);
        }
        public bool RemoveObject(CWhVirtual pObj, bool bFlagDepth = false)
        {
            return m_pListGroup.RemoveObject(pObj, bFlagDepth);
        }
        public void RemoveObjects(CWhListContainer pListObj)
        {
            RemoveObjects(pListObj, false);
        }
        public void RemoveObjects(CWhListContainer pListObj, bool bFlagDepth = false)
        {
            m_pListGroup.RemoveObjects(pListObj, bFlagDepth);
        }
        public void RemoveAll()
        {
            RemoveAll(false);
        }
        public void RemoveAll(bool bFlagDepth = false)
        {
            m_pListGroup.RemoveAll(bFlagDepth);
        }
        public void DeleteObject(CWhVirtual pObj)
        {
            DeleteObject(pObj, false);
        }
        public void DeleteObject(CWhVirtual pObj, bool bFlagDepth = false)
        {
            m_pListGroup.DeleteObject(pObj, bFlagDepth);
        }
        public void DeleteObjects(CWhListContainer pListObj)
        {
            DeleteObjects(pListObj, false);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void DeleteObjects(CWhListContainer pListObj, bool bFlagDepth = false)
        public void DeleteObjects(CWhListContainer pListObj, bool bFlagDepth = false)
        {
            m_pListGroup.DeleteObjects(pListObj, bFlagDepth);
        }
        public void DeleteAll()
        {
            DeleteAll(false);
        }
        public void DeleteAll(bool bFlagDepth = false)
        {
            m_pListGroup.DeleteAll(bFlagDepth);
        }
        public void ConnectHeadToEnd()
        {

        }
        public void Apart()
        {
            CWhVirtual pObj = null;
            LinkedListNode<object> posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                m_pParentList.AddObject(pObj);

                pObj.m_pParentList = m_pParentList;
            }
        }

        public CWhListContainer m_pListGroup;
        public RectangleF m_rcGridBound = new RectangleF();
        public string m_strParentLayerName;
    }
    public class CWhEllipse : CWhVirtual
    { //圆和矩形,椭圆类
       
        public CWhEllipse(RectangleF rcEllipse, int nTypeObj=0)
        {
            m_nObjType = DefineConstantsFdxf.WH_TYPE_ELLIPSE;
            m_nEllipseType = nTypeObj;

            m_rcBound = rcEllipse;
            m_nRadium = ((m_rcBound.Width + m_rcBound.Height) / 4);
            SetObjDefaultProperty();
        }

        public float m_nRadium;
        public int m_nEllipseType;

        public override void Serialize(ref BinaryFormatter ar)
        {
            CWhVirtual.Serialize(ref ar);

            if (ar.IsStoring() != 0)
            {
                ar << m_nEllipseType << m_nRadium;
            }
            else
            {
                ar >> m_nEllipseType >> m_nRadium;
            }
        }
        public override void UpdateBoundRect()
        {
            //m_rcBound.NormalizeRect();
            m_nRadium = ((m_rcBound.Width + m_rcBound.Height) / 4);
        }
        public override void Draw(ref Graphics pDC, RectangleF rcClient)
        {
            if (m_bIsShow)
            {
                RectangleF rcInterSectRect = new RectangleF(0, 0, 0, 0);
                RectangleF rcClientReal = TransDPtoRP(rcClient,ref pDC);
                if (RectangleF.Intersect(m_rcBound, rcClientReal).IsEmpty)
                {
                    return;
                }
                RectangleF rcEllipse = new RectangleF();
                rcEllipse = TransRPtoLP(m_rcBound);
                Pen pOldPen = null;
                Pen penEllipse = new Pen(m_colPenColor,m_nPenWidth);
                pOldPen = penEllipse;
                if (m_nEllipseType == 0)
                {
                    pDC.DrawEllipse(penEllipse, rcEllipse);
                }
                else if (m_nEllipseType == 1)
                {
                    pDC.DrawRectangle(penEllipse, rcEllipse.X, rcEllipse.Y, rcEllipse.Width, rcEllipse.Height);
                }
            }
        }
        public override void DrawHandle(ref Graphics pDC)
        {
            RectangleF rcBound = new RectangleF();

            rcBound = TransRPtoLP(m_rcBound);

            RectangleF rcHandle = new RectangleF(0, 2, 2, 2);
            //pDC.DPtoLP(rcHandle);
            RectangleF rcBottom = new RectangleF((float)((rcBound.Left + rcBound.Right) / 2), rcBound.Bottom, 0, 0);
            RectangleF rcCenter = new RectangleF( new PointF(rcBound.Right-rcBound.Width/2, rcBound.Top - rcBound.Height / 2),new SizeF(0,0));
            rcBottom.Inflate(rcHandle.Width, rcHandle.Height);
            rcCenter.Inflate(rcHandle.Width, rcHandle.Height);
            //设置画笔
            Pen pOldPen = null;
            Pen pen = new Pen(Color.FromArgb(0, 0, 255),rcHandle.Width*2);
            pOldPen = pen;
            pDC.DrawRectangle(pen, rcCenter.X, rcCenter.Y, rcCenter.Width, rcCenter.Height);
            //设置画笔
            Pen pOldPen1 = null;
            Pen pen1 = new Pen(Color.FromArgb(255, 0, 0),rcHandle.Width*2);
            pOldPen1 = pen1;
            pDC.DrawRectangle(pen, rcBottom.X, rcBottom.Y, rcBottom.Width, rcBottom.Height);
        }
        public override void DrawArrow(ref Graphics pDC)
        {

        }
        public override void DrawStartPoint(ref Graphics pDC)
        {
            PointF ptStart = new PointF(0, 0);
            if (m_nEllipseType == 0)
            {
                ptStart = new  PointF(m_rcBound.Left+m_rcBound.Width/2, m_rcBound.Top);
            }
            else if (m_nEllipseType == 1)
            {
                ptStart = new PointF(m_rcBound.Top, m_rcBound.Left);
            }

            ptStart = TransRPtoLP(ptStart);

            RectangleF rcHandle = new RectangleF(0, 3, 3, 3);
            //pDC.DPtoLP(rcHandle);
            RectangleF rcStart = new RectangleF(ptStart.X, ptStart.Y, 0, 0);
            rcStart.Inflate(rcHandle.Width, rcHandle.Height);

            //设置画笔
            Pen pOldPen = null;
            Pen pen = new Pen(Color.FromArgb(255, 0, 0),0);
            pOldPen = pen;
            pDC.DrawRectangle(pen, rcStart.X, rcStart.Y, rcStart.Width, rcStart.Height);
        }
        public override void DrawNumber(ref Graphics pDC)
        {

            PointF ptStart = new PointF();
            if (m_nEllipseType == 0)
            {
                ptStart = new  PointF(m_rcBound.Left + m_rcBound.Width / 2, m_rcBound.Top);
            }
            else if (m_nEllipseType == 1)
            {
                ptStart = new  PointF(m_rcBound.Top, m_rcBound.Left);
            }

            
            string strNum;
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            strNum = string.Format("%d", m_lID);
            PointF pt = TransRPtoLP(ptStart);
            pDC.DrawString(strNum, drawFont, drawBrush, pt.X, pt.Y);
        }
        public override bool IsValid()
        {
            return true;
        }
        public override void Move(float nX, float nY)
        {
            PointF ptMove = new PointF(nX, nY);
            m_rcBound.Offset(ptMove);
            UpdateBoundRect();
        }

        public float GetRadium()
        {
            return m_nRadium = ((m_rcBound.Width + m_rcBound.Height) / 4);
        }
        public void SetEllipseType(int nEllipseType)
        {
            m_nEllipseType = nEllipseType;
        }
        public int GetEllipseType()
        {
            return m_nEllipseType;
        }

        public override bool IsSelected(PointF ptClick, int nLimit)
        {
            bool bRet = false;
            float nDistance = 0;

            RectangleF rcBound = new RectangleF();
            rcBound.Inflate(nLimit, nLimit);

            if (rcBound.Contains(ptClick))
            {
                if (m_bIsFilled)
                {
                    bRet = true;
                    return bRet;
                }

                if (m_nEllipseType == 0)
                {
                    PointF centerpoint1 = new PointF(m_rcBound.Left + m_rcBound.Width / 2, m_rcBound.Top - m_rcBound.Height / 2);
                    nDistance = CWhSysFunction.PointToPointDistance(centerpoint1, ptClick);
                    if ((nDistance <= m_nRadium + nLimit) && (nDistance) >= m_nRadium - nLimit)
                    {
                        bRet = true;
                        return bRet;
                    }
                }
                else if (m_nEllipseType == 1)
                {

                    RectangleF rcOut = new RectangleF();
                    RectangleF rcIn = new RectangleF();
                    rcOut.Inflate(nLimit, nLimit);
                    rcIn.Inflate(-nLimit, -nLimit);
                    if ((rcOut.Contains(ptClick)) && (!rcIn.Contains(ptClick)))
                    {
                        bRet = true;
                        return bRet;
                    }
                }
            }

            return bRet;
        }
        public override bool IsSelected(RectangleF rcClick, int bFlagMode)
        {
            bool bRet = false;
            RectangleF rcInterSectRect = new RectangleF(0, 0, 0, 0);

            if (bFlagMode == -1)
            {
                if (!RectangleF.Intersect(m_rcBound, rcClick).IsEmpty)
                {
                    bRet = true;
                    return bRet;
                }
            }
            else if (bFlagMode == 1)
            {
                rcInterSectRect = RectangleF.Intersect(m_rcBound, rcClick);
                if (rcInterSectRect == m_rcBound)
                {
                    bRet = true;
                    return bRet;
                }
            }

            return bRet;
        }
        public override bool IsPointSnap(ref PointF ptSnap, PointF ptInput, float fDiatance)
        {
            bool bRet = false;
            RectangleF rcSnap = m_rcBound;
            rcSnap.Inflate(fDiatance, fDiatance);


            if (!rcSnap.Contains(ptInput))
            {
                return false;
            }

            RectangleF[] rc = new RectangleF[5];

            PointF centerpoint1 = new PointF(m_rcBound.Left + m_rcBound.Width / 2, m_rcBound.Top - m_rcBound.Height / 2);
            rc[0] = new RectangleF(m_rcBound.Left, ((m_rcBound.Bottom + m_rcBound.Top) / 2), 0, 0);
            rc[1] = new RectangleF(m_rcBound.Right, ((m_rcBound.Bottom + m_rcBound.Top) / 2), 0, 0);
            rc[2] = new RectangleF(((m_rcBound.Bottom + m_rcBound.Top) / 2), m_rcBound.Top, 0, 0);
            rc[3] = new RectangleF(((m_rcBound.Bottom + m_rcBound.Top) / 2), m_rcBound.Bottom, 0, 0);
            rc[4] = new RectangleF(centerpoint1, new SizeF(0,0));

            for (int i = 0; i < 5; i++)
            {
                rc[i].Inflate(fDiatance, fDiatance);
            }

            if (rc[0].Contains(ptInput))
            {
                ptSnap = new  PointF(m_rcBound.Left, ((m_rcBound.Bottom + m_rcBound.Top) / 2));
                bRet = true;
                return bRet;
            }
            else if (rc[1].Contains(ptInput))
            {
                ptSnap = new  PointF(m_rcBound.Right, ((m_rcBound.Bottom + m_rcBound.Top) / 2));
                bRet = true;
                return bRet;
            }
            else if (rc[2].Contains(ptInput))
            {
                ptSnap = new PointF(((m_rcBound.Bottom + m_rcBound.Top) / 2), m_rcBound.Top);
                bRet = true;
                return bRet;
            }
            else if (rc[3].Contains(ptInput))
            {
                ptSnap = new PointF(((m_rcBound.Bottom + m_rcBound.Top) / 2), m_rcBound.Bottom);
                bRet = true;
                return bRet;
            }
            else if (rc[4].Contains(ptInput))
            {                
                ptSnap = centerpoint1;
                bRet = true;
                return bRet;
            }

            return bRet;
        }
        public override bool IsStartPointSelect(ref PointF ptRet, PointF ptInput, float fDiatance)
        {
            bool bRet = false;
            RectangleF rcSnap = m_rcBound;
            rcSnap.Inflate(2 * fDiatance, 2 * fDiatance);

            if (!rcSnap.Contains(ptInput))
            {
                return false;
            }

            RectangleF rcStart = new RectangleF();
            if (m_nEllipseType == 0)
            {
                rcStart = new  RectangleF( new PointF(m_rcBound.Left+m_rcBound.Width/2, m_rcBound.Top), new SizeF(0, 0));
            }
            else if (m_nEllipseType == 1)
            {
                rcStart = new  RectangleF( new PointF(m_rcBound.Left,m_rcBound.Top), new  SizeF(0,0));
            }
            rcStart.Inflate(fDiatance, fDiatance);
            if (rcStart.Contains(ptInput))
            {
                ptRet = new PointF(rcStart.Left + rcStart.Width / 2, rcStart.Top- rcStart.Height/2);
                bRet = true;
                return bRet;
            }
            return bRet;
        }

        public override void SetObjDefaultProperty()
        {
            m_colPenColor = Color.FromArgb(0, 255, 0);
            if (!m_bFlagIsRegister)
            {
                m_colBrush = Color.FromArgb(255, 0, 0); //默认的是红色刷子
            }
        }
    }
    public class CWhArc : CWhVirtual
    {
        public RectangleF m_rcBoundDraw = new RectangleF();
        public PointF m_ptStart = new PointF();
        public PointF m_ptEnd = new PointF();
        public PointF m_ptCenter = new PointF();
        public float m_nRadium;
        public int m_nDirection;
        public int m_nGoodOrBad;
        public CWhArc(PointF ptCenter, PointF ptStart, PointF ptEnd, int nDirection)
        {
            m_nObjType = DefineConstantsFdxf.WH_TYPE_ARC;
            m_ptStart = ptStart;
            m_ptEnd = ptEnd;
            m_ptCenter = ptCenter;
            m_nRadium = CWhSysFunction.PointToPointDistance(m_ptCenter, m_ptStart);
            m_rcBoundDraw =new RectangleF(ptCenter.X - m_nRadium, ptCenter.Y - m_nRadium, m_nRadium*2, -m_nRadium*2);
            //m_rcBoundDraw.NormalizeRect();
            m_nDirection = nDirection;
            SetObjDefaultProperty();
            UpdateBoundRect();
        }
        public CWhArc(RectangleF rcBound, PointF ptStart, PointF ptEnd, int nDirection)
        {
            m_nObjType = DefineConstantsFdxf.WH_TYPE_ARC;

            m_rcBoundDraw = rcBound;
            //m_rcBoundDraw.NormalizeRect();
            m_ptStart = ptStart;
            m_ptEnd = ptEnd;
            m_ptCenter =new PointF(m_rcBoundDraw.Left+ m_rcBoundDraw.Width/2, m_rcBoundDraw.Top - m_rcBoundDraw.Height / 2);
            m_nRadium = (float)((m_rcBoundDraw.Width + m_rcBoundDraw.Height) / 4.0);
            m_nDirection = nDirection;

            SetObjDefaultProperty();

            UpdateBoundRect();
        }

        public override void Serialize(ref BinaryFormatter ar)
        {
            CWhVirtual::Serialize(ar);

            if (ar.IsStoring())
            {
                ar << m_ptStart << m_ptEnd << m_ptCenter << m_rcBoundDraw << m_nDirection << m_nGoodOrBad << m_nRadium;
            }
            else
            {
                ar >> m_ptStart >> m_ptEnd >> m_ptCenter >> m_rcBoundDraw >> m_nDirection >> m_nGoodOrBad >> m_nRadium;
            }
        }

        public override void UpdateBoundRect()
        {
            SetRadium();
            m_rcBoundDraw = new RectangleF(m_ptCenter.X - m_nRadium, m_ptCenter.Y - m_nRadium, m_nRadium*2, -m_nRadium*2);

            if (m_nDirection == 1)
            {
                m_rcBound = CalBoundRect(m_ptStart, m_ptEnd, m_ptCenter, m_nDirection, m_nRadium);
            }
            else if (m_nDirection == 2)
            {
                m_rcBound = CalBoundRect(m_ptEnd, m_ptStart, m_ptCenter, 1, m_nRadium);
            }


            //m_rcBound.NormalizeRect();
        }

        public override void Move(float nX, float nY)
        {
            PointF ptMove = new PointF(nX, nY);
            m_ptStart.X += ptMove.X;
            m_ptStart.Y += ptMove.Y;
            m_ptEnd.X += ptMove.X;
            m_ptEnd.Y += ptMove.Y;
            m_ptCenter.X += ptMove.X;
            m_ptCenter.Y += ptMove.Y;
            UpdateBoundRect();
        }

        public override void Draw(ref Graphics pDC, RectangleF rcClient)
        {
            if (m_bIsShow)
            {
                RectangleF rcInterSectRect = new RectangleF(0, 0, 0, 0);
                RectangleF rcClientReal = TransDPtoRP(rcClient,ref pDC);
                rcInterSectRect = RectangleF.Intersect(m_rcBound, rcClientReal);
                if (rcInterSectRect.IsEmpty)
                {
                    return;
                }

                PointF ptStart, ptEnd;
                RectangleF rcBound;

                ptStart = TransRPtoLP(m_ptStart);
                ptEnd = TransRPtoLP(m_ptEnd);
                rcBound = TransRPtoLP(m_rcBoundDraw);


                Pen pOldPen = null;
                Pen penArc;
                penArc = new Pen (m_colPenColor,m_nPenWidth);
                pOldPen = penArc;


                //SetArcDirection(m_nDirection);
                //pDC.MoveTo(ptStart);
                pDC.DrawArc(penArc,rcBound, ptStart, ptEnd);                


                if (m_bIsShowHandle)
                {
                    DrawHandle(ref pDC);
                }
            }
        }

        public override void DrawHandle(ref Graphics pDC)
        {
            PointF ptStart, ptEnd;
            RectangleF rcBound;

            ptStart = TransRPtoLP(m_ptStart);
            ptEnd = TransRPtoLP(m_ptEnd);
            rcBound = TransRPtoLP(m_rcBoundDraw);

            RectangleF rcHandle = new RectangleF(0, 2, 2, 2);
            //pDC->DPtoLP(rcHandle);
            RectangleF rcStart = new RectangleF(ptStart.X, ptStart.Y, 0, 0);
            RectangleF rcEnd = new RectangleF(ptEnd.X, ptEnd.Y, 0, 0);
            PointF CenterPoint1 = new PointF(rcBound.Left + rcBound.Width / 2, rcBound.Top - rcBound.Height / 2);
            RectangleF rcCenter = new RectangleF(CenterPoint1.X, CenterPoint1.Y, 0, 0);
            rcStart.Inflate(rcHandle.Width, rcHandle.Height);
            rcEnd.Inflate(rcHandle.Width, rcHandle.Height);
            Pen pOldPen = null;
            Pen pen;
            pen = new Pen(Color.FromArgb(0, 0, 255), rcHandle.Width * 2 );
            pOldPen = pen;
            pDC.DrawRectangle(pen, rcStart.Left, rcStart.Top, rcStart.Width, rcStart.Height);
            pDC.DrawRectangle(pen, rcEnd.Left, rcEnd.Top, rcEnd.Width, rcEnd.Height);
            Pen pOldPen1 = null;
            Pen pen1;
            pen1 = new Pen(Color.FromArgb(255, 0, 0), rcHandle.Width * 2);
            pOldPen1 = pen1;
            pDC.DrawRectangle(pen1, rcStart.Left, rcStart.Top, rcStart.Width, rcStart.Height);
        }
        public override void DrawArrow(ref Graphics pDC)
        {

        }

        public override void DrawStartPoint(ref Graphics pDC)
        {
            PointF ptStart;

            ptStart = TransRPtoLP(m_ptStart);

            RectangleF rcHandle = new RectangleF(0, 3, 3, 3);
            //pDC->DPtoLP(rcHandle);
            RectangleF rcStart = new RectangleF(ptStart.X, ptStart.Y, 0, 0);
            rcStart.Inflate(rcHandle.Width, rcHandle.Height);            

            Pen pOldPen = null;
            Pen pen;
            pen = new Pen(Color.FromArgb(255, 0, 0),0);
            pOldPen = pen;
            pDC.DrawRectangle(pen, rcStart.Left, rcStart.Top,rcStart.Width,rcStart.Height);
        }
        public override void DrawNumber(ref Graphics pDC)
        {
            string strNum;
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            strNum = string.Format("%d", m_lID);
            PointF pt = TransRPtoLP(m_ptStart);
            pDC.DrawString(strNum, drawFont, drawBrush, pt.X, pt.Y);
        }
        public override bool IsValid()
        {
            if (m_nRadium!=0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
        public override void ExchangeStartToEnd()
        {
            PointF ptTem = new PointF(0, 0);
            ptTem = m_ptStart;
            SetStartPoint(m_ptEnd);
            SetEndPoint(ptTem);
            SetDirection(m_nDirection == 1 ? 2 : 1);
            UpdateBoundRect();
        }

        public override bool IsSelected(PointF ptClick, int nLimit)
        {
            bool bRet = false;
            float nDistance = 0;

            RectangleF rcBound = m_rcBound;
            rcBound.Inflate(nLimit, nLimit);

            if (rcBound.Contains(ptClick))
            {
                if (m_bIsFilled)
                {
                    bRet = true;
                    return bRet;
                }

                nDistance = CWhSysFunction.PointToPointDistance(m_ptCenter, ptClick);
                if ((nDistance <= m_nRadium + nLimit) && (nDistance) >= m_nRadium - nLimit)
                {
                    bRet = true;
                    return bRet;
                }
            }

            return bRet;
        }

        public override bool IsSelected(RectangleF rcClick, int bFlagMode)
        {
            bool bRet = false;
            RectangleF rcInterSectRect = new RectangleF(0, 0, 0, 0);
            rcInterSectRect = RectangleF.Intersect(m_rcBound, rcClick);
            if (bFlagMode == -1)
            {
                if (!rcInterSectRect.IsEmpty)
                {
                    bRet = true;
                    return bRet;
                }
            }
            else if (bFlagMode == 1)
            {
                if (rcInterSectRect == m_rcBound)
                {
                    bRet = true;
                    return bRet;
                }
            }

            return bRet;
        }

        public override bool IsPointSnap(ref PointF ptSnap, PointF ptInput, float fDiatance)
        {
            bool bRet = false;
            RectangleF rcSnap = m_rcBound;
            rcSnap.Inflate(fDiatance, fDiatance);


            if (!rcSnap.Contains(ptInput))
            {
                return false;
            }

            RectangleF[] rc = new RectangleF[3];
            rc[0] = new RectangleF(m_ptStart, new SizeF(0,0));
            rc[1] = new RectangleF(m_ptEnd, new SizeF(0, 0));
            rc[2] = new RectangleF(m_ptCenter, new SizeF(0, 0));

            for (int i = 0; i < 3; i++)
            {
                rc[i].Inflate(fDiatance, fDiatance);
            }

            if (rc[0].Contains(ptInput))
            {
                ptSnap = m_ptStart;
                bRet = true;
                return bRet;
            }
            else if (rc[1].Contains(ptInput))
            {
                ptSnap = m_ptEnd;
                bRet = true;
                return bRet;
            }
            else if (rc[2].Contains(ptInput))
            {
                ptSnap = m_ptCenter;
                bRet = true;
                return bRet;
            }



            return bRet;
        }

        public override bool IsStartPointSelect(ref PointF ptRet, PointF ptInput, float fDiatance)
        {
            bool bRet = false;
            RectangleF rcSnap = m_rcBound;
            rcSnap.Inflate(2 * fDiatance, 2 * fDiatance);

            if (!rcSnap.Contains(ptInput))
            {
                return false;
            }

            RectangleF rcStart;
            rcStart =new RectangleF(m_ptStart,new SizeF(0,0));
            rcStart.Inflate(fDiatance, fDiatance);
            if (rcStart.Contains(ptInput))
            {
                ptRet = m_ptStart;
                bRet = true;
                return bRet;
            }
            return bRet;
        }

        public override bool IsObjValid()
        {
            if (m_nRadium==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SetRadium(float nRadium)
        {
            m_nRadium = nRadium;
        }

        public void SetRadium()
        {
            double fRadium, fLength;

            fLength = ((m_ptCenter.X - m_ptStart.X) /DefineConstantsFdxf.TRANSRATIO) * ((m_ptCenter.X - m_ptStart.X) / DefineConstantsFdxf.TRANSRATIO)
                      + ((m_ptCenter.Y - m_ptStart.Y) / DefineConstantsFdxf.TRANSRATIO) * ((m_ptCenter.Y - m_ptStart.Y) / DefineConstantsFdxf.TRANSRATIO);
            fRadium = System.Math.Sqrt(fLength);
            m_nRadium = (float)(fRadium * DefineConstantsFdxf.TRANSRATIO);
        }

        public float GetRadium()
        {
            return m_nRadium;
        }

        public int GetDirection()
        {
            return m_nDirection;
        }

        public void SetDirection(int nDirection)
        {
            m_nDirection = nDirection;

        }

        public void SetStartPoint(PointF ptStart)
        {

            m_ptStart = ptStart;
        }

        public void SetEndPoint(PointF ptEnd)
        {
                m_ptEnd = ptEnd;
        }

        public override PointF GetStartPoint()
        {
            return m_ptStart;
        }

        public override PointF GetEndPoint()
        {
            return m_ptEnd;
        }

        public void SetCenterPoint(PointF ptCenter)
        {
            m_ptCenter = ptCenter;
        }

        public PointF GetCenterPoint()
        {
            return m_ptCenter;
        }

        public int JustifyArcGoodOrBad()
        {
            return 1;
        }

        public int GetPointInArea(PointF ptInput, PointF ptCenter)
        {
            int nRet = 0;
            PointF ptRealtive =new PointF(ptInput.X - ptCenter.X, ptInput.Y - ptCenter.Y);
            if (ptRealtive.X >= 0.0 && ptRealtive.Y > 0.0)
            {
                nRet = 1;
            }
            else if (ptRealtive.X < 0.0 && ptRealtive.Y >= 0.0)
            {
                nRet = 2;
            }
            else if (ptRealtive.X <= 0.0 && ptRealtive.Y < 0.0)
            {
                nRet = 3;
            }
            else if (ptRealtive.X > 0.0 && ptRealtive.Y <= 0.0)
            {
                nRet = 4;
            }
            return nRet;
        }

        public RectangleF CalBoundRect(PointF ptStart, PointF ptEnd, PointF ptCenter, int nDirection, float nRadium)
        {
            RectangleF rcBoundRet = new RectangleF();
            /////////////////////////////////////////////////////////
            float nl, nr, nt, nb;
            nl = ptCenter.X - nRadium;
            nr = ptCenter.X + nRadium;
            nt = ptCenter.Y - nRadium;
            nb = ptCenter.Y + nRadium;
            if (ptStart == ptEnd)
            {
                rcBoundRet =new RectangleF(ptCenter.X - nRadium, ptCenter.Y - nRadium, nRadium*2, -nRadium * 2);
                if (rcBoundRet.IsEmpty)
                {
                    rcBoundRet.Inflate(rcBoundRet.Width>0 ? 0 : 1, rcBoundRet.Height>0 ? 0 : 1);
                }
                //rcBoundRet.NormalizeRect();
                return rcBoundRet;
            }


            int nAreaStart=0;
            int nAreaEnd=0;
            nAreaStart = GetPointInArea(ptStart, ptCenter);
            nAreaEnd = GetPointInArea(ptEnd, ptCenter);
            if (nDirection == 1)
            {
                if (nAreaStart == 1)
                {
                    if (nAreaEnd == 1)
                    {
                        if (ptStart.X > ptEnd.X)
                        {
                            rcBoundRet = new RectangleF(ptEnd.X, ptStart.Y, ptStart.X- ptEnd.X, ptStart.Y-ptEnd.Y);
                        }
                        else
                        {
                            rcBoundRet = new RectangleF(ptCenter.X - nRadium, ptCenter.Y - nRadium, nRadium * 2, -nRadium * 2);
                        }
                    }
                    else if (nAreaEnd == 2)
                    {
                        rcBoundRet = new RectangleF(ptEnd.X, (ptStart.Y >= ptEnd.Y) ? ptEnd.Y : ptStart.Y, ptStart.X - ptEnd.X, (ptStart.Y >= ptEnd.Y) ? ptEnd.Y-nb : ptStart.Y-nb);
                    }
                    else if (nAreaEnd == 3)
                    {
                        rcBoundRet = new RectangleF(nl, ptEnd.Y, ptStart.X-nl, ptEnd.Y-nb);
                    }
                    else if (nAreaEnd == 4)
                    {
                        rcBoundRet = new RectangleF(nl, nt, (ptStart.X > ptEnd.X) ? ptStart.X-nl : ptEnd.X-nl,nt-nb);
                    }
                }
                else if (nAreaStart == 2)
                {
                    if (nAreaEnd == 1)
                    {
                        rcBoundRet = new RectangleF(nl, nt, nr-nl, (ptStart.Y > ptEnd.Y) ? nt-ptStart.Y : nt-ptEnd.Y);
                    }
                    else if (nAreaEnd == 2)
                    {
                        if (ptStart.X > ptEnd.X)
                        {
                            rcBoundRet = new RectangleF(ptEnd.X, ptEnd.Y, ptStart.X-ptEnd.X, ptEnd.Y-ptStart.Y);
                        }
                        else
                        {
                            rcBoundRet = new RectangleF(ptCenter.X - nRadium, ptCenter.Y - nRadium, nRadium*2, -nRadium * 2);
                        }
                    }
                    else if (nAreaEnd == 3)
                    {
                        rcBoundRet = new RectangleF(nl, ptEnd.Y, (ptStart.X > ptEnd.X) ? ptStart.X-nl : ptEnd.X-nl, ptEnd.Y-ptStart.Y);
                    }
                    else if (nAreaEnd == 4)
                    {
                        rcBoundRet = new RectangleF(nl, nt, ptEnd.X-nl, nt-ptStart.Y);
                    }
                }
                else if (nAreaStart == 3)
                {
                    if (nAreaEnd == 1)
                    {
                        rcBoundRet = new RectangleF(ptStart.X, nt, nr-ptStart.X,nt-ptEnd.Y);
                    }
                    else if (nAreaEnd == 2)
                    {
                        rcBoundRet = new RectangleF((ptStart.X > ptEnd.X) ? ptEnd.X : ptStart.X, nt, (ptStart.X > ptEnd.X) ?nr- ptEnd.X :nr- ptStart.X, nt- nb);
                    }
                    else if (nAreaEnd == 3)
                    {
                        if (ptStart.X > ptEnd.X)
                        {
                            rcBoundRet = new RectangleF(ptCenter.X - nRadium, ptCenter.Y - nRadium, ptCenter.X + nRadium, ptCenter.Y + nRadium);
                        }
                        else
                        {
                            rcBoundRet = new RectangleF(ptStart.X, ptEnd.Y, ptEnd.X-ptStart.X,ptEnd.Y- ptStart.Y);
                        }
                    }
                    else if (nAreaEnd == 4)
                    {
                        rcBoundRet = new RectangleF(ptStart.X, nt, ptEnd.X-ptStart.X, (ptStart.Y > ptEnd.Y) ? nt-ptStart.Y : nt-ptEnd.Y);
                    }
                }
                else if (nAreaStart == 4)
                {
                    if (nAreaEnd == 1)
                    {
                        rcBoundRet = new RectangleF((ptStart.X > ptEnd.X) ? ptEnd.X : ptStart.X, ptStart.Y, (ptStart.X > ptEnd.X) ? nr-ptEnd.X : nr-ptStart.X, ptStart.Y-ptEnd.Y);
                    }
                    else if (nAreaEnd == 2)
                    {
                        rcBoundRet = new RectangleF(ptEnd.X, ptStart.Y, nr-ptEnd.X, ptStart.Y-nb);
                    }
                    else if (nAreaEnd == 3)
                    {
                        rcBoundRet = new RectangleF(nl, (ptStart.Y > ptEnd.Y) ? ptEnd.Y : ptStart.Y, nr-nl, (ptStart.Y > ptEnd.Y) ? ptEnd.Y-nb : ptStart.Y-nb);
                    }
                    else if (nAreaEnd == 4)
                    {
                        if (ptStart.X > ptEnd.X)
                        {
                            rcBoundRet = new RectangleF(ptCenter.X - nRadium, ptCenter.Y - nRadium, nRadium*2,  -nRadium*2);
                        }
                        else
                        {
                            rcBoundRet = new RectangleF(ptStart, new SizeF(ptEnd.X-ptStart.X,ptStart.Y-ptEnd.Y));
                        }
                    }
                }
            }
            else if (m_nDirection == 2)
            {

            }

            return rcBoundRet;
        }

        public override void SetObjDefaultProperty()
        {
            m_colPenColor =Color.FromArgb(0, 0, 255);
        }

    }
    public class CWhDxfClass
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfClass()
        {

        }
        public virtual void Dispose()
        {

        }

    }
    public class tagUpPara
    {
        public PointF centerPoint = new PointF();
        public float fRadium;

        public tagUpPara()
        {
            centerPoint = new PointF(0, 0);
            fRadium = 0;
        }

    }
    public class CWhDxfEntities
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfEntities()
        {
            m_pObjList = null;
            m_pCurrentLayer = null;
            m_nTypeEntities = 0;
            m_bFlagPolyLineStart = false;
            m_nLwPolyCount = 0;

            //临时对象初始化
            m_pTemGroup = null;
            m_pTemLine = null;
            m_pTemArc = null;
            m_pTemRect = null;


            m_fDxfRatio = 1.0f;
            m_nDirection = 1;
            m_ptStart = new PointF(0, 0);
            m_ptEnd = new PointF(0, 0);
            m_ptCenter = new PointF(0, 0);
            m_ptTem = new PointF(0, 0);
            m_ptPre = new PointF(0, 0);
            m_fRadium = 0;
            m_fAngleStart = 0;
            m_fAngleEnd = 0;
            m_fUpAngle = 0;
            m_nDxfCount = 0;
            m_nClosed = 0;
            m_fEllipseRatio = 1.0f;
        }
        public virtual void Dispose()
        {
            m_pCurrentLayer = null;
            m_pTemGroup = null;
            m_pTemLine = null;
            m_pTemArc = null;
            m_pTemRect = null;
        }

        public void SetList(CWhListContainer pObjList)
        {
            m_pObjList = pObjList;
        }
        public void SetEntitiesString(ref tagDXFSTRING strInput)
        {
            m_strEntities.strCode = strInput.strCode;
            m_strEntities.strValue = strInput.strValue;
        }
        public bool JustifyEntitiesType()
        {
            string stringEntitiesName = m_strEntities.strCode;
            string stringEntitiesValue = m_strEntities.strValue;

            if (stringEntitiesName == "0")
            {
                //在下一图元开始前将当前图元加入链表
                AddObject();

                if (stringEntitiesValue == "LINE")
                {
                    m_nTypeEntities = 1;
                    return true;
                }
                else if (stringEntitiesValue == "ARC")
                {
                    m_nTypeEntities = 2;
                    return true;
                }
                else if (stringEntitiesValue == "CIRCLE")
                {
                    m_nTypeEntities = 3;
                    return true;
                }
                else if (stringEntitiesValue == "LWPOLYLINE")
                {
                    m_nTypeEntities = 4;
                    //m_bFlagPolyLineStart = true;

                    //创建一个组并传给m_pTemGroup
                    m_pTemGroup = new CWhGroup();
                    return true;
                }
                else if (stringEntitiesValue == "POLYLINE")
                {
                    m_nTypeEntities = 5;
                    m_bFlagPolyLineStart = true;

                    //创建一个组并传给m_pTemGroup
                    m_pTemGroup = new CWhGroup();
                    return true;
                }
                else if (stringEntitiesValue == "SEQEND")
                {
                    m_nTypeEntities = 5;
                    m_bFlagPolyLineStart = false;
                    return true;
                }
                else if (stringEntitiesValue == "VERTEX")
                {
                    m_nTypeEntities = 6;
                    return true;
                }
                else if (stringEntitiesValue == "PointF")
                {
                    m_nTypeEntities = 7;
                    return true;
                }
                else if (stringEntitiesValue == "ELLIPSE")
                {
                    m_nTypeEntities = 8;
                    return true;
                }
                else
                {
                    m_nTypeEntities = 0;
                    return true;
                }


            }

            bool ret = true;
            switch (m_nTypeEntities)
            {
                case 1:
                    ret = AnalyseLine(ref m_strEntities);

                    break;
                case 2:
                    ret = AnalyseArc(ref m_strEntities);

                    break;
                case 3:
                    ret = AnalyseCircle(ref m_strEntities);

                    break;
                case 4:
                    ret = AnalyseLwPolyLine(ref m_strEntities);

                    break;
                case 5:
                    ret = AnalysePolyLine(ref m_strEntities);

                    break;
                case 6:
                    ret = AnalyseVertex(ref m_strEntities);

                    break;
                case 7:
                    ret = AnalysePoint(ref m_strEntities);

                    break;
                case 8:
                    ret = AnalyseEllipse(ref m_strEntities);
                    break;
            }

            return ret;
        }
        public void ReSetPara()
        {
            m_ptStart = new PointF(0, 0);
            m_ptEnd = new PointF(0, 0);
            m_ptCenter = new PointF(0, 0);
            m_fRadium = 0;
            m_nDirection = 1;
        }

        public bool AnalyseLine(ref tagDXFSTRING strEntities)
        {
            string stringLineName =strEntities.strCode;
            string stringLineValue = strEntities.strValue;

            if (stringLineName == "5" || stringLineName == "330" || stringLineName == "100") //handle ,ignore
            {
                return false;
            }
            else
            if (stringLineName == "8")
            {
                string strLayerName;
                strLayerName=stringLineValue;
                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
                return true;
            }
            else if (stringLineName == "10")
            {
                m_ptStart.X = float.Parse(stringLineValue);
                return true;
            }
            else if (stringLineName == "20")
            {
                m_ptStart.Y = float.Parse(stringLineValue);
                return true;
            }
            else if (stringLineName == "11")
            {
                m_ptEnd.X = float.Parse(stringLineValue);
                return true;
            }
            else if (stringLineName == "21")
            {
                m_ptEnd.Y = float.Parse(stringLineValue);
                return true;
            }
            return true;
        }
        public bool AnalyseArc(ref tagDXFSTRING strEntities)
        {
            string stringArcName = strEntities.strCode;
            string stringArcValue = strEntities.strValue;
            if (stringArcName == "5" || stringArcName == "330" || stringArcName == "100") //handle ,ignore
            {
                return false;
            }
            else if (stringArcName == "8")
            {
                string strLayerName;
                //C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
                strLayerName = stringArcValue;
                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
                return true;
            }
            else if (stringArcName == "10")
            {
                m_ptCenter.X = float.Parse(stringArcValue);
                return true;
            }
            else if (stringArcName == "20")
            {
                m_ptCenter.Y = float.Parse(stringArcValue);
                return true;
            }
            else if (stringArcName == "40")
            {
                m_fRadium = float.Parse(stringArcValue);
                return true;
            }
            else if (stringArcName == "50")
            {
                m_fAngleStart = float.Parse(stringArcValue)/180.0f*DefineConstantsFdxf.PI;
                return true;
            }
            else if (stringArcName == "51")
            {
                m_fAngleEnd = float.Parse(stringArcValue) / 180.0f * DefineConstantsFdxf.PI;
                return true;
            }
            return true;
        }
        public bool AnalyseCircle(ref tagDXFSTRING strEntities)
        {
            string stringCircleName = strEntities.strCode;
            string stringCircleValue = strEntities.strValue;

            if (stringCircleName == "5" || stringCircleName == "330" || stringCircleName == "100") //handle ,ignore
            {
                return false;
            }
            else if (stringCircleName == "8")
            {
                string strLayerName;
                //C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
                strLayerName = stringCircleValue;
                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
            }
            else if (stringCircleName == "10")
            {
                m_ptCenter.X = float.Parse(stringCircleValue);
            }
            else if (stringCircleName == "20")
            {
                m_ptCenter.Y = float.Parse(stringCircleValue);
            }
            else if (stringCircleName == "40")
            {
                m_fRadium = float.Parse(stringCircleValue);
            }
            return true;
        }
        public bool AnalyseRect(ref tagDXFSTRING strEntities)
        {
            return true;
        }
        ///////////////////////////////////////////////////////////////////////////////
        public bool AnalyseLwPolyLine(ref tagDXFSTRING strEntities)
        {
            string stringLwPolyLineName = strEntities.strCode;
            string stringLwPolyLineValue = strEntities.strValue;
            if (stringLwPolyLineName == "5" || stringLwPolyLineName == "330") //handle ,ignore
            {
                return true;
            }
            else if (stringLwPolyLineName == "8")
            {
                string strLayerName;
                strLayerName = stringLwPolyLineValue;

                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
                return true;
            }
            else if (stringLwPolyLineName == "90")
            {
                m_nLwPolyCount = Int32.Parse(stringLwPolyLineValue);
                return true;
            }
            else if (stringLwPolyLineName == "10")
            {
                m_ptTem.X = float.Parse(stringLwPolyLineValue);
                return true;
            }
            else if (stringLwPolyLineName == "20")
            {
                m_ptTem.Y = float.Parse(stringLwPolyLineValue);

                if (m_nDxfCount == 0)
                {
                    m_nDxfCount++;
                    m_ptStart = m_ptTem;
                    m_ptPre = m_ptTem;
                    return true;
                }
                AddObjectWithUpAngle(m_pTemGroup, ref m_ptPre, ref m_ptTem, ref m_fUpAngle);
                m_fUpAngle = 0;
                m_nDxfCount++;
                m_ptPre = m_ptTem;
                return true;
            }
            else if (stringLwPolyLineName == "42" || stringLwPolyLineName == "43")
            {
                m_fUpAngle = float.Parse(stringLwPolyLineValue);
                if (m_fUpAngle > 0)
                {
                    m_nDirection = 1;
                }
                else if (m_fUpAngle < 0)
                {
                    m_nDirection = 2;
                }
                //绝对值
                m_fUpAngle = Math.Abs(m_fUpAngle);

                return true;
            }
            else if (stringLwPolyLineName == "70")
            {
                m_nClosed = Int32.Parse(stringLwPolyLineValue);
                return true;
            }
            return true;
        }
        public bool AnalysePolyLine(ref tagDXFSTRING strEntities)
        {
            string stringPolyLineName = strEntities.strCode;
            string stringPolyLineValue = strEntities.strValue;
            if (stringPolyLineName == "5" || stringPolyLineName == "330" || stringPolyLineName == "100") //handle ,ignore
            {
                return false;
            }
            else if (stringPolyLineName == "8")
            {
                string strLayerName;
                strLayerName = stringPolyLineValue;
                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
                return true;
            }
            else if (stringPolyLineName == "70")
            {
                m_nClosed = Int32.Parse(stringPolyLineValue);
                return true;
            }

            return true;
        }
        public bool AnalyseEllipse(ref tagDXFSTRING strEntities)
        {
            string stringEllipseName = strEntities.strCode;
            string stringEllipseValue = strEntities.strValue;

            if (stringEllipseName == "5" || stringEllipseName == "330" || stringEllipseName == "100") //handle ,ignore
            {
                return false;
            }
            else if (stringEllipseName == "8")
            {
                string strLayerName;
                strLayerName = stringEllipseValue;
                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
                return true;
            }
            else if (stringEllipseName == "10")
            {
                m_ptCenter.X = float.Parse(stringEllipseValue);
            }
            else if (stringEllipseName == "20")
            {
                m_ptCenter.Y = float.Parse(stringEllipseValue);
            }
            else if (stringEllipseName == "11")
            {
                m_ptStart.X = float.Parse(stringEllipseValue);
            }
            else if (stringEllipseName == "21")
            {
                m_ptStart.Y = float.Parse(stringEllipseValue);
            }
            else if (stringEllipseName == "40")
            {
                m_fEllipseRatio = float.Parse(stringEllipseValue);
            }
            else if (stringEllipseName == "41")
            {
                m_fAngleStart = float.Parse(stringEllipseValue);
            }
            else if (stringEllipseName == "42")
            {
                m_fAngleEnd = float.Parse(stringEllipseValue);
            }
            return true;
        }
        public bool AnalyseVertex(ref tagDXFSTRING strEntities)
        {
            string stringVertexName = strEntities.strCode;
            string stringVertexValue = strEntities.strValue;

            if (stringVertexName == "5" || stringVertexName == "330" || stringVertexName == "100") //handle ,ignore
            {
                return false;
            }
            else if (stringVertexName == "10")
            {
                m_ptTem.X = float.Parse(stringVertexValue);
                return true;
            }
            else if (stringVertexName == "20")
            {
                m_ptTem.Y = float.Parse(stringVertexValue);
                if (!m_bFlagPolyLineStart)
                {
                    if (m_nDxfCount == 0)
                    { 
                        m_nDxfCount++;
                        m_ptStart = m_ptTem;
                        m_ptPre = m_ptTem;
                        return true;
                    }
                    if (m_nDxfCount++ >0)
                    {
                        AddObjectWithUpAngle(m_pTemGroup, ref m_ptPre, ref m_ptTem, ref m_fUpAngle);
                        m_fUpAngle = 0;
                    }                    
                    m_ptPre = m_ptTem;
                }
                //////////////////////////////
                return true;
            }
            else if (stringVertexName == "42")
            {
                m_fUpAngle = float.Parse(stringVertexValue);
                if (m_fUpAngle > 0)
                {
                    m_nDirection = 1;
                }
                else if (m_fUpAngle < 0)
                {
                    m_nDirection = 2;
                }
                m_fUpAngle = Math.Abs(m_fUpAngle);
                return true;
            }
            return true;
        }
        public bool AnalysePoint(ref tagDXFSTRING strEntities)
        {
            string stringPointName = strEntities.strCode;
            string stringPointValue = strEntities.strValue;

            if (stringPointName == "5" || stringPointName == "330" || stringPointName == "100") //handle ,ignore
            {
                return false;
            }
            else if (stringPointName == "8")
            {
                string strLayerName;
                strLayerName = stringPointValue;
                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
                return true;
            }
            else if (stringPointName == "10")
            {
                m_ptTem.X = float.Parse(stringPointValue);
                return true;
            }
            else if (stringPointName == "20")
            {
                m_ptTem.Y = float.Parse(stringPointValue);
                return true;
            }
            return true;
        }
        public CWhLayer SearchLayer(ref string strLayerName)
        {
            LinkedListNode<object> posStart = m_pObjList.GetHeadPosition();
            CWhLayer pRtnLayer = null;
            while (posStart != null)
            {
                CWhVirtual pVirtual = (CWhVirtual)m_pObjList.GetNext(ref posStart);
                if (pVirtual.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    if (((CWhLayer)pVirtual).GetLayerName() == strLayerName)
                    {
                        pRtnLayer = (CWhLayer)pVirtual;
                        break;
                    }
                }
            }

            return pRtnLayer;
        }
        public tagUpPara GetArcUpPara(ref PointF ptStart, ref PointF ptEnd, ref float fUpAngle)
        {
            tagUpPara paraRtn = new tagUpPara();
            PointF ptUpPoint = new PointF();
            float Distance1 = (float)System.Math.Sqrt((ptStart.X - ptEnd.X) * (ptStart.X - ptEnd.X) + (ptStart.Y - ptEnd.Y) * (ptStart.Y - ptEnd.Y));
            float fDistance = (Distance1 / 2)  *fUpAngle;
            ptUpPoint = GetUpPoint(ref ptStart, ref ptEnd,ref fDistance);
            PointF[] ptTem = new PointF[3];
            PointF centerPoint = new PointF();
            ptTem[0] = new PointF(ptStart.X, ptStart.Y);
            ptTem[1] = new PointF(ptEnd.X, ptEnd.Y);
            ptTem[2] = new PointF(ptUpPoint.X, ptUpPoint.Y);
            centerPoint = CWhSysFunction.CalCenterPoint(ptTem[0], ptTem[1], ptTem[2]);
            paraRtn.centerPoint = new PointF(centerPoint.X, centerPoint.Y);
            float Distance2 = (float)System.Math.Sqrt((ptEnd.X - paraRtn.centerPoint.X) * (ptEnd.X - paraRtn.centerPoint.X) + (ptEnd.Y - paraRtn.centerPoint.Y) * (ptEnd.Y - paraRtn.centerPoint.Y));
            paraRtn.fRadium = Distance2;
            return paraRtn;
        }
        public PointF GetUpPoint(ref PointF ptStart, ref PointF ptEnd, ref float fDistance)
        {
            PointF ptRet = new PointF();
            PointF pt1 = new PointF();
            PointF pt2 = new PointF();
            PointF ptRelative1 = new PointF();
            PointF ptRelative2 = new PointF();
            float k1 = 0;
            float b2 = 0;
            float a = 0;
            float b = 0;
            float c = 0;
            float fValue = 0;
            float detx = 0;
            float dety = 0;
            float addx = 0;
            float addy = 0;
            float m = 0;

            detx = ptEnd.X - ptStart.X;
            dety = ptEnd.Y - ptStart.Y;
            addx = ptEnd.X + ptStart.X;
            addy = ptStart.Y + ptEnd.Y;

            k1 = dety / detx;
            b2 = ((addy) + (1 / k1) * (addx)) / 2;
            m = (b2 - (addy) / 2);
            a = 1 / (k1 * k1) + 1;
            b = -(addx) - 2 * b2 / k1 + (addy) / k1;
            c = (addx) * (addx) / 4 + (m) * (m) - fDistance  *fDistance;



            if (ptStart.X == ptEnd.X)
            {
                pt1.X = pt1.X - fDistance;
                pt1.Y = (pt1.Y + pt2.Y) / 2;
                pt2.X = pt2.X + fDistance;
                pt2.Y = pt1.Y;
            }
            else
            {
                pt1.X = (float)((-b + Math.Pow((b * b - 4 * a * c), 0.5)) / (2 * a));
                pt1.Y = (float)(-1 / k1*(pt1.X) + b2);
                pt2.X = (float)((-b - Math.Pow((b * b - 4 * a * c), 0.5)) / (2 * a));
                pt2.Y = (float)(-1 / k1*(pt2.X) + b2);
            }
            ptRelative1.X = pt1.X - ptStart.X;
            ptRelative1.Y = pt1.Y - ptStart.Y;
            ptRelative2.X = ptEnd.X - ptStart.X;
            ptRelative2.Y = ptEnd.Y - ptStart.Y;
            fValue = ptRelative1.X * ptRelative2.Y - ptRelative1.Y * ptRelative2.X;
            if (m_nDirection == 1)
            {
                if (fValue > 0)
                {
                    ptRet=pt1;
                }
                else
                {
                    ptRet=pt2;
                }
            }
            else if (m_nDirection == 2)
            {
                if (fValue < 0)
                {
                    ptRet = pt1;
                }
                else
                {
                    ptRet = pt2;
                }
            }

            return ptRet;
        }
        public void AddObject()
        {

            if (m_nTypeEntities == 1)
            {
                m_pTemLine = new CWhLine();
                m_pTemLine.SetStartPoint(m_ptStart);
                m_pTemLine.SetEndPoint(m_ptEnd);

                m_pTemLine.SetIsShow(true);
                m_pTemLine.SetPenWidth(0);
                //////
                m_pCurrentLayer.AddObject(m_pTemLine);
                m_pTemLine = null;

                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 2)
            {
                /////////////////////////////////////////////
                RectangleF rcBound = new RectangleF(new PointF(m_ptCenter.X - m_fRadium, m_ptCenter.Y + m_fRadium), new SizeF(m_fRadium*2, m_fRadium*2));
                PointF ptStart = new PointF((float)(m_fRadium * Math.Cos(m_fAngleStart)), (float)(m_fRadium * Math.Sin(m_fAngleStart)));
                PointF ptEnd = new PointF((float)(m_fRadium * Math.Cos(m_fAngleEnd)), (float)(m_fRadium * Math.Sin(m_fAngleEnd)));
                ptStart.X = ptStart.X + m_ptCenter.X;
                ptStart.Y = ptStart.Y + m_ptCenter.Y;
                ptEnd.X = ptEnd.X + m_ptCenter.X;
                ptEnd.Y = ptEnd.Y + m_ptCenter.Y;

                m_pTemArc = new CWhArc(rcBound, ptStart, ptEnd, m_nDirection);
                Debug.Assert(m_pTemArc.IsValid());
                m_pTemArc.SetDirection(1);

                m_pTemArc.SetIsShow(true);
                m_pTemArc.SetPenWidth(0);
                //////
                m_pCurrentLayer.AddObject(m_pTemArc);
                m_pTemArc = null;
                /////////////////////////////////////////////
                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 3)
            {
                RectangleF rcBound = new RectangleF(new PointF((m_ptCenter.X - m_fRadium), (m_ptCenter.Y + m_fRadium)), new SizeF(m_fRadium*2,m_fRadium*2));
                m_pTemRect = new CWhEllipse(rcBound);

                //m_pTemRect->SetPenColor(COLORREF( Color.FromArgb(255, 0, 0)));     //颜色设置
                m_pTemRect.SetIsShow(true);
                m_pTemRect.SetPenWidth(0);
                //////
                m_pCurrentLayer.AddObject(m_pTemRect);
                m_pTemRect = null;
                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 4)
            {


                if (m_nClosed != 0)
                {
                    AddObjectWithUpAngle(m_pTemGroup, ref m_ptPre, ref m_ptStart, ref m_fUpAngle);
                    m_fUpAngle = 0;
                }
                m_pCurrentLayer.AddObject(m_pTemGroup);
                m_pTemGroup = null;
                m_nDxfCount = 0;
                m_nClosed = 0;
                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 5)
            {
                if (!m_bFlagPolyLineStart)
                {

                }
                else
                {
                    if (m_nClosed != 0)
                    {
                        AddObjectWithUpAngle(m_pTemGroup, ref m_ptPre, ref m_ptStart, ref m_fUpAngle);
                        m_fUpAngle = 0;
                    }
                    m_pCurrentLayer.AddObject(m_pTemGroup);
                    m_pTemGroup = null;
                    m_nDxfCount = 0;
                }
                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 6)
            {
                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 7)
            {
                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 8)
            {
                m_nTypeEntities = 0;
                return;
            }

            return;
        }


        public void AddLastObject()
        {
            AddObject();
        }

        public void AddObjectWithUpAngle(CWhGroup pTemGroup, ref PointF ptStart, ref PointF ptEnd, ref float fUpAngle)
        {
            if (fUpAngle == 1)
            {
                PointF centerPoint = new PointF((ptStart.X + ptEnd.X) / 2, (ptStart.Y + ptEnd.Y) / 2);
                float Distance1 = (float)System.Math.Sqrt((ptStart.X - ptEnd.X) * (ptStart.X - ptEnd.X) + (ptStart.Y - ptEnd.Y) * (ptStart.Y - ptEnd.Y));
                m_fRadium = Distance1 / 2.0f;
                RectangleF rcBound = new RectangleF(new PointF((centerPoint.X - m_fRadium), (centerPoint.Y + m_fRadium)), new SizeF(m_fRadium * 2, m_fRadium * 2));
                m_pTemArc = new CWhArc(rcBound, ptStart, ptEnd, m_nDirection);
                Debug.Assert(m_pTemArc.IsValid());
                m_pTemArc.SetDirection(m_nDirection);

                m_pTemArc.SetIsShow(true);
                m_pTemArc.SetPenWidth(0);
                pTemGroup.AddObject(m_pTemArc);
                m_pTemArc = null;
            }
            else if (fUpAngle == 0)
            {
                m_pTemLine = new CWhLine();
                m_pTemLine.SetStartPoint(ptStart);
                m_pTemLine.SetEndPoint(ptEnd);
                //m_pTemLine->SetPenColor(COLORREF( Color.FromArgb(255, 0, 0)));     //颜色设置
                m_pTemLine.SetIsShow(true);
                m_pTemLine.SetPenWidth(0);
                m_pTemGroup.AddObject(m_pTemLine);
                m_pTemLine = null;
            }
            else
            { //一般情况
                tagUpPara upPara = GetArcUpPara(ref ptStart, ref ptEnd, ref fUpAngle);
                PointF centerPoint = upPara.centerPoint;
                m_fRadium = upPara.fRadium;
                RectangleF rcBound = new RectangleF(new PointF(m_ptCenter.X - m_fRadium, m_ptCenter.Y + m_fRadium), new SizeF(m_fRadium * 2, m_fRadium * 2));
                m_pTemArc = new CWhArc(rcBound, ptStart, ptEnd, m_nDirection);
                Debug.Assert(m_pTemArc.IsValid());
                m_pTemArc.SetDirection(m_nDirection);
                //m_pTemArc->SetPenColor(COLORREF( Color.FromArgb(255, 0, 0)));     //颜色设置
                m_pTemArc.SetIsShow(true);
                m_pTemArc.SetPenWidth(0);
                pTemGroup.AddObject(m_pTemArc);
                m_pTemArc = null;
            }
        }

        public void SetRatio(int fRatio)
        {
            //	if( fRatio == 0 )
            //	{
            //       m_fDxfRatio = 1000  25.4;  //wuhao
            //	}
            //	else if( fRatio == 1 )
            //	{
            //       m_fDxfRatio = 1000  25.4;
            //	}
            //	else if( fRatio == 4 )
            //	{
            //       m_fDxfRatio = 1000;
            //	}
            //	else if( fRatio == 4 )
            //	{
            //       m_fDxfRatio = 1000;
            //	}
        }

        private CWhListContainer m_pObjList;
        private CWhLayer m_pCurrentLayer;
        private CWhGroup m_pTemGroup;

        private CWhLine m_pTemLine;
        private CWhArc m_pTemArc;
        private CWhEllipse m_pTemRect;

        private tagDXFSTRING m_strEntities = new tagDXFSTRING();
        private bool m_bFlagPolyLineStart;
        private int m_nLwPolyCount;
        private int m_nTypeEntities;

        private float m_fDxfRatio;
        private PointF m_ptTem = new PointF();
        private PointF m_ptPre = new PointF();
        private PointF m_ptStart = new PointF();
        private PointF m_ptEnd = new PointF();
        private PointF m_ptCenter = new PointF();
        private float m_fRadium;
        private int m_nDirection;
        private int m_nDxfCount;
        private float m_fAngleStart;
        private float m_fAngleEnd;
        private float m_fUpAngle;
        private int m_nClosed;
        private float m_fEllipseRatio;

    }
    public class CWhDxfHeaders
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfHeaders()
        {
            m_nTypeHeaders = 0;
            m_nUnit = 0;
        }
        public virtual void Dispose()
        {

        }

        public void SetHeadersString(ref tagDXFSTRING strHeaders)
        {
            m_strHeaders.strCode = strHeaders.strCode;
            m_strHeaders.strValue = strHeaders.strValue;
        }
        public bool JustifyHeadersType()
        {

            if (m_strHeaders.strCode == "9")
            {
                if (m_strHeaders.strValue == "$INSUNITS")
                {
                    m_nTypeHeaders = 1;
                    return true;
                }
                else if (m_strHeaders.strValue == "$ANGDIR")
                {
                    m_nTypeHeaders = 2;
                    return true;
                }
                else
                {
                    m_nTypeHeaders = 0;
                    return true;
                }
            }

            switch (m_nTypeHeaders)
            {
                case 1:
                    AnalyseRatio(ref m_strHeaders);
                    break;
                case 2:

                    break;
                case 3:

                    break;

            }

            return true;
        }
        public void AnalyseRatio(ref tagDXFSTRING strHeaders)
        {
            string stringRatioName = strHeaders.strCode;
            string stringRatioValue = strHeaders.strValue;

            if (stringRatioName == "70")
            {                
                m_nUnit = Convert.ToInt32(stringRatioValue);
            }
        }

        public int GetRatio()
        {
            return m_nUnit;
        }

        private tagDXFSTRING m_strHeaders = new tagDXFSTRING();
        private int m_nTypeHeaders;
        private int m_nUnit;

    }
    public class CWhDxfObjects
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfObjects()
        {

        }
        public virtual void Dispose()
        {

        }

    }
    public class CWhDxfParse
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfParse()
        {
            m_pImagicOblist = null;
            m_nFlagGroup = 0;
            m_bFlagSpaceLineCount = false;
            m_bFalgSectionStart = false;
            m_nSectionType = 0;
        }
        public virtual void Dispose()
        {

        }


        public void SetObjList(CWhListContainer pImagicOblist)
        {

            m_pImagicOblist = pImagicOblist;


        }
        public int SetString(ref string strDxfLine)
        {

            if ((strDxfLine == "") && (!m_bFlagSpaceLineCount) && (m_nFlagGroup!=0))
            {
                m_bFlagSpaceLineCount = true;
            }
            else if ((strDxfLine == "") && (m_nFlagGroup==0))
            {
                return 0;
            }

            if (m_nFlagGroup == 0)
            {
                m_strInput.strCode = strDxfLine;
                m_nFlagGroup++;
                m_bFlagSpaceLineCount = false;

                return 0;
            }
            else
            {
                m_strInput.strValue = strDxfLine;
                m_nFlagGroup = 0;

                return 1;
            }
        }
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        //	int JustifyGroupCode();
        public bool JustifyMatch()
        {

            return true;
        }
        public bool JustifyGroupCode()
        {
            string stringGroupName = m_strInput.strCode;
            string stringGroupValue = m_strInput.strValue;
            if (m_nSectionType!=0)
            {
                if (stringGroupName == "0" && stringGroupValue == "SECTION")
                {
                    m_bFalgSectionStart = true;
                    return true;
                }
                else if (m_bFalgSectionStart && stringGroupName == "2" && stringGroupValue == "HEADER")
                {
                    m_nSectionType = 1;
                    return true;
                }
                else if (m_bFalgSectionStart && stringGroupName == "2" && stringGroupValue == "CLASSES")
                {
                    m_nSectionType = 2;
                    return true;
                }
                else if (m_bFalgSectionStart && stringGroupName == "2" && stringGroupValue == "TABLES")
                {
                    m_nSectionType = 3;
                    return true;
                }
                else if (m_bFalgSectionStart && stringGroupName == "2" && stringGroupValue == "BLOCKS")
                {
                    m_nSectionType = 4;
                    return true;
                }
                else if (m_bFalgSectionStart && stringGroupName == "2" && stringGroupValue == "ENTITIES")
                {
                    m_nSectionType = 5;
                    m_DxfEntities.SetList(m_pImagicOblist);
                    m_DxfEntities.SetRatio(m_DxfHeaders.GetRatio());
                    return true;
                }
                else if (m_bFalgSectionStart && stringGroupName == "2" && stringGroupValue == "OBJECTS")
                {
                    m_nSectionType = 6;
                    return true;
                }
                else if (stringGroupName == "0" && stringGroupValue == "EOF")
                {

                    return true;
                }
                else
                {
                    MessageBox.Show("段没开始");
                    return false;
                }                
            }
            else if (m_bFalgSectionStart && stringGroupName == "0" && stringGroupValue == "ENDSEC")
            {
                m_bFalgSectionStart = false;

                ///////////////////////////////
                if (m_nSectionType == 5)
                {
                    m_DxfEntities.AddLastObject();
                }
                ///////////////////////////////

                m_nSectionType = 0;
                return true;
            }


            if (m_nSectionType == 1)
            {
                m_DxfHeaders.SetHeadersString(ref m_strInput);
                if (!m_DxfHeaders.JustifyHeadersType())
                {
                    return false;
                }
                return true;
            }
            else if (m_nSectionType == 2)
            {
                return true;
            }
            else if (m_nSectionType == 3)
            {
                return true;
            }
            else if (m_nSectionType == 4)
                return true;
            else if (m_nSectionType == 5)
            {
                m_DxfEntities.SetEntitiesString(ref m_strInput);
                if (!m_DxfEntities.JustifyEntitiesType())
                {
                    return false;
                }
                return true;
            }

            else if (m_nSectionType == 6)
            {
                return true;
            }

            return true;
        }

        private CWhListContainer m_pImagicOblist;
        private tagDXFSTRING m_strInput = new tagDXFSTRING();
        private int m_nFlagGroup;
        private bool m_bFlagSpaceLineCount;
        private bool m_bFalgSectionStart;
        private int m_nSectionType;

        private CWhDxfHeaders m_DxfHeaders = new CWhDxfHeaders();
        private CWhDxfEntities m_DxfEntities = new CWhDxfEntities();
        private CWhDxfBlocks m_DxfBlocks = new CWhDxfBlocks();
        private CWhDxfObjects m_DxfObjects = new CWhDxfObjects();

    }
    public class CWhDxfTables
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfTables()
        {

        }
        public virtual void Dispose()
        {

        }

    }
    public class CWhDxfBlocks
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfBlocks()
        {

        }

    }

}