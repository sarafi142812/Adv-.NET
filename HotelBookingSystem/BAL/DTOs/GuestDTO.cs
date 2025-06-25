using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DTOs
{
    public class GuestDTO
    {
        public int guest_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
