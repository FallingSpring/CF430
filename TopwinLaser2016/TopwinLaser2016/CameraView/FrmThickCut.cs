using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraView
{
    public partial class FrmThickCut : Form
    {
        #region 成员变量
        public double m_fDlgMarkCoordinateX;
        public double m_fDlgMarkCoordinateY;
        public double m_fDlgCameraResolution;           //相机分辨率
        public double m_fDlgMarkDiameter;               //标准圆直径
        public double m_fDlgCameraOffsetX;
        public double m_fDlgCameraOffsetY;
        public double m_fDlgMarkDiameterPiexl;
        public double m_fDlgViewRulerUnit;
        #endregion

        public FrmThickCut()
        {
            InitializeComponent();
        }

        private void FrmThickCut_Load(object sender, EventArgs e)
        {
            m_fDlgMarkCoordinateX       = WriteRegistryKey.ReadParam("CAMERA_PARA", "MARK_X", 0) / 10000.0;
            m_fDlgMarkCoordinateY       = WriteRegistryKey.ReadParam("CAMERA_PARA", "MARK_Y", 0) / 10000.0;
            m_fDlgCameraResolution      = WriteRegistryKey.ReadParam("CAMERA_PARA", "RESOLUTION", 67000) / 10000.0;
            m_fDlgMarkDiameter          = WriteRegistryKey.ReadParam("CAMERA_PARA", "MARK_DIAMETER", 20000) / 10000.0;
            m_fDlgCameraOffsetX         = WriteRegistryKey.ReadParam("CAMERA_PARA", "CAMERA_OFFSET_X", 0) / 10000.0;
            m_fDlgCameraOffsetY         = WriteRegistryKey.ReadParam("CAMERA_PARA", "CAMERA_OFFSET_Y", 0) / 10000.0;
            m_fDlgMarkDiameterPiexl     = WriteRegistryKey.ReadParam("CAMERA_PARA", "MARK_DIAMETER_PIEXL", 0) / 10000.0;
            m_fDlgViewRulerUnit         = WriteRegistryKey.ReadParam("CAMERA_PARA", "VIEW_RULER_UNIT", 50) / 1.0;

            tb_Camera_X_pixel.Text      = m_fDlgMarkCoordinateX.ToString();
            tb_Camera_Y_pixel.Text      = m_fDlgMarkCoordinateY.ToString();
            tb_Camera_Resoluton.Text    = m_fDlgCameraResolution.ToString();
            tb_Camera_D_mm.Text         = m_fDlgMarkDiameter.ToString();
            tb_Camera_D_pixel.Text      = m_fDlgMarkDiameterPiexl.ToString();
            tb_CameraOffset_X.Text      = m_fDlgCameraOffsetX.ToString();
            tb_CameraOffset_Y.Text      = m_fDlgCameraOffsetY.ToString();
            tb_Ruluer_Unit.Text         = m_fDlgViewRulerUnit.ToString();

        }
        /// <summary>
        /// 计算相机分辨率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GetResolution_Click(object sender, EventArgs e)
        {
            try
            {
                m_fDlgMarkDiameter = Double.Parse(tb_Camera_D_mm.Text);
                m_fDlgMarkDiameterPiexl = Double.Parse(tb_Camera_D_pixel.Text);
                m_fDlgCameraResolution = m_fDlgMarkDiameter * 1000 / m_fDlgMarkDiameterPiexl;
                tb_Camera_Resoluton.Text = m_fDlgCameraResolution.ToString();
            }
            catch
            {
                
            }  
        }

        /// <summary>
        /// 测试相机中心距离
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_testCameraCenter_Click(object sender, EventArgs e)
        {
            // TODO: Add your control notification handler code here
            /*
            if (!pCNCMC3)
            {
                return;
            }

            CPointD pos_XYDst, pos_XYStart;

            if (pCNCMC3->m_nLaserType == 2)
            {
                pCNCMC3->SetIPGMO(TRUE);
            }

            if (m_serialPort.m_bOpenPort && pCNCMC3->m_nLaserType == 3)
            {
                m_serialPort.TALON_SetGateOnOff(TRUE);
            }

            pCNCMC3->StartList(LIST_1);

            pos_XYStart.x = 0;
            pos_XYStart.y = 0;
            pos_XYDst.x = -1;
            pos_XYDst.y = 0;
            CPointD ptCenter = CPointD(0, 0);
            double fRadium = 1.0;

            pCNCMC3->SetLensJumpToPosWithCompInList(pos_XYStart, pos_XYDst);
            pCNCMC3->SetLensMovePosArcWithCompInList(pos_XYDst, pos_XYDst, ptCenter, -1, fRadium);

            pos_XYStart.x = -1;
            pos_XYStart.y = 0;
            pos_XYDst.x = 0;
            pos_XYDst.y = 0;
            pCNCMC3->SetLensJumpToPosWithCompInList(pos_XYStart, pos_XYDst);

            pCNCMC3->m_lmp->set_end_of_list();
            pCNCMC3->ExecuteList(pCNCMC3->m_nCurrentList);

            while (pCNCMC3->CheckBufMovingDone())
            {
                Sleep(10);
            }

            if (m_serialPort.m_bOpenPort && pCNCMC3->m_nLaserType == 3)
            {
                m_serialPort.TALON_SetGateOnOff(FALSE);
            }

            if (pCNCMC3->m_nLaserType == 2)
            {
                pCNCMC3->SetIPGMO(FALSE);
            }

            if (pCNCMC3)
            {
                pCNCMC3->ZigMoveRelativeTo(AXIS_X, AXIS_Y, -m_fDlgCameraOffsetX, -m_fDlgCameraOffsetY);

            }
             * */
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                m_fDlgMarkDiameter = Double.Parse(tb_Camera_D_mm.Text);
                m_fDlgMarkDiameterPiexl = Double.Parse(tb_Camera_D_pixel.Text);
                m_fDlgMarkCoordinateX = Double.Parse(tb_Camera_X_pixel.Text);
                m_fDlgMarkCoordinateY = Double.Parse(tb_Camera_Y_pixel.Text);
                m_fDlgCameraResolution = Double.Parse(tb_Camera_Resoluton.Text);
                m_fDlgCameraOffsetX = Double.Parse(tb_CameraOffset_X.Text);
                m_fDlgCameraOffsetY = Double.Parse(tb_CameraOffset_Y.Text);
                m_fDlgViewRulerUnit = Double.Parse(tb_Ruluer_Unit.Text);

                WriteRegistryKey.WriteParam("CAMERA_PARA", "MARK_X", m_fDlgMarkCoordinateX * 10000);
                WriteRegistryKey.WriteParam("CAMERA_PARA", "MARK_Y", m_fDlgMarkCoordinateY * 10000);
                WriteRegistryKey.WriteParam("CAMERA_PARA", "RESOLUTION", m_fDlgCameraResolution * 10000);
                WriteRegistryKey.WriteParam("CAMERA_PARA", "MARK_DIAMETER", m_fDlgMarkDiameter * 10000);
                WriteRegistryKey.WriteParam("CAMERA_PARA", "CAMERA_OFFSET_X", m_fDlgCameraOffsetX * 10000);
                WriteRegistryKey.WriteParam("CAMERA_PARA", "CAMERA_OFFSET_Y", m_fDlgCameraOffsetY * 10000);
                WriteRegistryKey.WriteParam("CAMERA_PARA", "MARK_DIAMETER_PIEXL", m_fDlgMarkDiameterPiexl * 10000);
                WriteRegistryKey.WriteParam("CAMERA_PARA", "VIEW_RULER_UNIT", m_fDlgViewRulerUnit);
            }
            catch
            {
                MessageBox.Show("请检查数据格式！");
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        
        


    }
}
