namespace TopwinLaser2016
{
    partial class UserControlMachining
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
            this.button_LaserSwitch = new System.Windows.Forms.Button();
            this.button_IndicationLight = new System.Windows.Forms.Button();
            this.button_BeginMachining = new System.Windows.Forms.Button();
            this.button_SuspendMachining = new System.Windows.Forms.Button();
            this.button_StopMachining = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_LaserSwitch
            // 
            this.button_LaserSwitch.Location = new System.Drawing.Point(6, 20);
            this.button_LaserSwitch.Name = "button_LaserSwitch";
            this.button_LaserSwitch.Size = new System.Drawing.Size(75, 23);
            this.button_LaserSwitch.TabIndex = 0;
            this.button_LaserSwitch.Text = "开激光";
            this.button_LaserSwitch.UseVisualStyleBackColor = true;
            // 
            // button_IndicationLight
            // 
            this.button_IndicationLight.Location = new System.Drawing.Point(6, 49);
            this.button_IndicationLight.Name = "button_IndicationLight";
            this.button_IndicationLight.Size = new System.Drawing.Size(75, 23);
            this.button_IndicationLight.TabIndex = 0;
            this.button_IndicationLight.Text = "指示光";
            this.button_IndicationLight.UseVisualStyleBackColor = true;
            // 
            // button_BeginMachining
            // 
            this.button_BeginMachining.Location = new System.Drawing.Point(153, 20);
            this.button_BeginMachining.Name = "button_BeginMachining";
            this.button_BeginMachining.Size = new System.Drawing.Size(75, 23);
            this.button_BeginMachining.TabIndex = 0;
            this.button_BeginMachining.Text = "开始加工";
            this.button_BeginMachining.UseVisualStyleBackColor = true;
            // 
            // button_SuspendMachining
            // 
            this.button_SuspendMachining.Location = new System.Drawing.Point(153, 78);
            this.button_SuspendMachining.Name = "button_SuspendMachining";
            this.button_SuspendMachining.Size = new System.Drawing.Size(75, 23);
            this.button_SuspendMachining.TabIndex = 0;
            this.button_SuspendMachining.Text = "暂停加工";
            this.button_SuspendMachining.UseVisualStyleBackColor = true;
            // 
            // button_StopMachining
            // 
            this.button_StopMachining.Location = new System.Drawing.Point(153, 49);
            this.button_StopMachining.Name = "button_StopMachining";
            this.button_StopMachining.Size = new System.Drawing.Size(75, 23);
            this.button_StopMachining.TabIndex = 0;
            this.button_StopMachining.Text = "停止加工";
            this.button_StopMachining.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_LaserSwitch);
            this.groupBox1.Controls.Add(this.button_StopMachining);
            this.groupBox1.Controls.Add(this.button_IndicationLight);
            this.groupBox1.Controls.Add(this.button_SuspendMachining);
            this.groupBox1.Controls.Add(this.button_BeginMachining);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 114);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // UserControlMachining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlMachining";
            this.Size = new System.Drawing.Size(250, 120);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_LaserSwitch;
        private System.Windows.Forms.Button button_IndicationLight;
        private System.Windows.Forms.Button button_BeginMachining;
        private System.Windows.Forms.Button button_SuspendMachining;
        private System.Windows.Forms.Button button_StopMachining;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
