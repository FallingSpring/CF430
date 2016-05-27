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
    public partial class FrmLogin : Form
    {
        private string[] access = {"操作工", "工程师", "管理员", "拓普银"};
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            InitUI();
        }

        private void InitUI()
        {
            cb_Access.Items.Clear();
            int power = -1;

            if ((int)Power.Access < 2)
            {
                power = 2;
                btn_reset.Visible = false;
            }
            else
            {
                power = 3;
                btn_reset.Visible = true;
            }

            for (;power >= 0; power--)
            {
                cb_Access.Items.Insert(0, access[power]);
            }

            cb_Access.SelectedIndex = 0;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            POWER power = (POWER)cb_Access.SelectedIndex;
            string access = cb_Access.Text;
            string code = tb_Code.Text.Trim();

            if(Power.CheckPower(power, code, access))
            {
                MessageBox.Show("权限切换成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("密码错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            FrmChangeCode dlg = new FrmChangeCode();
            dlg.ShowDialog();
            DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
