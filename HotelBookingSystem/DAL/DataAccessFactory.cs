using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Guest, int, Guest> GuestDataAccess()
        {
            return new GuestRepo();
        }

        public static IRepo<Room, int, Room> RoomDataAccess()
        {
            return new RoomRepo();
        }

        public static IRepo<Booking, int, Booking> BookingDataAccess()
        {
            return new BookingRepo();
        }

        public static IRoomRepo RoomRepoDataAccess() // Renamed to avoid conflict  
        {
            return (IRoomRepo)new RoomRepo(); // Explicit cast added to resolve CS0266
        }
    }
}
