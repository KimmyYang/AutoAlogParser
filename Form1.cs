using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace AutoAlogParser
{
    public partial class AlogParser : Form
    {

        public AlogParser()
        {
            InitializeComponent();
            initUtility();
            initAlogAdapter();
            //this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void ParserTab_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {/*
            Graphics g = e.Graphics;
            using (Pen p = new Pen(Color.Gray, 1))
            {
                g.DrawLine(p, 5, 145, 650, 145);
            }*/
        }

        private void StartParserBtn_Click(object sender, EventArgs e)
        {
            Parser(mFilePathText.Text);
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            mFilePathText.Text = "";
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            //dialog.InitialDirectory = Directory.GetCurrentDirectory();
            //dialog.Multiselect = true;
            //dialog.AllowNonFileSystemItems = true;
            //dialog.IsFolderPicker = true;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                mFilePathText.AppendText(dialog.FileName);
            }
        }

        private void OpenProfileBtn_Click(object sender, EventArgs e)
        {
            mTagProfileText.Text = "";
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                mTagProfileText.AppendText(dialog.FileName);
                mTagFilterCheckBox.Checked = true;
            }
            Trace.WriteLine("mTagProfileText = " + mTagProfileText.Text);
        }

        private void ContentProfileBtn_Click(object sender, EventArgs e)
        {
            mContentText.Text = "";
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                mContentText.AppendText(dialog.FileName);
                mContentProfileCheckBox.Checked = true;
            }
            Trace.WriteLine("mContentProfileText = " + mContentText.Text);
        }

        private void MergeBtn_Click(object sender, EventArgs e)
        {
            Merge(mFilePathText.Text);
        }

        private void mStartTimeText_TextChanged(object sender, EventArgs e)
        {
            mTimeFilterCheckBox.Checked = true;
        }

        private void mEndTimeText_TextChanged(object sender, EventArgs e)
        {
            mTimeFilterCheckBox.Checked = true;
        }

        private void mPIDText_TextChanged(object sender, EventArgs e)
        {
            mPIDFilterCheckBox.Checked = true;
        }

        private void mTIDText_TextChanged(object sender, EventArgs e)
        {
            mTIDFilterCheckBox.Checked = true;
        }

        private void mTagText_TextChanged(object sender, EventArgs e)
        {
            if(mTagText.Text!=String.Empty)
                mTagFilterCheckBox.Checked = true;
            else
                mTagFilterCheckBox.Checked = false;
        }

        private void mTagProfileText_TextChanged(object sender, EventArgs e)
        {
            if(mTagProfileText.Text != String.Empty)
                mTagFilterCheckBox.Checked = true;
            else
                mTagFilterCheckBox.Checked = false;
        }

        private void ContentProfileText_TextChanged(object sender, EventArgs e)
        {
            /*
             * if(mContentText.Text!=String.Empty)
                mContentProfileCheckBox.Checked = true;
            else
                mContentProfileCheckBox.Checked = false;
            */
        }

        private void ContentProfileText_GotFocus(object sender, EventArgs e)
        {

        }

        private void mTagFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!mTagFilterCheckBox.Checked)
            {
                mTagProfileText.Text = String.Empty;
                mTagText.Text = String.Empty;
            }
        }

        private void ContentProfileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!mContentProfileCheckBox.Checked)
            {
                mContentText.Text = String.Empty;
            }
        }

        private void mResetBtn_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void AutoParserIssueBtn_Click(object sender, EventArgs e)
        {
            try
            {
                mJirHandler.TransferIssue();
            }
            catch (AlogParserException ex)
            {
                mUtility.OutputJiraText("AutoParserIssue ex = " + ex.getMessage());
            }
        }

        private String getPS1TeamIssueFilter()
        {
            return "issuetype = \"SW Bug\" AND status in (Opened, \"In Progress\", Reopened, Resolving, Monitoring, Inspecting, Verifying) AND assignee in (membersOf(_R3J148), membersOf(_R3J148T03), membersOf(_R3J148T02), membersOf(_R3J148T01)) ORDER BY assignee ASC";
        }

        private void mQueryBtn_Click(object sender, EventArgs e)
        {
            mJirHandler.ParserIssue(mIssueKeyText.Text);
        }

        private void AlogParserTabControl_Click(object sender, EventArgs e)
        {
            if(VDBG)mUtility.OutputText("AlogParserTabControl.SelectedIndex = " + AlogParserTabControl.SelectedIndex);
            if(AlogParserTabControl.SelectedIndex == 1)
            {
                initJiraHandler();
                mUtility.clearStatusConsole();
            }
            else if(AlogParserTabControl.SelectedIndex == 0)
            {
                mUtility.clearJiraStatusConsole();
            }
        }

        private void mLoginBtn_Click(object sender, EventArgs e)
        {
            mJirHandler.Login();
        }

        private void mJiraBasicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(mJiraBasicCheckBox.CheckState == CheckState.Checked)
            {
                if (mJirHandler.loadSetupProfile())
                {
                    mJiraBaiscText.Enabled = false;
                    mJiraBasicBtn.Enabled = false;
                }
                else
                {
                    mJiraBasicCheckBox.Checked = false;
                }
            }
            else
            {
                mIssueFilterText.Text = "";
                mJiraBaiscText.Text = "";
                mJiraBaiscText.Enabled = true;
                mJiraBasicBtn.Enabled = true;
            }
        }

        private void mJiraFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (mJiraFilterCheckBox.CheckState == CheckState.Checked)
            {
                if (mJirHandler.loadConditionProfile())
                {
                    mJiraCondtionText.Enabled = false;
                    mJiraCondtionBtn.Enabled = false;
                }
                else
                {
                    mJiraFilterCheckBox.Checked = false;
                }
            }
            else
            {
                mJiraCondtionText.Text = "";
                mJiraCondtionText.Enabled = true;
                mJiraCondtionBtn.Enabled = true;
            }
        }

        private void mJiraResetBtn_Click(object sender, EventArgs e)
        {
            mJirHandler.reset();

            mJiraFilterCheckBox.Enabled = true;
            mJiraFilterCheckBox.Checked = false;
            mJiraCondtionText.Enabled = true;
            mJiraCondtionBtn.Enabled = true;

            mJiraBasicCheckBox.Enabled = true;
            mJiraBasicCheckBox.Checked = false;
            mJiraCondtionText.Enabled = true;
            mJiraCondtionBtn.Enabled = true;

            mUserNameText.Enabled = true;
            mPasswordText.Enabled = true;

            mIssueKeyText.Text = "";
            mPeriodText.Text = "";
        }

        private void mJiraBasicBtn_Click(object sender, EventArgs e)
        {
            mJiraBaiscText.Text = "";
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                mJiraBaiscText.AppendText(dialog.FileName);
                mJirHandler.loadSetupProfile();
                mJiraBasicCheckBox.Enabled = false;
            }
            mUtility.OutputText("mJiraBaiscText = " + mJiraBaiscText.Text);
        }

        private void mJiraBaiscText_TextChanged(object sender, EventArgs e)
        {
            if(mJiraBaiscText.Text == "")
            {
                mJiraBasicCheckBox.Enabled = true;
            }
        }

        private void mJiraCondtionBtn_Click(object sender, EventArgs e)
        {
            mJiraCondtionText.Text = "";
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                mJiraCondtionText.AppendText(dialog.FileName);
                mJirHandler.loadConditionProfile();
            }
            mUtility.OutputText("mJiraCondtionText = " + mJiraCondtionText.Text);
        }

        private void mAutoAssignBtn_Click(object sender, EventArgs e)
        {
            try{
                mJirHandler.AutoAssign();
            }catch(AlogParserException ex){
                mUtility.OutputJiraText("AutoAssign ex = " + ex.getMessage());
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void mLoadDefaultCB_CheckedChanged(object sender, EventArgs e)
        {
            if (mLoadDefaultCB.Checked)
            {
                string tagProfile = "profile\\TagProfile.txt";
                string contentProfile = "profile\\ContentProfile.txt";
                if (File.Exists(tagProfile))
                {
                    mTagProfileText.Text = tagProfile;
                    mTagProfileText.Enabled = false;
                }
                else
                {
                    mUtility.OutputText(tagProfile + " not exist.");
                }
                if (File.Exists(contentProfile))
                {
                    mContentText.Text = contentProfile;
                    mContentText.Enabled = false;
                }
                else
                {
                    mUtility.OutputText(contentProfile + " not exist.");
                }
                if(!File.Exists(tagProfile) && !File.Exists(contentProfile))
                {
                    mLoadDefaultCB.Checked = false;
                    mTagProfileText.Enabled = true;
                    mContentText.Enabled = true;
                }
            }
            else
            {
                mTagProfileText.Text = String.Empty;
                mContentText.Text = String.Empty;
                mTagProfileText.Enabled = true;
                mContentText.Enabled = true;
            }
        }

        private void ContentFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
