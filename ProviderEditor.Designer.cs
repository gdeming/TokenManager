namespace TokenManager
{
    partial class ProviderEditor
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
            this.groupBoxHotKeys = new System.Windows.Forms.GroupBox();
            this.textBoxHotKeys = new System.Windows.Forms.TextBox();
            this.checkBoxEnableHotKeys = new System.Windows.Forms.CheckBox();
            this.groupBoxAccessTokens = new System.Windows.Forms.GroupBox();
            this.textBoxAccessTokens = new TokenManager.ProviderTextBox();
            this.groupBoxProviderUrl = new System.Windows.Forms.GroupBox();
            this.textBoxProviderUrl = new System.Windows.Forms.TextBox();
            this.buttonProviderUrl = new System.Windows.Forms.Button();
            this.groupBoxHotKeys.SuspendLayout();
            this.groupBoxAccessTokens.SuspendLayout();
            this.groupBoxProviderUrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxHotKeys
            // 
            this.groupBoxHotKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxHotKeys.Controls.Add(this.textBoxHotKeys);
            this.groupBoxHotKeys.Controls.Add(this.checkBoxEnableHotKeys);
            this.groupBoxHotKeys.Location = new System.Drawing.Point(16, 16);
            this.groupBoxHotKeys.Name = "groupBoxHotKeys";
            this.groupBoxHotKeys.Size = new System.Drawing.Size(266, 72);
            this.groupBoxHotKeys.TabIndex = 1;
            this.groupBoxHotKeys.TabStop = false;
            this.groupBoxHotKeys.Text = "Hot Keys";
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
            this.textBoxHotKeys.WordWrap = false;
            this.textBoxHotKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxHotKeys_KeyDown);
            // 
            // checkBoxEnableHotKeys
            // 
            this.checkBoxEnableHotKeys.AutoSize = true;
            this.checkBoxEnableHotKeys.Checked = true;
            this.checkBoxEnableHotKeys.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnableHotKeys.Location = new System.Drawing.Point(7, 20);
            this.checkBoxEnableHotKeys.Name = "checkBoxEnableHotKeys";
            this.checkBoxEnableHotKeys.Size = new System.Drawing.Size(105, 17);
            this.checkBoxEnableHotKeys.TabIndex = 2;
            this.checkBoxEnableHotKeys.Text = "&Enable Hot Keys";
            this.checkBoxEnableHotKeys.UseVisualStyleBackColor = true;
            // 
            // groupBoxAccessTokens
            // 
            this.groupBoxAccessTokens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAccessTokens.Controls.Add(this.textBoxAccessTokens);
            this.groupBoxAccessTokens.Location = new System.Drawing.Point(16, 152);
            this.groupBoxAccessTokens.Name = "groupBoxAccessTokens";
            this.groupBoxAccessTokens.Size = new System.Drawing.Size(266, 232);
            this.groupBoxAccessTokens.TabIndex = 7;
            this.groupBoxAccessTokens.TabStop = false;
            this.groupBoxAccessTokens.Text = "Access &Tokens";
            // 
            // textBoxAccessTokens
            // 
            this.textBoxAccessTokens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAccessTokens.Location = new System.Drawing.Point(8, 16);
            this.textBoxAccessTokens.Multiline = true;
            this.textBoxAccessTokens.Name = "textBoxAccessTokens";
            this.textBoxAccessTokens.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxAccessTokens.Size = new System.Drawing.Size(250, 208);
            this.textBoxAccessTokens.TabIndex = 8;
            this.textBoxAccessTokens.TextPasted += textBoxAccessTokens_TextPasted;
            // 
            // groupBoxProviderUrl
            // 
            this.groupBoxProviderUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxProviderUrl.Controls.Add(this.textBoxProviderUrl);
            this.groupBoxProviderUrl.Controls.Add(this.buttonProviderUrl);
            this.groupBoxProviderUrl.Location = new System.Drawing.Point(16, 96);
            this.groupBoxProviderUrl.Name = "groupBoxProviderUrl";
            this.groupBoxProviderUrl.Size = new System.Drawing.Size(266, 48);
            this.groupBoxProviderUrl.TabIndex = 4;
            this.groupBoxProviderUrl.TabStop = false;
            this.groupBoxProviderUrl.Text = "Provider &URL";
            // 
            // textBoxProviderUrl
            // 
            this.textBoxProviderUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProviderUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProviderUrl.Location = new System.Drawing.Point(6, 20);
            this.textBoxProviderUrl.Name = "textBoxProviderUrl";
            this.textBoxProviderUrl.Size = new System.Drawing.Size(232, 20);
            this.textBoxProviderUrl.TabIndex = 5;
            this.textBoxProviderUrl.WordWrap = false;
            this.textBoxProviderUrl.TextChanged += new System.EventHandler(this.textBoxProviderUrl_TextChanged);
            // 
            // buttonProviderUrl
            // 
            this.buttonProviderUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProviderUrl.BackgroundImage = global::TokenManager.Properties.Resources.ProviderUrlLink;
            this.buttonProviderUrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonProviderUrl.Location = new System.Drawing.Point(239, 19);
            this.buttonProviderUrl.Name = "buttonProviderUrl";
            this.buttonProviderUrl.Size = new System.Drawing.Size(22, 22);
            this.buttonProviderUrl.TabIndex = 6;
            this.buttonProviderUrl.UseVisualStyleBackColor = true;
            this.buttonProviderUrl.Click += new System.EventHandler(this.buttonProviderUrl_Click);
            // 
            // ProviderEditor
            // 
            this.Controls.Add(this.groupBoxProviderUrl);
            this.Controls.Add(this.groupBoxAccessTokens);
            this.Controls.Add(this.groupBoxHotKeys);
            this.Name = "ProviderEditor";
            this.Size = new System.Drawing.Size(298, 398);
            this.groupBoxHotKeys.ResumeLayout(false);
            this.groupBoxHotKeys.PerformLayout();
            this.groupBoxAccessTokens.ResumeLayout(false);
            this.groupBoxAccessTokens.PerformLayout();
            this.groupBoxProviderUrl.ResumeLayout(false);
            this.groupBoxProviderUrl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxHotKeys;
        private System.Windows.Forms.TextBox textBoxHotKeys;
        private System.Windows.Forms.CheckBox checkBoxEnableHotKeys;
        private System.Windows.Forms.GroupBox groupBoxAccessTokens;
        private TokenManager.ProviderTextBox textBoxAccessTokens;
        private System.Windows.Forms.GroupBox groupBoxProviderUrl;
        private System.Windows.Forms.TextBox textBoxProviderUrl;
        private System.Windows.Forms.Button buttonProviderUrl;
    }
}
