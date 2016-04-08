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
    public partial class UserControlStageXY : UserControl
    {
        public UserControlStageXY()
        {
            InitializeComponent();
        }
        public void Initialize()
        {
            string[] stageIds = Enum.GetNames(typeof(StageID));
            userControlXYMoverStage.MoveAbsoluteEvent -= userControlXYMoverStage_MoveAbsoluteEvent;
            userControlXYMoverStage.MoveRelativeEvent -= userControlXYMoverStage_MoveRelativeEvent;
            userControlXYMoverStage.MoveAbsoluteEvent += userControlXYMoverStage_MoveAbsoluteEvent;
            userControlXYMoverStage.MoveRelativeEvent += userControlXYMoverStage_MoveRelativeEvent;
            double x = FormMainWindow.Symphoney.GetStagePosition(StageID.X);
            double y = FormMainWindow.Symphoney.GetStagePosition(StageID.Y);
            userControlXYMoverStage.UpdateCurrentPosition(x, y);
        }

        void userControlXYMoverStage_MoveRelativeEvent(double steps, RelativeMovementDirection direction)
        {
            double newX = userControlXYMoverStage.CurrentX;
            double newY = userControlXYMoverStage.CurrentY;

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

            userControlXYMoverStage_MoveAbsoluteEvent(newX, newY);
        }

        void userControlXYMoverStage_MoveAbsoluteEvent(double x, double y)
        {
            FormMainWindow.Symphoney.StageMove(x, y);

            double currentX = FormMainWindow.Symphoney.GetStagePosition(StageID.X);
            double currentY = FormMainWindow.Symphoney.GetStagePosition(StageID.Y);

            userControlXYMoverStage.UpdateCurrentPosition(currentX, currentY);
        }

    }
}
