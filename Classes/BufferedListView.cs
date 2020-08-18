using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

class BufferedListView : ListView
{
    public BufferedListView()
    {
        //Activate double buffering
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

        //Enable the OnNotifyMessage event so we get a chance to filter out 
        // Windows messages before they get to the form's WndProc
        this.SetStyle(ControlStyles.EnableNotifyMessage, true);
    }

    protected override void OnNotifyMessage(Message m)
    {
        //Filter out the WM_ERASEBKGND message
        if (m.Msg != 0x14)
        {
            base.OnNotifyMessage(m);
        }
    }

    //public Control LinkedListView { get; set; }

    //private static bool scrolling;   // In case buddy tries to scroll us

    //protected override void WndProc(ref Message m)
    //{
    //    base.WndProc(ref m);
    //    // Trap WM_VSCROLL message and pass to buddy
    //    if ((m.Msg == 0x115 || m.Msg == 0x20a) && !scrolling && LinkedListView != null && LinkedListView.IsHandleCreated)
    //    {
    //        scrolling = true;
    //        SendMessage(LinkedListView.Handle, m.Msg, m.WParam, m.LParam);
    //        scrolling = false;
    //    }
    //}

    //[DllImport("user32.dll", CharSet = CharSet.Auto)]
    //private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
}