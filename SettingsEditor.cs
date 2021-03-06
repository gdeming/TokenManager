﻿using System;
using System.Windows.Forms;

using BaseClass = TokenManager.TokenManagerEditor;
////using BaseClass = System.Windows.Forms.UserControl;

namespace TokenManager
{
    internal sealed partial class SettingsEditor : BaseClass
    {
        public SettingsEditor(TokenManagerModel model, string name) : base(model)
        {
            InitializeComponent();
            numericUpDownWarnAt.Left = labelWarnAtPrefix.Right;
            labelWarnAtPostfix.Left = numericUpDownWarnAt.Right;
            Name = name;
            Text = name;
            RevertChanges();
            AcceptChanges();
            UpdateAddButtonState();
            UpdateRemoveButtonState();
            UpdateRemoveList();
            Disposed += LocalDispose;
        }

        private void LocalDispose(object sender, EventArgs e)
        {
            Disposed -= LocalDispose;
            TokenManagerHotkeys.Unregister(Name);
        }

        private string ProviderNameToAdd => textBoxAddProvider.Text;

        private string ProviderNameToRemove => comboBoxRemoveProvider.Text;

        public override void AcceptChanges()
        {
            try
            {
                TokenManagerHotkeys.Register(Name, Model.GetSettingsHotKeys(), SettingsHotKey_Pressed);
                Model.SetSettingsEnabled(checkBoxEnable.Checked);
                Model.SetSettingsHotKeys((Keys)textBoxHotKeys.Tag);
                Model.SetTokenAccessNotificationsEnabled(checkBoxEnableTokenNotifications.Checked);
                Model.SetSettingsWarnAt((int)numericUpDownWarnAt.Value);
            }
            catch
            {
                Program.ApplicationContext.Alert(
                    title: "Token Manager",
                    text: "Unable to set settings hotkey",
                    alertType: TokenManagerApplicationContext.AlertType.Error);
            }

        }

        public override void RevertChanges()
        {
            checkBoxEnable.Checked = Model.GetSettingsEnabled();
            Keys hotKeys = Model.GetSettingsHotKeys();
            textBoxHotKeys.Tag = hotKeys;
            textBoxHotKeys.Text = hotKeys.ToDisplayString();
            checkBoxEnableTokenNotifications.Checked = Model.GetTokenAccessNotificationsEnabled();
            numericUpDownWarnAt.Value = Model.GetSettingsWarnAt();
        }

        private void UpdateAddButtonState()
        {
            buttonAddProvider.Enabled = !string.IsNullOrWhiteSpace(ProviderNameToAdd) && !Model.HasProvider(ProviderNameToAdd);
        }

        private void UpdateRemoveButtonState()
        {
            buttonRemoveProvider.Enabled = !string.IsNullOrWhiteSpace(ProviderNameToRemove) && Model.HasProvider(ProviderNameToRemove);
        }

        private void UpdateRemoveList()
        {
            comboBoxRemoveProvider.Items.Clear();
            foreach (string providerName in Model.GetProviderNames())
            {
                comboBoxRemoveProvider.Items.Add(providerName);
            }
        }

        private void SettingsHotKey_Pressed(object sender, TokenManagerHotkeysEventArgs e)
        {
            if (Model.GetSettingsEnabled())
            {
                Program.ApplicationContext.Show();
                e.Handled = true;
            }
        }

        private void buttonAddProvider_Click(object sender, EventArgs e)
        {
            Model.AddProvider(ProviderNameToAdd);
            comboBoxRemoveProvider.Items.Add(ProviderNameToAdd);
            textBoxAddProvider.Text = "";
        }

        private void buttonRemoveProvider_Click(object sender, EventArgs e)
        {
            Model.RemoveProvider(ProviderNameToRemove);
            comboBoxRemoveProvider.Items.Remove(ProviderNameToRemove);
            comboBoxRemoveProvider.Text = "";
        }

        private void textBoxAddProvider_TextChanged(object sender, EventArgs e)
        {
            UpdateAddButtonState();
        }

        private void comboBoxRemoveProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRemoveButtonState();
        }

        private void textBoxHotKeys_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxHotKeys.Tag = e.KeyData;
            textBoxHotKeys.Text = e.KeyData.ToDisplayString();
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
    }
}
