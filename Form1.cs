using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogReader
{
    public partial class Form1 : Form, CascadeParser.IParserOwner, CascadeParser.ILogPrinter
    {
        const string SettingFileName = "Settings.txt";
        Settings _settings;

        CascadeSerializer.CCascadeSerializer _serializer;

        List<CLogString> _log_strings = new List<CLogString>();

        IFilter _filter;

        int _line_range1 = -1;
        int _line_range2 = -1;

        public Form1()
        {
            InitializeComponent();
            _serializer = new CascadeSerializer.CCascadeSerializer(this);
        }

        #region LogWindow Output
        void AddLogToRichText(string inText, Color inClr)
        {
            if (m_uiLogLinesCount > 1000)
                ClearLog();

            int length = rtLog.TextLength;  // at end of text
            rtLog.AppendText(inText);
            rtLog.SelectionStart = length;
            rtLog.SelectionLength = inText.Length;
            rtLog.SelectionColor = inClr;
            rtLog.SelectionStart = rtLog.TextLength;
            rtLog.SelectionLength = 0;
        }

        void ClearLog()
        {
            rtLog.Text = string.Empty;
            m_uiLogLinesCount = 0;
        }

        uint m_uiLogLinesCount = 0;
        public void AddLogToConsole(string inText, Color inClr)
        {
            if (rtLog.IsDisposed)
                return;

            string sres = string.Format("{0}: {1}{2}", m_uiLogLinesCount.ToString(), inText, Environment.NewLine);
            rtLog.BeginInvoke(new Action<string>(s => AddLogToRichText(s, inClr)), sres);
            m_uiLogLinesCount++;
        }

        public void AddLogToConsole(string inText, ELogLevel inLogLevel)
        {
            if (rtLog.IsDisposed)
                return;

            string sres = string.Format("{0}: {1}{2}", m_uiLogLinesCount.ToString(), inText, Environment.NewLine);

            Color clr = Color.Black;
            switch (inLogLevel)
            {
                case ELogLevel.Info: clr = Color.Black; break;
                case ELogLevel.Warning: clr = Color.Brown; break;
                case ELogLevel.Error: clr = Color.Red; break;
            }

            //tbLog.BeginInvoke(new Action<string>(s => tbLog.AppendText(s)), sres);
            rtLog.BeginInvoke(new Action<string>(s => AddLogToRichText(s, clr)), sres);
            m_uiLogLinesCount++;
        }

        #endregion //LogWindow Output

        #region CascadeParser Interfaces
        public string GetTextFromFile(string inFileName, object inContextData)
        {
            throw new NotImplementedException();
        }

        public void LogError(string inText)
        {
            AddLogToConsole(inText, ELogLevel.Error);
        }

        public void LogWarning(string inText)
        {
            AddLogToConsole(inText, ELogLevel.Warning);
        }

        public void Trace(string inText)
        {
            AddLogToConsole(inText, ELogLevel.Info);
        }
        #endregion //CascadeParser Interfaces

        private void Form1_Load(object sender, EventArgs e)
        {
            string setting_file = GetSettingFilePath();
            if (!File.Exists(setting_file))
            {
                _settings = new Settings();
                SaveSettings();
            }
            else
            {
                using (StreamReader reader = File.OpenText(setting_file))
                {
                    string text = reader.ReadToEnd();
                    _settings = _serializer.Deserialize<Settings>(text, this);
                    Trace("Read Settings:");
                    Trace(text);
                    OnSettingChange();
                }
            }
        }

        string GetSettingFilePath() { return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), SettingFileName); }

        void SaveSettings()
        {
            string setting_file = GetSettingFilePath();
            using (StreamWriter writer = File.CreateText(setting_file))
            {
                string text = _serializer.SerializeToCascade(_settings, this);
                writer.Write(text);
            }
        }

        private void OnSettingChange()
        {
            lbFindFolders.BeginInvoke(new Action(() =>
            {
                lbFindFolders.Items.AddRange(_settings.LogFolders.ToArray());
            }));

            cbLogFile.BeginInvoke(new Action(() =>
            {
                cbLogFile.Items.Clear();

                foreach (string path in _settings.LogFolders)
                {
                    string[] files = Directory.GetFiles(path, "*.log");

                    foreach (string fl in files)
                    {
                        cbLogFile.Items.Add(new SLogFileInfo(fl));
                    }
                }

                if (cbLogFile.Items.Count > 0)
                    cbLogFile.SelectedIndex = 0;
            }));

            lbClearKeys.BeginInvoke(new Action(() =>
            {
                foreach (string f in _settings.Filters)
                {
                    lbClearKeys.Items.Add(f);
                }
            }));
        }

        private void cbLogFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadSelectFile();
        }

        private void btnAddFindFolders_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog1.SelectedPath = Path.GetDirectoryName(Application.ExecutablePath);
            FolderBrowserDialog1.ShowNewFolderButton = false;

            DialogResult res = FolderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                Trace(FolderBrowserDialog1.SelectedPath);
                _settings.LogFolders.Add(FolderBrowserDialog1.SelectedPath);
                SaveSettings();
                OnSettingChange();
            }
        }

        private void ReadSelectFile()
        {
            _log_strings.Clear();
            SLogFileInfo sfi = (SLogFileInfo)cbLogFile.SelectedItem;
            Trace($"Begin read {sfi.FilePath}");
            using (StreamReader reader = File.OpenText(sfi.FilePath))
            {
                int ln = 1;
                string line = reader.ReadLine();
                while(line != null)
                {
                    var ls = new CLogString(line, ln);
                    _log_strings.Add(ls);

                    line = reader.ReadLine();
                    ln++;
                }

                OutputText();
            }
            Trace($"End read {sfi.FilePath}");
        }

        private void OutputText()
        {
            Trace($"Begin output text");
            var sb = new StringBuilder();
            foreach(CLogString ls in _log_strings)
            {
                if (_line_range1 != -1 && ls.LineNumber < _line_range1)
                    continue;
                if (_line_range2 != -1 && ls.LineNumber > _line_range2)
                    continue;

                if (_filter != null && !_filter.Access(ls.Text))
                    continue;

                sb.AppendLine(ls.ToString());
            }

            rtbContent.Text = sb.ToString();
            Trace($"End output text");
        }

        private void btnAddFilter_Click_1(object sender, EventArgs e)
        {
            string text = rtbFilter.Text;
            if (string.IsNullOrEmpty(text))
                return;

            if(!_settings.Filters.Contains(text))
            {
                _settings.Filters.Add(text);
                SaveSettings();
                lbClearKeys.Items.Add(text);
            }

            _filter = CFilterFactory.Create(text);
            if(_filter == null)
            {
                LogError("Can't parse filter!");
            }
            else
            {
                Trace("Apply filter!");
            }

            OutputText();
        }

        private void lbClearKeys_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string text = lbClearKeys.SelectedItem as string;
            if (string.IsNullOrEmpty(text))
                return;

            rtbFilter.Text = text;
            _filter = CFilterFactory.Create(text);
            if (_filter == null)
            {
                LogError("Can't parse filter!");
            }
            else
            {
                Trace("Apply filter!");
            }
            OutputText();
        }

        private void lbClearKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = lbClearKeys.SelectedItem as string;
            if (string.IsNullOrEmpty(text))
                return;

            rtbFilter.Text = text;
        }

        private void lbClearKeys_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'd' && lbClearKeys.SelectedIndex >= 0)
            {
                string text = lbClearKeys.SelectedItem as string;
                _settings.Filters.Remove(text);
                SaveSettings();
                lbClearKeys.Items.RemoveAt(lbClearKeys.SelectedIndex);
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            _filter = null;
            rtbFilter.Text = string.Empty;
            Trace("Clear filter!");
            OutputText();
        }

        private void btnLnNumRange_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbLnNum1.Text, out _line_range1))
                _line_range1 = -1;
            if (!int.TryParse(tbLnNum2.Text, out _line_range2))
                _line_range2 = -1;

            Trace($"Set line_range1 {_line_range1}; line_range2 {_line_range2}");
            OutputText();
        }
    }
}
