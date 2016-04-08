using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESI.SymphonyAPI;
namespace TopwinLaser2016
{
    public partial class UserControlZMover : UserControl
    {
        public UserControlZMover()
        {
            InitializeComponent();
        }

        private void buttonStageMoveXYZ_Click(object sender, EventArgs e)
        {
           //FormMainWindow.Symphoney.StageMove(new TopwinLaser2016.UserControlXYMover().CurrentX, new TopwinLaser2016.UserControlXYMover().CurrentY, (double)numericUpDownStageMoveXYZ_Z.Value);
            FormMainWindow.Symphoney.StageMove(StageID.Z, (double)numericUpDownStageMoveXYZ_Z.Value,0.05);
        }
    }
}
