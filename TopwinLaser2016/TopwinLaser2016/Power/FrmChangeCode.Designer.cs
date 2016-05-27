namespace TopwinLaser2016.Power
{
    partial class FrmChangeCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_Access = new System.Windows.Forms.ComboBox();
            this.tb_OldCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_NewCode = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_Access
            // 
            this.cb_Access.FormattingEnabled = true;
            this.cb_Access.Location = new System.Drawing.Point(57, 17);
            this.cb_Access.Name = "cb_Access";
            this.cb_Access.Size = new System.Drawing.Size(103, 20);
            this.cb_Access.TabIndex = 7;
            // 
            // tb_OldCode
            // 
            this.tb_OldCode.Location = new System.Drawing.Point(57, 48);
            this.tb_OldCode.MaxLength = 12;
            this.tb_OldCode.Name = "tb_OldCode";
            this.tb_OldCode.PasswordChar = '*';
            this.tb_OldCode.Size = new System.Drawing.Size(103, 21);
            this.tb_OldCode.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "旧密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "用  户";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "新密码";
            // 
            // tb_NewCode
            // 
            this.tb_NewCode.Location = new System.Drawing.Point(57, 82);
            this.tb_NewCode.MaxLength = 12;
            this.tb_NewCode.Name = "tb_NewCode";
            this.tb_NewCode.PasswordChar = '*';
            this.tb_NewCode.Size = new System.Drawing.Size(103, 21);
            this.tb_NewCode.TabIndex = 6;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(110, 125);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(50, 23);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(14, 125);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(50, 23);
            this.btn_reset.TabIndex = 9;
            this.btn_reset.Text = "修改";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // FrmChangeCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 167);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.cb_Access);
            this.Controls.Add(this.tb_NewCode);
            this.Controls.Add(this.tb_OldCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangeCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "密码修改";
            this.Load += new System.EventHandler(this.FrmChangeCode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Access;
        private System.Windows.Forms.TextBox tb_OldCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_NewCode;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_reset;
    }
}