namespace TopwinLaser2016
{
    partial class UserControlXYMover
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlXYMover));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelCurrentPositionY = new System.Windows.Forms.Label();
            this.labelCurrentPositionX = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonMoveAbsolute = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMoveAbsoluteY = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDowMoveAbsoluteX = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonMoveSW = new System.Windows.Forms.Button();
            this.buttonMoveNW = new System.Windows.Forms.Button();
            this.buttonMoveSE = new System.Windows.Forms.Button();
            this.buttonMoveNE = new System.Windows.Forms.Button();
            this.buttonMoveW = new System.Windows.Forms.Button();
            this.buttonMoveS = new System.Windows.Forms.Button();
            this.buttonMoveE = new System.Windows.Forms.Button();
            this.buttonMoveN = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownMoveRelativeStep = new System.Windows.Forms.NumericUpDown();
            this.buttonMoveHome = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoveAbsoluteY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowMoveAbsoluteX)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoveRelativeStep)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelCurrentPositionY);
            this.groupBox4.Controls.Add(this.labelCurrentPositionX);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(109, 70);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "当前位置";
            // 
            // labelCurrentPositionY
            // 
            this.labelCurrentPositionY.BackColor = System.Drawing.Color.White;
            this.labelCurrentPositionY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCurrentPositionY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentPositionY.ForeColor = System.Drawing.Color.Green;
            this.labelCurrentPositionY.Location = new System.Drawing.Point(37, 40);
            this.labelCurrentPositionY.Name = "labelCurrentPositionY";
            this.labelCurrentPositionY.Size = new System.Drawing.Size(62, 21);
            this.labelCurrentPositionY.TabIndex = 15;
            this.labelCurrentPositionY.Text = "0";
            // 
            // labelCurrentPositionX
            // 
            this.labelCurrentPositionX.BackColor = System.Drawing.Color.White;
            this.labelCurrentPositionX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCurrentPositionX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentPositionX.ForeColor = System.Drawing.Color.Green;
            this.labelCurrentPositionX.Location = new System.Drawing.Point(37, 17);
            this.labelCurrentPositionX.Name = "labelCurrentPositionX";
            this.labelCurrentPositionX.Size = new System.Drawing.Size(62, 21);
            this.labelCurrentPositionX.TabIndex = 12;
            this.labelCurrentPositionX.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "Y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "X";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonMoveAbsolute);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDownMoveAbsoluteY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDowMoveAbsoluteX);
            this.groupBox1.Location = new System.Drawing.Point(3, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 105);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "绝对移动";
            // 
            // buttonMoveAbsolute
            // 
            this.buttonMoveAbsolute.Location = new System.Drawing.Point(24, 76);
            this.buttonMoveAbsolute.Name = "buttonMoveAbsolute";
            this.buttonMoveAbsolute.Size = new System.Drawing.Size(75, 21);
            this.buttonMoveAbsolute.TabIndex = 12;
            this.buttonMoveAbsolute.Text = "开始移动";
            this.buttonMoveAbsolute.UseVisualStyleBackColor = true;
            this.buttonMoveAbsolute.Click += new System.EventHandler(this.buttonMoveAbsolute_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Y";
            // 
            // numericUpDownMoveAbsoluteY
            // 
            this.numericUpDownMoveAbsoluteY.Location = new System.Drawing.Point(37, 49);
            this.numericUpDownMoveAbsoluteY.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownMoveAbsoluteY.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownMoveAbsoluteY.Name = "numericUpDownMoveAbsoluteY";
            this.numericUpDownMoveAbsoluteY.Size = new System.Drawing.Size(62, 21);
            this.numericUpDownMoveAbsoluteY.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "X";
            // 
            // numericUpDowMoveAbsoluteX
            // 
            this.numericUpDowMoveAbsoluteX.Location = new System.Drawing.Point(37, 23);
            this.numericUpDowMoveAbsoluteX.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDowMoveAbsoluteX.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDowMoveAbsoluteX.Name = "numericUpDowMoveAbsoluteX";
            this.numericUpDowMoveAbsoluteX.Size = new System.Drawing.Size(62, 21);
            this.numericUpDowMoveAbsoluteX.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonMoveHome);
            this.groupBox2.Controls.Add(this.buttonMoveSW);
            this.groupBox2.Controls.Add(this.buttonMoveNW);
            this.groupBox2.Controls.Add(this.buttonMoveSE);
            this.groupBox2.Controls.Add(this.buttonMoveNE);
            this.groupBox2.Controls.Add(this.buttonMoveW);
            this.groupBox2.Controls.Add(this.buttonMoveS);
            this.groupBox2.Controls.Add(this.buttonMoveE);
            this.groupBox2.Controls.Add(this.buttonMoveN);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numericUpDownMoveRelativeStep);
            this.groupBox2.Location = new System.Drawing.Point(118, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 181);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "相对移动";
            // 
            // buttonMoveSW
            // 
            this.buttonMoveSW.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMoveSW.BackgroundImage")));
            this.buttonMoveSW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMoveSW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveSW.Location = new System.Drawing.Point(9, 149);
            this.buttonMoveSW.Name = "buttonMoveSW";
            this.buttonMoveSW.Size = new System.Drawing.Size(23, 21);
            this.buttonMoveSW.TabIndex = 20;
            this.buttonMoveSW.UseVisualStyleBackColor = true;
            this.buttonMoveSW.Click += new System.EventHandler(this.buttonMoveSW_Click);
            // 
            // buttonMoveNW
            // 
            this.buttonMoveNW.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMoveNW.BackgroundImage")));
            this.buttonMoveNW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMoveNW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveNW.Location = new System.Drawing.Point(9, 84);
            this.buttonMoveNW.Name = "buttonMoveNW";
            this.buttonMoveNW.Size = new System.Drawing.Size(23, 21);
            this.buttonMoveNW.TabIndex = 19;
            this.buttonMoveNW.UseVisualStyleBackColor = true;
            this.buttonMoveNW.Click += new System.EventHandler(this.buttonMoveNW_Click);
            // 
            // buttonMoveSE
            // 
            this.buttonMoveSE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMoveSE.BackgroundImage")));
            this.buttonMoveSE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMoveSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveSE.Location = new System.Drawing.Point(81, 149);
            this.buttonMoveSE.Name = "buttonMoveSE";
            this.buttonMoveSE.Size = new System.Drawing.Size(23, 21);
            this.buttonMoveSE.TabIndex = 18;
            this.buttonMoveSE.UseVisualStyleBackColor = true;
            this.buttonMoveSE.Click += new System.EventHandler(this.buttonMoveSE_Click);
            // 
            // buttonMoveNE
            // 
            this.buttonMoveNE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMoveNE.BackgroundImage")));
            this.buttonMoveNE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMoveNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveNE.Location = new System.Drawing.Point(81, 84);
            this.buttonMoveNE.Name = "buttonMoveNE";
            this.buttonMoveNE.Size = new System.Drawing.Size(23, 21);
            this.buttonMoveNE.TabIndex = 17;
            this.buttonMoveNE.UseVisualStyleBackColor = true;
            this.buttonMoveNE.Click += new System.EventHandler(this.buttonMoveNE_Click);
            // 
            // buttonMoveW
            // 
            this.buttonMoveW.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMoveW.BackgroundImage")));
            this.buttonMoveW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMoveW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveW.Location = new System.Drawing.Point(9, 114);
            this.buttonMoveW.Name = "buttonMoveW";
            this.buttonMoveW.Size = new System.Drawing.Size(33, 21);
            this.buttonMoveW.TabIndex = 16;
            this.buttonMoveW.UseVisualStyleBackColor = true;
            this.buttonMoveW.Click += new System.EventHandler(this.buttonMoveW_Click);
            // 
            // buttonMoveS
            // 
            this.buttonMoveS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMoveS.BackgroundImage")));
            this.buttonMoveS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMoveS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveS.Location = new System.Drawing.Point(46, 140);
            this.buttonMoveS.Name = "buttonMoveS";
            this.buttonMoveS.Size = new System.Drawing.Size(23, 30);
            this.buttonMoveS.TabIndex = 15;
            this.buttonMoveS.UseVisualStyleBackColor = true;
            this.buttonMoveS.Click += new System.EventHandler(this.buttonMoveS_Click);
            // 
            // buttonMoveE
            // 
            this.buttonMoveE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMoveE.BackgroundImage")));
            this.buttonMoveE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMoveE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveE.Location = new System.Drawing.Point(72, 115);
            this.buttonMoveE.Name = "buttonMoveE";
            this.buttonMoveE.Size = new System.Drawing.Size(32, 21);
            this.buttonMoveE.TabIndex = 14;
            this.buttonMoveE.UseVisualStyleBackColor = true;
            this.buttonMoveE.Click += new System.EventHandler(this.buttonMoveE_Click);
            // 
            // buttonMoveN
            // 
            this.buttonMoveN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMoveN.BackgroundImage")));
            this.buttonMoveN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMoveN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveN.Location = new System.Drawing.Point(46, 84);
            this.buttonMoveN.Name = "buttonMoveN";
            this.buttonMoveN.Size = new System.Drawing.Size(23, 27);
            this.buttonMoveN.TabIndex = 13;
            this.buttonMoveN.UseVisualStyleBackColor = true;
            this.buttonMoveN.Click += new System.EventHandler(this.buttonMoveN_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "移动步长";
            // 
            // numericUpDownMoveRelativeStep
            // 
            this.numericUpDownMoveRelativeStep.Location = new System.Drawing.Point(9, 41);
            this.numericUpDownMoveRelativeStep.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownMoveRelativeStep.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownMoveRelativeStep.Name = "numericUpDownMoveRelativeStep";
            this.numericUpDownMoveRelativeStep.Size = new System.Drawing.Size(95, 21);
            this.numericUpDownMoveRelativeStep.TabIndex = 8;
            this.numericUpDownMoveRelativeStep.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // buttonMoveHome
            // 
            this.buttonMoveHome.Location = new System.Drawing.Point(46, 114);
            this.buttonMoveHome.Name = "buttonMoveHome";
            this.buttonMoveHome.Size = new System.Drawing.Size(23, 22);
            this.buttonMoveHome.TabIndex = 21;
            this.buttonMoveHome.UseVisualStyleBackColor = true;
            this.buttonMoveHome.Click += new System.EventHandler(this.buttonMoveHome_Click);
            // 
            // UserControlXYMover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "UserControlXYMover";
            this.Size = new System.Drawing.Size(250, 194);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoveAbsoluteY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowMoveAbsoluteX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoveRelativeStep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelCurrentPositionY;
        private System.Windows.Forms.Label labelCurrentPositionX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonMoveAbsolute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMoveAbsoluteY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDowMoveAbsoluteX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonMoveSW;
        private System.Windows.Forms.Button buttonMoveNW;
        private System.Windows.Forms.Button buttonMoveSE;
        private System.Windows.Forms.Button buttonMoveNE;
        private System.Windows.Forms.Button buttonMoveW;
        private System.Windows.Forms.Button buttonMoveS;
        private System.Windows.Forms.Button buttonMoveE;
        private System.Windows.Forms.Button buttonMoveN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownMoveRelativeStep;
        private System.Windows.Forms.Button buttonMoveHome;
    }
}
