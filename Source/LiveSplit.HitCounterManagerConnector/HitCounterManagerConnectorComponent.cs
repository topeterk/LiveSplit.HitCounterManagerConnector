//MIT License

//Copyright (c) 2022-2022 Peter Kirmeier

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.ComponentUtil;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace LiveSplit.HitCounterManagerConnector
{
    public class HitCounterManagerConnectorComponent : LogicComponent
    {
        private LiveSplitState CurrentState;
        public Process RemoteProcess { get; internal set; }

        public HitCounterManagerConnectorComponent(LiveSplitState state)
        {
            Settings.Reconnect += Settings_Reconnect;

            CurrentState = state;
            CurrentState.OnReset += (object sender, TimerPhase value) => State_OnReset(sender, null);
            CurrentState.OnSplit += State_OnSplit;
            CurrentState.OnSkipSplit += State_OnSplit;
            CurrentState.OnUndoSplit += State_OnUndoSplit;
            Connect();
        }

        private void Settings_Reconnect(object sender, EventArgs e) => Connect();

        private void State_OnReset(object sender, EventArgs e) => SendUpdate(SC_Type.SC_Type_Reset);
        private void State_OnSplit(object sender, EventArgs e) => SendUpdate(SC_Type.SC_Type_Split);
        private void State_OnUndoSplit(object sender, EventArgs e) => SendUpdate(SC_Type.SC_Type_SplitPrev);

        private void SendUpdate(SC_Type type)
        {
            Console.WriteLine("PK: " + type.ToString());
            if (null == RemoteProcess) Connect(); // Try to reconnect
            if (null != RemoteProcess) // Reconnected or still connected?
            {
                RemoteProcess.Refresh();
                IntPtr hwnd = IntPtr.Zero;
                try
                {
                    hwnd = RemoteProcess.MainWindowHandle;
                }
                catch // try because process might have just died
                {
                    if (RemoteProcess.HasExited)
                    {
                        RemoteProcess = null;
                        Settings.SetConnectionInfo(RemoteProcess);
                    }
                }

                if (IntPtr.Zero != hwnd) SendMessageW(hwnd, WM_HOTKEY, (IntPtr)type, (IntPtr)0);
            }
        }

        private void Connect()
        {
            Process[] processes = Process.GetProcesses();

            foreach (Process p in processes)
            {
                try
                {
                    if (!p.MainWindowTitle.StartsWith("HitCounterManager")) continue;

                    FileVersionInfo fvi = p.MainModuleWow64Safe().FileVersionInfo;
                    if ((null == fvi.ProductName) || (null == fvi.ProductVersion)) continue;

                    if (fvi.ProductName.Equals("HitCounterManager"))
                    {
                        string[] version = fvi.ProductVersion.Split('.');
                        int MajorVersion;
                        int MinorVersion;
                        if (int.TryParse(version[0], out MajorVersion) &&
                            int.TryParse(version[1], out MinorVersion))
                        if ((2 == MajorVersion) ||
                           ((1 == MajorVersion) && (15 <= MinorVersion))) // We need at least SC_Type_SplitPrev
                        {
                            RemoteProcess = p;
                            Settings.SetConnectionInfo(RemoteProcess);
                            return;
                        }
                    }
                }
                catch { }
            }

            RemoteProcess = null;
            Settings.SetConnectionInfo(RemoteProcess);
        }

        public override string ComponentName => "HitCounterManager Connector";

        private HitCounterManagerConnectorSettings Settings { get; } = new HitCounterManagerConnectorSettings();

        public override void Dispose() { }

        public override Control GetSettingsControl(LayoutMode mode) => Settings;

        public override XmlNode GetSettings(XmlDocument document) => Settings.GetSettings(document);
        public override void SetSettings(XmlNode settings) => Settings.SetSettings(settings);

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) { }

        /// <summary>
        /// Definitions from HitCounterManager
        /// </summary>
        public enum SC_Type
        {
            SC_Type_Reset = 0,
            SC_Type_Hit = 1,
            SC_Type_Split = 2,
            // Since version 1.15:
            SC_Type_HitUndo = 3,
            SC_Type_SplitPrev = 4,
            // Since version 1.17:
            SC_Type_WayHit = 5,
            SC_Type_WayHitUndo = 6,
            SC_Type_PB = 7,
            // Since version 1.20:
            SC_Type_TimerStart = 8,
            SC_Type_TimerStop = 9,
            SC_Type_MAX = 10
        };

        #region Windows API

        // Datatypes: https://docs.microsoft.com/en-us/windows/win32/winprog/windows-data-types

        private const int WM_HOTKEY = 0x0312;

        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessagew
        /// </summary>
        /// <param name="hWnd">HWND = HANDLE = PVOID = void*</param>
        /// <param name="Msg">UINT = unsigned int</param>
        /// <param name="wParam">WPARAM = UINT_PTR = __int64 or long</param>
        /// <param name="lParam">LPARAM = LONG_PTR = __int64 or long</param>
        /// <returns>LRESULT = LONG_PTR = __int64 or long</returns>
        [DllImport("User32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr SendMessageW(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        #endregion
    }
}
