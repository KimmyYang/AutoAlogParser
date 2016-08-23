using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using JiraConnector;
using System.Diagnostics;
using System.Reflection;
using Microsoft.CSharp.RuntimeBinder;

namespace AutoAlogParser
{
    class JiraProfile
    {
        public String mUserName="";
        public String mPassword="";
        public String mUrl = "";
        public String mFilter = "";
        private List<JiraCondition> mConditionList = new List<JiraCondition>();

        public String toString()
        {
            return "UserName:" + mUserName + ",Password:" + mPassword +
                         ",Url:" + mUrl + ",Filter:" + mFilter;
        }

        public void setCondition(JiraCondition condiiton)
        {
            mConditionList.Add(condiiton);
        }

        public JiraCondition getCondition(int index)
        {
            foreach (JiraCondition condition in mConditionList)
            {
                if(condition.mIndex == index)
                {
                    return condition;
                }
            }
            return new JiraCondition();
        }

        public List<JiraCondition> getConditions()
        {
            return mConditionList;
        }

        public void reset()
        {
            mUserName = "";
            mPassword = "";
            mUrl = "";
            mFilter = "";
            mConditionList.Clear();
        }
    }

    class JiraCondition
    {
        public int mIndex;
        public String mAssignee;
        public String mProject;
        public String mSummary;
        public List<string> mDescriptionList = new List<string>();

        public string toString()
        {
            return "index:"+Convert.ToString(mIndex) +",assignee:"+ mAssignee+",project:"+ mProject+",summary:" + mSummary;
        }
    }

    class JiraHandler
    {
        const bool DBG = true;
        const bool VDBG = false;
        const String JIRA_ADDRESS = "https://tpe-jira2.fihtdc.com/";
        const String JIRA_SETUP_PROFILE = "profile\\JiraSetupProfile.txt";
        const String JIRA_CONDITION_PROFILE = "profile\\JiraCondtion.txt";
        //setup profile
        const String JIRA_USER_NAME = "UserName";
        const String JIRA_PASSWORD = "Password";
        const String JIRA_URL = "URL";
        const String JIRA_FILTER = "Filter";
        //condition profile
        const String JIRA_INDEX = "Index";
        const String JIRA_ASSIGNEE = "Assignee";
        const String JIRA_PROJECT = "Project";
        const String JIRA_SUMMARY = "Summary";
        const String JIRA_DESCRIPTION = "Description";
        //textbox
        private TextBox mUserName;
        private TextBox mPassword;
        private TextBox mIssueFilter;
        private TextBox mBaiscProfile;
        private TextBox mConditionProfile;
        private TextBox mIssueKey;
        //others
        private RichTextBox mStatusConsole;
        private static Utility mUtility = null;
        private JiraProfile mJiraProfile = new JiraProfile();
        private JiraConnection mJiraConn = JiraConnection.getInstance();
        private static JiraHandler mInstance = null;
        private AlogParser mParser = null;

        private JiraHandler()
        {
            mUtility = Utility.getInstance();
        }

        public static JiraHandler getInstance()
        {

            if (mInstance == null)
            {
                mInstance = new JiraHandler();
            }
            return mInstance;
        }

        public void setParser(AlogParser parser)
        {
            mParser = parser;
        }

        public void initTextInfo(TextBox name, TextBox password, TextBox filter, TextBox basicProfile, TextBox conditionProfile, TextBox issueKey)
        {
            mUserName = name;
            mPassword = password;
            mIssueFilter = filter;
            mBaiscProfile = basicProfile;
            mConditionProfile = conditionProfile;
            mIssueKey = issueKey;
        }

        public bool Login()
        {
            string username = mUserName.Text=="" ? mJiraProfile.mUserName:mUserName.Text;
            string password = mPassword.Text=="" ? mJiraProfile.mPassword:mPassword.Text;
            string url = mJiraProfile.mUrl == "" ? JIRA_ADDRESS : mJiraProfile.mUrl;

            if (username == "" || password == "")
            {
                mUtility.OutputJiraText("Please enter UserName and Password");
                return false;
            }
            else if (mJiraConn.isLogin())
            {
                mUtility.OutputJiraText(String.Format("{0} is login already.",username));
                return true;
            }
            mUtility.OutputJiraTextContinue(String.Format("Start to Login {0}. Please Wait ...",url));
            if (mJiraConn.login(url, username, password))
            {
                //locked down
                mUserName.Text = username;
                mPassword.Text = password;
                mUserName.Enabled = false;
                mPassword.Enabled = false;
                mUtility.OutputJiraText("Login success");
            }
            else
            {
                mUserName.Text = String.Empty;
                mPassword.Text = String.Empty;
                mUserName.Enabled = true;
                mPassword.Enabled = true;
                mUtility.OutputJiraText("Login failed");
            }
            return true;
        }

