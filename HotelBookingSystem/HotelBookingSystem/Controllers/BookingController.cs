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
    public class BookingController : ApiController
    {
        [HttpGet]
        [Route("api/bookings/getAll")]
        public HttpResponseMessage GetAllBookings()
        {
            var data = BookingService.GetAllBookings();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/bookings/get/{id}")]
        public HttpResponseMessage GetBooking(int id)
        {
            var data = BookingService.GetBooking(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Booking not found");
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/bookings/add")]
        public HttpResponseMessage AddBooking(BookingDTO booking)
        {
            var data = BookingService.AddBooking(booking);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }

        [HttpPost]
        [Route("api/bookings/update")]
        public HttpResponseMessage UpdateBooking(BookingDTO booking)
        {
            var data = BookingService.UpdateBooking(booking);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/bookings/delete/{id}")]
        public HttpResponseMessage DeleteBooking(int id)
        {
            var success = BookingService.DeleteBooking(id);
            if (success)
                return Request.CreateResponse(HttpStatusCode.OK, "Booking deleted");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Booking not found");
        }
    }
}
