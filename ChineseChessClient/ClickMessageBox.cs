using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseChessClient
{
    class ClickMessageBox
    {
        // A delegate which is used by EnumChildWindows to execute a callback method.
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        // This method accepts a string which represents the title name of the window you're looking for the controls on.
        public static void ClickButtonLabeledNo(string windowTitle)
        {
            try
            {
                // Find the main window's handle by the title.
                var windowHWnd = FindWindowByCaption(IntPtr.Zero, windowTitle);

                // Loop though the child windows, and execute the EnumChildWindowsCallback method
                EnumChildWindows(windowHWnd, EnumChildWindowsCallback, IntPtr.Zero);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private static bool EnumChildWindowsCallback(IntPtr handle, IntPtr pointer)
        {
            const uint WM_LBUTTONDOWN = 0x0201;
            const uint WM_LBUTTONUP = 0x0202;

            var sb = new StringBuilder(256);
            // Get the control's text.
            GetWindowCaption(handle, sb, 256);
            var text = sb.ToString();

            // If the text on the control == &No send a left mouse click to the handle.
            if (text == @"否(&N)")
            {
                PostMessage(handle, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
                PostMessage(handle, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
            }

            return true;
        }

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "GetWindowText", CharSet = CharSet.Auto)]
        private static extern IntPtr GetWindowCaption(IntPtr hwnd, StringBuilder lpString, int maxCount);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    }
}
