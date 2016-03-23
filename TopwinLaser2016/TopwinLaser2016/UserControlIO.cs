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
    public partial class UserControlIO : UserControl
    {
        public UserControlIO()
        {
            InitializeComponent();
        }
        public void Initialize()
        {
            buttonReadAllOutputs_Click(buttonReadAllOutputs, null);
            buttonReadAllInputs_Click(buttonReadAllInputs, null);
        }


        private void buttonSetIODigitalPutputs_Click(object sender, EventArgs e)
        {
            List<int> outputs = new List<int>();
            List<bool> values = new List<bool>();
            foreach (DataGridViewRow row in dataGridViewIODigitalOutputs.Rows)
            {
                if ((row.Cells[0].Value != null) && (!string.IsNullOrEmpty(row.Cells[0].Value.ToString())))
                {
                    try
                    {
                        DataGridViewCheckBoxCell chk = ((DataGridViewCheckBoxCell)row.Cells[1]);
                        int outV = int.Parse(row.Cells[0].Value.ToString());
                        bool valV = (chk.Value == chk.TrueValue);
                        outputs.Add(outV);
                        values.Add(valV);
                    }
                    catch
                    {

                    }
                }
            }
            FormMainWindow.Symphoney.SetDigitalOutputs(outputs, values);

        }

        private void buttonReadAllOutputs_Click(object sender, EventArgs e)
        {
            dataGridViewIODigitalOutputs.Rows.Clear();
            for (int i = 0; i < 10000; i++)
            {
                try
                {
                    bool value = FormMainWindow.Symphoney.GetDigitalOutput(i);
                    dataGridViewIODigitalOutputs.Rows.Add(new object[] { i, value });
                }
                catch
                {
                    break;
                }

            }
        }

        private void buttonReadAllInputs_Click(object sender, EventArgs e)
        {
            dataGridViewDigitalInputs.Rows.Clear();
            for (int i = 0; i < 10000; i++)
            {
                try
                {
                    bool value = FormMainWindow.Symphoney.GetDigitalInput(i);
                    dataGridViewDigitalInputs.Rows.Add(new object[] { i, value });
                }
                catch
                {
                    break;
                }

            }
        }
    }
}
