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
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Consultar usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("users")]
        public Task<HttpResponseMessage> Get()
        {
            try
            {
                var users = _userService.GetUsers().ToArray();
                return CreateResponse(users);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }


        /// <summary>
        /// Consultar por Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /Todo
        ///     {
        ///        "userId": (Guid, required)
        ///     }
        /// 
        /// </remarks>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet, Route("user/{userId}")]
        public Task<HttpResponseMessage> Get(Guid userId)
        {
            try
            {
                var users = _userService.GetUserById(userId);
                return CreateResponse(users);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }




        /// <summary>
        /// Criar novo usuário
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Todo
        ///     {
        ///        "firstName": (string, required),
        ///        "lastName": (string, required),
        ///        "email": (string, required),
        ///        "password": (string, required),
        ///     }
        /// 
        /// </remarks>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost, Route("user/save")]
        public Task<HttpResponseMessage> Save(User user)
        {
            try
            {
                _userService.Save(user);
                return CreateResponse(true);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        /// <summary>
        /// Edit usuário
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /Todo
        ///     {
        ///        "userId": (Guid, required),
        ///        "firstName": (string, optional),
        ///        "lastName": (string, optional),
        ///        "email": (string, optional),
        ///        "password": (string, optional),
        ///     }
        /// 
        /// </remarks>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut, Route("user/edit")]
        public Task<HttpResponseMessage> Edit(User user)
        {
            try
            {
                _userService.Update(user);
                return CreateResponse(true);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        /// <summary>
        /// Deletar usuário
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /Todo
        ///     {
        ///        "userId": (Guid, required)
        ///     }
        /// 
        /// </remarks>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete, Route("user/{userId}")]
        public Task<HttpResponseMessage> Delete(Guid userId)
        {
            try
            {
                _userService.Delete(userId);
                return CreateResponse(true);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }


        /// <summary>
        /// Logar 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Todo
        ///     {
        ///        "email": (string, required),
        ///        "password": (string, required)
        ///     }
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost, Route("user/sign-in")]
        public Task<HttpResponseMessage> SignIn(string email, string password)
        {
            try
            {
                var user = _userService.SignIn(email, password);
                if (user == null)
                    return CreateErrorResponse(new BaseError(HttpStatusCode.Unauthorized, "User Unauthorized"));
                return CreateResponse(user);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        /// <summary>
        /// Habilitar usuário
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Todo
        ///     {
        ///        "userId": (Guid, required)
        ///     }
        /// 
        /// </remarks>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost, Route("user/enable")]
        public Task<HttpResponseMessage> Enable(Guid userId)
        {
            try
            {
                _userService.Enable(userId);
                return CreateResponse(true);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }


        /// <summary>
        ///  Desativar usuário
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Todo
        ///     {
        ///        "userId": (Guid, required)
        ///     }
        /// 
        /// </remarks>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost, Route("user/disable")]
        public Task<HttpResponseMessage> Disable(Guid userId)
        {
            try
            {
                _userService.Disable(userId);
                return CreateResponse(true);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        /// <summary>
        /// Esqueceu a senha
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Todo
        ///     {
        ///        "email": (string, required)
        ///     }
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost, Route("user/forgot")]
        public Task<HttpResponseMessage> Forgot(string email)
        {
            try
            {
                var password = _userService.Forgot(email);
                return CreateResponse(password);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(new BaseError(HttpStatusCode.InternalServerError, e.Message));
            }
        }

    }
}