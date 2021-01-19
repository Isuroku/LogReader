
using System.Collections.Generic;
using System.IO;

namespace LogReader
{
    class Settings
    {
        public List<string> LogFolders;
        public List<string> Filters;

        public Settings()
        {
            LogFolders = new List<string>();
            Filters = new List<string>();
        }
    }

    struct SLogFileInfo
    {
        public string FilePath { get; private set; }

        public SLogFileInfo(string inFilePath)
        {
            FilePath = inFilePath;
        }

        public override string ToString()
        {
            return Path.GetFileName(FilePath);
        }
    }
}
