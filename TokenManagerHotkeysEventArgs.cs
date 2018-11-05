using System;
using NHotkey;

namespace TokenManager
{
    internal class TokenManagerHotkeysEventArgs : EventArgs
    {
        public TokenManagerHotkeysEventArgs(string name, bool handled)
        {
            Name = name;
            Handled = handled;
        }

        public string Name { get; }

        public bool Handled { get; set; }

        public static implicit operator TokenManagerHotkeysEventArgs(HotkeyEventArgs e)
        {
            return new TokenManagerHotkeysEventArgs(e.Name, e.Handled);
        }
    }
}
