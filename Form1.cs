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

        public Form1()
        {
            InitializeComponent();
            _serializer = new CascadeSerializer.CCascadeSerializer(this);

            string setting_file = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), SettingFileName);
            if (!File.Exists(setting_file))
            {
                using (StreamWriter writer = File.CreateText(setting_file))
                {

                    _settings = new Settings();
                    string text = _serializer.SerializeToCascade(_settings, this);
                    writer.Write(text);
                }
            }
            else
            {
                using (StreamReader reader = File.OpenText(setting_file))
                    _settings = _serializer.Deserialize<Settings>(reader.ReadToEnd(), this);
            }
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
    }
}
