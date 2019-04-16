using NHotkey;
using NHotkey.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TokenManager
{
    internal static class TokenManagerHotkeys
    {
        public static void Register(string name, Keys hotkeys, EventHandler<TokenManagerHotkeysEventArgs> handler)
        {
            try
            {
                Unregister(name);
                if (hotkeys != Keys.None)
                {
                    RegisteredHotkeys.Add(name, new HotkeysData(name, hotkeys, handler));
                    HotkeyManager.Current.AddOrReplace(name, hotkeys, true, HotkeyHandler);
                }
            }
            catch (Exception)
            {
                Program.ApplicationContext.Alert("TokenManager", "Unable to register hotkey", TokenManagerApplicationContext.AlertType.Error);
            }
        }

        public static void Unregister(string name)
        {
            try
            {
                HotkeyManager.Current.Remove(name);
                RegisteredHotkeys.Remove(name);
            }
            catch (Exception)
            {
                Program.ApplicationContext.Alert("TokenManager", "Unable to unregister hotkey", TokenManagerApplicationContext.AlertType.Error);
            }
        }

        public static bool IsRegistered(string name)
        {
            return RegisteredHotkeys.Keys.Contains(name);
        }

        private static void HotkeyHandler(object sender, HotkeyEventArgs e)
        {
            TokenManagerHotkeysEventArgs eventArgs = e;
            RegisteredHotkeys[eventArgs.Name].Handler?.Invoke(sender, eventArgs);
            e.Handled = eventArgs.Handled;
        }

        private static readonly Dictionary<string, HotkeysData> RegisteredHotkeys = new Dictionary<string, HotkeysData>();

        private class HotkeysData
        {
            public HotkeysData(string name, Keys hotkeys, EventHandler<TokenManagerHotkeysEventArgs> handler)
            {
                Name = name;
                Hotkeys = hotkeys;
                Handler = handler;
            }

            public string Name { get; }

            public Keys Hotkeys { get; }

            public EventHandler<TokenManagerHotkeysEventArgs> Handler { get; }
        }
    }
}
