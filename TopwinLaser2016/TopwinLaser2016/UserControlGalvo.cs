using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopwinLaser2016
{
    public partial class UserControlGalvo : UserControl
    {
        public UserControlGalvo()
        {
            InitializeComponent();
        }

        public void initialize()
        {
            double x, y;
            FormMainWindow.Symphoney.GetGalvoPosition(out x, out y);
            userControlXYMoverGalvo.UpdateCurrentPosition(x, y);

            userControlXYMoverGalvo.MoveAbsoluteEvent -= userControlXYMoverGalvo_MoveAbsoluteEvent;
            userControlXYMoverGalvo.MoveRelativeEvent -= userControlXYMoverGalvo_MoveRelativeEvent;

            userControlXYMoverGalvo.MoveAbsoluteEvent += userControlXYMoverGalvo_MoveAbsoluteEvent;
            userControlXYMoverGalvo.MoveRelativeEvent += userControlXYMoverGalvo_MoveRelativeEvent;

            //Read Current Values
            buttonReadGalvoFocalLength_Click(buttonReadGalvoFocalLength, null);
            buttonReadGalvoMotionDelay_Click(buttonReadGalvoMotionDelay, null);
            buttonReadGalvoFlipped_Click(buttonReadGalvoFlipped, null);
        }

        void userControlXYMoverGalvo_MoveRelativeEvent(double steps, RelativeMovementDirection direction)
        {
            double newX = userControlXYMoverGalvo.CurrentX;
            double newY = userControlXYMoverGalvo.CurrentY;

            switch (direction)
            {
                case RelativeMovementDirection.E:
                    newX += steps;
                    break;
                case RelativeMovementDirection.N:
                    newY += steps;
                    break;
                case RelativeMovementDirection.Ne:
                    newY += steps;
                    newX += steps;
                    break;
                case RelativeMovementDirection.Nw:
                    newY += steps;
                    newX -= steps;
                    break;
                case RelativeMovementDirection.S:
                    newY -= steps;
                    break;
                case RelativeMovementDirection.Se:
                    newY -= steps;
                    newX += steps;
                    break;
                case RelativeMovementDirection.Sw:
                    newY -= steps;
                    newX -= steps;
                    break;
                case RelativeMovementDirection.W:
                    newX -= steps;
                    break;
            }

            userControlXYMoverGalvo_MoveAbsoluteEvent(newX, newY);
        }

        void userControlXYMoverGalvo_MoveAbsoluteEvent(double x, double y)
        {
            FormMainWindow.Symphoney.GalvoMove(x, y);

            double currentX, currentY;
            FormMainWindow.Symphoney.GetGalvoPosition(out currentX, out currentY);
            userControlXYMoverGalvo.UpdateCurrentPosition(currentX, currentY);
        }

        private void buttonReadGalvoFocalLength_Click(object sender, EventArgs e)
        {
            int val = FormMainWindow.Symphoney.GetGalvoFocalLength();
            numericUpDownGalvoFocalLength.Value = val;
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonReadGalvoMotionDelay_Click(object sender, EventArgs e)
        {
            int val = FormMainWindow.Symphoney.GetGalvoMotionDelay();
            numericUpDownGalvoMotionDelay.Value = val;
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonSetGalvoFocalLength_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetGalvoFocalLength((int)numericUpDownGalvoFocalLength.Value);
        }

        private void buttonSetGalvoMotionDelay_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetGalvoMotionDelay((int)numericUpDownGalvoMotionDelay.Value);
        }

        private void buttonReadGalvoFlipped_Click(object sender, EventArgs e)
        {
            bool xFlipped, yFlipped;
            FormMainWindow.Symphoney.GetGalvoFlipped(out xFlipped, out yFlipped);
            if (xFlipped)
            {
                radioButtonGalvoFlippedXTrue.Checked = true;
            }
            else
            {
                radioButtonGalvoFlippedXFalse.Checked = true;
            }

            if (yFlipped)
            {
                radioButtonGalvoFlippedYTrue.Checked = true;
            }
            else
            {
                radioButtonGalvoFlippedYFalse.Checked = true;
            }
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonSetGalvoFlipped_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetGalvoFlipped(radioButtonGalvoFlippedXTrue.Checked, radioButtonGalvoFlippedYTrue.Checked);
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            FormMainWindow.numericUpDownValueChanged(sender, e);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            FormMainWindow.radioButton_CheckedChanged(sender, e);
        }

    }

   
}
