using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DTOs
{
    public class BookingDTO
    {
        public int booking_id { get; set; }
        public int guest_id { get; set; }
        public int room_id { get; set; }
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; set; }
        public decimal total_price { get; set; }
    }
}
