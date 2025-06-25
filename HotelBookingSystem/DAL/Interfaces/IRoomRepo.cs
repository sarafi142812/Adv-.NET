using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.Interfaces
{
    public interface IRoomRepo : IRepo<Room, int, Room>
    {
        List<Room> GetAvailableRooms();
    }
}
