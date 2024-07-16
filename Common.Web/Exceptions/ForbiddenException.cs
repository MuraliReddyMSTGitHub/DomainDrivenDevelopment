using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web.Exceptions
{
    [Serializable]
    public class ForbiddenException : Exception
    {
        public ForbiddenException(
            string clientMessage = "Forbidden")
            : base(clientMessage)
        { }

    }
}
