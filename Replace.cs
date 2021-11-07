using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ReplaceString
{
    public class Replace
    {
        public string path { get; set; }
        public string Folder { get; set; }
        public string What { get; set; }
        public string WhatType { get; set; }
        public string StartWith { get; set; }
        public string EndWith { get; set; }
        public string ReplaceWith { get; set; }
        public int Instance { get; set; }
        public string Description { get; set; }
        public string replace(string input, string what, string replaceWith)
        {
            return Regex.Replace(input, what, replaceWith);
        }
        public string replace(string input, string what, MatchEvaluator matchEvalotar)
        {
            return Regex.Replace(input, what, matchEvalotar);
        }
        public string replaceFilesInFolder(Boolean Isdry)
        {
            var outPut = "";
            var items = findFilesInFolderByExtension();
            foreach (var file in items) {
                outPut+=replaceFile(Isdry,file);
            }
            return outPut;
        }
        public string[] findFilesInFolderByExtension()
        {
           return Directory.GetFiles(Folder,path);
        }
        public string replaceAll(Boolean Isdry)
        {
            if (Path.GetFileNameWithoutExtension(path) == "*") return replaceFilesInFolder(Isdry);
            else return replaceFile(Isdry, Folder+@"\"+path); 
        }
        public string replaceFile(Boolean Isdry,string filePath)
        {
            try
            {
                string fileText, fileChanges;
                fileText = fileChanges = MyFile.readFile(filePath);
                string pattern = "";
                int x = 0;

                pattern = (WhatType == "string") ? pattern = What :
                    pattern = "(" + StartWith + ").*(" + EndWith + ")";

                fileChanges = (Instance == 0) ?
                       replace(fileChanges, pattern, ReplaceWith) :
                        replace(fileChanges, pattern, instace => (++x) == Instance ? ReplaceWith : instace.Value);

                if (fileChanges == fileText)
                    return "Didn't find instance to replace";

                if (Isdry)
                    return "found " + Description;

                MyFile.writeFile(filePath, fileChanges);
                return "change " + Description;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
