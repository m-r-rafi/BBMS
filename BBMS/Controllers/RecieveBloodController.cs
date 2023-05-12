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
        [HttpGet]
        [Route("api/recieveblood/getallbystatus/{id}")]
        public HttpResponseMessage GetByStatus(int id)
        {
            try
            {
                var data = RecieveBloodService.GetAllByStatus(id);
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
        [HttpPost]
        [Route("api/recieveblood/history")]
        public HttpResponseMessage GetByUserId(HistoryModel model)
        {
            try
            {
                var data = RecieveBloodService.GetByUserIdStatus(model.Id, model.StatusId);
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
        [HttpGet]
        [Route("api/recieveblood/isallowed/{id}")]
        public HttpResponseMessage IsAllowedRequest(int id)
        {
            try
            {
                var data = RecieveBloodService.IsAllowedRequest(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/recieveblood/donorlist")]
        public HttpResponseMessage DonorList(DonorListModel model)
        {
            try
            {
                List<UserDTO> data = UserService.DonorList(model.Id, model.BloodName);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/receiveblood/viewchangestatus")]
        public HttpResponseMessage ViewChangeStatus(ChangeStatusModel model)
        {
            try
            {
                var data = RecieveBloodService.ViewChangeStatus(model.DonateId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/receiveblood/changestatus")]
        public HttpResponseMessage ChangeStatus(ChangeStatusModel model)
        {
            try
            {
                bool data = RecieveBloodService.ChangeStatus(model.DonateId, (int)model.StatusId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
