using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BAL.DTOs;
using DAL.EF;
using DAL;

namespace BAL.Services
{
    public class BookingService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Booking, BookingDTO>();
                cfg.CreateMap<BookingDTO, Booking>();
            });
            return new Mapper(config);
        }

        public static List<BookingDTO> GetAllBookings()
        {
            var data = DataAccessFactory.BookingDataAccess().GetAll();
            var mapper = GetMapper();
            return mapper.Map<List<BookingDTO>>(data);
        }

        public static BookingDTO GetBooking(int id)
        {
            var data = DataAccessFactory.BookingDataAccess().GetById(id);
            var mapper = GetMapper();
            return mapper.Map<BookingDTO>(data);
        }

        public static BookingDTO AddBooking(BookingDTO booking)
        {
            var mapper = GetMapper();
            var bookingEntity = mapper.Map<Booking>(booking);
            var result = DataAccessFactory.BookingDataAccess().Add(bookingEntity);
            return mapper.Map<BookingDTO>(result);
        }

        public static BookingDTO UpdateBooking(BookingDTO booking)
        {
            var mapper = GetMapper();
            var bookingEntity = mapper.Map<Booking>(booking);
            var result = DataAccessFactory.BookingDataAccess().Update(bookingEntity);
            return mapper.Map<BookingDTO>(result);
        }

        public static bool DeleteBooking(int id)
        {
            return DataAccessFactory.BookingDataAccess().Delete(id);
        }
    }
}
