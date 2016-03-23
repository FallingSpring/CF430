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
    public delegate void MoveAbsoluteDeligate(double x, double Y);
    public delegate void MoveRelativeDeligate(double steps,RelativeMovementDirection direction);

    public enum RelativeMovementDirection
    {
        N,
        Ne,
        E,
        Se,
        S,
        Sw,
        W,
        Nw,
    }

    public partial class UserControlXYMover : UserControl
    {
        public event MoveAbsoluteDeligate MoveAbsoluteEvent;
        public event MoveRelativeDeligate MoveRelativeEvent;
        public UserControlXYMover()
        {
            InitializeComponent();
        }

        private void buttonMoveAbsolute_Click(object sender, EventArgs e)
        {
            if (MoveAbsoluteEvent != null)
            {
                MoveAbsoluteEvent((double)numericUpDowMoveAbsoluteX.Value, (double)numericUpDownMoveAbsoluteY.Value);
            }
        }

        public void UpdateCurrentPosition(double x, double y)
        {
            labelCurrentPositionX.Text = x.ToString();
            labelCurrentPositionY.Text = y.ToString();

            CurrentX = x;
            CurrentY = y;
        }

        private void buttonMoveNW_Click(object sender, EventArgs e)
        {
            if (MoveRelativeEvent != null)
            {
                MoveRelativeEvent((double)numericUpDownMoveRelativeStep.Value, RelativeMovementDirection.Nw);
            }
        }

        private void buttonMoveN_Click(object sender, EventArgs e)
        {
            if (MoveRelativeEvent != null)
            {
                MoveRelativeEvent((double)numericUpDownMoveRelativeStep.Value, RelativeMovementDirection.N);
            }
        }

        private void buttonMoveNE_Click(object sender, EventArgs e)
        {
            if (MoveRelativeEvent != null)
            {
                MoveRelativeEvent((double)numericUpDownMoveRelativeStep.Value, RelativeMovementDirection.Ne);
            }
        }

        private void buttonMoveE_Click(object sender, EventArgs e)
        {
            if (MoveRelativeEvent != null)
            {
                MoveRelativeEvent((double)numericUpDownMoveRelativeStep.Value, RelativeMovementDirection.E);
            }
        }

        private void buttonMoveSE_Click(object sender, EventArgs e)
        {
            if (MoveRelativeEvent != null)
            {
                MoveRelativeEvent((double)numericUpDownMoveRelativeStep.Value, RelativeMovementDirection.Se);
            }
        }

        private void buttonMoveS_Click(object sender, EventArgs e)
        {
            if (MoveRelativeEvent != null)
            {
                MoveRelativeEvent((double)numericUpDownMoveRelativeStep.Value, RelativeMovementDirection.S);
            }
        }

        private void buttonMoveSW_Click(object sender, EventArgs e)
        {
            if (MoveRelativeEvent != null)
            {
                MoveRelativeEvent((double)numericUpDownMoveRelativeStep.Value, RelativeMovementDirection.Sw);
            }
        }

        private void buttonMoveW_Click(object sender, EventArgs e)
        {
            if (MoveRelativeEvent != null)
            {
                MoveRelativeEvent((double)numericUpDownMoveRelativeStep.Value, RelativeMovementDirection.W);
            }
        }
        public double CurrentX { get; set; }
        public double CurrentY { get; set; }

        private void buttonMoveHome_Click(object sender, EventArgs e)
        {

        }
    }
}
