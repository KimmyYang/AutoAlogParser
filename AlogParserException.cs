using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAlogParser
{
    class AlogParserException : Exception
    {

        public const int GENERIC_INTERNAL_ERROR = -1;
        public const int JIRA_CONDITION_IS_EMPTY = -2;
        public const int JIRA_QUERY_NO_ISSUE= -3;
        int mCode = GENERIC_INTERNAL_ERROR;

        public AlogParserException(int code):base(code.ToString())
        {
            mCode = code;
        }

        public String getMessage()
        {
            switch (mCode)
            {
                case JIRA_CONDITION_IS_EMPTY:
                    return "Jira Condition is Empty";
                case JIRA_QUERY_NO_ISSUE:
                    return "Can't query any issue";
                default:
                case GENERIC_INTERNAL_ERROR:
                    return "Generic Internal Error";
            }
        }
    }
}
