#  Auto Alog Parser
--------------------

### Environment
* Windows7 /.NET Framework 4.5.2  
* Disk Storage : at least 1G

### Introduction  
This program is written by C#, and use zip, JiraConnector,etc library.    
Auto AlogParser will call AlogParser to merge/parser Android's log(alog/alog_radio).    
Then use JiraConnector to download/link to Jira issue.

### UI Introduce - Log Parser   
* Time - Start Time/End Time (ex.08-17 17:00:18.276)  
* PID - Process ID (ex. 1234)
* TID - Thread ID (ex. 5678)
* Load Default Profile - TagProfile.txt and ContentProfile.txt
* Tag - Enter "Key Word" or load profile
* Content - Load profile
* Or - "or" the filter condition with tag and content
* Merge - Merge alog/alog_radio to alog_merge/alog_radio_merge under the specific path
* Start Parser - Parser the specific log (Choose File)

### UI Introduce - Jira Handler
 * User Name/Password
 * Load Default(Setup) - JiraSetupProfile.txt
 * Issue Filter - Jira search condition
 * Load Default(Condition) - JiraCondition.txt
 * Issue Key - Jira issue key
