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
    public partial class FrmCameraParam : Form
    {
        #region 变量
        public int m_Light;
        #endregion

        public FrmCameraParam()
        {
            InitializeComponent();

            trackLight.Maximum = 1000;
            trackLight.Minimum = 0;
            
        }

        private void trackLight_Scroll(object sender, EventArgs e)
        {
            tb_Light.Text = trackLight.Value.ToString();
        }

        private void tb_Light_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int Light = Int32.Parse(tb_Light.Text);
                if (Light < 0 || Light > 1000)
                {
                    MessageBox.Show("请输入0~1000的整数");
                    tb_Light.Text = m_Light.ToString();
                }
                else
                {
                    m_Light = Light;
                    tb_Light.Text = m_Light.ToString();
                    trackLight.Value = m_Light;
                }
            }
            catch
            {
                MessageBox.Show("请输入0~1000的整数");
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
