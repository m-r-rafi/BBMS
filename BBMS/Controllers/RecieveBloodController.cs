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
    [EnableCors("*", "*", "*")]
    [Logged]
    public class RecieveBloodController : ApiController
    {
        [Route("api/recieveblood")]
        [HttpGet]
        public HttpResponseMessage AllReceive()
        {
            try
            {
                var data = RecieveBloodService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/recieveblood/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = RecieveBloodService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/recieveblood/create")]
        public HttpResponseMessage Create(RecieveBloodDTO recieveblood)
        {
            try
            {
                var res = RecieveBloodService.Create(recieveblood);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/recieveblood/update")]
        public HttpResponseMessage Update(RecieveBloodDTO recieveblood)
        {
            try
            {
                var res = RecieveBloodService.Update(recieveblood);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/recieveblood/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = RecieveBloodService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/recieveblood/history/{id}")]
        public HttpResponseMessage GetByUserId(int id)
        {
            try
            {
                var data = RecieveBloodService.GetByUserId(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/recieveblood/requestblood")]
        public HttpResponseMessage RequestBlood(RequestBloodModel model)
        {
            try
            {
                bool data = RecieveBloodService.RequestBlood(model.UserId, model.BloodName, model.Bags);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
