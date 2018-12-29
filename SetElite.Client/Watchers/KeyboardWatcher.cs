using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace SetElite.Client.Watchers
{
    public class KeyboardWatcher
    {
        private const int WhKeyboardLl = 13;
        private const int WmKeydown = 0x0100;
        private static readonly LowLevelKeyboardProc Proc = HookCallback;
        private static IntPtr _hookId;


        public KeyboardWatcher()
        {
            _hookId = SetHook(Proc);
        }
        ~KeyboardWatcher()
        {
            UnhookWindowsHookEx(_hookId);
        }


        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0 || wParam != (IntPtr)WmKeydown)
                return CallNextHookEx(_hookId, nCode, wParam, lParam);

            var isKeyDown1 = Keyboard.IsKeyDown(Key.Scroll);
            var isKeyDown2 = Keyboard.IsKeyDown(Key.Pause);

            if (!isKeyDown2) return CallNextHookEx(_hookId, nCode, wParam, lParam);
            if (!isKeyDown1)
            {
                LockWorkStation();
            }
            else
            {
                ExitWindowsEx(0, 0);
            }

            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }


        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WhKeyboardLl, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        #region hook
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion
        #region LogOff
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int ExitWindowsEx(uint uFlags, uint dwReason);
        #endregion
        #region LockWorkstation
        [DllImport("user32", SetLastError = true)]
        private static extern void LockWorkStation();
        #endregion
    }
}
