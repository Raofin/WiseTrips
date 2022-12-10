using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PackageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AgencyId { get; set; }
        public string Country { get; set; }
        public string Details { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
    }
}
