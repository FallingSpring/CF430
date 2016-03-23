using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace TopwinLaser2016
{
    public partial class UserControlGraphpaper : UserControl
    {
        [DllImport("Fdxf.dll", EntryPoint = "?SetString@CWhDxfParse@@QAEHAAVCString@@@Z")]
        static extern int SetString(string strDxfLine);
        [DllImport("Fdxf.dll", EntryPoint = "?JustifyGroupCode@CWhDxfParse@@QAEHXZ")]
        static extern bool JustifyGroupCode();
        [DllImport("Fdxf.dll", EntryPoint = "?JustifyMatch@CWhDxfParse@@QAEHXZ")]
        static extern bool JustifyMatch();
        [DllImport("Fdxf.dll", EntryPoint = "?SetObjList@CWhDxfParse@@QAEXPAVCWhListContainer@@@Z")]
        static extern void  SetObjList(CWhListContainer pListObj);
        [DllImport("Fdxf.dll", EntryPoint = "??0CWhDxfParse@@QAE@XZ")]
        static extern void CWhDxfParse();
//         [DllImport("Fdxf.dll", EntryPoint = "??1CWhDxfParse@@UAE@XZ")]
//         static extern void SetObjList(WhbList pListObj);
        public UserControlGraphpaper()
        {
            InitializeComponent();
        }
        public int ParseDxf(string strFileName, CWhListContainer pListObj)
        {
            //CWhDxfParse();
            //SetObjList(pListObj);
            StreamReader sr = File.OpenText(@strFileName);
            string strDxfLine = "";
            while (strDxfLine != "EOF")
            {
                strDxfLine = sr.ReadLine();
                strDxfLine.Trim(' ');

//                 if (SetString(strDxfLine)>0)
//                 {
//                     if (!JustifyGroupCode())
//                     {
//                         break;
//                     }
//                 }
                if (strDxfLine == "EOF")
                {
                    MessageBox.Show("解析DXF完毕");
                    break;
                }
            }
            return 1;
        }

    }
}
