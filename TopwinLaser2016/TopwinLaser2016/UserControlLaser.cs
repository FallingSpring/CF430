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
    public partial class UserControlLaser : UserControl
    {
        public UserControlLaser()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            buttonReadLaserEnabled_Click(buttonReadLaserEnabled, null);
            buttonReadLaserRepRate_Click(buttonReadLaserRepRate, null);
            buttonReadLaserOn_Click(buttonReadLaserOn, null);
            buttonReadLaserGateStartDelay_Click(buttonReadLaserGateStartDelay, null);
            buttonReadLaserGatePolarity_Click(buttonReadLaserGatePolarity, null);
            buttonReadLaserGateStopDelay_Click(buttonReadLaserGateStopDelay, null);
            buttonReadLaserClockPolarity_Click(buttonReadLaserClockPolarity, null);
            buttonReadLaserFirstPulseDelay_Click(buttonReadLaserFirstPulseDelay, null);
            buttonReadLaserSimmer_Click(buttonReadLaserSimmer, null);
        }

        private void buttonReadLaserEnabled_Click(object sender, EventArgs e)
        {
            bool val = FormMainWindow.Symphoney.GetLaserEnabled();
            if (val)
            {
                radioButtonLaserEnabledTrue.Checked = true;
            }
            else
            {
                radioButtonLaserEnabledFalse.Checked = true;
            }
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonReadLaserOn_Click(object sender, EventArgs e)
        {
            bool val = FormMainWindow.Symphoney.GetLaserOn();
            if (val)
            {
                radioButtonLaserOnTrue.Checked = true;
            }
            else
            {
                radioButtonLaserOnFalse.Checked = true;
            }
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonReadLaserGatePolarity_Click(object sender, EventArgs e)
        {
            bool val = FormMainWindow.Symphoney.GetGatePolarity();
            if (val)
            {
                radioButtonLaserGatePolarityTrue.Checked = true;
            }
            else
            {
                radioButtonLaserGatePolarityFalse.Checked = true;
            }
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonReadLaserClockPolarity_Click(object sender, EventArgs e)
        {
            bool val = FormMainWindow.Symphoney.GetClockPolarity();
            if (val)
            {
                radioButtonLaserClockPolarityTrue.Checked = true;
            }
            else
            {
                radioButtonLaserClockPolarityFalse.Checked = true;
            }
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonSetLaserEnabled_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetLaserEnabled(radioButtonLaserEnabledTrue.Checked);
        }

        private void buttonSetLaserOn_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetLaserOn(radioButtonLaserOnTrue.Checked);
        }

        private void buttonSetLaserGatePolarity_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetGatePolarity(radioButtonLaserGatePolarityTrue.Checked);
        }

        private void buttonSetLaserClockPolarity_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetClockPolarity(radioButtonLaserClockPolarityTrue.Checked);
        }

        private void buttonReadLaserRepRate_Click(object sender, EventArgs e)
        {
            int val = FormMainWindow.Symphoney.GetRepRate();
            numericUpDownLaserRepRate.Value = val;
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonReadLaserGateStartDelay_Click(object sender, EventArgs e)
        {
            int val = FormMainWindow.Symphoney.GetGateStartDelay();
            numericUpDownLaserGateStartDelay.Value = val;
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonReadLaserGateStopDelay_Click(object sender, EventArgs e)
        {
            int val = FormMainWindow.Symphoney.GetGateStopDelay();
            numericUpDownLaserGateStopDelay.Value = val;
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonReadLaserFirstPulseDelay_Click(object sender, EventArgs e)
        {
            int val = FormMainWindow.Symphoney.GetFirstPulseDelay();
            numericUpDownLaserFirstPulseDelay.Value = val;
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonSetLaserRepRate_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetRepRate((int)numericUpDownLaserRepRate.Value);
        }

        private void buttonSetLaserGateStartDelay_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetGateStartDelay((int)numericUpDownLaserGateStartDelay.Value);
        }

        private void buttonSetLaserGateStopDelay_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetGateStopDelay((int)numericUpDownLaserGateStopDelay.Value);
        }

        private void buttonSetLaserFirstPulseDelay_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetFirstPulseDelay((int)numericUpDownLaserFirstPulseDelay.Value);
        }

        private void buttonReadLaserSimmer_Click(object sender, EventArgs e)
        {
            bool gate, clock;
            int delay, freq, pw;
            FormMainWindow.Symphoney.GetLaserSimmer(out gate, out clock, out delay, out freq, out pw);
            if (gate)
            {
                radioButtonLaserSimmerGateTrue.Checked = true;
            }
            else
            {
                radioButtonLaserSimmerGateFalse.Checked = true;
            }

            if (clock)
            {
                radioButtonLaserSimmerClockTrue.Checked = true;
            }
            else
            {
                radioButtonLaserSimmerClockFalse.Checked = true;
            }

            numericUpDownLaserSimmerDelay.Value = delay;
            numericUpDownLaserSimmerFreq.Value = freq;
            numericUpDownLaserSimmerPW.Value = pw;
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }


        private void buttonSetLaserSimmer_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetLaserSimmer(radioButtonLaserSimmerGateTrue.Checked, radioButtonLaserSimmerClockTrue.Checked, (int)numericUpDownLaserSimmerDelay.Value, (int)numericUpDownLaserSimmerFreq.Value, (int)numericUpDownLaserSimmerPW.Value);
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
