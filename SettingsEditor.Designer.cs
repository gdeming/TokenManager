namespace TokenManager
{
    partial class SettingsEditor
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.textBoxHotKeys = new System.Windows.Forms.TextBox();
            this.checkBoxEnable = new System.Windows.Forms.CheckBox();
            this.groupBoxAddProvider = new System.Windows.Forms.GroupBox();
            this.buttonAddProvider = new System.Windows.Forms.Button();
            this.textBoxAddProvider = new System.Windows.Forms.TextBox();
            this.groupBoxRemoveProvider = new System.Windows.Forms.GroupBox();
            this.buttonRemoveProvider = new System.Windows.Forms.Button();
            this.comboBoxRemoveProvider = new System.Windows.Forms.ComboBox();
            this.groupBoxNotifications = new System.Windows.Forms.GroupBox();
            this.checkBoxEnableTokenNotifications = new System.Windows.Forms.CheckBox();
            this.labelWarnAtPrefix = new System.Windows.Forms.Label();
            this.labelWarnAtPostfix = new System.Windows.Forms.Label();
            this.numericUpDownWarnAt = new System.Windows.Forms.NumericUpDown();
            this.groupBox.SuspendLayout();
            this.groupBoxAddProvider.SuspendLayout();
            this.groupBoxRemoveProvider.SuspendLayout();
            this.groupBoxNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWarnAt)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.textBoxHotKeys);
            this.groupBox.Controls.Add(this.checkBoxEnable);
            this.groupBox.Location = new System.Drawing.Point(16, 16);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(266, 72);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Hot &Keys";
            // 
            // textBoxHotKeys
            // 
            this.textBoxHotKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHotKeys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxHotKeys.Location = new System.Drawing.Point(6, 43);
            this.textBoxHotKeys.Name = "textBoxHotKeys";
            this.textBoxHotKeys.Size = new System.Drawing.Size(254, 20);
            this.textBoxHotKeys.TabIndex = 3;
            this.textBoxHotKeys.Text = "Alt + Control + Shift + S";
            this.textBoxHotKeys.WordWrap = false;
            this.textBoxHotKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxHotKeys_KeyDown);
            // 
            // checkBoxEnable
            // 
            this.checkBoxEnable.AutoSize = true;
            this.checkBoxEnable.Checked = true;
            this.checkBoxEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnable.Location = new System.Drawing.Point(7, 20);
            this.checkBoxEnable.Name = "checkBoxEnable";
            this.checkBoxEnable.Size = new System.Drawing.Size(145, 17);
            this.checkBoxEnable.TabIndex = 2;
            this.checkBoxEnable.Text = "Enable &Providers (Global)";
            this.checkBoxEnable.UseVisualStyleBackColor = true;
            // 
            // groupBoxAddProvider
            // 
            this.groupBoxAddProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAddProvider.Controls.Add(this.buttonAddProvider);
            this.groupBoxAddProvider.Controls.Add(this.textBoxAddProvider);
            this.groupBoxAddProvider.Location = new System.Drawing.Point(16, 96);
            this.groupBoxAddProvider.Name = "groupBoxAddProvider";
            this.groupBoxAddProvider.Size = new System.Drawing.Size(266, 84);
            this.groupBoxAddProvider.TabIndex = 4;
            this.groupBoxAddProvider.TabStop = false;
            this.groupBoxAddProvider.Text = "&Add Provider";
            // 
            // buttonAddProvider
            // 
            this.buttonAddProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddProvider.Location = new System.Drawing.Point(168, 46);
            this.buttonAddProvider.Name = "buttonAddProvider";
            this.buttonAddProvider.Size = new System.Drawing.Size(92, 32);
            this.buttonAddProvider.TabIndex = 6;
            this.buttonAddProvider.Text = "Add";
            this.buttonAddProvider.UseVisualStyleBackColor = true;
            this.buttonAddProvider.Click += new System.EventHandler(this.buttonAddProvider_Click);
            // 
            // textBoxAddProvider
            // 
            this.textBoxAddProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddProvider.Location = new System.Drawing.Point(6, 20);
            this.textBoxAddProvider.Name = "textBoxAddProvider";
            this.textBoxAddProvider.Size = new System.Drawing.Size(254, 20);
            this.textBoxAddProvider.TabIndex = 5;
            this.textBoxAddProvider.TextChanged += new System.EventHandler(this.textBoxAddProvider_TextChanged);
            // 
            // groupBoxRemoveProvider
            // 
            this.groupBoxRemoveProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRemoveProvider.Controls.Add(this.buttonRemoveProvider);
            this.groupBoxRemoveProvider.Controls.Add(this.comboBoxRemoveProvider);
            this.groupBoxRemoveProvider.Location = new System.Drawing.Point(16, 188);
            this.groupBoxRemoveProvider.Name = "groupBoxRemoveProvider";
            this.groupBoxRemoveProvider.Size = new System.Drawing.Size(266, 84);
            this.groupBoxRemoveProvider.TabIndex = 7;
            this.groupBoxRemoveProvider.TabStop = false;
            this.groupBoxRemoveProvider.Text = "&Remove Provider";
            // 
            // buttonRemoveProvider
            // 
            this.buttonRemoveProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveProvider.Location = new System.Drawing.Point(168, 46);
            this.buttonRemoveProvider.Name = "buttonRemoveProvider";
            this.buttonRemoveProvider.Size = new System.Drawing.Size(92, 32);
            this.buttonRemoveProvider.TabIndex = 9;
            this.buttonRemoveProvider.Text = "Remove";
            this.buttonRemoveProvider.UseVisualStyleBackColor = true;
            this.buttonRemoveProvider.Click += new System.EventHandler(this.buttonRemoveProvider_Click);
            // 
            // comboBoxRemoveProvider
            // 
            this.comboBoxRemoveProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRemoveProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRemoveProvider.FormattingEnabled = true;
            this.comboBoxRemoveProvider.Location = new System.Drawing.Point(6, 20);
            this.comboBoxRemoveProvider.Name = "comboBoxRemoveProvider";
            this.comboBoxRemoveProvider.Size = new System.Drawing.Size(254, 21);
            this.comboBoxRemoveProvider.TabIndex = 8;
            this.comboBoxRemoveProvider.SelectedIndexChanged += new System.EventHandler(this.comboBoxRemoveProvider_SelectedIndexChanged);
            // 
            // groupBoxNotifications
            // 
            this.groupBoxNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxNotifications.Controls.Add(this.checkBoxEnableTokenNotifications);
            this.groupBoxNotifications.Controls.Add(this.labelWarnAtPrefix);
            this.groupBoxNotifications.Controls.Add(this.labelWarnAtPostfix);
            this.groupBoxNotifications.Controls.Add(this.numericUpDownWarnAt);
            this.groupBoxNotifications.Location = new System.Drawing.Point(16, 280);
            this.groupBoxNotifications.Name = "groupBoxNotifications";
            this.groupBoxNotifications.Size = new System.Drawing.Size(266, 68);
            this.groupBoxNotifications.TabIndex = 10;
            this.groupBoxNotifications.TabStop = false;
            this.groupBoxNotifications.Text = "&Notifications";
            // 
            // checkBoxEnableTokenNotifications
            // 
            this.checkBoxEnableTokenNotifications.AutoSize = true;
            this.checkBoxEnableTokenNotifications.Checked = true;
            this.checkBoxEnableTokenNotifications.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnableTokenNotifications.Location = new System.Drawing.Point(7, 20);
            this.checkBoxEnableTokenNotifications.Name = "checkBoxEnableTokenNotifications";
            this.checkBoxEnableTokenNotifications.Size = new System.Drawing.Size(255, 17);
            this.checkBoxEnableTokenNotifications.TabIndex = 11;
            this.checkBoxEnableTokenNotifications.Text = "&Enable \"Token copied to clipboard\" notifications";
            this.checkBoxEnableTokenNotifications.UseVisualStyleBackColor = true;
            // 
            // labelWarnAtPrefix
            // 
            this.labelWarnAtPrefix.AutoSize = true;
            this.labelWarnAtPrefix.Location = new System.Drawing.Point(6, 44);
            this.labelWarnAtPrefix.Name = "labelWarnAtPrefix";
            this.labelWarnAtPrefix.Size = new System.Drawing.Size(110, 13);
            this.labelWarnAtPrefix.TabIndex = 12;
            this.labelWarnAtPrefix.Text = "&Warn when less than:";
            // 
            // labelWarnAtPostfix
            // 
            this.labelWarnAtPostfix.AutoSize = true;
            this.labelWarnAtPostfix.Location = new System.Drawing.Point(110, 44);
            this.labelWarnAtPostfix.Name = "labelWarnAtPostfix";
            this.labelWarnAtPostfix.Size = new System.Drawing.Size(87, 13);
            this.labelWarnAtPostfix.TabIndex = 14;
            this.labelWarnAtPostfix.Text = "tokens remaining";
            // 
            // numericUpDownWarnAt
            // 
            this.numericUpDownWarnAt.Location = new System.Drawing.Point(50, 41);
            this.numericUpDownWarnAt.Name = "numericUpDownWarnAt";
            this.numericUpDownWarnAt.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownWarnAt.TabIndex = 13;
            this.numericUpDownWarnAt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownWarnAt.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // SettingsEditor
            // 
            this.Controls.Add(this.groupBoxNotifications);
            this.Controls.Add(this.groupBoxRemoveProvider);
            this.Controls.Add(this.groupBoxAddProvider);
            this.Controls.Add(this.groupBox);
            this.Name = "SettingsEditor";
            this.Size = new System.Drawing.Size(298, 398);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBoxAddProvider.ResumeLayout(false);
            this.groupBoxAddProvider.PerformLayout();
            this.groupBoxRemoveProvider.ResumeLayout(false);
            this.groupBoxNotifications.ResumeLayout(false);
            this.groupBoxNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWarnAt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox textBoxHotKeys;
        private System.Windows.Forms.CheckBox checkBoxEnable;
        private System.Windows.Forms.GroupBox groupBoxAddProvider;
        private System.Windows.Forms.Button buttonAddProvider;
        private System.Windows.Forms.TextBox textBoxAddProvider;
        private System.Windows.Forms.GroupBox groupBoxRemoveProvider;
        private System.Windows.Forms.Button buttonRemoveProvider;
        private System.Windows.Forms.ComboBox comboBoxRemoveProvider;
        private System.Windows.Forms.GroupBox groupBoxNotifications;
        private System.Windows.Forms.Label labelWarnAtPrefix;
        private System.Windows.Forms.Label labelWarnAtPostfix;
        private System.Windows.Forms.NumericUpDown numericUpDownWarnAt;
        private System.Windows.Forms.CheckBox checkBoxEnableTokenNotifications;
    }
}
