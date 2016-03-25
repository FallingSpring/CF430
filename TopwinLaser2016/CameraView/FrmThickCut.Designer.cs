namespace CameraView
{
    partial class FrmThickCut
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_GetResolution = new System.Windows.Forms.Button();
            this.tb_Camera_Resoluton = new System.Windows.Forms.TextBox();
            this.tb_Camera_D_mm = new System.Windows.Forms.TextBox();
            this.tb_Camera_D_pixel = new System.Windows.Forms.TextBox();
            this.tb_Camera_Y_pixel = new System.Windows.Forms.TextBox();
            this.tb_Camera_X_pixel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_TestCameraOffset = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_CameraOffset_Y = new System.Windows.Forms.TextBox();
            this.tb_CameraOffset_X = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_testCameraCenter = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tb_Ruluer_Unit = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_GetResolution);
            this.groupBox1.Controls.Add(this.tb_Camera_Resoluton);
            this.groupBox1.Controls.Add(this.tb_Camera_D_mm);
            this.groupBox1.Controls.Add(this.tb_Camera_D_pixel);
            this.groupBox1.Controls.Add(this.tb_Camera_Y_pixel);
            this.groupBox1.Controls.Add(this.tb_Camera_X_pixel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 234);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分辨率设置";
            // 
            // btn_GetResolution
            // 
            this.btn_GetResolution.Location = new System.Drawing.Point(13, 205);
            this.btn_GetResolution.Name = "btn_GetResolution";
            this.btn_GetResolution.Size = new System.Drawing.Size(182, 23);
            this.btn_GetResolution.TabIndex = 2;
            this.btn_GetResolution.Text = "计算分辨率";
            this.btn_GetResolution.UseVisualStyleBackColor = true;
            this.btn_GetResolution.Click += new System.EventHandler(this.btn_GetResolution_Click);
            // 
            // tb_Camera_Resoluton
            // 
            this.tb_Camera_Resoluton.Location = new System.Drawing.Point(89, 168);
            this.tb_Camera_Resoluton.Name = "tb_Camera_Resoluton";
            this.tb_Camera_Resoluton.Size = new System.Drawing.Size(71, 21);
            this.tb_Camera_Resoluton.TabIndex = 1;
            // 
            // tb_Camera_D_mm
            // 
            this.tb_Camera_D_mm.Location = new System.Drawing.Point(89, 133);
            this.tb_Camera_D_mm.Name = "tb_Camera_D_mm";
            this.tb_Camera_D_mm.Size = new System.Drawing.Size(71, 21);
            this.tb_Camera_D_mm.TabIndex = 1;
            // 
            // tb_Camera_D_pixel
            // 
            this.tb_Camera_D_pixel.Location = new System.Drawing.Point(89, 98);
            this.tb_Camera_D_pixel.Name = "tb_Camera_D_pixel";
            this.tb_Camera_D_pixel.Size = new System.Drawing.Size(71, 21);
            this.tb_Camera_D_pixel.TabIndex = 1;
            // 
            // tb_Camera_Y_pixel
            // 
            this.tb_Camera_Y_pixel.Location = new System.Drawing.Point(89, 63);
            this.tb_Camera_Y_pixel.Name = "tb_Camera_Y_pixel";
            this.tb_Camera_Y_pixel.Size = new System.Drawing.Size(71, 21);
            this.tb_Camera_Y_pixel.TabIndex = 1;
            // 
            // tb_Camera_X_pixel
            // 
            this.tb_Camera_X_pixel.Location = new System.Drawing.Point(89, 28);
            this.tb_Camera_X_pixel.Name = "tb_Camera_X_pixel";
            this.tb_Camera_X_pixel.Size = new System.Drawing.Size(71, 21);
            this.tb_Camera_X_pixel.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "分辨率";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "圆实际直径";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "圆直径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "圆心Y坐标";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(166, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "μm/pixel";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(166, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "mm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(166, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "像素";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(166, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "像素";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(166, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "像素";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "圆心X坐标";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_TestCameraOffset);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tb_CameraOffset_Y);
            this.groupBox2.Controls.Add(this.tb_CameraOffset_X);
            this.groupBox2.Location = new System.Drawing.Point(230, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 154);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "相机与振镜中心距离";
            // 
            // btn_TestCameraOffset
            // 
            this.btn_TestCameraOffset.Location = new System.Drawing.Point(17, 90);
            this.btn_TestCameraOffset.Name = "btn_TestCameraOffset";
            this.btn_TestCameraOffset.Size = new System.Drawing.Size(167, 58);
            this.btn_TestCameraOffset.TabIndex = 2;
            this.btn_TestCameraOffset.Text = "测试相机中心距离";
            this.btn_TestCameraOffset.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "Y方向偏置";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "X方向偏置";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(167, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "mm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(167, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "mm";
            // 
            // tb_CameraOffset_Y
            // 
            this.tb_CameraOffset_Y.Location = new System.Drawing.Point(90, 63);
            this.tb_CameraOffset_Y.Name = "tb_CameraOffset_Y";
            this.tb_CameraOffset_Y.Size = new System.Drawing.Size(71, 21);
            this.tb_CameraOffset_Y.TabIndex = 1;
            // 
            // tb_CameraOffset_X
            // 
            this.tb_CameraOffset_X.Location = new System.Drawing.Point(90, 28);
            this.tb_CameraOffset_X.Name = "tb_CameraOffset_X";
            this.tb_CameraOffset_X.Size = new System.Drawing.Size(71, 21);
            this.tb_CameraOffset_X.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_testCameraCenter);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Location = new System.Drawing.Point(230, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 189);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "相机与振镜中心距离";
            // 
            // btn_testCameraCenter
            // 
            this.btn_testCameraCenter.Location = new System.Drawing.Point(17, 113);
            this.btn_testCameraCenter.Name = "btn_testCameraCenter";
            this.btn_testCameraCenter.Size = new System.Drawing.Size(167, 58);
            this.btn_testCameraCenter.TabIndex = 2;
            this.btn_testCameraCenter.Text = "测试相机中心距离";
            this.btn_testCameraCenter.UseVisualStyleBackColor = true;
            this.btn_testCameraCenter.Click += new System.EventHandler(this.btn_testCameraCenter_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "Y方向偏置";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "X方向偏置";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(167, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "mm";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(167, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "mm";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 21);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(90, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(71, 21);
            this.textBox2.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.tb_Ruluer_Unit);
            this.groupBox4.Location = new System.Drawing.Point(1, 252);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(223, 59);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "图像刻度尺寸";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(15, 31);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(101, 12);
            this.label20.TabIndex = 0;
            this.label20.Text = "刻度尺寸最小单位";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(200, 31);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(23, 12);
            this.label22.TabIndex = 0;
            this.label22.Text = "μm";
            // 
            // tb_Ruluer_Unit
            // 
            this.tb_Ruluer_Unit.Location = new System.Drawing.Point(124, 28);
            this.tb_Ruluer_Unit.Name = "tb_Ruluer_Unit";
            this.tb_Ruluer_Unit.Size = new System.Drawing.Size(71, 21);
            this.tb_Ruluer_Unit.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Location = new System.Drawing.Point(230, 204);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 107);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "相机内参数";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 66);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "V参数";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(15, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 12);
            this.label21.TabIndex = 0;
            this.label21.Text = "U参数";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(167, 66);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 0;
            this.label23.Text = "mm";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(167, 31);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 12);
            this.label24.TabIndex = 0;
            this.label24.Text = "mm";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(90, 63);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(71, 21);
            this.textBox3.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(90, 28);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(71, 21);
            this.textBox4.TabIndex = 1;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(90, 336);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(263, 336);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // FrmThickCut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 368);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmThickCut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置分辨率和相机偏置";
            this.Load += new System.EventHandler(this.FrmThickCut_Load);
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

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Camera_Resoluton;
        private System.Windows.Forms.TextBox tb_Camera_D_mm;
        private System.Windows.Forms.TextBox tb_Camera_D_pixel;
        private System.Windows.Forms.TextBox tb_Camera_Y_pixel;
        private System.Windows.Forms.TextBox tb_Camera_X_pixel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_GetResolution;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_TestCameraOffset;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_CameraOffset_Y;
        private System.Windows.Forms.TextBox tb_CameraOffset_X;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_testCameraCenter;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tb_Ruluer_Unit;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
    }
}