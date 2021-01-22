
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
        public bool IsFile { get; private set; }

        public SLogFileInfo(string inFilePath, bool inIsFile)
        {
            FilePath = inFilePath;
            IsFile = inIsFile;
        }

        public override string ToString()
        {
            if(IsFile)
                return Path.GetFileName(FilePath);
            return $"-- {FilePath} --";
        }
    }
}
