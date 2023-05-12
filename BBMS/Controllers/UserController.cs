using BBMS.Auth;
using BBMS.Models;
using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BBMS.Controllers
{
    [EnableCors("*","*","*")]
    [Logged]
    public class UserController : ApiController
    {
        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage AllUsers()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/user/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = UserService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/user/create")]
        public HttpResponseMessage Create(UserDTO user)
        {
            try
            {
                var res = UserService.Create(user);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/user/update")]
        public HttpResponseMessage UpdateUser(UserDTO user)
        {
            try
            {
                var res = UserService.Update(user);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/user/changePassword")]
        public HttpResponseMessage ChangePassword(PasswordChangeModel model)
        {
            try
            {
                if(model.newPass != model.confirmPass) return Request.CreateResponse(HttpStatusCode.BadRequest,"Passwords are not the same");
                var res = UserService.ChangePassword(model.id,model.currentPass,model.newPass);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/user/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = UserService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
        [HttpGet]
        [Route("api/user/iseligible/{id}")]
        public HttpResponseMessage IsEligible(int id)
        {
            try
            {
                var data = UserService.IsEligible(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
        [HttpPost]
        [Route("api/user/iseligibleupdate")]
        public HttpResponseMessage IsEligibleUpdate(EligibleUpdateModel updateModel)
        {
            try
            {
                var res = UserService.IsEligibleUpdate(updateModel.Id,updateModel.Date);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
