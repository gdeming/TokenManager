using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace TokenManager
{
    internal sealed class TokenManagerApplicationContext : ApplicationContext
    {
        public enum AlertType
        {
            None,
            Info,
            Warning,
            Error
        }

        public TokenManagerApplicationContext()
        {
            _mainForm = new TokenManagerMainForm(new TokenManagerModel());
            _mainForm.FormClosed += ExitHandler;
            _trayIcon = new NotifyIcon()
            {
                Text = "Token Manager",
                Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location),
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Settings", ShowHandler),
                    new MenuItem("Exit", ExitHandler) }),
                Visible = true
            };
            _trayIcon.DoubleClick += ShowHandler;
            _trayIcon.BalloonTipClicked += ShowHandler;
        }

        public void Alert(string title = "", string text = "", AlertType alertType = AlertType.None, int timeout = 3000)
        {
            _trayIcon.BalloonTipIcon = AlertIcon[alertType];
            _trayIcon.BalloonTipText = text;
            _trayIcon.BalloonTipTitle = title;
            _trayIcon.ShowBalloonTip(timeout);
        }

        public void Show() => _mainForm?.Show();

        public void Exit() => Application.Exit();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_mainForm != null)
                {
                    _mainForm.FormClosed -= ExitHandler;
                    _mainForm.Visible = false;
                    _mainForm.Dispose();
                    _mainForm = null;
                }
                if (_trayIcon != null)
                {
                    _trayIcon.BalloonTipClicked -= ShowHandler;
                    _trayIcon.DoubleClick -= ShowHandler;
                    _trayIcon.Visible = false;
                    _trayIcon.Dispose();
                    _trayIcon = null;
                }
            }
            base.Dispose(disposing);
        }
                
        private void ShowHandler(object sender, EventArgs e)
        {
            Show();
        }

        private void ExitHandler(object sender, EventArgs e)
        {
            Exit();
        }

        private TokenManagerMainForm _mainForm;
        private NotifyIcon _trayIcon;

        private static readonly Dictionary<AlertType, ToolTipIcon> AlertIcon = new Dictionary<AlertType, ToolTipIcon>
        {
            { AlertType.None, ToolTipIcon.None },
            { AlertType.Info, ToolTipIcon.Info },
            { AlertType.Warning, ToolTipIcon.Warning },
            { AlertType.Error, ToolTipIcon.Error }
        };
    }
}
