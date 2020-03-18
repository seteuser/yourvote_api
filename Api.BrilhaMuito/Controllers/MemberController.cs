using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Api.BrilhaMuito.Resource;
using BrilhaMuito.Domain.Account.Entities;
using BrilhaMuito.Factory.Service.Account;

namespace Api.BrilhaMuito.Controllers
{
    /// <summary>
    /// </summary>
    public class MemberController : BaseController
    {
        private readonly IMemberService _memberService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberService"></param>
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet, Route("members")]
        public Task<HttpResponseMessage> Get(Guid userId)
        {
            try
            {
                var members = _memberService.GetMembersByUserId(userId).ToArray();
                return CreateResponse(members);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [HttpPut, Route("member/edit")]
        public Task<HttpResponseMessage> Edit(Member member)
        {
            try
            {
                _memberService.Update(member);
                return CreateResponse(true);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [HttpPost, Route("member/save")]
        public Task<HttpResponseMessage> Save(Member member)
        {
            try
            {
                _memberService.Save(member);
                return CreateResponse(true);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpDelete, Route("member/{memberId}")]
        public Task<HttpResponseMessage> Delete(Guid memberId)
        {
            try
            {
                _memberService.Delete(memberId);
                return CreateResponse(true);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpGet, Route("member/{memberId}")]
        public Task<HttpResponseMessage> GetMember(Guid memberId)
        {
            try
            {
                var member = _memberService.GetMemberById(memberId);
                return CreateResponse(member);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpPost, Route("member/disable/{memberId}")]
        public Task<HttpResponseMessage> Disable(Guid memberId)
        {
            try
            {
                _memberService.Disable(memberId);
                return CreateResponse(true);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpPost, Route("member/enable/{memberId}")]
        public Task<HttpResponseMessage> Enable(Guid memberId)
        {
            try
            {
                _memberService.Enable(memberId);
                return CreateResponse(true);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

    }
}