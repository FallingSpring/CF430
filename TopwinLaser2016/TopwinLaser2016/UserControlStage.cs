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
    public partial class UserControlStage : UserControl
    {
        public UserControlStage()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            string[] stageIds = Enum.GetNames(typeof(StageID));
            comboBoxStage.Items.Clear();
            comboBoxStage.Items.AddRange(stageIds);
            comboBoxStage.SelectedIndex = 0;

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



        private void buttonReadStageEnabled_Click(object sender, EventArgs e)
        {
            bool enabled = FormMainWindow.Symphoney.GetStageEnabled((StageID)comboBoxStage.SelectedIndex);
            if (enabled)
            {
                radioButtonStageEnabled.Checked = true;
            }
            else
            {
                radioButtonStageDisabled.Checked = true;
            }
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonSetStageEnabled_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetStageEnabled((StageID)comboBoxStage.SelectedIndex, radioButtonStageEnabled.Checked);
        }

        private void buttonStageMove_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.StageMove((StageID)comboBoxStage.SelectedIndex, (double)numericUpDownStageMovePosition.Value, (double)numericUpDownStageMoveMaxVel.Value);
        }

        private void buttonSetStageRawPosition_Click(object sender, EventArgs e)
        {
            double position = (double)numericUpDownStageRawPosition.Value;
            StageID stageId = (StageID)comboBoxStage.SelectedIndex;

            FormMainWindow.Symphoney.SetStageRawPosition(stageId, position);
        }

        private void buttonSetStageStepPolarity_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetStageStepPolarity((StageID)comboBoxStage.SelectedIndex, radioButtonStageStepPolarityTrue.Checked);
        }

        private void buttonSetStagePulseShape_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetStagePulseShape((StageID)comboBoxStage.SelectedIndex,
                (double)numericUpDownStagePulseShapeSetupTime.Value, 
                (double)numericUpDownStagePulseShapeHoldTime.Value);
        }

        private void buttonReadStagePulseShape_Click(object sender, EventArgs e)
        {
            double setupTime, holdTime;
            FormMainWindow.Symphoney.GetStagePulseShape((StageID)comboBoxStage.SelectedIndex, out setupTime, out holdTime);
            numericUpDownStagePulseShapeSetupTime.Value = (decimal)setupTime;
            numericUpDownStagePulseShapeHoldTime.Value = (decimal)holdTime;

            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonReadStageDelay_Click(object sender, EventArgs e)
        {
            int delay = FormMainWindow.Symphoney.GetStageDelay((StageID)comboBoxStage.SelectedIndex);
            numericUpDownStageDelay.Value = delay;
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonSetStageDelay_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetStageDelay((StageID)comboBoxStage.SelectedIndex, (int)numericUpDownStageDelay.Value);
        }

        private void buttonReadStageDirPolarity_Click(object sender, EventArgs e)
        {
            bool polarity = FormMainWindow.Symphoney.GetStageDirPolarity((StageID)comboBoxStage.SelectedIndex);
            if (polarity)
            {
                radioButtonStageDirPolarityTrue.Checked = true;
            }
            else
            {
                radioButtonStageDirPolarityFalse.Checked = true;
            }
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonSetStageDirPolarity_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetStageDirPolarity((StageID)comboBoxStage.SelectedIndex, radioButtonStageDirPolarityTrue.Checked);
        }

        private void buttonReadStageLimit_Click(object sender, EventArgs e)
        {
            double upper, lower;
            FormMainWindow.Symphoney.GetStageLimits((StageID)comboBoxStage.SelectedIndex, out upper, out lower);
            numericUpDownStageLimitUpper.Value = (decimal)upper;
            numericUpDownStageLimitLower.Value = (decimal)lower;

            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonReadStageLimitPolarity_Click(object sender, EventArgs e)
        {
            bool polarity = FormMainWindow.Symphoney.GetStageLimitPolarity((StageID)comboBoxStage.SelectedIndex);
            if (polarity)
            {
                radioButtonStageLimitPolarityTrue.Checked = true;
            }
            else
            {
                radioButtonStageLimitPolarityFalse.Checked = true;
            }
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonSetStageLimitPolarity_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetStageLimitPolarity((StageID)comboBoxStage.SelectedIndex, radioButtonStageLimitPolarityTrue.Checked);
        }

        private void buttonStageMoveXYZ_Click(object sender, EventArgs e)
        {
            //FormMainWindow.Symphoney.StageMove(userControlXYMoverStage.CurrentX, userControlXYMoverStage.CurrentY, (double)numericUpDownStageMoveXYZ_Z.Value);
            FormMainWindow.Symphoney.StageMove(StageID.Z, (double)numericUpDownStageMoveXYZ_Z.Value, 0.05);
        }

        private void buttonReadStageStepPolarity_Click(object sender, EventArgs e)
        {
            bool polarity = FormMainWindow.Symphoney.GetStageStepPolarity((StageID)comboBoxStage.SelectedIndex);
            if (polarity)
            {
                radioButtonStageStepPolarityTrue.Checked = true;
            }
            else
            {
                radioButtonStageStepPolarityFalse.Checked = true;
            }
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonReadStageRawPosition_Click(object sender, EventArgs e)
        {
            StageID stageId = (StageID)comboBoxStage.SelectedIndex;

            double position = FormMainWindow.Symphoney.GetStagePosition(stageId);
            numericUpDownStageRawPosition.Value = (decimal)position;

            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonInit_Click(object sender, EventArgs e)
        {
            StageID stageId = (StageID)comboBoxStage.SelectedIndex;
            //FormMainWindow.Symphoney.StageInit(stageId);
            FormMainWindow.Symphoney.FindLimits(stageId, 5000);
        }

        private void comboBoxStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonReadStageEnabled_Click(buttonReadStageEnabled, null);
            buttonReadStageStepPolarity_Click(buttonReadStageStepPolarity, null);
            buttonReadStageRawPosition_Click(buttonReadStageRawPosition, null);
            buttonReadStageDelay_Click(buttonReadStageDelay, null);
            buttonReadStageLimitPolarity_Click(buttonReadStageLimitPolarity, null);
            buttonReadStageDirPolarity_Click(buttonReadStageDirPolarity, null);
            buttonReadStagePulseShape_Click(buttonReadStagePulseShape, null);
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
