using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.Repos
{
    internal class RepoDB
    {
        protected HotelBookingDBEntities db;

        public RepoDB()
        {
            db = new HotelBookingDBEntities();
        }
    }
}
