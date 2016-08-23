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

        public int Parser(string file, string userSelection)
        {
            int result = -1;//generic failure
            string fileName = file;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "AlogParser.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.Arguments = userSelection + " -f \"" + fileName + "\"";
            //mUtility.OutputText("startInfo.Arguments =" + startInfo.Arguments);
            Trace.WriteLine("startInfo.Arguments =" + startInfo.Arguments);
            if (fileName == String.Empty || !File.Exists(fileName))
            {
                mUtility.OutputText("Please choose the valid log file ...");
                return result;
            }

            try
            {
                mUtility.OutputText("Start Parser : " + fileName);
                mAlogParserProcess = Process.Start(startInfo);
                mAlogParserProcess.WaitForExit();
            }
            catch (Exception ex)
            {
                // Log error.
                mUtility.OutputText("call AlogParser error : " + ex);
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
