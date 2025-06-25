using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repos
{
    internal class BookingRepo : RepoDB, IRepo<Booking, int, Booking>
    {
        public Booking Add(Booking obj)
        {
            db.Bookings.Add(obj);
            db.SaveChanges();

            var room = db.Rooms.Find(obj.room_id);
            if (room != null)
            {
                room.is_available = false;
                db.SaveChanges();
            }

            return obj;
        }

        public bool Delete(int id)
        {
            var booking = db.Bookings.Find(id);
            if (booking == null) return false;
            db.Bookings.Remove(booking);
            return db.SaveChanges() > 0;
        }

        public List<Booking> GetAll()
        {
            return db.Bookings.ToList();
        }

        public Booking GetById(int id)
        {
            return db.Bookings.Find(id);
        }

        public Booking Update(Booking obj)
        {
            var existingBooking = db.Bookings.Find(obj.booking_id);
            if (existingBooking == null) return null;
            db.Entry(existingBooking).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }

        
    }
}
