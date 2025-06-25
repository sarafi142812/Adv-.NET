using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL.DTOs;
using BAL.Services;

namespace HotelBookingSystem.Controllers
{
    public class GuestController : ApiController
    {
        [HttpGet]
        [Route("api/guests/getAll")]
        public HttpResponseMessage GetAllGuests()
        {
            var data = GuestService.GetAllGuests();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/guests/get/{id}")]
        public HttpResponseMessage GetGuest(int id)
        {
            var data = GuestService.GetGuest(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Guest not found");
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/guests/add")]
        public HttpResponseMessage AddGuest(GuestDTO guest)
        {
            var data = GuestService.AddGuest(guest);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }

        [HttpPost]
        [Route("api/guests/update")]
        public HttpResponseMessage UpdateGuest(GuestDTO guest)
        {
            var data = GuestService.UpdateGuest(guest);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/guests/delete/{id}")]
        public HttpResponseMessage DeleteGuest(int id)
        {
            var success = GuestService.DeleteGuest(id);
            if (success)
                return Request.CreateResponse(HttpStatusCode.OK, "Guest deleted");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Guest not found");
        }
    }
}
