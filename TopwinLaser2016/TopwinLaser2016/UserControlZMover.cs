using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Topwin.SymphonyAPI;
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
            FormMainWindow.Symphoney.StageMove(StageID.Z, (double)numericUpDownStageMoveXYZ_Z.Value, (double)numericUpDownZSpeed.Value);
        }
        private void buttonStageMoveZUp_Click(object sender, EventArgs e)
        {
            double currentZ = FormMainWindow.Symphoney.GetStagePosition(StageID.Z);
            FormMainWindow.Symphoney.StageMove(StageID.Z, currentZ + (double)numericUpDownStep.Value, (double)numericUpDownZSpeed.Value);
            numericUpDownStageMoveXYZ_Z.Value = (decimal)FormMainWindow.Symphoney.GetStagePosition(StageID.Z);
        }
        private void buttonStageMoveZDown_Click(object sender, EventArgs e)
        {
            double currentZ = FormMainWindow.Symphoney.GetStagePosition(StageID.Z);
            FormMainWindow.Symphoney.StageMove(StageID.Z, currentZ - (double)numericUpDownStep.Value, (double)numericUpDownZSpeed.Value);
            numericUpDownStageMoveXYZ_Z.Value = (decimal)FormMainWindow.Symphoney.GetStagePosition(StageID.Z);
        }
    }
}
