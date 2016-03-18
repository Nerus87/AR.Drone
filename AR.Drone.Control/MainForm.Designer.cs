namespace AR.Drone.WinApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonActivate = new System.Windows.Forms.Button();
            this.buttonDeactivate = new System.Windows.Forms.Button();
            this.pictureBoxVideo = new System.Windows.Forms.PictureBox();
            this.buttonTakeoff = new System.Windows.Forms.Button();
            this.buttonLand = new System.Windows.Forms.Button();
            this.buttonEmergency = new System.Windows.Forms.Button();
            this.timerStateUpdate = new System.Windows.Forms.Timer(this.components);
            this.buttonSwitchCamera = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonLeanLeft = new System.Windows.Forms.Button();
            this.buttonBackward = new System.Windows.Forms.Button();
            this.buttonLeanRight = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonTurnLeft = new System.Windows.Forms.Button();
            this.buttonTurnRight = new System.Windows.Forms.Button();
            this.buttonHover = new System.Windows.Forms.Button();
            this.timerVideoUpdate = new System.Windows.Forms.Timer(this.components);
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxControlPanel = new System.Windows.Forms.GroupBox();
            this.checkBoxFlatTrim = new System.Windows.Forms.CheckBox();
            this.groupBoxDigitalSection = new System.Windows.Forms.GroupBox();
            this.groupBoxAutopilotSection = new System.Windows.Forms.GroupBox();
            this.comboBoxFlightType = new System.Windows.Forms.ComboBox();
            this.labelFlightType = new System.Windows.Forms.Label();
            this.numericUpDownDistance = new System.Windows.Forms.NumericUpDown();
            this.labelDistance = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxControlPanel.SuspendLayout();
            this.groupBoxDigitalSection.SuspendLayout();
            this.groupBoxAutopilotSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonActivate
            // 
            this.buttonActivate.Location = new System.Drawing.Point(174, 14);
            this.buttonActivate.Name = "buttonActivate";
            this.buttonActivate.Size = new System.Drawing.Size(75, 23);
            this.buttonActivate.TabIndex = 0;
            this.buttonActivate.Text = "Activate";
            this.buttonActivate.UseVisualStyleBackColor = true;
            this.buttonActivate.Click += new System.EventHandler(this.OnButtonActivateClicked);
            // 
            // buttonDeactivate
            // 
            this.buttonDeactivate.Enabled = false;
            this.buttonDeactivate.Location = new System.Drawing.Point(255, 14);
            this.buttonDeactivate.Name = "buttonDeactivate";
            this.buttonDeactivate.Size = new System.Drawing.Size(75, 23);
            this.buttonDeactivate.TabIndex = 1;
            this.buttonDeactivate.Text = "Deactivate";
            this.buttonDeactivate.UseVisualStyleBackColor = true;
            this.buttonDeactivate.Click += new System.EventHandler(this.OnButtonDeactivateClicked);
            // 
            // pictureBoxVideo
            // 
            this.pictureBoxVideo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxVideo.Enabled = false;
            this.pictureBoxVideo.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxVideo.Name = "pictureBoxVideo";
            this.pictureBoxVideo.Size = new System.Drawing.Size(640, 360);
            this.pictureBoxVideo.TabIndex = 2;
            this.pictureBoxVideo.TabStop = false;
            // 
            // buttonTakeoff
            // 
            this.buttonTakeoff.Location = new System.Drawing.Point(101, 19);
            this.buttonTakeoff.Name = "buttonTakeoff";
            this.buttonTakeoff.Size = new System.Drawing.Size(75, 23);
            this.buttonTakeoff.TabIndex = 4;
            this.buttonTakeoff.Text = "Takeoff";
            this.buttonTakeoff.UseVisualStyleBackColor = true;
            this.buttonTakeoff.Click += new System.EventHandler(this.OnButtonTakeoffClick);
            // 
            // buttonLand
            // 
            this.buttonLand.Enabled = false;
            this.buttonLand.Location = new System.Drawing.Point(184, 19);
            this.buttonLand.Name = "buttonLand";
            this.buttonLand.Size = new System.Drawing.Size(75, 23);
            this.buttonLand.TabIndex = 5;
            this.buttonLand.Text = "Land";
            this.buttonLand.UseVisualStyleBackColor = true;
            this.buttonLand.Click += new System.EventHandler(this.OnButtonLandClicked);
            // 
            // buttonEmergency
            // 
            this.buttonEmergency.Location = new System.Drawing.Point(6, 19);
            this.buttonEmergency.Name = "buttonEmergency";
            this.buttonEmergency.Size = new System.Drawing.Size(83, 23);
            this.buttonEmergency.TabIndex = 6;
            this.buttonEmergency.Text = "Emergency";
            this.buttonEmergency.UseVisualStyleBackColor = true;
            this.buttonEmergency.Click += new System.EventHandler(this.OnButtonEmergencyClicked);
            // 
            // timerStateUpdate
            // 
            this.timerStateUpdate.Interval = 500;
            this.timerStateUpdate.Tick += new System.EventHandler(this.OnTimerStateUpdateTick);
            // 
            // buttonSwitchCamera
            // 
            this.buttonSwitchCamera.Enabled = false;
            this.buttonSwitchCamera.Location = new System.Drawing.Point(6, 385);
            this.buttonSwitchCamera.Name = "buttonSwitchCamera";
            this.buttonSwitchCamera.Size = new System.Drawing.Size(641, 23);
            this.buttonSwitchCamera.TabIndex = 8;
            this.buttonSwitchCamera.Text = "Switch Camera";
            this.buttonSwitchCamera.UseVisualStyleBackColor = true;
            this.buttonSwitchCamera.Click += new System.EventHandler(this.OnButtonSwitchCamClicked);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(6, 19);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(75, 23);
            this.buttonUp.TabIndex = 9;
            this.buttonUp.Text = "Altitude+";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.OnButtonUpClicked);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(6, 48);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(75, 23);
            this.buttonDown.TabIndex = 10;
            this.buttonDown.Text = "Altitude-";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.OnButtonDownClicked);
            // 
            // buttonLeanLeft
            // 
            this.buttonLeanLeft.Location = new System.Drawing.Point(87, 48);
            this.buttonLeanLeft.Name = "buttonLeanLeft";
            this.buttonLeanLeft.Size = new System.Drawing.Size(75, 23);
            this.buttonLeanLeft.TabIndex = 11;
            this.buttonLeanLeft.Text = "Lean Left";
            this.buttonLeanLeft.UseVisualStyleBackColor = true;
            this.buttonLeanLeft.Click += new System.EventHandler(this.OnButtonLeanLeftClicked);
            // 
            // buttonBackward
            // 
            this.buttonBackward.Location = new System.Drawing.Point(168, 48);
            this.buttonBackward.Name = "buttonBackward";
            this.buttonBackward.Size = new System.Drawing.Size(75, 23);
            this.buttonBackward.TabIndex = 12;
            this.buttonBackward.Text = "Backward";
            this.buttonBackward.UseVisualStyleBackColor = true;
            this.buttonBackward.Click += new System.EventHandler(this.OnButtonBackClicked);
            // 
            // buttonLeanRight
            // 
            this.buttonLeanRight.Location = new System.Drawing.Point(249, 48);
            this.buttonLeanRight.Name = "buttonLeanRight";
            this.buttonLeanRight.Size = new System.Drawing.Size(75, 23);
            this.buttonLeanRight.TabIndex = 13;
            this.buttonLeanRight.Text = "Lean Right";
            this.buttonLeanRight.UseVisualStyleBackColor = true;
            this.buttonLeanRight.Click += new System.EventHandler(this.OnButtonLeanRightClicked);
            // 
            // buttonForward
            // 
            this.buttonForward.Location = new System.Drawing.Point(168, 19);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(75, 23);
            this.buttonForward.TabIndex = 14;
            this.buttonForward.Text = "Forward";
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.OnbuttonForwardClicked);
            // 
            // buttonTurnLeft
            // 
            this.buttonTurnLeft.Location = new System.Drawing.Point(87, 19);
            this.buttonTurnLeft.Name = "buttonTurnLeft";
            this.buttonTurnLeft.Size = new System.Drawing.Size(75, 23);
            this.buttonTurnLeft.TabIndex = 15;
            this.buttonTurnLeft.Text = "Turn Left";
            this.buttonTurnLeft.UseVisualStyleBackColor = true;
            this.buttonTurnLeft.Click += new System.EventHandler(this.OnButtonTurnLeftClicked);
            // 
            // buttonTurnRight
            // 
            this.buttonTurnRight.Location = new System.Drawing.Point(249, 19);
            this.buttonTurnRight.Name = "buttonTurnRight";
            this.buttonTurnRight.Size = new System.Drawing.Size(75, 23);
            this.buttonTurnRight.TabIndex = 16;
            this.buttonTurnRight.Text = "Turn Right";
            this.buttonTurnRight.UseVisualStyleBackColor = true;
            this.buttonTurnRight.Click += new System.EventHandler(this.OnButtonTurnRightClicked);
            // 
            // buttonHover
            // 
            this.buttonHover.Enabled = false;
            this.buttonHover.Location = new System.Drawing.Point(265, 19);
            this.buttonHover.Name = "buttonHover";
            this.buttonHover.Size = new System.Drawing.Size(75, 23);
            this.buttonHover.TabIndex = 17;
            this.buttonHover.Text = "Hover";
            this.buttonHover.UseVisualStyleBackColor = true;
            this.buttonHover.Click += new System.EventHandler(this.OnButtonHoverClicked);
            // 
            // timerVideoUpdate
            // 
            this.timerVideoUpdate.Interval = 1;
            this.timerVideoUpdate.Tick += new System.EventHandler(this.OnTimerVideoUpdateTick);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(95, 19);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(83, 23);
            this.buttonReset.TabIndex = 19;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.OnButtonResetClicked);
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(6, 59);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(247, 23);
            this.buttonExecute.TabIndex = 25;
            this.buttonExecute.Text = "Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.OnButtonExecuteChenged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxHost);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.buttonActivate);
            this.groupBox1.Controls.Add(this.buttonDeactivate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 99);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Panel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP Address:";
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(73, 16);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(95, 20);
            this.textBoxHost.TabIndex = 3;
            this.textBoxHost.Text = "192.168.1.1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonReset);
            this.groupBox2.Controls.Add(this.buttonEmergency);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(6, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 49);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Emergency Section";
            // 
            // groupBoxControlPanel
            // 
            this.groupBoxControlPanel.Controls.Add(this.buttonHover);
            this.groupBoxControlPanel.Controls.Add(this.checkBoxFlatTrim);
            this.groupBoxControlPanel.Controls.Add(this.groupBoxDigitalSection);
            this.groupBoxControlPanel.Controls.Add(this.groupBoxAutopilotSection);
            this.groupBoxControlPanel.Controls.Add(this.buttonTakeoff);
            this.groupBoxControlPanel.Controls.Add(this.buttonLand);
            this.groupBoxControlPanel.Enabled = false;
            this.groupBoxControlPanel.Location = new System.Drawing.Point(12, 117);
            this.groupBoxControlPanel.Name = "groupBoxControlPanel";
            this.groupBoxControlPanel.Size = new System.Drawing.Size(347, 231);
            this.groupBoxControlPanel.TabIndex = 27;
            this.groupBoxControlPanel.TabStop = false;
            this.groupBoxControlPanel.Text = "Control Panel";
            // 
            // checkBoxFlatTrim
            // 
            this.checkBoxFlatTrim.AutoSize = true;
            this.checkBoxFlatTrim.Checked = true;
            this.checkBoxFlatTrim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFlatTrim.Location = new System.Drawing.Point(12, 23);
            this.checkBoxFlatTrim.Name = "checkBoxFlatTrim";
            this.checkBoxFlatTrim.Size = new System.Drawing.Size(86, 17);
            this.checkBoxFlatTrim.TabIndex = 6;
            this.checkBoxFlatTrim.Text = "Flat Trim: On";
            this.checkBoxFlatTrim.UseVisualStyleBackColor = true;
            this.checkBoxFlatTrim.CheckedChanged += new System.EventHandler(this.OnCheckBoxFlatTrimChanged);
            // 
            // groupBoxDigitalSection
            // 
            this.groupBoxDigitalSection.Controls.Add(this.buttonUp);
            this.groupBoxDigitalSection.Controls.Add(this.buttonDown);
            this.groupBoxDigitalSection.Controls.Add(this.buttonLeanLeft);
            this.groupBoxDigitalSection.Controls.Add(this.buttonTurnRight);
            this.groupBoxDigitalSection.Controls.Add(this.buttonBackward);
            this.groupBoxDigitalSection.Controls.Add(this.buttonTurnLeft);
            this.groupBoxDigitalSection.Controls.Add(this.buttonLeanRight);
            this.groupBoxDigitalSection.Controls.Add(this.buttonForward);
            this.groupBoxDigitalSection.Enabled = false;
            this.groupBoxDigitalSection.Location = new System.Drawing.Point(6, 143);
            this.groupBoxDigitalSection.Name = "groupBoxDigitalSection";
            this.groupBoxDigitalSection.Size = new System.Drawing.Size(335, 81);
            this.groupBoxDigitalSection.TabIndex = 1;
            this.groupBoxDigitalSection.TabStop = false;
            this.groupBoxDigitalSection.Text = "Digital Section";
            // 
            // groupBoxAutopilotSection
            // 
            this.groupBoxAutopilotSection.Controls.Add(this.comboBoxFlightType);
            this.groupBoxAutopilotSection.Controls.Add(this.labelFlightType);
            this.groupBoxAutopilotSection.Controls.Add(this.numericUpDownDistance);
            this.groupBoxAutopilotSection.Controls.Add(this.labelDistance);
            this.groupBoxAutopilotSection.Controls.Add(this.buttonExecute);
            this.groupBoxAutopilotSection.Enabled = false;
            this.groupBoxAutopilotSection.Location = new System.Drawing.Point(6, 48);
            this.groupBoxAutopilotSection.Name = "groupBoxAutopilotSection";
            this.groupBoxAutopilotSection.Size = new System.Drawing.Size(335, 89);
            this.groupBoxAutopilotSection.TabIndex = 0;
            this.groupBoxAutopilotSection.TabStop = false;
            this.groupBoxAutopilotSection.Text = "Autopilot Section";
            // 
            // comboBoxFlightType
            // 
            this.comboBoxFlightType.FormattingEnabled = true;
            this.comboBoxFlightType.Location = new System.Drawing.Point(132, 32);
            this.comboBoxFlightType.Name = "comboBoxFlightType";
            this.comboBoxFlightType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFlightType.TabIndex = 28;
            this.comboBoxFlightType.Text = "Select Flight Type";
            // 
            // labelFlightType
            // 
            this.labelFlightType.AutoSize = true;
            this.labelFlightType.Location = new System.Drawing.Point(129, 16);
            this.labelFlightType.Name = "labelFlightType";
            this.labelFlightType.Size = new System.Drawing.Size(58, 13);
            this.labelFlightType.TabIndex = 27;
            this.labelFlightType.Text = "Flight type:";
            // 
            // numericUpDownDistance
            // 
            this.numericUpDownDistance.Location = new System.Drawing.Point(6, 32);
            this.numericUpDownDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDistance.Name = "numericUpDownDistance";
            this.numericUpDownDistance.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDistance.TabIndex = 50;
            this.numericUpDownDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDistance.ValueChanged += new System.EventHandler(this.OnNumericUpDownDistanceChanged);
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(3, 16);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(69, 13);
            this.labelDistance.TabIndex = 6;
            this.labelDistance.Text = "Distance [m]:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pictureBoxVideo);
            this.groupBox6.Controls.Add(this.buttonSwitchCamera);
            this.groupBox6.Location = new System.Drawing.Point(365, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(653, 421);
            this.groupBox6.TabIndex = 28;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Camera Panel";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 445);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBoxControlPanel);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "AR.Drone Control";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBoxControlPanel.ResumeLayout(false);
            this.groupBoxControlPanel.PerformLayout();
            this.groupBoxDigitalSection.ResumeLayout(false);
            this.groupBoxAutopilotSection.ResumeLayout(false);
            this.groupBoxAutopilotSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonActivate;
        private System.Windows.Forms.Button buttonDeactivate;
        private System.Windows.Forms.PictureBox pictureBoxVideo;
        private System.Windows.Forms.Button buttonTakeoff;
        private System.Windows.Forms.Button buttonLand;
        private System.Windows.Forms.Button buttonEmergency;
        private System.Windows.Forms.Timer timerStateUpdate;
        private System.Windows.Forms.Button buttonSwitchCamera;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonLeanLeft;
        private System.Windows.Forms.Button buttonBackward;
        private System.Windows.Forms.Button buttonLeanRight;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Button buttonTurnLeft;
        private System.Windows.Forms.Button buttonTurnRight;
        private System.Windows.Forms.Button buttonHover;
        private System.Windows.Forms.Timer timerVideoUpdate;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBoxControlPanel;
        private System.Windows.Forms.CheckBox checkBoxFlatTrim;
        private System.Windows.Forms.GroupBox groupBoxDigitalSection;
        private System.Windows.Forms.GroupBox groupBoxAutopilotSection;
        private System.Windows.Forms.ComboBox comboBoxFlightType;
        private System.Windows.Forms.Label labelFlightType;
        private System.Windows.Forms.NumericUpDown numericUpDownDistance;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}

