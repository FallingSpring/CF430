namespace CameraView
{
    partial class FrmMarkAndLocation
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
            this.m_originList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_RealList = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Offset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_OffsetY = new System.Windows.Forms.TextBox();
            this.tb_OffsetX = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_UpdatePos = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_PosY = new System.Windows.Forms.TextBox();
            this.tb_Index = new System.Windows.Forms.TextBox();
            this.tb_PosX = new System.Windows.Forms.TextBox();
            this.btn_UpdateRelation = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_originList);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 248);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "加工文件上的注册点";
            // 
            // m_originList
            // 
            this.m_originList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_originList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_originList.GridLines = true;
            this.m_originList.Location = new System.Drawing.Point(3, 17);
            this.m_originList.Name = "m_originList";
            this.m_originList.Size = new System.Drawing.Size(258, 228);
            this.m_originList.TabIndex = 0;
            this.m_originList.UseCompatibleStateImageBehavior = false;
            this.m_originList.View = System.Windows.Forms.View.Details;
            this.m_originList.SelectedIndexChanged += new System.EventHandler(this.ListViewSelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "顺序号";
            this.columnHeader1.Width = 76;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "X坐标";
            this.columnHeader2.Width = 93;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Y坐标";
            this.columnHeader3.Width = 84;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_RealList);
            this.groupBox2.Location = new System.Drawing.Point(283, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 248);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实际测量的标准点";
            // 
            // m_RealList
            // 
            this.m_RealList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.m_RealList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_RealList.GridLines = true;
            this.m_RealList.Location = new System.Drawing.Point(3, 17);
            this.m_RealList.Name = "m_RealList";
            this.m_RealList.Size = new System.Drawing.Size(258, 228);
            this.m_RealList.TabIndex = 0;
            this.m_RealList.UseCompatibleStateImageBehavior = false;
            this.m_RealList.View = System.Windows.Forms.View.Details;
            this.m_RealList.SelectedIndexChanged += new System.EventHandler(this.ListViewSelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "顺序号";
            this.columnHeader4.Width = 76;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "X坐标";
            this.columnHeader5.Width = 93;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Y坐标";
            this.columnHeader6.Width = 84;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_Offset);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tb_OffsetY);
            this.groupBox3.Controls.Add(this.tb_OffsetX);
            this.groupBox3.Location = new System.Drawing.Point(553, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 245);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "整体偏移";
            // 
            // btn_Offset
            // 
            this.btn_Offset.Location = new System.Drawing.Point(40, 152);
            this.btn_Offset.Name = "btn_Offset";
            this.btn_Offset.Size = new System.Drawing.Size(114, 52);
            this.btn_Offset.TabIndex = 2;
            this.btn_Offset.Text = "整体偏移";
            this.btn_Offset.UseVisualStyleBackColor = true;
            this.btn_Offset.Click += new System.EventHandler(this.btn_Offset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y方向";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "X方向";
            // 
            // tb_OffsetY
            // 
            this.tb_OffsetY.Location = new System.Drawing.Point(68, 95);
            this.tb_OffsetY.Name = "tb_OffsetY";
            this.tb_OffsetY.Size = new System.Drawing.Size(100, 21);
            this.tb_OffsetY.TabIndex = 0;
            // 
            // tb_OffsetX
            // 
            this.tb_OffsetX.Location = new System.Drawing.Point(68, 57);
            this.tb_OffsetX.Name = "tb_OffsetX";
            this.tb_OffsetX.Size = new System.Drawing.Size(100, 21);
            this.tb_OffsetX.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_UpdatePos);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.tb_PosY);
            this.groupBox4.Controls.Add(this.tb_Index);
            this.groupBox4.Controls.Add(this.tb_PosX);
            this.groupBox4.Location = new System.Drawing.Point(13, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(534, 100);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "修改坐标数据";
            // 
            // btn_UpdatePos
            // 
            this.btn_UpdatePos.Location = new System.Drawing.Point(391, 31);
            this.btn_UpdatePos.Name = "btn_UpdatePos";
            this.btn_UpdatePos.Size = new System.Drawing.Size(114, 52);
            this.btn_UpdatePos.TabIndex = 2;
            this.btn_UpdatePos.Text = "修改";
            this.btn_UpdatePos.UseVisualStyleBackColor = true;
            this.btn_UpdatePos.Click += new System.EventHandler(this.btn_UpdatePos_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "序号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "X方向";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(314, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "mm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(314, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "X方向";
            // 
            // tb_PosY
            // 
            this.tb_PosY.Location = new System.Drawing.Point(200, 69);
            this.tb_PosY.Name = "tb_PosY";
            this.tb_PosY.Size = new System.Drawing.Size(100, 21);
            this.tb_PosY.TabIndex = 0;
            // 
            // tb_Index
            // 
            this.tb_Index.Location = new System.Drawing.Point(53, 48);
            this.tb_Index.Name = "tb_Index";
            this.tb_Index.Size = new System.Drawing.Size(71, 21);
            this.tb_Index.TabIndex = 0;
            // 
            // tb_PosX
            // 
            this.tb_PosX.Location = new System.Drawing.Point(200, 25);
            this.tb_PosX.Name = "tb_PosX";
            this.tb_PosX.Size = new System.Drawing.Size(100, 21);
            this.tb_PosX.TabIndex = 0;
            // 
            // btn_UpdateRelation
            // 
            this.btn_UpdateRelation.Location = new System.Drawing.Point(561, 309);
            this.btn_UpdateRelation.Name = "btn_UpdateRelation";
            this.btn_UpdateRelation.Size = new System.Drawing.Size(180, 32);
            this.btn_UpdateRelation.TabIndex = 2;
            this.btn_UpdateRelation.Text = "再次建立定位关系";
            this.btn_UpdateRelation.UseVisualStyleBackColor = true;
            this.btn_UpdateRelation.Click += new System.EventHandler(this.btn_UpdateRelation_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(150, 408);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(114, 52);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "确认";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(480, 408);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(114, 52);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // FrmMarkAndLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 487);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_UpdateRelation);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMarkAndLocation";
            this.Text = "标志点与实际定位点";
            this.Load += new System.EventHandler(this.FrmMarkAndLocation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView m_originList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView m_RealList;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Offset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_OffsetY;
        private System.Windows.Forms.TextBox tb_OffsetX;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_UpdatePos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_PosY;
        private System.Windows.Forms.TextBox tb_Index;
        private System.Windows.Forms.TextBox tb_PosX;
        private System.Windows.Forms.Button btn_UpdateRelation;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}