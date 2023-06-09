﻿using BBMS.Auth;
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
    public class BloodBankController : ApiController
    {
        [Route("api/bloodbank")]
        [HttpGet]
        public HttpResponseMessage AllBloods()
        {
            try
            {
                var data = BloodBankService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/bloodbank/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = BloodBankService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/bloodbank/create")]
        public HttpResponseMessage Create(BloodBankDTO bloodbank)
        {
            try
            {
                var res = BloodBankService.Create(bloodbank);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/bloodbank/update")]
        public HttpResponseMessage Update(BloodBankDTO bloodbank)
        {
            try
            {
                var res = BloodBankService.Update(bloodbank);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/bloodbank/updatebyadmin")]
        public HttpResponseMessage UpdateByAdmin(AdminUpdate update)
        {
            try
            {
                bool res = BloodBankService.UpdateByAdmin(update.BloodName, update.Bags);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/bloodbank/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = BloodBankService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/bloodbank/availableBlood")]
        public HttpResponseMessage AvailableBlood(AvailableBloodModel model)
        {
            try
            {
                var data = BloodBankService.AvailableBlood(model.BloodName);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
