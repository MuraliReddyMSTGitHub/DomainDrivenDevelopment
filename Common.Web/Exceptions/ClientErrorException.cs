using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web.Exceptions
{
    /// <summary>
    ///     Base exception for all exceptions related to client caused errors.
    /// </summary>
    [Serializable]
    public abstract class ClientErrorException : Exception
    {
        private Dictionary<string, object> _clientData;

        public string ClientMessage { get; private set; }

        public IDictionary<string, object> ClientData
        {
            get
            {
                if (_clientData == null)
                    _clientData = new Dictionary<string, object>();
                return _clientData;
            }
        }

        public bool HasClientData
        {
            get { return _clientData != null && _clientData.Count > 0; }
        }

        protected ClientErrorException(string clientMessage)
        {
            Argument.RequiresNonEmptyString("clientMessage", clientMessage);
            ClientMessage = clientMessage;
        }

        protected ClientErrorException(string clientMessage, Exception innerException)
            : base(null, innerException)
        {
            Argument.RequiresNonEmptyString("clientMessage", clientMessage);
            ClientMessage = clientMessage;
        }

        protected ClientErrorException(string clientMessage, string exceptionMessage)
            : base(exceptionMessage)
        {
            Argument.RequiresNonEmptyString("clientMessage", clientMessage);
            ClientMessage = clientMessage;
        }

        protected ClientErrorException(string clientMessage, string exceptionMessage, Exception innerException)
            : base(exceptionMessage, innerException)
        {
            Argument.RequiresNonEmptyString("clientMessage", clientMessage);
            ClientMessage = clientMessage;
        }

        protected ClientErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ClientMessage = info.GetString("ClientMessage");
            _clientData = (Dictionary<string, object>)info.GetValue("ClientData", typeof(Dictionary<string, object>));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ClientMessage", ClientMessage);
            info.AddValue("ClientData", _clientData, typeof(Dictionary<string, object>));
        }
    }
}
