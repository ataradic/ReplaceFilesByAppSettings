using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReplaceString
{
    class MyFile
    {
        public static string readFile(string path)
        {
            if (!File.Exists(path))
                throw new Exception("File doesn't exixt");
            return File.ReadAllText(path);
        }

        public static void writeFile(string path, string text)
        {
            if (!File.Exists(path))
                throw new Exception("File doesn't exixt");
            File.WriteAllText(path, text);
        }
    }
}
