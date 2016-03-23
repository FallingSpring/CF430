using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopwinLaser2016
{
    public partial class ExceptionDialog : Form
    {
        Exception _ex;

        public ExceptionDialog(Exception ex)
        {
            InitializeComponent();

            _ex = ex;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            txtMessage.Text = _ex.Message;
            btnNestedException.Visible = _ex.InnerException != null;
            this.Text = _ex.GetType().Name;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnStackTrace_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, _ex.StackTrace, "Stack Trace", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNestedException_Click(object sender, EventArgs e)
        {
            using (var diag = new ExceptionDialog(_ex.InnerException))
            {
                diag.ShowDialog(this);
            }
        }
    }
}
