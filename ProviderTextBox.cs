using System;
using System.Windows.Forms;

namespace TokenManager
{
    internal class ProviderTextBox : TextBox
    {
        public event EventHandler TextPasted;

        protected virtual void OnPasted()
        {
            TextPasted?.Invoke(this, new EventArgs());
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PASTE)
            {
                OnPasted();
            }
        }

        private const int WM_PASTE = 0x0302;
    }
}
