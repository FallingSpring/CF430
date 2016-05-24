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
    public partial class FrmGalvoCalibrate : Form
    {
        private readonly FrmView view = null;

        private int iGalvoSize;         
        private int iGridType;
        private List<KeyValuePair<double, double>> RawPos;
        private List<KeyValuePair<double, double>> NominalPos;
        private double dDist;

        private double OrigionX, OrigionY;
        


        public FrmGalvoCalibrate(FrmView view)
        {
            InitializeComponent();
            this.view = view;
            iGalvoSize = 80;
            iGridType = 8;
            RawPos = new List<KeyValuePair<double, double>>();
            NominalPos = new List<KeyValuePair<double, double>>();
        }

        private void FrmGalvoCalibrate_Load(object sender, EventArgs e)
        {
            InitUI();
        }

        private void InitUI()
        {
            cb_GridType.SelectedIndex = iGridType/8 -1;
            tb_GalvoSize.Text = iGalvoSize.ToString();
        }

        private void GetUiInfo()
        {
            iGridType = (cb_GridType.SelectedIndex + 1) * 8;
            Int32.TryParse(tb_GalvoSize.Text, out iGalvoSize);
        }

        private void InitRawPos()
        {
            RawPos.Clear();
            dDist = (iGalvoSize / 2) / iGridType;
            double dRaduis = 1.0;
            if (dDist < dRaduis)
            {
                MessageBox.Show("网格间距过小，请调整网格类型");
            }

            double xRaw = 0.0; double yRaw = 0.0;

            for (int col = -iGridType; col < iGridType; col++)
            {
                for (int row = -iGridType; row < iGridType; row++)
                {
                    xRaw = row * dDist;
                    yRaw = col * dDist;
                    RawPos.Add(new KeyValuePair<double, double>(xRaw, yRaw));
                }
            }
        }

        private void MarkGrid()
        { 
        }

        private void btn_MarkGrid_Click(object sender, EventArgs e)
        {
            InitRawPos();
            //根据RawPos来镭雕对应的圆
            MarkGrid();
        }

        private void GetNominalPos()
        {
            double Row = 0, Col = 0;
            NominalPos.Clear();
            
            foreach (KeyValuePair<double, double> item in RawPos)
            {
                Row = item.Key;
                Col = item.Value;

                MoveAndLocate(ref Row, ref Col);
            }

        }

        private void MoveAndLocate(ref double row, ref double col)
        { 
            //相机中心到振镜中心距离
            double xOffset = 0;
            double yOffset = 0;
            //移动相机到对应的点
            double xPos = row + xOffset + OrigionX;
            double yPos = col + yOffset + OrigionY;
            //定位一个圆相对镜头中心的偏差
            double xCircle = 0.0;
            double yCircle = 0.0;
            Locate(out xCircle, out yCircle);
            //计算nominalPos;
            double xNomPos = xCircle + row;
            double yNomPos = yCircle + col;
        }

        private void Locate(out double x, out double y)
        {
            x = 0;
            y = 0;
            try
            {
                Rectangle rc = doNetHalcon.do_located("", view);

                x = (1280 - (rc.Location.X + rc.Width / 2)) / 2;
                y = (1024 - (rc.Location.Y + rc.Height / 2)) / 2;
            }
            catch
            {
                MessageBox.Show("未找到识别点");
            }
            
        }
        private void btn_AutoCalibrate_Click(object sender, EventArgs e)
        {
            GetNominalPos();

            //Symphony.SetDataTable(NominalPos, RawPos);
            }

        private void btn_MarkRect_Click(object sender, EventArgs e)
        {
             
        }


    }
}
