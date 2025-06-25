using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repos
{
    internal class GuestRepo : RepoDB, IRepo<Guest, int, Guest>
    {
        public Guest Add(Guest obj)
        {
            db.Guests.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var guest = db.Guests.Find(id);
            if (guest == null) return false;
            db.Guests.Remove(guest);
            return db.SaveChanges() > 0;
        }

        public List<Guest> GetAll()
        {
            return db.Guests.ToList();
        }

        public Guest GetById(int id)
        {
            return db.Guests.Find(id);
        }

        public Guest Update(Guest obj)
        {
            var existingGuest = db.Guests.Find(obj.guest_id);
            if (existingGuest == null) return null;
            db.Entry(existingGuest).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
