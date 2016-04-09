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
    public partial class FrmRegisterPoint : Form
    {
        #region 成员变量
        public double m_fDlgMarkX = 0.0;
	    public double m_fDlgMarkY = 0.0;
	    public int m_nDlgMarkNumber = 0;
	    public double m_fDlgMarkDiameter = 0.0;
	    public double m_fDlgMarkDiameterPiexl = 0.0;
	    public int m_nDlgMarkIndex = 0;
        public bool m_bDlgFlagAuto = false;

        #endregion

        public FrmRegisterPoint()
        {
            InitializeComponent();
        }

        private void FrmRegisterPoint_Load(object sender, EventArgs e)
        {
            tb_CenterX.Text = m_fDlgMarkX.ToString();
            tb_CenterY.Text = m_fDlgMarkY.ToString();
            tb_RealD.Text = m_fDlgMarkDiameter.ToString();
            tb_PixelD.Text = m_fDlgMarkDiameterPiexl.ToString();
            ck_AllAuto.Checked = m_bDlgFlagAuto;

            m_nDlgMarkNumber = (int)WriteRegistryKey.ReadParam("TRANSFORM_MATCH", "MARK_NUMBER", 0);
            m_nDlgMarkIndex = (int)WriteRegistryKey.ReadParam("TRANSFORM_MATCH", "MARK_INDEX", 0);
            m_nDlgMarkNumber++;
            m_nDlgMarkIndex++;

            tb_Index.Text = m_nDlgMarkIndex.ToString();
            tb_TransformMarkNum.Text = m_nDlgMarkNumber.ToString();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                m_nDlgMarkNumber = Int32.Parse(tb_TransformMarkNum.Text);
                m_nDlgMarkIndex = Int32.Parse(tb_Index.Text);
                WriteRegistryKey.WriteParam("TRANSFORM_MATCH", "MARK_NUMBER", m_nDlgMarkNumber);
                WriteRegistryKey.WriteParam("TRANSFORM_MATCH", "MARK_INDEX", m_nDlgMarkIndex);
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
