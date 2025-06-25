using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repos
{
    internal class RoomRepo : RepoDB, IRepo<Room, int, Room>
    {
        public Room Add(Room obj)
        {
            db.Rooms.Add(obj); // Changed 'Room' to 'Rooms' to match the DbSet name in HotelBookingDBEntities2  
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var room = db.Rooms.Find(id); // Changed 'Room' to 'Rooms'  
            if (room == null) return false;
            db.Rooms.Remove(room); // Changed 'Room' to 'Rooms'  
            return db.SaveChanges() > 0;
        }

        public List<Room> GetAll()
        {
            return db.Rooms.ToList(); // Changed 'Room' to 'Rooms'  
        }

        public Room GetById(int id)
        {
            return db.Rooms.Find(id); // Changed 'Room' to 'Rooms'  
        }

        public Room Update(Room obj)
        {
            var existingRoom = db.Rooms.Find(obj.room_id); // Changed 'Room' to 'Rooms'  
            if (existingRoom == null) return null;
            db.Entry(existingRoom).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }

        public List<Room> GetRoomsByType(string type)
        {
            return db.Rooms.Where(r => r.room_type == type).ToList();
        }

        public List<Room> GetAvailableRooms()
        {
            return db.Rooms.Where(r => r.is_available == true).ToList();
        }
    }
}