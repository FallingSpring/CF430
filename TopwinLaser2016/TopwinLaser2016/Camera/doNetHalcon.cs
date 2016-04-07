using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace CameraView
{
    public class doNetHalcon
    {

        private static HObject m_image;
        private HTuple m_WindowHander;
        private static HObject m_CircleCon;
        private static HTuple m_ModelID;

        public static void read_image(string path)
        { 
            
        }

        public static Rectangle do_located(string FilePath, FrmView view)
        {
            Rectangle rect = new Rectangle(0, 0, 0, 0);
            HTuple Row, Col, Angle, Scale, Score;

            HOperatorSet.ReadImage(out m_image, FilePath);
            HOperatorSet.FindScaledShapeModel(m_image, m_ModelID, -0.39, 0.7, view.m_fContourMinRatio, view.m_fContourMaxRatio,
                                            view.m_fContourMinScore, view.m_nFindNum, 0, "least_squares", 0, view.m_fFindGredness,
                                            out Row, out Col, out Angle, out Scale, out Score);

            view.m_nCountDetect = Row.Length;
            view.m_nCountDetectIndex = 0;

            if (view.m_nCountDetect == 0)
            {
                return rect;
            }

            for (int d = 0; d < view.m_nCountDetect; d++)
            {
                view.m_ptDetectCross[d] = new Point(Col[d].I, Row[d].I);
                int nRadium = (int)Scale[d].D * view.m_nContourRadium;
                view.m_rcDetectRect[d].Location = new Point(view.m_ptDetectCross[d].X - nRadium, view.m_ptDetectCross[d].Y - nRadium);
                view.m_rcDetectRect[d].Size =  new Size(2*nRadium, 2*nRadium);
            }

            //最佳匹配点
            Size s = view.m_sizeImg;
            Point pointImageCenter = new Point(s.Width / 2, s.Height / 2);
            double fDistanceMin = double.MaxValue, fDistance;
            int MostMatched = 0;
            int l = 0;
            do
            {
                fDistance = Distance(pointImageCenter, CenterPoint(view.m_rcDetectRect[l]));       
                if (fDistance < fDistanceMin)
                {
                    fDistanceMin = fDistance;
                    MostMatched = l;
                }
                l++;

            }while(l<view.m_nCountDetect);

            rect = view.m_rcDetectRect[MostMatched];

            return rect;
        }

        public static void CreateModelxld(int raduims, double MinRatio, double MaxRatio, int ContourContrast)
        {
            HOperatorSet.GenCircleContourXld(out m_CircleCon, raduims, raduims, raduims, 0, 6.28318, "positive", 1);
            HOperatorSet.CreateScaledShapeModelXld(m_CircleCon, "auto", -0.39, 0.79, "auto",
            MinRatio, MaxRatio, "auto", "auto", "ignore_local_polarity",
            ContourContrast, out m_ModelID);
        }

        private static Point CenterPoint(Rectangle rect)
        {
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            return center;
        }

        private static double Distance(Point p1, Point p2)
        {
            return (p1.X - p2.X) * (p1.X - p2.X) + (p2.Y - p2.Y) * (p2.Y - p2.Y);
        }
        
    }
}
