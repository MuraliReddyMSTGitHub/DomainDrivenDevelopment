using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException(
            string clientMessage = "Bad Request")
            : base(clientMessage)
        { }

       
    }
}
