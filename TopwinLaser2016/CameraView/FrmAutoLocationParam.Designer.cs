namespace CameraView
{
    partial class FrmAutoLocationParam
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
            this.r_Standard = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.r_Userdefine = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_Constrast = new System.Windows.Forms.TextBox();
            this.tb_MinScale = new System.Windows.Forms.TextBox();
            this.tb_MaxScale = new System.Windows.Forms.TextBox();
            this.tb_CircleR = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ck_ChekFirstOffset = new System.Windows.Forms.CheckBox();
            this.tb_OffsetY = new System.Windows.Forms.TextBox();
            this.tb_OffsetX = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tb_MatchSpeed = new System.Windows.Forms.TextBox();
            this.tb_MatchTimes = new System.Windows.Forms.TextBox();
            this.tb_MatchScore = new System.Windows.Forms.TextBox();
            this.tb_MatchNum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tb_AreaMax = new System.Windows.Forms.TextBox();
            this.tb_AreaMin = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // r_Standard
            // 
            this.r_Standard.AutoSize = true;
            this.r_Standard.Location = new System.Drawing.Point(126, 20);
            this.r_Standard.Name = "r_Standard";
            this.r_Standard.Size = new System.Drawing.Size(71, 16);
            this.r_Standard.TabIndex = 0;
            this.r_Standard.TabStop = true;
            this.r_Standard.Text = "标准模板";
            this.r_Standard.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.r_Userdefine);
            this.groupBox1.Controls.Add(this.r_Standard);
            this.groupBox1.Location = new System.Drawing.Point(80, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模板类型";
            // 
            // r_Userdefine
            // 
            this.r_Userdefine.AutoSize = true;
            this.r_Userdefine.Location = new System.Drawing.Point(293, 20);
            this.r_Userdefine.Name = "r_Userdefine";
            this.r_Userdefine.Size = new System.Drawing.Size(83, 16);
            this.r_Userdefine.TabIndex = 0;
            this.r_Userdefine.TabStop = true;
            this.r_Userdefine.Text = "自定义模板";
            this.r_Userdefine.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_Constrast);
            this.groupBox2.Controls.Add(this.tb_MinScale);
            this.groupBox2.Controls.Add(this.tb_MaxScale);
            this.groupBox2.Controls.Add(this.tb_CircleR);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 159);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "标准模板参数";
            // 
            // tb_Constrast
            // 
            this.tb_Constrast.Location = new System.Drawing.Point(93, 122);
            this.tb_Constrast.Name = "tb_Constrast";
            this.tb_Constrast.Size = new System.Drawing.Size(100, 21);
            this.tb_Constrast.TabIndex = 1;
            // 
            // tb_MinScale
            // 
            this.tb_MinScale.Location = new System.Drawing.Point(93, 89);
            this.tb_MinScale.Name = "tb_MinScale";
            this.tb_MinScale.Size = new System.Drawing.Size(100, 21);
            this.tb_MinScale.TabIndex = 1;
            // 
            // tb_MaxScale
            // 
            this.tb_MaxScale.Location = new System.Drawing.Point(93, 54);
            this.tb_MaxScale.Name = "tb_MaxScale";
            this.tb_MaxScale.Size = new System.Drawing.Size(100, 21);
            this.tb_MaxScale.TabIndex = 1;
            // 
            // tb_CircleR
            // 
            this.tb_CircleR.Location = new System.Drawing.Point(93, 24);
            this.tb_CircleR.Name = "tb_CircleR";
            this.tb_CircleR.Size = new System.Drawing.Size(100, 21);
            this.tb_CircleR.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(194, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "(推荐值5)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "对比度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "(推荐值0.5)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "最小比值";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "(推荐值1.5)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "最大比值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "(推荐值200)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标准圆半径";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ck_ChekFirstOffset);
            this.groupBox3.Controls.Add(this.tb_OffsetY);
            this.groupBox3.Controls.Add(this.tb_OffsetX);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Location = new System.Drawing.Point(321, 238);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 98);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其他设置";
            // 
            // ck_ChekFirstOffset
            // 
            this.ck_ChekFirstOffset.AutoSize = true;
            this.ck_ChekFirstOffset.Location = new System.Drawing.Point(8, 21);
            this.ck_ChekFirstOffset.Name = "ck_ChekFirstOffset";
            this.ck_ChekFirstOffset.Size = new System.Drawing.Size(156, 16);
            this.ck_ChekFirstOffset.TabIndex = 0;
            this.ck_ChekFirstOffset.Text = "使能重复加工起始点偏移";
            this.ck_ChekFirstOffset.UseVisualStyleBackColor = true;
            this.ck_ChekFirstOffset.Click += new System.EventHandler(this.ck_ChekFirstOffset_Click);
            // 
            // tb_OffsetY
            // 
            this.tb_OffsetY.Location = new System.Drawing.Point(164, 54);
            this.tb_OffsetY.Name = "tb_OffsetY";
            this.tb_OffsetY.Size = new System.Drawing.Size(65, 21);
            this.tb_OffsetY.TabIndex = 1;
            // 
            // tb_OffsetX
            // 
            this.tb_OffsetX.Location = new System.Drawing.Point(93, 54);
            this.tb_OffsetX.Name = "tb_OffsetX";
            this.tb_OffsetX.Size = new System.Drawing.Size(65, 21);
            this.tb_OffsetX.TabIndex = 1;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(235, 57);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(17, 12);
            this.label22.TabIndex = 0;
            this.label22.Text = "mm";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(25, 57);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 0;
            this.label21.Text = "偏移距离";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tb_MatchSpeed);
            this.groupBox4.Controls.Add(this.tb_MatchTimes);
            this.groupBox4.Controls.Add(this.tb_MatchScore);
            this.groupBox4.Controls.Add(this.tb_MatchNum);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(321, 73);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(308, 159);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "自动定位参数";
            // 
            // tb_MatchSpeed
            // 
            this.tb_MatchSpeed.Location = new System.Drawing.Point(93, 122);
            this.tb_MatchSpeed.Name = "tb_MatchSpeed";
            this.tb_MatchSpeed.Size = new System.Drawing.Size(100, 21);
            this.tb_MatchSpeed.TabIndex = 10;
            // 
            // tb_MatchTimes
            // 
            this.tb_MatchTimes.Location = new System.Drawing.Point(93, 89);
            this.tb_MatchTimes.Name = "tb_MatchTimes";
            this.tb_MatchTimes.Size = new System.Drawing.Size(100, 21);
            this.tb_MatchTimes.TabIndex = 11;
            // 
            // tb_MatchScore
            // 
            this.tb_MatchScore.Location = new System.Drawing.Point(93, 54);
            this.tb_MatchScore.Name = "tb_MatchScore";
            this.tb_MatchScore.Size = new System.Drawing.Size(100, 21);
            this.tb_MatchScore.TabIndex = 12;
            // 
            // tb_MatchNum
            // 
            this.tb_MatchNum.Location = new System.Drawing.Point(93, 24);
            this.tb_MatchNum.Name = "tb_MatchNum";
            this.tb_MatchNum.Size = new System.Drawing.Size(100, 21);
            this.tb_MatchNum.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(194, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "(推荐值0.9)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "匹配速度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(194, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "(推荐2-3次)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "计算次数";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(194, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 12);
            this.label13.TabIndex = 6;
            this.label13.Text = "(推荐值0.8)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 7;
            this.label14.Text = "匹配度";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(194, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 8;
            this.label15.Text = "(推荐值1)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 9;
            this.label16.Text = "匹配个数";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tb_AreaMax);
            this.groupBox5.Controls.Add(this.tb_AreaMin);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Location = new System.Drawing.Point(12, 238);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(303, 98);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "自定义模板参数";
            // 
            // tb_AreaMax
            // 
            this.tb_AreaMax.Location = new System.Drawing.Point(93, 57);
            this.tb_AreaMax.Name = "tb_AreaMax";
            this.tb_AreaMax.Size = new System.Drawing.Size(100, 21);
            this.tb_AreaMax.TabIndex = 1;
            // 
            // tb_AreaMin
            // 
            this.tb_AreaMin.Location = new System.Drawing.Point(93, 27);
            this.tb_AreaMin.Name = "tb_AreaMin";
            this.tb_AreaMin.Size = new System.Drawing.Size(100, 21);
            this.tb_AreaMin.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "AreaMax";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "AreaMin";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(194, 60);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 12);
            this.label20.TabIndex = 0;
            this.label20.Text = "(推荐值0.8)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(194, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "(推荐值2)";
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(144, 355);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "确认";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(373, 355);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // FrmAutoLocationParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 389);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAutoLocationParam";
            this.Text = "FrmAutoLocationParam";
            this.Load += new System.EventHandler(this.FrmAutoLocationParam_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton r_Standard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton r_Userdefine;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tb_Constrast;
        private System.Windows.Forms.TextBox tb_MinScale;
        private System.Windows.Forms.TextBox tb_MaxScale;
        private System.Windows.Forms.TextBox tb_CircleR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_MatchSpeed;
        private System.Windows.Forms.TextBox tb_MatchTimes;
        private System.Windows.Forms.TextBox tb_MatchScore;
        private System.Windows.Forms.TextBox tb_MatchNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tb_AreaMax;
        private System.Windows.Forms.TextBox tb_AreaMin;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox ck_ChekFirstOffset;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tb_OffsetY;
        private System.Windows.Forms.TextBox tb_OffsetX;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
    }
}