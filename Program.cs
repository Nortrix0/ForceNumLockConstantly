﻿namespace ForceNumLockConstantly
{
    class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        //static System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon
        //{
        //    Icon = Properties.Resources.Numlock,
        //    Visible = true,
        //    Text = "Force Numlock",
        //    ContextMenu = new System.Windows.Forms.ContextMenu(new System.Windows.Forms.MenuItem[] { new System.Windows.Forms.MenuItem("&Stop", MenuItemClick), new System.Windows.Forms.MenuItem("&Close", (sender, e) => { ni.Visible = false; System.Windows.Forms.Application.Exit(); }) })
        //};
        //static System.Timers.Timer timer = new System.Timers.Timer
        //{
        //    Interval = 10,
        //    AutoReset = true,
        //    Enabled = true
        //};
        static void Main()
        {
            System.Timers.Timer timer = new System.Timers.Timer { Interval = 10, AutoReset = true, Enabled = true };
            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon { Icon = Properties.Resources.Numlock, Visible = true, Text = "Force Numlock" };
            ni.ContextMenu = new System.Windows.Forms.ContextMenu(new System.Windows.Forms.MenuItem[] { new System.Windows.Forms.MenuItem("&Stop", (sender, e) => { if (((System.Windows.Forms.MenuItem)sender).Text == "&Stop") { timer.Stop(); ((System.Windows.Forms.MenuItem)sender).Text = "&Start"; } else { timer.Start(); ((System.Windows.Forms.MenuItem)sender).Text = "&Stop"; } }), new System.Windows.Forms.MenuItem("&Close", (sender, e) => { ni.Dispose(); System.Windows.Forms.Application.Exit(); }) });
            timer.Elapsed += (sender, e) => { if (!System.Windows.Forms.Control.IsKeyLocked(System.Windows.Forms.Keys.NumLock)){ keybd_event(144, 0x45, 0x1, 0); keybd_event(144, 0x45, 0x1 | 0x2, 0); } };
            System.Windows.Forms.Application.Run();
        }
        //static void CheckNumlock(object sender, System.EventArgs e)
        //{
        //    if (!System.Windows.Forms.Control.IsKeyLocked(System.Windows.Forms.Keys.NumLock))
        //    {
        //        keybd_event(144, 0x45, 0x1, 0);
        //        keybd_event(144, 0x45, 0x1 | 0x2, 0);
        //    }
        //}
        //static void MenuItemClick(object sender, System.EventArgs e)
        //{
        //    if (((System.Windows.Forms.MenuItem)sender).Text == "&Stop")
        //    {
        //        timer.Stop();
        //        ((System.Windows.Forms.MenuItem)sender).Text = "&Start";
        //    }
        //    else if (((System.Windows.Forms.MenuItem)sender).Text == "&Start")
        //    {
        //        timer.Start();
        //        ((System.Windows.Forms.MenuItem)sender).Text = "&Stop";
        //    }
        //}
        //{
        //    if (((System.Windows.Forms.MenuItem)sender).Text == "&Stop"){ timer.Stop(); ((System.Windows.Forms.MenuItem)sender).Text = "&Start"; } else { timer.Start(); ((System.Windows.Forms.MenuItem)sender).Text = "&Stop"; }
    }
}
