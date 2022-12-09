using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CouponDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public int AddedBy { get; set; }
        public Nullable<int> SponsoredBy { get; set; }
        public System.DateTime ExpireOn { get; set; }

    }
}
