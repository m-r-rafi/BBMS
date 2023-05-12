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
    public class DonateBloodController : ApiController
    {
        [Route("api/donateblood")]
        [HttpGet]
        public HttpResponseMessage AllDonate()
        {
            try
            {
                var data = DonateBloodService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/donateblood/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = DonateBloodService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/donateblood/getallbystatus/{id}")]
        public HttpResponseMessage GetByStatus(int id)
        {
            try
            {
                var data = DonateBloodService.GetAllByStatus(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/donateblood/create")]
        public HttpResponseMessage Create(DonateBloodDTO donateblood)
        {
            try
            {
                var res = DonateBloodService.Create(donateblood);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/donateblood/update")]
        public HttpResponseMessage Update(DonateBloodDTO donateblood)
        {
            try
            {
                var res = DonateBloodService.Update(donateblood);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/donateblood/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = DonateBloodService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/donateblood/Donate/{id}")]
        public HttpResponseMessage Donate(int id)
        {
            try
            {
                var isAllowed = DonateBloodService.IsAllowedRequest(id);
                var data = isAllowed ? DonateBloodService.Donate(id) : false;
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/donateblood/isallowed/{id}")]
        public HttpResponseMessage IsAllowedRequest(int id)
        {
            try
            {
                var data = DonateBloodService.IsAllowedRequest(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/donateblood/history")]
        public HttpResponseMessage GetByUserId(HistoryModel model)
        {
            try
            {
                var data = DonateBloodService.GetByUserIdStatus(model.Id, model.StatusId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/donateblood/viewchangestatus")]
        public HttpResponseMessage ViewChangeStatus(ChangeStatusModel model)
        {
            try
            {
                var data = DonateBloodService.ViewChangeStatus(model.DonateId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/donateblood/changestatus")]
        public HttpResponseMessage ChangeStatus(ChangeStatusModel model)
        {
            try
            {
                bool data = DonateBloodService.ChangeStatus(model.DonateId, (int)model.StatusId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
