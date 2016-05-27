using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopwinLaser2016.Power
{
    public partial class FrmChangeCode : Form
    {
        private string[] access = { "操作工", "工程师", "管理员", "拓普银" };

        public FrmChangeCode()
        {
            InitializeComponent();
        }

        private void FrmChangeCode_Load(object sender, EventArgs e)
        {
            InitUI();
        }

        private void InitUI()
        {
            cb_Access.Items.Clear();
            int power = -1;

            if ((int)Power.Access < 3)
            {
                power = 2;
                for (; power >= 0; power--)
                {
                    cb_Access.Items.Insert(0, access[power]);
                }
            }
            else
            {
                power = (int)POWER.TOPWIN;
                cb_Access.Items.Add(access[power]);
            }

            cb_Access.SelectedIndex = 0;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            POWER power = (POWER)cb_Access.SelectedIndex;
            string OldCode = tb_OldCode.Text.Trim();
            string NewCode = tb_NewCode.Text.Trim();

            if (Power.ChangePowerCode(power, OldCode, NewCode))
            {
                MessageBox.Show("密码修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("旧密码错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        
    }
}
