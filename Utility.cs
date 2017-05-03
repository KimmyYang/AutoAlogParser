using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using SevenZip;
using System.Diagnostics;
using System.IO.Compression;

namespace AutoAlogParser
{
    
    class Utility
    {
        private RichTextBox mParserStatusConsole;
        private RichTextBox mJiraStatusConsole;
        private static Utility mUtility = null;

        private Utility()
        {
            SevenZipExtractor.SetLibraryPath("7z.dll");
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
                    Trace.WriteLine("inputFilePath " + inputFilePath);
                    using (var inputStream = File.OpenRead(inputFilePath))
                    {
                        /*string fileContents;
                        using (StreamReader reader = new StreamReader(inputStream))
                        {
                            fileContents = reader.ReadToEnd();
                            Trace.WriteLine("str : " + fileContents);
                        }*/

                        // Buffer size can be passed as the second argument.
                        inputStream.CopyTo(outputStream);
                    }
                    //Console.WriteLine("The file {0} has been processed.", inputFilePath);
                }
            }
        }

        /*
         * extract all the compress files in specific directory(sourcePath) and output to targetPath
         * ex. source : rootFolder/subFolder1/subFolder2/file.zip
         *     target : rootFolder/subFolder1/subFolder2/file/file.txt
         */
        public void ExtractCompressFilesInDir(string sourcePath, string targetPath)
        {
            //Trace.WriteLine("ExtractCompressFilesInDir: sourcePath = " + sourcePath + " targetPath = " + targetPath);
            string[] files = Directory.GetFiles(sourcePath);
            foreach (string file in files)
            {
                if(isZipFile(file))
                {
                    Trace.WriteLine("ExtractCompressFilesInDir: file = " + file);
                    ExtractArchive(file, targetPath==null? getTargetFolder(file) : targetPath);
                }
            }
        }

        /*
         * call when extract file only
         * create the extract target folder
         * source : rootFolder/File.zip
         * target : File
        */
        private string getTargetFolder(string source)
        {
            string rootFolder = String.Empty;
            string targetFolder = source;
            try {
                string[] strs = splitString(source, '\\'); //ex. rootFolder\File.zip
                if (strs.Length >= 2)
                {//has rootFolder
                    rootFolder = splitString(source, strs[strs.Length - 1])[0]; //ex. rootFolder\
                    strs = splitString(strs[strs.Length - 1], '.');
                }
                else
                {//no rootFolder
                    strs = splitString(source, '.');
                }
                if (strs.Length > 0) targetFolder = strs[0];
                targetFolder = rootFolder != String.Empty ? rootFolder + targetFolder : targetFolder;

                //Trace.WriteLine("[getTargetFolder] source = " + source);
                //Trace.WriteLine("[getTargetFolder] rootFolder = " + rootFolder);
                Trace.WriteLine("[getTargetFolder] targetFolder = " + targetFolder);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[getTargetFolder] ex = " + ex.Message);
            }
            return targetFolder;
        }

        /*
         * extract single file to directory
         * source : Compress File
         * target : dest folder
         */
        public void ExtractArchive(string source, string target)
        {
            try
            {
                //Trace.WriteLine("ExtractArchive: source =  " + source + " target = " + target);
                if (!Directory.Exists(target))
                {
                    CreateFolder(target);
                    using (var file = new SevenZipExtractor(source))
                    {
                        file.ExtractArchive(target);
                    }
                }
            }
            catch (Exception ex)
            {
                OutputJiraText("[ExtractArchive] ex = " + ex.Message);
                OutputText("[ExtractArchive] ex = " + ex.Message);
            }
        }

        public void ExtractGzArchive(string source)
        {
            GZipStream decompressFile = null;
            try
            {
                //Trace.WriteLine("ExtractGzArchive: source =  " + source + " target = " + target);
                FileStream orgFS = File.OpenRead(source);
                //string extention = Path.GetExtension(source);
                //string target = source.Substring(0, source.Length - extention.Length);
                string target = filterExtention(source);
                FileStream newFS = File.Create(target);
                Trace.WriteLine("ExtractGzArchive: source =  " + source + " target = " + target);
                using (decompressFile = new GZipStream(orgFS, System.IO.Compression.CompressionMode.Decompress))
                {
                    decompressFile.CopyTo(newFS);
                    orgFS.Close(); newFS.Close();
                }
            }
            catch (Exception ex)
            {
                //OutputJiraText("ExtractGzArchive: ex = " + ex.Message);
                //OutputText("ExtractGzArchive: ex = " + ex.Message);
                Trace.WriteLine("ExtractGzArchive: ex = " + ex.Message);
            }
            finally
            {
                if(decompressFile!=null)decompressFile.Close();
            }
        }

        private string getExtractFileName(string source)
        {
            string[] strs = splitString(source, '\\');
            if (strs.Length >= 2)
            {
                if (isZipFile(strs[1])){
                    strs = splitString(strs[1], '.');
                    source = strs[0];
                }
            }
            return source;
        }

        private bool isZipFile(string file)
        {
            if (file.ToLower().EndsWith("zip") || file.ToLower().EndsWith("7z") ||
                file.ToLower().EndsWith("rar") || file.ToLower().EndsWith("7z.001"))
            {
                return true;
            }
            return false;
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

        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            try {
                // Unix timestamp is seconds past epoch
                dateTime = dateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            }catch(Exception ex)
            {
                Trace.WriteLine("UnixTimeStampToDateTime: ex = " + ex);
            }
            return dateTime;
        }

        public string filterExtention(string fileName)
        {
            string extention = Path.GetExtension(fileName);
            return fileName.Substring(0, fileName.Length - extention.Length);
        }

        //string related
        public string[] splitString(string str, char delim)
        {
            string[] strs = str.Split(delim);
            return strs;
        }

        private string[] splitString(string str, string delim)
        {
            string[] strs = str.Split(new string[] { delim }, StringSplitOptions.None);
            return strs;
        }
    }
}
