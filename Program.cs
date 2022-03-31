namespace ForceNumLockConstantly
{
    class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        static bool run = true, check = true;
        static System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon
        {
            Icon = Properties.Resources.Numlock,
            Visible = true,
            Text = "Force Numlock",
            ContextMenu = new System.Windows.Forms.ContextMenu(new System.Windows.Forms.MenuItem[] { new System.Windows.Forms.MenuItem("&Stop", MenuItemClick), new System.Windows.Forms.MenuItem("&Close", MenuItemClick) })
        };
        static System.Timers.Timer timer = new System.Timers.Timer
        {
            Interval = 10,
            AutoReset = true,
            Enabled = true
        };
        static void Main()
        {
            timer.Elapsed += CheckNumlock;
            System.Windows.Forms.Application.Run();
        }
        static void CheckNumlock(object sender, System.EventArgs e)
        {
            if (!run)
            {
                ni.Visible = false;
                System.Windows.Forms.Application.Exit();
            }
            if (check && !System.Windows.Forms.Control.IsKeyLocked(System.Windows.Forms.Keys.NumLock))
            {
                keybd_event(144, 0x45, 0x1, 0);
                keybd_event(144, 0x45, 0x1 | 0x2, 0);
            }
        }
        static void MenuItemClick(object sender, System.EventArgs e)
        {
            if (((System.Windows.Forms.MenuItem)sender).Text == "&Stop")
            {
                check = false;
                timer.Stop();
                ((System.Windows.Forms.MenuItem)sender).Text = "&Start";
            }
            else if (((System.Windows.Forms.MenuItem)sender).Text == "&Start")
            {
                check = true;
                timer.Start();
                ((System.Windows.Forms.MenuItem)sender).Text = "&Stop";
            }
            if (((System.Windows.Forms.MenuItem)sender).Text == "&Close")
            {
                run = false;
            }
        }
    }
}
