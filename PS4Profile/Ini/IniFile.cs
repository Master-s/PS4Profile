using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace PS4Profile.Ini
{
	public class IniFile
	{

		public IniFile(string IniPath)
		{
			this.Path = new FileInfo(IniPath + ".ini").FullName.ToString();
		}


		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


		public string Read(string Section, string Key)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			int privateProfileString = IniFile.GetPrivateProfileString(Section, Key, "", stringBuilder, 255, this.Path);
			return stringBuilder.ToString();
		}


		public void Write(string Section, string Key, string Value)
		{
			IniFile.WritePrivateProfileString(Section, Key, Value, this.Path);
		}


		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);


		public string Path;
	}
}
