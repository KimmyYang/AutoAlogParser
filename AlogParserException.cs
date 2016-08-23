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


        public AlogParserException(int code):base(code.ToString())
        {
        }
    }
}
