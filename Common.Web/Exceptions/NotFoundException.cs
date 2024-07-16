using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException(
            string clientMessage = " Not Found")
            : base(clientMessage)
        { }

    }
}
