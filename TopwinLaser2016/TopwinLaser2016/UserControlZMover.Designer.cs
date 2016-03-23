namespace TopwinLaser2016
{
    partial class UserControlZMover
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonStageMoveXYZ = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownStageMoveXYZ_Z = new System.Windows.Forms.NumericUpDown();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageMoveXYZ_Z)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonStageMoveXYZ);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.numericUpDownStageMoveXYZ_Z);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(233, 56);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Z轴";
            // 
            // buttonStageMoveXYZ
            // 
            this.buttonStageMoveXYZ.Location = new System.Drawing.Point(153, 18);
            this.buttonStageMoveXYZ.Name = "buttonStageMoveXYZ";
            this.buttonStageMoveXYZ.Size = new System.Drawing.Size(75, 21);
            this.buttonStageMoveXYZ.TabIndex = 12;
            this.buttonStageMoveXYZ.Text = "开始移动";
            this.buttonStageMoveXYZ.UseVisualStyleBackColor = true;
            this.buttonStageMoveXYZ.Click += new System.EventHandler(this.buttonStageMoveXYZ_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "Z";
            // 
            // numericUpDownStageMoveXYZ_Z
            // 
            this.numericUpDownStageMoveXYZ_Z.Location = new System.Drawing.Point(28, 19);
            this.numericUpDownStageMoveXYZ_Z.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownStageMoveXYZ_Z.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownStageMoveXYZ_Z.Name = "numericUpDownStageMoveXYZ_Z";
            this.numericUpDownStageMoveXYZ_Z.Size = new System.Drawing.Size(83, 21);
            this.numericUpDownStageMoveXYZ_Z.TabIndex = 10;
            // 
            // UserControlZMover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Name = "UserControlZMover";
            this.Size = new System.Drawing.Size(250, 62);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageMoveXYZ_Z)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonStageMoveXYZ;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownStageMoveXYZ_Z;
    }
}
