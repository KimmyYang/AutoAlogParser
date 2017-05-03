using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace AutoAlogParser
{
    public partial class AlogParser
    {
        private Boolean DBG = true;
        private Boolean VDBG = false;
        
        private static Utility mUtility = null;
        private static JiraHandler mJirHandler = null;
        private List<String> mAlogList = new List<String>();
        private List<String> mAlogRadioList = new List<String>();
        private AlogParserAdapter mAdapter = null;

        private void initAlogAdapter()
        {
            mAdapter = AlogParserAdapter.getAlogParserAdapter();
        }

        private void initUtility()
        {
            mUtility = Utility.getInstance();
            mUtility.setStatusConsole(mParserStatusConsole, mJiraStatusConsole);
        }

        private void initJiraHandler()
        {
            if (mJirHandler == null)
            {
                mJirHandler = JiraHandler.getInstance();
                mJirHandler.initTextInfo(mUserNameText, mPasswordText, mIssueFilterText, mJiraBaiscText, mJiraCondtionText, mIssueKeyText);
                mJirHandler.setParser(this);
            }
        }

        private string loadDropboxSelection()
        {
            string strArguments = String.Empty;
            //anr
            if (mParserAnrCheckBox.Checked)
            {
                strArguments += " -anr ";
            }
            //crash
            if (mParserCrashCheckBox.Checked)
            {
                strArguments += " -crash ";
            }
            return strArguments;
        }

        private string loadUserSelection()
        {
            string strArguments = String.Empty;
            string outputArguments = String.Empty;

            if (mTimeFilterCheckBox.Checked && (mStartTimeText.Text != String.Empty || mEndTimeText.Text != String.Empty))
            {
                if (mStartTimeText.Text != String.Empty && mEndTimeText.Text == String.Empty)
                {
                    mEndTimeText.Text = mStartTimeText.Text;
                }
                else if (mStartTimeText.Text == String.Empty && mEndTimeText.Text != String.Empty)
                {
                    mStartTimeText.Text = mEndTimeText.Text;
                }
                strArguments = "-st " + mStartTimeText.Text + " -et " + mEndTimeText.Text;
                outputArguments = mTimeFilterCheckBox.Text + ":" + mStartTimeText.Text + "~" + mEndTimeText.Text + "\n";
            }

            if (mPIDFilterCheckBox.Checked)
            {
                if (mPIDText.Text != String.Empty)
                {
                    strArguments += " -p " + mPIDText.Text;
                    outputArguments += mPIDFilterCheckBox.Text + ":" + mPIDText.Text + "\n";
                }
            }
            if (mTIDFilterCheckBox.Checked)
            {
                if (mTIDText.Text != String.Empty)
                {
                    strArguments += " -t " + mTIDText.Text;
                    outputArguments += mTIDFilterCheckBox.Text + ":" + mTIDText.Text + "\n";
                }
            }
            if (mTagFilterCheckBox.Checked)
            {
                //1st proiorty
                if (mTagProfileText.Text != String.Empty)
                {
                    strArguments += " -sp " + mTagProfileText.Text;
                    outputArguments += mTagFilterCheckBox.Text + ":" + mTagProfileText.Text + "\n";
                }
                else  if (mTagText.Text != null && mTagText.Text != "")
                {
                    strArguments += " -s " + mTagText.Text;
                    outputArguments += mTagFilterCheckBox.Text + ":" + mTagText.Text + "\n";
                }
            }
            if (mContentFilterCheckBox.Checked && mContentText.Text != String.Empty)
            {
                strArguments += " -c " + mContentText.Text;
                outputArguments += mContentProfileCheckBox.Text + ":" + mContentText.Text + "\n";

            }else if(mContentProfileCheckBox.Checked && mContentText.Text != String.Empty)//profile
            {
                strArguments += " -cp " + mContentText.Text;
                outputArguments += mContentProfileCheckBox.Text + ":" + mContentText.Text + "\n";
            }

            //condition
            //"-or" worked when tag and content are all checked
            if (mOrCheckBox.Checked && mTagFilterCheckBox.Checked && mContentProfileCheckBox.Checked)
            {
                strArguments += " -or";
                outputArguments += " -or";
            }
            //if (outputArguments != String.Empty) mUtility.OutputText(outputArguments);
            return strArguments;
        }

        public void Parser(string file)
        {
            /*chose log or dropbox log*/
            string userSelection = loadDropboxSelection();
            if(userSelection != String.Empty)
            {
                ParserDropboxLog(file, userSelection);
            }else{
                ParserLog(file, loadUserSelection());
            }
        }

        private void ParserLog(string file, string userSelection)
        {
            if (file == String.Empty || userSelection == String.Empty)
            {
                String str = "No Input File or User Selection. Can't Parser.";
                Trace.WriteLine(str);
                mUtility.OutputText(str);
                return;
            }
            int result = mAdapter.Parser(file, userSelection);

            if (result == 0)
            {
                mUtility.OutputText("Parser Done.");
            }
            else
            {
                mUtility.OutputText("Parser Error : " + result);
            }
        }

        private void ParserDropboxLog(string path, string selection)
        {
            extractDropBoxLog(path, selection);
            var packageName = getPackageList(path, selection);
            String str  = String.Empty;
            if(packageName.Count > 0)
            {
                foreach(string name in packageName)
                {
                    str += name + "\n";
                }
            }else{
                str = "Can't Parser the Dropbox Log. " + selection;
            }
            mUtility.OutputText(str);
        }

        private List<string> getPackageList(string path, string selection)
        {
            var packageName = new List<string>();
            foreach (string file in Directory.EnumerateFiles(path, "*.txt"))
            {
                if ((selection.IndexOf("anr") > 0 && file.IndexOf("system_app_anr") > 0) ||
                    (selection.IndexOf("crash") > 0 && file.IndexOf("system_app_crash") > 0))
                {
                    const Int32 BufferSize = 128;
                    using (var fileStream = File.OpenRead(file))
                    {
                        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                        {
                            String line;
                            while ((line = streamReader.ReadLine()) != null)
                            {
                                string[] tokens = mUtility.splitString(line, ':');
                                if (tokens.Length >= 2 && tokens[0] == "Process")
                                {
                                    string fileName = Path.GetFileName(file);
                                    string date = getTimeFromDroboxLog(fileName);
                                    packageName.Add(fileName + " ("+ date+") : " +tokens[1]);
                                }
                                break;
                            }
                            streamReader.Close();
                        }
                        fileStream.Close();
                    }
                }
            }
            return packageName;
        }

        private string getTimeFromDroboxLog(string fileName)
        {
            string[] tokens = mUtility.splitString(fileName, '@');
            if(tokens!=null && tokens.Length == 2)
            {
                tokens[1] = mUtility.filterExtention(tokens[1]);
                //Trace.WriteLine("tokens[1] = " + tokens[1]);
                DateTime date =  mUtility.UnixTimeStampToDateTime(Convert.ToDouble(tokens[1]));
                return date.ToString("yyyy-MM-dd HH:mm:ss");
            }
            return "No Time";
        }

        private void extractDropBoxLog(string path, string selection)
        {
            if (path == String.Empty)
            {
                mUtility.OutputText("No Input Path.");
                return;
            }
            foreach (string file in Directory.EnumerateFiles(path, "*.gz"))
            {
                if ((selection.IndexOf("anr") > 0 && file.IndexOf("system_app_anr") > 0) ||
                    (selection.IndexOf("crash") > 0 && file.IndexOf("system_app_crash") > 0))
                {
                    mUtility.ExtractGzArchive(file);
                    //mUtility.OutputText(file);
                }
            }
        }

        public void Merge(string path)
        {
            if(path == String.Empty)
            {
                mUtility.OutputText("No file can merge. Please choose the input directory ..");
                return;
            }
            mAlogList.Clear();
            mAlogRadioList.Clear();
            if (DBG) mUtility.OutputText("Start to Merge File in Path : " + path);
            foreach (string file in Directory.EnumerateFiles(path, "*"))
            {
                if (VDBG)
                {
                    mUtility.OutputText("merge file = " + file);
                }
                if (file.IndexOf("system") > 0 || file.IndexOf("event") > 0 ||
                      file.IndexOf("filelist") > 0 || file.IndexOf("alog_merge") > 0 ||
                      file.IndexOf("alog_radio_merge") > 0)
                {
                    continue;
                }
                else if (file.IndexOf("radio") > 0)
                {
                    mAlogRadioList.Add(file);
                }
                else//main log
                {
                    mAlogList.Add(file);
                }
            }
            Trace.WriteLine("mAlogList size " + mAlogList.Count);
            mergeAlog(path);
            mergeAlogRadio(path);
            mUtility.OutputText("Merge Done.");
        }

        private void mergeAlogRadio(string path)
        {
            mUtility.SortStrListDecrease(mAlogRadioList);
            //moveLog(mAlogRadioList, "alog_radio", 0);
            string outputAlogFile = path;
            string outputRadioFile;
            char lastChar = outputAlogFile[outputAlogFile.Length - 1];

            if (lastChar != '\\')
            {
                outputAlogFile += "\\";
            }
            outputRadioFile = outputAlogFile + "alog_radio_merge";
            mUtility.mergeFile(outputRadioFile, mAlogRadioList);
            mUtility.OutputText("Output alog_radio : " + outputRadioFile);
        }

        private void mergeAlog(string path)
        {
            int DEFAULT_MAX_SIZE = 300;//default log not bigger than 300MB
            mUtility.SortStrListDecrease(mAlogList);//sort
            moveLog(mAlogRadioList, "alog", 0);
            string ALOG_OUTPUT_NAME = path+"\\alog_merge";
            long MAX_SIZE = -1;
            if (mMergeSizeText.Text != String.Empty)
            {//if the original file is less then MAX_SIZE, and won't split the file
                MAX_SIZE = Convert.ToInt64(mMergeSizeText.Text);
            }
            else
            {
                MAX_SIZE = DEFAULT_MAX_SIZE;
            }
            mUtility.OutputText("Split MAX per File Size to " + MAX_SIZE + "MB");
            MAX_SIZE = MAX_SIZE * 1000 * 1000;//bytes
            Trace.WriteLine("[mergeAlog] MAX_SIZE = " + MAX_SIZE + ", ALOG_OUTPUT_NAME = "+ ALOG_OUTPUT_NAME);
            //init
            int index = 0;
            long fileSize = 0;
            string outputFile = ALOG_OUTPUT_NAME;
            List<String> tmpList = new List<String>();
            
            foreach (string file in mAlogList)
            {
                FileInfo fileInfo = new FileInfo(file);
                fileSize += fileInfo.Length;//bytes
                tmpList.Add(file);
                if (fileSize >= MAX_SIZE && MAX_SIZE!=-1)
                {
                    if (index > 0)
                    {
                        outputFile = ALOG_OUTPUT_NAME + "_" + Convert.ToString(index);
                    }
                    Trace.WriteLine("[mergeAlog] fileSize = " + fileSize + ", outputFile = " + outputFile);
                    mUtility.mergeFile(outputFile, tmpList);
                    mUtility.OutputText("Output alog : " + outputFile);
                    fileSize = 0;
                    tmpList.Clear();
                    ++index;
                }
            }
            if(tmpList.Count > 0)
            {
                if (index > 0)
                {
                    outputFile = ALOG_OUTPUT_NAME + "_" + Convert.ToString(index);
                }
                mUtility.mergeFile(outputFile, tmpList);
                mUtility.OutputText("Output alog : " + outputFile);
            }
        }

        private void moveLog(List<String> list, string log, int pos)
        {
            if (list.Contains(log)) { 
                list.RemoveAll(elem => elem.Equals(log));
                list.Insert(pos, log);
            }
        }

        private void reset()
        {
            mStartTimeText.Text = String.Empty;
            mEndTimeText.Text = String.Empty;
            mPIDText.Text = String.Empty;
            mTIDText.Text = String.Empty;
            mTagText.Text = String.Empty;
            mTagProfileText.Text = String.Empty;
            mFilePathText.Text = String.Empty;
            mContentText.Text = String.Empty;
            mTimeFilterCheckBox.Checked = false;
            mTagFilterCheckBox.Checked = false;
            mTIDFilterCheckBox.Checked = false;
            mPIDFilterCheckBox.Checked = false;
            mLoadDefaultCB.Checked = false;
            mContentFilterCheckBox.Checked = false;
            mContentProfileCheckBox.Checked = false;
            //mOrCheckBox.Checked = false;
            mAlogList.Clear();
            mAlogRadioList.Clear();
            mUtility.clearStatusConsole();
            //20170503
            mParserAnrCheckBox.Checked = false;
            mParserCrashCheckBox.Checked = false;
        }
    }
}
