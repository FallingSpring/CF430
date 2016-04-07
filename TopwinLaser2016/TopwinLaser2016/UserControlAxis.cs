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
    public partial class UserControlAxis : UserControl
    {
        public UserControlAxis()
        {
            InitializeComponent();
        }

        public void Initialize()
        {

            string[] axises = Enum.GetNames(typeof(AxisID));
            comboBoxAsix.Items.Clear();
            comboBoxAsix.Items.AddRange(axises);
            comboBoxAsix.SelectedIndex = 0;

        }

        private void buttonReadAxisKinematicConstraints_Click(object sender, EventArgs e)
        {
            double minMT, maxVel, maxAccel = 0;

            FormMainWindow.Symphoney.GetKinematicConstraints((AxisID)comboBoxAsix.SelectedIndex, out minMT, out maxVel, out maxAccel);
            numericUpDownAxisKinematicConstraintsMinMT.Value = (decimal)minMT;
            numericUpDownAxisKinematicConstraintsMaxVel.Value = (decimal)maxVel;
            numericUpDownAxisKinematicConstraintsMaxAccel.Value = (decimal)maxAccel;

            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        public void buttonSetAxisKinematicConstraints_Click(object sender, EventArgs e)
        {
            double minMT = (double)numericUpDownAxisKinematicConstraintsMinMT.Value;
            double maxVel = (double)numericUpDownAxisKinematicConstraintsMaxVel.Value;
            double maxAccel = (double)numericUpDownAxisKinematicConstraintsMaxAccel.Value;

            FormMainWindow.Symphoney.SetKinematicConstraints((AxisID)comboBoxAsix.SelectedIndex, minMT, maxVel, maxAccel);

        }

        private void buttonReadAsixUseUtilityTransform_Click(object sender, EventArgs e)
        {
            bool value = FormMainWindow.Symphoney.GetUseUnityTransform((AxisID)comboBoxAsix.SelectedIndex);
            if (value)
            {
                radioButtonAsixUseUnityTransformTrue.Checked = true;
            }
            else
            {
                radioButtonAsixUseUnityTransformFalse.Checked = true;
            }
            FormMainWindow.SetSyncedMode((GroupBox)((Button)sender).Parent, true);
        }

        private void buttonSetAxisUseUtilityTransform_Click(object sender, EventArgs e)
        {
            FormMainWindow.Symphoney.SetUseUnityTransform((AxisID)comboBoxAsix.SelectedIndex, radioButtonAsixUseUnityTransformTrue.Checked);
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
