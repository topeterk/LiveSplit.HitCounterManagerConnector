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
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.UI;

namespace LiveSplit.HitCounterManagerConnector
{
    public partial class HitCounterManagerConnectorSettings : UserControl
    {

        public HitCounterManagerConnectorSettings()
        {
            InitializeComponent();
            txtVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            SettingsHelper.CreateSetting(document, parent, "Version", "0.0");
            return parent;
        }

        public void SetSettings(XmlNode node) { }

        public void SetConnectionInfo(Process process)
        {
            string text;

            if (null == process)
                text = "<Disconnected>";
            else
            {
                try
                {
                    text = "[" + process.Id.ToString() + "]  " + process.MainWindowTitle;
                }
                catch
                {
                    text = "<Cannot resolve process name>";
                }
            }

            if (InvokeRequired)
                this.Invoke(new Action<string>(SetConnectionName), new object[] { text });
            else
                SetConnectionName(text);
        }

        private void SetConnectionName(string Name) => txtConnected.Text = Name;

        public event EventHandler Reconnect;
        private void btnReconnect_Click(object sender, EventArgs e) => Reconnect?.Invoke(sender, e);
    }
}
