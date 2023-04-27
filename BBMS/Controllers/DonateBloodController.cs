using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BBMS.Controllers
{
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
        [Route("api/donateblood/history/{id}")]
        public HttpResponseMessage GetByUserId(int id)
        {
            try
            {
                var data = DonateBloodService.GetByUserId(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
