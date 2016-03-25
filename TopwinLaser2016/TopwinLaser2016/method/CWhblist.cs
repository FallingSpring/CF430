using System.Drawing;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace TopwinLaser2016
{
    public struct tagDXFSTRING
    {
        string strCode;
        string strValue;

        tagDXFSTRING(string s1,string s2)
        {
            strCode = s1;
            strValue = s2;
        }
    }
    public class CWhListContainer
    {
        CWhListContainer m_pImagicOblist;
        tagDXFSTRING m_strInput;
        int m_nFlagGroup;
        bool m_bFlagSpaceLineCount;
        bool m_bFalgSectionStart;
        int m_nSectionType;
        int a = 0;
        public CWhListContainer()
        {
            m_pImagicOblist = null;
            m_nFlagGroup = 0;
            m_bFlagSpaceLineCount = false;
            m_bFalgSectionStart = false;
            m_nSectionType = 0;
            CWhObjList m_pListContainer = new CWhObjList();
            Rectangle m_rcBound = new Rectangle(0,0,0,0);
        }
    }
    public class CWhObjList:CWhVirtual
    {
    }
    public class CWhCommon : object
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
        public Rectangle m_rcBound = new Rectangle();
        public CWhListContainer m_pParentList;

        public int m_nMachineCount; //加工次数
        public int m_bMachineStyle; //加工方式
        public int m_nMachineFrequence; //加工频率
        public int m_bIsShow;
        public int m_bIsShowHandle;
        public int m_bIsSelect;
        public int m_bIsFilled;

        public int m_nPenWidth; //线宽
        public int m_nPenType; //线型
        public uint m_colPenColor; //颜色

        public int m_nBrushType;
        public uint m_colBrush;
        public int m_bFlagIsRegister;

        public Point TransRPtoLP(Point ptInput)
        {
            Point ptRet = new Point();

            ptRet.X = ptInput.X;
            ptRet.Y = -ptInput.Y;
            return ptRet;
        }
        public Point TransLPtoRP(Point ptInput)
        {
            Point ptRet = new Point();
            ptRet.X = ptInput.X;
            ptRet.Y = -ptInput.Y;
            return ptRet;
        }
        public Point TopLeft(Rectangle rcInput)
        {
            Point oldpoint = new Point();
            oldpoint.X = rcInput.Left;
            oldpoint.Y = rcInput.Top;
            return oldpoint;
        }
        public Rectangle TransRPtoLP(Rectangle rcInput)
        {
            Rectangle rcRet = new Rectangle(TransRPtoLP(TopLeft(rcInput)),rcInput.Size);
            return rcRet;
        }
        public Rectangle TransLPtoRP(Rectangle rcInput)
        {
            Rectangle rcRet = new Rectangle(TransRPtoLP(TopLeft(rcInput)), rcInput.Size);
            return rcRet;
        }
        public Point TransDPtoLP(Point ptInput, ref Graphics pDC)
        {
            Point[] ptRet ={ ptInput,ptInput};
            pDC.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace.Page,System.Drawing.Drawing2D.CoordinateSpace.World,ptRet);
            //pDC.DPtoLP(ptRet);
            return ptRet[0];
        }
        public Rectangle TransDPtoLP(Rectangle rcInput, ref Graphics pDC)
        {
            Rectangle rcRet = rcInput;
            Point[] ptRet = { TopLeft(rcInput), TopLeft(rcInput)};
            ptRet[1].X = rcInput.Right;
            ptRet[1].Y = rcInput.Bottom;
            pDC.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace.Page, System.Drawing.Drawing2D.CoordinateSpace.World, ptRet);
            rcRet = new Rectangle(ptRet[0].X, ptRet[0].Y,ptRet[1].X, ptRet[1].Y);            
            return rcRet;
        }
        public Point TransDPtoRP(Point ptInput, ref Graphics pDC)
        {
            Point ptRet = new Point();
            Point ptTem = new Point();
            ptTem = TransDPtoLP(ptInput, ref pDC);
            ptRet = TransLPtoRP(ptTem);
            return ptRet;
        }
        public Rectangle TransDPtoRP(Rectangle rcInput, ref Graphics pDC)
        {
            Rectangle rcRet = new Rectangle();
            Rectangle rcTem = new Rectangle();
            rcTem = TransDPtoLP(rcInput, ref pDC);
            rcRet = TransLPtoRP(rcTem);
            return rcRet;
        }
               
        public virtual void Serialize(ref BinaryFormatter ar)
        {                       
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
        public virtual void Draw(ref Graphics pDC, Rectangle rcClient)
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
        public virtual void Move(int nX, int nY)
        {

        }
        public virtual void SetIsShowHandle(int bIsShowHandle)
        {
            m_bIsShowHandle = bIsShowHandle;
        }
        public virtual void ExchangeStartToEnd()
        {

        }
        public virtual Point GetStartPoint()
        {
            Point ptRet = new Point(0, 0);
            return ptRet;
        }
        public virtual Point GetEndPoint()
        {
            Point ptRet = new Point(0, 0);
            return ptRet;
        }
        public virtual bool IsObjValid()
        {
            return true;
        }

        public virtual bool IsSelected(Point ptClick, int nLimit)
        {
            return false;
        }
        public virtual bool IsSelected(Rectangle rcClick, int bFlagMode)
        {
            return false;
        }

        public virtual bool IsObjInRect(Rectangle rcClient)
        {
            return IsObjInRect(rcClient,0);
        }
        public virtual bool IsObjInRect(Rectangle rcClient, int bFlagDepth)
        {
            Rectangle rcInterSectRect = new Rectangle(0, 0, 0, 0);
            rcInterSectRect = Rectangle.Intersect(m_rcBound, rcClient);
            if (!rcInterSectRect.IsEmpty)
            {
                return true;
            }
            return false;
        }
        public virtual bool IsPointSnap(ref Point ptSnap, Point ptInput, double fDiatance)
        {
            bool bRet = false;
            return bRet;
        }
        public virtual bool IsPointSelect(ref Point ptSnap, ref int nSnap, Point ptInput, double fDiatance)
        {
            return false;
        }
        public virtual bool IsStartPointSelect(ref Point ptRet, Point ptInput, double fDiatance)
        {
            return false;
        }

        public virtual void SetObjDefaultProperty()
        {

        }
        public virtual void SetPenColor(uint colRef)
        {
            m_colPenColor = colRef;
        }
        public virtual void SetBrushColor(uint colRef)
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
        public void SetIsShow(int bIsShow)
        {
            m_bIsShow = bIsShow;
        }
        public int GetIsShow()
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
        public uint GetPenColor()
        {
            return m_colPenColor;
        }
        public void SetIsFilled(int bIsFilled)
        {
            m_bIsFilled = bIsFilled;
        }
        public void SetMachineStyle(int bMachineStyle)
        {
            m_bMachineStyle = bMachineStyle;
        }
        public int GetMachineStyle()
        {
            return m_bMachineStyle;
        }
    }
    public class CWhSysFunction 
    {
        public static int PointToLineDistance(Point pt1, Point pt2, Point pt3)
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
                return (int)System.Math.Abs(pt1.X - pt3.X);
            }
            else if (pt1.Y == pt2.Y)
            {
                return (int)System.Math.Abs(pt1.Y - pt3.Y);
            }


            double k1 = 0.0;
            double k2 = 0.0;
            double x1 = 0.0;
            double y1 = 0.0;
            double x2 = 0.0;
            double y2 = 0.0;
            double x3 = 0.0;
            double y3 = 0.0;
            double xt = 0.0;
            double yt = 0.0;
            double fDistance = 0.0;
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
            fDistance = System.Math.Sqrt(fDistance);
            fDistance *= DefineConstantsFdxf.TRANSRATIO;

            return (int)fDistance;
        }

        public static int PointToPointDistance(Point pt1, Point pt2)
        {
            double x1 = 0.0;
            double y1 = 0.0;
            double x2 = 0.0;
            double y2 = 0.0;
            double fDistance = 0.0;
            x1 = pt1.X / DefineConstantsFdxf.TRANSRATIO;
            y1 = pt1.Y / DefineConstantsFdxf.TRANSRATIO;
            x2 = pt2.X / DefineConstantsFdxf.TRANSRATIO;
            y2 = pt2.Y / DefineConstantsFdxf.TRANSRATIO;

            fDistance = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
            fDistance = System.Math.Sqrt(fDistance);
            fDistance *= DefineConstantsFdxf.TRANSRATIO;

            return (int)fDistance;
        }

        public static Point CalCenterPoint(Point pt1, Point pt2, Point pt3)
        {
            Point ptRet = new Point(0, 0);
            double k1 = 0.0;
            double k2 = 0.0;
            double k_1 = 0.0;
            double k_2 = 0.0;
            double x_1 = 0.0;
            double y_1 = 0.0;
            double x_2 = 0.0;
            double y_2 = 0.0;
            double xret = 0.0;
            double yret = 0.0;

            x_1 = (pt1.X + pt2.X) / 2.0;
            y_1 = (pt1.Y + pt2.Y) / 2.0;
            x_2 = (pt2.X + pt3.X) / 2.0;
            y_2 = (pt2.Y + pt3.Y) / 2.0;

            if ((pt1.X == pt2.X) && (pt2.Y == pt3.Y))
            {
                xret = x_2;
                yret = y_1;
                ptRet.X = (int)(xret);
                ptRet.Y = (int)(yret);
                return ptRet;
            }
            else if ((pt1.Y == pt2.Y) & (pt2.X == pt3.X))
            {
                xret = x_1;
                yret = y_2;
                ptRet.X = (int)(xret);
                ptRet.Y = (int)(yret);
                return ptRet;
            }
            else if (pt1.X == pt2.X)
            {
                yret = y_1;

                k2 = (double)(pt3.Y - pt2.Y) / (double)(pt3.X - pt2.X);
                k_2 = -1 / k2;
                xret = (yret - y_2 + k_2 * x_2) / k_2;
                ptRet.X = (int)(xret);
                ptRet.Y = (int)(yret);
                return ptRet;
            }
            else if (pt1.Y == pt2.Y)
            {
                xret = x_1;

                k2 = (double)(pt3.Y - pt2.Y) / (double)(pt3.X - pt2.X);
                k_2 = -1 / k2;
                yret = k_2 * xret + y_2 - k_2 * x_2;
                ptRet.X = (int)(xret);
                ptRet.Y = (int)(yret);
                return ptRet;
            }
            else if (pt2.X == pt3.X)
            {
                yret = y_2;

                k1 = (double)(pt2.Y - pt1.Y) / (double)(pt2.X - pt1.X);
                k_1 = -1 / k1;
                xret = (yret - y_1 + k1 * x_1) / k1;
                ptRet.X = (int)(xret);
                ptRet.Y = (int)(yret);
                return ptRet;
            }
            else if (pt2.Y == pt3.Y)
            {
                xret = x_2;

                k1 = (double)(pt2.Y - pt1.Y) / (double)(pt2.X - pt1.X);
                k_1 = -1 / k1;
                yret = k_1 * xret + y_1 - k_1 * x_1;
                ptRet.X = (int)(xret);
                ptRet.Y = (int)(yret);
                return ptRet;
            }


            k1 = (double)(pt2.Y - pt1.Y) / (double)(pt2.X - pt1.X);
            k_1 = -1 / k1;
            k2 = (double)(pt3.Y - pt2.Y) / (double)(pt3.X - pt2.X);
            k_2 = -1 / k2;

            xret = (y_2 - y_1 - k_2 * x_2 + k_1 * x_1) / (k_1 - k_2);
            yret = k_1 * xret + y_1 - k_1 * x_1;

            ptRet.X = (int)(xret);
            ptRet.Y = (int)(yret);
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
        public const int NULL = 0;
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
        public const int FALSE = 0;
        public const int TRUE = 1;
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
        public const double PI = 3.14159265358979323846;
        public const double TRANSRATIO = 1000.0;
    }
    public class CWhPointD : CWhVirtual
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhPointD()
        {
            m_fx = 0.0;
            m_fy = 0.0;
        }
        public CWhPointD(ref CWhPointD point)
        {
            m_fx = point.m_fx;
            m_fy = point.m_fy;
        }
        public CWhPointD(double x, double y)
        {
            m_fx = x;
            m_fy = y;
        }
        public CWhPointD(Point point)
        {
            m_fx = point.X;
            m_fy = point.Y;
        }
        public double m_fx;
        public double m_fy;        
        public void CopyFrom(CWhPointD point)
        {
            m_fx = point.m_fx;
            m_fy = point.m_fy;
        }        
        public static CWhPointD operator +(CWhPointD ImpliedObject, CWhPointD point)
        {
            CWhPointD ptRet = new CWhPointD();

            return ptRet;
        }
        public static CWhPointD operator -(CWhPointD ImpliedObject, CWhPointD point)
        {
            CWhPointD ptRet = new CWhPointD();

            return ptRet;
        }

        public double Distance(ref CWhPointD ptInput)
        {
            double fRet = 0.0;

            fRet = (m_fx - ptInput.m_fx) * (m_fx - ptInput.m_fx) + (m_fy - ptInput.m_fy) * (m_fy - ptInput.m_fy);
            fRet = System.Math.Sqrt(fRet);

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
        public static AFX_CORE_DATA CRuntimeClass classclass_name = new AFX_CORE_DATA();
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: virtual CRuntimeClass GetRuntimeClass() const
        public override CRuntimeClass GetRuntimeClass()
        {
            return ((CRuntimeClass)(GlobalMembersWhLine.CWhLine.classCWhLine));
        }
#endif static CObject __stdcall CreateObject(); friend CArchive& __stdcall operator >>(CArchive& ar, CWhLine &pOb); public: CWhLine();
        public CWhLine(CPoint ptStart, CPoint ptEnd)
        {
            m_ptStart = ptStart;
            m_ptEnd = ptEnd;
            m_nObjType = DefineConstantsWhLine.WH_TYPE_LINE;
            SetObjDefaultProperty();
            UpdateBoundRect();
        }
        public override void Dispose()
        {

            base.Dispose();
        }

        public CPoint m_ptStart = new CPoint();
        public CPoint m_ptEnd = new CPoint();

        public void Serialize(ref CArchive ar)
        {
            GlobalMembersWhLine.CWhVirtual.Serialize(ar);

            if (ar.IsStoring() != 0)
            {
                ar << m_ptStart << m_ptEnd;
            }
            else
            {
                ar >> m_ptStart >> m_ptEnd;
            }
        }
        public new void UpdateBoundRect()
        {
            m_rcBound.SetRect(m_ptStart, m_ptEnd);
            m_rcBound.NormalizeRect();
            if (m_rcBound.IsRectEmpty())
            {
                m_rcBound.InflateRect(m_rcBound.Width() ? 0 : 1, m_rcBound.Height() ? 0 : 1);
            }
        }
        public void Draw(ref CDC pDC, CRect rcClient)
        {

            if (m_bIsShow)
            {

                CRect rcInterSectRect = new CRect(0, 0, 0, 0);
                CRect rcClientReal = TransDPtoRP(rcClient, pDC);
                if (!rcInterSectRect.IntersectRect(m_rcBound, rcClientReal))
                {
                    return;
                }

                CPoint ptStart = new CPoint();
                CPoint ptEnd = new CPoint();

                ptStart = TransRPtoLP(m_ptStart);
                ptEnd = TransRPtoLP(m_ptEnd);

                CPen pOldPen = (IntPtr)0;
                CPen penLine = new CPen();
                penLine.CreatePen(PS_SOLID, m_nPenWidth, m_colPenColor);
                pOldPen = pDC.SelectObject(penLine);

                pDC.MoveTo(ptStart);
                pDC.LineTo(ptEnd);
                pDC.SelectObject(pOldPen);

                if (m_bIsShowHandle)
                {
                    DrawHandle(ref pDC);
                }
            }
        }
        public void DrawHandle(ref CDC pDC)
        {
            CPoint ptStart = new CPoint();
            CPoint ptEnd = new CPoint();

            ptStart = TransRPtoLP(m_ptStart);
            ptEnd = TransRPtoLP(m_ptEnd);

            CRect rcHandle = new CRect(0, 0, 2, 2);
            pDC.DPtoLP(rcHandle);
            CRect rcStart = new CRect(ptStart.x, ptStart.y, ptStart.x, ptStart.y);
            CRect rcEnd = new CRect(ptEnd.x, ptEnd.y, ptEnd.x, ptEnd.y);

            rcStart.InflateRect(rcHandle.Width(), rcHandle.Height());
            rcEnd.InflateRect(rcHandle.Width(), rcHandle.Height());


            //设置画笔
            CPen pOldPen = (IntPtr)0;
            CPen pen = new CPen();
            pen.CreatePen(PS_SOLID, rcHandle.Width()  2, RGB(0, 0, 255));
            pOldPen = pDC.SelectObject(pen);
            //pDC->Rectangle(rcStart);
            pDC.Rectangle(rcEnd);
            //还原画笔
            pDC.SelectObject(pOldPen);

            //设置画笔
            CPen pOldPen1 = (IntPtr)0;
            CPen pen1 = new CPen();
            pen1.CreatePen(PS_SOLID, rcHandle.Width()  2, RGB(255, 0, 0));
            pOldPen1 = pDC.SelectObject(pen1);
            pDC.Rectangle(rcStart);
            //还原画笔
            pDC.SelectObject(pOldPen1);
        }
        public void DrawArrow(ref CDC pDC)
        {

        }
        public void DrawStartPoint(ref CDC pDC)
        {
            CPoint ptStart = new CPoint();

            ptStart = TransRPtoLP(m_ptStart);

            CRect rcHandle = new CRect(0, 0, 3, 3);
            pDC.DPtoLP(rcHandle);
            CRect rcStart = new CRect(ptStart.x, ptStart.y, ptStart.x, ptStart.y);
            rcStart.InflateRect(rcHandle.Width(), rcHandle.Height());


            CBrush pOldBrush = (IntPtr)0;
            IntPtr hGdi = GetStockObject(NULL_BRUSH);
            CBrush pBrush = CBrush.FromHandle((IntPtr)hGdi);
            pOldBrush = pDC.SelectObject(pBrush);
            CPen pOldPen = (IntPtr)0;
            CPen pen = new CPen();
            pen.CreatePen(PS_SOLID, 0, RGB(255, 0, 0));
            pOldPen = pDC.SelectObject(pen);
            pDC.Rectangle(rcStart);

            pDC.SelectObject(pOldPen);
            pDC.SelectObject(pOldBrush);
        }
        public new int IsValid()
        {
            if (m_ptStart == m_ptEnd)
            {
                return DefineConstantsWhLine.FALSE;
            }
            return DefineConstantsWhLine.TRUE;
        }
        public new void Move(int nX, int nY)
        {
            CPoint ptMove = new CPoint(nX, nY);
            m_ptStart += ptMove;
            m_ptEnd += ptMove;
            UpdateBoundRect();
        }
        public new void ExchangeStartToEnd()
        {
            CPoint ptTem = new CPoint(0, 0);
            ptTem = m_ptStart;
            SetStartPoint(m_ptEnd);
            SetEndPoint(ptTem);
            UpdateBoundRect();
        }
        public void DrawNumber(ref CDC pDC)
        {
            string strNum;
            strNum.Format("%d", m_lID);
            CPoint pt = TransRPtoLP(m_ptStart);
            pDC.TextOut(pt.x, pt.y, strNum);
        }

        public new int IsSelected(CPoint ptClick, int nLimit)
        {
            int bRet = DefineConstantsWhLine.FALSE;

            CRect rcBound = new CRect(m_rcBound);
            rcBound.InflateRect(nLimit, nLimit); //wuhao

            if (rcBound.PtInRect(ptClick))
            {

                int nDisTance = GlobalMembersWhLine.PointToLineDistance(m_ptStart, m_ptEnd, ptClick);
                if (nDisTance <= nLimit)
                {
                    bRet = DefineConstantsWhLine.TRUE;
                    return bRet;
                }
            }

            return bRet;
        }
        public new int IsSelected(CRect rcClick, int bFlagMode)
        {
            int bRet = DefineConstantsWhLine.FALSE;

            CRect rcBound = new CRect(m_rcBound);
            CRect rcInterSectRect = new CRect(0, 0, 0, 0);
            rcBound.InflateRect(1, 1);

            if (bFlagMode == -1)
            {
                if (rcInterSectRect.IntersectRect(m_rcBound, rcClick))
                {
                    bRet = DefineConstantsWhLine.TRUE;
                    return bRet;
                }
            }
            else if (bFlagMode == 1)
            {
                rcInterSectRect.IntersectRect(m_rcBound, rcClick);
                if (rcInterSectRect == m_rcBound)
                {
                    bRet = DefineConstantsWhLine.TRUE;
                    return bRet;
                }
            }

            return bRet;
        }
        public int IsPointSnap(ref CPoint ptSnap, CPoint ptInput, double fDiatance)
        {
            int bRet = DefineConstantsWhLine.FALSE;
            CRect rcSnap = m_rcBound;
            rcSnap.InflateRect(2 * (int)fDiatance, 2 * (int)fDiatance);


            if (!rcSnap.PtInRect(ptInput))
            {
                return DefineConstantsWhLine.FALSE;
            }

            CRect[] rc = new CRect[3];
            rc[0] = CRect(m_ptStart, m_ptStart);
            rc[1] = CRect(m_ptEnd, m_ptEnd);
            rc[2] = CRect(CPoint((int)((m_ptStart.x + m_ptEnd.x) / 2.0), (int)((m_ptStart.y + m_ptEnd.y) / 2.0)), CPoint((int)((m_ptStart.x + m_ptEnd.x) / 2.0), (int)((m_ptStart.y + m_ptEnd.y) / 2.0)));

            for (int i = 0; i < 3; i++)
            {
                rc[i].InflateRect((int)fDiatance, (int)fDiatance);
            }

            if (rc[0].PtInRect(ptInput))
            {
                ptSnap = m_ptStart;
                bRet = DefineConstantsWhLine.TRUE;
                return bRet;
            }
            else if (rc[1].PtInRect(ptInput))
            {
                ptSnap = m_ptEnd;
                bRet = DefineConstantsWhLine.TRUE;
                return bRet;
            }
            else if (rc[2].PtInRect(ptInput))
            {
                ptSnap = CPoint((int)((m_ptStart.x + m_ptEnd.x) / 2.0), (int)((m_ptStart.y + m_ptEnd.y) / 2.0));
                bRet = DefineConstantsWhLine.TRUE;
                return bRet;
            }

            return bRet;
        }
        public int IsPointSelect(ref CPoint ptSnap, ref int nSnap, CPoint ptInput, double fDiatance)
        {
            int bRet = DefineConstantsWhLine.FALSE;

            CRect rcSnap = m_rcBound;
            rcSnap.InflateRect((int)fDiatance, (int)fDiatance);
            if (!rcSnap.PtInRect(ptInput))
            {
                return bRet;
            }


            CRect[] rc = new CRect[3];
            rc[0] = CRect(m_ptStart, m_ptStart);
            rc[1] = CRect(m_ptEnd, m_ptEnd);
            rc[2] = CRect(CPoint((int)((m_ptStart.x + m_ptEnd.x) / 2.0), (int)((m_ptStart.y + m_ptEnd.y) / 2.0)), CPoint((int)((m_ptStart.x + m_ptEnd.x) / 2.0), (int)((m_ptStart.y + m_ptEnd.y) / 2.0)));

            for (int i = 0; i < 3; i++)
            {
                rc[i].InflateRect((int)fDiatance, (int)fDiatance);
            }


            if (rc[0].PtInRect(ptInput))
            {
                ptSnap = m_ptStart;
                nSnap = 1;
                bRet = DefineConstantsWhLine.TRUE;
                return bRet;
            }
            else if (rc[1].PtInRect(ptInput))
            {
                ptSnap = m_ptEnd;
                nSnap = 2;
                bRet = DefineConstantsWhLine.TRUE;
                return bRet;
            }
            else if (rc[2].PtInRect(ptInput))
            {
                return bRet;
            }

            return bRet;
        }
        public int IsStartPointSelect(ref CPoint ptRet, CPoint ptInput, double fDiatance)
        {
            int bRet = DefineConstantsWhLine.FALSE;
            CRect rcSnap = m_rcBound;
            rcSnap.InflateRect(2 * (int)fDiatance, 2 * (int)fDiatance);

            if (!rcSnap.PtInRect(ptInput))
            {
                return DefineConstantsWhLine.FALSE;
            }

            CRect rcStart = new CRect();
            rcStart = CRect(m_ptStart, m_ptStart);
            rcStart.InflateRect((int)fDiatance, (int)fDiatance);
            if (rcStart.PtInRect(ptInput))
            {
                ptRet = m_ptStart;
                bRet = DefineConstantsWhLine.TRUE;
                return bRet;
            }
            return bRet;
        }

        public void SetStartPoint(CPoint ptStart)
        {
            m_ptStart = ptStart;
            UpdateBoundRect();
        }
        public void SetEndPoint(CPoint ptEnd)
        {
            m_ptEnd = ptEnd;
            UpdateBoundRect();
        }
        public void SetStartPoint(int x, int y)
        {
            m_ptStart.x = x;
            m_ptStart.y = y;
            UpdateBoundRect();
        }
        public void SetEndPoint(int x, int y)
        {
            m_ptEnd.x = x;
            m_ptEnd.y = y;
            UpdateBoundRect();
        }
        public new CPoint GetStartPoint()
        {
            return m_ptStart;
        }
        public new CPoint GetEndPoint()
        {
            return m_ptEnd;
        }
        public new int IsObjValid()
        {
            if (m_ptStart == m_ptEnd)
            {
                return DefineConstantsWhLine.FALSE;
            }
            else
            {
                return DefineConstantsWhLine.TRUE;
            }
        }

        public new void SetObjDefaultProperty()
        {
            m_colPenColor = RGB(0, 0, 0);
        }
    }
}