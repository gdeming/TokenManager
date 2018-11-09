using System;
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
                Model.SetProviderTokens(Name, textBoxAccessTokens.Text.ToTokens());
            }
            catch
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
            textBoxAccessTokens.Text = string.Join("\r\n", Model.GetProviderTokens(Name));
        }

        private void CheckForLowTokenCount()
        {
            if (Model.TokenCount(Name) <= Model.GetSettingsWarnAt())
            {
                Program.ApplicationContext.Alert(
                    title: "Token Manager",
                    text: Model.TokenCount(Name).ToString() + " token(s) remaining for provider:" + Text,
                    alertType: TokenManagerApplicationContext.AlertType.Warning);
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
            Program.ApplicationContext.Alert(
                title: "Token Manager",
                text: provider + " token: " + token + "\r\nCopied to the clipboard",
                alertType: TokenManagerApplicationContext.AlertType.Info);
        }

        private void ShowNoTokensError()
        {
            Program.ApplicationContext.Alert(
                title: "Token Manager",
                text: "No tokens remaining for provider:" + Text,
                alertType: TokenManagerApplicationContext.AlertType.Error);
        }

        private void textBoxHotKeys_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxHotKeys.Tag = e.KeyData;
            textBoxHotKeys.Text = e.KeyData.ToDisplayString();
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void textBoxHotKeys_KeyUp(object sender, KeyEventArgs e)
        {
            ////if ((e.KeyData ^ (Keys)textBoxHotKeys.Tag) == Keys.None)
            ////{
            ////    textBoxHotKeys.Tag = Keys.None;
            ////    textBoxHotKeys.Text = e.KeyData.ToDisplayString();
            ////}
            ////else
            ////{
            ////    textBoxHotKeys.Text = e.KeyData.ToDisplayString();
            ////}
        }

        private readonly Regex TokenRegex = new Regex(@"[^A-Za-z0-9 ]");
    }
}
