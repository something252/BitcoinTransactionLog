using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bitcoin_Transaction_Log
{
    public class NotificationIcon
    {
        public NotifyIcon notifyIcon;
        private ContextMenu notificationMenu;
        private MainForm mainForm;

        #region Initialize icon and menu
        public NotificationIcon(MainForm form1)
        {
            mainForm = form1;
            notifyIcon = new NotifyIcon();
            notificationMenu = new ContextMenu(InitializeMenu());

            if (mainForm.CryptoList.CurrentCryptoType == "ETH")
                notifyIcon.Icon = Properties.Resources.Ethereum32icon;
            else if (mainForm.CryptoList.CurrentCryptoType == "LTC")
                notifyIcon.Icon = Properties.Resources.Litecoin32icon;
            else
                notifyIcon.Icon = Properties.Resources.Bitcoin50;
            
            notifyIcon.MouseClick += menuShowClick;
            notifyIcon.ContextMenu = notificationMenu;
        }

        private MenuItem[] InitializeMenu()
        {
            MenuItem[] menu = new MenuItem[] {
                new MenuItem("Show", menuShow),
                new MenuItem("Exit", menuExitClick)
            };
            return menu;
        }
        #endregion

        #region Event Handlers        
        private void menuExitClick(object sender, EventArgs e)
        {
            mainForm.Close();
        }

        private void menuShow(object sender, EventArgs e)
        {
            mainForm.Show();
            mainForm.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

         private void menuShowClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                mainForm.Show();
                mainForm.WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }
        #endregion
    }
}
