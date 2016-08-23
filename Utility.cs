using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using SevenZip;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace AutoAlogParser
{
    
    class Utility
    {
        private RichTextBox mParserStatusConsole;
        private RichTextBox mJiraStatusConsole;
        private static Utility mUtility = null;

        private Utility()
        {
            //Assembly dll = Assembly.LoadFrom(@"E:\Code\VisualStuidio_Project\AutoAlogParser\AutoAlogParser\bin\Release\lib\SevenZipSharp.dll");
            //var type = dll.GetType("SevenZipSharp.SevenZipExtractor");
            // cls = Activator.CreateInstance(type);
            //var method = type.GetMethod("SetLibraryPath");
            //method.Invoke(cls, new object[] { "lib\\7z.dll" });
            //no implememnt
            //SevenZipExtractor.SetLibraryPath(@"E:\Code\VisualStuidio_Project\AutoAlogParser\AutoAlogParser\lib\7z.dll");
            SevenZipExtractor.SetLibraryPath("7z.dll");
            //SevenZipCompressor.SetLibraryPath(@"E:\Code\VisualStuidio_Project\AutoAlogParser\AutoAlogParser\lib\7z.dll");
            SevenZipCompressor.SetLibraryPath("7z.dll");
        }

        public static Utility getInstance()
        {
            if(mUtility == null)
            {
                mUtility = new Utility();
            }
            return mUtility;
        }
        public void OutputText(string str)
        {
            mParserStatusConsole.Text += str + "\n";
        }

        public void OutputJiraText(string str)
        {
            mJiraStatusConsole.Text += str + "\n";
        }

        public void OutputJiraTextContinue(string str)
        {
            mJiraStatusConsole.Text += str;
        }

        public void setStatusConsole(RichTextBox parserConsole, RichTextBox jiraConsole)
        {
            mParserStatusConsole = parserConsole;
            mJiraStatusConsole = jiraConsole;
        }

        public void clearStatusConsole()
        {
            mParserStatusConsole.Text = "";
        }

        public void clearJiraStatusConsole()
        {
            mJiraStatusConsole.Text = "";
        }

        public void SortStrListDecrease(List<String> lists)//pass by reference
        {
            lists.Sort(delegate (string str1, string str2) { return String.Compare(str2, str1); });
        }

        public void mergeFile(string outFile, List<String>inputList)
        {
            using (var outputStream = File.Create(outFile))
            {
                foreach (var inputFilePath in inputList)
                {
                    //OutputText("[MergeBtn_Click] merger : " + inputFilePath);
                    using (var inputStream = File.OpenRead(inputFilePath))
                    {
                        // Buffer size can be passed as the second argument.
                        inputStream.CopyTo(outputStream);
                    }
                    //Console.WriteLine("The file {0} has been processed.", inputFilePath);
                }
            }
        }

        /*
         * extract all the compress files in specific directory(sourcePath) and output to targetPath
         */
        public void ExtractCompressFilesInDir(string sourcePath, string targetPath)
        {
            string[] files = Directory.GetFiles(sourcePath);
            foreach (string file in files)
            {
                if(file.ToLower().EndsWith("zip") || file.ToLower().EndsWith("7z") || file.ToLower().EndsWith("rar") || file.ToLower().EndsWith("7z.001"))
                {
                    ExtractArchive(file, targetPath);
                }
            }
        }

        /*
         * extract single file
         */
        public void ExtractArchive(string source, string target)
        {
            using (var file = new SevenZipExtractor(source))
            {
                file.ExtractArchive(target);
            }
        }

        public void CreateFolder(string folder)
        {
            try {
                if (Directory.Exists(folder))
                {
                    return;
                }
                DirectoryInfo info = Directory.CreateDirectory(folder);
            }
            catch (Exception ex)
            {
                OutputJiraText("Create Folder " + folder + " failed. ex = " + ex.Message);
                OutputText("Create Folder " + folder + " failed. ex = " + ex.Message);
            }
        }

        public bool isEmptyDirectory(string path)
        {
            if (0 == GetSubDirCount(path) && 0 == GetSubFileCount(path)) return true;
            return false;
        }

        public int GetSubDirCount(string path)
        {
            int count = 0;
            if (Directory.Exists(path))
            {
                count = Directory.GetDirectories(path).Length;
            }
            Trace.WriteLine("[GetSubDirCount] count = "+count);
            return count;
        }

        public int GetSubFileCount(string path)
        {
            int count = 0;
            if (Directory.Exists(path))
            {
                count = Directory.GetFiles(path).Length;
            }
            Trace.WriteLine("[GetSubFileCount] count = " + count);
            return count;
        }
    }
}
