using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using USBCamera;
using USBCameraAPI = USBCamera.API;
using System.Diagnostics;



namespace CameraView
{
    public partial class FrmView : Form
    {
        #region constvalue
        private const int width = 1280;
        private const int height = 1024;
        private readonly Point ptXRight = new Point(0, height / 2);
        private readonly Point ptXLeft = new Point(width, height / 2);
        private readonly Point ptYTop = new Point(width / 2, 0);
        private readonly Point ptYBoom = new Point(width / 2, height);
        #endregion

        #region 成员变量
        CameraDevice m_Camera = new CameraDevice();
        

        private HV_SNAP_PROC snapCallback = new HV_SNAP_PROC(SnapCallBack);         ///< 回调函数
        private bool m_bIfCameraOpen = false;                                       ///< 是否打开设备
                                                                                    ///
        private bool m_bFlagTypeLocation = true;                                          ///< 手动定位标识
        private List<Point> m_ListPoint = new List<Point>();                        ///< 手动定位点缓存  
        private int m_nDetected = 0;                                                /// 匹配点个数


        private Bitmap m_ImgCache = null;


        private bool bDrawMark = false;
        
        #endregion

        private Topwin.SymphonyAPI.Symphony symphony = Topwin.SymphonyAPI.Symphony.GetInstance();

        public FrmView()


        {
            InitializeComponent();
        }

