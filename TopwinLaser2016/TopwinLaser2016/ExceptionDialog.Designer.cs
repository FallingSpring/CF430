namespace TopwinLaser2016
{
    partial class ExceptionDialog
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
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnNestedException = new System.Windows.Forms.Button();
            this.btnStackTrace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(334, 179);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Message:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(15, 26);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(394, 134);
            this.txtMessage.TabIndex = 2;
            // 
            // btnNestedException
            // 
            this.btnNestedException.Location = new System.Drawing.Point(136, 179);
            this.btnNestedException.Name = "btnNestedException";
            this.btnNestedException.Size = new System.Drawing.Size(139, 23);
            this.btnNestedException.TabIndex = 3;
            this.btnNestedException.Text = "View Nested Exception";
            this.btnNestedException.UseVisualStyleBackColor = true;
            this.btnNestedException.Click += new System.EventHandler(this.btnNestedException_Click);
            // 
            // btnStackTrace
            // 
            this.btnStackTrace.Location = new System.Drawing.Point(12, 179);
            this.btnStackTrace.Name = "btnStackTrace";
            this.btnStackTrace.Size = new System.Drawing.Size(118, 23);
            this.btnStackTrace.TabIndex = 4;
            this.btnStackTrace.Text = "View Stack Trace...";
            this.btnStackTrace.UseVisualStyleBackColor = true;
            this.btnStackTrace.Click += new System.EventHandler(this.btnStackTrace_Click);
            // 
            // ExceptionDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 214);
            this.Controls.Add(this.btnStackTrace);
            this.Controls.Add(this.btnNestedException);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Name = "ExceptionDialog";
            this.Text = "ExceptionDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnNestedException;
        private System.Windows.Forms.Button btnStackTrace;
    }
}