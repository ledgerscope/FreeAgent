using RestSharp;
using System;
using System.Net;

namespace FreeAgent.Exceptions
{
    public class FreeAgentException : Exception
    {
        /// <summary>
        /// The response of the error call (for Debugging use)
        /// </summary>
        public IRestResponse Response { get; }
        public HttpStatusCode StatusCode { get; }
        public string ResourceType { get; }

        public string Errors = "";

        public FreeAgentException() : base() { }

        public FreeAgentException(string message) : base(message) { }

        public FreeAgentException(string message, Exception innerException) : base(message, innerException) { }

        public FreeAgentException(IRestResponse response, string resourceType = null, Exception innerException = null) : base(null, innerException)
        {
            Response = response;
            StatusCode = response.StatusCode;
            ResourceType = resourceType;

            try
            {
                var json = Response.Content;
                if (json.Contains("\"errors\""))
                {
                    Errors = json;
                }
            }
            catch
            {
                //do nothing
            }
        }

        public override string ToString()
        {
            return string.Format("FreeAgentException: StatusCode={0}, Content={1}, Resource Type={2}", StatusCode, Response.Content, ResourceType);
        }
    }
}
