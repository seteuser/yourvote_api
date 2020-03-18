using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Api.BrilhaMuito.Resource;
using Api.BrilhaMuito.Resource.Enum;

namespace Api.BrilhaMuito.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public  class BaseController : ApiController
    {
        /// <summary>
        /// </summary>
        protected new HttpResponseMessage ResponseMessage;

        /// <summary>
        /// </summary>
        /// <param name="response"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        public Task<HttpResponseMessage> CreateResponse<TResponse>(TResponse response)
        {
            ResponseMessage = Request.CreateResponse(new
            {
                Status = DefaultResponseStatus.Success.ToString(),
                Response = response
            });
            ResponseMessage.StatusCode = HttpStatusCode.OK;
            return Task.FromResult(ResponseMessage);
        }

     
        /// <summary>
        /// </summary>
        /// <param name="baseError"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> CreateErrorResponse(BaseError baseError)
        {
            ResponseMessage = Request.CreateResponse(
                new
                {
                    Status = DefaultResponseStatus.Failure.ToString(),
                    ErrorMessage = new BaseErrorResponse((int)baseError.HttpStatusCode, baseError.Message),
                });
            ResponseMessage.StatusCode = baseError.HttpStatusCode;
            return Task.FromResult(ResponseMessage);
        }
    }
}