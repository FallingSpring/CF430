namespace TopwinLaser2016
{
    partial class UserControlGalvo
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.userControlXYMoverGalvo = new TopwinLaser2016.UserControlXYMover();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.buttonReadGalvoMotionDelay = new System.Windows.Forms.Button();
            this.buttonSetGalvoMotionDelay = new System.Windows.Forms.Button();
            this.numericUpDownGalvoMotionDelay = new System.Windows.Forms.NumericUpDown();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.buttonReadGalvoFocalLength = new System.Windows.Forms.Button();
            this.buttonSetGalvoFocalLength = new System.Windows.Forms.Button();
            this.numericUpDownGalvoFocalLength = new System.Windows.Forms.NumericUpDown();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.radioButtonGalvoFlippedYFalse = new System.Windows.Forms.RadioButton();
            this.radioButtonGalvoFlippedYTrue = new System.Windows.Forms.RadioButton();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.radioButtonGalvoFlippedXFalse = new System.Windows.Forms.RadioButton();
            this.radioButtonGalvoFlippedXTrue = new System.Windows.Forms.RadioButton();
            this.buttonReadGalvoFlipped = new System.Windows.Forms.Button();
            this.buttonSetGalvoFlipped = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGalvoMotionDelay)).BeginInit();
            this.groupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGalvoFocalLength)).BeginInit();
            this.groupBox17.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.userControlXYMoverGalvo);
            this.groupBox2.Location = new System.Drawing.Point(185, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 275);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Move";
            // 
            // userControlXYMoverGalvo
            // 
            this.userControlXYMoverGalvo.CurrentX = 0D;
            this.userControlXYMoverGalvo.CurrentY = 0D;
            this.userControlXYMoverGalvo.Location = new System.Drawing.Point(6, 18);
            this.userControlXYMoverGalvo.Name = "userControlXYMoverGalvo";
            this.userControlXYMoverGalvo.Size = new System.Drawing.Size(286, 203);
            this.userControlXYMoverGalvo.TabIndex = 24;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.buttonReadGalvoMotionDelay);
            this.groupBox21.Controls.Add(this.buttonSetGalvoMotionDelay);
            this.groupBox21.Controls.Add(this.numericUpDownGalvoMotionDelay);
            this.groupBox21.Location = new System.Drawing.Point(4, 71);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(175, 66);
            this.groupBox21.TabIndex = 28;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "运动延时 (µs)";
            // 
            // buttonReadGalvoMotionDelay
            // 
            this.buttonReadGalvoMotionDelay.Location = new System.Drawing.Point(9, 38);
            this.buttonReadGalvoMotionDelay.Name = "buttonReadGalvoMotionDelay";
            this.buttonReadGalvoMotionDelay.Size = new System.Drawing.Size(75, 21);
            this.buttonReadGalvoMotionDelay.TabIndex = 14;
            this.buttonReadGalvoMotionDelay.Text = "Read";
            this.buttonReadGalvoMotionDelay.UseVisualStyleBackColor = true;
            this.buttonReadGalvoMotionDelay.Click += new System.EventHandler(this.buttonReadGalvoMotionDelay_Click);
            // 
            // buttonSetGalvoMotionDelay
            // 
            this.buttonSetGalvoMotionDelay.Location = new System.Drawing.Point(90, 38);
            this.buttonSetGalvoMotionDelay.Name = "buttonSetGalvoMotionDelay";
            this.buttonSetGalvoMotionDelay.Size = new System.Drawing.Size(75, 21);
            this.buttonSetGalvoMotionDelay.TabIndex = 12;
            this.buttonSetGalvoMotionDelay.Text = "Set";
            this.buttonSetGalvoMotionDelay.UseVisualStyleBackColor = true;
            this.buttonSetGalvoMotionDelay.Click += new System.EventHandler(this.buttonSetGalvoMotionDelay_Click);
            // 
            // numericUpDownGalvoMotionDelay
            // 
            this.numericUpDownGalvoMotionDelay.Location = new System.Drawing.Point(9, 15);
            this.numericUpDownGalvoMotionDelay.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownGalvoMotionDelay.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownGalvoMotionDelay.Name = "numericUpDownGalvoMotionDelay";
            this.numericUpDownGalvoMotionDelay.Size = new System.Drawing.Size(156, 21);
            this.numericUpDownGalvoMotionDelay.TabIndex = 8;
            this.numericUpDownGalvoMotionDelay.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.buttonReadGalvoFocalLength);
            this.groupBox20.Controls.Add(this.buttonSetGalvoFocalLength);
            this.groupBox20.Controls.Add(this.numericUpDownGalvoFocalLength);
            this.groupBox20.Location = new System.Drawing.Point(4, 3);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(175, 66);
            this.groupBox20.TabIndex = 27;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "焦距 (mm)";
            // 
            // buttonReadGalvoFocalLength
            // 
            this.buttonReadGalvoFocalLength.Location = new System.Drawing.Point(9, 38);
            this.buttonReadGalvoFocalLength.Name = "buttonReadGalvoFocalLength";
            this.buttonReadGalvoFocalLength.Size = new System.Drawing.Size(75, 21);
            this.buttonReadGalvoFocalLength.TabIndex = 14;
            this.buttonReadGalvoFocalLength.Text = "Read";
            this.buttonReadGalvoFocalLength.UseVisualStyleBackColor = true;
            this.buttonReadGalvoFocalLength.Click += new System.EventHandler(this.buttonReadGalvoFocalLength_Click);
            // 
            // buttonSetGalvoFocalLength
            // 
            this.buttonSetGalvoFocalLength.Location = new System.Drawing.Point(90, 38);
            this.buttonSetGalvoFocalLength.Name = "buttonSetGalvoFocalLength";
            this.buttonSetGalvoFocalLength.Size = new System.Drawing.Size(75, 21);
            this.buttonSetGalvoFocalLength.TabIndex = 12;
            this.buttonSetGalvoFocalLength.Text = "Set";
            this.buttonSetGalvoFocalLength.UseVisualStyleBackColor = true;
            this.buttonSetGalvoFocalLength.Click += new System.EventHandler(this.buttonSetGalvoFocalLength_Click);
            // 
            // numericUpDownGalvoFocalLength
            // 
            this.numericUpDownGalvoFocalLength.Location = new System.Drawing.Point(9, 15);
            this.numericUpDownGalvoFocalLength.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownGalvoFocalLength.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownGalvoFocalLength.Name = "numericUpDownGalvoFocalLength";
            this.numericUpDownGalvoFocalLength.Size = new System.Drawing.Size(156, 21);
            this.numericUpDownGalvoFocalLength.TabIndex = 8;
            this.numericUpDownGalvoFocalLength.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.groupBox19);
            this.groupBox17.Controls.Add(this.groupBox18);
            this.groupBox17.Controls.Add(this.buttonReadGalvoFlipped);
            this.groupBox17.Controls.Add(this.buttonSetGalvoFlipped);
            this.groupBox17.Location = new System.Drawing.Point(4, 143);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(175, 135);
            this.groupBox17.TabIndex = 26;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "翻转";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.radioButtonGalvoFlippedYFalse);
            this.groupBox19.Controls.Add(this.radioButtonGalvoFlippedYTrue);
            this.groupBox19.Location = new System.Drawing.Point(8, 56);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(157, 37);
            this.groupBox19.TabIndex = 19;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Y 翻转";
            // 
            // radioButtonGalvoFlippedYFalse
            // 
            this.radioButtonGalvoFlippedYFalse.AutoSize = true;
            this.radioButtonGalvoFlippedYFalse.Location = new System.Drawing.Point(76, 13);
            this.radioButtonGalvoFlippedYFalse.Name = "radioButtonGalvoFlippedYFalse";
            this.radioButtonGalvoFlippedYFalse.Size = new System.Drawing.Size(53, 16);
            this.radioButtonGalvoFlippedYFalse.TabIndex = 15;
            this.radioButtonGalvoFlippedYFalse.Text = "False";
            this.radioButtonGalvoFlippedYFalse.UseVisualStyleBackColor = true;
            // 
            // radioButtonGalvoFlippedYTrue
            // 
            this.radioButtonGalvoFlippedYTrue.AutoSize = true;
            this.radioButtonGalvoFlippedYTrue.Checked = true;
            this.radioButtonGalvoFlippedYTrue.Location = new System.Drawing.Point(12, 13);
            this.radioButtonGalvoFlippedYTrue.Name = "radioButtonGalvoFlippedYTrue";
            this.radioButtonGalvoFlippedYTrue.Size = new System.Drawing.Size(47, 16);
            this.radioButtonGalvoFlippedYTrue.TabIndex = 14;
            this.radioButtonGalvoFlippedYTrue.TabStop = true;
            this.radioButtonGalvoFlippedYTrue.Text = "True";
            this.radioButtonGalvoFlippedYTrue.UseVisualStyleBackColor = true;
            this.radioButtonGalvoFlippedYTrue.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.radioButtonGalvoFlippedXFalse);
            this.groupBox18.Controls.Add(this.radioButtonGalvoFlippedXTrue);
            this.groupBox18.Location = new System.Drawing.Point(8, 14);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(157, 37);
            this.groupBox18.TabIndex = 18;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "X 翻转";
            // 
            // radioButtonGalvoFlippedXFalse
            // 
            this.radioButtonGalvoFlippedXFalse.AutoSize = true;
            this.radioButtonGalvoFlippedXFalse.Location = new System.Drawing.Point(76, 13);
            this.radioButtonGalvoFlippedXFalse.Name = "radioButtonGalvoFlippedXFalse";
            this.radioButtonGalvoFlippedXFalse.Size = new System.Drawing.Size(53, 16);
            this.radioButtonGalvoFlippedXFalse.TabIndex = 15;
            this.radioButtonGalvoFlippedXFalse.Text = "False";
            this.radioButtonGalvoFlippedXFalse.UseVisualStyleBackColor = true;
            // 
            // radioButtonGalvoFlippedXTrue
            // 
            this.radioButtonGalvoFlippedXTrue.AutoSize = true;
            this.radioButtonGalvoFlippedXTrue.Checked = true;
            this.radioButtonGalvoFlippedXTrue.Location = new System.Drawing.Point(12, 13);
            this.radioButtonGalvoFlippedXTrue.Name = "radioButtonGalvoFlippedXTrue";
            this.radioButtonGalvoFlippedXTrue.Size = new System.Drawing.Size(47, 16);
            this.radioButtonGalvoFlippedXTrue.TabIndex = 14;
            this.radioButtonGalvoFlippedXTrue.TabStop = true;
            this.radioButtonGalvoFlippedXTrue.Text = "True";
            this.radioButtonGalvoFlippedXTrue.UseVisualStyleBackColor = true;
            this.radioButtonGalvoFlippedXTrue.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // buttonReadGalvoFlipped
            // 
            this.buttonReadGalvoFlipped.Location = new System.Drawing.Point(8, 106);
            this.buttonReadGalvoFlipped.Name = "buttonReadGalvoFlipped";
            this.buttonReadGalvoFlipped.Size = new System.Drawing.Size(70, 21);
            this.buttonReadGalvoFlipped.TabIndex = 17;
            this.buttonReadGalvoFlipped.Text = "Read";
            this.buttonReadGalvoFlipped.UseVisualStyleBackColor = true;
            this.buttonReadGalvoFlipped.Click += new System.EventHandler(this.buttonReadGalvoFlipped_Click);
            // 
            // buttonSetGalvoFlipped
            // 
            this.buttonSetGalvoFlipped.Location = new System.Drawing.Point(90, 108);
            this.buttonSetGalvoFlipped.Name = "buttonSetGalvoFlipped";
            this.buttonSetGalvoFlipped.Size = new System.Drawing.Size(75, 21);
            this.buttonSetGalvoFlipped.TabIndex = 16;
            this.buttonSetGalvoFlipped.Text = "Set";
            this.buttonSetGalvoFlipped.UseVisualStyleBackColor = true;
            this.buttonSetGalvoFlipped.Click += new System.EventHandler(this.buttonSetGalvoFlipped_Click);
            // 
            // UserControlGalvo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox21);
            this.Controls.Add(this.groupBox20);
            this.Controls.Add(this.groupBox17);
            this.Name = "UserControlGalvo";
            this.Size = new System.Drawing.Size(496, 289);
            this.groupBox2.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGalvoMotionDelay)).EndInit();
            this.groupBox20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGalvoFocalLength)).EndInit();
            this.groupBox17.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private UserControlXYMover userControlXYMoverGalvo;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Button buttonReadGalvoMotionDelay;
        private System.Windows.Forms.Button buttonSetGalvoMotionDelay;
        private System.Windows.Forms.NumericUpDown numericUpDownGalvoMotionDelay;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Button buttonReadGalvoFocalLength;
        private System.Windows.Forms.Button buttonSetGalvoFocalLength;
        private System.Windows.Forms.NumericUpDown numericUpDownGalvoFocalLength;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.RadioButton radioButtonGalvoFlippedYFalse;
        private System.Windows.Forms.RadioButton radioButtonGalvoFlippedYTrue;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.RadioButton radioButtonGalvoFlippedXFalse;
        private System.Windows.Forms.RadioButton radioButtonGalvoFlippedXTrue;
        private System.Windows.Forms.Button buttonReadGalvoFlipped;
        private System.Windows.Forms.Button buttonSetGalvoFlipped;
    }
}
