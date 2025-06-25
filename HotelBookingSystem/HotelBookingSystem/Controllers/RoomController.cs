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
    public class RoomController : ApiController
    {
        [HttpGet]
        [Route("api/rooms/getAll")]
        public HttpResponseMessage GetAllRooms()
        {
            var data = RoomService.GetAllRooms();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/rooms/get/{id}")]
        public HttpResponseMessage GetRoom(int id)
        {
            var data = RoomService.GetRoom(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Room not found");
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/rooms/add")]
        public HttpResponseMessage AddRoom(RoomDTO room)
        {
            var data = RoomService.AddRoom(room);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }

        [HttpPost]
        [Route("api/rooms/update")]
        public HttpResponseMessage UpdateRoom(RoomDTO room)
        {
            var data = RoomService.UpdateRoom(room);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/rooms/delete/{id}")]
        public HttpResponseMessage DeleteRoom(int id)
        {
            var success = RoomService.DeleteRoom(id);
            if (success)
                return Request.CreateResponse(HttpStatusCode.OK, "Room deleted");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Room not found");
        }

        [HttpGet]
        [Route("api/rooms/bytype/{type}")]
        public HttpResponseMessage GetRoomsByType(string type)
        {
            var data = RoomService.GetRoomsByType(type);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/rooms/available")]
        public HttpResponseMessage GetAvailableRooms()
        {
            var data = RoomService.GetAvailableRooms();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }



    }
}
