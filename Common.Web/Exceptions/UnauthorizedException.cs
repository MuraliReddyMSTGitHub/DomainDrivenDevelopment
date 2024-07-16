using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string clientMessage = "Unauthorized")
            : base(clientMessage) { }
    }
}
