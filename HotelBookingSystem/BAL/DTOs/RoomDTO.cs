using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DTOs
{
    public class RoomDTO
    {
        public int room_id { get; set; }
        public string room_number { get; set; }
        public string room_type { get; set; }
        public decimal price_per_night { get; set; }
        public bool is_available { get; set; }
    }
}
