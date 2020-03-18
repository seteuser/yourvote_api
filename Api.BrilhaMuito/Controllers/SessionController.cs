using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Api.BrilhaMuito.Resource;
using BrilhaMuito.Domain.Account.Entities;
using BrilhaMuito.Domain.Vote;
using BrilhaMuito.Factory.Service.Account;

namespace Api.BrilhaMuito.Controllers
{
    /// <summary>
    /// </summary>
    public class SessionController : BaseController
    {
        private readonly ISessionService _sessionService;
        private readonly ICandidateService _candidateService;

        /// <summary>
        /// </summary>
        /// <param name="sessionService"></param>
        /// <param name="candidateService"></param>
        public SessionController(ISessionService sessionService, ICandidateService candidateService)
        {
            _sessionService = sessionService;
            _candidateService = candidateService;
        }


        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet, Route("sessions")]
        public Task<HttpResponseMessage> Sessions(Guid userId)
        {
            try
            {
                var sessions = _sessionService.GetSessionsByUserId(userId).ToArray();
                return CreateResponse(sessions);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        /// <summary>
        /// Criar nova sessão
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPost, Route("session/save")]
        public Task<HttpResponseMessage> Save(Session session)
        {
            try
            {
                var token = _sessionService.Save(session);
                return CreateResponse(token);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        [HttpPut, Route("session/edit")]
        public Task<HttpResponseMessage> Edit(Session session)
        {
            try
            {
                var token = _sessionService.Update(session);
                return CreateResponse(token);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        /// <summary>
        /// Deletar Sessão
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [HttpDelete, Route("session/{sessionId}")]
        public Task<HttpResponseMessage> Delete(Guid sessionId)
        {
            try
            {
                _sessionService.Delete(sessionId);
                return CreateResponse(true);
            }
            catch (Exception e)
            {

                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [HttpGet, Route("session/{sessionId}")]
        public Task<HttpResponseMessage> GetSession(Guid sessionId)
        {
            try
            {
                var session = _sessionService.GetSessionById(sessionId);
                return CreateResponse(session);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [HttpPost, Route("session/enable")]
        public Task<HttpResponseMessage> Enable(Guid sessionId)
        {
            try
            {
                _sessionService.Enable(sessionId);
                return CreateResponse(true);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

       
        //[HttpPost, Route("session/disable")]
        //public Task<HttpResponseMessage> Disable(Guid sessionId)
        //{
        //    try
        //    {
        //        _sessionService.Disable(sessionId);
        //        return CreateResponse(true);
        //    }
        //    catch (Exception e)
        //    {
        //        return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
        //    }
        //}

        /// <summary>
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet, Route("session/sign-in/{token}")]
        public Task<HttpResponseMessage> SignIn(string token)
        {
            try
            {
                var session = _sessionService.GetSessionByToken(token);
                if (session.IsClosed)
                    return CreateErrorResponse(new BaseError(HttpStatusCode.Unauthorized, "Session Closed"));
                return CreateResponse(session);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vote"></param>
        /// <returns></returns>
        [HttpPost, Route("session/candidate/vote")]
        public Task<HttpResponseMessage> Vote(PendingVote vote)
        {
            try
            {
                _candidateService.Save(vote);
                return CreateResponse(true);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [HttpPost, Route("session/closed")]
        public Task<HttpResponseMessage> CloseSession(Guid sessionId)
        {
            try
            {
                _sessionService.Disable(sessionId);
                return CreateResponse(sessionId);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [HttpGet, Route("session/compute")]
        public Task<HttpResponseMessage> Compute(Guid sessionId)
        {
            try
            {
                var parameters = _candidateService.Compute(sessionId);
                return CreateResponse(parameters);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}