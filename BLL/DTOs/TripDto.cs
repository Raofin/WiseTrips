using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TripDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PackageId { get; set; }
        public int HotelId { get; set; }
        public int Persons { get; set; }
        public DateTime Date { get; set; }
        public int? UsedCoupon { get; set; }
        public int Paid { get; set; }
    }
}
