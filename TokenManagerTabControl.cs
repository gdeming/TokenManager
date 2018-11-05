using System;
using System.Windows.Forms;

namespace TokenManager
{
    internal class TokenManagerTabControl : TabControl
    {
        public TokenManagerTabControl()
        {
            Disposed += LocalDispose;
        }

        private void LocalDispose(object sender, EventArgs e)
        {
            Disposed -= LocalDispose;
            foreach (TabPage tabPage in TabPages)
            {
                tabPage.Dispose();
            }
        }

        public void AddProviderPage(TokenManagerModel model, string name)
        {
            TabPages.Add(new ProviderEditor(model, name));
            SelectedTab = TabPages[name];
        }

        public void AddSettingsPage(TokenManagerModel model)
        {
            TabPages.Add(new SettingsEditor(model, SettingsTabName));
        }

        public void RemoveProviderPage(string name)
        {
            TabPage tabPage = GetTabPage(name);
            TabPages.Remove(tabPage);
            tabPage.Dispose();
        }

        public void RemoveSettingsPage()
        {
            TabPage tabPage = GetTabPage(SettingsTabName);
            TabPages.Remove(tabPage);
            tabPage.Dispose();
        }

        public void AcceptChanges(string name)
        {
            GetTabPage(name).AcceptChanges();
        }

        public void RevertChanges(string name)
        {
            GetTabPage(name).RevertChanges();
        }

        public void AcceptAllChanges()
        {
            foreach (TabPage tabPage in TabPages)
            {
                AcceptChanges(tabPage.Name);
            }
        }

        public void RevertAllChanges()
        {
            foreach (TabPage tabPage in TabPages)
            {
                RevertChanges(tabPage.Name);
            }
        }

        private TokenManagerEditor GetTabPage(string name)
        {
            return TabPages[name] as TokenManagerEditor;
        }

        private const string SettingsTabName = "Settings";
    }
}
