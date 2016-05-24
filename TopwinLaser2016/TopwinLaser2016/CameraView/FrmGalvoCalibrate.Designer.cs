namespace CameraView
{
    partial class FrmGalvoCalibrate
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
            this.btn_MarkGrid = new System.Windows.Forms.Button();
            this.btn_AutoCalibrate = new System.Windows.Forms.Button();
            this.btn_MarkRect = new System.Windows.Forms.Button();
            this.cb_GridType = new System.Windows.Forms.ComboBox();
            this.tb_GalvoSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_MarkGrid
            // 
            this.btn_MarkGrid.Location = new System.Drawing.Point(29, 127);
            this.btn_MarkGrid.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_MarkGrid.Name = "btn_MarkGrid";
            this.btn_MarkGrid.Size = new System.Drawing.Size(272, 76);
            this.btn_MarkGrid.TabIndex = 0;
            this.btn_MarkGrid.Text = "标记网格点";
            this.btn_MarkGrid.UseVisualStyleBackColor = true;
            this.btn_MarkGrid.Click += new System.EventHandler(this.btn_MarkGrid_Click);
            // 
            // btn_AutoCalibrate
            // 
            this.btn_AutoCalibrate.Location = new System.Drawing.Point(29, 225);
            this.btn_AutoCalibrate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_AutoCalibrate.Name = "btn_AutoCalibrate";
            this.btn_AutoCalibrate.Size = new System.Drawing.Size(272, 76);
            this.btn_AutoCalibrate.TabIndex = 0;
            this.btn_AutoCalibrate.Text = "自动补偿";
            this.btn_AutoCalibrate.UseVisualStyleBackColor = true;
            this.btn_AutoCalibrate.Click += new System.EventHandler(this.btn_AutoCalibrate_Click);
            // 
            // btn_MarkRect
            // 
            this.btn_MarkRect.Location = new System.Drawing.Point(29, 323);
            this.btn_MarkRect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_MarkRect.Name = "btn_MarkRect";
            this.btn_MarkRect.Size = new System.Drawing.Size(272, 76);
            this.btn_MarkRect.TabIndex = 0;
            this.btn_MarkRect.Text = "画标准矩形";
            this.btn_MarkRect.UseVisualStyleBackColor = true;
            this.btn_MarkRect.Click += new System.EventHandler(this.btn_MarkRect_Click);
            // 
            // cb_GridType
            // 
            this.cb_GridType.FormattingEnabled = true;
            this.cb_GridType.Items.AddRange(new object[] {
            "8*8",
            "16*16",
            "24*24",
            "32*32",
            "64*64"});
            this.cb_GridType.Location = new System.Drawing.Point(188, 16);
            this.cb_GridType.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cb_GridType.Name = "cb_GridType";
            this.cb_GridType.Size = new System.Drawing.Size(113, 32);
            this.cb_GridType.TabIndex = 1;
            // 
            // tb_GalvoSize
            // 
            this.tb_GalvoSize.Location = new System.Drawing.Point(188, 70);
            this.tb_GalvoSize.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tb_GalvoSize.Name = "tb_GalvoSize";
            this.tb_GalvoSize.Size = new System.Drawing.Size(80, 35);
            this.tb_GalvoSize.TabIndex = 2;
            this.tb_GalvoSize.Text = "80";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "校正网格类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "振镜幅面大小";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "mm";
            // 
            // FrmGalvoCalibrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 417);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_GalvoSize);
            this.Controls.Add(this.cb_GridType);
            this.Controls.Add(this.btn_MarkRect);
            this.Controls.Add(this.btn_AutoCalibrate);
            this.Controls.Add(this.btn_MarkGrid);
            this.Font = new System.Drawing.Font("宋体", 18F);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FrmGalvoCalibrate";
            this.Text = "振镜校正";
            this.Load += new System.EventHandler(this.FrmGalvoCalibrate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_MarkGrid;
        private System.Windows.Forms.Button btn_AutoCalibrate;
        private System.Windows.Forms.Button btn_MarkRect;
        private System.Windows.Forms.ComboBox cb_GridType;
        private System.Windows.Forms.TextBox tb_GalvoSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}