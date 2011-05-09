namespace AutoUpdater
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class IniFiles
    {
        public string path;

        public IniFiles(string INIPath)
        {
            this.path = INIPath;
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public string IniReadvalue(string Section, string Key)
        {
            StringBuilder retVal = new StringBuilder(0xff);
            GetPrivateProfileString(Section, Key, "", retVal, 0xff, this.path);
            return retVal.ToString();
        }

        public void IniWritevalue(string Section, string Key, string value)
        {
            WritePrivateProfileString(Section, Key, value, this.path);
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    }
}

