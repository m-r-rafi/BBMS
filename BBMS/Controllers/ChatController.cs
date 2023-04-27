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
    public class ChatController : ApiController
    {
        [Route("api/chat")]
        [HttpGet]
        public HttpResponseMessage AllChats()
        {
            try
            {
                var data = ChatService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/chat/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = ChatService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/chat/create")]
        public HttpResponseMessage Create(ChatDTO chat)
        {
            try
            {
                var res = ChatService.Create(chat);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/chat/update")]
        public HttpResponseMessage Update(ChatDTO chat)
        {
            try
            {
                var res = ChatService.Update(chat);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/chat/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = ChatService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
