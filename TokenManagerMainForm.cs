using System;
using System.Windows.Forms;

namespace TokenManager
{
    internal sealed partial class TokenManagerMainForm : Form
    {
        public TokenManagerMainForm(TokenManagerModel model)
        {
            InitializeComponent();
            Model = model;
            Model.ProviderAdded += ProviderAddedHandler;
            Model.ProviderRemoved += ProviderRemovedHandler;
            tabControlMain.AddSettingsPage(Model);
            foreach (string providerName in Model.GetProviderNames())
            {
                tabControlMain.AddProviderPage(Model, providerName);
            }
            tabControlMain.SelectedIndex = 0;
            Disposed += LocalDispose;
        }

        private void LocalDispose(object sender, EventArgs e)
        {
            Disposed -= LocalDispose;
            Model.ProviderAdded -= ProviderAddedHandler;
            Model.ProviderRemoved -= ProviderRemovedHandler;
        }

        private void ApplyChanges()
        {
            tabControlMain.AcceptAllChanges();
            Model.Save();
        }

        private void DiscardChanges()
        {
            tabControlMain.RevertAllChanges();
        }

        private void ShowFormHandler(object sender, EventArgs e)
        {
            Show();
        }

        private void ApplyChangesHandler(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        private void AcceptChangesHandler(object sender, EventArgs e)
        {
            ApplyChanges();
            Hide();
        }

        private void CancelChangesHandler(object sender, EventArgs e)
        {
            DiscardChanges();
            Hide();
        }

        private void ProviderAddedHandler(object sender, ProviderDataEventArgs e)
        {
            tabControlMain.AddProviderPage(Model, e.Name);
        }

        private void ProviderRemovedHandler(object sender, ProviderDataEventArgs e)
        {
            tabControlMain.RemoveProviderPage(e.Name);
        }

        private void CloseFormHandler(object sender, FormClosingEventArgs e)
        {
            if ((e.CloseReason == CloseReason.UserClosing)
            && ((ModifierKeys & Keys.Shift) != Keys.Shift))
            {
                DiscardChanges();
                e.Cancel = true;
                Hide();
            }
        }

        private TokenManagerModel Model { get; }
    }
}
