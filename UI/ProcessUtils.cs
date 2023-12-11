using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FormUI
{
    public static class ProcessUtils
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        static extern IntPtr GetLastActivePopup(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool IsWindowEnabled(IntPtr hWnd);


        public static void SetFocusToPreviousInstance(string windowCaption)
        {

            try
            {
                IntPtr hWnd = FindWindow(null, windowCaption);


                if (hWnd != null)
                {

                    IntPtr hPopupWnd = GetLastActivePopup(hWnd);

                    if (hPopupWnd != null && IsWindowEnabled(hPopupWnd))
                    {
                        hWnd = hPopupWnd;
                    }

                    SetForegroundWindow(hWnd);


                    if (IsIconic(hWnd))
                    {
                        ShowWindow(hWnd, SW_RESTORE);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
