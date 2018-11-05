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
            this.textBoxAccessTokens = new System.Windows.Forms.TextBox();
            this.groupBoxHotKeys.SuspendLayout();
            this.groupBoxAccessTokens.SuspendLayout();
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
            this.textBoxHotKeys.TabIndex = 1;
            this.textBoxHotKeys.WordWrap = false;
            this.textBoxHotKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxHotKeys_KeyDown);
            this.textBoxHotKeys.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxHotKeys_KeyUp);
            // 
            // checkBoxEnableHotKeys
            // 
            this.checkBoxEnableHotKeys.AutoSize = true;
            this.checkBoxEnableHotKeys.Checked = true;
            this.checkBoxEnableHotKeys.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnableHotKeys.Location = new System.Drawing.Point(7, 20);
            this.checkBoxEnableHotKeys.Name = "checkBoxEnableHotKeys";
            this.checkBoxEnableHotKeys.Size = new System.Drawing.Size(105, 17);
            this.checkBoxEnableHotKeys.TabIndex = 0;
            this.checkBoxEnableHotKeys.Text = "&Enable Hot Keys";
            this.checkBoxEnableHotKeys.UseVisualStyleBackColor = true;
            // 
            // groupBoxAccessTokens
            // 
            this.groupBoxAccessTokens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAccessTokens.Controls.Add(this.textBoxAccessTokens);
            this.groupBoxAccessTokens.Location = new System.Drawing.Point(16, 96);
            this.groupBoxAccessTokens.Name = "groupBoxAccessTokens";
            this.groupBoxAccessTokens.Size = new System.Drawing.Size(266, 286);
            this.groupBoxAccessTokens.TabIndex = 2;
            this.groupBoxAccessTokens.TabStop = false;
            this.groupBoxAccessTokens.Text = "Access Tokens";
            // 
            // textBoxAccessTokens
            // 
            this.textBoxAccessTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAccessTokens.Location = new System.Drawing.Point(3, 16);
            this.textBoxAccessTokens.Multiline = true;
            this.textBoxAccessTokens.Name = "textBoxAccessTokens";
            this.textBoxAccessTokens.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxAccessTokens.Size = new System.Drawing.Size(260, 267);
            this.textBoxAccessTokens.TabIndex = 0;
            // 
            // ProviderEditor
            // 
            this.Controls.Add(this.groupBoxAccessTokens);
            this.Controls.Add(this.groupBoxHotKeys);
            this.Name = "ProviderEditor";
            this.Size = new System.Drawing.Size(298, 398);
            this.groupBoxHotKeys.ResumeLayout(false);
            this.groupBoxHotKeys.PerformLayout();
            this.groupBoxAccessTokens.ResumeLayout(false);
            this.groupBoxAccessTokens.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxHotKeys;
        private System.Windows.Forms.TextBox textBoxHotKeys;
        private System.Windows.Forms.CheckBox checkBoxEnableHotKeys;
        private System.Windows.Forms.GroupBox groupBoxAccessTokens;
        private System.Windows.Forms.TextBox textBoxAccessTokens;
    }
}
