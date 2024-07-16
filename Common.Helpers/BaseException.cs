using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public abstract class BaseException : Exception
    {

        public int? ErrorCode { get; private set; }

        protected BaseException()
        { }

        protected BaseException(int? errorCode)
        {
            ErrorCode = errorCode;
        }

        protected BaseException(string message, int? errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        protected BaseException(string message, Exception innerException, int? errorCode)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