        private void FrmView_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.AllPaintingInWmPaint, true);
            m_ImgCache = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
        }

        ~FrmView()
        {
            CloseSnap();
        }

        
        #region 相机操作
        private bool OpenSnap()
        {
            bool bOpen = false;
            try
            {
                m_Camera.Initialize();
                System.Diagnostics.Debug.Assert(m_Camera.GetHandle() != IntPtr.Zero);

                HVSTATUS status = USBCameraAPI.HVOpenSnap(m_Camera.GetHandle(), snapCallback, this.Handle);
                USBCameraAPI.HV_VERIFY(status);
                if (USBCameraAPI.HV_SUCCESS(status))
                {
                    bOpen = true;
                }
            }
            catch
            {
                bOpen = false;
            }

            return bOpen;
        }

        private bool StartSnap()
        {
            bool bSnap = false;
            try
            {
                System.Diagnostics.Debug.Assert(m_Camera.GetHandle() != IntPtr.Zero);

                IntPtr[] pBuffers = new IntPtr[1];
                pBuffers[0] = m_Camera.GetRawBuffer();

                HVSTATUS status = USBCameraAPI.HVStartSnap(m_Camera.GetHandle(), pBuffers, 1);
                USBCameraAPI.HV_VERIFY(status);
                if (USBCameraAPI.HV_SUCCESS(status))
                {
                    bSnap = true;
                }
            }
            catch
            {
                bSnap = false;
            }

            return bSnap;
            
        }

        private void StopSnap()
        {
                System.Diagnostics.Debug.Assert(m_Camera.GetHandle() != IntPtr.Zero);
                HVSTATUS status = USBCameraAPI.HVStopSnap(m_Camera.GetHandle());
                USBCameraAPI.HV_VERIFY(status);
                USBCameraAPI.HV_SUCCESS(status);
        }

        private void CloseSnap()
        {
            System.Diagnostics.Debug.Assert(m_Camera.GetHandle() != IntPtr.Zero);
            HVSTATUS status = USBCameraAPI.HVCloseSnap(m_Camera.GetHandle());
            USBCameraAPI.HV_VERIFY(status);
            if (USBCameraAPI.HV_SUCCESS(status))
            {
                m_bIfCameraOpen = false;
            }
            m_Camera.Release();
            
        }

        private void OpenCamera()
        {
            if (!m_bIfCameraOpen)
            {
                OpenSnap();
                StartSnap();
                m_bIfCameraOpen = true;
            }

        }

        private void CloseCamera()
        {
            if (m_bIfCameraOpen)
            {
                m_bIfCameraOpen = false;
                StopSnap();
                CloseSnap();
            }

            this.Invalidate();
        }

        private static bool SnapCallBack(ref HV_SNAP_INFO pInfo)
        {
            FrmView dlg = (FrmView)(Form.FromHandle(pInfo.pParam));
            if (dlg != null)
            {
                dlg.ShowImage();
            }

            return true;
        }
        
        #endregion

        #region 显示
        private void ShowImage()
        {
            try
            {
                m_Camera.SaveImage();
                Graphics gc = Graphics.FromImage(m_ImgCache);
                gc.DrawImage(m_Camera.GetCurrentBMP(), this.ClientRectangle);
                DrawRuler(gc);
                if (bDrawMark)
                {
                    DrawMark(m_ListPoint, gc);
                }
                Graphics g = this.CreateGraphics();

                g.DrawImage(m_ImgCache, this.ClientRectangle);
            }
            catch
            {
                
            }
        }

        private void DrawRuler(Graphics gc)
        {
            Pen pen = new Pen(Color.Blue, 2);
            //x轴
            gc.DrawLine(pen, ptXLeft, ptXRight);
            //y轴
            gc.DrawLine(pen, ptYTop, ptYBoom);

            pen.Color = Color.Red;

            for (int i = 0; i < height / 2; i += 50)
            {
                gc.DrawLine(pen, width / 2 - 5, height / 2 - i, width / 2 + 5, height / 2 - i);
                gc.DrawLine(pen, width / 2 - 5, height / 2 + i, width / 2 + 5, height / 2 + i);
            }

            for (int i = 0; i < width / 2; i+=50)
            {
                gc.DrawLine(pen, width / 2 + i, height / 2 - 5, width / 2 + i, height / 2 + 5);
                gc.DrawLine(pen, width / 2 - i, height / 2 - 5, width / 2 - i, height / 2 + 5);
            }
        }

        private void DrawMark(List<Point> circle, Graphics gc)
        {
            if (!bDrawMark)
            {
                return;
            }

            if (circle.Count < 3)
            {
                MessageBox.Show("三点确定一个圆");
                return;
            }

            Point Center = new Point(0, 0);
            double raduis = 0;
            GetCircle(circle[0], circle[1], circle[2], ref Center, ref raduis); 
            Pen pen = new Pen(Color.Red, 1);
            try
            {
                //画圆
                gc.DrawEllipse(pen, Center.X - (int)raduis, Center.Y - (int)raduis, 2 * (float)raduis, 2 * (float)raduis);
                //画横线
                gc.DrawLine(pen, 0, Center.Y, width, Center.Y);
                //画竖线
                gc.DrawLine(pen, Center.X, 0, Center.X, height);
            }
            catch
            {

            }      
        }

        /// <summary>
        /// 三点确定一个圆
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="point3"></param>
        /// <param name="center">圆心</param>
        /// <param name="raduis">半径</param>
        private void GetCircle(Point point1, Point point2, Point point3, ref Point center, ref double raduis)
        {
            double mat1, mat2, mat3;
            mat1 = ((point2.X * point2.X + point2.Y * point2.Y) - (point1.X * point1.X + point1.Y * point1.Y)) * (2 * (point3.Y - point1.Y)) 
                - ((point3.X * point3.X + point3.Y * point3.Y) - (point1.X * point1.X + point1.Y * point1.Y)) * (2 * (point2.Y - point1.Y));
            
            mat2 = (2 * (point2.X - point1.X)) * ((point3.X * point3.X + point3.Y * point3.Y) - (point1.X * point1.X + point1.Y * point1.Y)) 
                - (2 * (point3.X - point1.X)) * ((point2.X * point2.X + point2.Y * point2.Y) - (point1.X * point1.X + point1.Y * point1.Y));
            
            mat3 = 4 * ((point2.X - point1.X) * (point3.Y - point1.Y) - (point3.X - point1.X) * (point2.Y - point1.Y));

            center.X = (int)(mat1 / mat3);
            center.Y = (int)(mat2 / mat3);

            raduis = Math.Sqrt((double)((point1.X-center.X)*(point1.X-center.X) + (point1.Y-center.Y)*(point1.Y-center.Y))); 

        }

        #endregion

        #region 界面响应


        public Point m_ptMarkCenterPiexl = new Point();
        public double m_fMarkDiameterPiexl = 0.0;
        public double m_fCameraViewRulerUnit = 0.0;

        public int m_nContourRadium = 150;
        public int m_nContourContrast = 5;
        public double m_fContourMaxRatio = 3.0;
        public double m_fContourMinRatio = 0.8;
        public double m_fContourMinScore = 0.8;
        public int m_nFindNum = 2;
        public double m_fFindGredness = 0.9;
        public bool m_bTypeModel = false;
        public int m_nMatchCount = 1;
        public double m_dFirstPointOffsetX = 0.0;
        public double m_dFirstPointOffsetY = 0.0;
        public bool m_bFirstPointOffset = false;


        public Point[] m_ptDetectCross = new Point[3];
        public Rectangle[] m_rcDetectRect = new Rectangle[3];


        private void 相机ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            switch (item.Text)
            {
                case "打开摄像机":
                    OpenCamera();
                    break;
                case "关闭摄像机":
                    CloseCamera();
                    break;
                case "设置相机参数":
                    SetCameraParam();
                    break;
                case "设置相机分辨率与偏置参数":
                    SetCameraResolution();
                    break;
                case "设置自动定位参数":
                    SetAutoLocateParam();
                    break;
                default:

                    break;
            }
        }


        private void SetCameraParam()
        {
            FrmCameraParam frmCP = new FrmCameraParam();
            if (frmCP.ShowDialog() == DialogResult.OK)
            {
                //设置相机参数
                //m_nExposureValue = frmCP.m_nDlgCameraExposure;
                //m_nRedValue = frmCP.m_nDlgCameraBalanceRed;
                //m_nBlueValue = frmCP.m_nDlgCameraBalanceBlue;
                //m_nGreenValue = frmCP.m_nDlgCameraBalanceGreen;

                //SetExposureTime(m_hHV, m_sizeImg.cx, m_nExposureValue, 1000);
                m_Camera.SetExposureTime(frmCP.m_Light, 1000);
            }
        }

        private void SetCameraResolution()
        {
            FrmThickCut frmTC = new FrmThickCut();
            frmTC.m_fDlgMarkCoordinateX = m_ptMarkCenterPiexl.X;
            frmTC.m_fDlgMarkCoordinateY = m_ptMarkCenterPiexl.Y;
            frmTC.m_fDlgMarkDiameterPiexl = m_fMarkDiameterPiexl;

            if (frmTC.ShowDialog() == DialogResult.OK/* && pCNCMC3*/)
            {
                /*
                pCNCMC3->m_fResolution = frmTC.m_fDlgCameraResolution;
                pCNCMC3->m_fOffsetX = frmTC.m_fDlgCameraOffsetX;
                pCNCMC3->m_fOffsetY = frmTC.m_fDlgCameraOffsetY;
                 */
                m_fCameraViewRulerUnit = frmTC.m_fDlgViewRulerUnit;
            }
        }

        private void SetAutoLocateParam()
        {
            FrmAutoLocationParam frmALP = new FrmAutoLocationParam();
            if (frmALP.ShowDialog() == DialogResult.OK)
            {
                m_nContourRadium = frmALP.m_nDlgContourRadium;
                m_nContourContrast = frmALP.m_nDlgContourContrast;
                m_fContourMaxRatio = frmALP.m_fDlgContourMaxRatio;
                m_fContourMinRatio = frmALP.m_fDlgContourMinRatio;
                m_fContourMinScore = frmALP.m_fDlgContourMinScore;
                m_nFindNum = frmALP.m_nDlgFindNum;
                m_fFindGredness = frmALP.m_fDlgFindGredness;
                m_bTypeModel = frmALP.m_bDlgTypeModel;
                m_nMatchCount = frmALP.m_nDlgMatchCount;

                m_bFirstPointOffset = frmALP.m_bFirstPointOffset;
                m_dFirstPointOffsetX = frmALP.m_fFirstPoint_OffsetX;
                m_dFirstPointOffsetY = frmALP.m_fFirstPoint_OffsetY;

                doNetHalcon.CreateModelxld(m_nContourRadium, m_fContourMinRatio, m_fContourMaxRatio, m_nContourContrast);
                /**
                //
                #ifdef XT_USE_HALCON
                        int nRet = gen_circle_contour_xld(&m_ContCircle, m_nContourRadium, m_nContourRadium,
                            m_nContourRadium, 0, 6.28318, "positive", 1);
                        nRet = create_scaled_shape_model_xld(m_ContCircle, "auto", -0.39, 0.79, "auto",
                            m_fContourMinRatio, m_fContourMaxRatio, "auto", "auto", "ignore_local_polarity",
                            m_nContourContrast, &m_ModelID);
                #endif
                **/
            }
        }

        private Rectangle m_rcMarkCircle = new Rectangle();
        private int m_nCountAutoIndex = 0;
        private bool m_bFlagRestAllAuto = false;
        private int m_nCurrentPoint = 0;

        private void 手动定位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            switch (item.Text)
            {
                case "手动定位开始":
                    m_bFlagTypeLocation = false;
                    m_ListPoint.Clear();
                    break;
                case "计算当前Mark点":
                    OnHandlocationCameraOver();
                    break;
                case "下一Mark点":
                    OnMarkNext();
                    break;
                case "建立定位关系":

                    break;
                default:

                    break;
            }
        }

        private void OnHandlocationCameraOver()
        {
            PointF centerAtlPoint =  new PointF(0,0),  curPoint = new PointF(0, 0), relPoint = new PointF(0, 0);
            m_ptMarkCenterPiexl = new Point(m_rcMarkCircle.X + m_rcMarkCircle.Width / 2, m_rcMarkCircle.Y + m_rcMarkCircle.Height / 2);
            m_fMarkDiameterPiexl = m_rcMarkCircle.Width;

            //if (pCNCMC3)
            //{
            //    pCNCMC3->GetAxisPos(AXIS_X, &centerAtlPoint.x);
            //    pCNCMC3->GetAxisPos(AXIS_Y, &centerAtlPoint.y);

            //    relPoint.x = (pCNCMC3->m_fResolution / 1000.0) * (m_ptMarkCenterPiexl.x - (m_sizeImg.cx / 2.0 + pCNCMC3->m_nValueU));
            //    relPoint.y = (pCNCMC3->m_fResolution / 1000.0) * (m_ptMarkCenterPiexl.y - (m_sizeImg.cy / 2.0 + pCNCMC3->m_nValueV));
            //}

            curPoint.X = centerAtlPoint.X + relPoint.X;
            curPoint.Y = centerAtlPoint.Y - relPoint.Y;

            //if (pCNCMC3)
            //{
            //    pCNCMC3->ZigMoveRelativeTo(AXIS_X, AXIS_Y, relPoint.x, -relPoint.y);
            //}

            PointF ptCenterpoint;
            ptCenterpoint = new Point(m_rcMarkCircle.X + m_rcMarkCircle.Width / 2, m_rcMarkCircle.Y + m_rcMarkCircle.Height / 2);
            //if (pCNCMC3)
            //{
            //    m_rcMarkCircle.OffsetRect((((int)(m_sizeImg.cx / 2.0) + pCNCMC3->m_nValueU) - ptCenterpoint.x),
            //                           (((int)(m_sizeImg.cy / 2.0) + pCNCMC3->m_nValueV) - ptCenterpoint.y));
            //}

            //////////////////////////////////////////////////////////////////////////////////////
            //CLaser_CNCDoc* pDoc = NULL;
            //CLaser_CNCView* pView = NULL;
            //CWinApp* pApp = AfxGetApp();
            //POSITION postem = pApp->GetFirstDocTemplatePosition();
            //CDocTemplate* pDocTemp = pApp->GetNextDocTemplate(postem);
            //POSITION posdoc = pDocTemp->GetFirstDocPosition();
            //pDoc = (CLaser_CNCDoc*)pDocTemp->GetNextDoc(posdoc);
            //pView = (CLaser_CNCView*)pDoc->GetLaser_CNCView();

            FrmRegisterPoint dlgMark = new FrmRegisterPoint();
            dlgMark.m_fDlgMarkX = curPoint.X;
            dlgMark.m_fDlgMarkY = curPoint.X;
            dlgMark.m_fDlgMarkDiameterPiexl = m_fMarkDiameterPiexl;
            dlgMark.m_nDlgMarkIndex = m_nCountAutoIndex;
            dlgMark.m_nDlgMarkNumber = m_nCountAutoIndex;
            //if (pCNCMC3)
            //{
            //    dlgMark.m_fDlgMarkDiameter = m_fMarkDiameterPiexl * (pCNCMC3->m_fResolution / 1000.0);
            //}
            if (dlgMark.ShowDialog() == DialogResult.OK)
            {
                m_bFlagRestAllAuto = dlgMark.m_bDlgFlagAuto;
                m_nCountAutoIndex = dlgMark.m_nDlgMarkIndex;

                //if (dlgMark.m_nDlgMarkNumber > pView->m_lTotalCountTransform)
                //{
                //    m_bFlagRestAllAuto = false;
                //    MessageBox.Show("超过已经总注册点数");
                //    return;
                //}

                //if (dlgMark.m_nDlgMarkIndex > pView->m_lTotalCountTransform)
                //{
                //    m_bFlagRestAllAuto = false;
                //    MessageBox.Show("超过已经总注册点数");
                //    return;
                //}

                PointF ptOffset;
                //if (pCNCMC3)
                //{
                //    ptOffset =new Point(pCNCMC3->m_fOffsetX, pCNCMC3->m_fOffsetY);
                //}

                //pView->m_ptDstData[dlgMark.m_nDlgMarkIndex - 1].x = dlgMark.m_fDlgMarkX;
                //pView->m_ptDstData[dlgMark.m_nDlgMarkIndex - 1].y = dlgMark.m_fDlgMarkY;
                //pView->m_ptDstData[dlgMark.m_nDlgMarkIndex - 1] += ptOffset;

                //pView->m_nCountTransform = dlgMark.m_nDlgMarkIndex;

                m_nCurrentPoint = dlgMark.m_nDlgMarkIndex;

                if (m_nCurrentPoint == 1)
                {
                    OnFirstLocatePoint();
                }

                if (m_nCurrentPoint == 2)
                {
                    //pView->m_fAngleRotate = CalRotateAngle(pView->m_ptSrcData[1] - pView->m_ptSrcData[0],
                    //                               pView->m_ptDstData[1] - pView->m_ptDstData[0]);
                }

                //if (dlgMark.m_nDlgMarkIndex == pView->m_lTotalCountTransform)
                //{
                //    pView->EstablishTransform();

                //    m_bFlagRestAllAuto = FALSE;
                //    m_nCountAutoIndex = 1;

                //    OnCloseCamera();

                //    m_rcMarkCircle.SetRectEmpty();
                //    return;
                //}
                //else
                //{
                //    OnMarkNext();
                //}
            }



        }

        private void OnFirstLocatePoint() 
        {
            //if( pCNCMC3 )      
            //{
            //    pCNCMC3->GetAxisPos(AXIS_X, &m_ptFirstLocatePoint.x);
            //    pCNCMC3->GetAxisPos(AXIS_Y, &m_ptFirstLocatePoint.y);
            //}
        }

        private  double CalRotateAngle(PointF ptRelative1, PointF ptRelative2)
        {
	        double fRetAngle = 0;
	        double fAngle1, fAngle2;
	        fAngle1 = Math.Atan(ptRelative1.Y / ptRelative1.X);
	        fAngle2 = Math.Atan(ptRelative2.Y / ptRelative2.X);
	        fRetAngle = fAngle2 - fAngle1;
	        return fRetAngle;
        }

        void OnMarkNext()
        {
            //CLaser_CNCDoc* pDoc = NULL;
            //CLaser_CNCView* pView = NULL;
            //CWinApp* pApp = AfxGetApp();
            //POSITION  postem = pApp->GetFirstDocTemplatePosition(); 
            //CDocTemplate* pDocTemp = pApp->GetNextDocTemplate(postem);
            //POSITION  posdoc =  pDocTemp->GetFirstDocPosition();
            //pDoc = (CLaser_CNCDoc*)pDocTemp->GetNextDoc(posdoc);
            //pView = (CLaser_CNCView*)pDoc->GetLaser_CNCView();
            ///////////////////////////////////////////////////////////

	        PointF ptRelativeMove = new PointF(0,0);

            PointF pt1 = new PointF(0,0), pt2 = new PointF(0,0);
	        if( m_nCurrentPoint > 1 )
	        {
                //pt1 = GetPointFromRotateAngle(pView->m_ptSrcData[0], pView->m_ptSrcData[m_nCurrentPoint - 1], pView->m_fAngleRotate);
                //pt2 = GetPointFromRotateAngle(pView->m_ptSrcData[0], pView->m_ptSrcData[m_nCurrentPoint], pView->m_fAngleRotate); //2 zhengjia
	        }
	        else
	        {
                //pt1 = pView->m_ptSrcData[m_nCurrentPoint-1];
                //pt2 = pView->m_ptSrcData[m_nCurrentPoint];
	        }

            ptRelativeMove.X = pt1.X - pt2.X;
            ptRelativeMove.Y = pt1.Y - pt2.Y;

            //if( pCNCMC3 )
            //{
            //    pCNCMC3->ZigMoveRelativeTo(AXIS_X, AXIS_Y, ptRelativeMove.x, ptRelativeMove.y);
            //}
        }

        
        PointF GetPointFromRotateAngle(PointF ptBaseSrc, PointF ptInput, double fAngle)
        {
            PointF ptRet = new PointF(0, 0);
            
            PointF ptInputTem = new PointF(ptInput.X - ptBaseSrc.X, ptInput.Y - ptBaseSrc.Y);
	        fAngle = -fAngle; 

            ptRet.X = (float)(ptInputTem.X*Math.Cos(fAngle) + ptInputTem.Y*Math.Sign(fAngle));
            ptRet.Y = (float)(-ptInputTem.X*Math.Sign(fAngle) + ptInputTem.Y*Math.Cos(fAngle));
	        return ptRet;
        }

        /// <summary>
        /// 窗口按键响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmView_Click(object sender, EventArgs e)
        {
            //手动定位
            bDrawMark = false;
            if (!m_bFlagTypeLocation)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                if (m_ListPoint.Count == 3)
                {
                    m_ListPoint.Clear();
                }
                m_ListPoint.Add(me.Location);

                if (m_ListPoint.Count == 3)
                {
                    bDrawMark = true;
                    
                }
            }
        }

        #endregion

        private void 自动定位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            switch (item.Text)
            {
                case "自动找Mark点":
                    OnAutolocation();
                    break;
                case "选择Mark点":
                    OnAutolocationSelectNextMark();
                    break;
                case "匹配当前Mark点":
                    OnHandlocationCameraOver();
                    break;
                case "下一个Mark点":
                    OnMarkNext();
                    break;
                default:

                    break;
            }
        }

        private void 显示定位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnShowTransformPoint();
        }

        private void OnShowTransformPoint()
        {
            FrmMarkAndLocation frmMAL = new FrmMarkAndLocation();

            frmMAL.ShowDialog();
        }


        public Point m_ptCross;
        public Size m_sizeImg = new Size(1280, 1024);

        private bool OnAutolocation()
        {
            if (!m_bIfCameraOpen)
                return false;

            //if (!m_nRetCamera)
            //{
            //    m_bHasCapture = TRUE;
            //    while (m_bHasCapture || !m_bImageSaved)
            //    {
            //        Sleep(50);
            //    }
            //}

            int nRetHasFound = 1;

            m_bFlagTypeLocation = true; ;
            m_ptCross = new Point(0, 0);
            string Path = "";

            m_rcMarkCircle = doNetHalcon.do_located(Path, this);

            return true;

        }
        public int m_nCountDetectIndex;
        public int m_nCountDetect;
        private void OnAutolocationSelectNextMark()
        {
            m_nCountDetectIndex++;
            m_nCountDetectIndex %= m_nCountDetect;
            m_rcMarkCircle = m_rcDetectRect[m_nCountDetectIndex];
        }

        private void OnUpdateAutolocationSelectNextMark()
        {
            //pCmdUI->Enable(m_nCountDetect > 1);
        }

        private void OnMoveFromCameraToLens()
        {
            //if (pCNCMC3)
            //{
            //    pCNCMC3->ZigMoveRelativeTo(AXIS_X, AXIS_Y, pCNCMC3->m_fOffsetX, pCNCMC3->m_fOffsetY);
            //}
        }

        private void OnMoveFromLenToCamera()
        {
            //if (pCNCMC3)
            //{
            //    pCNCMC3->ZigMoveRelativeTo(AXIS_X, AXIS_Y, -(pCNCMC3->m_fOffsetX), -(pCNCMC3->m_fOffsetY));
            //}
        }

        private void OnMoveFromCameraToCurrent()
        {
                //CPointD relPoint(0,0), ptMouseCurrentPiexl;
	
                //ptMouseCurrentPiexl = m_ptMoveCameraToCurPos;
	
                //if( pCNCMC3 )
                //{
                //    relPoint.x = (pCNCMC3->m_fResolution / 1000.0) * (ptMouseCurrentPiexl.x - (m_sizeImg.cx / 2.0 + pCNCMC3->m_nValueU) );
                //    relPoint.y = (pCNCMC3->m_fResolution / 1000.0) * (ptMouseCurrentPiexl.y - (m_sizeImg.cy / 2.0 + pCNCMC3->m_nValueV) );
                //}

                //if( pCNCMC3 )
                //{
                //    pCNCMC3->ZigMoveRelativeTo(AXIS_X, AXIS_Y, relPoint.x, -relPoint.y);

                //}
        }

        public PointF m_ptFirstLocatePoint = new PointF(0, 0);
        public int DoAutoLocate(uint wParam = 0, long lParam = 0)
        {
            if (m_bIfCameraOpen == false)
            {
                OpenSnap();
                StartSnap();
            }

            if (m_ptFirstLocatePoint.X == 0 && m_ptFirstLocatePoint.Y == 0)
            {
                MessageBox.Show("请正确设定自动定位起始点！");
                return -1;
            }

            //CLaser_CNCDoc* pDoc = NULL;
            //CLaser_CNCView* pView = NULL;
            //CWinApp* pApp = AfxGetApp();
            //POSITION postem = pApp->GetFirstDocTemplatePosition();
            //CDocTemplate* pDocTemp = pApp->GetNextDocTemplate(postem);
            //POSITION posdoc = pDocTemp->GetFirstDocPosition();
            //pDoc = (CLaser_CNCDoc*)pDocTemp->GetNextDoc(posdoc);

            //if (pView->m_lTotalCountTransform < 2)
            //{
            //    AfxMessageBox(_T("请先在加工文件上选择至少两个MARK点进行注册！"));
            //    return -2;
            //}

            //if (pCNCMC3)
            //{
            //    pCNCMC3->ZigMoveTo(AXIS_X, AXIS_Y, m_ptFirstLocatePoint.x, m_ptFirstLocatePoint.y);
            //}

            m_bFlagRestAllAuto = true;
            m_rcMarkCircle = new Rectangle(0,0,0,0);

            PointF centerAtlPoint = new PointF(0, 0), curPoint = new PointF(0, 0), relPoint;

            bool nAutoLocation = true;

            if (m_bFlagRestAllAuto)
            {
                for( int m = (m_nCountAutoIndex-1); m < Int16.MaxValue/*pView->m_lTotalCountTransform*/; m++ )
                {
                    for (int count = 0; count < m_nMatchCount; count++)
                    {
                        nAutoLocation = OnAutolocation();
                        if (!nAutoLocation)
                        {
                            if (count + 1 == m_nMatchCount)
                            {
                                m_bFlagRestAllAuto = false;
                                MessageBox.Show("没有找到Mark点，请调整参数再次捕捉");
                                break;
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(100);
                                continue;
                            }
                        }

                        m_ptMarkCenterPiexl = new Point(m_rcMarkCircle.X + m_rcMarkCircle.Width / 2, m_rcMarkCircle.Y + m_rcMarkCircle.Height / 2);
                        //m_rcMarkCircle.NormalizeRect();
                        m_fMarkDiameterPiexl = m_rcMarkCircle.Width;

                        //if (pCNCMC3)
                        //{
                        //    pCNCMC3->GetAxisPos(AXIS_X, &centerAtlPoint.x);
                        //    pCNCMC3->GetAxisPos(AXIS_Y, &centerAtlPoint.y);

                        //    relPoint.x = (pCNCMC3->m_fResolution / 1000.0) * (m_ptMarkCenterPiexl.x - (m_sizeImg.cx / 2.0 + pCNCMC3->m_nValueU));
                        //    relPoint.y = (pCNCMC3->m_fResolution / 1000.0) * (m_ptMarkCenterPiexl.y - (m_sizeImg.cy / 2.0 + pCNCMC3->m_nValueV));
                        //}

                        //curPoint.X = centerAtlPoint.X + relPoint.X;
                        //curPoint.Y = centerAtlPoint.Y - relPoint.Y;s

                        //if (pCNCMC3)
                        //{
                        //    pCNCMC3->ZigMoveRelativeTo(AXIS_X, AXIS_Y, relPoint.x, -relPoint.y);

                        //    Sleep(50);
                        //}

                        //CPoint ptCenterpoint;
                        //ptCenterpoint = m_rcMarkCircle.CenterPoint();
                        //if (pCNCMC3)
                        //{
                        //    m_rcMarkCircle.OffsetRect((((int)(m_sizeImg.cx / 2.0) + pCNCMC3->m_nValueU) - ptCenterpoint.x),
                        //        (((int)(m_sizeImg.cy / 2.0) + pCNCMC3->m_nValueV) - ptCenterpoint.y));
                        //}

                    }

                    if (!nAutoLocation)
                    {
                        break;
                    }

                    //////////////////////////////////////////////////////////////////////////////////////
                    //if (m_nCountAutoIndex > pView->m_lTotalCountTransform)
                    //{
                    //    AfxMessageBox("超过已经总注册点数");
                    //    return 2;
                    //}

                    PointF ptOffset = new PointF(0, 0);

                    //if (pCNCMC3)
                    //{
                    //    ptOffset = CPointD(pCNCMC3->m_fOffsetX, pCNCMC3->m_fOffsetY);
                    //}
                    //pView->m_ptDstData[m_nCountAutoIndex - 1].x = curPoint.x;
                    //pView->m_ptDstData[m_nCountAutoIndex - 1].y = curPoint.y;
                    //pView->m_ptDstData[m_nCountAutoIndex - 1] += ptOffset;

                    //pView->m_nCountTransform = m_nCountAutoIndex;

                    m_nCurrentPoint = m_nCountAutoIndex;

                    if (m_nCurrentPoint == 1)
                    {
                        if (m_bFirstPointOffset)
                        {
                            //pView->m_ptDstData[0].x += m_dFirstPointOffsetX;
                            //pView->m_ptDstData[0].y += m_dFirstPointOffsetY;
                        }
                    }
                    else if (m_nCurrentPoint == 2)
                    {
                        //pView->m_fAngleRotate = CalRotateAngle(pView->m_ptSrcData[1] - pView->m_ptSrcData[0],
                        //    pView->m_ptDstData[1] - pView->m_ptDstData[0]);
                    }

                    //if (m_nCountAutoIndex == pView->m_lTotalCountTransform)
                    //{
                    //    pView->EstablishTransform();

                    //    m_bFlagRestAllAuto = FALSE;
                    //    m_nCountAutoIndex = 1;

                    //    OnCloseCamera();

                    //    m_rcMarkCircle.SetRectEmpty();
                    //    return 0;
                    //}

                    OnMarkNext();
		           m_nCountAutoIndex++; 

                   //if(::PeekMessage(&message,NULL,0,0,PM_REMOVE))
                   //{
                   //   ::TranslateMessage(&message);
                   //   ::DispatchMessage(&message);
                   //}

                   //m_rcMarkCircle.SetRectEmpty();
		           if( !m_bFlagRestAllAuto )
		           {
			           break;
		           }
                }

                if (!nAutoLocation)
                {
                    return -3;
                }
            }

            return 0;
        }

        private PointF DoLocateGridPoint(int nGridType, int nHor, int nVer)
        {
            PointF centerAtlPoint = new PointF(0, 0), curPoint = new PointF(0, 0), relPoint;

            for (int count = 0; count < m_nMatchCount; count++)
            {
                bool nAutoLocation = OnAutolocation();

                if (!nAutoLocation)
                {
                    if (count + 1 == m_nMatchCount)
                    {
                        MessageBox.Show("没有找到Mark点，请调整参数再次捕捉");
                        m_rcMarkCircle = new Rectangle(0, 0, 0, 0);
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(100);
                        continue;
                    }
                }

                m_ptMarkCenterPiexl = new Point(m_rcMarkCircle.X + m_rcMarkCircle.Width / 2, m_rcMarkCircle.Y + m_rcMarkCircle.Height / 2);
            }
            return curPoint;
        }
       

        private void 振镜校正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGalvoCalibrate frm = new FrmGalvoCalibrate(this);
            frm.ShowDialog();


        }


        private void FrmView_KeyDown(object sender, KeyEventArgs e)
        {
            double PosX = symphony.GetStagePosition(Topwin.SymphonyAPI.StageID.X);
            double PosY = symphony.GetStagePosition(Topwin.SymphonyAPI.StageID.Y);
            double delta = 10;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    PosX += delta;
                    break;
                case Keys.Down:
                    PosX -= delta;
                    break;
                case Keys.Left:
                    PosY += delta;
                    break;
                case Keys.Right:
                    PosY -= delta;
                    break;
            }          
            symphony.StageMove(PosX, PosY);
        }

        private void FrmView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.A:
                    OnAutolocation();
                    break;
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    double PosX = symphony.GetStagePosition(Topwin.SymphonyAPI.StageID.X);
                    double PosY = symphony.GetStagePosition(Topwin.SymphonyAPI.StageID.Y);
                    symphony.StageMove(PosX, PosY);
                    break;
                default:
                    break;
            }
        }


    }

}