        private void SignOut()
        {
            if (mJiraConn.isLogin() && mJiraConn.signOut())
            {
                mUtility.OutputJiraText("Sign out success.");
            }
        }

        public bool loadSetupProfile()
        {
            string profile = mBaiscProfile.Text != "" ? mBaiscProfile.Text : JIRA_SETUP_PROFILE;
            char delim = ':';
            if (!File.Exists(profile))
            {
                mUtility.OutputJiraText(profile + " not exist.");
                return false;
            }
            StringBuilder sb = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader(profile))
                {
                    String line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        sb.AppendLine(line);
                        string[] strs = line.Split(delim);
                        if (strs.Length < 2) continue;
                        switch (strs[0])
                        {
                            case JIRA_USER_NAME:
                                mJiraProfile.mUserName = mUserName.Text != "" ? mUserName.Text : strs[1];
                                break;
                            case JIRA_PASSWORD:
                                mJiraProfile.mPassword = mPassword.Text != "" ? mPassword.Text : strs[1];
                                break;
                            case JIRA_URL:
                                mJiraProfile.mUrl = strs[1]+":"+strs[2];
                                Trace.WriteLine("mJiraProfile.mUrl : " + mJiraProfile.mUrl);
                                break;
                            case JIRA_FILTER:
                                mJiraProfile.mFilter = mIssueFilter.Text != "" ? mIssueFilter.Text : strs[1];
                                break;
                            default:
                                mUtility.OutputJiraText("Undefined Text : " + strs[0]);
                                break;
                        }

                    }
                }
            }
            catch (NullReferenceException ex)
            {
                mUtility.OutputJiraText("Exception : " + ex.Message);
                return false;
            }
            finally
            {
                mBaiscProfile.Text = profile;
                mIssueFilter.Text = mJiraProfile.mFilter;
                mUserName.Text = mJiraProfile.mUserName;
                mPassword.Text = mJiraProfile.mPassword;
            }
            return true;
        }

        public bool loadConditionProfile()
        {
            string profile = mConditionProfile.Text != "" ? mConditionProfile.Text : JIRA_CONDITION_PROFILE;
            char delim = ':';
            if (!File.Exists(profile))
            {
                mUtility.OutputJiraText(profile + " not exist.");
                return false;
            }
            StringBuilder sb = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader(profile))
                {
                    String line;
                    JiraCondition condition = null;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        sb.AppendLine(line);
                        string[] strs = line.Split(delim);
                        if (strs.Length < 2) continue;
                        switch (strs[0])
                        {
                            case JIRA_INDEX:
                                condition = new JiraCondition();
                                mJiraProfile.setCondition(condition);
                                condition.mIndex = int.Parse(strs[1]);
                                break;
                            case JIRA_ASSIGNEE:
                                condition.mAssignee = strs[1];
                                break;
                            case JIRA_PROJECT:
                                condition.mProject = strs[1];
                                break;
                            case JIRA_SUMMARY:
                                condition.mSummary = strs[1];
                                break;
                            case JIRA_DESCRIPTION:
                                composeDescription(condition, strs[1]);
                                break;
                            default:
                                mUtility.OutputJiraText("Undefined Text : " + strs[0]);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mUtility.OutputJiraText(String.Format("[loadConditionProfile] Failed ex = {0}\n",ex.Message));
                return false;
            }
            finally
            {
                mConditionProfile.Text = profile;
                mIssueFilter.Text = mJiraProfile.mFilter;

                List<JiraCondition> condList = mJiraProfile.getConditions();
                foreach (JiraCondition condition in condList)
                {
                    Trace.WriteLine(condition.toString());
                }        
            }
            return true;
        }

        private void composeDescription(JiraCondition condtion, string conditions)
        {
            char delim = ';';
            condtion.mDescriptionList.Clear();
            string[] strs = conditions.Split(delim);
            foreach(string str in strs)
            {
                Trace.Write(String.Format("[getDescription] str = {0}\n", str));
                condtion.mDescriptionList.Add(str);
            }
            Trace.Write(String.Format("[getDescription] DescriptionListSize = {0}\n" , condtion.mDescriptionList.Count));
        }

        public void AutoAssign()
        {
            checkLoginStatus();
            List<IssueInfo> issueList = queryIssue(mIssueFilter.Text==String.Empty?mJiraProfile.mFilter: mIssueFilter.Text);
            List<JiraCondition> conditionList = mJiraProfile.getConditions();
            //mUtility.OutputJiraText("conditionList.Count = " + conditionList.Count);
            try
            {
                mUtility.OutputJiraText("[AutoAssign]+");
                if (conditionList.Count == 0) throw new AlogParserException(AlogParserException.JIRA_CONDITION_IS_EMPTY);
                foreach (IssueInfo issue in issueList)
                {
                    foreach (JiraCondition condition in conditionList)
                    {
                        if (isMatch(issue, condition))
                        {
                            mUtility.OutputJiraText("condition.mAssignee = " + condition.mAssignee);
                            mUtility.OutputJiraTextContinue(String.Format("Start Assign issue [{0}] to {1} ... ", issue.key, condition.mAssignee));
                            issue.assign(condition.mAssignee);
                            mUtility.OutputJiraText("Done");
                            break;
                        }
                    }
                    //if (VDBG) mUtility.OutputJiraText(issue.Key + " " + issue.Summary);
                }
            }catch (Exception ex)
            {
                mUtility.OutputJiraText(String.Format("Auto Assign Stop. ex = {0} \n" ,ex.Message));
                return;
            }
            
        }

        private bool isMatch(IssueInfo issue, JiraCondition condition)
        {
            mUtility.OutputJiraText("[isMatch]+");
            if (condition.mSummary!=String.Empty && condition.mProject!=String.Empty &&
                issue.summary.IndexOf(condition.mSummary, StringComparison.OrdinalIgnoreCase) >= 0 &&
                condition.mProject == issue.project)
            {
                mUtility.OutputJiraText(String.Format("[isMatch] project = {0} , summary = {1}", issue.project, issue.summary));
                Trace.WriteLine(String.Format("[isMatch] project = {0} , summary = {1}",issue.project,issue.summary));
                return true;
            }
            else if (condition.mDescriptionList.Count > 0 && issue.summary != String.Empty)
            {
                for(int i=0; i< condition.mDescriptionList.Count; ++i)
                {
                    string description = condition.mDescriptionList[i];
                    if (issue.description.IndexOf(description) >= 0)
                    {
                        mUtility.OutputJiraText(String.Format("[isMatch] description = {0}\n", description));
                        Trace.WriteLine(String.Format("[isMatch] description = {0}\n", description));
                        Trace.WriteLine("[isMatch] issue.description = "+issue.description+"\n");
                        return true;
                    }
                }
            }
            return false;
        }

        public void AutoParserIssue()
        {
            checkLoginStatus();
            List<IssueInfo> issueList = queryIssue(mIssueFilter.Text == String.Empty ? mJiraProfile.mFilter : mIssueFilter.Text);
            mUtility.OutputJiraText("Start auto parser issue ... ");
            foreach(IssueInfo issue in issueList)
            {
                mUtility.OutputJiraTextContinue(String.Format("Start parser {0} ... ",issue.key));
                ParserIssue(issue.key);
                mUtility.OutputJiraText("Done");
            }
        }

        public void ParserIssue(string issueKey)
        {
            checkLoginStatus();
            try
            {
                string condition = "issuekey in (" + issueKey + ")";
                List<IssueInfo> issueList = queryIssue(condition);
                foreach (IssueInfo issue in issueList)
                {
                    if(downloadLog(issueKey, issue))parserLog(issueKey);
                }
            }
            catch (Exception ex)
            {
                mUtility.OutputJiraText(ex.Message);
            }
        }

        private List<IssueInfo> queryIssue(string condition)
        {
            mUtility.OutputJiraTextContinue("Start Query ... ");
            List<IssueInfo> IssueInfoList = null;
            try
            {
                IssueInfoList = mJiraConn.QueryIssue(condition);
                mUtility.OutputJiraText("Done.");
            }
            catch (Exception ex)
            {
                mUtility.OutputJiraText(String.Format("[queryIssue] {0} \n", ex.Message));
            }
            return IssueInfoList;
        }

        //download and uzip the file
        private bool downloadLog(String issueKey, IssueInfo issueInfo)
        {
            //create folder
            mUtility.OutputJiraText("Create folder " + issueKey);
            mUtility.CreateFolder(issueKey);

            //download
            mUtility.OutputJiraTextContinue(String.Format("Start download attachments to ./{0} ... ", issueKey));
            issueInfo.DownloadAattchments(issueKey);
            mUtility.OutputJiraText("Download Done");

            //extract
            if (!mUtility.isEmptyDirectory(issueKey))
            {
                mUtility.OutputJiraTextContinue(String.Format("Start extract attachments to ./{0} ... ", issueKey));
                mUtility.ExtractCompressFilesInDir(issueKey, issueKey);
                mUtility.OutputJiraText("Extract Done");
            }
            else
            {
                mUtility.OutputJiraText(issueKey+" : No any directory/file need to extract and parser");
            }
            /*if (attachList.Count == 0)
            {
                mUtility.OutputJiraText("No any log in attachment.");
                mUpdater.AddComment(issue, JiraUpdater.NO_LOG_COMMENT);
                return false;
            }*/
            return true;
        }

        //merge and parser log (alog_merge, alog_radio_merge)
        private void parserLog(string issueKey)
        {
            string[] mainDirs = Directory.GetDirectories(issueKey);

            //start loop dir
            foreach (string dir in mainDirs)
            {
                //mUtility.OutputJiraText("main directory included = " + dir);
                //parser generic log format
                string logPath = dir + "\\logs\\data";
                if (Directory.Exists(logPath))
                {//parser one layer log
                    parserCommonDirLog(logPath);
                }
                else if (mUtility.GetSubDirCount(dir) == 1)//one directory only
                {//parser two layer log
                    logPath = Directory.GetDirectories(dir)[0] + "\\logs\\data";
                    if(Directory.Exists(logPath)) parserCommonDirLog(logPath);
                    else mUtility.OutputJiraText(logPath + " not match the generic path format. ex. ./logs/data/ ...  ");
                }
                else
                {
                    if (!parserSingleLogFromDir(dir)) mUtility.OutputJiraText(dir + " not match the generic path format. ex. ./logs/data/ ...  ");
                }
            }

            //start loop single file in main dir
            parserSingleLogFromDir(issueKey);
        }

        //this method is for parsering the common directory (ex. xxxx/data/logs/ )
        private void parserCommonDirLog(string logPath)
        {
            mUtility.OutputJiraTextContinue("Start merge file in " + logPath + " ... ");
            mParser.Merge(logPath);
            mUtility.OutputJiraText("Merge Done");
            //alog
            string alogFile = logPath + "\\alog_merge";
            mUtility.OutputJiraTextContinue("Start parser " + alogFile + " ... ");
            mParser.Parser(alogFile);
            mUtility.OutputJiraText("Parser Done");
            //alog_radio
            alogFile = logPath + "\\alog_radio_merge";
            mUtility.OutputJiraTextContinue("Start parser " + alogFile + " ... ");
            mParser.Parser(alogFile);
            mUtility.OutputJiraText("Parser Done");
        }

        //the method is for parser the single file
        private bool parserSingleLogFromDir(string dir)
        {
            var filteredFiles = Directory.EnumerateFiles(dir)
                             .Where(file => file.ToLower().EndsWith("log") || file.ToLower().EndsWith("txt")).ToList();
            foreach (string file in filteredFiles)
            {
                mUtility.OutputJiraTextContinue("Start parser " + file + " ... ");
                mParser.Parser(file);
                mUtility.OutputJiraText("Parser Done");
            }
            if (filteredFiles.Count == 0) return false;
            return true;
        }

        private void checkLoginStatus()
        {
            if (mJiraConn.isLogin() == false)
            {
                Login();
            }
        }

        public void reset()
        {
            mUtility.clearJiraStatusConsole();
            mUserName.Text = "";
            mPassword.Text = "";
            mIssueFilter.Text = "";
            mBaiscProfile.Text = "";
            mConditionProfile.Text = "";
            mJiraProfile.reset();
            SignOut();
    }

        public void setStatusConsole(RichTextBox statusConsole)
        {
            mStatusConsole = statusConsole;
        }

    }
}
