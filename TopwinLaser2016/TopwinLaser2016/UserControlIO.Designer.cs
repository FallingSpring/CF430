namespace TopwinLaser2016
{
    partial class UserControlIO
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
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.buttonReadAllOutputs = new System.Windows.Forms.Button();
            this.dataGridViewIODigitalOutputs = new System.Windows.Forms.DataGridView();
            this.buttonSetIODigitalPutputs = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonReadAllInputs = new System.Windows.Forms.Button();
            this.dataGridViewDigitalInputs = new System.Windows.Forms.DataGridView();
            this.Output = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox38.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIODigitalOutputs)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDigitalInputs)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox38
            // 
            this.groupBox38.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox38.Controls.Add(this.buttonReadAllOutputs);
            this.groupBox38.Controls.Add(this.dataGridViewIODigitalOutputs);
            this.groupBox38.Controls.Add(this.buttonSetIODigitalPutputs);
            this.groupBox38.Location = new System.Drawing.Point(3, 6);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(260, 415);
            this.groupBox38.TabIndex = 17;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "输出";
            // 
            // buttonReadAllOutputs
            // 
            this.buttonReadAllOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReadAllOutputs.Location = new System.Drawing.Point(98, 389);
            this.buttonReadAllOutputs.Name = "buttonReadAllOutputs";
            this.buttonReadAllOutputs.Size = new System.Drawing.Size(75, 21);
            this.buttonReadAllOutputs.TabIndex = 18;
            this.buttonReadAllOutputs.Text = "Read";
            this.buttonReadAllOutputs.UseVisualStyleBackColor = true;
            this.buttonReadAllOutputs.Click += new System.EventHandler(this.buttonReadAllOutputs_Click);
            // 
            // dataGridViewIODigitalOutputs
            // 
            this.dataGridViewIODigitalOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewIODigitalOutputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIODigitalOutputs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Output,
            this.Value});
            this.dataGridViewIODigitalOutputs.Location = new System.Drawing.Point(6, 16);
            this.dataGridViewIODigitalOutputs.Name = "dataGridViewIODigitalOutputs";
            this.dataGridViewIODigitalOutputs.Size = new System.Drawing.Size(248, 367);
            this.dataGridViewIODigitalOutputs.TabIndex = 13;
            // 
            // buttonSetIODigitalPutputs
            // 
            this.buttonSetIODigitalPutputs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetIODigitalPutputs.Location = new System.Drawing.Point(179, 389);
            this.buttonSetIODigitalPutputs.Name = "buttonSetIODigitalPutputs";
            this.buttonSetIODigitalPutputs.Size = new System.Drawing.Size(75, 21);
            this.buttonSetIODigitalPutputs.TabIndex = 12;
            this.buttonSetIODigitalPutputs.Text = "Set";
            this.buttonSetIODigitalPutputs.UseVisualStyleBackColor = true;
            this.buttonSetIODigitalPutputs.Click += new System.EventHandler(this.buttonSetIODigitalPutputs_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.buttonReadAllInputs);
            this.groupBox1.Controls.Add(this.dataGridViewDigitalInputs);
            this.groupBox1.Location = new System.Drawing.Point(269, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 415);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入";
            // 
            // buttonReadAllInputs
            // 
            this.buttonReadAllInputs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReadAllInputs.Location = new System.Drawing.Point(179, 389);
            this.buttonReadAllInputs.Name = "buttonReadAllInputs";
            this.buttonReadAllInputs.Size = new System.Drawing.Size(75, 21);
            this.buttonReadAllInputs.TabIndex = 18;
            this.buttonReadAllInputs.Text = "Read";
            this.buttonReadAllInputs.UseVisualStyleBackColor = true;
            this.buttonReadAllInputs.Click += new System.EventHandler(this.buttonReadAllInputs_Click);
            // 
            // dataGridViewDigitalInputs
            // 
            this.dataGridViewDigitalInputs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDigitalInputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDigitalInputs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewCheckBoxColumn1});
            this.dataGridViewDigitalInputs.Location = new System.Drawing.Point(6, 16);
            this.dataGridViewDigitalInputs.Name = "dataGridViewDigitalInputs";
            this.dataGridViewDigitalInputs.Size = new System.Drawing.Size(248, 367);
            this.dataGridViewDigitalInputs.TabIndex = 13;
            // 
            // Output
            // 
            this.Output.HeaderText = "输出";
            this.Output.Name = "Output";
            // 
            // Value
            // 
            this.Value.FalseValue = "False";
            this.Value.HeaderText = "值";
            this.Value.Name = "Value";
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Value.TrueValue = "True";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "输入";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FalseValue = "False";
            this.dataGridViewCheckBoxColumn1.HeaderText = "值";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.TrueValue = "True";
            // 
            // UserControlIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox38);
            this.Name = "UserControlIO";
            this.Size = new System.Drawing.Size(539, 424);
            this.groupBox38.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIODigitalOutputs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDigitalInputs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox38;
        private System.Windows.Forms.DataGridView dataGridViewIODigitalOutputs;
        private System.Windows.Forms.Button buttonSetIODigitalPutputs;
        private System.Windows.Forms.Button buttonReadAllOutputs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonReadAllInputs;
        private System.Windows.Forms.DataGridView dataGridViewDigitalInputs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Output;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}
