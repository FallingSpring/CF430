namespace TopwinLaser2016
{
    partial class UserControlAxis
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxAsix = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxAxisKinematicConstraints = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownAxisKinematicConstraintsMaxAccel = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownAxisKinematicConstraintsMaxVel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownAxisKinematicConstraintsMinMT = new System.Windows.Forms.NumericUpDown();
            this.buttonReadAxisKinematicConstraints = new System.Windows.Forms.Button();
            this.buttonSetAxisKinematicConstraints = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonReadAsixUseUtilityTransform = new System.Windows.Forms.Button();
            this.radioButtonAsixUseUnityTransformFalse = new System.Windows.Forms.RadioButton();
            this.buttonSetAxisUseUtilityTransform = new System.Windows.Forms.Button();
            this.radioButtonAsixUseUnityTransformTrue = new System.Windows.Forms.RadioButton();
            this.s = new System.Windows.Forms.Label();
            this.groupBoxAxisKinematicConstraints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAxisKinematicConstraintsMaxAccel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAxisKinematicConstraintsMaxVel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAxisKinematicConstraintsMinMT)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxAsix
            // 
            this.comboBoxAsix.FormattingEnabled = true;
            this.comboBoxAsix.Location = new System.Drawing.Point(45, 4);
            this.comboBoxAsix.Name = "comboBoxAsix";
            this.comboBoxAsix.Size = new System.Drawing.Size(162, 20);
            this.comboBoxAsix.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "轴";
            // 
            // groupBoxAxisKinematicConstraints
            // 
            this.groupBoxAxisKinematicConstraints.Controls.Add(this.label6);
            this.groupBoxAxisKinematicConstraints.Controls.Add(this.label5);
            this.groupBoxAxisKinematicConstraints.Controls.Add(this.label3);
            this.groupBoxAxisKinematicConstraints.Controls.Add(this.numericUpDownAxisKinematicConstraintsMaxAccel);
            this.groupBoxAxisKinematicConstraints.Controls.Add(this.label2);
            this.groupBoxAxisKinematicConstraints.Controls.Add(this.numericUpDownAxisKinematicConstraintsMaxVel);
            this.groupBoxAxisKinematicConstraints.Controls.Add(this.label1);
            this.groupBoxAxisKinematicConstraints.Controls.Add(this.numericUpDownAxisKinematicConstraintsMinMT);
            this.groupBoxAxisKinematicConstraints.Controls.Add(this.buttonReadAxisKinematicConstraints);
            this.groupBoxAxisKinematicConstraints.Controls.Add(this.buttonSetAxisKinematicConstraints);
            this.groupBoxAxisKinematicConstraints.Location = new System.Drawing.Point(7, 39);
            this.groupBoxAxisKinematicConstraints.Name = "groupBoxAxisKinematicConstraints";
            this.groupBoxAxisKinematicConstraints.Size = new System.Drawing.Size(249, 111);
            this.groupBoxAxisKinematicConstraints.TabIndex = 7;
            this.groupBoxAxisKinematicConstraints.TabStop = false;
            this.groupBoxAxisKinematicConstraints.Text = "运动约束";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "G";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "m/s";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "最大加速度";
            // 
            // numericUpDownAxisKinematicConstraintsMaxAccel
            // 
            this.numericUpDownAxisKinematicConstraintsMaxAccel.DecimalPlaces = 4;
            this.numericUpDownAxisKinematicConstraintsMaxAccel.Location = new System.Drawing.Point(113, 56);
            this.numericUpDownAxisKinematicConstraintsMaxAccel.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownAxisKinematicConstraintsMaxAccel.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownAxisKinematicConstraintsMaxAccel.Name = "numericUpDownAxisKinematicConstraintsMaxAccel";
            this.numericUpDownAxisKinematicConstraintsMaxAccel.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownAxisKinematicConstraintsMaxAccel.TabIndex = 6;
            this.numericUpDownAxisKinematicConstraintsMaxAccel.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownAxisKinematicConstraintsMaxAccel.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "最大速度";
            // 
            // numericUpDownAxisKinematicConstraintsMaxVel
            // 
            this.numericUpDownAxisKinematicConstraintsMaxVel.DecimalPlaces = 4;
            this.numericUpDownAxisKinematicConstraintsMaxVel.Location = new System.Drawing.Point(113, 37);
            this.numericUpDownAxisKinematicConstraintsMaxVel.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownAxisKinematicConstraintsMaxVel.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownAxisKinematicConstraintsMaxVel.Name = "numericUpDownAxisKinematicConstraintsMaxVel";
            this.numericUpDownAxisKinematicConstraintsMaxVel.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownAxisKinematicConstraintsMaxVel.TabIndex = 4;
            this.numericUpDownAxisKinematicConstraintsMaxVel.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownAxisKinematicConstraintsMaxVel.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "最小响应时间";
            // 
            // numericUpDownAxisKinematicConstraintsMinMT
            // 
            this.numericUpDownAxisKinematicConstraintsMinMT.DecimalPlaces = 4;
            this.numericUpDownAxisKinematicConstraintsMinMT.Location = new System.Drawing.Point(113, 18);
            this.numericUpDownAxisKinematicConstraintsMinMT.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownAxisKinematicConstraintsMinMT.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownAxisKinematicConstraintsMinMT.Name = "numericUpDownAxisKinematicConstraintsMinMT";
            this.numericUpDownAxisKinematicConstraintsMinMT.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownAxisKinematicConstraintsMinMT.TabIndex = 2;
            this.numericUpDownAxisKinematicConstraintsMinMT.Value = new decimal(new int[] {
            15,
            0,
            0,
            196608});
            this.numericUpDownAxisKinematicConstraintsMinMT.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // buttonReadAxisKinematicConstraints
            // 
            this.buttonReadAxisKinematicConstraints.Location = new System.Drawing.Point(14, 80);
            this.buttonReadAxisKinematicConstraints.Name = "buttonReadAxisKinematicConstraints";
            this.buttonReadAxisKinematicConstraints.Size = new System.Drawing.Size(75, 21);
            this.buttonReadAxisKinematicConstraints.TabIndex = 0;
            this.buttonReadAxisKinematicConstraints.Text = "Read";
            this.buttonReadAxisKinematicConstraints.UseVisualStyleBackColor = true;
            this.buttonReadAxisKinematicConstraints.Click += new System.EventHandler(this.buttonReadAxisKinematicConstraints_Click);
            // 
            // buttonSetAxisKinematicConstraints
            // 
            this.buttonSetAxisKinematicConstraints.Location = new System.Drawing.Point(113, 80);
            this.buttonSetAxisKinematicConstraints.Name = "buttonSetAxisKinematicConstraints";
            this.buttonSetAxisKinematicConstraints.Size = new System.Drawing.Size(75, 21);
            this.buttonSetAxisKinematicConstraints.TabIndex = 1;
            this.buttonSetAxisKinematicConstraints.Text = "Set";
            this.buttonSetAxisKinematicConstraints.UseVisualStyleBackColor = true;
            this.buttonSetAxisKinematicConstraints.Click += new System.EventHandler(this.buttonSetAxisKinematicConstraints_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonReadAsixUseUtilityTransform);
            this.groupBox1.Controls.Add(this.radioButtonAsixUseUnityTransformFalse);
            this.groupBox1.Controls.Add(this.buttonSetAxisUseUtilityTransform);
            this.groupBox1.Controls.Add(this.radioButtonAsixUseUnityTransformTrue);
            this.groupBox1.Location = new System.Drawing.Point(7, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 67);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "使用组合形态";
            // 
            // buttonReadAsixUseUtilityTransform
            // 
            this.buttonReadAsixUseUtilityTransform.Location = new System.Drawing.Point(113, 15);
            this.buttonReadAsixUseUtilityTransform.Name = "buttonReadAsixUseUtilityTransform";
            this.buttonReadAsixUseUtilityTransform.Size = new System.Drawing.Size(75, 21);
            this.buttonReadAsixUseUtilityTransform.TabIndex = 0;
            this.buttonReadAsixUseUtilityTransform.Text = "Read";
            this.buttonReadAsixUseUtilityTransform.UseVisualStyleBackColor = true;
            this.buttonReadAsixUseUtilityTransform.Click += new System.EventHandler(this.buttonReadAsixUseUtilityTransform_Click);
            // 
            // radioButtonAsixUseUnityTransformFalse
            // 
            this.radioButtonAsixUseUnityTransformFalse.AutoSize = true;
            this.radioButtonAsixUseUnityTransformFalse.Location = new System.Drawing.Point(8, 37);
            this.radioButtonAsixUseUnityTransformFalse.Name = "radioButtonAsixUseUnityTransformFalse";
            this.radioButtonAsixUseUnityTransformFalse.Size = new System.Drawing.Size(53, 16);
            this.radioButtonAsixUseUnityTransformFalse.TabIndex = 3;
            this.radioButtonAsixUseUnityTransformFalse.Text = "False";
            this.radioButtonAsixUseUnityTransformFalse.UseVisualStyleBackColor = true;
            // 
            // buttonSetAxisUseUtilityTransform
            // 
            this.buttonSetAxisUseUtilityTransform.Location = new System.Drawing.Point(113, 38);
            this.buttonSetAxisUseUtilityTransform.Name = "buttonSetAxisUseUtilityTransform";
            this.buttonSetAxisUseUtilityTransform.Size = new System.Drawing.Size(75, 21);
            this.buttonSetAxisUseUtilityTransform.TabIndex = 1;
            this.buttonSetAxisUseUtilityTransform.Text = "Set";
            this.buttonSetAxisUseUtilityTransform.UseVisualStyleBackColor = true;
            this.buttonSetAxisUseUtilityTransform.Click += new System.EventHandler(this.buttonSetAxisUseUtilityTransform_Click);
            // 
            // radioButtonAsixUseUnityTransformTrue
            // 
            this.radioButtonAsixUseUnityTransformTrue.AutoSize = true;
            this.radioButtonAsixUseUnityTransformTrue.Checked = true;
            this.radioButtonAsixUseUnityTransformTrue.Location = new System.Drawing.Point(8, 20);
            this.radioButtonAsixUseUnityTransformTrue.Name = "radioButtonAsixUseUnityTransformTrue";
            this.radioButtonAsixUseUnityTransformTrue.Size = new System.Drawing.Size(47, 16);
            this.radioButtonAsixUseUnityTransformTrue.TabIndex = 2;
            this.radioButtonAsixUseUnityTransformTrue.TabStop = true;
            this.radioButtonAsixUseUnityTransformTrue.Text = "True";
            this.radioButtonAsixUseUnityTransformTrue.UseVisualStyleBackColor = false;
            this.radioButtonAsixUseUnityTransformTrue.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // s
            // 
            this.s.AutoSize = true;
            this.s.Location = new System.Drawing.Point(197, 59);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(11, 12);
            this.s.TabIndex = 10;
            this.s.Text = "s";
            // 
            // UserControlAxis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.s);
            this.Controls.Add(this.comboBoxAsix);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBoxAxisKinematicConstraints);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlAxis";
            this.Size = new System.Drawing.Size(400, 364);
            this.groupBoxAxisKinematicConstraints.ResumeLayout(false);
            this.groupBoxAxisKinematicConstraints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAxisKinematicConstraintsMaxAccel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAxisKinematicConstraintsMaxVel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAxisKinematicConstraintsMinMT)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAsix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxAxisKinematicConstraints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownAxisKinematicConstraintsMaxAccel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownAxisKinematicConstraintsMaxVel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownAxisKinematicConstraintsMinMT;
        private System.Windows.Forms.Button buttonReadAxisKinematicConstraints;
        private System.Windows.Forms.Button buttonSetAxisKinematicConstraints;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonReadAsixUseUtilityTransform;
        private System.Windows.Forms.RadioButton radioButtonAsixUseUnityTransformFalse;
        private System.Windows.Forms.Button buttonSetAxisUseUtilityTransform;
        private System.Windows.Forms.RadioButton radioButtonAsixUseUnityTransformTrue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label s;
    }
}
