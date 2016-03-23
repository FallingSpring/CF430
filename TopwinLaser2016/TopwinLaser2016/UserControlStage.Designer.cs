namespace TopwinLaser2016
{
    partial class UserControlStage
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
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.userControlXYMoverStage = new TopwinLaser2016.UserControlXYMover();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonStageMoveXYZ = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownStageMoveXYZ_Z = new System.Windows.Forms.NumericUpDown();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.buttonReadStageLimit = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.numericUpDownStageLimitUpper = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDownStageLimitLower = new System.Windows.Forms.NumericUpDown();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.buttonReadStageLimitPolarity = new System.Windows.Forms.Button();
            this.buttonSetStageLimitPolarity = new System.Windows.Forms.Button();
            this.radioButtonStageLimitPolarityFalse = new System.Windows.Forms.RadioButton();
            this.radioButtonStageLimitPolarityTrue = new System.Windows.Forms.RadioButton();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.buttonReadStageDirPolarity = new System.Windows.Forms.Button();
            this.buttonSetStageDirPolarity = new System.Windows.Forms.Button();
            this.radioButtonStageDirPolarityFalse = new System.Windows.Forms.RadioButton();
            this.radioButtonStageDirPolarityTrue = new System.Windows.Forms.RadioButton();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.buttonReadStageStepPolarity = new System.Windows.Forms.Button();
            this.buttonSetStageStepPolarity = new System.Windows.Forms.Button();
            this.radioButtonStageStepPolarityFalse = new System.Windows.Forms.RadioButton();
            this.radioButtonStageStepPolarityTrue = new System.Windows.Forms.RadioButton();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.buttonReadStagePulseShape = new System.Windows.Forms.Button();
            this.buttonSetStagePulseShape = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDownStagePulseShapeHoldTime = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDownStagePulseShapeSetupTime = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonReadStageDelay = new System.Windows.Forms.Button();
            this.buttonSetStageDelay = new System.Windows.Forms.Button();
            this.numericUpDownStageDelay = new System.Windows.Forms.NumericUpDown();
            this.button9 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.buttonReadStageEnabled = new System.Windows.Forms.Button();
            this.buttonSetStageEnabled = new System.Windows.Forms.Button();
            this.radioButtonStageDisabled = new System.Windows.Forms.RadioButton();
            this.radioButtonStageEnabled = new System.Windows.Forms.RadioButton();
            this.comboBoxStage = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.buttonReadStageRawPosition = new System.Windows.Forms.Button();
            this.buttonSetStageRawPosition = new System.Windows.Forms.Button();
            this.numericUpDownStageRawPosition = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonStageMove = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownStageMoveMaxVel = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownStageMovePosition = new System.Windows.Forms.NumericUpDown();
            this.groupBox15.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageMoveXYZ_Z)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageLimitUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageLimitLower)).BeginInit();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStagePulseShapeHoldTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStagePulseShapeSetupTime)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageDelay)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageRawPosition)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageMoveMaxVel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageMovePosition)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.userControlXYMoverStage);
            this.groupBox15.Controls.Add(this.groupBox5);
            this.groupBox15.Location = new System.Drawing.Point(375, 3);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(257, 371);
            this.groupBox15.TabIndex = 20;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "多平台操作";
            // 
            // userControlXYMoverStage
            // 
            this.userControlXYMoverStage.CurrentX = 0D;
            this.userControlXYMoverStage.CurrentY = 0D;
            this.userControlXYMoverStage.Location = new System.Drawing.Point(6, 18);
            this.userControlXYMoverStage.Name = "userControlXYMoverStage";
            this.userControlXYMoverStage.Size = new System.Drawing.Size(250, 203);
            this.userControlXYMoverStage.TabIndex = 14;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonStageMoveXYZ);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.numericUpDownStageMoveXYZ_Z);
            this.groupBox5.Location = new System.Drawing.Point(6, 314);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(233, 51);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Z轴";
            // 
            // buttonStageMoveXYZ
            // 
            this.buttonStageMoveXYZ.Location = new System.Drawing.Point(146, 19);
            this.buttonStageMoveXYZ.Name = "buttonStageMoveXYZ";
            this.buttonStageMoveXYZ.Size = new System.Drawing.Size(75, 21);
            this.buttonStageMoveXYZ.TabIndex = 12;
            this.buttonStageMoveXYZ.Text = "开始移动";
            this.buttonStageMoveXYZ.UseVisualStyleBackColor = true;
            this.buttonStageMoveXYZ.Click += new System.EventHandler(this.buttonStageMoveXYZ_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "Z";
            // 
            // numericUpDownStageMoveXYZ_Z
            // 
            this.numericUpDownStageMoveXYZ_Z.Location = new System.Drawing.Point(28, 19);
            this.numericUpDownStageMoveXYZ_Z.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownStageMoveXYZ_Z.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownStageMoveXYZ_Z.Name = "numericUpDownStageMoveXYZ_Z";
            this.numericUpDownStageMoveXYZ_Z.Size = new System.Drawing.Size(96, 21);
            this.numericUpDownStageMoveXYZ_Z.TabIndex = 10;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.groupBox14);
            this.groupBox9.Controls.Add(this.groupBox13);
            this.groupBox9.Controls.Add(this.groupBox12);
            this.groupBox9.Controls.Add(this.groupBox11);
            this.groupBox9.Controls.Add(this.groupBox10);
            this.groupBox9.Controls.Add(this.groupBox6);
            this.groupBox9.Controls.Add(this.button9);
            this.groupBox9.Controls.Add(this.label13);
            this.groupBox9.Controls.Add(this.groupBox8);
            this.groupBox9.Controls.Add(this.comboBoxStage);
            this.groupBox9.Controls.Add(this.groupBox7);
            this.groupBox9.Controls.Add(this.groupBox3);
            this.groupBox9.Location = new System.Drawing.Point(1, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(368, 371);
            this.groupBox9.TabIndex = 19;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "单平台操作";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.buttonReadStageLimit);
            this.groupBox14.Controls.Add(this.label19);
            this.groupBox14.Controls.Add(this.numericUpDownStageLimitUpper);
            this.groupBox14.Controls.Add(this.label20);
            this.groupBox14.Controls.Add(this.numericUpDownStageLimitLower);
            this.groupBox14.Location = new System.Drawing.Point(188, 101);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(174, 86);
            this.groupBox14.TabIndex = 22;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "限位";
            // 
            // buttonReadStageLimit
            // 
            this.buttonReadStageLimit.Location = new System.Drawing.Point(89, 57);
            this.buttonReadStageLimit.Name = "buttonReadStageLimit";
            this.buttonReadStageLimit.Size = new System.Drawing.Size(75, 21);
            this.buttonReadStageLimit.TabIndex = 12;
            this.buttonReadStageLimit.Text = "Read";
            this.buttonReadStageLimit.UseVisualStyleBackColor = true;
            this.buttonReadStageLimit.Click += new System.EventHandler(this.buttonReadStageLimit_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 12);
            this.label19.TabIndex = 11;
            this.label19.Text = "负";
            // 
            // numericUpDownStageLimitUpper
            // 
            this.numericUpDownStageLimitUpper.Location = new System.Drawing.Point(67, 36);
            this.numericUpDownStageLimitUpper.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownStageLimitUpper.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownStageLimitUpper.Name = "numericUpDownStageLimitUpper";
            this.numericUpDownStageLimitUpper.Size = new System.Drawing.Size(99, 21);
            this.numericUpDownStageLimitUpper.TabIndex = 10;
            this.numericUpDownStageLimitUpper.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 12);
            this.label20.TabIndex = 9;
            this.label20.Text = "正";
            // 
            // numericUpDownStageLimitLower
            // 
            this.numericUpDownStageLimitLower.Location = new System.Drawing.Point(67, 16);
            this.numericUpDownStageLimitLower.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownStageLimitLower.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownStageLimitLower.Name = "numericUpDownStageLimitLower";
            this.numericUpDownStageLimitLower.Size = new System.Drawing.Size(99, 21);
            this.numericUpDownStageLimitLower.TabIndex = 8;
            this.numericUpDownStageLimitLower.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.buttonReadStageLimitPolarity);
            this.groupBox13.Controls.Add(this.buttonSetStageLimitPolarity);
            this.groupBox13.Controls.Add(this.radioButtonStageLimitPolarityFalse);
            this.groupBox13.Controls.Add(this.radioButtonStageLimitPolarityTrue);
            this.groupBox13.Location = new System.Drawing.Point(188, 252);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(174, 57);
            this.groupBox13.TabIndex = 21;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "限位极性";
            // 
            // buttonReadStageLimitPolarity
            // 
            this.buttonReadStageLimitPolarity.Location = new System.Drawing.Point(9, 30);
            this.buttonReadStageLimitPolarity.Name = "buttonReadStageLimitPolarity";
            this.buttonReadStageLimitPolarity.Size = new System.Drawing.Size(75, 21);
            this.buttonReadStageLimitPolarity.TabIndex = 17;
            this.buttonReadStageLimitPolarity.Text = "Read";
            this.buttonReadStageLimitPolarity.UseVisualStyleBackColor = true;
            this.buttonReadStageLimitPolarity.Click += new System.EventHandler(this.buttonReadStageLimitPolarity_Click);
            // 
            // buttonSetStageLimitPolarity
            // 
            this.buttonSetStageLimitPolarity.Location = new System.Drawing.Point(89, 30);
            this.buttonSetStageLimitPolarity.Name = "buttonSetStageLimitPolarity";
            this.buttonSetStageLimitPolarity.Size = new System.Drawing.Size(75, 21);
            this.buttonSetStageLimitPolarity.TabIndex = 16;
            this.buttonSetStageLimitPolarity.Text = "Set";
            this.buttonSetStageLimitPolarity.UseVisualStyleBackColor = true;
            this.buttonSetStageLimitPolarity.Click += new System.EventHandler(this.buttonSetStageLimitPolarity_Click);
            // 
            // radioButtonStageLimitPolarityFalse
            // 
            this.radioButtonStageLimitPolarityFalse.AutoSize = true;
            this.radioButtonStageLimitPolarityFalse.Location = new System.Drawing.Point(77, 14);
            this.radioButtonStageLimitPolarityFalse.Name = "radioButtonStageLimitPolarityFalse";
            this.radioButtonStageLimitPolarityFalse.Size = new System.Drawing.Size(53, 16);
            this.radioButtonStageLimitPolarityFalse.TabIndex = 15;
            this.radioButtonStageLimitPolarityFalse.Text = "False";
            this.radioButtonStageLimitPolarityFalse.UseVisualStyleBackColor = true;
            // 
            // radioButtonStageLimitPolarityTrue
            // 
            this.radioButtonStageLimitPolarityTrue.AutoSize = true;
            this.radioButtonStageLimitPolarityTrue.Checked = true;
            this.radioButtonStageLimitPolarityTrue.Location = new System.Drawing.Point(13, 14);
            this.radioButtonStageLimitPolarityTrue.Name = "radioButtonStageLimitPolarityTrue";
            this.radioButtonStageLimitPolarityTrue.Size = new System.Drawing.Size(47, 16);
            this.radioButtonStageLimitPolarityTrue.TabIndex = 14;
            this.radioButtonStageLimitPolarityTrue.TabStop = true;
            this.radioButtonStageLimitPolarityTrue.Text = "True";
            this.radioButtonStageLimitPolarityTrue.UseVisualStyleBackColor = true;
            this.radioButtonStageLimitPolarityTrue.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.buttonReadStageDirPolarity);
            this.groupBox12.Controls.Add(this.buttonSetStageDirPolarity);
            this.groupBox12.Controls.Add(this.radioButtonStageDirPolarityFalse);
            this.groupBox12.Controls.Add(this.radioButtonStageDirPolarityTrue);
            this.groupBox12.Location = new System.Drawing.Point(188, 310);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(174, 55);
            this.groupBox12.TabIndex = 20;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "方向极性";
            // 
            // buttonReadStageDirPolarity
            // 
            this.buttonReadStageDirPolarity.Location = new System.Drawing.Point(8, 29);
            this.buttonReadStageDirPolarity.Name = "buttonReadStageDirPolarity";
            this.buttonReadStageDirPolarity.Size = new System.Drawing.Size(75, 21);
            this.buttonReadStageDirPolarity.TabIndex = 17;
            this.buttonReadStageDirPolarity.Text = "Read";
            this.buttonReadStageDirPolarity.UseVisualStyleBackColor = true;
            this.buttonReadStageDirPolarity.Click += new System.EventHandler(this.buttonReadStageDirPolarity_Click);
            // 
            // buttonSetStageDirPolarity
            // 
            this.buttonSetStageDirPolarity.Location = new System.Drawing.Point(89, 29);
            this.buttonSetStageDirPolarity.Name = "buttonSetStageDirPolarity";
            this.buttonSetStageDirPolarity.Size = new System.Drawing.Size(75, 21);
            this.buttonSetStageDirPolarity.TabIndex = 16;
            this.buttonSetStageDirPolarity.Text = "Set";
            this.buttonSetStageDirPolarity.UseVisualStyleBackColor = true;
            this.buttonSetStageDirPolarity.Click += new System.EventHandler(this.buttonSetStageDirPolarity_Click);
            // 
            // radioButtonStageDirPolarityFalse
            // 
            this.radioButtonStageDirPolarityFalse.AutoSize = true;
            this.radioButtonStageDirPolarityFalse.Location = new System.Drawing.Point(77, 12);
            this.radioButtonStageDirPolarityFalse.Name = "radioButtonStageDirPolarityFalse";
            this.radioButtonStageDirPolarityFalse.Size = new System.Drawing.Size(53, 16);
            this.radioButtonStageDirPolarityFalse.TabIndex = 15;
            this.radioButtonStageDirPolarityFalse.Text = "False";
            this.radioButtonStageDirPolarityFalse.UseVisualStyleBackColor = true;
            // 
            // radioButtonStageDirPolarityTrue
            // 
            this.radioButtonStageDirPolarityTrue.AutoSize = true;
            this.radioButtonStageDirPolarityTrue.Checked = true;
            this.radioButtonStageDirPolarityTrue.Location = new System.Drawing.Point(13, 12);
            this.radioButtonStageDirPolarityTrue.Name = "radioButtonStageDirPolarityTrue";
            this.radioButtonStageDirPolarityTrue.Size = new System.Drawing.Size(47, 16);
            this.radioButtonStageDirPolarityTrue.TabIndex = 14;
            this.radioButtonStageDirPolarityTrue.TabStop = true;
            this.radioButtonStageDirPolarityTrue.Text = "True";
            this.radioButtonStageDirPolarityTrue.UseVisualStyleBackColor = true;
            this.radioButtonStageDirPolarityTrue.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.buttonReadStageStepPolarity);
            this.groupBox11.Controls.Add(this.buttonSetStageStepPolarity);
            this.groupBox11.Controls.Add(this.radioButtonStageStepPolarityFalse);
            this.groupBox11.Controls.Add(this.radioButtonStageStepPolarityTrue);
            this.groupBox11.Location = new System.Drawing.Point(188, 43);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(174, 55);
            this.groupBox11.TabIndex = 19;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "步长极性";
            // 
            // buttonReadStageStepPolarity
            // 
            this.buttonReadStageStepPolarity.Location = new System.Drawing.Point(8, 29);
            this.buttonReadStageStepPolarity.Name = "buttonReadStageStepPolarity";
            this.buttonReadStageStepPolarity.Size = new System.Drawing.Size(75, 21);
            this.buttonReadStageStepPolarity.TabIndex = 17;
            this.buttonReadStageStepPolarity.Text = "Read";
            this.buttonReadStageStepPolarity.UseVisualStyleBackColor = true;
            this.buttonReadStageStepPolarity.Click += new System.EventHandler(this.buttonReadStageStepPolarity_Click);
            // 
            // buttonSetStageStepPolarity
            // 
            this.buttonSetStageStepPolarity.Location = new System.Drawing.Point(89, 29);
            this.buttonSetStageStepPolarity.Name = "buttonSetStageStepPolarity";
            this.buttonSetStageStepPolarity.Size = new System.Drawing.Size(75, 21);
            this.buttonSetStageStepPolarity.TabIndex = 16;
            this.buttonSetStageStepPolarity.Text = "Set";
            this.buttonSetStageStepPolarity.UseVisualStyleBackColor = true;
            this.buttonSetStageStepPolarity.Click += new System.EventHandler(this.buttonSetStageStepPolarity_Click);
            // 
            // radioButtonStageStepPolarityFalse
            // 
            this.radioButtonStageStepPolarityFalse.AutoSize = true;
            this.radioButtonStageStepPolarityFalse.Location = new System.Drawing.Point(77, 12);
            this.radioButtonStageStepPolarityFalse.Name = "radioButtonStageStepPolarityFalse";
            this.radioButtonStageStepPolarityFalse.Size = new System.Drawing.Size(53, 16);
            this.radioButtonStageStepPolarityFalse.TabIndex = 15;
            this.radioButtonStageStepPolarityFalse.Text = "False";
            this.radioButtonStageStepPolarityFalse.UseVisualStyleBackColor = true;
            // 
            // radioButtonStageStepPolarityTrue
            // 
            this.radioButtonStageStepPolarityTrue.AutoSize = true;
            this.radioButtonStageStepPolarityTrue.Checked = true;
            this.radioButtonStageStepPolarityTrue.Location = new System.Drawing.Point(13, 12);
            this.radioButtonStageStepPolarityTrue.Name = "radioButtonStageStepPolarityTrue";
            this.radioButtonStageStepPolarityTrue.Size = new System.Drawing.Size(47, 16);
            this.radioButtonStageStepPolarityTrue.TabIndex = 14;
            this.radioButtonStageStepPolarityTrue.TabStop = true;
            this.radioButtonStageStepPolarityTrue.Text = "True";
            this.radioButtonStageStepPolarityTrue.UseVisualStyleBackColor = true;
            this.radioButtonStageStepPolarityTrue.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.buttonReadStagePulseShape);
            this.groupBox10.Controls.Add(this.buttonSetStagePulseShape);
            this.groupBox10.Controls.Add(this.label14);
            this.groupBox10.Controls.Add(this.numericUpDownStagePulseShapeHoldTime);
            this.groupBox10.Controls.Add(this.label15);
            this.groupBox10.Controls.Add(this.numericUpDownStagePulseShapeSetupTime);
            this.groupBox10.Location = new System.Drawing.Point(6, 266);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(176, 100);
            this.groupBox10.TabIndex = 18;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "脉冲形状 (µs)";
            // 
            // buttonReadStagePulseShape
            // 
            this.buttonReadStagePulseShape.Location = new System.Drawing.Point(11, 73);
            this.buttonReadStagePulseShape.Name = "buttonReadStagePulseShape";
            this.buttonReadStagePulseShape.Size = new System.Drawing.Size(75, 21);
            this.buttonReadStagePulseShape.TabIndex = 15;
            this.buttonReadStagePulseShape.Text = "Read";
            this.buttonReadStagePulseShape.UseVisualStyleBackColor = true;
            this.buttonReadStagePulseShape.Click += new System.EventHandler(this.buttonReadStagePulseShape_Click);
            // 
            // buttonSetStagePulseShape
            // 
            this.buttonSetStagePulseShape.Location = new System.Drawing.Point(89, 73);
            this.buttonSetStagePulseShape.Name = "buttonSetStagePulseShape";
            this.buttonSetStagePulseShape.Size = new System.Drawing.Size(75, 21);
            this.buttonSetStagePulseShape.TabIndex = 12;
            this.buttonSetStagePulseShape.Text = "Set";
            this.buttonSetStagePulseShape.UseVisualStyleBackColor = true;
            this.buttonSetStagePulseShape.Click += new System.EventHandler(this.buttonSetStagePulseShape_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 11;
            this.label14.Text = "保持";
            // 
            // numericUpDownStagePulseShapeHoldTime
            // 
            this.numericUpDownStagePulseShapeHoldTime.DecimalPlaces = 1;
            this.numericUpDownStagePulseShapeHoldTime.Location = new System.Drawing.Point(67, 45);
            this.numericUpDownStagePulseShapeHoldTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownStagePulseShapeHoldTime.Name = "numericUpDownStagePulseShapeHoldTime";
            this.numericUpDownStagePulseShapeHoldTime.Size = new System.Drawing.Size(99, 21);
            this.numericUpDownStagePulseShapeHoldTime.TabIndex = 10;
            this.numericUpDownStagePulseShapeHoldTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownStagePulseShapeHoldTime.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 9;
            this.label15.Text = "上升沿";
            // 
            // numericUpDownStagePulseShapeSetupTime
            // 
            this.numericUpDownStagePulseShapeSetupTime.DecimalPlaces = 1;
            this.numericUpDownStagePulseShapeSetupTime.Location = new System.Drawing.Point(67, 24);
            this.numericUpDownStagePulseShapeSetupTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownStagePulseShapeSetupTime.Name = "numericUpDownStagePulseShapeSetupTime";
            this.numericUpDownStagePulseShapeSetupTime.Size = new System.Drawing.Size(99, 21);
            this.numericUpDownStagePulseShapeSetupTime.TabIndex = 8;
            this.numericUpDownStagePulseShapeSetupTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownStagePulseShapeSetupTime.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonReadStageDelay);
            this.groupBox6.Controls.Add(this.buttonSetStageDelay);
            this.groupBox6.Controls.Add(this.numericUpDownStageDelay);
            this.groupBox6.Location = new System.Drawing.Point(188, 189);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(174, 62);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "延时";
            // 
            // buttonReadStageDelay
            // 
            this.buttonReadStageDelay.Location = new System.Drawing.Point(11, 36);
            this.buttonReadStageDelay.Name = "buttonReadStageDelay";
            this.buttonReadStageDelay.Size = new System.Drawing.Size(75, 21);
            this.buttonReadStageDelay.TabIndex = 14;
            this.buttonReadStageDelay.Text = "Read";
            this.buttonReadStageDelay.UseVisualStyleBackColor = true;
            this.buttonReadStageDelay.Click += new System.EventHandler(this.buttonReadStageDelay_Click);
            // 
            // buttonSetStageDelay
            // 
            this.buttonSetStageDelay.Location = new System.Drawing.Point(92, 36);
            this.buttonSetStageDelay.Name = "buttonSetStageDelay";
            this.buttonSetStageDelay.Size = new System.Drawing.Size(75, 21);
            this.buttonSetStageDelay.TabIndex = 12;
            this.buttonSetStageDelay.Text = "Set";
            this.buttonSetStageDelay.UseVisualStyleBackColor = true;
            this.buttonSetStageDelay.Click += new System.EventHandler(this.buttonSetStageDelay_Click);
            // 
            // numericUpDownStageDelay
            // 
            this.numericUpDownStageDelay.Location = new System.Drawing.Point(11, 16);
            this.numericUpDownStageDelay.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownStageDelay.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownStageDelay.Name = "numericUpDownStageDelay";
            this.numericUpDownStageDelay.Size = new System.Drawing.Size(155, 21);
            this.numericUpDownStageDelay.TabIndex = 8;
            this.numericUpDownStageDelay.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(134, 18);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(57, 21);
            this.button9.TabIndex = 12;
            this.button9.Text = "初始化";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.buttonInit_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "平台";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.buttonReadStageEnabled);
            this.groupBox8.Controls.Add(this.buttonSetStageEnabled);
            this.groupBox8.Controls.Add(this.radioButtonStageDisabled);
            this.groupBox8.Controls.Add(this.radioButtonStageEnabled);
            this.groupBox8.Location = new System.Drawing.Point(6, 43);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(176, 55);
            this.groupBox8.TabIndex = 16;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "使能";
            // 
            // buttonReadStageEnabled
            // 
            this.buttonReadStageEnabled.Location = new System.Drawing.Point(8, 29);
            this.buttonReadStageEnabled.Name = "buttonReadStageEnabled";
            this.buttonReadStageEnabled.Size = new System.Drawing.Size(75, 21);
            this.buttonReadStageEnabled.TabIndex = 17;
            this.buttonReadStageEnabled.Text = "Read";
            this.buttonReadStageEnabled.UseVisualStyleBackColor = true;
            this.buttonReadStageEnabled.Click += new System.EventHandler(this.buttonReadStageEnabled_Click);
            // 
            // buttonSetStageEnabled
            // 
            this.buttonSetStageEnabled.Location = new System.Drawing.Point(89, 29);
            this.buttonSetStageEnabled.Name = "buttonSetStageEnabled";
            this.buttonSetStageEnabled.Size = new System.Drawing.Size(75, 21);
            this.buttonSetStageEnabled.TabIndex = 16;
            this.buttonSetStageEnabled.Text = "Set";
            this.buttonSetStageEnabled.UseVisualStyleBackColor = true;
            this.buttonSetStageEnabled.Click += new System.EventHandler(this.buttonSetStageEnabled_Click);
            // 
            // radioButtonStageDisabled
            // 
            this.radioButtonStageDisabled.AutoSize = true;
            this.radioButtonStageDisabled.Location = new System.Drawing.Point(77, 12);
            this.radioButtonStageDisabled.Name = "radioButtonStageDisabled";
            this.radioButtonStageDisabled.Size = new System.Drawing.Size(35, 16);
            this.radioButtonStageDisabled.TabIndex = 15;
            this.radioButtonStageDisabled.Text = "否";
            this.radioButtonStageDisabled.UseVisualStyleBackColor = true;
            // 
            // radioButtonStageEnabled
            // 
            this.radioButtonStageEnabled.AutoSize = true;
            this.radioButtonStageEnabled.Checked = true;
            this.radioButtonStageEnabled.Location = new System.Drawing.Point(13, 12);
            this.radioButtonStageEnabled.Name = "radioButtonStageEnabled";
            this.radioButtonStageEnabled.Size = new System.Drawing.Size(35, 16);
            this.radioButtonStageEnabled.TabIndex = 14;
            this.radioButtonStageEnabled.TabStop = true;
            this.radioButtonStageEnabled.Text = "是";
            this.radioButtonStageEnabled.UseVisualStyleBackColor = true;
            this.radioButtonStageEnabled.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // comboBoxStage
            // 
            this.comboBoxStage.FormattingEnabled = true;
            this.comboBoxStage.Location = new System.Drawing.Point(48, 18);
            this.comboBoxStage.Name = "comboBoxStage";
            this.comboBoxStage.Size = new System.Drawing.Size(80, 20);
            this.comboBoxStage.TabIndex = 7;
            this.comboBoxStage.SelectedIndexChanged += new System.EventHandler(this.comboBoxStage_SelectedIndexChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.buttonReadStageRawPosition);
            this.groupBox7.Controls.Add(this.buttonSetStageRawPosition);
            this.groupBox7.Controls.Add(this.numericUpDownStageRawPosition);
            this.groupBox7.Location = new System.Drawing.Point(6, 189);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(176, 73);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "当前位置";
            // 
            // buttonReadStageRawPosition
            // 
            this.buttonReadStageRawPosition.Location = new System.Drawing.Point(8, 41);
            this.buttonReadStageRawPosition.Name = "buttonReadStageRawPosition";
            this.buttonReadStageRawPosition.Size = new System.Drawing.Size(75, 21);
            this.buttonReadStageRawPosition.TabIndex = 14;
            this.buttonReadStageRawPosition.Text = "Read";
            this.buttonReadStageRawPosition.UseVisualStyleBackColor = true;
            this.buttonReadStageRawPosition.Click += new System.EventHandler(this.buttonReadStageRawPosition_Click);
            // 
            // buttonSetStageRawPosition
            // 
            this.buttonSetStageRawPosition.Location = new System.Drawing.Point(89, 41);
            this.buttonSetStageRawPosition.Name = "buttonSetStageRawPosition";
            this.buttonSetStageRawPosition.Size = new System.Drawing.Size(75, 21);
            this.buttonSetStageRawPosition.TabIndex = 12;
            this.buttonSetStageRawPosition.Text = "Set";
            this.buttonSetStageRawPosition.UseVisualStyleBackColor = true;
            this.buttonSetStageRawPosition.Click += new System.EventHandler(this.buttonSetStageRawPosition_Click);
            // 
            // numericUpDownStageRawPosition
            // 
            this.numericUpDownStageRawPosition.Location = new System.Drawing.Point(8, 16);
            this.numericUpDownStageRawPosition.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownStageRawPosition.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownStageRawPosition.Name = "numericUpDownStageRawPosition";
            this.numericUpDownStageRawPosition.Size = new System.Drawing.Size(158, 21);
            this.numericUpDownStageRawPosition.TabIndex = 8;
            this.numericUpDownStageRawPosition.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonStageMove);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.numericUpDownStageMoveMaxVel);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numericUpDownStageMovePosition);
            this.groupBox3.Location = new System.Drawing.Point(6, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 86);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "平台移动";
            // 
            // buttonStageMove
            // 
            this.buttonStageMove.Location = new System.Drawing.Point(89, 57);
            this.buttonStageMove.Name = "buttonStageMove";
            this.buttonStageMove.Size = new System.Drawing.Size(75, 21);
            this.buttonStageMove.TabIndex = 12;
            this.buttonStageMove.Text = "开始移动";
            this.buttonStageMove.UseVisualStyleBackColor = true;
            this.buttonStageMove.Click += new System.EventHandler(this.buttonStageMove_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "最大速度";
            // 
            // numericUpDownStageMoveMaxVel
            // 
            this.numericUpDownStageMoveMaxVel.Location = new System.Drawing.Point(67, 35);
            this.numericUpDownStageMoveMaxVel.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownStageMoveMaxVel.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownStageMoveMaxVel.Name = "numericUpDownStageMoveMaxVel";
            this.numericUpDownStageMoveMaxVel.Size = new System.Drawing.Size(99, 21);
            this.numericUpDownStageMoveMaxVel.TabIndex = 10;
            this.numericUpDownStageMoveMaxVel.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "位置";
            // 
            // numericUpDownStageMovePosition
            // 
            this.numericUpDownStageMovePosition.Location = new System.Drawing.Point(67, 16);
            this.numericUpDownStageMovePosition.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownStageMovePosition.Minimum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            -2147483648});
            this.numericUpDownStageMovePosition.Name = "numericUpDownStageMovePosition";
            this.numericUpDownStageMovePosition.Size = new System.Drawing.Size(99, 21);
            this.numericUpDownStageMovePosition.TabIndex = 8;
            this.numericUpDownStageMovePosition.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // UserControlStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox15);
            this.Controls.Add(this.groupBox9);
            this.Name = "UserControlStage";
            this.Size = new System.Drawing.Size(639, 379);
            this.groupBox15.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageMoveXYZ_Z)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageLimitUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageLimitLower)).EndInit();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStagePulseShapeHoldTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStagePulseShapeSetupTime)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageDelay)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageRawPosition)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageMoveMaxVel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStageMovePosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox15;
        private UserControlXYMover userControlXYMoverStage;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonStageMoveXYZ;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownStageMoveXYZ_Z;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Button buttonReadStageLimit;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numericUpDownStageLimitUpper;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDownStageLimitLower;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button buttonReadStageLimitPolarity;
        private System.Windows.Forms.Button buttonSetStageLimitPolarity;
        private System.Windows.Forms.RadioButton radioButtonStageLimitPolarityFalse;
        private System.Windows.Forms.RadioButton radioButtonStageLimitPolarityTrue;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button buttonReadStageDirPolarity;
        private System.Windows.Forms.Button buttonSetStageDirPolarity;
        private System.Windows.Forms.RadioButton radioButtonStageDirPolarityFalse;
        private System.Windows.Forms.RadioButton radioButtonStageDirPolarityTrue;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button buttonReadStageStepPolarity;
        private System.Windows.Forms.Button buttonSetStageStepPolarity;
        private System.Windows.Forms.RadioButton radioButtonStageStepPolarityFalse;
        private System.Windows.Forms.RadioButton radioButtonStageStepPolarityTrue;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button buttonSetStagePulseShape;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDownStagePulseShapeHoldTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDownStagePulseShapeSetupTime;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonReadStageDelay;
        private System.Windows.Forms.Button buttonSetStageDelay;
        private System.Windows.Forms.NumericUpDown numericUpDownStageDelay;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button buttonReadStageEnabled;
        private System.Windows.Forms.Button buttonSetStageEnabled;
        private System.Windows.Forms.RadioButton radioButtonStageDisabled;
        private System.Windows.Forms.RadioButton radioButtonStageEnabled;
        private System.Windows.Forms.ComboBox comboBoxStage;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button buttonReadStageRawPosition;
        private System.Windows.Forms.Button buttonSetStageRawPosition;
        private System.Windows.Forms.NumericUpDown numericUpDownStageRawPosition;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonStageMove;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownStageMoveMaxVel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownStageMovePosition;
        private System.Windows.Forms.Button buttonReadStagePulseShape;
    }
}
