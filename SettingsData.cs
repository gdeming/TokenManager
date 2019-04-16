using System.Windows.Forms;

namespace TokenManager
{
    internal class SettingsData
    {
        public SettingsData()
        {
            Enabled = true;
            HotKeys = Keys.None;
            WarnAt = DefaultWarnAt;
        }

        public bool Enabled { get; set; }

        public Keys HotKeys { get; set; }

        public bool TokenAccessNotificationsEnabled { get; set; }

        public int WarnAt { get; set; }

        private const int DefaultWarnAt = 3;
    }
}
