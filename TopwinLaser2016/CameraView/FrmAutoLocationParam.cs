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
    public partial class FrmAutoLocationParam : Form
    {
        #region 成员变量
        public int m_nDlgContourRadium;
        public int m_nDlgContourContrast;
        public double m_fDlgContourMaxRatio;
        public double m_fDlgContourMinRatio;
        public double m_fDlgContourMinScore;
        public int m_nDlgFindNum;
        public double m_fDlgFindGredness;
        public bool m_nDlgTypeModel;
        public int m_nDlgMatchCount;
        public double m_fFirstPoint_OffsetX;
        public double m_fFirstPoint_OffsetY;
        public bool m_bFirstPointOffset;
        #endregion

        public FrmAutoLocationParam()
        {
            InitializeComponent();

            m_nDlgContourRadium = 150;
            m_nDlgContourContrast = 5;
            m_fDlgContourMaxRatio = 3.0;
            m_fDlgContourMinRatio = 0.8;
            m_fDlgContourMinScore = 0.8;
            m_nDlgFindNum = 2;
            m_fDlgFindGredness = 0.9;
            m_nDlgTypeModel = false;
            m_nDlgMatchCount = 1;
            m_fFirstPoint_OffsetX = 0.0;
            m_fFirstPoint_OffsetY = 0.0;
            m_bFirstPointOffset = false;
        }

        private void FrmAutoLocationParam_Load(object sender, EventArgs e)
        {
            m_nDlgContourRadium = (int)WriteRegistryKey.ReadParam("AUTO_LOCATION", "IDC_EDIT_CONTOUR_CIRCLE", 180);
            m_nDlgContourContrast = (int)WriteRegistryKey.ReadParam("AUTO_LOCATION", "IDC_EDIT_CONTOUR_CONTRAST", 5);
            m_fDlgContourMaxRatio = (WriteRegistryKey.ReadParam("AUTO_LOCATION", "IDC_EDIT_CONTOUR_MAXRATIO", 2000)) / 1000.0;
            m_fDlgContourMinRatio = (WriteRegistryKey.ReadParam("AUTO_LOCATION", "IDC_EDIT_CONTOUR_MINRATIO", 800)) / 1000.0;
            m_fDlgContourMinScore = (WriteRegistryKey.ReadParam("AUTO_LOCATION", "IDC_EDIT_FIND_MINSCORE", 600)) / 1000.0;
            m_nDlgFindNum = (int)WriteRegistryKey.ReadParam("AUTO_LOCATION", "IDC_EDIT_FIND_NUM", 1);
            m_fDlgFindGredness = (WriteRegistryKey.ReadParam("AUTO_LOCATION", "IDC_EDIT__FIND_GREDNIESS", 900)) / 1000.0;
            m_nDlgTypeModel = (bool)WriteRegistryKey.ReadParam("AUTO_LOCATION", "IDC_RADIO_STANDARD", false);
            m_nDlgMatchCount = (int)WriteRegistryKey.ReadParam("AUTO_LOCATION", "IDC_MATCH_COUNT", 1);

            m_bFirstPointOffset = (bool)WriteRegistryKey.ReadParam("AUTO_LOCATION", "FIRST_POINT_OFFSET_EN", false);
            m_fFirstPoint_OffsetX = (WriteRegistryKey.ReadParam("AUTO_LOCATION", "FIRST_POINT_OFFSET_X", 2)) / 1000.0;
            m_fFirstPoint_OffsetY = (WriteRegistryKey.ReadParam("AUTO_LOCATION", "FIRST_POINT_OFFSET_Y", 1)) / 1000.0;

            tb_CircleR.Text = m_nDlgContourContrast.ToString();
            tb_Constrast.Text = m_nDlgContourContrast.ToString();
            tb_MaxScale.Text = m_fDlgContourMaxRatio.ToString();
            tb_MinScale.Text = m_fDlgContourMinRatio.ToString();
            tb_MatchScore.Text = m_fDlgContourMinScore.ToString();
            tb_MatchNum.Text = m_nDlgFindNum.ToString();
            tb_MatchSpeed.Text = m_fDlgFindGredness.ToString();
            tb_MatchTimes.Text = m_nDlgMatchCount.ToString();
            tb_OffsetX.Text = m_fFirstPoint_OffsetX.ToString();
            tb_OffsetY.Text = m_fFirstPoint_OffsetY.ToString();
            ck_ChekFirstOffset.Checked = m_bFirstPointOffset;
            
            if (m_nDlgMatchCount == 1)
            {
                r_Standard.Checked = true;
                r_Userdefine.Checked = false;
            }
            else
            {
                r_Standard.Checked = false;
                r_Userdefine.Checked = true;
            }
            
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                m_nDlgContourRadium = Int32.Parse(tb_CircleR.Text);
                m_nDlgContourContrast = Int32.Parse(tb_Constrast.Text);
                m_fDlgContourMaxRatio = Double.Parse(tb_MaxScale.Text);
                m_fDlgContourMinRatio = Double.Parse(tb_MinScale.Text);
                m_fDlgContourMinScore = Double.Parse(tb_MatchScore.Text);
                m_nDlgFindNum = Int32.Parse(tb_MatchNum.Text);
                m_fDlgFindGredness = Double.Parse(tb_MatchSpeed.Text);
                m_nDlgMatchCount = Int32.Parse(tb_MatchTimes.Text);
                m_fFirstPoint_OffsetX = Double.Parse(tb_OffsetX.Text);
                m_fFirstPoint_OffsetY = Double.Parse(tb_OffsetY.Text);
                m_bFirstPointOffset = ck_ChekFirstOffset.Checked;
                m_nDlgTypeModel = r_Standard.Checked;


                WriteRegistryKey.WriteParam("AUTO_LOCATION", "IDC_EDIT_CONTOUR_CIRCLE", m_nDlgContourRadium);
                WriteRegistryKey.WriteParam("AUTO_LOCATION", "IDC_EDIT_CONTOUR_CONTRAST", m_nDlgContourContrast);
                WriteRegistryKey.WriteParam("AUTO_LOCATION", "IDC_EDIT_CONTOUR_MAXRATIO", m_fDlgContourMaxRatio*1000);
                WriteRegistryKey.WriteParam("AUTO_LOCATION", "IDC_EDIT_CONTOUR_MINRATIO", m_fDlgContourMinRatio*1000);
                WriteRegistryKey.WriteParam("AUTO_LOCATION", "IDC_EDIT_FIND_MINSCORE", m_fDlgContourMinScore*1000);
                WriteRegistryKey.WriteParam("AUTO_LOCATION", "IDC_EDIT_FIND_NUM", m_nDlgFindNum);
                WriteRegistryKey.WriteParam("AUTO_LOCATION", "IDC_EDIT__FIND_GREDNIESS", m_fDlgFindGredness*1000);
                WriteRegistryKey.WriteParam("AUTO_LOCATION", "IDC_RADIO_STANDARD", m_nDlgTypeModel);
                WriteRegistryKey.WriteParam("AUTO_LOCATION", "IDC_MATCH_COUNT", m_nDlgMatchCount);

                WriteRegistryKey.WriteParam("AUTO_LOCATION", "FIRST_POINT_OFFSET_EN", m_bFirstPointOffset);
                WriteRegistryKey.WriteParam("AUTO_LOCATION", "FIRST_POINT_OFFSET_X", m_fFirstPoint_OffsetX*1000);
                WriteRegistryKey.WriteParam("AUTO_LOCATION", "FIRST_POINT_OFFSET_Y", m_fFirstPoint_OffsetY*1000);



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

        private void ck_ChekFirstOffset_Click(object sender, EventArgs e)
        {
            tb_OffsetX.Enabled = ck_ChekFirstOffset.Checked;
            tb_OffsetY.Enabled = ck_ChekFirstOffset.Checked;
        }

    }
}
