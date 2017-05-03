using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAlogParser
{
    class AlogParserAdapter
    {
        private Utility mUtility = null;
        private static AlogParserAdapter mInstance = null;
        private Process mAlogParserProcess = null;
        private const string ALOG_PARSER_BINARY_NAME = "AlogParser.exe";
        private const int GENERIC_FAILURE_CODE = -1;

        private AlogParserAdapter()
        {
            mUtility = Utility.getInstance();
            mAlogParserProcess = new Process();
        }

        static public AlogParserAdapter getAlogParserAdapter()
        {
            if (mInstance == null) mInstance = new AlogParserAdapter();
            return mInstance;
        }

        private ProcessStartInfo getProcessInfo()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = ALOG_PARSER_BINARY_NAME;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            return startInfo;
        }

        public int Parser(string file, string userSelection)
        {
            string fileName = file;
            ProcessStartInfo startInfo = getProcessInfo();
            startInfo.Arguments = userSelection + " -f \"" + fileName + "\"";
            Trace.WriteLine("startInfo.Arguments =" + startInfo.Arguments);

            if (fileName == String.Empty || !File.Exists(fileName))
            {
                mUtility.OutputText("Please Choose the Valid Log File ...");
                return GENERIC_FAILURE_CODE;
            }
            mUtility.OutputText("Start Parser : " + fileName);
            return run(startInfo);
        }

        public int GetVersion()
        {
            ProcessStartInfo startInfo = getProcessInfo();
            startInfo.Arguments = "-v";
            return run(startInfo);
        }

        private int run(ProcessStartInfo startInfo)
        {
            int result = GENERIC_FAILURE_CODE;
            try
            {
                mAlogParserProcess = Process.Start(startInfo);
                while (!mAlogParserProcess.StandardOutput.EndOfStream)
                {//output AlogParser's log to screen
                    mUtility.OutputText(mAlogParserProcess.StandardOutput.ReadLine());
                }
                mAlogParserProcess.WaitForExit();
            }
            catch (Exception ex)
            {
                // Log error.
                mUtility.OutputText("run AlogParser error : " + ex);
                return result;
            }
            finally
            {
                result = mAlogParserProcess.ExitCode;
            }
            return result;
        }
    }
}
