using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TokenManager
{
    internal sealed partial class ProviderEditor : TokenManagerEditor
    {
        public ProviderEditor(TokenManagerModel model, string name) : base(model)
        {
            InitializeComponent();
            Name = name;
            Text = Name;
            RevertChanges();
            AcceptChanges();
            Disposed += LocalDispose;
        }

        private void LocalDispose(object sender, EventArgs e)
        {
            Disposed -= LocalDispose;
            TokenManagerHotkeys.Unregister(Name);
        }

        public override void AcceptChanges()
        {
            try
            {
                FormatTokens();
                TokenManagerHotkeys.Register(Name, Model.GetProviderHotKeys(Name), InsertToken);
                Model.SetProviderEnabled(Name, checkBoxEnableHotKeys.Checked);
                Model.SetProviderHotKeys(Name, (Keys)textBoxHotKeys.Tag);
                Model.SetProviderUrl(Name, textBoxProviderUrl.Text);
                Model.SetProviderTokens(Name, textBoxAccessTokens.Text.ToTokens());
            }
            catch (Exception)
            {
                Program.ApplicationContext.Alert(
                    title: "Token Manager",
                    text: "Unable to set provider hotkey",
                    alertType: TokenManagerApplicationContext.AlertType.Error);
            }
        }

        public override void RevertChanges()
        {
            Keys hotKeys = Model.GetProviderHotKeys(Name);
            checkBoxEnableHotKeys.Checked = Model.GetProviderEnabled(Name);
            textBoxHotKeys.Text = hotKeys.ToDisplayString();
            textBoxHotKeys.Tag = hotKeys;
            textBoxProviderUrl.Text = Model.GetProviderUrl(Name);
            textBoxAccessTokens.Text = string.Join("\r\n", Model.GetProviderTokens(Name));
        }

        private void CheckForLowTokenCount()
        {
            if (Model.TokenCount(Name) <= Model.GetSettingsWarnAt())
            {
                Program.ApplicationContext.Alert(
                    title: "Token Manager",
                    text: $"{Model.TokenCount(Name)} token(s) remaining for provider: {Text}",
                    alertType: TokenManagerApplicationContext.AlertType.Warning,
                    timeout: int.MaxValue);
            }
        }

        private void InsertToken(object sender, TokenManagerHotkeysEventArgs e)
        {
            if (Model.GetSettingsEnabled() && Model.GetProviderEnabled(Name) && !textBoxHotKeys.Focused)
            {
                string token = Model.ExtractProviderToken(e.Name);
                if (!string.IsNullOrWhiteSpace(token))
                {
                    RevertChanges();
                    Model.Save();
                    SendKeys.Send(token);
                    Clipboard.SetText(token);
                    ShowTokenCopy(Name, token);
                    CheckForLowTokenCount();
                }
                else
                {
                    ShowNoTokensError();
                }
                e.Handled = true;
            }
        }

        private void FormatTokens()
        {
            StringBuilder result = new StringBuilder("");
            foreach (string token in TokenRegex.Split(textBoxAccessTokens.Text))
            {
                if (!string.IsNullOrWhiteSpace(token))
                {
                    result.AppendLine(token.Trim());
                }
            }
            textBoxAccessTokens.Text = result.ToString().Trim();
        }

        private void ShowTokenCopy(string provider, string token)
        {
            if (Model.GetTokenAccessNotificationsEnabled())
            {
                Program.ApplicationContext.Alert(
                  title: "Token Manager",
                  text: $"{provider} token: {token}\r\nCopied to the clipboard",
                  alertType: TokenManagerApplicationContext.AlertType.Info);
            }
        }

        private void ShowNoTokensError()
        {
            Program.ApplicationContext.Alert(
                title: "Token Manager",
                text: $"No tokens remaining for provider: {Text}",
                alertType: TokenManagerApplicationContext.AlertType.Error);
        }

        private void textBoxHotKeys_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxHotKeys.Tag = e.KeyData;
            textBoxHotKeys.Text = e.KeyData.ToDisplayString();
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
        
        private void buttonProviderUrl_Click(object sender, EventArgs e)
        {
            Process.Start(textBoxProviderUrl.Text);
        }

        private void textBoxAccessTokens_TextPasted(object sender, EventArgs e)
        {
            FormatTokens();
        }

        private readonly Regex TokenRegex = new Regex(@"[^A-Za-z0-9 ]");
    }
}
