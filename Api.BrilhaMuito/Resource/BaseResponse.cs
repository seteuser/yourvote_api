using System;
using System.Net;

namespace Api.BrilhaMuito.Resource
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    [Serializable]
    public class BaseResponse<TResponse>
    {
        /// <summary>
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="response"></param>
        public BaseResponse(int statusCode, TResponse response)
        {
            StatusCode = statusCode;
            Response = response;
        }
        /// <summary>
        /// </summary>
        public int StatusCode { get; }
        /// <summary>
        /// </summary>
        public TResponse Response { get; }
    }

    /// <summary>
    /// </summary>
    [Serializable]
    public class BaseErrorResponse
    {
        /// <summary>
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public BaseErrorResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        /// <summary>
        /// </summary>
        public int StatusCode { get; }
        /// <summary>
        /// </summary>
        public string Message { get; }

    }

    /// <summary>
    /// </summary>
    [Serializable]
    public class BaseError
    {
        /// <summary>
        /// </summary>
        /// <param name="httpStatusCode"></param>
        /// <param name="message"></param>
        public BaseError(HttpStatusCode httpStatusCode, string message)
        {
            HttpStatusCode = httpStatusCode;
            Message = message;
        }
        /// <summary>
        /// </summary>
        public HttpStatusCode HttpStatusCode { set; get; }
        /// <summary>
        /// </summary>
        public string Message { get; set; }
    }
}