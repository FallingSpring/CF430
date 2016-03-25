namespace CameraView
{
    partial class FrmView
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.相机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动对焦ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mark点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.手动定位开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算当前Mark点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下一Mark点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.建立定位关系ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.相机ToolStripMenuItem,
            this.mark点ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 48);
            // 
            // 相机ToolStripMenuItem
            // 
            this.相机ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.自动对焦ToolStripMenuItem,
            this.关闭ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.相机ToolStripMenuItem.Name = "相机ToolStripMenuItem";
            this.相机ToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.相机ToolStripMenuItem.Text = "相机";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.相机ToolStripMenuItem_Click);
            // 
            // 自动对焦ToolStripMenuItem
            // 
            this.自动对焦ToolStripMenuItem.Name = "自动对焦ToolStripMenuItem";
            this.自动对焦ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.自动对焦ToolStripMenuItem.Text = "自动对焦";
            this.自动对焦ToolStripMenuItem.Click += new System.EventHandler(this.相机ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.相机ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.相机ToolStripMenuItem_Click);
            // 
            // mark点ToolStripMenuItem
            // 
            this.mark点ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.手动定位开始ToolStripMenuItem,
            this.计算当前Mark点ToolStripMenuItem,
            this.下一Mark点ToolStripMenuItem,
            this.建立定位关系ToolStripMenuItem});
            this.mark点ToolStripMenuItem.Name = "mark点ToolStripMenuItem";
            this.mark点ToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.mark点ToolStripMenuItem.Text = "Mark点";
            // 
            // 手动定位开始ToolStripMenuItem
            // 
            this.手动定位开始ToolStripMenuItem.Name = "手动定位开始ToolStripMenuItem";
            this.手动定位开始ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.手动定位开始ToolStripMenuItem.Text = "手动定位开始";
            this.手动定位开始ToolStripMenuItem.Click += new System.EventHandler(this.mark点ToolStripMenuItem_Click);
            // 
            // 计算当前Mark点ToolStripMenuItem
            // 
            this.计算当前Mark点ToolStripMenuItem.Name = "计算当前Mark点ToolStripMenuItem";
            this.计算当前Mark点ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.计算当前Mark点ToolStripMenuItem.Text = "计算当前Mark点";
            this.计算当前Mark点ToolStripMenuItem.Click += new System.EventHandler(this.mark点ToolStripMenuItem_Click);
            // 
            // 下一Mark点ToolStripMenuItem
            // 
            this.下一Mark点ToolStripMenuItem.Name = "下一Mark点ToolStripMenuItem";
            this.下一Mark点ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.下一Mark点ToolStripMenuItem.Text = "下一Mark点";
            this.下一Mark点ToolStripMenuItem.Click += new System.EventHandler(this.mark点ToolStripMenuItem_Click);
            // 
            // 建立定位关系ToolStripMenuItem
            // 
            this.建立定位关系ToolStripMenuItem.Name = "建立定位关系ToolStripMenuItem";
            this.建立定位关系ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.建立定位关系ToolStripMenuItem.Text = "建立定位关系";
            this.建立定位关系ToolStripMenuItem.Click += new System.EventHandler(this.mark点ToolStripMenuItem_Click);
            // 
            // FrmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmView";
            this.Text = "FrmView";
            this.Click += new System.EventHandler(this.FrmView_Click);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 相机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mark点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动对焦ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 手动定位开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算当前Mark点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下一Mark点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 建立定位关系ToolStripMenuItem;
    }
}