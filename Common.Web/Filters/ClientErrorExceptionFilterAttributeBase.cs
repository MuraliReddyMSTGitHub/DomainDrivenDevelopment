using Common.Helpers;
using Common.Web.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web.Filters
{
    public abstract class ClientErrorExceptionFilterAttributeBase : ExceptionFilterAttribute
    {
        protected void CreateHttpResponseMessage(ActionExecutedContext context, HttpStatusCode httpStatusCode)
        {
            Argument.RequiresNonNullValue("context", context);
            Argument.Requires("content", context.Exception is ClientErrorException, string.Format("context.Exception property must be of type {0}", typeof(ClientErrorException)));
            var clientErrorException = (ClientErrorException)context.Exception;
            
        }
    }
}
