using BBMS.Auth;
using BBMS.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BBMS.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage LogIn(LogInModel logIn)
        {
            try
            {
                var res = AuthService.Authenticate(logIn.Uname, logIn.Pass);
                if (res != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message});
            }
        }
        [Logged]
        [HttpGet]
        [Route("api/logout")]
        public HttpResponseMessage LogOut()
        {
            var token = Request.Headers.Authorization.ToString();
            try
            {
                var res = AuthService.LogOut(token);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = ex.Message });
            }
        }
    }
}
