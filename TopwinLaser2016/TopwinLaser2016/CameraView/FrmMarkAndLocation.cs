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
    public partial class FrmMarkAndLocation : Form
    {
        public FrmMarkAndLocation()
        {
            InitializeComponent();
        }

        private void FrmMarkAndLocation_Load(object sender, EventArgs e)
        {
            /*
             	int nRowOrigin(0);
                CString strIndex, strX, strY;
	            for(int i = 0; i < pView->m_lTotalCountTransform; i++)
	            {
	               strIndex.Format("%d", i+1);
	               strX.Format("%.3f", pView->m_ptSrcData[i].x);
	               strY.Format("%.3f", pView->m_ptSrcData[i].y);
	               nRowOrigin = m_ctrlListOriginPoint.InsertItem(i, strIndex); 
                   m_ctrlListOriginPoint.SetItemText(nRowOrigin, 1, strX);
	               m_ctrlListOriginPoint.SetItemText(nRowOrigin, 2, strY);
	            }
                nRet = m_ctrlListOriginPoint.GetItemCount();


                for(int j = 0; j < pView->m_nCountTransform; j++)
	            {
	               strIndex.Format("%d", j+1);
	               strX.Format("%.3f", pView->m_ptDstData[j].x);
	               strY.Format("%.3f", pView->m_ptDstData[j].y);
	               nRowOrigin = m_ctrlListRealPoint.InsertItem(j, strIndex); 
                   m_ctrlListRealPoint.SetItemText(nRowOrigin, 1, strX);
	               m_ctrlListRealPoint.SetItemText(nRowOrigin, 2, strY);
	            }    
             */
        }

        private bool m_IsReal = false;
        private void ListViewSelectedIndexChanged(object sender, EventArgs e)
        {

            ListView list = sender as ListView;
            ListViewItem item = list.SelectedItems[0];

            if (list.Name == "m_RealList")
            {
                m_IsReal = true;
            }
            else
            {
                m_IsReal = false;
            }

            tb_Index.Text = item.Text;
            tb_OffsetX.Text = item.SubItems[0].Text;
            tb_OffsetY.Text = item.SubItems[1].Text;
        }

        private void btn_UpdatePos_Click(object sender, EventArgs e)
        {
            ListView list = null;
            if (m_IsReal)
            {
                list = m_RealList;
            }
            else
            {
                list = m_originList;
            }

            ListViewItem item = list.Items[Int32.Parse(tb_Index.Text)];
            item.SubItems[0].Text = tb_OffsetX.Text;
            item.SubItems[1].Text = tb_OffsetY.Text;
        }

        private void btn_Offset_Click(object sender, EventArgs e)
        {
            double offset_x = Double.Parse(tb_OffsetX.Text);
            double offset_y = Double.Parse(tb_OffsetY.Text);
            foreach(ListViewItem item in m_RealList.Items)
            {
                double pos_x = Double.Parse(item.SubItems[0].Text) + offset_x;
                double pos_y = Double.Parse(item.SubItems[1].Text) + offset_y;

                item.SubItems[0].Text = pos_x.ToString();
                item.SubItems[1].Text = pos_y.ToString();
            }
        }

        private void btn_UpdateRelation_Click(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }





    }
}
