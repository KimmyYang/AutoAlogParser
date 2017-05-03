using System.Drawing;

namespace AutoAlogParser
{
    partial class AlogParser
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlogParser));
            this.AlogParserTabControl = new System.Windows.Forms.TabControl();
            this.mParserTab = new System.Windows.Forms.TabPage();
            this.mParserCrashCheckBox = new System.Windows.Forms.CheckBox();
            this.mParserAnrCheckBox = new System.Windows.Forms.CheckBox();
            this.mContentFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.mMergeSizeText = new System.Windows.Forms.TextBox();
            this.mMergeBtn = new System.Windows.Forms.Button();
            this.mMergeSizeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mLoadDefaultCB = new System.Windows.Forms.CheckBox();
            this.mOrCheckBox = new System.Windows.Forms.CheckBox();
            this.mContentProfileCheckBox = new System.Windows.Forms.CheckBox();
            this.mContentProfileBtn = new System.Windows.Forms.Button();
            this.mContentText = new System.Windows.Forms.TextBox();
            this.LogTypeText = new System.Windows.Forms.TextBox();
            this.mLogTypeFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.mTagProfileBtn = new System.Windows.Forms.Button();
            this.mTagProfileText = new System.Windows.Forms.TextBox();
            this.mResetBtn = new System.Windows.Forms.Button();
            this.mTagText = new System.Windows.Forms.TextBox();
            this.mTagFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.mTIDText = new System.Windows.Forms.TextBox();
            this.mTIDFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.mPIDText = new System.Windows.Forms.TextBox();
            this.mPIDFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.stLabel = new System.Windows.Forms.Label();
            this.etLabel = new System.Windows.Forms.Label();
            this.mEndTimeText = new System.Windows.Forms.TextBox();
            this.mStartTimeText = new System.Windows.Forms.TextBox();
            this.mTimeFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.mOpenFileBtn = new System.Windows.Forms.Button();
            this.mParserStatusConsole = new System.Windows.Forms.RichTextBox();
            this.StartParserBtn = new System.Windows.Forms.Button();
            this.mFilePathText = new System.Windows.Forms.TextBox();
            this.mJiraTab = new System.Windows.Forms.TabPage();
            this.mJiraResetBtn = new System.Windows.Forms.Button();
            this.mIssueKeyLabel = new System.Windows.Forms.Label();
            this.mIssueKeyText = new System.Windows.Forms.TextBox();
            this.mPeriodLabel = new System.Windows.Forms.Label();
            this.mPeriodText = new System.Windows.Forms.TextBox();
            this.mAutoAssignBtn = new System.Windows.Forms.Button();
            this.mJiraFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.mJiraBasicCheckBox = new System.Windows.Forms.CheckBox();
            this.mJiraCondtionBtn = new System.Windows.Forms.Button();
            this.mJiraCondtionText = new System.Windows.Forms.TextBox();
            this.mJiraBasicBtn = new System.Windows.Forms.Button();
            this.mJiraBaiscText = new System.Windows.Forms.TextBox();
            this.mLoginBtn = new System.Windows.Forms.Button();
            this.mJiraStatusConsole = new System.Windows.Forms.RichTextBox();
            this.mIssueFilterLabel = new System.Windows.Forms.Label();
            this.mIssueFilterText = new System.Windows.Forms.TextBox();
            this.mPasswordLabel = new System.Windows.Forms.Label();
            this.mUserNameLabel = new System.Windows.Forms.Label();
            this.mParserIssueBtn = new System.Windows.Forms.Button();
            this.mAutoParserIssueBtn = new System.Windows.Forms.Button();
            this.mPasswordText = new System.Windows.Forms.TextBox();
            this.mUserNameText = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AlogParserTabControl.SuspendLayout();
            this.mParserTab.SuspendLayout();
            this.mJiraTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // AlogParserTabControl
            // 
            this.AlogParserTabControl.Controls.Add(this.mParserTab);
            this.AlogParserTabControl.Controls.Add(this.mJiraTab);
            this.AlogParserTabControl.Location = new System.Drawing.Point(2, 12);
            this.AlogParserTabControl.Name = "AlogParserTabControl";
            this.AlogParserTabControl.SelectedIndex = 0;
            this.AlogParserTabControl.Size = new System.Drawing.Size(663, 804);
            this.AlogParserTabControl.TabIndex = 1;
            this.AlogParserTabControl.Click += new System.EventHandler(this.AlogParserTabControl_Click);
            // 
            // mParserTab
            // 
            this.mParserTab.Controls.Add(this.mParserCrashCheckBox);
            this.mParserTab.Controls.Add(this.mParserAnrCheckBox);
            this.mParserTab.Controls.Add(this.mContentFilterCheckBox);
            this.mParserTab.Controls.Add(this.mMergeSizeText);
            this.mParserTab.Controls.Add(this.mMergeBtn);
            this.mParserTab.Controls.Add(this.mMergeSizeLabel);
            this.mParserTab.Controls.Add(this.label1);
            this.mParserTab.Controls.Add(this.mLoadDefaultCB);
            this.mParserTab.Controls.Add(this.mOrCheckBox);
            this.mParserTab.Controls.Add(this.mContentProfileCheckBox);
            this.mParserTab.Controls.Add(this.mContentProfileBtn);
            this.mParserTab.Controls.Add(this.mContentText);
            this.mParserTab.Controls.Add(this.LogTypeText);
            this.mParserTab.Controls.Add(this.mLogTypeFilterCheckBox);
            this.mParserTab.Controls.Add(this.mTagProfileBtn);
            this.mParserTab.Controls.Add(this.mTagProfileText);
            this.mParserTab.Controls.Add(this.mResetBtn);
            this.mParserTab.Controls.Add(this.mTagText);
            this.mParserTab.Controls.Add(this.mTagFilterCheckBox);
            this.mParserTab.Controls.Add(this.mTIDText);
            this.mParserTab.Controls.Add(this.mTIDFilterCheckBox);
            this.mParserTab.Controls.Add(this.mPIDText);
            this.mParserTab.Controls.Add(this.mPIDFilterCheckBox);
            this.mParserTab.Controls.Add(this.stLabel);
            this.mParserTab.Controls.Add(this.etLabel);
            this.mParserTab.Controls.Add(this.mEndTimeText);
            this.mParserTab.Controls.Add(this.mStartTimeText);
            this.mParserTab.Controls.Add(this.mTimeFilterCheckBox);
            this.mParserTab.Controls.Add(this.mOpenFileBtn);
            this.mParserTab.Controls.Add(this.mParserStatusConsole);
            this.mParserTab.Controls.Add(this.StartParserBtn);
            this.mParserTab.Controls.Add(this.mFilePathText);
            this.mParserTab.Location = new System.Drawing.Point(4, 22);
            this.mParserTab.Name = "mParserTab";
            this.mParserTab.Padding = new System.Windows.Forms.Padding(3);
            this.mParserTab.Size = new System.Drawing.Size(655, 778);
            this.mParserTab.TabIndex = 0;
            this.mParserTab.Text = "Log Parser";
            this.mParserTab.UseVisualStyleBackColor = true;
            // 
            // mParserCrashCheckBox
            // 
            this.mParserCrashCheckBox.AutoSize = true;
            this.mParserCrashCheckBox.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mParserCrashCheckBox.Location = new System.Drawing.Point(450, 198);
            this.mParserCrashCheckBox.Name = "mParserCrashCheckBox";
            this.mParserCrashCheckBox.Size = new System.Drawing.Size(105, 20);
            this.mParserCrashCheckBox.TabIndex = 63;
            this.mParserCrashCheckBox.Text = "Parser Crash";
            this.mParserCrashCheckBox.UseVisualStyleBackColor = true;
            // 
            // mParserAnrCheckBox
            // 
            this.mParserAnrCheckBox.AutoSize = true;
            this.mParserAnrCheckBox.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mParserAnrCheckBox.Location = new System.Drawing.Point(345, 198);
            this.mParserAnrCheckBox.Name = "mParserAnrCheckBox";
            this.mParserAnrCheckBox.Size = new System.Drawing.Size(99, 20);
            this.mParserAnrCheckBox.TabIndex = 62;
            this.mParserAnrCheckBox.Text = "Parser ANR";
            this.mParserAnrCheckBox.UseVisualStyleBackColor = true;
            // 
            // mContentFilterCheckBox
            // 
            this.mContentFilterCheckBox.AutoSize = true;
            this.mContentFilterCheckBox.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mContentFilterCheckBox.Location = new System.Drawing.Point(226, 198);
            this.mContentFilterCheckBox.Name = "mContentFilterCheckBox";
            this.mContentFilterCheckBox.Size = new System.Drawing.Size(113, 20);
            this.mContentFilterCheckBox.TabIndex = 61;
            this.mContentFilterCheckBox.Text = "Content Filter";
            this.mContentFilterCheckBox.UseVisualStyleBackColor = true;
            this.mContentFilterCheckBox.CheckedChanged += new System.EventHandler(this.ContentFilterCheckBox_CheckedChanged);
            // 
            // mMergeSizeText
            // 
            this.mMergeSizeText.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mMergeSizeText.Location = new System.Drawing.Point(15, 290);
            this.mMergeSizeText.Name = "mMergeSizeText";
            this.mMergeSizeText.Size = new System.Drawing.Size(72, 25);
            this.mMergeSizeText.TabIndex = 60;
            // 
            // mMergeBtn
            // 
            this.mMergeBtn.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mMergeBtn.Location = new System.Drawing.Point(93, 258);
            this.mMergeBtn.Name = "mMergeBtn";
            this.mMergeBtn.Size = new System.Drawing.Size(120, 65);
            this.mMergeBtn.TabIndex = 59;
            this.mMergeBtn.Text = "Merge";
            this.mMergeBtn.UseVisualStyleBackColor = true;
            this.mMergeBtn.Click += new System.EventHandler(this.MergeBtn_Click);
            // 
            // mMergeSizeLabel
            // 
            this.mMergeSizeLabel.AutoSize = true;
            this.mMergeSizeLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mMergeSizeLabel.Location = new System.Drawing.Point(12, 254);
            this.mMergeSizeLabel.MaximumSize = new System.Drawing.Size(110, 40);
            this.mMergeSizeLabel.MinimumSize = new System.Drawing.Size(110, 35);
            this.mMergeSizeLabel.Name = "mMergeSizeLabel";
            this.mMergeSizeLabel.Size = new System.Drawing.Size(110, 35);
            this.mMergeSizeLabel.TabIndex = 58;
            this.mMergeSizeLabel.Text = "Per File Size(MB)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 16);
            this.label1.TabIndex = 56;
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "------------";
            // 
            // mLoadDefaultCB
            // 
            this.mLoadDefaultCB.AutoSize = true;
            this.mLoadDefaultCB.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mLoadDefaultCB.Location = new System.Drawing.Point(15, 135);
            this.mLoadDefaultCB.Name = "mLoadDefaultCB";
            this.mLoadDefaultCB.Size = new System.Drawing.Size(160, 22);
            this.mLoadDefaultCB.TabIndex = 55;
            this.mLoadDefaultCB.Text = "Load Default Profile";
            this.mLoadDefaultCB.UseVisualStyleBackColor = true;
            this.mLoadDefaultCB.CheckedChanged += new System.EventHandler(this.mLoadDefaultCB_CheckedChanged);
            // 
            // mOrCheckBox
            // 
            this.mOrCheckBox.AutoSize = true;
            this.mOrCheckBox.Checked = true;
            this.mOrCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mOrCheckBox.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mOrCheckBox.Location = new System.Drawing.Point(15, 203);
            this.mOrCheckBox.Name = "mOrCheckBox";
            this.mOrCheckBox.Size = new System.Drawing.Size(72, 35);
            this.mOrCheckBox.TabIndex = 54;
            this.mOrCheckBox.Text = "OR";
            this.mOrCheckBox.UseVisualStyleBackColor = true;
            // 
            // mContentProfileCheckBox
            // 
            this.mContentProfileCheckBox.AutoSize = true;
            this.mContentProfileCheckBox.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mContentProfileCheckBox.Location = new System.Drawing.Point(100, 198);
            this.mContentProfileCheckBox.Name = "mContentProfileCheckBox";
            this.mContentProfileCheckBox.Size = new System.Drawing.Size(120, 20);
            this.mContentProfileCheckBox.TabIndex = 53;
            this.mContentProfileCheckBox.Text = "Content Profile";
            this.mContentProfileCheckBox.UseVisualStyleBackColor = true;
            this.mContentProfileCheckBox.CheckedChanged += new System.EventHandler(this.ContentProfileCheckBox_CheckedChanged);
            // 
            // mContentProfileBtn
            // 
            this.mContentProfileBtn.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mContentProfileBtn.Location = new System.Drawing.Point(555, 218);
            this.mContentProfileBtn.Name = "mContentProfileBtn";
            this.mContentProfileBtn.Size = new System.Drawing.Size(89, 33);
            this.mContentProfileBtn.TabIndex = 52;
            this.mContentProfileBtn.Text = "Load Profile";
            this.mContentProfileBtn.UseVisualStyleBackColor = true;
            this.mContentProfileBtn.Click += new System.EventHandler(this.ContentProfileBtn_Click);
            // 
            // mContentText
            // 
            this.mContentText.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mContentText.Location = new System.Drawing.Point(100, 224);
            this.mContentText.Name = "mContentText";
            this.mContentText.Size = new System.Drawing.Size(449, 25);
            this.mContentText.TabIndex = 51;
            this.mContentText.TextChanged += new System.EventHandler(this.ContentProfileText_TextChanged);
            this.mContentText.GotFocus += new System.EventHandler(this.ContentProfileText_GotFocus);
            // 
            // LogTypeText
            // 
            this.LogTypeText.Enabled = false;
            this.LogTypeText.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogTypeText.Location = new System.Drawing.Point(544, 97);
            this.LogTypeText.Name = "LogTypeText";
            this.LogTypeText.Size = new System.Drawing.Size(100, 25);
            this.LogTypeText.TabIndex = 50;
            // 
            // mLogTypeFilterCheckBox
            // 
            this.mLogTypeFilterCheckBox.AutoSize = true;
            this.mLogTypeFilterCheckBox.Enabled = false;
            this.mLogTypeFilterCheckBox.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mLogTypeFilterCheckBox.Location = new System.Drawing.Point(462, 99);
            this.mLogTypeFilterCheckBox.Name = "mLogTypeFilterCheckBox";
            this.mLogTypeFilterCheckBox.Size = new System.Drawing.Size(81, 20);
            this.mLogTypeFilterCheckBox.TabIndex = 49;
            this.mLogTypeFilterCheckBox.Text = "LogType";
            this.mLogTypeFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // mTagProfileBtn
            // 
            this.mTagProfileBtn.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTagProfileBtn.Location = new System.Drawing.Point(555, 163);
            this.mTagProfileBtn.Name = "mTagProfileBtn";
            this.mTagProfileBtn.Size = new System.Drawing.Size(89, 33);
            this.mTagProfileBtn.TabIndex = 47;
            this.mTagProfileBtn.Text = "Load Profile";
            this.mTagProfileBtn.UseVisualStyleBackColor = true;
            this.mTagProfileBtn.Click += new System.EventHandler(this.OpenProfileBtn_Click);
            // 
            // mTagProfileText
            // 
            this.mTagProfileText.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTagProfileText.Location = new System.Drawing.Point(275, 167);
            this.mTagProfileText.Name = "mTagProfileText";
            this.mTagProfileText.Size = new System.Drawing.Size(274, 25);
            this.mTagProfileText.TabIndex = 46;
            this.mTagProfileText.TextChanged += new System.EventHandler(this.mTagProfileText_TextChanged);
            // 
            // mResetBtn
            // 
            this.mResetBtn.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mResetBtn.Location = new System.Drawing.Point(219, 258);
            this.mResetBtn.Name = "mResetBtn";
            this.mResetBtn.Size = new System.Drawing.Size(130, 65);
            this.mResetBtn.TabIndex = 44;
            this.mResetBtn.Text = "Reset";
            this.mResetBtn.UseVisualStyleBackColor = true;
            this.mResetBtn.Click += new System.EventHandler(this.mResetBtn_Click);
            // 
            // mTagText
            // 
            this.mTagText.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTagText.Location = new System.Drawing.Point(100, 167);
            this.mTagText.Name = "mTagText";
            this.mTagText.Size = new System.Drawing.Size(161, 25);
            this.mTagText.TabIndex = 43;
            this.mTagText.TextChanged += new System.EventHandler(this.mTagText_TextChanged);
            // 
            // mTagFilterCheckBox
            // 
            this.mTagFilterCheckBox.AutoSize = true;
            this.mTagFilterCheckBox.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTagFilterCheckBox.Location = new System.Drawing.Point(15, 170);
            this.mTagFilterCheckBox.Name = "mTagFilterCheckBox";
            this.mTagFilterCheckBox.Size = new System.Drawing.Size(86, 20);
            this.mTagFilterCheckBox.TabIndex = 42;
            this.mTagFilterCheckBox.Text = "Tag Filter";
            this.mTagFilterCheckBox.UseVisualStyleBackColor = true;
            this.mTagFilterCheckBox.CheckedChanged += new System.EventHandler(this.mTagFilterCheckBox_CheckedChanged);
            // 
            // mTIDText
            // 
            this.mTIDText.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTIDText.Location = new System.Drawing.Point(323, 99);
            this.mTIDText.Name = "mTIDText";
            this.mTIDText.Size = new System.Drawing.Size(126, 25);
            this.mTIDText.TabIndex = 41;
            this.mTIDText.TextChanged += new System.EventHandler(this.mTIDText_TextChanged);
            // 
            // mTIDFilterCheckBox
            // 
            this.mTIDFilterCheckBox.AutoSize = true;
            this.mTIDFilterCheckBox.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTIDFilterCheckBox.Location = new System.Drawing.Point(242, 101);
            this.mTIDFilterCheckBox.Name = "mTIDFilterCheckBox";
            this.mTIDFilterCheckBox.Size = new System.Drawing.Size(87, 20);
            this.mTIDFilterCheckBox.TabIndex = 40;
            this.mTIDFilterCheckBox.Text = "TID Filter";
            this.mTIDFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // mPIDText
            // 
            this.mPIDText.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mPIDText.Location = new System.Drawing.Point(105, 99);
            this.mPIDText.Name = "mPIDText";
            this.mPIDText.Size = new System.Drawing.Size(121, 25);
            this.mPIDText.TabIndex = 39;
            this.mPIDText.TextChanged += new System.EventHandler(this.mPIDText_TextChanged);
            // 
            // mPIDFilterCheckBox
            // 
            this.mPIDFilterCheckBox.AutoSize = true;
            this.mPIDFilterCheckBox.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mPIDFilterCheckBox.Location = new System.Drawing.Point(15, 101);
            this.mPIDFilterCheckBox.Name = "mPIDFilterCheckBox";
            this.mPIDFilterCheckBox.Size = new System.Drawing.Size(87, 20);
            this.mPIDFilterCheckBox.TabIndex = 38;
            this.mPIDFilterCheckBox.Text = "PID Filter";
            this.mPIDFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // stLabel
            // 
            this.stLabel.AutoSize = true;
            this.stLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stLabel.Location = new System.Drawing.Point(118, 61);
            this.stLabel.Name = "stLabel";
            this.stLabel.Size = new System.Drawing.Size(72, 16);
            this.stLabel.TabIndex = 36;
            this.stLabel.Text = "Start Time";
            // 
            // etLabel
            // 
            this.etLabel.AutoSize = true;
            this.etLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etLabel.Location = new System.Drawing.Point(390, 60);
            this.etLabel.Name = "etLabel";
            this.etLabel.Size = new System.Drawing.Size(66, 16);
            this.etLabel.TabIndex = 37;
            this.etLabel.Text = "End Time";
            // 
            // mEndTimeText
            // 
            this.mEndTimeText.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mEndTimeText.Location = new System.Drawing.Point(462, 53);
            this.mEndTimeText.Name = "mEndTimeText";
            this.mEndTimeText.Size = new System.Drawing.Size(171, 25);
            this.mEndTimeText.TabIndex = 35;
            this.mEndTimeText.TextChanged += new System.EventHandler(this.mEndTimeText_TextChanged);
            // 
            // mStartTimeText
            // 
            this.mStartTimeText.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mStartTimeText.Location = new System.Drawing.Point(196, 56);
            this.mStartTimeText.Name = "mStartTimeText";
            this.mStartTimeText.Size = new System.Drawing.Size(168, 25);
            this.mStartTimeText.TabIndex = 34;
            this.mStartTimeText.TextChanged += new System.EventHandler(this.mStartTimeText_TextChanged);
            // 
            // mTimeFilterCheckBox
            // 
            this.mTimeFilterCheckBox.AutoSize = true;
            this.mTimeFilterCheckBox.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTimeFilterCheckBox.Location = new System.Drawing.Point(15, 60);
            this.mTimeFilterCheckBox.Name = "mTimeFilterCheckBox";
            this.mTimeFilterCheckBox.Size = new System.Drawing.Size(95, 20);
            this.mTimeFilterCheckBox.TabIndex = 33;
            this.mTimeFilterCheckBox.Text = "Time Filter";
            this.mTimeFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // mOpenFileBtn
            // 
            this.mOpenFileBtn.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mOpenFileBtn.Location = new System.Drawing.Point(539, 10);
            this.mOpenFileBtn.Name = "mOpenFileBtn";
            this.mOpenFileBtn.Size = new System.Drawing.Size(105, 32);
            this.mOpenFileBtn.TabIndex = 27;
            this.mOpenFileBtn.Text = "Choose File";
            this.mOpenFileBtn.UseVisualStyleBackColor = true;
            this.mOpenFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // mParserStatusConsole
            // 
            this.mParserStatusConsole.Location = new System.Drawing.Point(4, 329);
            this.mParserStatusConsole.Name = "mParserStatusConsole";
            this.mParserStatusConsole.Size = new System.Drawing.Size(645, 431);
            this.mParserStatusConsole.TabIndex = 26;
            this.mParserStatusConsole.Text = "";
            // 
            // StartParserBtn
            // 
            this.StartParserBtn.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartParserBtn.Location = new System.Drawing.Point(355, 258);
            this.StartParserBtn.Name = "StartParserBtn";
            this.StartParserBtn.Size = new System.Drawing.Size(288, 65);
            this.StartParserBtn.TabIndex = 25;
            this.StartParserBtn.Text = "Start Paraser";
            this.StartParserBtn.UseVisualStyleBackColor = true;
            this.StartParserBtn.Click += new System.EventHandler(this.StartParserBtn_Click);
            // 
            // mFilePathText
            // 
            this.mFilePathText.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mFilePathText.Location = new System.Drawing.Point(17, 17);
            this.mFilePathText.Name = "mFilePathText";
            this.mFilePathText.Size = new System.Drawing.Size(516, 26);
            this.mFilePathText.TabIndex = 4;
            // 
            // mJiraTab
            // 
            this.mJiraTab.Controls.Add(this.mJiraResetBtn);
            this.mJiraTab.Controls.Add(this.mIssueKeyLabel);
            this.mJiraTab.Controls.Add(this.mIssueKeyText);
            this.mJiraTab.Controls.Add(this.mPeriodLabel);
            this.mJiraTab.Controls.Add(this.mPeriodText);
            this.mJiraTab.Controls.Add(this.mAutoAssignBtn);
            this.mJiraTab.Controls.Add(this.mJiraFilterCheckBox);
            this.mJiraTab.Controls.Add(this.mJiraBasicCheckBox);
            this.mJiraTab.Controls.Add(this.mJiraCondtionBtn);
            this.mJiraTab.Controls.Add(this.mJiraCondtionText);
            this.mJiraTab.Controls.Add(this.mJiraBasicBtn);
            this.mJiraTab.Controls.Add(this.mJiraBaiscText);
            this.mJiraTab.Controls.Add(this.mLoginBtn);
            this.mJiraTab.Controls.Add(this.mJiraStatusConsole);
            this.mJiraTab.Controls.Add(this.mIssueFilterLabel);
            this.mJiraTab.Controls.Add(this.mIssueFilterText);
            this.mJiraTab.Controls.Add(this.mPasswordLabel);
            this.mJiraTab.Controls.Add(this.mUserNameLabel);
            this.mJiraTab.Controls.Add(this.mParserIssueBtn);
            this.mJiraTab.Controls.Add(this.mAutoParserIssueBtn);
            this.mJiraTab.Controls.Add(this.mPasswordText);
            this.mJiraTab.Controls.Add(this.mUserNameText);
            this.mJiraTab.Location = new System.Drawing.Point(4, 22);
            this.mJiraTab.Name = "mJiraTab";
            this.mJiraTab.Padding = new System.Windows.Forms.Padding(3);
            this.mJiraTab.Size = new System.Drawing.Size(655, 778);
            this.mJiraTab.TabIndex = 1;
            this.mJiraTab.Text = "JIRA Handler";
            this.mJiraTab.UseVisualStyleBackColor = true;
            // 
            // mJiraResetBtn
            // 
            this.mJiraResetBtn.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mJiraResetBtn.Location = new System.Drawing.Point(320, 232);
            this.mJiraResetBtn.Name = "mJiraResetBtn";
            this.mJiraResetBtn.Size = new System.Drawing.Size(97, 56);
            this.mJiraResetBtn.TabIndex = 75;
            this.mJiraResetBtn.Text = "Reset";
            this.mJiraResetBtn.UseVisualStyleBackColor = true;
            this.mJiraResetBtn.Click += new System.EventHandler(this.mJiraResetBtn_Click);
            // 
            // mIssueKeyLabel
            // 
            this.mIssueKeyLabel.AutoSize = true;
            this.mIssueKeyLabel.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mIssueKeyLabel.Location = new System.Drawing.Point(17, 229);
            this.mIssueKeyLabel.MaximumSize = new System.Drawing.Size(100, 40);
            this.mIssueKeyLabel.Name = "mIssueKeyLabel";
            this.mIssueKeyLabel.Size = new System.Drawing.Size(70, 18);
            this.mIssueKeyLabel.TabIndex = 74;
            this.mIssueKeyLabel.Text = "Issue key";
            // 
            // mIssueKeyText
            // 
            this.mIssueKeyText.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mIssueKeyText.Location = new System.Drawing.Point(98, 222);
            this.mIssueKeyText.MaximumSize = new System.Drawing.Size(150, 30);
            this.mIssueKeyText.MinimumSize = new System.Drawing.Size(80, 30);
            this.mIssueKeyText.Name = "mIssueKeyText";
            this.mIssueKeyText.Size = new System.Drawing.Size(95, 26);
            this.mIssueKeyText.TabIndex = 73;
            // 
            // mPeriodLabel
            // 
            this.mPeriodLabel.AutoSize = true;
            this.mPeriodLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mPeriodLabel.Location = new System.Drawing.Point(17, 263);
            this.mPeriodLabel.MaximumSize = new System.Drawing.Size(100, 40);
            this.mPeriodLabel.Name = "mPeriodLabel";
            this.mPeriodLabel.Size = new System.Drawing.Size(92, 16);
            this.mPeriodLabel.TabIndex = 72;
            this.mPeriodLabel.Text = "Peroid(次/H)";
            // 
            // mPeriodText
            // 
            this.mPeriodText.Enabled = false;
            this.mPeriodText.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mPeriodText.Location = new System.Drawing.Point(113, 258);
            this.mPeriodText.MaximumSize = new System.Drawing.Size(150, 30);
            this.mPeriodText.MinimumSize = new System.Drawing.Size(80, 30);
            this.mPeriodText.Name = "mPeriodText";
            this.mPeriodText.Size = new System.Drawing.Size(80, 26);
            this.mPeriodText.TabIndex = 71;
            // 
            // mAutoAssignBtn
            // 
            this.mAutoAssignBtn.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mAutoAssignBtn.Location = new System.Drawing.Point(423, 232);
            this.mAutoAssignBtn.Name = "mAutoAssignBtn";
            this.mAutoAssignBtn.Size = new System.Drawing.Size(94, 56);
            this.mAutoAssignBtn.TabIndex = 70;
            this.mAutoAssignBtn.Text = "Auto Assign";
            this.mAutoAssignBtn.UseVisualStyleBackColor = true;
            this.mAutoAssignBtn.Click += new System.EventHandler(this.mAutoAssignBtn_Click);
            // 
            // mJiraFilterCheckBox
            // 
            this.mJiraFilterCheckBox.AutoSize = true;
            this.mJiraFilterCheckBox.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mJiraFilterCheckBox.Location = new System.Drawing.Point(10, 175);
            this.mJiraFilterCheckBox.Name = "mJiraFilterCheckBox";
            this.mJiraFilterCheckBox.Size = new System.Drawing.Size(117, 22);
            this.mJiraFilterCheckBox.TabIndex = 69;
            this.mJiraFilterCheckBox.Text = "Load Default";
            this.mJiraFilterCheckBox.UseVisualStyleBackColor = true;
            this.mJiraFilterCheckBox.CheckedChanged += new System.EventHandler(this.mJiraFilterCheckBox_CheckedChanged);
            // 
            // mJiraBasicCheckBox
            // 
            this.mJiraBasicCheckBox.AutoSize = true;
            this.mJiraBasicCheckBox.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mJiraBasicCheckBox.Location = new System.Drawing.Point(12, 78);
            this.mJiraBasicCheckBox.Name = "mJiraBasicCheckBox";
            this.mJiraBasicCheckBox.Size = new System.Drawing.Size(117, 22);
            this.mJiraBasicCheckBox.TabIndex = 68;
            this.mJiraBasicCheckBox.Text = "Load Default";
            this.mJiraBasicCheckBox.UseVisualStyleBackColor = true;
            this.mJiraBasicCheckBox.CheckedChanged += new System.EventHandler(this.mJiraBasicCheckBox_CheckedChanged);
            // 
            // mJiraCondtionBtn
            // 
            this.mJiraCondtionBtn.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mJiraCondtionBtn.Location = new System.Drawing.Point(537, 165);
            this.mJiraCondtionBtn.Name = "mJiraCondtionBtn";
            this.mJiraCondtionBtn.Size = new System.Drawing.Size(102, 42);
            this.mJiraCondtionBtn.TabIndex = 67;
            this.mJiraCondtionBtn.Text = "Load Condtion";
            this.mJiraCondtionBtn.UseVisualStyleBackColor = true;
            this.mJiraCondtionBtn.Click += new System.EventHandler(this.mJiraCondtionBtn_Click);
            // 
            // mJiraCondtionText
            // 
            this.mJiraCondtionText.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mJiraCondtionText.Location = new System.Drawing.Point(146, 173);
            this.mJiraCondtionText.MaximumSize = new System.Drawing.Size(400, 30);
            this.mJiraCondtionText.MinimumSize = new System.Drawing.Size(300, 30);
            this.mJiraCondtionText.Name = "mJiraCondtionText";
            this.mJiraCondtionText.Size = new System.Drawing.Size(385, 26);
            this.mJiraCondtionText.TabIndex = 66;
            // 
            // mJiraBasicBtn
            // 
            this.mJiraBasicBtn.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mJiraBasicBtn.Location = new System.Drawing.Point(537, 66);
            this.mJiraBasicBtn.Name = "mJiraBasicBtn";
            this.mJiraBasicBtn.Size = new System.Drawing.Size(102, 42);
            this.mJiraBasicBtn.TabIndex = 65;
            this.mJiraBasicBtn.Text = "Load Setup Profile";
            this.mJiraBasicBtn.UseVisualStyleBackColor = true;
            this.mJiraBasicBtn.Click += new System.EventHandler(this.mJiraBasicBtn_Click);
            // 
            // mJiraBaiscText
            // 
            this.mJiraBaiscText.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mJiraBaiscText.Location = new System.Drawing.Point(146, 74);
            this.mJiraBaiscText.MaximumSize = new System.Drawing.Size(400, 30);
            this.mJiraBaiscText.MinimumSize = new System.Drawing.Size(300, 30);
            this.mJiraBaiscText.Name = "mJiraBaiscText";
            this.mJiraBaiscText.Size = new System.Drawing.Size(385, 26);
            this.mJiraBaiscText.TabIndex = 64;
            this.mJiraBaiscText.TextChanged += new System.EventHandler(this.mJiraBaiscText_TextChanged);
            // 
            // mLoginBtn
            // 
            this.mLoginBtn.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mLoginBtn.Location = new System.Drawing.Point(566, 14);
            this.mLoginBtn.Name = "mLoginBtn";
            this.mLoginBtn.Size = new System.Drawing.Size(73, 42);
            this.mLoginBtn.TabIndex = 63;
            this.mLoginBtn.Text = "Login";
            this.mLoginBtn.UseVisualStyleBackColor = true;
            this.mLoginBtn.Click += new System.EventHandler(this.mLoginBtn_Click);
            // 
            // mJiraStatusConsole
            // 
            this.mJiraStatusConsole.Location = new System.Drawing.Point(5, 303);
            this.mJiraStatusConsole.Name = "mJiraStatusConsole";
            this.mJiraStatusConsole.Size = new System.Drawing.Size(645, 469);
            this.mJiraStatusConsole.TabIndex = 53;
            this.mJiraStatusConsole.Text = "";
            // 
            // mIssueFilterLabel
            // 
            this.mIssueFilterLabel.AutoSize = true;
            this.mIssueFilterLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mIssueFilterLabel.Location = new System.Drawing.Point(6, 128);
            this.mIssueFilterLabel.MaximumSize = new System.Drawing.Size(200, 40);
            this.mIssueFilterLabel.Name = "mIssueFilterLabel";
            this.mIssueFilterLabel.Size = new System.Drawing.Size(104, 23);
            this.mIssueFilterLabel.TabIndex = 52;
            this.mIssueFilterLabel.Text = "Issue Filter";
            // 
            // mIssueFilterText
            // 
            this.mIssueFilterText.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mIssueFilterText.Location = new System.Drawing.Point(113, 125);
            this.mIssueFilterText.MaximumSize = new System.Drawing.Size(550, 30);
            this.mIssueFilterText.MinimumSize = new System.Drawing.Size(500, 30);
            this.mIssueFilterText.Name = "mIssueFilterText";
            this.mIssueFilterText.Size = new System.Drawing.Size(524, 26);
            this.mIssueFilterText.TabIndex = 51;
            // 
            // mPasswordLabel
            // 
            this.mPasswordLabel.AutoSize = true;
            this.mPasswordLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mPasswordLabel.Location = new System.Drawing.Point(271, 26);
            this.mPasswordLabel.MaximumSize = new System.Drawing.Size(100, 40);
            this.mPasswordLabel.Name = "mPasswordLabel";
            this.mPasswordLabel.Size = new System.Drawing.Size(91, 23);
            this.mPasswordLabel.TabIndex = 49;
            this.mPasswordLabel.Text = "Password";
            // 
            // mUserNameLabel
            // 
            this.mUserNameLabel.AutoSize = true;
            this.mUserNameLabel.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mUserNameLabel.Location = new System.Drawing.Point(6, 25);
            this.mUserNameLabel.MaximumSize = new System.Drawing.Size(100, 40);
            this.mUserNameLabel.Name = "mUserNameLabel";
            this.mUserNameLabel.Size = new System.Drawing.Size(93, 20);
            this.mUserNameLabel.TabIndex = 48;
            this.mUserNameLabel.Text = "User Name";
            // 
            // mParserIssueBtn
            // 
            this.mParserIssueBtn.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mParserIssueBtn.Location = new System.Drawing.Point(217, 232);
            this.mParserIssueBtn.Name = "mParserIssueBtn";
            this.mParserIssueBtn.Size = new System.Drawing.Size(97, 56);
            this.mParserIssueBtn.TabIndex = 47;
            this.mParserIssueBtn.Text = "Parser Issue";
            this.mParserIssueBtn.UseVisualStyleBackColor = true;
            this.mParserIssueBtn.Click += new System.EventHandler(this.mQueryBtn_Click);
            // 
            // mAutoParserIssueBtn
            // 
            this.mAutoParserIssueBtn.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mAutoParserIssueBtn.Location = new System.Drawing.Point(523, 232);
            this.mAutoParserIssueBtn.Name = "mAutoParserIssueBtn";
            this.mAutoParserIssueBtn.Size = new System.Drawing.Size(114, 56);
            this.mAutoParserIssueBtn.TabIndex = 46;
            this.mAutoParserIssueBtn.Text = "Auto Parser";
            this.mAutoParserIssueBtn.UseVisualStyleBackColor = true;
            this.mAutoParserIssueBtn.Click += new System.EventHandler(this.AutoParserIssueBtn_Click);
            // 
            // mPasswordText
            // 
            this.mPasswordText.Location = new System.Drawing.Point(368, 21);
            this.mPasswordText.MaximumSize = new System.Drawing.Size(200, 30);
            this.mPasswordText.MinimumSize = new System.Drawing.Size(180, 30);
            this.mPasswordText.Name = "mPasswordText";
            this.mPasswordText.Size = new System.Drawing.Size(180, 22);
            this.mPasswordText.TabIndex = 35;
            this.mPasswordText.UseSystemPasswordChar = true;
            // 
            // mUserNameText
            // 
            this.mUserNameText.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mUserNameText.Location = new System.Drawing.Point(104, 23);
            this.mUserNameText.MaximumSize = new System.Drawing.Size(180, 30);
            this.mUserNameText.MinimumSize = new System.Drawing.Size(150, 30);
            this.mUserNameText.Name = "mUserNameText";
            this.mUserNameText.Size = new System.Drawing.Size(150, 26);
            this.mUserNameText.TabIndex = 34;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // AlogParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 819);
            this.Controls.Add(this.AlogParserTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlogParser";
            this.Text = "Alog Parser V2.2";
            this.AlogParserTabControl.ResumeLayout(false);
            this.mParserTab.ResumeLayout(false);
            this.mParserTab.PerformLayout();
            this.mJiraTab.ResumeLayout(false);
            this.mJiraTab.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TabControl AlogParserTabControl;
        private System.Windows.Forms.TabPage mParserTab;
        private System.Windows.Forms.Button mTagProfileBtn;
        private System.Windows.Forms.TextBox mTagProfileText;
        private System.Windows.Forms.Button mResetBtn;
        private System.Windows.Forms.TextBox mTagText;
        private System.Windows.Forms.CheckBox mTagFilterCheckBox;
        private System.Windows.Forms.TextBox mTIDText;
        private System.Windows.Forms.CheckBox mTIDFilterCheckBox;
        private System.Windows.Forms.TextBox mPIDText;
        private System.Windows.Forms.CheckBox mPIDFilterCheckBox;
        private System.Windows.Forms.Label stLabel;
        private System.Windows.Forms.Label etLabel;
        private System.Windows.Forms.TextBox mEndTimeText;
        private System.Windows.Forms.TextBox mStartTimeText;
        private System.Windows.Forms.CheckBox mTimeFilterCheckBox;
        private System.Windows.Forms.Button mOpenFileBtn;
        private System.Windows.Forms.RichTextBox mParserStatusConsole;
        private System.Windows.Forms.Button StartParserBtn;
        private System.Windows.Forms.TextBox mFilePathText;
        private System.Windows.Forms.TabPage mJiraTab;
        private System.Windows.Forms.TextBox mPasswordText;
        private System.Windows.Forms.TextBox mUserNameText;
        private System.Windows.Forms.Button mAutoParserIssueBtn;
        private System.Windows.Forms.CheckBox mLogTypeFilterCheckBox;
        private System.Windows.Forms.Label mUserNameLabel;
        private System.Windows.Forms.Button mParserIssueBtn;
        private System.Windows.Forms.Label mPasswordLabel;
        private System.Windows.Forms.Label mIssueFilterLabel;
        private System.Windows.Forms.TextBox mIssueFilterText;
        private System.Windows.Forms.RichTextBox mJiraStatusConsole;
        private System.Windows.Forms.Button mLoginBtn;
        private System.Windows.Forms.Button mJiraCondtionBtn;
        private System.Windows.Forms.TextBox mJiraCondtionText;
        private System.Windows.Forms.Button mJiraBasicBtn;
        private System.Windows.Forms.TextBox mJiraBaiscText;
        private System.Windows.Forms.Button mAutoAssignBtn;
        private System.Windows.Forms.CheckBox mJiraFilterCheckBox;
        private System.Windows.Forms.CheckBox mJiraBasicCheckBox;
        private System.Windows.Forms.TextBox mPeriodText;
        private System.Windows.Forms.Label mPeriodLabel;
        private System.Windows.Forms.Label mIssueKeyLabel;
        private System.Windows.Forms.TextBox mIssueKeyText;
        private System.Windows.Forms.Button mJiraResetBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox LogTypeText;
        private System.Windows.Forms.Button mContentProfileBtn;
        private System.Windows.Forms.TextBox mContentText;
        private System.Windows.Forms.CheckBox mOrCheckBox;
        private System.Windows.Forms.CheckBox mContentProfileCheckBox;
        private System.Windows.Forms.CheckBox mLoadDefaultCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mMergeSizeLabel;
        private System.Windows.Forms.TextBox mMergeSizeText;
        private System.Windows.Forms.Button mMergeBtn;
        private System.Windows.Forms.CheckBox mContentFilterCheckBox;
        private System.Windows.Forms.CheckBox mParserCrashCheckBox;
        private System.Windows.Forms.CheckBox mParserAnrCheckBox;
    }
}

