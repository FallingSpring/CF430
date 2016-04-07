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
        private bool m_bIsSnap = false;                                             ///< 是否正在采集
        private bool m_bIsOpen = false;                                             ///< 是否打开设备
                                                                                    ///
        private bool m_bAutoLocate = true;                                          ///< 手动定位标识
        private List<Point> m_ListPoint = new List<Point>();                        ///< 手动定位点缓存  
        private int m_nDetected = 0;                                                /// 匹配点个数
        
        
        #endregion

        public FrmView()


        {
            InitializeComponent();
            DrawRuler();

        }

        ~FrmView()
        {
            CloseSnap();
        }

        
        #region 相机操作
        private void OpenSnap()
        {
            m_Camera.Initialize();
            System.Diagnostics.Debug.Assert(m_Camera.GetHandle() != IntPtr.Zero);

            HVSTATUS status = USBCameraAPI.HVOpenSnap(m_Camera.GetHandle(), snapCallback, this.Handle);
            USBCameraAPI.HV_VERIFY(status);
            if (USBCameraAPI.HV_SUCCESS(status))
            {
                m_bIsOpen = true;
            }
        }

        private void StartSnap()
        {
            System.Diagnostics.Debug.Assert(m_Camera.GetHandle() != IntPtr.Zero);

            IntPtr[] pBuffers = new IntPtr[1];
            pBuffers[0] = m_Camera.GetRawBuffer();

            HVSTATUS status = USBCameraAPI.HVStartSnap(m_Camera.GetHandle(), pBuffers, 1);
            USBCameraAPI.HV_VERIFY(status);
            if (USBCameraAPI.HV_SUCCESS(status))
            {
                m_bIsSnap = true;
            }
        }

        private void StopSnap()
        {    
            if (m_bIsSnap)
            {
                m_bIsSnap = false;
                //System.Diagnostics.Debug.Assert(m_Camera.GetHandle() != IntPtr.Zero);
                HVSTATUS status = USBCameraAPI.HVStopSnap(m_Camera.GetHandle());
                USBCameraAPI.HV_VERIFY(status);
                if (USBCameraAPI.HV_SUCCESS(status))
                {
                    
                }
            }
        }

        private void CloseSnap()
        {
            if (m_bIsSnap)
            {
                System.Diagnostics.Debug.Assert(m_Camera.GetHandle() != IntPtr.Zero);
                StopSnap();
                HVSTATUS status = USBCameraAPI.HVCloseSnap(m_Camera.GetHandle());
                m_Camera.Release();
            }
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
            m_Camera.SaveImage();
            Graphics gc = this.CreateGraphics();
            gc.DrawImage(m_Camera.GetCurrentBMP(), this.ClientRectangle);
            gc.DrawImage(m_Ruler, 0, 0, width, height);
        }

        Bitmap m_Ruler = null;
        private void DrawRuler()
        {
            m_Ruler = new Bitmap(width, height);

            Graphics gc = Graphics.FromImage(m_Ruler);
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

        private void DrawMark(List<Point> circle)
        {
            if (circle.Count < 3)
            {
                MessageBox.Show("三点确定一个圆");
                return;
            }

            Point Center = new Point(0, 0);
            double raduis = 0;
            GetCircle(circle[0], circle[1], circle[2], ref Center, ref raduis); 
            Graphics gc = this.CreateGraphics();
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

        private void GetCircle(Point point1, Point point2, Point point3, ref Point center, ref double raduis)
        {
            double mat1, mat2, mat3;
            mat1 = ((point2.X*point2.X +point2.Y*point2.Y)-(point1.X*point1.X +point1.Y*point1.Y))*(2*(point3.Y-point1.Y))-  
            ((point3.X*point3.X +point3.Y*point3.Y)-(point1.X*point1.X +point1.Y*point1.Y))*(2*(point2.Y-point1.Y));  
            mat2 = (2*(point2.X-point1.X))*((point3.X*point3.X+point3.Y*point3.Y)-(point1.X*point1.X +point1.Y*point1.Y))-  
                (2*(point3.X-point1.X))*((point2.X*point2.X+point2.Y*point2.Y)-(point1.X*point1.X +point1.Y*point1.Y));  
            mat3 = 4*((point2.X-point1.X)*(point3.Y-point1.Y) - (point3.X-point1.X)*(point2.Y-point1.Y));

            center.X = (int)(mat1 / mat3);
            center.Y = (int)(mat2 / mat3);

            raduis = Math.Sqrt((double)((point1.X-center.X)*(point1.X-center.X) + (point1.Y-center.Y)*(point1.Y-center.Y))); 

        }

        #endregion

        #region 界面响应

        private void 相机ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            switch (item.Text)
            {
                case "打开":
                    OpenSnap();
                    StartSnap();
                    break;
                case "自动对焦":
                    break;
                case "关闭":
                    StopSnap();
                    CloseSnap();
                    break;
                case "设置":
                    FrmCameraParam DlgSet = new FrmCameraParam();
                    if (DlgSet.ShowDialog() == DialogResult.OK)
                    {
                        m_Camera.SetExposureTime(DlgSet.m_Light, 1000);
                    }
                    this.DrawRuler();

                    FrmThickCut Dlg = new FrmThickCut();
                    Dlg.ShowDialog();
                    break;
                default:

                    break;
            }
        }

        private void mark点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            switch (item.Text)
            {
                case "手动定位开始":
                    m_bAutoLocate = false;
                    m_ListPoint.Clear();
                    break;
                case "计算当前Mark点":
                    break;
                case "下一Mark点":

                    break;
                case "建立定位关系":

                    break;
                default:

                    break;
            }
        }

        /// <summary>
        /// 窗口按键响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmView_Click(object sender, EventArgs e)
        {
            //手动定位
            if (!m_bAutoLocate)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                if (m_ListPoint.Count == 3)
                {
                    m_ListPoint.Clear();
                }
                m_ListPoint.Add(me.Location);

                if (m_ListPoint.Count == 3)
                {
                    DrawMark(m_ListPoint);
                }
            }
        }

        #endregion
    }

}
