using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CameraView
{
    public partial class CameraView: UserControl
    {

        FrmView m_FrmView = null;

        public CameraView()
        {
            InitializeComponent();     
        }

        ~CameraView()
        {
            
        }
        #region 界面操作
        private void CameraView_Load(object sender, EventArgs e)
        {
            m_FrmView = new FrmView();
            m_FrmView.Location = panel1.Location;
            m_FrmView.Size = new System.Drawing.Size(1280, 1024);
            m_FrmView.TopLevel = false;
            panel1.Controls.Add(m_FrmView);
            m_FrmView.Show();
        }        
        #endregion
    }
}
